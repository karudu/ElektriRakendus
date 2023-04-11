Imports PrjAndmebaas
Public Class FormPakettideVordlus
    Dim Paketid As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
    Dim ConnectDb As New CAndmebaas
    Public StructBors As New PrjAndmebaas.IAndmebaas.PkBors
    Public StructFix As New PrjAndmebaas.IAndmebaas.PkFix
    Public StructUniv As New PrjAndmebaas.IAndmebaas.PkUniv
    Private Sub FormPakettideVordlus_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub joonistaGraafik(pktTypeB As IAndmebaas.PaketiTyyp, pktTypeF As IAndmebaas.PaketiTyyp, periood As Integer)
        Dim GInfo As List(Of (Xval As String, Yval As Decimal))
        Dim GInfo2 As List(Of (Xval As String, Yval As Decimal))
        Dim GetInfo As GraafikControl.IGraafikInfo
        GetInfo = New GraafikControl.CGraafikInfo

        Select Case periood
            Case 0
                GInfo = GetInfo.GetPaev(StructBors.ID, pktTypeB)
                GInfo2 = GetInfo.GetPaev(StructFix.ID, pktTypeF)
            Case 1
                GInfo = GetInfo.GetKuu(StructBors.ID, pktTypeB)
                GInfo2 = GetInfo.GetKuu(StructFix.ID, pktTypeF)
            Case 2
                GInfo = GetInfo.GetAasta(StructBors.ID, pktTypeB)
                GInfo2 = GetInfo.GetAasta(StructFix.ID, pktTypeF)
            Case Else
                cBoxPeriood.Text = "Valige periood!"
                Exit Sub
        End Select
        'Select Case periood
        '    Case 0
        '        GInfo = GetInfo.GetPaev(StructBors.ID, pktTypeB)
        '        GInfo2 = GetInfo.GetPaev(StructUniv.ID, pktTypeF)
        '    Case 1
        '        GInfo = GetInfo.GetKuu(StructBors.ID, pktTypeB)
        '        GInfo2 = GetInfo.GetKuu(StructFix.ID, pktTypeF)
        '    Case 2
        '        GInfo = GetInfo.GetAasta(StructBors.ID, pktTypeB)
        '        GInfo2 = GetInfo.GetAasta(StructFix.ID, pktTypeF)
        '    Case Else
        '        cBoxPeriood.Text = "Valige periood!"
        '        Exit Sub
        'End Select
        Dim Index As Integer = 0
        While Index < GInfo.Count - 1 And Index < GInfo2.Count - 1
            Graafik1.setPoint1(GInfo.Item(Index).Xval, GInfo.Item(Index).Yval)
            Graafik1.setPoint2(GInfo2.Item(Index).Xval, GInfo2.Item(Index).Yval)
            Index += 1
        End While
    End Sub
    'Börsi- ja fikseeritud hinna võrdlus graafikul
    Private Sub btnArvuta_Click(sender As Object, e As EventArgs) Handles btnArvuta.Click
        Graafik1.ClearPoints()
        Me.StructBors.Nimi = "Temp"
        Me.StructBors.Juurdetasu = 0
        Me.StructBors.Kuutasu = 0
        Me.StructFix.Nimi = "Temp"
        Me.StructFix.PTariif = CDec(Val(txtFixP.Text))
        Me.StructFix.OTariif = CDec(Val(txtFixO.Text))
        Me.StructFix.Kuutasu = 0

        If Not IsNumeric(txtFixP.Text) And Not IsNumeric(txtFixO.Text) Then
            cBoxPeriood.Text = "Sisestage ainult number päeva ja öö tariifidesse"
            Exit Sub
        End If

        ConnectDb.LisaPakettBors(StructBors.Nimi, StructBors.Juurdetasu, StructBors.Kuutasu)
        ConnectDb.LisaPakettFix(StructFix.Nimi, StructFix.PTariif, StructFix.OTariif, StructFix.Kuutasu)
        Dim nimekiri As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
        nimekiri = ConnectDb.LoePakettideNimekiri()
        Dim pktTypeB As IAndmebaas.PaketiTyyp
        Dim pktTypeF As IAndmebaas.PaketiTyyp
        Dim index As Integer
        Dim I As Integer
        For index = 0 To nimekiri.Count - 1
            If nimekiri(index).Tyyp = IAndmebaas.PaketiTyyp.PAKETT_BORS Then
                Me.StructBors.ID = nimekiri(index).ID
                pktTypeB = IAndmebaas.PaketiTyyp.PAKETT_BORS
                I = index
            End If
        Next
        Dim periood As Integer
        periood = cBoxPeriood.SelectedIndex
        For index = 0 To nimekiri.Count - 1
            If nimekiri(index).Tyyp = IAndmebaas.PaketiTyyp.PAKETT_FIX Then
                Me.StructFix.ID = nimekiri(index).ID
                pktTypeF = IAndmebaas.PaketiTyyp.PAKETT_FIX
                I = index
            End If
        Next
        joonistaGraafik(pktTypeB, pktTypeF, periood)
        ConnectDb.KustutaPakettBors(StructBors.ID)
        ConnectDb.KustutaPakettFix(StructFix.ID)
    End Sub

    Private Sub btnArvuta2_Click(sender As Object, e As EventArgs) Handles btnArvuta2.Click
        Graafik1.ClearPoints()
        Me.StructBors.Nimi = "Temp"
        Me.StructBors.Juurdetasu = 0
        Me.StructBors.Kuutasu = 0
        Me.StructUniv.Nimi = "Temp"
        Me.StructUniv.Baas = CDec(Val(txtBaas.Text))
        Me.StructUniv.Marginaal = 0
        Me.StructUniv.Kuutasu = 0

        If Not IsNumeric(txtBaas.Text) Then
            cBoxPeriood.Text = "Sisestage baas hind ainult numbrina"
            Exit Sub
        End If

        ConnectDb.LisaPakettBors(StructBors.Nimi, StructBors.Juurdetasu, StructBors.Kuutasu)
        ConnectDb.LisaPakettUniv(StructUniv.Nimi, StructUniv.Baas, StructUniv.Marginaal, StructUniv.Kuutasu)
        Dim nimekiri As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
        nimekiri = ConnectDb.LoePakettideNimekiri()
        Dim pktTypeB As IAndmebaas.PaketiTyyp
        Dim pktTypeU As IAndmebaas.PaketiTyyp
        Dim index As Integer
        Dim I As Integer
        For index = 0 To nimekiri.Count - 1
            If nimekiri(index).Tyyp = IAndmebaas.PaketiTyyp.PAKETT_BORS Then
                Me.StructBors.ID = nimekiri(index).ID
                pktTypeB = IAndmebaas.PaketiTyyp.PAKETT_BORS
                I = index
            End If
        Next
        For index = 0 To nimekiri.Count - 1
            If nimekiri(index).Tyyp = IAndmebaas.PaketiTyyp.PAKETT_UNIV Then
                Me.StructUniv.ID = nimekiri(index).ID
                pktTypeU = IAndmebaas.PaketiTyyp.PAKETT_UNIV
                I = index
            End If
        Next
        Dim periood As Integer
        periood = cBoxPeriood.SelectedIndex
        joonistaGraafik(pktTypeB, pktTypeB, periood)
        ConnectDb.KustutaPakettBors(StructBors.ID)
        ConnectDb.KustutaPakettUniv(StructUniv.ID)
    End Sub
End Class