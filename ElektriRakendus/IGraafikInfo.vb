Public Interface IGraafikInfo
    Function GetPaev(ByVal PakettID As Integer, ByVal PaketiTyyp As Integer) As List(Of (Aeg As String, Hind As Double))
    Function GetKuu(ByVal PakettID As Integer, ByVal PaketiTyyp As Integer) As String(,)
    Function GetAasta(ByVal PakettID As Integer, ByVal PaketiTyyp As Integer) As String(,)

End Interface
