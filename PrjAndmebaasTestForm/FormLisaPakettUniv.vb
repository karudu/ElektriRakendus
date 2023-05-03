Public Class FormLisaPakettUniv
    ' Uue universaalpaketi lisamise dialoog
    Private Sub BtnLisa_Click(sender As Object, e As EventArgs) Handles BtnLisa.Click
        ' Kontrolli, kas nimi on antud
        Dim Nimi As String = TxtNimi.Text
        If String.IsNullOrEmpty(Nimi) Then
            MessageBox.Show("Paketil peab olema nimi", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Kontrolli, kas baashind on antud ja see on korrektne
        Dim Baas As Decimal
        If Not Decimal.TryParse(TxtBaas.Text, Baas) Or Baas < 0 Then
            MessageBox.Show("Ebakorrektne baashind", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Kontrolli, kas marginaal on antud ja see on korrektne
        Dim Marginaal As Decimal
        If Not Decimal.TryParse(TxtMarginaal.Text, Marginaal) Or Marginaal < 0 Then
            MessageBox.Show("Ebakorrektne pakkuja marginaal", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Kontrolli, kas kuutasu on antud ja see on korrektne
        Dim Kuutasu As Decimal
        If Not Decimal.TryParse(TxtKuutasu.Text, Kuutasu) Or Kuutasu < 0 Then
            MessageBox.Show("Ebakorrektne kuutasu", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Lisa uus universaalpakett
        Dim Andmebaas As New PrjAndmebaas.CAndmebaas
        Andmebaas.LisaPakettUniv(Nimi, Baas, Marginaal, Kuutasu)

        Me.Close()
    End Sub
End Class