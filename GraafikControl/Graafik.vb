Public Class Graafik
    ' Algväärtusta graafik
    Public Sub InitGraph()
        HinnaGraafik.ChartAreas("ChartArea1").AxisY.Title = "Hind(s/kWh)"
    End Sub
    ' Kustuta kõik graafikul olevad punktid
    Public Sub ClearPoints()
        HinnaGraafik.Series("Pakett 1").Points.Clear()
        HinnaGraafik.Series("Pakett 2").Points.Clear()
        HinnaGraafik.Series("Pakett 3").Points.Clear()
    End Sub
    ' Lisab graafikule objekti alla ühe punkti
    Public Sub setPoint1(ByVal Time As String, ByVal hind As Decimal, Optional ToolTip As String = Nothing)
        Dim Index = HinnaGraafik.Series("Pakett 1").Points.AddXY(Time, hind)
        If Not String.IsNullOrEmpty(ToolTip) Then HinnaGraafik.Series("Pakett 1").Points(Index).ToolTip = ToolTip
    End Sub
    Public Sub setPoint2(ByVal Time As String, ByVal hind As Decimal, Optional ToolTip As String = Nothing)
        Dim Index = HinnaGraafik.Series("Pakett 2").Points.AddXY(Time, hind)
        If Not String.IsNullOrEmpty(ToolTip) Then HinnaGraafik.Series("Pakett 2").Points(Index).ToolTip = ToolTip
    End Sub
    Public Sub setPoint3(ByVal Time As String, ByVal hind As Decimal, Optional ToolTip As String = Nothing)
        Dim Index = HinnaGraafik.Series("Pakett 3").Points.AddXY(Time, hind)
        If Not String.IsNullOrEmpty(ToolTip) <> 0 Then HinnaGraafik.Series("Pakett 3").Points(Index).ToolTip = ToolTip
    End Sub
    ' Tagastab True, kui graafikul on punkte või False, kui see on tühi
    Public Function HasPoints() As Boolean
        If HinnaGraafik.Series("Pakett 1").Points.Count <> 0 Then Return True
        If HinnaGraafik.Series("Pakett 2").Points.Count <> 0 Then Return True
        If HinnaGraafik.Series("Pakett 3").Points.Count <> 0 Then Return True
        Return False
    End Function
    ' Tagastab, kui mitu objekti graafikul näha on
    Public Function NumItems() As Integer
        Dim Count = 0
        If HinnaGraafik.Series("Pakett 1").Points.Count <> 0 Then Count += 1
        If HinnaGraafik.Series("Pakett 2").Points.Count <> 0 Then Count += 1
        If HinnaGraafik.Series("Pakett 3").Points.Count <> 0 Then Count += 1
        Return Count
    End Function
    ' Tagastab graafiku X telje punktide arvu
    Public Function NumPoints() As Integer
        Return Math.Max(HinnaGraafik.Series("Pakett 1").Points.Count,
                        Math.Max(HinnaGraafik.Series("Pakett 2").Points.Count,
                        HinnaGraafik.Series("Pakett 3").Points.Count))
    End Function
    ' Tagasta, kas graafikul on kindel objekt olemas
    Public Function HasItem(ByVal Item As Integer) As Boolean
        Select Case Item
            Case 0
                Return HinnaGraafik.Series("Pakett 1").Points.Count <> 0
            Case 1
                Return HinnaGraafik.Series("Pakett 2").Points.Count <> 0
            Case 2
                Return HinnaGraafik.Series("Pakett 3").Points.Count <> 0
            Case Else
                Return False
        End Select
    End Function
    ' Tagasta objekti ühe punkti väärtus
    Public Function GetPoint(ByVal Item As Integer, ByVal X As Integer) As Double
        Select Case Item
            Case 0
                Return HinnaGraafik.Series("Pakett 1").Points(X).YValues(0)
            Case 1
                Return HinnaGraafik.Series("Pakett 2").Points(X).YValues(0)
            Case 2
                Return HinnaGraafik.Series("Pakett 3").Points(X).YValues(0)
            Case Else
                Return 0
        End Select
    End Function
    ' Tagasta objekti ühe punkti X väärtus
    Public Function GetPointX(ByVal Item As Integer, ByVal X As Integer) As String
        Select Case Item
            Case 0
                Dim Tekst = HinnaGraafik.Series("Pakett 1").Points(X).AxisLabel
                If Tekst = " " Then Tekst = HinnaGraafik.Series("Pakett 1").Points(X).ToolTip
                Return Tekst
            Case 1
                Dim Tekst = HinnaGraafik.Series("Pakett 2").Points(X).AxisLabel
                If Tekst = " " Then Tekst = HinnaGraafik.Series("Pakett 2").Points(X).ToolTip
                Return Tekst
            Case 2
                Dim Tekst = HinnaGraafik.Series("Pakett 3").Points(X).AxisLabel
                If Tekst = " " Then Tekst = HinnaGraafik.Series("Pakett 3").Points(X).ToolTip
                Return Tekst
            Case Else
                Return Nothing
        End Select
    End Function
End Class
