﻿Imports System.Data.OleDb
Imports System.Net
Imports Microsoft.VisualBasic.FileIO
Imports Newtonsoft.Json
Public Class CAndmebaas
    Implements IAndmebaas

    Private GConnection As OleDbConnection

    Public Function LoePakettideNimekiri() As List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp)) Implements IAndmebaas.LoePakettideNimekiri
        Dim Paketid As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                Dim Cmd As New OleDbCommand
                Dim Reader As OleDbDataReader

                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM paketid_bors "
                    Reader = .ExecuteReader
                End With
                Cmd.Dispose()
                While Reader.Read()
                    Dim Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp)
                    Pakett.ID = Reader("ID")
                    Pakett.Nimi = Reader("nimi").ToString
                    Pakett.Tyyp = IAndmebaas.PaketiTyyp.PAKETT_BORS
                    Paketid.Add(Pakett)
                End While
                Reader.Close()

                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM paketid_fix "
                    Reader = .ExecuteReader
                End With
                Cmd.Dispose()
                While Reader.Read()
                    Dim Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp)
                    Pakett.ID = Reader("ID")
                    Pakett.Nimi = Reader("nimi").ToString
                    Pakett.Tyyp = IAndmebaas.PaketiTyyp.PAKETT_FIX
                    Paketid.Add(Pakett)
                End While
                Reader.Close()

                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM paketid_univ "
                    Reader = .ExecuteReader
                End With
                Cmd.Dispose()
                While Reader.Read()
                    Dim Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp)
                    Pakett.ID = Reader("ID")
                    Pakett.Nimi = Reader("nimi").ToString
                    Pakett.Tyyp = IAndmebaas.PaketiTyyp.PAKETT_UNIV
                    Paketid.Add(Pakett)
                End While
                Reader.Close()

                .Close()
            End With
            Connection.Dispose()

            Return Paketid
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Paketid
        End Try
    End Function

    Function LoePakettBors(ID As Integer) As IAndmebaas.PkBors Implements IAndmebaas.LoePakettBors
        Dim Pakett As New IAndmebaas.PkBors
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                Dim Cmd As New OleDbCommand
                Dim Reader As OleDbDataReader

                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM paketid_bors " &
                                   "WHERE ID = " &
                                   ID.ToString
                    Reader = .ExecuteReader
                End With
                Cmd.Dispose()

                Reader.Read()
                Pakett.ID = Reader("ID")
                Pakett.Nimi = Reader("nimi").ToString
                Pakett.Juurdetasu = Reader("juurdetasu")
                Pakett.Kuutasu = Reader("kuutasu")
                Reader.Close()

                .Close()
            End With
            Connection.Dispose()

            Return Pakett
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Pakett
        End Try
    End Function

    Public Function LoePakettFix(ID As Integer) As IAndmebaas.PkFix Implements IAndmebaas.LoePakettFix
        Dim Pakett As New IAndmebaas.PkFix
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                Dim Cmd As New OleDbCommand
                Dim Reader As OleDbDataReader

                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM paketid_fix " &
                                   "WHERE ID = " &
                                   ID.ToString
                    Reader = .ExecuteReader
                End With
                Cmd.Dispose()

                Reader.Read()
                Pakett.ID = Reader("ID")
                Pakett.Nimi = Reader("nimi").ToString
                Pakett.PTariif = Reader("ptariif")
                Pakett.OTariif = Reader("otariif")
                Pakett.Kuutasu = Reader("kuutasu")
                Reader.Close()

                .Close()
            End With
            Connection.Dispose()

            Return Pakett
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Pakett
        End Try
    End Function

    Public Function LoePakettUniv(ID As Integer) As IAndmebaas.PkUniv Implements IAndmebaas.LoePakettUniv
        Dim Pakett As New IAndmebaas.PkUniv
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                Dim Cmd As New OleDbCommand
                Dim Reader As OleDbDataReader

                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM paketid_univ " &
                                   "WHERE ID = " &
                                   ID.ToString
                    Reader = .ExecuteReader
                End With
                Cmd.Dispose()

                Reader.Read()
                Pakett.ID = Reader("ID")
                Pakett.Nimi = Reader("nimi").ToString
                Pakett.Baas = Reader("baas")
                Pakett.Marginaal = Reader("marginaal")
                Pakett.Kuutasu = Reader("kuutasu")
                Reader.Close()

                .Close()
            End With
            Connection.Dispose()

            Return Pakett
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Pakett
        End Try
    End Function

    Public Function LoeKodumasinad() As List(Of IAndmebaas.Kodumasin) Implements IAndmebaas.LoeKodumasinad
        Dim Kodumasinad As New List(Of IAndmebaas.Kodumasin)
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                Dim Cmd As New OleDbCommand
                Dim Reader As OleDbDataReader

                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM kodumasinad "
                    Reader = .ExecuteReader
                End With
                Cmd.Dispose()
                While Reader.Read()
                    Dim Kodumasin As IAndmebaas.Kodumasin
                    Kodumasin.ID = Reader("ID")
                    Kodumasin.Nimi = Reader("nimi").ToString
                    Kodumasin.Voimsus = Reader("voimsus")
                    Kodumasin.Aeg = Reader("aeg")
                    Kodumasinad.Add(Kodumasin)
                End While
                Reader.Close()

                .Close()
            End With
            Connection.Dispose()

            Return Kodumasinad
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return Kodumasinad
        End Try
    End Function

    Private Const KAIBEMAKS = 1.2 ' 20%
    Private LugemineOK As Boolean
    Public Function LoeBorsihinnad(AlgusAeg As Date, Tunnid As Integer) As List(Of Decimal) Implements IAndmebaas.LoeBorsihinnad
        Dim Ajad As New List(Of Decimal)

        Dim Aeg As Date = AlgusAeg
        Aeg = Aeg.ToUniversalTime()
        Aeg = New Date(Aeg.Year, Aeg.Month, Aeg.Day, Aeg.Hour, 0, 0)

        GConnection = New OleDbConnection
        With GConnection
            .ConnectionString = LoeConnectionString()
            .Open()

            For i As Integer = 0 To Tunnid - 1
                Dim Hind As Decimal = LoeBorsihind(Aeg, Tunnid - i) * KAIBEMAKS
                Ajad.Add(Hind)
                Aeg = Aeg.AddHours(1)
                If Hind = 0 And LugemineOK = False Then ' Kui hindasid pole, siis ära neid edasi küsi
                    For j As Integer = 0 To Tunnid - i - 2
                        Ajad.Add(0)
                    Next
                    Exit For
                End If
            Next

            .Close()
        End With
        GConnection.Dispose()

        Return Ajad
    End Function
    ' Loe alates mingist ajast N tunni jagu börsihindasid
    ' Hindade ühik on sent/kWh
    Public Function LoeBorsihinnadSentkWh(AlgusAeg As Date, Tunnid As Integer) As List(Of Decimal) Implements IAndmebaas.LoeBorsihinnadSentkWh
        Dim Hinnad As List(Of Decimal) = LoeBorsihinnad(AlgusAeg, Tunnid)

        For i As Integer = 0 To Hinnad.Count - 1
            Hinnad(i) *= 0.1
        Next

        Return Hinnad
    End Function
    'Public Function LoeBorsKuuKeskmine(AlgusAeg As Date, Kuud As Integer) As List(Of Decimal) Implements IAndmebaas.LoeBorsKuuKeskmine
    '    Dim Ajad As New List(Of Decimal)

    '    ' Ümarda aeg kuu algusesse ja teisenda UTC'sse
    '    Dim Aeg As Date = AlgusAeg
    '    Aeg = Aeg.ToUniversalTime()
    '    Aeg = New Date(Aeg.Year, Aeg.Month, 0, 0, 0, 0)

    '    ' Loe keskmised hinnad
    '    GConnection = New OleDbConnection
    '    With GConnection
    '        .ConnectionString = LoeConnectionString()
    '        .Open()

    '        For i As Integer = 0 To Kuud - 1
    '            Dim Hind As Decimal = LoeKuuKeskmineHind(Aeg, Kuud - i) * KAIBEMAKS
    '            Ajad.Add(Hind)
    '            Aeg = Aeg.AddMonths(1)
    '            If Hind = 0 And LugemineOK = False Then ' Kui hindasid pole, siis ära neid edasi küsi
    '                For j As Integer = 0 To Kuud - i - 2
    '                    Ajad.Add(0)
    '                Next
    '                Exit For
    '            End If
    '        Next

    '        .Close()
    '    End With
    '    GConnection.Dispose()

    '    Return Ajad
    'End Function
    Private Class JsonJuur
        Public data As JsonHinnad
    End Class
    Private Class JsonHinnad
        Public ee() As JsonHind
    End Class
    Private Class JsonHind
        Public Timestamp As Integer
        Public Price As Decimal
    End Class
    Private Function LoeBorsihind(Aeg As Date, Tunnid As Integer) As Decimal
        Dim Timestamp As Integer
        Timestamp = (Aeg - New Date(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds

        ' Vaata, kas selle tunni hind on juba andmebaasis olemas
        Try
            Dim Cmd As New OleDbCommand
            Dim Reader As OleDbDataReader

            With Cmd
                .Connection = GConnection
                .CommandType = CommandType.Text
                .CommandText = "SELECT * FROM borsihinnad " &
                               "WHERE [timestamp] = " &
                               Timestamp.ToString &
                               ";"
                Reader = .ExecuteReader
            End With
            Cmd.Dispose()

            Reader.Read()
            If Reader.HasRows Then
                ' Andmebaasis olemas
                Dim HindReturn As Decimal = Reader("hind")
                Reader.Close()
                LugemineOK = True
                Return HindReturn
            End If
            Reader.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        ' Ei ole, otsusta, mitu tundi tuleb lugeda
        For i As Integer = 1 To Tunnid - 1
            Dim TimestampKontroll As String
            TimestampKontroll = (Aeg.AddHours(i) - New Date(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds.ToString
            Try
                Dim Cmd As New OleDbCommand
                Dim Reader As OleDbDataReader

                With Cmd
                    .Connection = GConnection
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM borsihinnad " &
                               "WHERE [timestamp] = " &
                               TimestampKontroll.ToString &
                               ";"
                    Reader = .ExecuteReader
                End With
                Cmd.Dispose()

                Reader.Read()
                If Reader.HasRows Then
                    Reader.Close()
                    Tunnid = i
                    Exit For
                End If
                Reader.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        Next

        ' Loe andmed API kaudu
        Dim TimeString As String
        TimeString = Aeg.AddMilliseconds(-1).ToString("yyyy-MM-ddTHH\:mm\:ss.fff") & "Z"
        Dim TimeStringLopp As String
        TimeStringLopp = Aeg.AddHours(Tunnid).AddMilliseconds(-1).ToString("yyyy-MM-ddTHH\:mm\:ss.fff") & "Z"

        Dim JsonStr As String
        Dim RequestStr As String = "https://dashboard.elering.ee/api/nps/price?start=" &
                                   TimeString &
                                   "&end=" &
                                   TimeStringLopp
        Using WebClient As New WebClient
            JsonStr = WebClient.DownloadString(RequestStr)
        End Using
        Dim Andmed = JsonConvert.DeserializeObject(Of JsonJuur)(JsonStr)
        Dim Hinnad = Andmed.data.ee

        ' Kui andmed puuduvad (küsiti tulevikust), siis tagasta 0
        If Hinnad.Length = 0 Then
            LugemineOK = False
            Return 0
        End If

        ' Lisa loetud hinnad andmebaasi
        For i As Integer = 0 To Hinnad.Length - 1
            Try
                Dim Cmd As New OleDbCommand
                With Cmd
                    .Connection = GConnection
                    .CommandType = CommandType.Text
                    .CommandText = "INSERT INTO borsihinnad " &
                                       "([timestamp], hind) " &
                                       "VALUES (@p1, @p2);"

                    .Parameters.Add(New OleDbParameter("@p1", OleDbType.Integer)).Value = Hinnad(i).Timestamp
                    .Parameters.Add(New OleDbParameter("@p2", OleDbType.Currency)).Value = Hinnad(i).Price

                    .ExecuteNonQuery()
                End With
                Cmd.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        Next

        LugemineOK = True
        Return Hinnad(0).Price
    End Function
    'Private Function LoeKuuKeskmineHind(Aeg As Date, Kuud As Integer) As Decimal
    '    ' Leia, mitu börsihinda lugeda tuleb
    '    Dim NHinnad = Date.DaysInMonth(Aeg.Year, Aeg.Month) * 24

    '    ' Loe börsihinnad
    '    Dim Hinnad As New List(Of Decimal)
    '    Hinnad = LoeBorsihind(Aeg, NHinnad)

    '    ' Loe hinnad
    '    For i As Integer = 0 To NHinnad - 1
    '        Dim Hind = LoeBorsihind(Aeg, NHinnad)
    '    Next

    '    Dim Timestamp As String
    '    Timestamp = (Aeg - New Date(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds.ToString

    '    ' Vaata, kas selle tunni hind on juba andmebaasis olemas
    '    Try
    '        Dim Cmd As New OleDbCommand
    '        Dim Reader As OleDbDataReader

    '        With Cmd
    '            .Connection = GConnection
    '            .CommandType = CommandType.Text
    '            .CommandText = "SELECT * FROM borsihinnad " &
    '                           "WHERE [timestamp] = " &
    '                           """" &
    '                           Timestamp &
    '                           """" &
    '                           ";"
    '            Reader = .ExecuteReader
    '        End With
    '        Cmd.Dispose()

    '        Reader.Read()
    '        If Reader.HasRows Then
    '            ' Andmebaasis olemas
    '            Dim HindReturn As Decimal = Reader("hind")
    '            Reader.Close()
    '            LugemineOK = True
    '            Return HindReturn
    '        End If
    '        Reader.Close()
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '    End Try

    '    ' Ei ole, otsusta, mitu tundi tuleb lugeda
    '    For i As Integer = 1 To Tunnid - 1
    '        Dim TimestampKontroll As String
    '        TimestampKontroll = (Aeg.AddHours(i) - New Date(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds.ToString
    '        Try
    '            Dim Cmd As New OleDbCommand
    '            Dim Reader As OleDbDataReader

    '            With Cmd
    '                .Connection = GConnection
    '                .CommandType = CommandType.Text
    '                .CommandText = "SELECT * FROM borsihinnad " &
    '                           "WHERE [timestamp] = " &
    '                           """" &
    '                           TimestampKontroll &
    '                           """;"
    '                Reader = .ExecuteReader
    '            End With
    '            Cmd.Dispose()

    '            Reader.Read()
    '            If Reader.HasRows Then
    '                Reader.Close()
    '                Tunnid = i
    '                Exit For
    '            End If
    '            Reader.Close()
    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        End Try
    '    Next

    '    ' Loe andmed API kaudu
    '    Dim TimeString As String
    '    TimeString = Aeg.AddMilliseconds(-1).ToString("yyyy-MM-ddTHH\:mm\:ss.fff") & "Z"
    '    Dim TimeStringLopp As String
    '    TimeStringLopp = Aeg.AddHours(Tunnid).AddMilliseconds(-1).ToString("yyyy-MM-ddTHH\:mm\:ss.fff") & "Z"

    '    Dim JsonStr As String
    '    Dim RequestStr As String = "https://dashboard.elering.ee/api/nps/price?start=" &
    '                               TimeString &
    '                               "&end=" &
    '                               TimeStringLopp
    '    Using WebClient As New WebClient
    '        JsonStr = WebClient.DownloadString(RequestStr)
    '    End Using
    '    Dim Andmed = JsonConvert.DeserializeObject(Of JsonJuur)(JsonStr)
    '    Dim Hinnad = Andmed.data.ee

    '    ' Kui andmed puuduvad (küsiti tulevikust), siis tagasta 0
    '    If Hinnad.Length = 0 Then
    '        LugemineOK = False
    '        Return 0
    '    End If

    '    ' Lisa loetud hinnad andmebaasi
    '    For i As Integer = 0 To Hinnad.Length - 1
    '        Try
    '            Dim Cmd As New OleDbCommand
    '            With Cmd
    '                .Connection = GConnection
    '                .CommandType = CommandType.Text
    '                .CommandText = "INSERT INTO borsihinnad " &
    '                                   "([timestamp], hind) " &
    '                                   "VALUES (@p1, @p2);"

    '                .Parameters.Add(New OleDbParameter("@p1", OleDbType.VarChar, 255)).Value = Hinnad(i).Timestamp
    '                .Parameters.Add(New OleDbParameter("@p2", OleDbType.Currency)).Value = Hinnad(i).Price

    '                .ExecuteNonQuery()
    '            End With
    '            Cmd.Dispose()
    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        End Try
    '    Next

    '    LugemineOK = True
    '    Return Hinnad(0).Price
    'End Function

    Public Sub LisaPakettBors(Nimi As String, JuurdeTasu As Decimal, Kuutasu As Decimal) Implements IAndmebaas.LisaPakettBors
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                Dim Cmd As New OleDbCommand
                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "INSERT INTO paketid_bors " &
                                       "(nimi, juurdetasu, kuutasu) " &
                                       "VALUES (@p1, @p2, @p3);"

                    .Parameters.Add(New OleDbParameter("@p1", OleDbType.VarChar, 255)).Value = Nimi
                    .Parameters.Add(New OleDbParameter("@p2", OleDbType.Currency)).Value = JuurdeTasu
                    .Parameters.Add(New OleDbParameter("@p3", OleDbType.Currency)).Value = Kuutasu

                    .ExecuteNonQuery()
                End With
                Cmd.Dispose()

                .Close()
            End With
            Connection.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub LisaPakettFix(Nimi As String, PTariif As Decimal, OTariif As Decimal, Kuutasu As Decimal) Implements IAndmebaas.LisaPakettFix
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                Dim Cmd As New OleDbCommand
                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "INSERT INTO paketid_fix " &
                                       "(nimi, ptariif, otariif, kuutasu) " &
                                       "VALUES (@p1, @p2, @p3, @p4);"

                    .Parameters.Add(New OleDbParameter("@p1", OleDbType.VarChar, 255)).Value = Nimi
                    .Parameters.Add(New OleDbParameter("@p2", OleDbType.Currency)).Value = PTariif
                    .Parameters.Add(New OleDbParameter("@p3", OleDbType.Currency)).Value = OTariif
                    .Parameters.Add(New OleDbParameter("@p4", OleDbType.Currency)).Value = Kuutasu

                    .ExecuteNonQuery()
                End With
                Cmd.Dispose()

                .Close()
            End With
            Connection.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub LisaPakettUniv(Nimi As String, Baashind As Decimal, Marginaal As Decimal, Kuutasu As Decimal) Implements IAndmebaas.LisaPakettUniv
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                Dim Cmd As New OleDbCommand
                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "INSERT INTO paketid_univ " &
                                       "(nimi, baas, marginaal, kuutasu) " &
                                       "VALUES (@p1, @p2, @p3, @p4);"

                    .Parameters.Add(New OleDbParameter("@p1", OleDbType.VarChar, 255)).Value = Nimi
                    .Parameters.Add(New OleDbParameter("@p2", OleDbType.Currency)).Value = Baashind
                    .Parameters.Add(New OleDbParameter("@p3", OleDbType.Currency)).Value = Marginaal
                    .Parameters.Add(New OleDbParameter("@p4", OleDbType.Currency)).Value = Kuutasu

                    .ExecuteNonQuery()
                End With
                Cmd.Dispose()

                .Close()
            End With
            Connection.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub LisaKodumasin(Nimi As String, Voimsus As Double, Aeg As Double) Implements IAndmebaas.LisaKodumasin
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                Dim Cmd As New OleDbCommand
                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "INSERT INTO kodumasinad " &
                                       "(nimi, voimsus, aeg) " &
                                       "VALUES (@p1, @p2, @p3);"

                    .Parameters.Add(New OleDbParameter("@p1", OleDbType.VarChar, 255)).Value = Nimi
                    .Parameters.Add(New OleDbParameter("@p2", OleDbType.Double)).Value = Voimsus
                    .Parameters.Add(New OleDbParameter("@p3", OleDbType.Double)).Value = Aeg

                    .ExecuteNonQuery()
                End With
                Cmd.Dispose()

                .Close()
            End With
            Connection.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub MuudaPakettBors(ID As Integer, Nimi As String, JuurdeTasu As Decimal, Kuutasu As Decimal) Implements IAndmebaas.MuudaPakettBors
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                Dim Cmd As New OleDbCommand
                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "UPDATE paketid_bors " &
                                   "SET nimi = @p1, " &
                                   "juurdetasu = @p2, " &
                                   "kuutasu = @p3 " &
                                   "WHERE ID = " &
                                   ID.ToString &
                                   ";"

                    .Parameters.Add(New OleDbParameter("@p1", OleDbType.VarChar, 255)).Value = Nimi
                    .Parameters.Add(New OleDbParameter("@p2", OleDbType.Currency)).Value = JuurdeTasu
                    .Parameters.Add(New OleDbParameter("@p3", OleDbType.Currency)).Value = Kuutasu

                    .ExecuteNonQuery()
                End With
                Cmd.Dispose()

                .Close()
            End With
            Connection.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub MuudaPakettFix(ID As Integer, Nimi As String, PTariif As Decimal, OTariif As Decimal, Kuutasu As Decimal) Implements IAndmebaas.MuudaPakettFix
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                Dim Cmd As New OleDbCommand
                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "UPDATE paketid_fix " &
                                   "SET nimi = @p1, " &
                                   "ptariif = @p2, " &
                                   "otariif = @p3, " &
                                   "kuutasu = @p4 " &
                                   "WHERE ID = " &
                                   ID.ToString &
                                   ";"

                    .Parameters.Add(New OleDbParameter("@p1", OleDbType.VarChar, 255)).Value = Nimi
                    .Parameters.Add(New OleDbParameter("@p2", OleDbType.Currency)).Value = PTariif
                    .Parameters.Add(New OleDbParameter("@p3", OleDbType.Currency)).Value = OTariif
                    .Parameters.Add(New OleDbParameter("@p4", OleDbType.Currency)).Value = Kuutasu

                    .ExecuteNonQuery()
                End With
                Cmd.Dispose()

                .Close()
            End With
            Connection.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub MuudaPakettUniv(ID As Integer, Nimi As String, Baashind As Decimal, Marginaal As Decimal, Kuutasu As Decimal) Implements IAndmebaas.MuudaPakettUniv
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                Dim Cmd As New OleDbCommand
                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "UPDATE paketid_univ " &
                                   "SET nimi = @p1, " &
                                   "baas = @p2, " &
                                   "marginaal = @p3, " &
                                   "kuutasu = @p4 " &
                                   "WHERE ID = " &
                                   ID.ToString &
                                   ";"

                    .Parameters.Add(New OleDbParameter("@p1", OleDbType.VarChar, 255)).Value = Nimi
                    .Parameters.Add(New OleDbParameter("@p2", OleDbType.Currency)).Value = Baashind
                    .Parameters.Add(New OleDbParameter("@p3", OleDbType.Currency)).Value = Marginaal
                    .Parameters.Add(New OleDbParameter("@p4", OleDbType.Currency)).Value = Kuutasu

                    .ExecuteNonQuery()
                End With
                Cmd.Dispose()

                .Close()
            End With
            Connection.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub MuudaKodumasin(ID As Integer, Nimi As String, Voimsus As Double, Aeg As Double) Implements IAndmebaas.MuudaKodumasin
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                Dim Cmd As New OleDbCommand
                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "UPDATE kodumasinad " &
                                   "SET nimi = @p1, " &
                                   "voimsus = @p2, " &
                                   "aeg = @p3 " &
                                   "WHERE ID = " &
                                   ID.ToString &
                                   ";"

                    .Parameters.Add(New OleDbParameter("@p1", OleDbType.VarChar, 255)).Value = Nimi
                    .Parameters.Add(New OleDbParameter("@p2", OleDbType.Double)).Value = Voimsus
                    .Parameters.Add(New OleDbParameter("@p3", OleDbType.Double)).Value = Aeg

                    .ExecuteNonQuery()
                End With
                Cmd.Dispose()

                .Close()
            End With
            Connection.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub KustutaPakettBors(ID As Integer) Implements IAndmebaas.KustutaPakettBors
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                Dim Cmd As New OleDbCommand
                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "DELETE FROM paketid_bors " &
                                   "WHERE ID = " &
                                   ID.ToString &
                                   ";"

                    .ExecuteNonQuery()
                End With
                Cmd.Dispose()

                .Close()
            End With
            Connection.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub KustutaPakettFix(ID As Integer) Implements IAndmebaas.KustutaPakettFix
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                Dim Cmd As New OleDbCommand
                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "DELETE FROM paketid_fix " &
                                   "WHERE ID = " &
                                   ID.ToString &
                                   ";"

                    .ExecuteNonQuery()
                End With
                Cmd.Dispose()

                .Close()
            End With
            Connection.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub KustutaPakettUniv(ID As Integer) Implements IAndmebaas.KustutaPakettUniv
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                Dim Cmd As New OleDbCommand
                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "DELETE FROM paketid_univ " &
                                   "WHERE ID = " &
                                   ID.ToString &
                                   ";"

                    .ExecuteNonQuery()
                End With
                Cmd.Dispose()

                .Close()
            End With
            Connection.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub KustutaKodumasin(ID As Integer) Implements IAndmebaas.KustutaKodumasin
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                Dim Cmd As New OleDbCommand
                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "DELETE FROM kodumasinad " &
                                   "WHERE ID = " &
                                   ID.ToString &
                                   ";"

                    .ExecuteNonQuery()
                End With
                Cmd.Dispose()

                .Close()
            End With
            Connection.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function LoeConnectionString() As String
        'Return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Environment.CurrentDirectory & "\andmebaas.accdb"
        Return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & SpecialDirectories.Desktop & "\andmebaas.accdb"
    End Function

End Class
