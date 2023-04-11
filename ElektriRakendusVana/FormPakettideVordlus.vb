Imports PrjAndmebaas
Public Class FormPakettideVordlus
    Dim Paketid As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
    Dim ConnectDb As New CAndmebaas
    Public StructBors As New PrjAndmebaas.IAndmebaas.PkBors
    Public StructFix As New PrjAndmebaas.IAndmebaas.PkFix
    Public StructUniv As New PrjAndmebaas.IAndmebaas.PkUniv
    Private Sub FormPakettideVordlus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboxAlgus.Visible = False
        cboxLopp.Visible = False
        lblAlgus.Visible = False
        lblLopp.Visible = False
        lblError.Visible = False
        lblError2.Visible = False
    End Sub
    Private Sub cBoxPeriood_DropDownClosed(sender As Object, e As EventArgs) Handles cBoxPeriood.DropDownClosed
        Select Case cBoxPeriood.SelectedIndex
            Case 0
                cboxAlgus.Visible = True
                cboxLopp.Visible = True
                lblAlgus.Visible = True
                lblLopp.Visible = True
            Case Else
                cboxAlgus.Visible = False
                cboxLopp.Visible = False
                lblAlgus.Visible = False
                lblLopp.Visible = False
        End Select
    End Sub
    Private Sub joonistaGraafikBF(pktTypeB As IAndmebaas.PaketiTyyp, pktTypeF As IAndmebaas.PaketiTyyp, periood As Integer)
        Dim GInfo As List(Of (Xval As String, Yval As Decimal))
        Dim GInfo2 As List(Of (Xval As String, Yval As Decimal))
        Dim GetInfo As GraafikControl.IGraafikInfo
        GetInfo = New GraafikControl.CGraafikInfo

        Select Case periood
            Case 0
                If cboxAlgus.SelectedIndex = -1 And cboxLopp.SelectedIndex = -1 Then
                    cBoxPeriood.Text = "Valige aja algus ja lopp"
                    Exit Sub
                End If
                GInfo = GetInfo.GetPaev(StructBors.ID, pktTypeB)
                GInfo2 = GetInfo.GetPaev(StructFix.ID, pktTypeF)
            Case 1
                GInfo = GetInfo.GetPaev(StructBors.ID, pktTypeB)
                GInfo2 = GetInfo.GetPaev(StructFix.ID, pktTypeF)
            Case 2
                GInfo = GetInfo.GetKuu(StructBors.ID, pktTypeB)
                GInfo2 = GetInfo.GetKuu(StructFix.ID, pktTypeF)
            Case 3
                GInfo = GetInfo.GetAasta(StructBors.ID, pktTypeB)
                GInfo2 = GetInfo.GetAasta(StructFix.ID, pktTypeF)
            Case Else
                cBoxPeriood.Text = "Valige periood!"
                Exit Sub
        End Select
        Dim Index As Integer = 0
        If periood = 0 Then
            While Index < GInfo.Count And Index < GInfo2.Count
                If Index >= cboxAlgus.SelectedIndex And Index <= cboxLopp.SelectedIndex Then
                    Graafik1.setPoint1(GInfo.Item(Index).Xval, GInfo.Item(Index).Yval)
                    Graafik1.setPoint2(GInfo2.Item(Index).Xval, GInfo2.Item(Index).Yval)
                End If
                Index += 1
            End While
        Else
            While Index < GInfo.Count And Index < GInfo2.Count
                Graafik1.setPoint1(GInfo.Item(Index).Xval, GInfo.Item(Index).Yval)
                Graafik1.setPoint2(GInfo2.Item(Index).Xval, GInfo2.Item(Index).Yval)
                Index += 1
            End While
        End If
    End Sub
    Private Sub joonistaGraafikBU(pktTypeB As IAndmebaas.PaketiTyyp, pktTypeU As IAndmebaas.PaketiTyyp, AegAlgus As Integer, AegLopp As Integer)
        Dim GInfo As List(Of (Xval As String, Yval As Decimal))
        Dim GInfo2 As List(Of (Xval As String, Yval As Decimal))
        Dim GetInfo As GraafikControl.IGraafikInfo
        GetInfo = New GraafikControl.CGraafikInfo

        If cboxAlgus2.SelectedIndex <> -1 And cboxLopp2.SelectedIndex <> -1 Then
            GInfo = GetInfo.GetPaev(StructBors.ID, pktTypeB)
            GInfo2 = GetInfo.GetPaev(StructUniv.ID, pktTypeU)
        Else
            cboxAlgus2.Text = "Valige perioodi algus ja lopp ajad!"
            Exit Sub
        End If

        Dim Index As Integer = 0
        While Index < GInfo.Count And Index < GInfo2.Count
            If Index >= cboxAlgus2.SelectedIndex And Index <= cboxLopp2.SelectedIndex Then
                Graafik1.setPoint1(GInfo.Item(Index).Xval, GInfo.Item(Index).Yval)
                Graafik1.setPoint2(GInfo2.Item(Index).Xval, GInfo2.Item(Index).Yval)
            End If
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
            cboxAlgus2.Text = "Sisestage ainult numbrid päeva ja öö tariifidesse"
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
        For index = 0 To nimekiri.Count - 1
            If nimekiri(index).Tyyp = IAndmebaas.PaketiTyyp.PAKETT_FIX Then
                Me.StructFix.ID = nimekiri(index).ID
                pktTypeF = IAndmebaas.PaketiTyyp.PAKETT_FIX
                I = index
            End If
        Next
        Dim periood As Integer
        periood = cBoxPeriood.SelectedIndex
        joonistaGraafikBF(pktTypeB, pktTypeF, periood)
        ConnectDb.KustutaPakettBors(StructBors.ID)
        ConnectDb.KustutaPakettFix(StructFix.ID)
    End Sub
    'börsi ja univ pakettide võrdlus
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
        Dim AegAlgus As Integer
        AegAlgus = cboxAlgus2.SelectedIndex
        Dim AegLopp As Integer
        AegLopp = cboxLopp2.SelectedIndex
        joonistaGraafikBU(pktTypeB, pktTypeU, AegAlgus, AegLopp)
        ConnectDb.KustutaPakettBors(StructBors.ID)
        ConnectDb.KustutaPakettUniv(StructUniv.ID)
    End Sub
End Class