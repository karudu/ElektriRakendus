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
        Dim EndTime As DateTime = New DateTime(CurrTime.Year, CurrTime.Month, CurrTime.Day + 1, 0, 0, 0)
        Dim BeginTime As Date = EndTime.AddDays(-1)
        Dim TS As New TimeSpan
        TS = EndTime.Subtract(BeginTime)
        Dim Tunnid As Integer = TS.TotalHours
        'paketitüübi valik(0=börs, 1=fix, 2=universaal)
        If PaketiTyyp = 0 Then
            Me.StructBors = AndmedConnect.LoePakettBors(PakettID)
            Hinnad = AndmedConnect.LoeBorsihinnad(BeginTime, Tunnid)
            For I = 0 To 23
                Dim Info As (Aeg As String, Hind As Decimal)
                Info.Aeg = BeginTime.ToString("HH")
                Info.Hind = (Hinnad.Item(I) / 10) + (StructBors.Juurdetasu)
                InfoList.Add(Info)
                BeginTime = BeginTime.AddHours(1)
            Next
        ElseIf PaketiTyyp = 1 Then
            Me.StructFix = AndmedConnect.LoePakettFix(PakettID)
            For I = 0 To 23
                Dim Info As (Aeg As String, Hind As Decimal)
                Info.Aeg = BeginTime.ToString("HH")
                If BeginTime.Hour > 22 Or BeginTime.Hour < 7 Then
                    Info.Hind = StructFix.OTariif
                Else
                    Info.Hind = StructFix.PTariif
                End If
                InfoList.Add(Info)
                BeginTime = BeginTime.AddHours(1)
            Next
        Else
            Me.StructUniv = AndmedConnect.LoePakettUniv(PakettID)
            For I = 0 To 23
                Dim Info As (Aeg As String, Hind As Decimal)
                Info.Aeg = BeginTime.ToString("HH")
                Info.Hind = StructUniv.Baas + StructUniv.Marginaal
                InfoList.Add(Info)
                BeginTime = BeginTime.AddHours(1)
            Next
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
        Dim CurrTime As Date = Date.Now()
        Dim EndTime As DateTime = New DateTime(CurrTime.Year, CurrTime.Month, CurrTime.Day + 1, 0, 0, 0)
        Dim BeginTime As Date = EndTime.AddMonths(-1)
        Dim TS As New TimeSpan
        TS = EndTime.Subtract(BeginTime)
        Dim Tunnid As Integer = TS.TotalHours
        'paketitüübi valik(0=börs, 1=fix, 2=universaal)
        If PaketiTyyp = 0 Then
            Me.StructBors = AndmedConnect.LoePakettBors(PakettID)
            Hinnad = AndmedConnect.LoeBorsihinnad(BeginTime, Tunnid)
            While I < Tunnid - 1
                Dim Info As (Aeg As String, Hind As Decimal)
                Info.Aeg = BeginTime.ToString("M")
                While J < 24
                    Info.Hind += (Hinnad.Item(I) / 10) + StructBors.Juurdetasu
                    I += 1
                    J += 1
                    BeginTime = BeginTime.AddHours(1)
                End While
                J = 0
                Info.Hind = Info.Hind / 24
                InfoList.Add(Info)
            End While
        ElseIf PaketiTyyp = 1 Then
            Me.StructFix = AndmedConnect.LoePakettFix(PakettID)
            For I = 0 To Tunnid - 1 Step 24
                Dim Info As (Aeg As String, Hind As Decimal)
                Info.Aeg = BeginTime.ToString("M")
                Info.Hind = ((8 * StructFix.OTariif) + (16 * StructFix.PTariif)) / 24
                BeginTime = BeginTime.AddDays(1)
                InfoList.Add(Info)
            Next
        Else
            Me.StructUniv = AndmedConnect.LoePakettUniv(PakettID)
            For I = 0 To Tunnid - 1 Step 24
                Dim Info As (Aeg As String, Hind As Decimal)
                Info.Aeg = BeginTime.ToString("M")
                Info.Hind = StructUniv.Baas + StructUniv.Marginaal
                BeginTime = BeginTime.AddDays(1)
                InfoList.Add(Info)
            Next
        End If
        Return InfoList
    End Function

    Public Function GetAasta(PakettID As Integer, PaketiTyyp As Integer) As List(Of (Aeg As String, Hind As Decimal)) Implements IGraafikInfo.GetAasta
        Dim InfoList As New List(Of (Aeg As String, Hind As Decimal))
        Dim Hinnad As New List(Of Decimal)
        Dim AndmedConnect As PrjAndmebaas.IAndmebaas
        AndmedConnect = New PrjAndmebaas.CAndmebaas
        Dim I As Integer = 0
        Dim J As Integer = 0
        Dim CurrTime As Date = Date.Now()
        Dim EndTime As DateTime = New DateTime(CurrTime.Year, CurrTime.Month, CurrTime.Day + 1, 0, 0, 0)
        Dim BeginTime As Date = EndTime.AddYears(-1)
        Dim TS As New TimeSpan
        TS = EndTime.Subtract(BeginTime)
        Dim Tunnid As Integer = TS.TotalHours
        'paketitüübi valik(0=börs, 1=fix, 2=universaal)
        If PaketiTyyp = 0 Then
            Me.StructBors = AndmedConnect.LoePakettBors(PakettID)
            Hinnad = AndmedConnect.LoeBorsihinnad(BeginTime, Tunnid)
            While I < Hinnad.Count - 1
                Dim Info As (Aeg As String, Hind As Decimal)
                Info.Aeg = BeginTime.ToString("y")
                Dim PaevaArvKuus = DaysInMonth(BeginTime.Year, BeginTime.Month)
                While J < (PaevaArvKuus * 24) And I < Hinnad.Count
                    Info.Hind += (Hinnad.Item(I) / 10) + StructBors.Juurdetasu
                    I += 1
                    J += 1
                    BeginTime = BeginTime.AddHours(1)
                End While
                J = 0
                Info.Hind = Info.Hind / (PaevaArvKuus * 24)
                InfoList.Add(Info)
            End While
        ElseIf PaketiTyyp = 1 Then
            Me.StructFix = AndmedConnect.LoePakettFix(PakettID)
            While I < Tunnid - 1
                Dim Info As (Aeg As String, Hind As Decimal)
                Info.Aeg = BeginTime.ToString("y")
                Dim PaevaArvKuus = DaysInMonth(BeginTime.Year, BeginTime.Month)
                While J < (PaevaArvKuus * 24)
                    If BeginTime.Hour > 22 Or BeginTime.Hour < 7 Then
                        Info.Hind += StructFix.OTariif
                    Else
                        Info.Hind += StructFix.PTariif
                    End If
                    J += 1
                    I += 1
                    BeginTime = BeginTime.AddHours(1)
                End While
                J = 0
                Info.Hind = (Info.Hind / (PaevaArvKuus * 24)) + StructFix.Kuutasu
                InfoList.Add(Info)
            End While
        Else
            Me.StructUniv = AndmedConnect.LoePakettUniv(PakettID)
            While I < Tunnid - 1
                Dim Info As (Aeg As String, Hind As Decimal)
                Info.Aeg = BeginTime.ToString("y")
                Dim PaevaArvKuus = DaysInMonth(BeginTime.Year, BeginTime.Month)
                While J < (PaevaArvKuus * 24)
                    Info.Hind += StructUniv.Baas + StructUniv.Marginaal
                    I += 1
                    BeginTime = BeginTime.AddHours(1)
                    J += 1
                End While
                J = 0
                Info.Hind = (Info.Hind / (PaevaArvKuus * 24)) + StructUniv.Kuutasu
                InfoList.Add(Info)
            End While
        End If
        Return InfoList
    End Function

    Public Function GetCustom(PakettID As Integer, PaketiTyyp As Integer, AlgAeg As Date, LoppAeg As Date, Flag As Integer) As List(Of (Aeg As String, Hind As Decimal)) Implements IGraafikInfo.GetCustom
        Dim InfoList As New List(Of (Aeg As String, Hind As Decimal))
        Dim Hinnad As New List(Of Decimal)
        Dim AndmedConnect As PrjAndmebaas.IAndmebaas
        AndmedConnect = New PrjAndmebaas.CAndmebaas
        Dim I As Integer = 0
        Dim J As Integer = 0
        Dim TS As New TimeSpan
        'kontrollime kas algkuupäev on sama mis lõppkuupäev
        AlgAeg = New Date(AlgAeg.Year, AlgAeg.Month, AlgAeg.Day, 0, 0, 0)
        LoppAeg = New Date(LoppAeg.Year, LoppAeg.Month, LoppAeg.Day, 0, 0, 0)
        If DaysInMonth(LoppAeg.Year, LoppAeg.Month) = LoppAeg.Day Then
            If LoppAeg.Month = 12 Then
                LoppAeg = New Date(LoppAeg.Year + 1, 1, 1, 0, 0, 0)
            Else
                LoppAeg = New Date(LoppAeg.Year, LoppAeg.Month + 1, 1, 0, 0, 0)
            End If
        Else
            LoppAeg = New Date(LoppAeg.Year, LoppAeg.Month, LoppAeg.Day + 1, 0, 0, 0)
        End If
        TS = LoppAeg.Subtract(AlgAeg)
        Dim Tunnid As Integer = TS.TotalHours
        'kui on ainult 24 tundi vahet siis anname tundide lõikes andmed
        If Tunnid = 24 Then
            'paketitüübi valik(0=börs, 1=fix, 2=universaal)
            If PaketiTyyp = 0 Or Flag = 1 Then
                If Flag = 0 Then
                    Me.StructBors = AndmedConnect.LoePakettBors(PakettID)
                End If
                Hinnad = AndmedConnect.LoeBorsihinnad(AlgAeg, Tunnid)
                For I = 0 To 23
                    Dim Info As (Aeg As String, Hind As Decimal)
                    Info.Aeg = AlgAeg.ToString("HH")
                    If Flag = 0 Then
                        Info.Hind = (Hinnad.Item(I) / 10) + (StructBors.Juurdetasu)
                    Else
                        Info.Hind = Hinnad.Item(I) / 10
                    End If
                    InfoList.Add(Info)
                    AlgAeg = AlgAeg.AddHours(1)
                Next
            ElseIf PaketiTyyp = 1 Then
                    Me.StructFix = AndmedConnect.LoePakettFix(PakettID)
                    For I = 0 To 23
                        Dim Info As (Aeg As String, Hind As Decimal)
                        Info.Aeg = AlgAeg.ToString("HH")
                        If AlgAeg.Hour > 22 Or AlgAeg.Hour < 7 Then
                            Info.Hind = StructFix.OTariif
                        Else
                            Info.Hind = StructFix.PTariif
                        End If
                        InfoList.Add(Info)
                        AlgAeg = AlgAeg.AddHours(1)
                    Next
                Else
                    Me.StructUniv = AndmedConnect.LoePakettUniv(PakettID)
                For I = 0 To 23
                    Dim Info As (Aeg As String, Hind As Decimal)
                    Info.Aeg = AlgAeg.ToString("HH")
                    Info.Hind = StructUniv.Baas + StructUniv.Marginaal
                    InfoList.Add(Info)
                    AlgAeg = AlgAeg.AddHours(1)
                Next
            End If
        Else 'kui on rohkem kui 24 tundi anname päevade lõikes
            'paketitüübi valik(0=börs, 1=fix, 2=universaal)
            If PaketiTyyp = 0 Or Flag = 1 Then
                If Flag = 0 Then
                    Me.StructBors = AndmedConnect.LoePakettBors(PakettID)
                End If
                Hinnad = AndmedConnect.LoeBorsihinnad(AlgAeg, Tunnid)
                While I < Tunnid - 1
                    Dim Info As (Aeg As String, Hind As Decimal)
                    Info.Aeg = AlgAeg.ToString("M")
                    While J < 24
                        If Flag = 0 Then
                            Info.Hind += (Hinnad.Item(I) / 10) + StructBors.Juurdetasu
                        Else
                            Info.Hind += Hinnad.Item(I) / 10
                        End If
                        I += 1
                        J += 1
                        AlgAeg = AlgAeg.AddHours(1)
                    End While
                    J = 0
                    Info.Hind = Info.Hind / 24
                    InfoList.Add(Info)
                End While
            ElseIf PaketiTyyp = 1 Then
                Me.StructFix = AndmedConnect.LoePakettFix(PakettID)
                For I = 0 To Tunnid - 1 Step 24
                    Dim Info As (Aeg As String, Hind As Decimal)
                    Info.Aeg = AlgAeg.ToString("M")
                    Info.Hind = ((8 * StructFix.OTariif) + (16 * StructFix.PTariif)) / 24
                    AlgAeg = AlgAeg.AddDays(1)
                    InfoList.Add(Info)
                Next
            Else
                Me.StructUniv = AndmedConnect.LoePakettUniv(PakettID)
                For I = 0 To Tunnid - 1 Step 24
                    Dim Info As (Aeg As String, Hind As Decimal)
                    Info.Aeg = AlgAeg.ToString("M")
                    Info.Hind = StructUniv.Baas + StructUniv.Marginaal
                    AlgAeg = AlgAeg.AddDays(1)
                    InfoList.Add(Info)
                Next
            End If
        End If
        Return InfoList
    End Function
End Class
