Imports PrjAndmebaas

Public Class Form2
    Public d As Short
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UuendaPaketid()
    End Sub
    Private Sub UuendaPaketid()
        Dim Paketid As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
        Dim Andmebaas As New CAndmebaas
        Paketid = Andmebaas.LoePakettideNimekiri
        ListUniv.Items.Clear()
        Select Case ComboBox2.SelectedIndex
            Case 0
                For Each Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp) In Paketid
                    Select Case Pakett.Tyyp
                        Case IAndmebaas.PaketiTyyp.PAKETT_BORS
                            Dim PakettBors As New IAndmebaas.PkBors
                            PakettBors = Andmebaas.LoePakettBors(Pakett.ID)
                            Dim Item As New ListViewItem(PakettBors.Nimi)
                            ListUniv.Items.Add(Item)
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
                    ListUniv.Items.Add(Item)
                    End Select
        Next
            Case 2
                For Each Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp) In Paketid
                    Select Case Pakett.Tyyp
                        Case IAndmebaas.PaketiTyyp.PAKETT_UNIV
                            Dim PakettUniv As New IAndmebaas.PkUniv
                            PakettUniv = Andmebaas.LoePakettUniv(Pakett.ID)
                            Dim Item As New ListViewItem(PakettUniv.Nimi)
                            ListUniv.Items.Add(Item)
                    End Select
                Next

        End Select
        Dim sadasd As Integer = 0
    End Sub


    Private Sub tootle(ByRef Kalkulaator As Kalkulaator)
        TextBox4.Text = Kalkulaator.Rahalinekulu
    End Sub
    Private Sub Arvuta_Click(sender As Object, e As EventArgs) Handles Arvuta.Click
        If ListUniv.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        If IsNumeric(SeadmeV.Text) = True And IsNumeric(KasutusAeg.Text) = True Then
            Dim KodumasinaKasutus As New KodumasinaKasutus(TextBox1.Text, SeadmeV.Text, KasutusAeg.Text)
            tootle(KodumasinaKasutus)
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        UuendaPaketid()
    End Sub

    Private Sub SeadmeV_TextChanged(sender As Object, e As EventArgs) Handles SeadmeV.TextChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        UuendaPaketid()
    End Sub

    Private Sub KasutusAeg_TextChanged(sender As Object, e As EventArgs) Handles KasutusAeg.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub ListUniv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListUniv.SelectedIndexChanged
        UuendaPaketid()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class