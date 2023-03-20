Public Class Graafik
    Public Sub ClearPoints()
        HinnaGraafik.Series("Pakett 1").Points.Clear()
    End Sub
    Public Sub setPoint1(ByVal Time As String, ByVal hind As Integer)
        HinnaGraafik.Series("Pakett 1").Points.AddXY(Time, hind)
    End Sub

    Public Sub setPoint2(ByVal Time As String, ByVal hind As Integer)
        HinnaGraafik.Series("Pakett 2").Points.AddXY(Time, hind)
    End Sub

    'Public Sub Init_Chart()
    '    HinnaGraafik.ChartArea
    'End Sub
End Class
