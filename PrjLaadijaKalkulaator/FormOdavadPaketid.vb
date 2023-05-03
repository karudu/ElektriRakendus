Imports System.Net
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports PrjAndmebaas

Public Class FormOdavadPaketid
    Private Const KAIBEMAKS = 1.2 ' 20%
    ' Leia fikseeritud paketi tunnihind ühe tunni jaoks
    Private Function FixTunniHind(Pakett As IAndmebaas.PkFix, Kuupaev As Date) As Decimal
        If Kuupaev.DayOfWeek = DayOfWeek.Saturday Or Kuupaev.DayOfWeek = DayOfWeek.Sunday Then
            Return Pakett.OTariif
        End If
        If Kuupaev.Hour >= 22 Or Kuupaev.Hour <= 7 Then Return Pakett.OTariif
        Return Pakett.PTariif
    End Function
    ' Leia fikseeritud paketi kogu tarbimise hind ajavahemiku jaoks (sent/kWh)
    Private Function LeiaHindFix(Pakett As IAndmebaas.PkFix, AlgusAeg As Date, Tunnid As Double) As Decimal
        Dim Kokku As Decimal = 0

        ' Esimene tund osaline
        If Not AlgusAeg.Minute = 0 And Tunnid > 1 Then
            Dim Minutid As Double = 60 - AlgusAeg.Minute ' Minuteid jäänud
            Dim TunniOsa As Double = Minutid / 60

            Kokku += FixTunniHind(Pakett, AlgusAeg) * TunniOsa

            Tunnid -= TunniOsa
            AlgusAeg.AddMinutes(Minutid) ' Järgmine tund
        End If

        ' Täistunnid
        Dim TunnidT = Math.Floor(Tunnid)
        For i As Integer = 0 To TunnidT - 1
            Kokku += FixTunniHind(Pakett, AlgusAeg)
            AlgusAeg.AddHours(1)
        Next

        ' Viimane tund osaline
        Tunnid -= TunnidT
        If Not Tunnid = 0 Then
            Kokku += FixTunniHind(Pakett, AlgusAeg) * Tunnid
        End If

        Return Kokku
    End Function
    ' Leia universaalpaketi kogu tarbimise hind ajaperioodi jaoks (sent/kWh)
    Private Function LeiaHindUniv(Pakett As IAndmebaas.PkUniv, Tunnid As Double) As Decimal
        Dim Tasu = Pakett.Baas + Pakett.Marginaal
        Return Tasu * Tunnid
    End Function
    ' Leia börsipaketi kogu tarbimise hind ajavahemiku jaoks (sent/kWh), hinnale on arvestatud käibemaks
    Private Function LeiaHindBors(Pakett As IAndmebaas.PkBors, AlgusAeg As Date, Tunnid As Double) As Decimal
        Dim Andmebaas As New CAndmebaas
        Dim Juurdetasu As Decimal = Pakett.Juurdetasu
        Dim ETund As Double = 0
        Dim VTund As Double = 0
        Dim NHinnad = 0
        Dim Hinnad As New List(Of Decimal)
        Dim Kokku As Decimal = 0

        ' Leia loetavate börsihindade arv, ning esimese ja viimase
        ' tunni hinna tegurid
        ' Esimene tund osaline
        If Not AlgusAeg.Minute = 0 And Tunnid > 1 Then
            Dim Minutid As Double = 60 - AlgusAeg.Minute ' Minuteid jäänud
            Dim TunniOsa As Double = Minutid / 60

            ETund = TunniOsa
            NHinnad += 1

            Tunnid -= TunniOsa
        End If

        ' Täistunnid
        Dim TunnidT = Math.Floor(Tunnid)
        NHinnad += TunnidT

        ' Viimane tund osaline
        Tunnid -= TunnidT
        If Not Tunnid = 0 Then
            VTund = Tunnid
            NHinnad += 1
        End If

        ' Loe börsihinnad
        Dim HindI = 0
        Try
            Hinnad = Andmebaas.LoeBorsihinnadSentkWh(AlgusAeg, NHinnad)
        Catch ex As Exception
            Return 0
        End Try

        ' Arvuta koguhind
        If Not ETund = 0 Then
            Kokku += (Hinnad(HindI) + Juurdetasu) * ETund
            HindI += 1
        End If
        For i As Integer = 0 To TunnidT - 1
            Kokku += Hinnad(HindI) + Juurdetasu
            HindI += 1
        Next
        If Not VTund = 0 Then
            Kokku += (Hinnad(HindI) + Juurdetasu) * VTund
        End If

        Return Kokku
    End Function
    ' Ajavahemiku lisamise nupp
    Private Sub BtnLisa_Click(sender As Object, e As EventArgs) Handles BtnLisa.Click
        ' Ümarda algkuupäev minuti peale
        Dim D As Date = DtpAlgus.Value
        DtpAlgus.Value = New Date(D.Year, D.Month, D.Day, D.Hour, D.Minute, 0)
        ' Ümarda lõppkuupäev minuti peale
        D = DtpLopp.Value
        DtpLopp.Value = New Date(D.Year, D.Month, D.Day, D.Hour, D.Minute, 0)

        ' Kuupäevade järjekorra kontroll
        If DtpAlgus.Value >= DtpLopp.Value Then
            MessageBox.Show("Lõppaeg peab olema hiljem, kui algus", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Kontrolli, kas ajavahemik on juba kaetud
        For i As Integer = 0 To ListAjad.Items.Count - 1
            Dim Algus As Date = Date.ParseExact(ListAjad.Items(i).SubItems(0).Text, "MM.dd.yyyy HH:mm",
                                                Nothing)
            Dim Lopp As Date = Date.ParseExact(ListAjad.Items(i).SubItems(1).Text, "MM.dd.yyyy HH:mm",
                                                Nothing)

            If DtpAlgus.Value >= Algus And DtpAlgus.Value <= Lopp Then
                MessageBox.Show("Ajavahemik on juba olemas", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If DtpLopp.Value >= Algus And DtpLopp.Value <= Lopp Then
                MessageBox.Show("Ajavahemik on juba olemas", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Next

        ' Lisa uus ajavahemik nimekirja
        Dim Item As New ListViewItem(DtpAlgus.Value.ToString("MM.dd.yyyy HH:mm"))
        Item.SubItems.Add(DtpLopp.Value.ToString("MM.dd.yyyy HH:mm"))
        ListAjad.Items.Add(Item)
    End Sub
    ' Ajavahemiku kustutamise nupp
    Private Sub BtnKustutaAeg_Click(sender As Object, e As EventArgs) Handles BtnKustutaAeg.Click
        For Each i As ListViewItem In ListAjad.SelectedItems
            ListAjad.Items.Remove(i)
        Next
    End Sub
    ' Pakettide arvutamise nupp
    Private Sub BtnArvuta_Click(sender As Object, e As EventArgs) Handles BtnArvuta.Click
        Dim Andmebaas As New PrjAndmebaas.CAndmebaas

        ' Kontrolli, kas nimekirjas on vähemalt üks ajavahemik
        If ListAjad.Items.Count = 0 Then
            MessageBox.Show("Vaja on vähemalt ühte ajavahemikku", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim Nimekiri As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
        Dim Hinnad As New List(Of (Nimi As String, Hind As Decimal))

        ' Loe kõik olemasolevad paketid
        Nimekiri = Andmebaas.LoePakettideNimekiri()

        ' Kontrolli, kas pakette on üldse olemas
        If Nimekiri.Count = 0 Then
            MessageBox.Show("Rakenduses pole elektripakette, lisa vähemalt üks pakett", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Arvuta kõikide pakettide jaoks koguhinnad vahemikes
        For i As Integer = 0 To Nimekiri.Count - 1
            Dim PakettN = Nimekiri(i)
            Dim Hind As Double = 0

            ' Arvuta kõikide vahemike hindade summa vastavalt paketi tüübile
            Select Case PakettN.Tyyp
                Case IAndmebaas.PaketiTyyp.PAKETT_BORS
                    For Each Aeg In ListAjad.Items
                        Dim Algus As Date = Date.ParseExact(Aeg.SubItems(0).Text, "MM.dd.yyyy HH:mm",
                                                            Nothing)
                        Dim Lopp As Date = Date.ParseExact(Aeg.SubItems(1).Text, "MM.dd.yyyy HH:mm",
                                                           Nothing)
                        Dim Kestus = (Lopp - Algus).TotalHours
                        Dim Pakett = Andmebaas.LoePakettBors(PakettN.ID)

                        Hind += LeiaHindBors(Pakett, Algus, Kestus)
                    Next
                Case IAndmebaas.PaketiTyyp.PAKETT_FIX
                    For Each Aeg In ListAjad.Items
                        Dim Algus As Date = Date.ParseExact(Aeg.SubItems(0).Text, "MM.dd.yyyy HH:mm",
                                                            Nothing)
                        Dim Lopp As Date = Date.ParseExact(Aeg.SubItems(1).Text, "MM.dd.yyyy HH:mm",
                                                           Nothing)
                        Dim Kestus = (Lopp - Algus).TotalHours
                        Dim Pakett = Andmebaas.LoePakettFix(PakettN.ID)

                        Hind += LeiaHindFix(Pakett, Algus, Kestus) * KAIBEMAKS
                    Next
                Case IAndmebaas.PaketiTyyp.PAKETT_UNIV
                    For Each Aeg In ListAjad.Items
                        Dim Algus As Date = Date.ParseExact(Aeg.SubItems(0).Text, "MM.dd.yyyy HH:mm",
                                                            Nothing)
                        Dim Lopp As Date = Date.ParseExact(Aeg.SubItems(1).Text, "MM.dd.yyyy HH:mm",
                                                           Nothing)
                        Dim Kestus = (Lopp - Algus).TotalHours
                        Dim Pakett = Andmebaas.LoePakettUniv(PakettN.ID)

                        Hind += LeiaHindUniv(Pakett, Kestus) * KAIBEMAKS
                    Next
            End Select
            ' Lisa pakett ja selle hind nimekirja
            Hinnad.Add((PakettN.Nimi, Hind))
        Next

        ' Kuva paketid, sorteeri odavamad esimesena
        Hinnad = Hinnad.OrderBy(Function(X) X.Hind).ToList
        RtxPaketid.Clear()
        For Each Pakett In Hinnad
            RtxPaketid.AppendText(Pakett.Nimi & " (" & Math.Round(Pakett.Hind, 2).ToString &
                                  ")" & Environment.NewLine)
        Next
    End Sub
End Class
