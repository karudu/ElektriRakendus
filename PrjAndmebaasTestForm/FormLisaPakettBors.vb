Public Class FormLisaPakettBors
    Private Sub BtnLisa_Click(sender As Object, e As EventArgs) Handles BtnLisa.Click
        Dim Nimi As String = TxtNimi.Text
        If String.IsNullOrEmpty(Nimi) Then
            MessageBox.Show("Paketil peab olema nimi", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Juurdetasu As Decimal
        If Not Decimal.TryParse(TxtJuurdetasu.Text, Juurdetasu) Then
            MessageBox.Show("Ebakorrektne börsihinna juurdetasu", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Kuutasu As Decimal
        If Not Decimal.TryParse(TxtKuutasu.Text, Kuutasu) Then
            MessageBox.Show("Ebakorrektne kuutasu", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Andmebaas As New PrjAndmebaas.CAndmebaas
        Andmebaas.LisaPakettBors(Nimi, Juurdetasu, Kuutasu)

        Me.Close()
    End Sub

    Private Sub TxtNimi_TextChanged(sender As Object, e As EventArgs) Handles TxtNimi.TextChanged

    End Sub
End Class