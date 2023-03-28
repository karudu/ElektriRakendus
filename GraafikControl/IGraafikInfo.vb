Public Interface IGraafikInfo
    Function GetPaev(ByVal PakettID As Integer, ByVal PaketiTyyp As Integer) As List(Of (Aeg As String, Hind As Decimal))
    Function GetKuu(ByVal PakettID As Integer, ByVal PaketiTyyp As Integer) As List(Of (Aeg As String, Hind As Decimal))
    Function GetAasta(ByVal PakettID As Integer, ByVal PaketiTyyp As Integer) As List(Of (Aeg As String, Hind As Decimal))

End Interface
