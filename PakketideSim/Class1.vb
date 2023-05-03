Imports PrjAndmebaas

Public Class Class1
    Implements Interface1
    'Public Property Kuupäev As String
    ' Public Property Voimsus_kWh As Decimal

    Public Function LoeCSV(Lines As List(Of String), ofd As OpenFileDialog) As List(Of (Kuupäev As String, algAeg As String, loppAeg As String, Voimsus_kWh As Decimal)) Implements Interface1.LoeCSV

        Dim CSVinfo As New List(Of (Kuupäev As String, algAeg As String, loppAeg As String, Voimsus_kWh As Decimal))
        Dim Info As (Kuupäev As String, algAeg As String, loppAeg As String, Voimsus_kWh As Decimal)
        Dim h As Integer = 1



        For i As Integer = 1 To Lines.Count - 1

            Dim data As String() = Lines(i).Split(",")
            Dim isValidDate As Boolean = IsDate(data(0))
            If isValidDate = False Then 'kontroll kas kuupäeval on korektne forormaat'

                MsgBox(MessageBox.Show("CSV failis on vigane kuupäev ", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning))
                MsgBox(MessageBox.Show(" Vigane osa " + data(0) + " viga asub real" + (i + 1).ToString, "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning))

            End If
            If IsNumeric(data(1)) = False Then 'kontroll kas võõimsuses on numbrid ikka'
                MsgBox(MessageBox.Show("CSV failis on vigane võimsus ", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning))
                MsgBox(MessageBox.Show(" Vigane osa " + data(1) + " viga asub real" + (i + 1).ToString, "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning))

            End If

            Info.Kuupäev = data(0) 'lisab kuupaeva  DataGridView1'
            Info.Voimsus_kWh = data(1) 'lisab voimsuse  DataGridView1'

            If i = h Then
                Info.loppAeg = data(0)
            End If
            If h = 1 Then
                Info.algAeg = data(0)

            End If
            h = h + 1
            CSVinfo.Add(Info)
        Next


        Return CSVinfo
    End Function


End Class
