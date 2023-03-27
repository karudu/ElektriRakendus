Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbPeriood.Items.Add("Päev")
        cmbPeriood.Items.Add("Kuu")
        cmbPeriood.Items.Add("Aasta")
    End Sub


    Private Sub cmbPeriood_DropDownClosed(sender As Object, e As EventArgs) Handles cmbPeriood.DropDownClosed
        Dim GInfo As List(Of (Xval As String, Yval As Double))
        Graafik1.ClearPoints()
        Dim I As Integer
        Select Case cmbPeriood.SelectedIndex
            Case 0
                Dim GetInfo As ElektriRakendus.IGraafikInfo
                GetInfo = New ElektriRakendus.CGraafikInfo
                GInfo = GetInfo.GetPaev(15, 0)
                For I = 0 To GInfo.Count
                    Graafik1.setPoint1(GInfo.Item(I).Xval, GInfo.Item(I).Yval)
                Next
                'Case 1
                '    Dim GetInfo As ElektriRakendus.IGraafikInfo
                '    GetInfo = New ElektriRakendus.CGraafikInfo
                '    GInfo = GetInfo.GetKuu(0, 0)
                '    For I = 30 To 0 Step -1
                '        Graafik1.setPoint1(GInfo(I, 0), GInfo(I, 1))
                '    Next
                'Case 2
                '    Dim GetInfo As ElektriRakendus.IGraafikInfo
                '    GetInfo = New ElektriRakendus.CGraafikInfo
                '    GInfo = GetInfo.GetAasta(0, 0)
                '    For I = 12 To 0 Step -1
                '        Graafik1.setPoint1(GInfo(I, 0), GInfo(I, 1))
                '    Next
        End Select
    End Sub
End Class
