Public Class Form3
    Public d As Double
    Private Sub tootle(ByRef Kalkulaator As Kalkulaator)



        TextBox4.Text = Kalkulaator.Rahalinekulu

    End Sub
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox1.Text = Nothing Or ComboBox3.SelectedIndex = 0 Then
            d = 0
        End If
        If ComboBox3.SelectedIndex = 1 Then
            d = 1
        End If
        If ComboBox3.SelectedIndex = 2 Then
            d = 24
        End If
        If ComboBox3.SelectedIndex = 3 Then
            d = 168
        End If
        If ComboBox3.SelectedIndex = 4 Then
            d = 756
        End If
    End Sub

    Private Sub Arvuta_Click(sender As Object, e As EventArgs) Handles Arvuta.Click
        If IsNumeric(SeadmeV.Text) = True And IsNumeric(TextBox1.Text) = True Then
            Dim KodumasinaKasutus As New KodumasinaKasutus(TextBox1.Text, SeadmeV.Text, d)
            tootle(KodumasinaKasutus)
        End If
    End Sub

    Private Sub SeadmeV_TextChanged(sender As Object, e As EventArgs) Handles SeadmeV.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class