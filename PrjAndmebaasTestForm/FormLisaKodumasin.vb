Public Class FormLisaKodumasin
    Private Sub BtnLisa_Click(sender As Object, e As EventArgs) Handles BtnLisa.Click
        Dim Nimi As String = TxtNimi.Text
        If String.IsNullOrEmpty(Nimi) Then
            MessageBox.Show("Kodumasinal peab olema nimi", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Voimsus As Double
        If Not Decimal.TryParse(TxtVoimsus.Text, Voimsus) Then
            MessageBox.Show("Ebakorrektne võimsus", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Aeg As Double
        If Not Decimal.TryParse(TxtAeg.Text, Aeg) Then
            MessageBox.Show("Ebakorrektne kasutuse aeg", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Andmebaas As New PrjAndmebaas.CAndmebaas
        Andmebaas.LisaKodumasin(Nimi, Voimsus, Aeg)

        Me.Close()
    End Sub

    Private Sub FormLisaKodumasin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class