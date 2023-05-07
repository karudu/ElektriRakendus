
Public Interface ITarbimiseCSVLugeja

    Function LoeCSV(lines As List(Of String)) As List(Of (Kuupäev As String, Voimsus_kWh As Decimal))

End Interface
