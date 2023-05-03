Public Class FormMuudaPakettFix
    Private ID As Integer
    Public Sub New(ByVal ID As Integer)
        InitializeComponent()
        Me.ID = ID
    End Sub
    ' Fikseeritud paketi muutmise dialoog
    Private Sub BtnLisa_Click(sender As Object, e As EventArgs) Handles BtnLisa.Click
        ' Kontrolli, kas nimi on antud
        Dim Nimi As String = TxtNimi.Text
        If String.IsNullOrEmpty(Nimi) Then
            MessageBox.Show("Paketil peab olema nimi", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Kontrolli, kas päevatariif on antud ja see on korrektne
        Dim PTariif As Decimal
        If Not Decimal.TryParse(TxtPTariif.Text, PTariif) Or PTariif < 0 Then
            MessageBox.Show("Ebakorrektne päevatariif", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Kontrolli, kas öötariif on antud ja see on korrektne
        Dim OTariif As Decimal
        If Not Decimal.TryParse(TxtOTariif.Text, OTariif) Or OTariif < 0 Then
            MessageBox.Show("Ebakorrektne öötariif", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Kontrolli, kas kuutasu on antud ja see on korrektne
        Dim Kuutasu As Decimal
        If Not Decimal.TryParse(TxtKuutasu.Text, Kuutasu) Or Kuutasu < 0 Then
            MessageBox.Show("Ebakorrektne kuutasu", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Muuda fikseeritud paketi andmed
        Dim Andmebaas As New PrjAndmebaas.CAndmebaas
        Andmebaas.MuudaPakettFix(ID, Nimi, PTariif, OTariif, Kuutasu)

        Me.Close()
    End Sub
End Class