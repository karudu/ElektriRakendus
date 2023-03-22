Public Class FormLisaPakettFix
    Private Sub BtnLisa_Click(sender As Object, e As EventArgs) Handles BtnLisa.Click
        Dim Nimi As String = TxtNimi.Text
        If String.IsNullOrEmpty(Nimi) Then
            MessageBox.Show("Paketil peab olema nimi", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim PTariif As Decimal
        If Not Decimal.TryParse(TxtPTariif.Text, PTariif) Then
            MessageBox.Show("Ebakorrektne päevatariif", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim OTariif As Decimal
        If Not Decimal.TryParse(TxtOTariif.Text, OTariif) Then
            MessageBox.Show("Ebakorrektne öötariif", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Kuutasu As Decimal
        If Not Decimal.TryParse(TxtKuutasu.Text, Kuutasu) Then
            MessageBox.Show("Ebakorrektne kuutasu", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Andmebaas As New PrjAndmebaas.CAndmebaas
        Andmebaas.LisaPakettFix(Nimi, PTariif, OTariif, Kuutasu)

        Me.Close()
    End Sub
End Class