Imports System.DateTime
Public Class CGraafikInfo
    Implements IGraafikInfo

    Private Function DBQueryTime_Price(ByVal PaketiTyyp As Integer, ByVal PakettID As Integer, ByVal CurrTime As Date) As String
        Dim AndmedConnect As PrjAndmebaas.IAndmebaas
        AndmedConnect = New PrjAndmebaas.CAndmebaas
        If CurrTime.Minute > 0 Then
            CurrTime = CurrTime.AddHours(-1)
            CurrTime = CurrTime.AddMinutes((CurrTime.Minute))
        End If

        If PaketiTyyp = 0 Then
            Dim StructResult As New PrjAndmebaas.IAndmebaas.PkBors
            StructResult = AndmedConnect.LoePakettBors(15)
            Dim Price As Double = AndmedConnect.LoeHind(CurrTime) + (StructResult.Juurdetasu / 100)
            Console.WriteLine(Price)
            Return Price
        ElseIf PaketiTyyp = 1 Then
            Dim StructResult As New PrjAndmebaas.IAndmebaas.PkFix
            StructResult = AndmedConnect.LoePakettFix(1)
            Return StructResult.PTariif
        Else
            Dim StructResult As New PrjAndmebaas.IAndmebaas.PkUniv
            StructResult = AndmedConnect.LoePakettUniv(1)
            Dim Price As Double = AndmedConnect.LoeHind(CurrTime) + (StructResult.Marginaal / 100)
            Return Price
        End If
    End Function

    Public Function GetPaev(PakettID As Integer) As String(,) Implements IGraafikInfo.GetPaev
        Dim Info(24, 1) As String
        Dim CurrTime As Date = New DateTime(2023, 3, 20, 14, 0, 0)
        Dim EndTime = CurrTime.AddDays(-1)
        Dim RandInt As Random = New Random
        Dim TempInfo(1, 1) As String
        Dim I As Integer
        For I = 0 To 24
            Info(I, 0) = CurrTime.ToString("HH")
            Info(I, 1) = DBQueryTime_Price(0, 15, CurrTime).ToString
            CurrTime = CurrTime.AddHours(-1)
        Next
        Return Info
    End Function

    Public Function GetKuu(PakettID As Integer) As String(,) Implements IGraafikInfo.GetKuu
        Dim Info(30, 1) As String
        Dim I As Integer
        Dim CurrTime As Date = DateTime.Now()
        Dim EndTime = CurrTime.AddMonths(-1)
        Dim RandInt As Random = New Random
        For I = 0 To 30
            Info(I, 0) = CurrTime.AddDays(-I).ToString("H")
            Info(I, 1) = RandInt.Next(30, 130).ToString
        Next
        Return Info
    End Function

    Public Function GetAasta(PakettID As Integer) As String(,) Implements IGraafikInfo.GetAasta
        Dim Info(12, 1) As String
        Dim I As Integer
        Dim CurrTime As Date = DateTime.Now()
        Dim EndTime = CurrTime.AddYears(-1)
        Dim RandInt As Random = New Random
        For I = 0 To 12
            Info(I, 0) = CurrTime.AddMonths(-I).ToString("MMM")
            Info(I, 1) = RandInt.Next(30, 130).ToString
        Next
        Return Info
    End Function
End Class
