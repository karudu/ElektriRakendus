Public MustInherit Class Kalkulaator

    Protected strElektriPaket As String
    Protected dblElektriPaket As Double
    Protected KasutusAeg As Double
    Protected Elktrikasutus As Double

    Public Sub New(ByVal strElektriPaket As String, ByVal dblElektriPaket As Double, ByVal Elktrikasutus As Double, ByVal KasutusAeg As Double)
        Me.strElektriPaket = strElektriPaket
        Me.dblElektriPaket = dblElektriPaket
        Me.Elktrikasutus = Elktrikasutus
        Me.KasutusAeg = KasutusAeg
    End Sub

    Public Function annaTyyp() As String
        Return strElektriPaket
    End Function

    Public MustOverride Function Kasutatudenergia() As Double

    Public MustOverride Function Rahalinekulu() As Double

End Class
