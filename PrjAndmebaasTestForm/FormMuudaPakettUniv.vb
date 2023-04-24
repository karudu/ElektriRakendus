Public Class FormMuudaPakettUniv
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

        Dim Baas As Decimal
        If Not Decimal.TryParse(TxtBaas.Text, Baas) Then
            MessageBox.Show("Ebakorrektne baashind", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Marginaal As Decimal
        If Not Decimal.TryParse(TxtMarginaal.Text, Marginaal) Then
            MessageBox.Show("Ebakorrektne pakkuja marginaal", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Kuutasu As Decimal
        If Not Decimal.TryParse(TxtKuutasu.Text, Kuutasu) Then
            MessageBox.Show("Ebakorrektne kuutasu", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Andmebaas As New PrjAndmebaas.CAndmebaas
        Andmebaas.MuudaPakettUniv(ID, Nimi, Baas, Marginaal, Kuutasu)

        Me.Close()
    End Sub

    Private Sub FormMuudaPakettUniv_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class