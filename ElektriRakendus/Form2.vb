Imports System.Net
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports PrjAndmebaas

Public Class Form2
    Private GMasinad As New List(Of IAndmebaas.Kodumasin)


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UuendaPaketid()
        UuendaPaketid2()

    End Sub

    Private Sub UuendaPaketid2()
        Dim Masinad As New List(Of IAndmebaas.Kodumasin)
        Dim Andmebaas As New CAndmebaas
        Masinad = Andmebaas.LoeKodumasinad
        comboMasin.Items.Clear()
        GMasinad.Clear()
        Dim Masin As IAndmebaas.Kodumasin
        Dim i = 0
        For Each Masin In Masinad
            comboMasin.Items.Add(Masin.Nimi)
            GMasinad.Add(Masin)

            i += 1


        Next

    End Sub
    Private Sub UuendaPaketid()
        Dim Paketid As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
        Dim Andmebaas As New CAndmebaas
        Paketid = Andmebaas.LoePakettideNimekiri
        ListBors.Items.Clear()
        Select Case ComboBox2.SelectedIndex
            Case 0
                For Each Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp) In Paketid
                    Select Case Pakett.Tyyp
                        Case IAndmebaas.PaketiTyyp.PAKETT_BORS
                            Dim PakettBors As New IAndmebaas.PkBors
                            PakettBors = Andmebaas.LoePakettBors(Pakett.ID)
                            Dim Item As New ListViewItem(PakettBors.Nimi)
                            Item.SubItems.Add(Math.Round(PakettBors.Juurdetasu, 2).ToString & " senti/kWh")
                            Item.SubItems.Add("€" & Math.Round(PakettBors.Kuutasu, 2).ToString)
                            Item.SubItems.Add(0)
                            Item.SubItems.Add(Pakett.ID)
                            ListBors.Items.Add(Item)
                    End Select
                    ' ID on subitem 4
                    ' CInt(ListBors.Items(i).SubItems(4).Text)
                Next
            Case 1
                For Each Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp) In Paketid
                    Select Case Pakett.Tyyp
                        Case IAndmebaas.PaketiTyyp.PAKETT_FIX
                            Dim PakettFix As New IAndmebaas.PkFix
                            PakettFix = Andmebaas.LoePakettFix(Pakett.ID)
                            Dim Item As New ListViewItem(PakettFix.Nimi)
                            Item.SubItems.Add(Math.Round(PakettFix.PTariif, 2).ToString & " senti/kWh")
                            Item.SubItems.Add(Math.Round(PakettFix.OTariif, 2).ToString & " senti/kWh")
                            Item.SubItems.Add("€" & Math.Round(PakettFix.Kuutasu, 2).ToString)
                            Item.SubItems.Add(Pakett.ID)
                            ListBors.Items.Add(Item)
                    End Select
                Next
            Case 2
                For Each Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp) In Paketid
                    Select Case Pakett.Tyyp
                        Case IAndmebaas.PaketiTyyp.PAKETT_UNIV
                            Dim PakettUniv As New IAndmebaas.PkUniv
                            PakettUniv = Andmebaas.LoePakettUniv(Pakett.ID)
                            Dim Item As New ListViewItem(PakettUniv.Nimi)
                            Item.SubItems.Add(Math.Round(PakettUniv.Baas, 2).ToString & " senti/kWh")
                            Item.SubItems.Add(Math.Round(PakettUniv.Marginaal, 2).ToString & " senti/kWh")
                            Item.SubItems.Add("€" & Math.Round(PakettUniv.Kuutasu, 2).ToString)
                            Item.SubItems.Add(Pakett.ID)
                            ListBors.Items.Add(Item)
                    End Select
                Next

        End Select

    End Sub


    Private Sub tootle(ByRef Kalkulaator As Kalkulaator)
        TextBox4.Text = Math.Round(Kalkulaator.Rahalinekulu, 2) & " €"
        TextBox1.Text = Math.Round(Kalkulaator.Rahalinekulu * 30, 2) & " €"

    End Sub
    Private Sub Arvuta_Click(sender As Object, e As EventArgs) Handles Arvuta.Click
        If comboMasin.SelectedItem = Nothing Then
            Exit Sub
        End If
        Dim Masinad As New List(Of IAndmebaas.Kodumasin)
        Dim Andmebas As New CAndmebaas
        Masinad = Andmebas.LoeKodumasinad
        Dim Masin As IAndmebaas.Kodumasin
        Dim i = 0
        Dim energia As Double
        Dim aeg As Double


        For Each Masin In Masinad  'loop selleks et leida cboxPakett1 valitud paketti indexi listist

            If comboMasin.Text = Masin.Nimi Then
                energia = Masin.Voimsus
                aeg = Masin.Aeg / 60 'muudame minutid tundideks
                Exit For
            End If
        Next




        If ListBors.SelectedItems.Count = 0 Then
            Exit Sub
        End If


        Select Case ComboBox2.SelectedIndex

            Case 0
                Dim Andmebaas As New CAndmebaas
                Dim Pakett As New IAndmebaas.PkBors
                Dim ID As Integer
                Dim kuutasu As Decimal
                Dim Borsihinnad As List(Of Decimal)
                Dim Kuupaev As Date = Date.Now
                Kuupaev = Kuupaev.AddHours(-Kuupaev.Hour)
                Kuupaev = Kuupaev.AddMinutes(-Kuupaev.Minute)
                Kuupaev = Kuupaev.AddSeconds(-Kuupaev.Second)

                ID = CInt(ListBors.SelectedItems(0).SubItems(4).Text) ' ID on subitem 4
                Pakett = Andmebaas.LoePakettBors(ID)
                Borsihinnad = Andmebaas.LoeBorsihinnad(Kuupaev, 24)

                Dim Keskmine As Decimal = 0
                For j As Integer = 0 To 23
                    Keskmine += Borsihinnad(j) / 10
                Next
                Keskmine /= 24

                Dim KodumasinaKasutus As New KodumasinaKasutus(Keskmine, energia, aeg)

                tootle(KodumasinaKasutus)
            Case 1
                Dim Tund As Integer
                Tund = Date.Now.Hour
                Dim Andmebaas As New CAndmebaas
                Dim Pakett As New IAndmebaas.PkFix
                Dim ID As Integer
                ID = CInt(ListBors.SelectedItems(0).SubItems(4).Text) ' ID on subitem 4
                Pakett = Andmebaas.LoePakettFix(ID)
                Dim kuutasu As Decimal
                If Tund <= 7 Or Tund >= 22 Then
                    kuutasu = CDec(Pakett.OTariif)
                Else
                    kuutasu = CDec(Pakett.PTariif)
                End If

                Dim KodumasinaKasutus As New KodumasinaKasutus(kuutasu, energia, aeg)
                tootle(KodumasinaKasutus)
            Case 2


                Dim Andmebaas As New CAndmebaas
                Dim Pakett As New IAndmebaas.PkUniv
                Dim ID As Integer
                ID = CInt(ListBors.SelectedItems(0).SubItems(4).Text) ' ID on subitem 4
                Pakett = Andmebaas.LoePakettUniv(ID)
                Dim KodumasinaKasutus As New KodumasinaKasutus(Pakett.Baas + Pakett.Marginaal, energia, aeg)
                tootle(KodumasinaKasutus)
        End Select



        'If IsNumeric(SeadmeV.Text) = True And IsNumeric(KasutusAeg.Text) = True Then


        ''Dim KodumasinaKasutus As New KodumasinaKasutus(TextBox1.Text, SeadmeV.Text, KasutusAeg.Text)
        ''tootle(KodumasinaKasutus)

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        UuendaPaketid()
    End Sub

    Private Sub comboMasin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboMasin.SelectedIndexChanged
        LblVoimsus.Text = GMasinad(comboMasin.SelectedIndex).Voimsus.ToString & " W"
        LblAeg.Text = GMasinad(comboMasin.SelectedIndex).Aeg.ToString & " min"
    End Sub
End Class