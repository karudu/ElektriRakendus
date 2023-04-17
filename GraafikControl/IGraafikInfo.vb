Public Interface IGraafikInfo
    Function GetPaev(ByVal PakettID As Integer, ByVal PaketiTyyp As Integer) As List(Of (Aeg As String, Hind As Decimal))
    Function GetKuu(ByVal PakettID As Integer, ByVal PaketiTyyp As Integer) As List(Of (Aeg As String, Hind As Decimal))
    Function GetAasta(ByVal PakettID As Integer, ByVal PaketiTyyp As Integer) As List(Of (Aeg As String, Hind As Decimal))
    Function GetCustom(ByVal PakettID As Integer, ByVal PaketiTyyp As Integer, ByVal AlgAeg As Date, ByVal LoppAeg As Date) As List(Of (Aeg As String, Hind As Decimal))



End Interface
