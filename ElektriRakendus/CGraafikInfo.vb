Imports System.DateTime
Public Class CGraafikInfo
    Implements IGraafikInfo

    Public Function GetPaev(pakett As String) As String(,) Implements IGraafikInfo.GetPaev
        Dim Info(24, 1) As String
        Dim CurrTime As Date = DateTime.Now()
        Dim EndTime = CurrTime.AddDays(-1)
        Dim RandInt As Random = New Random
        For Index = 0 To 24
            Info(Index, 0) = CurrTime.AddHours(-Index).ToShortTimeString
            Info(Index, 1) = RandInt.Next(30, 130).ToString
        Next
        Return Info
    End Function

    Public Function GetKuu(pakett As String) As String(,) Implements IGraafikInfo.GetKuu
        Dim Info(30, 1) As String
        Dim CurrTime As Date = DateTime.Now()
        Dim EndTime = CurrTime.AddMonths(-1)
        Return Info
    End Function

    Public Function GetAasta(pakett As String) As String(,) Implements IGraafikInfo.GetAasta
        Dim Info(12, 1) As String
        Dim CurrTime As Date = DateTime.Now()
        Dim EndTime = CurrTime.AddYears(-1)
        Return Info
    End Function
End Class
