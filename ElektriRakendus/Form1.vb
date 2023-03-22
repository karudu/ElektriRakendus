Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbPeriood.Items.Add("Päev")
        cmbPeriood.Items.Add("Kuu")
        cmbPeriood.Items.Add("Aasta")
    End Sub


    Private Sub cmbPeriood_DropDownClosed(sender As Object, e As EventArgs) Handles cmbPeriood.DropDownClosed
        Dim GInfo
        Graafik1.ClearPoints()
        Dim I As Integer
        Select Case cmbPeriood.SelectedIndex
            Case 0
                Dim GetInfo As ElektriRakendus.IGraafikInfo
                GetInfo = New ElektriRakendus.CGraafikInfo
                GInfo = GetInfo.GetPaev(0)
                For I = 24 To 0 Step -1
                    Dim yint As Integer = CInt(GInfo(I, 1))
                    Graafik1.setPoint1(GInfo(I, 0), yint)
                Next
            Case 1
                Dim GetInfo As ElektriRakendus.IGraafikInfo
                GetInfo = New ElektriRakendus.CGraafikInfo
                GInfo = GetInfo.GetKuu(cmbPeriood.SelectedText)
                For I = 30 To 0 Step -1
                    Graafik1.setPoint1(GInfo(I, 0), GInfo(I, 1))
                Next
            Case 2
                Dim GetInfo As ElektriRakendus.IGraafikInfo
                GetInfo = New ElektriRakendus.CGraafikInfo
                GInfo = GetInfo.GetAasta(cmbPeriood.SelectedText)
                For I = 12 To 0 Step -1
                    Graafik1.setPoint1(GInfo(I, 0), GInfo(I, 1))
                Next
        End Select
    End Sub
End Class
