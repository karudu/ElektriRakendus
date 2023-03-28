Imports System.DateTime

Public Class CGraafikInfo
    Implements IGraafikInfo

    Public StructBors As New PrjAndmebaas.IAndmebaas.PkBors
    Public StructFix As New PrjAndmebaas.IAndmebaas.PkFix
    Public StructUniv As New PrjAndmebaas.IAndmebaas.PkUniv

    Private Function GetPaev(PakettID As Integer, PaketiTyyp As Integer) As List(Of (Aeg As String, Hind As Decimal)) Implements IGraafikInfo.GetPaev
        Dim InfoList As New List(Of (Aeg As String, Hind As Decimal))
        Dim Hinnad As New List(Of Decimal)
        Dim AndmedConnect As PrjAndmebaas.IAndmebaas
        AndmedConnect = New PrjAndmebaas.CAndmebaas
        Dim I As Integer
        Dim CurrTime As Date = Date.Now()
        Dim EndTime As Date = CurrTime.AddDays(-1)
        Dim TS As New TimeSpan
        TS = CurrTime.Subtract(EndTime)
        Dim Tunnid As Integer = TS.TotalHours
        If PaketiTyyp = 0 Then
            Me.StructBors = AndmedConnect.LoePakettBors(PakettID)
            Hinnad = AndmedConnect.LoeBorsihinnad(CurrTime, Tunnid)
            For I = 0 To Hinnad.Count - 1
                Dim Info As (Aeg As String, Hind As Decimal)
                Info.Aeg = CurrTime.ToString("HH")
                Info.Hind = Hinnad.Item(I) + (StructBors.Juurdetasu / 100)
                InfoList.Add(Info)
                CurrTime = CurrTime.AddHours(-1)
            Next
            'ElseIf PaketiTyyp = 1 Then
            '    Me.StructFix = AndmedConnect.LoePakettFix(1)
            '    For I = 0 To 24
            '        Info(I, 0) = CurrTime.ToString("HH")
            '        Info(I, 1) = StructFix.PTariif
            '        CurrTime = CurrTime.AddHours(-1)
            '    Next
            'Else
            '    Me.StructUniv = AndmedConnect.LoePakettUniv(1)
            '    For I = 0 To 24
            '        Info(I, 0) = CurrTime.ToString("HH")
            '        Info(I, 1) = (StructUniv.Baas + (StructUniv.Marginaal / 100)).ToString
            '        CurrTime = CurrTime.AddHours(-1)
            '    Next
        End If
        Return InfoList
    End Function
    Public Function GetKuu(PakettID As Integer, PaketiTyyp As Integer) As List(Of (Aeg As String, Hind As Decimal)) Implements IGraafikInfo.GetKuu
        Dim InfoList As New List(Of (Aeg As String, Hind As Decimal))
        Dim Hinnad As New List(Of Decimal)
        Dim AndmedConnect As PrjAndmebaas.IAndmebaas
        AndmedConnect = New PrjAndmebaas.CAndmebaas
        Dim I As Integer = 0
        Dim J As Integer = 0
        Dim CurrTime As Date = Date.Now().AddHours(-2)
        Dim EndTime As Date = CurrTime.AddMonths(-1)
        Dim TS As New TimeSpan
        TS = CurrTime.Subtract(EndTime)
        Dim Tunnid As Integer = TS.TotalHours
        If PaketiTyyp = 0 Then
            Me.StructBors = AndmedConnect.LoePakettBors(PakettID)
            Hinnad = AndmedConnect.LoeBorsihinnad(CurrTime, Tunnid)
            While I < Hinnad.Count - 1
                Dim Info As (Aeg As String, Hind As Decimal)
                Dim TodayHours As Integer = CurrTime.Hour
                While CurrTime.Hour > CurrTime.AddHours(-CurrTime.Hour).Hour And I < Hinnad.Count
                    Info.Hind += Hinnad.Item(I) + (StructBors.Juurdetasu / 100)
                    I += 1
                    CurrTime = CurrTime.AddHours(-1)
                End While
                Info.Hind = Info.Hind / TodayHours
                Info.Aeg = CurrTime.ToString("d")
                InfoList.Add(Info)
                CurrTime = CurrTime.AddHours(-1)
            End While
        End If
        Return InfoList
    End Function

    Public Function GetAasta(PakettID As Integer, PaketiTyyp As Integer) As List(Of (Aeg As String, Hind As Decimal)) Implements IGraafikInfo.GetAasta

    End Function
End Class
