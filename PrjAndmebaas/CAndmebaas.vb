'FAILINIMI: CAndmebaas.vb
'AUTOR:     Karl Udu
'LOODUD:    20.03.2023
'MUUDETUD:  03.05.2023
'
'KIRJELDUS: Klass andmebaasiga liidestamiseks, võimalik on
'           lisada, muuta ja kustutada elektripakette ja kodumasinaid.
'           Lisaks on meetodid Elering'i API kaudu börsihindade lugemiseks.
'EELTINGIMUSED: Andmebaasi objektide (paketid, kodumasinad) poole pöördumiseks
'               on vaja teada ID'sid, nende lugemiseks on meetodid olemas.

Imports System.Data.OleDb
Imports System.Net
Imports System.Security.Cryptography
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.FileIO
Imports Newtonsoft.Json
Public Class CAndmebaas
    Implements IAndmebaas

    Private GConnection As OleDbConnection
    Private FormLoading As FormLoading

    ' Loe nimekiri kõikidest andmebaasis olevatest elektripakettidest
    Public Function LoePakettideNimekiri() As List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp)) Implements IAndmebaas.LoePakettideNimekiri
        Dim Paketid As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))

        Try
            Dim Connection As New OleDbConnection
            With Connection
                ' Andmebaasist lugemise käsk
                .ConnectionString = LoeConnectionString()
                .Open()

                Dim Cmd As New OleDbCommand
                Dim Reader As OleDbDataReader

                ' Loe kõik börsipaketid
                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM paketid_bors "
                    Reader = .ExecuteReader
                End With
                Cmd.Dispose()

                ' Loe tagastatud paketid ja lisa need nimekirja
                While Reader.Read()
                    Dim Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp)
                    Pakett.ID = Reader("ID")
                    Pakett.Nimi = Reader("nimi").ToString
                    Pakett.Tyyp = IAndmebaas.PaketiTyyp.PAKETT_BORS
                    Paketid.Add(Pakett)
                End While
                Reader.Close()

                ' Loe kõik fikseeritud paketid
                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM paketid_fix "
                    Reader = .ExecuteReader
                End With
                Cmd.Dispose()

                ' Loe tagastatud paketid ja lisa need nimekirja
                While Reader.Read()
                    Dim Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp)
                    Pakett.ID = Reader("ID")
                    Pakett.Nimi = Reader("nimi").ToString
                    Pakett.Tyyp = IAndmebaas.PaketiTyyp.PAKETT_FIX
                    Paketid.Add(Pakett)
                End While
                Reader.Close()

                ' Loe kõik universaalpaketid
                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM paketid_univ "
                    Reader = .ExecuteReader
                End With
                Cmd.Dispose()

                ' Loe tagastatud paketid ja lisa need nimekirja
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
    ' Loe andmebaasist ühe börsipaketi andmed
    Function LoePakettBors(ID As Integer) As IAndmebaas.PkBors Implements IAndmebaas.LoePakettBors
        Dim Pakett As New IAndmebaas.PkBors
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                ' Paketi lugemise käsk
                Dim Cmd As New OleDbCommand
                Dim Reader As OleDbDataReader

                ' Loe antud börsipakett
                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM paketid_bors " &
                                   "WHERE ID = " &
                                   ID.ToString
                    Reader = .ExecuteReader
                End With
                Cmd.Dispose()

                ' Loe tagastatud väärtused
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
    ' Loe andmebaasist ühe fikseeritud paketi andmed
    Public Function LoePakettFix(ID As Integer) As IAndmebaas.PkFix Implements IAndmebaas.LoePakettFix
        Dim Pakett As New IAndmebaas.PkFix
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                ' Paketi lugemise käsk
                Dim Cmd As New OleDbCommand
                Dim Reader As OleDbDataReader

                ' Loe antud fikseeritud pakett
                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM paketid_fix " &
                                   "WHERE ID = " &
                                   ID.ToString
                    Reader = .ExecuteReader
                End With
                Cmd.Dispose()

                ' Loe tagastatud väärtused
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
    ' Loe andmebaasist ühe universaalpaketi andmed
    Public Function LoePakettUniv(ID As Integer) As IAndmebaas.PkUniv Implements IAndmebaas.LoePakettUniv
        Dim Pakett As New IAndmebaas.PkUniv
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                ' Paketi lugemise käsk
                Dim Cmd As New OleDbCommand
                Dim Reader As OleDbDataReader

                ' Loe antud universaalpakett
                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM paketid_univ " &
                                   "WHERE ID = " &
                                   ID.ToString
                    Reader = .ExecuteReader
                End With
                Cmd.Dispose()

                ' Loe tagastatud väärtused
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
    ' Loe nimekiri kõikidest andmebaasis olevatest kodumasinatest ja nende andmetest
    Public Function LoeKodumasinad() As List(Of IAndmebaas.Kodumasin) Implements IAndmebaas.LoeKodumasinad
        Dim Kodumasinad As New List(Of IAndmebaas.Kodumasin)
        Try
            Dim Connection As New OleDbConnection
            With Connection
                ' Andmebaasist lugemise käsk
                .ConnectionString = LoeConnectionString()
                .Open()

                Dim Cmd As New OleDbCommand
                Dim Reader As OleDbDataReader
                ' Loe kõik kodumasinad
                With Cmd
                    .Connection = Connection
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM kodumasinad "
                    Reader = .ExecuteReader
                End With
                Cmd.Dispose()

                ' Loe tagastatud kodumasinad ja lisa need nimekirja
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
    ' Kui hindade lugemine ebaõnnestus (internetiühendus puudub), siis tagastatakse exception
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

            Try
                ' Kui ajavahemik on pikem kui aasta, siis loe hinnad
                ' aasta kaupa, vastasel juhul ei tagasta API sellest suuremat vahemikku
                While Tunnid >= 365 * 24
                    Hinnad.AddRange(LoeBorsihind(Aeg, 365 * 24))
                    Aeg = Aeg.AddHours(365 * 24)
                    Tunnid -= 365 * 24
                End While

                ' Loe ülejäänud hinnad
                If Tunnid <> 0 Then Hinnad.AddRange(LoeBorsihind(Aeg, Tunnid))
            Catch ex As Exception
                Throw New Exception
                Exit Function
            End Try

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
    ' Kui hindade lugemine ebaõnnestus (internetiühendus puudub), siis tagastatakse exception
    Public Function LoeBorsihinnadSentkWh(AlgusAeg As Date, Tunnid As Integer) As List(Of Decimal) Implements IAndmebaas.LoeBorsihinnadSentkWh
        Dim Hinnad As List(Of Decimal)
        Try
            Hinnad = LoeBorsihinnad(AlgusAeg, Tunnid)
        Catch ex As Exception
            Throw New Exception
            Exit Function
        End Try

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
    ' Loo ühendus serveriga ja proovi lugeda alates mingist ajast N tunni jagu börsihindu
    ' Kui kõiki hindu ei tagastatud, siis LugemineOK väärtuseks seatakse False
    ' Kui hindade lugemine ebaõnnestus (internetiühendus puudub), siis tagastatakse exception
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
        Try
            Using WebClient As New WebClient
                JsonStr = WebClient.DownloadString(RequestStr)
            End Using
        Catch ex As Exception
            Throw New Exception
            Exit Function
        End Try

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
    ' Proovi lugeda alates mingist ajast N tunni jagu börsihindu, kas andmebaasi või API kaudu
    ' Kui kõiki hindu ei tagastatud, siis LugemineOK väärtuseks seatakse False
    ' Kui hindade lugemine ebaõnnestus (internetiühendus puudub), siis tagastatakse exception
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
        Dim APIHinnad_ As List(Of Decimal)
        Try
            APIHinnad_ = LoeBorsihindAPI(Aeg.AddHours(Offset), Tunnid - Offset)
        Catch ex As Exception
            FormLoading.Close()
            FormLoading.Dispose()
            MessageBox.Show("Börsihindade saamiseks on vaja internetiühendust," &
                            Environment.NewLine &
                            "veendu, et see on olemas ja proovi uuesti",
                            "Internetiühendus puudub", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Throw New Exception
            Exit Function
        End Try

        LoetudHinnad.InsertRange(Offset, APIHinnad_)

        LugemineOK = True
        FormLoading.Close()
        FormLoading.Dispose()
        'Debug.Assert(LoetudHinnad.Count = Tunnid)
        Return LoetudHinnad
    End Function
    ' Lisa andmebaasi uus börsipakett
    Public Sub LisaPakettBors(Nimi As String, JuurdeTasu As Decimal, Kuutasu As Decimal) Implements IAndmebaas.LisaPakettBors
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                ' Sisesta andmebaasi antud parameetritega börsipakett
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
    ' Lisa andmebaasi uus fikseeritud pakett
    Public Sub LisaPakettFix(Nimi As String, PTariif As Decimal, OTariif As Decimal, Kuutasu As Decimal) Implements IAndmebaas.LisaPakettFix
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                ' Sisesta andmebaasi antud parameetritega fikseeritud pakett
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
    ' Lisa andmebaasi uus universaalpakett
    Public Sub LisaPakettUniv(Nimi As String, Baashind As Decimal, Marginaal As Decimal, Kuutasu As Decimal) Implements IAndmebaas.LisaPakettUniv
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                ' Sisesta andmebaasi antud parameetritega universaalpakett
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
    ' Lisa andmebaasi uus kodumasin
    Public Sub LisaKodumasin(Nimi As String, Voimsus As Double, Aeg As Double) Implements IAndmebaas.LisaKodumasin
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                ' Sisesta andmebaasi antud parameetritega kodumasin
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
    ' Muuda andmebaasis oleva antud börsipaketi parameetreid
    Public Sub MuudaPakettBors(ID As Integer, Nimi As String, JuurdeTasu As Decimal, Kuutasu As Decimal) Implements IAndmebaas.MuudaPakettBors
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                ' Kirjuta antud börsipaketi parameetrid üle
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
    ' Muuda andmebaasis oleva antud fikseeritud paketi parameetreid
    Public Sub MuudaPakettFix(ID As Integer, Nimi As String, PTariif As Decimal, OTariif As Decimal, Kuutasu As Decimal) Implements IAndmebaas.MuudaPakettFix
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                ' Kirjuta antud fikseeritud paketi parameetrid üle
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
    ' Muuda andmebaasis oleva antud universaalpaketi parameetreid
    Public Sub MuudaPakettUniv(ID As Integer, Nimi As String, Baashind As Decimal, Marginaal As Decimal, Kuutasu As Decimal) Implements IAndmebaas.MuudaPakettUniv
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                ' Kirjuta antud universaalpaketi parameetrid üle
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
    ' Muuda andmebaasis oleva antud kodumasina parameetreid
    Public Sub MuudaKodumasin(ID As Integer, Nimi As String, Voimsus As Double, Aeg As Double) Implements IAndmebaas.MuudaKodumasin
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                ' Kirjuta antud kodumasina parameetrid üle
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
    ' Kustuta andmebaasis olev börsipakett
    Public Sub KustutaPakettBors(ID As Integer) Implements IAndmebaas.KustutaPakettBors
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                ' Kustuta antud börsipakett
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
    ' Kustuta andmebaasis olev fikseeritud pakett
    Public Sub KustutaPakettFix(ID As Integer) Implements IAndmebaas.KustutaPakettFix
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                ' Kustuta antud fikseeritud pakett
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
    ' Kustuta andmebaasis olev universaalpakett
    Public Sub KustutaPakettUniv(ID As Integer) Implements IAndmebaas.KustutaPakettUniv
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                ' Kustuta antud universaalpakett
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
    ' Kustuta andmebaasis olev kodumasin
    Public Sub KustutaKodumasin(ID As Integer) Implements IAndmebaas.KustutaKodumasin
        Try
            Dim Connection As New OleDbConnection
            With Connection
                .ConnectionString = LoeConnectionString()
                .Open()

                ' Kustuta antud kodumasin
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
    ' Andmebaasiga ühenduse loomiseks vajalik string
    ' Andmebaas on fail, mis asub programmi kaustas
    Private Function LoeConnectionString() As String
        Return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Environment.CurrentDirectory & "\andmebaas.accdb"
    End Function
End Class
