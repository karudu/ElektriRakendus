Imports PrjAndmebaas

Public Class FormRedaktorKodumasinad
    Private Masinad As New List(Of IAndmebaas.Kodumasin)
    Private Sub UuendaMasinad()
        Dim Andmebaas As New CAndmebaas
        Masinad = Andmebaas.LoeKodumasinad

        ListMasinad.Items.Clear()

        Dim i = 0
        For Each Masin In Masinad
            Dim Item As New ListViewItem(Masin.Nimi)
            Item.SubItems.Add(Math.Round(Masin.Voimsus, 1).ToString & " W")
            Item.SubItems.Add(Math.Round(Masin.Aeg, 1).ToString & " min")
            ' Indeks on subitem 3
            ' CInt(ListMasinad.Items(i).SubItems(3).Text)
            Item.SubItems.Add(i)
            ListMasinad.Items.Add(Item)
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
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UuendaMasinad()
    End Sub
    ' TODO Parem valideerimine sisestatud andmete jaoks
    Private Sub BtnLisaMasin_Click(sender As Object, e As EventArgs) Handles BtnLisaMasin.Click
        Dim FormLisaKodumasin As New FormLisaKodumasin
        FormLisaKodumasin.ShowDialog()
        UuendaMasinad()
    End Sub

    Private Sub BtnMuudaMasin_Click(sender As Object, e As EventArgs) Handles BtnMuudaMasin.Click
        If ListMasinad.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        Dim Masin As IAndmebaas.Kodumasin
        ' Indeks on subitem 3
        Masin = Masinad(CInt(ListMasinad.SelectedItems(0).SubItems(3).Text))

        Dim FormMuudaKodumasin As New FormMuudaKodumasin(Masin.ID)
        FormMuudaKodumasin.TxtNimi.Text = Masin.Nimi
        FormMuudaKodumasin.TxtVoimsus.Text = Masin.Voimsus.ToString
        FormMuudaKodumasin.TxtAeg.Text = Masin.Aeg.ToString
        FormMuudaKodumasin.ShowDialog()
        UuendaMasinad()
    End Sub

    Private Sub BtnKustutaBors_Click(sender As Object, e As EventArgs) Handles BtnKustutaMasin.Click
        If ListMasinad.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        ' MessageBox'i nuppude teksti muuta ei saa
        Dim Tulemus As DialogResult = MessageBox.Show("Kustuta valitud kodumasin?",
                                                      "Kustuta",
                                                      MessageBoxButtons.YesNo)
        If Not Tulemus = DialogResult.Yes Then
            Exit Sub
        End If

        Dim Andmebaas As New CAndmebaas
        Dim Masin As IAndmebaas.Kodumasin
        ' Indeks on subitem 3
        Masin = Masinad(CInt(ListMasinad.SelectedItems(0).SubItems(3).Text))
        Andmebaas.KustutaKodumasin(Masin.ID)
        UuendaMasinad()
    End Sub
End Class