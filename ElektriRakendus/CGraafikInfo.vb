Imports System.DateTime
Public Class CGraafikInfo
    Implements IGraafikInfo

    Private Function DBQueryPrice() As String
        Dim result As String


        Return result
    End Function

    Private Function DBQueryTime() As String
        Dim result As String

        Return result
    End Function
    Public Function GetPaev(pakett As String) As String(,) Implements IGraafikInfo.GetPaev
        Dim Info(24, 1) As String
        Dim CurrTime As Date = New DateTime(2023, 3, 20, 14, 0, 0)
        Dim EndTime = CurrTime.AddDays(-1)
        Dim RandInt As Random = New Random
        For Index = 0 To 24

        Next
        Return Info
    End Function

    Public Function GetKuu(pakett As String) As String(,) Implements IGraafikInfo.GetKuu
        Dim Info(30, 1) As String
        Dim CurrTime As Date = DateTime.Now()
        Dim EndTime = CurrTime.AddMonths(-1)
        Dim RandInt As Random = New Random
        For Index = 0 To 30
            Info(Index, 0) = CurrTime.AddDays(-Index).ToString("M")
            Info(Index, 1) = RandInt.Next(30, 130).ToString
        Next
        Return Info
    End Function

    Public Function GetAasta(pakett As String) As String(,) Implements IGraafikInfo.GetAasta
        Dim Info(12, 1) As String
        Dim CurrTime As Date = DateTime.Now()
        Dim EndTime = CurrTime.AddYears(-1)
        Dim RandInt As Random = New Random
        For Index = 0 To 12
            Info(Index, 0) = CurrTime.AddMonths(-Index).ToString("MMM")
            Info(Index, 1) = RandInt.Next(30, 130).ToString
        Next
        Return Info
    End Function
End Class
