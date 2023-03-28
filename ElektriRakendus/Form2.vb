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
        ComboBox1.Items.Clear()

        For Each Pakett In Paketid
            Select Case Pakett.Tyyp
                Case IAndmebaas.PaketiTyyp.PAKETT_BORS
                    Dim PakettBors As New IAndmebaas.PkBors
                    PakettBors = Andmebaas.LoePakettBors(Pakett.ID)
                    Dim Item As New ListViewItem(PakettBors.Nimi)
                    ' ID on subitem 4
                    ' CInt(ListBors.Items(i).SubItems(4).Text)
                Case IAndmebaas.PaketiTyyp.PAKETT_FIX
                    Dim PakettFix As New IAndmebaas.PkFix
                    PakettFix = Andmebaas.LoePakettFix(Pakett.ID)
                    Dim Item As New ListViewItem(PakettFix.Nimi)

                Case IAndmebaas.PaketiTyyp.PAKETT_UNIV
                    Dim PakettUniv As New IAndmebaas.PkUniv
                    PakettUniv = Andmebaas.LoePakettUniv(Pakett.ID)
                    Dim Item As New ListViewItem(PakettUniv.Nimi)

            End Select
        Next

        Dim sadasd As Integer = 0
    End Sub


    Private Sub tootle(ByRef Kalkulaator As Kalkulaator)
        TextBox4.Text = Kalkulaator.Rahalinekulu
    End Sub
    Private Sub Arvuta_Click(sender As Object, e As EventArgs) Handles Arvuta.Click
        If IsNumeric(SeadmeV.Text) = True And IsNumeric(KasutusAeg.Text) = True Then
            Dim KodumasinaKasutus As New KodumasinaKasutus(TextBox1.Text, SeadmeV.Text, KasutusAeg.Text)
            tootle(KodumasinaKasutus)
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub SeadmeV_TextChanged(sender As Object, e As EventArgs) Handles SeadmeV.TextChanged

    End Sub
End Class