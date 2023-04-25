Public Class Graafik

    Public Sub InitGraph()
        HinnaGraafik.ChartAreas("ChartArea1").AxisY.Title = "Hind(s/kWh)"
    End Sub

    Public Sub InitGraph1()
        HinnaGraafik.ChartAreas("ChartArea1").AxisY.Title = "Hind(€/kWh)"
    End Sub
    Public Sub ClearPoints()
        HinnaGraafik.Series("Pakett 1").Points.Clear()
        HinnaGraafik.Series("Pakett 2").Points.Clear()
    End Sub
    Public Sub setPoint1(ByVal Time As String, ByVal hind As Decimal)
        HinnaGraafik.Series("Pakett 1").Points.AddXY(Time, hind)
    End Sub

    Public Sub setPoint2(ByVal Time As String, ByVal hind As Decimal)
        HinnaGraafik.Series("Pakett 2").Points.AddXY(Time, hind)
    End Sub

    Private Sub HinnaGraafik_Click(sender As Object, e As EventArgs) Handles HinnaGraafik.Click

    End Sub
End Class
