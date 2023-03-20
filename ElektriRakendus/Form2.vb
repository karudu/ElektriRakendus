Public Class Form2
    Private Sub tootle(ByRef Kalkulaator As Kalkulaator)
        TextBox4.Text = Kalkulaator.Rahalinekulu
    End Sub
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub SeadmeV_TextChanged(sender As Object, e As EventArgs) Handles SeadmeV.TextChanged

    End Sub

    Private Sub KasutusAeg_TextChanged(sender As Object, e As EventArgs) Handles KasutusAeg.TextChanged

    End Sub

    Private Sub Arvuta_Click(sender As Object, e As EventArgs) Handles Arvuta.Click
        If IsNumeric(SeadmeV.Text) = True And IsNumeric(KasutusAeg.Text) = True Then
            Dim KodumasinaKasutus As New KodumasinaKasutus(TextBox1.Text, SeadmeV.Text, KasutusAeg.Text)
            tootle(KodumasinaKasutus)
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class