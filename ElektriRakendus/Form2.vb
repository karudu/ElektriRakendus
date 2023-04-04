﻿Imports PrjAndmebaas

Public Class Form2

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UuendaPaketid()
        UuendaPaketid2()
    End Sub

    Private Sub UuendaPaketid2()
        Dim Masinad As New List(Of IAndmebaas.Kodumasin)
        Dim Andmebaas As New CAndmebaas
        Masinad = Andmebaas.LoeKodumasinad
        comboMasin.Items.Clear()
        Dim Masin As IAndmebaas.Kodumasin
        Dim i = 0
        For Each Masin In Masinad
            Dim Item As New ListViewItem(Masin.Nimi)
            Item.SubItems.Add(Math.Round(Masin.Voimsus, 1).ToString & " W")
            Item.SubItems.Add(Math.Round(Masin.Aeg, 1).ToString & " min")
            ' Indeks on subitem 3
            ' CInt(ListMasinad.Items(i).SubItems(3).Text)
            Item.SubItems.Add(i)
            comboMasin.Items.Add(Masin.Nimi)
            i += 1
        Next

        Dim Hinnad As New List(Of Decimal)
        Hinnad = Andmebaas.LoeBorsihinnad(Date.Now.AddDays(-30), 10)
        Hinnad = Andmebaas.LoeBorsihinnad(Date.Now.AddDays(-20), 10)
        Hinnad = Andmebaas.LoeBorsihinnad(Date.Now.AddDays(-10), 10)
        Hinnad = Andmebaas.LoeBorsihinnad(Date.Now.AddDays(-1), 24)
        Hinnad = Andmebaas.LoeBorsihinnad(Date.Now.AddDays(-30), 24 * 30)
        Hinnad = Nothing
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
        Dim sadasd As Integer = 0
    End Sub


    Private Sub tootle(ByRef Kalkulaator As Kalkulaator)
        TextBox4.Text = Kalkulaator.Rahalinekulu

    End Sub
    Private Sub Arvuta_Click(sender As Object, e As EventArgs) Handles Arvuta.Click
        If ListBors.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        Select Case ComboBox2.SelectedIndex
            Case 0
                Dim Andmebaas As New CAndmebaas
                Dim Pakett As New IAndmebaas.PkBors
                Dim ID As Integer
                Dim kuutasu As Decimal

                ID = CInt(ListBors.SelectedItems(0).SubItems(4).Text) ' ID on subitem 4
                Pakett = Andmebaas.LoePakettBors(ID)
                kuutasu = CDec(Pakett.Kuutasu) + CDec(Pakett.Juurdetasu)

                Dim KodumasinaKasutus As New KodumasinaKasutus(kuutasu, SeadmeV.Text, KasutusAeg.Text)

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
                    kuutasu = CDec(Pakett.Kuutasu) + CDec(Pakett.OTariif)
                Else
                    kuutasu = CDec(Pakett.Kuutasu) + CDec(Pakett.PTariif)
                End If

                Dim KodumasinaKasutus As New KodumasinaKasutus(kuutasu, SeadmeV.Text, KasutusAeg.Text)
                tootle(KodumasinaKasutus)
            Case 2


                Dim Andmebaas As New CAndmebaas
                Dim Pakett As New IAndmebaas.PkUniv
                Dim ID As Integer
                ID = CInt(ListBors.SelectedItems(0).SubItems(4).Text) ' ID on subitem 4
                Pakett = Andmebaas.LoePakettUniv(ID)
                Dim KodumasinaKasutus As New KodumasinaKasutus(Pakett.Kuutasu, SeadmeV.Text, KasutusAeg.Text)
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
        UuendaPaketid2()
    End Sub
End Class