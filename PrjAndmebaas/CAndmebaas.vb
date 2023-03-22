Imports System.Data.OleDb

Public Class CAndmebaas
    Implements IAndmebaas

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
        Return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Environment.CurrentDirectory & "\andmebaas.accdb"
    End Function
End Class
