Imports System.IO

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using ofd As OpenFileDialog = New OpenFileDialog() With {.Filter = "Text file|*.CSV"}
            If ofd.ShowDialog() = DialogResult.OK Then

                Dim lines As List(Of String) = File.ReadAllLines(ofd.FileName).ToList
                Dim CSV As List(Of Class1) = New List(Of Class1)
                For i As Integer = 1 To lines.Count - 1
                    Dim data As String() = lines(i).Split(",")
                    CSV.Add(New Class1() With {
                    .dateS = data(0),
                    .Voimsus = data(1)
                })
                Next
                DataGridView1.DataSource = CSV
            End If

        End Using
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class


