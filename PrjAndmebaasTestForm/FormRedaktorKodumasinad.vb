Imports PrjAndmebaas

Public Class FormRedaktorKodumasinad
    Private Masinad As New List(Of IAndmebaas.Kodumasin)
    ' Uuenda aknas näidatud kodumasinaid
    Private Sub UuendaMasinad()
        Dim Andmebaas As New CAndmebaas

        ' Loe kodumasinad sisse
        Masinad = Andmebaas.LoeKodumasinad

        ' Tee nimekiri tühjaks
        ListMasinad.Items.Clear()

        ' Lisa kõik kodumasinad nimekirja
        Dim i = 0
        For Each Masin In Masinad
            Dim Item As New ListViewItem(Masin.Nimi)

            ' Lisa andmed nimekirja objekti
            Item.SubItems.Add(Math.Round(Masin.Voimsus, 1).ToString & " W")
            Item.SubItems.Add(Math.Round(Masin.Aeg, 1).ToString & " min")
            ' Indeksi lugemine: CInt(ListMasinad.Items(i).SubItems(3).Text)
            Item.SubItems.Add(i) ' Indeks on subitem 3

            ' Lisa kodumasin nimekirja
            ListMasinad.Items.Add(Item)
            i += 1
        Next
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UuendaMasinad()
    End Sub
    ' Ava kodumasina lisamise dialoog
    Private Sub BtnLisaMasin_Click(sender As Object, e As EventArgs) Handles BtnLisaMasin.Click
        Dim FormLisaKodumasin As New FormLisaKodumasin
        FormLisaKodumasin.ShowDialog()
        UuendaMasinad()
    End Sub
    ' Ava kodumasina muutmise dialoog
    Private Sub BtnMuudaMasin_Click(sender As Object, e As EventArgs) Handles BtnMuudaMasin.Click
        ' Lõpeta, kui ühtegi kodumasinat pole
        If ListMasinad.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        ' Loe valitud kodumasina andmed
        Dim Masin As IAndmebaas.Kodumasin
        Masin = Masinad(CInt(ListMasinad.SelectedItems(0).SubItems(3).Text)) ' Indeks on subitem 3

        ' Ava dialoog kodumasina andmetega
        Dim FormMuudaKodumasin As New FormMuudaKodumasin(Masin.ID)
        FormMuudaKodumasin.TxtNimi.Text = Masin.Nimi
        FormMuudaKodumasin.TxtVoimsus.Text = Masin.Voimsus.ToString
        FormMuudaKodumasin.TxtAeg.Text = Masin.Aeg.ToString
        FormMuudaKodumasin.ShowDialog()
        UuendaMasinad()
    End Sub
    ' Kustuta kodumasin
    Private Sub BtnKustutaBors_Click(sender As Object, e As EventArgs) Handles BtnKustutaMasin.Click
        ' Lõpeta, kui ühtegi kodumasinat pole
        If ListMasinad.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        ' Küsi, kas kasutaja tahab kodumasina ära kustutada
        Dim Tulemus As DialogResult = MessageBox.Show("Kustuta valitud kodumasin?",
                                                      "Kustuta",
                                                      MessageBoxButtons.YesNo)
        If Not Tulemus = DialogResult.Yes Then
            Exit Sub
        End If

        ' Kustuta valitud kodumasin
        Dim Andmebaas As New CAndmebaas
        Dim Masin As IAndmebaas.Kodumasin
        Masin = Masinad(CInt(ListMasinad.SelectedItems(0).SubItems(3).Text)) ' Indeks on subitem 3
        Andmebaas.KustutaKodumasin(Masin.ID)
        UuendaMasinad()
    End Sub
End Class