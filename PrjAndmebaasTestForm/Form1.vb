Imports PrjAndmebaas

Public Class Form1
    Private Sub UuendaPaketid()
        Dim Paketid As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
        Dim Andmebaas As New CAndmebaas
        Paketid = Andmebaas.LoePakettideNimekiri
        Dim sadasd As Integer = 0
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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UuendaPaketid()
    End Sub
End Class
