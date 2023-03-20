Public Interface IAndmebaas
    Sub LisaPakettBors(ByVal Nimi As String, ByVal JuurdeTasu As Decimal, ByVal Kuutasu As Decimal)
    Sub LisaPakettFix(ByVal Nimi As String, ByVal PTariif As Decimal, ByVal OTariif As Decimal, ByVal Kuutasu As Decimal)
    Sub LisaPakettUniv(ByVal Nimi As String, ByVal Baashind As Decimal, ByVal Marginaal As Decimal, ByVal Kuutasu As Decimal)

    Function LoePakettideNimekiri() As List(Of (ID As Integer, Nimi As String, Tyyp As PaketiTyyp))

    Enum PaketiTyyp
        PAKETT_BORS
        PAKETT_FIX
        PAKETT_UNIV
    End Enum
End Interface

Public Interface IPakett
    Sub LoePakett(ByVal ID As Integer)
End Interface