Public Interface IAndmebaas
    Function LoePakettideNimekiri() As List(Of (ID As Integer, Nimi As String, Tyyp As PaketiTyyp))
    Function LoePakettBors(ID As Integer) As PkBors
    Function LoePakettFix(ID As Integer) As PkFix
    Function LoePakettUniv(ID As Integer) As PkUniv
    Function LoeKodumasinad() As List(Of Kodumasin)
    Function LoeBorsihinnad(AlgusAeg As Date, Tunnid As Integer) As List(Of Decimal)
    Sub LisaPakettBors(Nimi As String, JuurdeTasu As Decimal, Kuutasu As Decimal)
    Sub LisaPakettFix(Nimi As String, PTariif As Decimal, OTariif As Decimal, Kuutasu As Decimal)
    Sub LisaPakettUniv(Nimi As String, Baashind As Decimal, Marginaal As Decimal, Kuutasu As Decimal)
    Sub LisaKodumasin(Nimi As String, Voimsus As Double, Aeg As Double)
    Sub MuudaPakettBors(ID As Integer, Nimi As String, JuurdeTasu As Decimal, Kuutasu As Decimal)
    Sub MuudaPakettFix(ID As Integer, Nimi As String, PTariif As Decimal, OTariif As Decimal, Kuutasu As Decimal)
    Sub MuudaPakettUniv(ID As Integer, Nimi As String, Baashind As Decimal, Marginaal As Decimal, Kuutasu As Decimal)
    Sub MuudaKodumasin(ID As Integer, Nimi As String, Voimsus As Double, Aeg As Double)
    Sub KustutaPakettBors(ID As Integer)
    Sub KustutaPakettFix(ID As Integer)
    Sub KustutaPakettUniv(ID As Integer)
    Sub KustutaKodumasin(ID As Integer)

    Enum PaketiTyyp
        PAKETT_BORS
        PAKETT_FIX
        PAKETT_UNIV
    End Enum
    Structure PkBors
        Public ID As Integer
        Public Nimi As String
        Public Juurdetasu As Decimal
        Public Kuutasu As Decimal
    End Structure
    Structure PkFix
        Public ID As Integer
        Public Nimi As String
        Public PTariif As Decimal
        Public OTariif As Decimal
        Public Kuutasu As Decimal
    End Structure
    Structure PkUniv
        Public ID As Integer
        Public Nimi As String
        Public Baas As Decimal
        Public Marginaal As Decimal
        Public Kuutasu As Decimal
    End Structure
    Structure Kodumasin
        Public ID As Integer
        Public Nimi As String
        Public Voimsus As Double
        Public Aeg As Double
    End Structure
End Interface
