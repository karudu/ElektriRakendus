Imports System.DateTime

Public Class CGraafikInfo
    Implements IGraafikInfo
    Public StructBors As New PrjAndmebaas.IAndmebaas.PkBors
    Public StructFix As New PrjAndmebaas.IAndmebaas.PkFix
    Public StructUniv As New PrjAndmebaas.IAndmebaas.PkUniv

    Public Function GetPaev(PakettID As Integer, PaketiTyyp As Integer) As String(,) Implements IGraafikInfo.GetPaev
        Dim AndmedConnect As PrjAndmebaas.IAndmebaas
        AndmedConnect = New PrjAndmebaas.CAndmebaas
        Dim I As Integer
        Dim Info(24, 1) As String
        Dim CurrTime As Date = New DateTime(2023, 3, 20, 14, 0, 0)
        Dim EndTime = CurrTime.AddDays(-1)
        If PaketiTyyp = 0 Then
            Me.StructBors = AndmedConnect.LoePakettBors(PakettID)
            For I = 0 To 24
                Info(I, 0) = CurrTime.ToString("HH")
                Info(I, 1) = ((AndmedConnect.LoeHind(CurrTime)) + (StructBors.Juurdetasu / 100)).ToString
                CurrTime = CurrTime.AddHours(-1)
            Next
        ElseIf PaketiTyyp = 1 Then
            Me.StructFix = AndmedConnect.LoePakettFix(1)
            For I = 0 To 24
                Info(I, 0) = CurrTime.ToString("HH")
                Info(I, 1) = StructFix.PTariif
                CurrTime = CurrTime.AddHours(-1)
            Next
        Else
            Me.StructUniv = AndmedConnect.LoePakettUniv(1)
            For I = 0 To 24
                Info(I, 0) = CurrTime.ToString("HH")
                Info(I, 1) = (StructUniv.Baas + (StructUniv.Marginaal / 100)).ToString
                CurrTime = CurrTime.AddHours(-1)
            Next
        End If
        Return Info
    End Function

    Public Function GetKuu(PakettID As Integer, PaketiTypp As Integer) As String(,) Implements IGraafikInfo.GetKuu
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

    Public Function GetAasta(PakettID As Integer, PaketiTyyp As Integer) As String(,) Implements IGraafikInfo.GetAasta
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
