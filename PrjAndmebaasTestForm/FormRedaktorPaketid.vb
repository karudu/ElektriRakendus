Imports PrjAndmebaas

Public Class FormRedaktorPaketid
    ' Uuenda aknas näidatud pakette
    Private Sub UuendaPaketid()
        Dim Paketid As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
        Dim Andmebaas As New CAndmebaas

        ' Loe paketid sisse
        Paketid = Andmebaas.LoePakettideNimekiri

        ' Tee nimekirjad tühjaks
        ListBors.Items.Clear()
        ListFix.Items.Clear()
        ListUniv.Items.Clear()

        ' Käi kõik paketid läbi, lisa need õigesse nimekirja
        For Each Pakett In Paketid
            Select Case Pakett.Tyyp
                Case IAndmebaas.PaketiTyyp.PAKETT_BORS
                    ' Loe börsipaketi andmed
                    Dim PakettBors As New IAndmebaas.PkBors
                    PakettBors = Andmebaas.LoePakettBors(Pakett.ID)

                    ' Lisa andmed nimekirja objekti
                    Dim Item As New ListViewItem(PakettBors.Nimi)
                    Item.SubItems.Add(Math.Round(PakettBors.Juurdetasu, 2).ToString & " senti/kWh")
                    Item.SubItems.Add("€" & Math.Round(PakettBors.Kuutasu, 2).ToString)
                    Item.SubItems.Add(0) ' Subitem 3 tühi
                    ' ID lugemine: CInt(ListBors.Items(i).SubItems(4).Text)
                    Item.SubItems.Add(Pakett.ID) ' ID on subitem 4

                    ' Lisa pakett nimekirja
                    ListBors.Items.Add(Item)
                Case IAndmebaas.PaketiTyyp.PAKETT_FIX
                    ' Loe fikseeritud paketi andmed
                    Dim PakettFix As New IAndmebaas.PkFix
                    PakettFix = Andmebaas.LoePakettFix(Pakett.ID)

                    ' Lisa andmed nimekirja objekti
                    Dim Item As New ListViewItem(PakettFix.Nimi)
                    Item.SubItems.Add(Math.Round(PakettFix.PTariif, 2).ToString & " senti/kWh")
                    Item.SubItems.Add(Math.Round(PakettFix.OTariif, 2).ToString & " senti/kWh")
                    Item.SubItems.Add("€" & Math.Round(PakettFix.Kuutasu, 2).ToString)
                    Item.SubItems.Add(Pakett.ID) ' ID on subitem 4

                    ' Lisa pakett nimekirja
                    ListFix.Items.Add(Item)
                Case IAndmebaas.PaketiTyyp.PAKETT_UNIV
                    ' Loe universaalpaketi andmed
                    Dim PakettUniv As New IAndmebaas.PkUniv
                    PakettUniv = Andmebaas.LoePakettUniv(Pakett.ID)

                    ' Lisa andmed nimekirja objekti
                    Dim Item As New ListViewItem(PakettUniv.Nimi)
                    Item.SubItems.Add(Math.Round(PakettUniv.Baas, 2).ToString & " senti/kWh")
                    Item.SubItems.Add(Math.Round(PakettUniv.Marginaal, 2).ToString & " senti/kWh")
                    Item.SubItems.Add("€" & Math.Round(PakettUniv.Kuutasu, 2).ToString)
                    Item.SubItems.Add(Pakett.ID) ' ID on subitem 4

                    ' Lisa pakett nimekirja
                    ListUniv.Items.Add(Item)
            End Select
        Next
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UuendaPaketid()
    End Sub
    ' Ava börsipaketi lisamise dialoog
    Private Sub BtnLisaBors_Click(sender As Object, e As EventArgs) Handles BtnLisaBors.Click
        Dim FormLisaBors As New FormLisaPakettBors
        FormLisaBors.ShowDialog()
        UuendaPaketid()
    End Sub
    ' Ava fikseeritud paketi lisamise dialoog
    Private Sub BtnLisaFix_Click(sender As Object, e As EventArgs) Handles BtnLisaFix.Click
        Dim FormLisaFix As New FormLisaPakettFix
        FormLisaFix.ShowDialog()
        UuendaPaketid()
    End Sub
    ' Ava universaalpaketi lisamise dialoog
    Private Sub BtnLisaUniv_Click(sender As Object, e As EventArgs) Handles BtnLisaUniv.Click
        Dim FormLisaUniv As New FormLisaPakettUniv
        FormLisaUniv.ShowDialog()
        UuendaPaketid()
    End Sub
    ' Ava börsipaketi muutmise dialoog
    Private Sub BtnMuudaBors_Click(sender As Object, e As EventArgs) Handles BtnMuudaBors.Click
        ' Lõpeta, kui ühtegi paketti pole
        If ListBors.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        ' Loe valitud paketi andmed
        Dim Andmebaas As New CAndmebaas
        Dim Pakett As New IAndmebaas.PkBors
        Dim ID As Integer
        ID = CInt(ListBors.SelectedItems(0).SubItems(4).Text) ' ID on subitem 4
        Pakett = Andmebaas.LoePakettBors(ID)

        ' Ava dialoog paketi andmetega
        Dim FormMuudaBors As New FormMuudaPakettBors(ID)
        FormMuudaBors.TxtNimi.Text = Pakett.Nimi
        FormMuudaBors.TxtJuurdetasu.Text = Pakett.Juurdetasu.ToString
        FormMuudaBors.TxtKuutasu.Text = Pakett.Kuutasu.ToString
        FormMuudaBors.ShowDialog()
        UuendaPaketid()
    End Sub
    ' Ava fikseeritud paketi muutmise dialoog
    Private Sub BtnMuudaFix_Click(sender As Object, e As EventArgs) Handles BtnMuudaFix.Click
        ' Lõpeta, kui ühtegi paketti pole
        If ListFix.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        ' Loe valitud paketi andmed
        Dim Andmebaas As New CAndmebaas
        Dim Pakett As New IAndmebaas.PkFix
        Dim ID As Integer
        ID = CInt(ListFix.SelectedItems(0).SubItems(4).Text) ' ID on subitem 4
        Pakett = Andmebaas.LoePakettFix(ID)

        ' Ava dialoog paketi andmetega
        Dim FormMuudaFix As New FormMuudaPakettFix(ID)
        FormMuudaFix.TxtNimi.Text = Pakett.Nimi
        FormMuudaFix.TxtPTariif.Text = Pakett.PTariif.ToString
        FormMuudaFix.TxtOTariif.Text = Pakett.OTariif.ToString
        FormMuudaFix.TxtKuutasu.Text = Pakett.Kuutasu.ToString
        FormMuudaFix.ShowDialog()
        UuendaPaketid()
    End Sub
    ' Ava universaalpaketi muutmise dialoog
    Private Sub BtnMuudaUniv_Click(sender As Object, e As EventArgs) Handles BtnMuudaUniv.Click
        ' Lõpeta, kui ühtegi paketti pole
        If ListUniv.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        ' Loe valitud paketi andmed
        Dim Andmebaas As New CAndmebaas
        Dim Pakett As New IAndmebaas.PkUniv
        Dim ID As Integer
        ID = CInt(ListUniv.SelectedItems(0).SubItems(4).Text) ' ID on subitem 4
        Pakett = Andmebaas.LoePakettUniv(ID)

        ' Ava dialoog paketi andmetega
        Dim FormMuudaUniv As New FormMuudaPakettUniv(ID)
        FormMuudaUniv.TxtNimi.Text = Pakett.Nimi
        FormMuudaUniv.TxtBaas.Text = Pakett.Baas.ToString
        FormMuudaUniv.TxtMarginaal.Text = Pakett.Marginaal.ToString
        FormMuudaUniv.TxtKuutasu.Text = Pakett.Kuutasu.ToString
        FormMuudaUniv.ShowDialog()
        UuendaPaketid()
    End Sub
    ' Kustuta börsipakett
    Private Sub BtnKustutaBors_Click(sender As Object, e As EventArgs) Handles BtnKustutaBors.Click
        ' Lõpeta, kui ühtegi paketti pole
        If ListBors.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        ' Küsi, kas kasutaja tahab paketi ära kustutada
        Dim Tulemus As DialogResult = MessageBox.Show("Kustuta valitud pakett?",
                                                      "Kustuta",
                                                      MessageBoxButtons.YesNo)
        If Not Tulemus = DialogResult.Yes Then
            Exit Sub
        End If

        ' Kustuta valitud pakett
        Dim Andmebaas As New CAndmebaas
        Dim ID As Integer
        ID = CInt(ListBors.SelectedItems(0).SubItems(4).Text) ' ID on subitem 4
        Andmebaas.KustutaPakettBors(ID)
        UuendaPaketid()
    End Sub
    ' Kustuta fikseeritud pakett
    Private Sub BtnKustutaFix_Click(sender As Object, e As EventArgs) Handles BtnKustutaFix.Click
        ' Lõpeta, kui ühtegi paketti pole
        If ListFix.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        ' Küsi, kas kasutaja tahab paketi ära kustutada
        Dim Tulemus As DialogResult = MessageBox.Show("Kustuta valitud pakett?",
                                                      "Kustuta",
                                                      MessageBoxButtons.YesNo)
        If Not Tulemus = DialogResult.Yes Then
            Exit Sub
        End If

        ' Kustuta valitud pakett
        Dim Andmebaas As New CAndmebaas
        Dim ID As Integer
        ID = CInt(ListFix.SelectedItems(0).SubItems(4).Text) ' ID on subitem 4
        Andmebaas.KustutaPakettFix(ID)
        UuendaPaketid()
    End Sub
    ' Kustuta universaalpakett
    Private Sub BtnKustutaUniv_Click(sender As Object, e As EventArgs) Handles BtnKustutaUniv.Click
        ' Lõpeta, kui ühtegi paketti pole
        If ListUniv.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        ' Küsi, kas kasutaja tahab paketi ära kustutada
        Dim Tulemus As DialogResult = MessageBox.Show("Kustuta valitud pakett?",
                                                      "Kustuta",
                                                      MessageBoxButtons.YesNo)
        If Not Tulemus = DialogResult.Yes Then
            Exit Sub
        End If

        ' Kustuta valitud pakett
        Dim Andmebaas As New CAndmebaas
        Dim ID As Integer
        ID = CInt(ListUniv.SelectedItems(0).SubItems(4).Text) ' ID on subitem 4
        Andmebaas.KustutaPakettUniv(ID)
        UuendaPaketid()
    End Sub
End Class
