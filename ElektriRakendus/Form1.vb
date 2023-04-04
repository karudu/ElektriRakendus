Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbPeriood.Items.Add("Päev")
        cmbPeriood.Items.Add("Kuu")
        cmbPeriood.Items.Add("Aasta")
    End Sub
    Private Sub cmbPeriood_DropDownClosed(sender As Object, e As EventArgs) Handles cmbPeriood.DropDownClosed
        Dim GInfo As List(Of (Xval As String, Yval As Decimal))
        Dim GraafikConnect As GraafikControl.IGraafikInfo
        GraafikConnect = New GraafikControl.CGraafikInfo
        Graafik1.ClearPoints()
        Dim I As Integer
        Select Case cmbPeriood.SelectedIndex
            Case 0
                GInfo = GraafikConnect.GetPaev(15, 0)
                For I = 0 To GInfo.Count - 1
                    Graafik1.setPoint1(GInfo.Item(I).Xval, GInfo.Item(I).Yval)
                Next
            Case 1
                GInfo = GraafikConnect.GetKuu(15, 0)
                For I = 0 To GInfo.Count - 1
                    Graafik1.setPoint1(GInfo.Item(I).Xval, GInfo.Item(I).Yval)
                Next
            Case 2
                GInfo = GraafikConnect.GetAasta(15, 0)
                For I = 0 To GInfo.Count - 1
                    Graafik1.setPoint1(GInfo.Item(I).Xval, GInfo.Item(I).Yval)
                Next
        End Select
    End Sub
End Class
