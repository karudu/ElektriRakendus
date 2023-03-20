Public Interface IAndmebaas
    Sub LisaPakettBors(ByVal Nimi As String, ByVal JuurdeTasu As Decimal, ByVal Kuutasu As Decimal)
    Sub LisaPakettFix(ByVal Nimi As String, ByVal PTariif As Decimal, ByVal OTariif As Decimal, ByVal Kuutasu As Decimal)
    Sub LisaPakettUniv(ByVal Nimi As String, ByVal Baashind As Decimal, ByVal Marginaal As Decimal, ByVal Kuutasu As Decimal)

    Function LoePakettideNimekiri() As List(Of (ID As Integer, Nimi As String, Tyyp As PaketiTyyp))
    Function LoePakettBors(ID As Integer) As PkBors
    Function LoePakettFix(ID As Integer) As PkFix
    Function LoePakettUniv(ID As Integer) As PkUniv

    Enum PaketiTyyp
        PAKETT_BORS
        PAKETT_FIX
        PAKETT_UNIV
    End Enum
    Structure PkBors
        Public Nimi As String
        Public Juurdetasu As Decimal
        Public Kuutasu As Decimal
    End Structure
    Structure PkFix
        Public Nimi As String
        Public PTariif As Decimal
        Public OTariif As Decimal
        Public Kuutasu As Decimal
    End Structure
    Structure PkUniv
        Public Nimi As String
        Public Baas As Decimal
        Public Marginaal As Decimal
        Public Kuutasu As Decimal
    End Structure
End Interface
