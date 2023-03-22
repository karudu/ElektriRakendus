Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports PrjAndmebaas

Public Class FormMuudaPakettBors
    Private ID As Integer
    Public Sub New(ByVal ID As Integer)
        InitializeComponent()
        Me.ID = ID
    End Sub

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

        Dim Andmebaas As New CAndmebaas
        Andmebaas.MuudaPakettBors(ID, Nimi, Juurdetasu, Kuutasu)

        Me.Close()
    End Sub
End Class