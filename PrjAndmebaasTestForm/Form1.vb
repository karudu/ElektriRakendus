Imports PrjAndmebaas

Public Class Form1
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

        Dim sadasd As Integer = 0
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UuendaPaketid()
    End Sub
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
End Class
