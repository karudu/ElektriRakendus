Imports PrjAndmebaas

Public Class Form1
    Private Sub UuendaPaketid()
        Dim Paketid As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
        Dim Andmebaas As New CAndmebaas
        Paketid = Andmebaas.LoePakettideNimekiri

        ListBors.Items.Clear()

        For Each Pakett In Paketid
            Select Case Pakett.Tyyp
                Case IAndmebaas.PaketiTyyp.PAKETT_BORS
                    Dim PakettBors As New IAndmebaas.PkBors
                    PakettBors = Andmebaas.LoePakettBors(Pakett.ID)
                    Dim Item As New ListViewItem(PakettBors.Nimi)
                    Item.SubItems.Add(PakettBors.Juurdetasu.ToString)
                    Item.SubItems.Add(PakettBors.Kuutasu.ToString)
                    ' ID on subitem 3
                    ' CInt(ListBors.Items(i).SubItems(3).Text)
                    Item.SubItems.Add(Pakett.ID)
                    ListBors.Items.Add(Item)
            End Select
        Next

        Dim sadasd As Integer = 0
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UuendaPaketid()
    End Sub
    Private Sub BtnLisaBors_Click(sender As Object, e As EventArgs) Handles BtnLisaBors.Click
        Dim FormLisaBors As New FormLisaPakettBors
        FormLisaBors.Show()
    End Sub

    Private Sub BtnLisaFix_Click(sender As Object, e As EventArgs) Handles BtnLisaFix.Click
        Dim FormLisaFix As New FormLisaPakettFix
        FormLisaFix.Show()
    End Sub

    Private Sub BtnLisaUniv_Click(sender As Object, e As EventArgs) Handles BtnLisaUniv.Click
        Dim FormLisaUniv As New FormLisaPakettUniv
        FormLisaUniv.Show()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        UuendaPaketid()
    End Sub
End Class
