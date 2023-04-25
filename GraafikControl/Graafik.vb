Public Class Graafik

    Public Sub InitGraph()
        HinnaGraafik.ChartAreas("ChartArea1").AxisY.Title = "Hind(s/kWh)"
    End Sub
    Public Sub ClearPoints()
        HinnaGraafik.Series("Pakett 1").Points.Clear()
        HinnaGraafik.Series("Pakett 2").Points.Clear()
        HinnaGraafik.Series("Pakett 3").Points.Clear()
    End Sub
    Public Sub setPoint1(ByVal Time As String, ByVal hind As Decimal)
        HinnaGraafik.Series("Pakett 1").Points.AddXY(Time, hind)
    End Sub

    Public Sub setPoint2(ByVal Time As String, ByVal hind As Decimal)
        HinnaGraafik.Series("Pakett 2").Points.AddXY(Time, hind)
    End Sub

    Public Sub setPoint3(ByVal Time As String, ByVal hind As Decimal)
        HinnaGraafik.Series("Pakett 3").Points.AddXY(Time, hind)
    End Sub
End Class
