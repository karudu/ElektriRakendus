Public Interface IAndmebaas

    Function LoePakettideNimekiri() As List(Of (ID As Integer, Nimi As String, Tyyp As PaketiTyyp))
    Function LoePakettBors(ID As Integer) As PkBors
    Function LoePakettFix(ID As Integer) As PkFix
    Function LoePakettUniv(ID As Integer) As PkUniv
    Sub LisaPakettBors(Nimi As String, JuurdeTasu As Decimal, Kuutasu As Decimal)
    Sub LisaPakettFix(Nimi As String, PTariif As Decimal, OTariif As Decimal, Kuutasu As Decimal)
    Sub LisaPakettUniv(Nimi As String, Baashind As Decimal, Marginaal As Decimal, Kuutasu As Decimal)
    Sub MuudaPakettBors(ID As Integer, Nimi As String, JuurdeTasu As Decimal, Kuutasu As Decimal)
    Sub MuudaPakettFix(ID As Integer, Nimi As String, PTariif As Decimal, OTariif As Decimal, Kuutasu As Decimal)
    Sub MuudaPakettUniv(ID As Integer, Nimi As String, Baashind As Decimal, Marginaal As Decimal, Kuutasu As Decimal)
    Sub KustutaPakettBors(ID As Integer)
    Sub KustutaPakettFix(ID As Integer)
    Sub KustutaPakettUniv(ID As Integer)

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
