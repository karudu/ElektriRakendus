Public Interface IGraafikInfo
    Function GetPaev(ByVal PakettID As Integer) As String(,)
    Function GetKuu(ByVal PakettID As Integer) As String(,)
    Function GetAasta(ByVal PakettID As Integer) As String(,)

End Interface
