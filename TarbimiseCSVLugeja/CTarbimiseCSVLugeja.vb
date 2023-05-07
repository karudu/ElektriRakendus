Imports System.Windows.Forms
Public Class CTarbimiseCSVLugeja
    Implements ITarbimiseCSVLugeja

    Public Function LoeCSV(Lines As List(Of String)) As List(Of (Kuupäev As String, Voimsus_kWh As Decimal)) Implements ITarbimiseCSVLugeja.LoeCSV
        Dim CSVinfo As New List(Of (Kuupäev As String, Voimsus_kWh As Decimal))
        Dim Info As (Kuupäev As String, Voimsus_kWh As Decimal)

        For i As Integer = 1 To Lines.Count - 1
            Dim data As String() = Lines(i).Split(",")
            Dim isValidDate As Boolean = IsDate(data(0))
            If isValidDate = False Then 'kontroll kas kuupäeval on korektne forormaat'
                MessageBox.Show("CSV failis on vigane kuupäev ", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                MessageBox.Show(" Vigane osa " + data(0) + " viga asub real" + (i + 1).ToString, "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            If IsNumeric(data(1)) = False Then 'kontroll kas võõimsuses on numbrid ikka'
                MessageBox.Show("CSV failis on vigane võimsus ", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                MessageBox.Show(" Vigane osa " + data(1) + " viga asub real" + (i + 1).ToString, "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            Info.Kuupäev = data(0) 'lisab kuupaeva  DataGridView1'
            Info.Voimsus_kWh = data(1) 'lisab voimsuse  DataGridView1'

            CSVinfo.Add(Info)
        Next

        Return CSVinfo
    End Function
End Class
