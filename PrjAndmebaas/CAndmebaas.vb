﻿Imports System.Data.OleDb
Imports System.Net
Imports Microsoft.VisualBasic.FileIO
Imports Newtonsoft.Json
Public Class CAndmebaas
    Implements IAndmebaas

    Private GConnection As OleDbConnection
    Private FormLoading As FormLoading

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
    ' Loe alates mingist ajast N tunni jagu börsihindu
    Public Function LoeBorsihinnad(AlgusAeg As Date, Tunnid As Integer) As List(Of Decimal) Implements IAndmebaas.LoeBorsihinnad
        Dim Hinnad As New List(Of Decimal)

        ' Ümarda aeg tunni peale ja teisenda see UTC'sse
        Dim Aeg As Date = AlgusAeg
        Aeg = Aeg.ToUniversalTime()
        Aeg = New Date(Aeg.Year, Aeg.Month, Aeg.Day, Aeg.Hour, 0, 0)

        GConnection = New OleDbConnection
        With GConnection
            ' Loo ühendus andmebaasiga
            .ConnectionString = LoeConnectionString()
            .Open()

            ' Kui ajavahemik on pikem kui aasta, siis loe hinnad
            ' aasta kaupa, vastasel juhul ei tagasta API sellest suuremat vahemikku
            While Tunnid >= 365 * 24
                Hinnad.AddRange(LoeBorsihind(Aeg, 365 * 24))
                Aeg = Aeg.AddHours(365 * 24)
                Tunnid -= 365 * 24
            End While

            ' Loe ülejäänud hinnad
            If Tunnid <> 0 Then Hinnad.AddRange(LoeBorsihind(Aeg, Tunnid))

            ' Lisa hindadele käibemaks
            For i As Integer = 0 To Hinnad.Count - 1
                Hinnad(i) *= KAIBEMAKS
            Next

            ' Lõpeta ühendus
            .Close()
        End With
        GConnection.Dispose()

        Return Hinnad
    End Function
    ' Loe alates mingist ajast N tunni jagu börsihindu
    ' Hindade ühik on sent/kWh
    Public Function LoeBorsihinnadSentkWh(AlgusAeg As Date, Tunnid As Integer) As List(Of Decimal) Implements IAndmebaas.LoeBorsihinnadSentkWh
        Dim Hinnad As List(Of Decimal) = LoeBorsihinnad(AlgusAeg, Tunnid)

        ' Teisenda EUR/MWh->sent/kWh
        For i As Integer = 0 To Hinnad.Count - 1
            Hinnad(i) *= 0.1
        Next

        Return Hinnad
    End Function
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

    Private Function LoeBorsihindAPI(Aeg As Date, Tunnid As Integer) As List(Of Decimal)
        Dim ReturnHinnad As New List(Of Decimal)

        ' Börsihinnad loetakse Unix timestamp'ide kaudu, leia lugemise vahemiku
        ' alguse ja lõpu aeg
        Dim TimeString As String
        TimeString = Aeg.AddMilliseconds(-1).ToString("yyyy-MM-ddTHH\:mm\:ss.fff") & "Z"
        Dim TimeStringLopp As String
        TimeStringLopp = Aeg.AddHours(Tunnid).AddMilliseconds(-1).ToString("yyyy-MM-ddTHH\:mm\:ss.fff") & "Z"

        Dim JsonStr As String
        ' API päringu URL
        Dim RequestStr As String = "https://dashboard.elering.ee/api/nps/price?start=" &
                                   TimeString &
                                   "&end=" &
                                   TimeStringLopp
        ' Tee GET päring ja loe vastu võetud tekst
        Using WebClient As New WebClient
            JsonStr = WebClient.DownloadString(RequestStr)
        End Using
        ' Loe välja JSON'ist andmed
        Dim Andmed = JsonConvert.DeserializeObject(Of JsonJuur)(JsonStr)
        Dim Hinnad = Andmed.data.ee

        ' Kui andmed puuduvad (küsiti tulevikust), siis tagasta kõik hinnad 0
        If Hinnad.Length = 0 Then
            LugemineOK = False

            For i As Integer = 0 To Tunnid - 1
                ReturnHinnad.Add(0)
            Next

            Return ReturnHinnad
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

                    ReturnHinnad.Add(Hinnad(i).Price)
                End With
                Cmd.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        Next

        Return ReturnHinnad
    End Function
    ' debug
    'Private Function Sorteeritud(Ajad As List(Of Integer)) As Boolean
    '    Dim Eelmine = 0
    '    For Each Aeg In Ajad
    '        If Aeg <= Eelmine Then Return False
    '        Eelmine = Aeg
    '    Next
    '    Return True
    'End Function
    Private Function LoeBorsihind(Aeg As Date, Tunnid As Integer) As List(Of Decimal)
        Debug.Assert(Tunnid > 0)

        ' Börsihinnad loetakse Unix timestamp'ide kaudu, leia lugemise vahemiku
        ' alguse ja lõpu aeg
        Dim TimestampAlgus As Integer
        TimestampAlgus = (Aeg - New Date(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds
        Dim TimestampLopp As Integer
        TimestampLopp = TimestampAlgus + (Tunnid * 3600) - 1 ' 3600 sec/tund

        ' Vaata, kas vaja minevad hinnad on juba andmebaasis olemas
        Dim LoetudHinnad As New List(Of Decimal)
        Dim LoetudAjad As New List(Of Integer)
        Try
            Dim Cmd As New OleDbCommand
            Dim Reader As OleDbDataReader

            With Cmd
                .Connection = GConnection
                .CommandType = CommandType.Text
                .CommandText = "SELECT * FROM borsihinnad " &
                               "WHERE [timestamp] BETWEEN " &
                               TimestampAlgus.ToString &
                               " AND " &
                               TimestampLopp.ToString &
                               " ORDER BY [timestamp];"
                Reader = .ExecuteReader
            End With
            Cmd.Dispose()

            If Reader.HasRows Then
                ' Kopeeri andmebaasist saadud hinnad nimekirja
                While Reader.Read()
                    LoetudHinnad.Add(Reader("hind"))
                    LoetudAjad.Add(Reader("timestamp"))
                End While
                Reader.Close()

                ' Kui kõik vajalikud hinnad on olemas, siis tagasta need
                If LoetudHinnad.Count = Tunnid Then Return LoetudHinnad
            End If
            ' Kui jõudsime siia, siis tuleb hindu juurde pärida
            Reader.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        ' Näita kasutajale laadimise akent
        FormLoading = New PrjAndmebaas.FormLoading
        FormLoading.Show()
        FormLoading.Refresh()

        Dim ReturnHinnad As New List(Of Decimal)
        Dim i = 0
        Dim Offset = 0
        ' Loe vajaminevad hinnad API kaudu
        While i <> Tunnid
            ' Otsime hindade vahemikke, mis on andmebaasis olemas ja mida ei pea lugema
            Dim TimestampKontroll As Integer
            TimestampKontroll = (Aeg.AddHours(i) - New Date(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds

            If LoetudAjad.Contains(TimestampKontroll) Then
                ' Olemasolev hind leitud, loe API'st kõik enne seda tulevad hinnad
                Dim TunnidLugeda = i - Offset
                If TunnidLugeda <> 0 Then
                    Dim APIHinnad As New List(Of Decimal)
                    APIHinnad = LoeBorsihindAPI(Aeg.AddHours(Offset), TunnidLugeda)
                    LoetudHinnad.InsertRange(Offset, APIHinnad)
                End If
                Offset = i + 1
                ' Vaata, kas peale seda on veel hindu, mida saab vahele jätta
                For j As Integer = i + 1 To Tunnid - 1
                    TimestampKontroll = (Aeg.AddHours(j) - New Date(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds

                    If LoetudAjad.Contains(TimestampKontroll) Then
                        Offset += 1
                        i += 1
                    Else
                        Exit For
                    End If
                Next
            End If

            i += 1
        End While

        ' Enam olemasolevaid hindu ees ei ole, loe kõik ülejäänud
        Dim APIHinnad_ = LoeBorsihindAPI(Aeg.AddHours(Offset), Tunnid - Offset)
        LoetudHinnad.InsertRange(Offset, APIHinnad_)

        LugemineOK = True
        FormLoading.Close()
        FormLoading.Dispose()
        'Debug.Assert(LoetudHinnad.Count = Tunnid)
        Return LoetudHinnad
    End Function
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
