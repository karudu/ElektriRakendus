Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbPeriood.Items.Add("Päev")
        cmbPeriood.Items.Add("Kuu")
        cmbPeriood.Items.Add("Aasta")
    End Sub


    Private Sub cmbPeriood_DropDownClosed(sender As Object, e As EventArgs) Handles cmbPeriood.DropDownClosed
        Dim GInfo
        Graafik1.ClearPoints()
        Select Case cmbPeriood.SelectedIndex
            Case 0
                Dim GetInfo As ElektriRakendus.IGraafikInfo
                GetInfo = New ElektriRakendus.CGraafikInfo
                GInfo = GetInfo.GetPaev(cmbPeriood.SelectedText)
                For Index = 24 To 0 Step -1
                    Dim yint As Integer = CInt(GInfo(Index, 1))
                    Graafik1.setPoint1(GInfo(Index, 0), yint)
                Next
                GInfo = GetInfo.GetPaev(cmbPeriood.SelectedText)
            Case 1
                Dim GetInfo As ElektriRakendus.IGraafikInfo
                GetInfo = New ElektriRakendus.CGraafikInfo
                GInfo = GetInfo.GetKuu(cmbPeriood.SelectedText)
                For Index = 30 To 0 Step -1
                    Graafik1.setPoint1(GInfo(Index, 0), GInfo(Index, 1))
                Next
            Case 2
                Dim GetInfo As ElektriRakendus.IGraafikInfo
                GetInfo = New ElektriRakendus.CGraafikInfo
                GInfo = GetInfo.GetAasta(cmbPeriood.SelectedText)
                For Index = 12 To 0 Step -1
                    Graafik1.setPoint1(GInfo(Index, 0), GInfo(Index, 1))
                Next
        End Select
    End Sub
End Class
