Imports PrjAndmebaas

Public Class FormRedaktorPaketid
    Private Sub UuendaPaketid()
        Dim Paketid As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
        Dim Andmebaas As New CAndmebaas
        Paketid = Andmebaas.LoePakettideNimekiri

        ListBors.Items.Clear()
        ListFix.Items.Clear()
        ListUniv.Items.Clear()

        For Each Pakett In Paketid
            Select Case Pakett.Tyyp
                Case IAndmebaas.PaketiTyyp.PAKETT_BORS
                    Dim PakettBors As New IAndmebaas.PkBors
                    PakettBors = Andmebaas.LoePakettBors(Pakett.ID)
                    Dim Item As New ListViewItem(PakettBors.Nimi)
                    Item.SubItems.Add(Math.Round(PakettBors.Juurdetasu, 2).ToString & " senti/kWh")
                    Item.SubItems.Add("€" & Math.Round(PakettBors.Kuutasu, 2).ToString)
                    ' ID on subitem 4
                    ' CInt(ListBors.Items(i).SubItems(4).Text)
                    Item.SubItems.Add(0)
                    Item.SubItems.Add(Pakett.ID)
                    ListBors.Items.Add(Item)
                Case IAndmebaas.PaketiTyyp.PAKETT_FIX
                    Dim PakettFix As New IAndmebaas.PkFix
                    PakettFix = Andmebaas.LoePakettFix(Pakett.ID)
                    Dim Item As New ListViewItem(PakettFix.Nimi)
                    Item.SubItems.Add(Math.Round(PakettFix.PTariif, 2).ToString & " senti/kWh")
                    Item.SubItems.Add(Math.Round(PakettFix.OTariif, 2).ToString & " senti/kWh")
                    Item.SubItems.Add("€" & Math.Round(PakettFix.Kuutasu, 2).ToString)
                    Item.SubItems.Add(Pakett.ID)
                    ListFix.Items.Add(Item)
                Case IAndmebaas.PaketiTyyp.PAKETT_UNIV
                    Dim PakettUniv As New IAndmebaas.PkUniv
                    PakettUniv = Andmebaas.LoePakettUniv(Pakett.ID)
                    Dim Item As New ListViewItem(PakettUniv.Nimi)
                    Item.SubItems.Add(Math.Round(PakettUniv.Baas, 2).ToString & " senti/kWh")
                    Item.SubItems.Add(Math.Round(PakettUniv.Marginaal, 2).ToString & " senti/kWh")
                    Item.SubItems.Add("€" & Math.Round(PakettUniv.Kuutasu, 2).ToString)
                    Item.SubItems.Add(Pakett.ID)
                    ListUniv.Items.Add(Item)
            End Select
        Next
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UuendaPaketid()
    End Sub
    ' TODO Parem valideerimine sisestatud andmete jaoks
    Private Sub BtnLisaBors_Click(sender As Object, e As EventArgs) Handles BtnLisaBors.Click
        Dim FormLisaBors As New FormLisaPakettBors
        FormLisaBors.ShowDialog()
        UuendaPaketid()
    End Sub

    Private Sub BtnLisaFix_Click(sender As Object, e As EventArgs) Handles BtnLisaFix.Click
        Dim FormLisaFix As New FormLisaPakettFix
        FormLisaFix.ShowDialog()
        UuendaPaketid()
    End Sub

    Private Sub BtnLisaUniv_Click(sender As Object, e As EventArgs) Handles BtnLisaUniv.Click
        Dim FormLisaUniv As New FormLisaPakettUniv
        FormLisaUniv.ShowDialog()
        UuendaPaketid()
    End Sub

    Private Sub BtnMuudaBors_Click(sender As Object, e As EventArgs) Handles BtnMuudaBors.Click
        If ListBors.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        Dim Andmebaas As New CAndmebaas
        Dim Pakett As New IAndmebaas.PkBors
        Dim ID As Integer
        ID = CInt(ListBors.SelectedItems(0).SubItems(4).Text) ' ID on subitem 4
        Pakett = Andmebaas.LoePakettBors(ID)

        Dim FormMuudaBors As New FormMuudaPakettBors(ID)
        FormMuudaBors.TxtNimi.Text = Pakett.Nimi
        FormMuudaBors.TxtJuurdetasu.Text = Pakett.Juurdetasu.ToString
        FormMuudaBors.TxtKuutasu.Text = Pakett.Kuutasu.ToString
        FormMuudaBors.ShowDialog()
        UuendaPaketid()
    End Sub

    Private Sub BtnMuudaFix_Click(sender As Object, e As EventArgs) Handles BtnMuudaFix.Click
        If ListFix.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        Dim Andmebaas As New CAndmebaas
        Dim Pakett As New IAndmebaas.PkFix
        Dim ID As Integer
        ID = CInt(ListFix.SelectedItems(0).SubItems(4).Text) ' ID on subitem 4
        Pakett = Andmebaas.LoePakettFix(ID)

        Dim FormMuudaFix As New FormMuudaPakettFix(ID)
        FormMuudaFix.TxtNimi.Text = Pakett.Nimi
        FormMuudaFix.TxtPTariif.Text = Pakett.PTariif.ToString
        FormMuudaFix.TxtOTariif.Text = Pakett.OTariif.ToString
        FormMuudaFix.TxtKuutasu.Text = Pakett.Kuutasu.ToString
        FormMuudaFix.ShowDialog()
        UuendaPaketid()
    End Sub

    Private Sub BtnMuudaUniv_Click(sender As Object, e As EventArgs) Handles BtnMuudaUniv.Click
        If ListUniv.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        Dim Andmebaas As New CAndmebaas
        Dim Pakett As New IAndmebaas.PkUniv
        Dim ID As Integer
        ID = CInt(ListUniv.SelectedItems(0).SubItems(4).Text) ' ID on subitem 4
        Pakett = Andmebaas.LoePakettUniv(ID)

        Dim FormMuudaUniv As New FormMuudaPakettUniv(ID)
        FormMuudaUniv.TxtNimi.Text = Pakett.Nimi
        FormMuudaUniv.TxtBaas.Text = Pakett.Baas.ToString
        FormMuudaUniv.TxtMarginaal.Text = Pakett.Marginaal.ToString
        FormMuudaUniv.TxtKuutasu.Text = Pakett.Kuutasu.ToString
        FormMuudaUniv.ShowDialog()
        UuendaPaketid()
    End Sub

    Private Sub BtnKustutaBors_Click(sender As Object, e As EventArgs) Handles BtnKustutaBors.Click
        If ListBors.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        ' MessageBox'i nuppude teksti muuta ei saa
        Dim Tulemus As DialogResult = MessageBox.Show("Kustuta valitud pakett?",
                                                      "Kustuta",
                                                      MessageBoxButtons.YesNo)
        If Not Tulemus = DialogResult.Yes Then
            Exit Sub
        End If

        Dim Andmebaas As New CAndmebaas
        Dim ID As Integer
        ID = CInt(ListBors.SelectedItems(0).SubItems(4).Text) ' ID on subitem 4
        Andmebaas.KustutaPakettBors(ID)
        UuendaPaketid()
    End Sub

    Private Sub BtnKustutaFix_Click(sender As Object, e As EventArgs) Handles BtnKustutaFix.Click
        If ListFix.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        ' MessageBox'i nuppude teksti muuta ei saa
        Dim Tulemus As DialogResult = MessageBox.Show("Kustuta valitud pakett?",
                                                      "Kustuta",
                                                      MessageBoxButtons.YesNo)
        If Not Tulemus = DialogResult.Yes Then
            Exit Sub
        End If

        Dim Andmebaas As New CAndmebaas
        Dim ID As Integer
        ID = CInt(ListFix.SelectedItems(0).SubItems(4).Text) ' ID on subitem 4
        Andmebaas.KustutaPakettFix(ID)
        UuendaPaketid()
    End Sub

    Private Sub BtnKustutaUniv_Click(sender As Object, e As EventArgs) Handles BtnKustutaUniv.Click
        If ListUniv.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        ' MessageBox'i nuppude teksti muuta ei saa
        Dim Tulemus As DialogResult = MessageBox.Show("Kustuta valitud pakett?",
                                                      "Kustuta",
                                                      MessageBoxButtons.YesNo)
        If Not Tulemus = DialogResult.Yes Then
            Exit Sub
        End If

        Dim Andmebaas As New CAndmebaas
        Dim ID As Integer
        ID = CInt(ListUniv.SelectedItems(0).SubItems(4).Text) ' ID on subitem 4
        Andmebaas.KustutaPakettUniv(ID)
        UuendaPaketid()
    End Sub
End Class
