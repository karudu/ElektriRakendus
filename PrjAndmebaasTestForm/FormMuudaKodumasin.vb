Imports PrjAndmebaas

Public Class FormMuudaKodumasin
    Private ID As Integer
    Public Sub New(ByVal ID As Integer)
        InitializeComponent()
        Me.ID = ID
    End Sub

    Private Sub BtnMuuda_Click(sender As Object, e As EventArgs) Handles BtnMuuda.Click
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

        Dim Andmebaas As New CAndmebaas
        Andmebaas.MuudaKodumasin(ID, Nimi, Voimsus, Aeg)

        Me.Close()
    End Sub
End Class