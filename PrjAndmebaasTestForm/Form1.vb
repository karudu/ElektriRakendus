﻿Public Class Form1
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
End Class
