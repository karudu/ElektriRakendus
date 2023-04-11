Imports System.Security.Cryptography


Public Class KodumasinaKasutus
    Inherits Kalkulaator
    Dim Elktrikogus As Double
    Dim Kulu As Double
    Public Sub New(ByVal PaketHind As Decimal, ByVal kasutus As Double, ByVal Aeg As Double)
        ' Baasklassi konstruktori väljakutse
        MyBase.New("KodumasinaKasutus", PaketHind, kasutus, Aeg)
    End Sub

    Public Overrides Function Kasutatudenergia() As Double
        Elktrikogus = Elktrikasutus * KasutusAeg
        Return Elktrikogus
    End Function

    Public Overrides Function Rahalinekulu() As Double
        Kulu = (Elktrikasutus / 1000) * KasutusAeg * (dblElektriPaket / 100)
        Return Kulu
    End Function
End Class
