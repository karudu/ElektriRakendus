Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports PrjAndmebaas

Public Class FormMuudaPakettBors
    Private ID As Integer
    Public Sub New(ByVal ID As Integer)
        InitializeComponent()
        Me.ID = ID
    End Sub
    ' Börsipaketi muutmise dialoog
    Private Sub BtnLisa_Click(sender As Object, e As EventArgs) Handles BtnLisa.Click
        ' Kontrolli, kas nimi on antud
        Dim Nimi As String = TxtNimi.Text
        If String.IsNullOrEmpty(Nimi) Then
            MessageBox.Show("Paketil peab olema nimi", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Kontrolli, kas juurdetasu on antud ja see on korrektne
        Dim Juurdetasu As Decimal
        If Not Decimal.TryParse(TxtJuurdetasu.Text, Juurdetasu) Or Juurdetasu < 0 Then
            MessageBox.Show("Ebakorrektne börsihinna juurdetasu", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Kontrolli, kas kuutasu on antud ja see on korrektne
        Dim Kuutasu As Decimal
        If Not Decimal.TryParse(TxtKuutasu.Text, Kuutasu) Or Kuutasu < 0 Then
            MessageBox.Show("Ebakorrektne kuutasu", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Muuda börsipaketi andmed
        Dim Andmebaas As New CAndmebaas
        Andmebaas.MuudaPakettBors(ID, Nimi, Juurdetasu, Kuutasu)

        Me.Close()
    End Sub
End Class