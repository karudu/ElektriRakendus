Public Class FormLisaKodumasin
    ' Uue kodumasina lisamise dialoog
    Private Sub BtnLisa_Click(sender As Object, e As EventArgs) Handles BtnLisa.Click
        ' Kontrolli, kas nimi on antud
        Dim Nimi As String = TxtNimi.Text
        If String.IsNullOrEmpty(Nimi) Then
            MessageBox.Show("Kodumasinal peab olema nimi", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Kontrolli, kas võimsus on antud ja see on korrektne
        Dim Voimsus As Double
        If Not Decimal.TryParse(TxtVoimsus.Text, Voimsus) Or Voimsus < 0 Then
            MessageBox.Show("Ebakorrektne võimsus", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Kontrolli, kas aeg on antud ja see on korrektne
        Dim Aeg As Double
        If Not Decimal.TryParse(TxtAeg.Text, Aeg) Or Aeg < 0 Then
            MessageBox.Show("Ebakorrektne kasutuse aeg", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Lisa uus kodumasin
        Dim Andmebaas As New PrjAndmebaas.CAndmebaas
        Andmebaas.LisaKodumasin(Nimi, Voimsus, Aeg)

        Me.Close()
    End Sub
End Class