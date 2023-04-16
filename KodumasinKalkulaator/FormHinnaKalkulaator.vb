Imports PrjAndmebaas

Public Class FormHinnaKalkulaator
    Private Const KAIBEMAKS = 1.2 ' 20%
    ' Leia fikseeritud paketi tunnihind ühe tunni jaoks
    Private Function FixTunniHind(Pakett As IAndmebaas.PkFix, Kuupaev As Date) As Decimal
        ' Laupäev/pühapäeval kogu ööpäev öötariifiga
        If Kuupaev.DayOfWeek = DayOfWeek.Saturday Or Kuupaev.DayOfWeek = DayOfWeek.Sunday Then
            Return Pakett.OTariif
        End If
        ' Öötariif 22:00-7:00
        If Kuupaev.Hour >= 22 Or Kuupaev.Hour <= 7 Then Return Pakett.OTariif
        ' Muidu päevatariif
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
        Hinnad = Andmebaas.LoeBorsihinnadSentkWh(AlgusAeg, NHinnad)

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
    Private GPaketid As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
    ' Uuenda pakettide combobox'is näidatavaid pakette
    Private Sub UuendaPaketid()
        Dim Paketid As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
        Dim Andmebaas As New CAndmebaas

        ' Loe paketid
        Paketid = Andmebaas.LoePakettideNimekiri()

        ' Tühjenda nimekirjad
        CbPaketid.Items.Clear()
        GPaketid.Clear()

        ' Lisa paketid combobox'i
        For Each Pakett In Paketid
            CbPaketid.Items.Add(Pakett.Nimi)
            GPaketid.Add(Pakett)
        Next
    End Sub
    ' Hinna arvutamise nupp
    Private Sub BtnArvuta_Click(sender As Object, e As EventArgs) Handles BtnArvuta.Click
        Dim Andmebaas As New PrjAndmebaas.CAndmebaas

        ' Kontrolli, kas pakett on valitud
        If CbPaketid.SelectedIndex = -1 Then
            MessageBox.Show("Vali elektripakett", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Kontrolli, kas nimekirjas on vähemalt üks ajavahemik
        If ListAjad.Items.Count = 0 Then
            MessageBox.Show("Vaja on vähemalt ühte ajavahemikku", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Kontrolli, kas võimsus on antud
        Dim Voimsus As Double
        If Not Double.TryParse(TxtVoimsus.Text, Voimsus) Then
            MessageBox.Show("Ebakorrektne võimsus", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Ei tohi olla negatiivne
        If Voimsus < 0 Then
            MessageBox.Show("Ebakorrektne võimsus", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim NimekiriPakett = GPaketid(CbPaketid.SelectedIndex) ' Valitud pakett 
        Dim Hind As Double = 0

        ' Arvuta hind vastavalt paketi tüübile, käies läbi kõik ajavahemikud
        Select Case NimekiriPakett.Tyyp
            Case IAndmebaas.PaketiTyyp.PAKETT_BORS
                For Each Aeg In ListAjad.Items
                    Dim Pakett = Andmebaas.LoePakettBors(NimekiriPakett.ID)
                    Dim Algus As Date = Date.ParseExact(Aeg.SubItems(0).Text, "MM.dd.yyyy HH:mm",
                                                            Nothing)
                    Dim Lopp As Date = Date.ParseExact(Aeg.SubItems(1).Text, "MM.dd.yyyy HH:mm",
                                                           Nothing)
                    Dim Kestus = (Lopp - Algus).TotalHours

                    ' Tarbimise hind EUR/kWh * võimsus kW
                    Hind += (LeiaHindBors(Pakett, Algus, Kestus) / 100) * (Voimsus / 1000)
                Next
            Case IAndmebaas.PaketiTyyp.PAKETT_FIX
                For Each Aeg In ListAjad.Items
                    Dim Pakett = Andmebaas.LoePakettFix(NimekiriPakett.ID)
                    Dim Algus As Date = Date.ParseExact(Aeg.SubItems(0).Text, "MM.dd.yyyy HH:mm",
                                                            Nothing)
                    Dim Lopp As Date = Date.ParseExact(Aeg.SubItems(1).Text, "MM.dd.yyyy HH:mm",
                                                           Nothing)
                    Dim Kestus = (Lopp - Algus).TotalHours

                    ' Tarbimise hind EUR/kWh * võimsus kW + käibemaks
                    Hind += (LeiaHindFix(Pakett, Algus, Kestus) / 100) * KAIBEMAKS * (Voimsus / 1000)
                Next
            Case IAndmebaas.PaketiTyyp.PAKETT_UNIV
                For Each Aeg In ListAjad.Items
                    Dim Pakett = Andmebaas.LoePakettUniv(NimekiriPakett.ID)
                    Dim Algus As Date = Date.ParseExact(Aeg.SubItems(0).Text, "MM.dd.yyyy HH:mm",
                                                            Nothing)
                    Dim Lopp As Date = Date.ParseExact(Aeg.SubItems(1).Text, "MM.dd.yyyy HH:mm",
                                                           Nothing)
                    Dim Kestus = (Lopp - Algus).TotalHours

                    ' Tarbimise hind EUR/kWh * võimsus kW + käibemaks
                    Hind += (LeiaHindUniv(Pakett, Kestus) / 100) * KAIBEMAKS * (Voimsus / 1000)
                Next
        End Select

        ' Kuva tulemus
        TxtHind.Text = "€" & Math.Round(Hind, 2).ToString("F2")
    End Sub

    Private Sub FormHinnaKalkulaator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UuendaPaketid()
    End Sub
End Class
