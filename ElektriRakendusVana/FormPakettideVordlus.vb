Imports System.Net.Security
Imports PrjAndmebaas
Public Class FormPakettideVordlus
    Dim Paketid As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
    ReadOnly ConnectDb As New CAndmebaas
    Public StructBors As New PrjAndmebaas.IAndmebaas.PkBors
    Public StructFix As New PrjAndmebaas.IAndmebaas.PkFix
    Public StructUniv As New PrjAndmebaas.IAndmebaas.PkUniv
    Private Sub FormPakettideVordlus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Index As Integer
        cboxPakett.Items.Clear()
        Paketid = ConnectDb.LoePakettideNimekiri 'load paketid to combobox
        cboxPakett.Items.Add("Börsihind")
        For Index = 0 To Paketid.Count - 1
            cboxPakett.Items.Add(Paketid(Index).Nimi)
        Next
        cboxAlgus.Visible = False
        cboxLopp.Visible = False
        lblAlgus.Visible = False
        lblLopp.Visible = False
        lblError.Visible = False
        lblError2.Visible = False
        lblKoguSum1.Visible = False
        lblKoguSum2.Visible = False
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
        Dim Index As Integer = 0
        Dim GInfo1Kesk As Decimal
        Dim GInfo2Kesk As Decimal
        Dim GInfo1Korge As Decimal = 0
        Dim GInfo1Madal As Decimal = 1000
        Dim kellaaegKorge As String
        Dim kellaaegMadal As String
        Dim ajaperioodKallim As Decimal = 0
        Dim ajaperioodOdavam As Decimal
        Dim ajavahemik As Integer
        lblError.Visible = True

        Select Case periood
            Case 0
                If cboxAlgus.SelectedIndex = -1 And cboxLopp.SelectedIndex = -1 Then
                    lblError.Text = "Valige perioodi algus ja lopp ajad"
                    Exit Sub
                End If
                If cboxAlgus.SelectedIndex >= cboxLopp.SelectedIndex Then
                    lblError.Text = "Perioodi lõpp aeg ei saa olla enne" +
                    Environment.NewLine +
                    "perioodi algus aega või sama."
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
                lblError.Text = "Valige periood!"
                Exit Sub
        End Select
        If periood = 0 Then
            While Index < GInfo.Count And Index < GInfo2.Count
                If Index >= cboxAlgus.SelectedIndex And Index <= cboxLopp.SelectedIndex Then
                    Graafik1.setPoint1(GInfo.Item(Index).Xval, GInfo.Item(Index).Yval)
                    Graafik1.setPoint2(GInfo2.Item(Index).Xval, GInfo2.Item(Index).Yval)
                    GInfo1Kesk += GInfo.Item(Index).Yval
                    GInfo2Kesk += GInfo2.Item(Index).Yval
                    If GInfo1Korge < GInfo.Item(Index).Yval Then
                        GInfo1Korge = Math.Round(GInfo.Item(Index).Yval, 2)
                        kellaaegKorge = GInfo.Item(Index).Xval
                    End If
                    If GInfo1Madal > GInfo.Item(Index).Yval Then
                        GInfo1Madal = Math.Round(GInfo.Item(Index).Yval, 2)
                        kellaaegMadal = GInfo.Item(Index).Xval
                    End If
                    If GInfo.Item(Index).Yval > GInfo2.Item(Index).Yval Then
                        ajaperioodKallim += 1
                    End If
                    ajavahemik += 1
                End If
                Index += 1
            End While
        Else
            While Index < GInfo.Count And Index < GInfo2.Count
                Graafik1.setPoint1(GInfo.Item(Index).Xval, GInfo.Item(Index).Yval)
                Graafik1.setPoint2(GInfo2.Item(Index).Xval, GInfo2.Item(Index).Yval)
                GInfo1Kesk += GInfo.Item(Index).Yval
                GInfo2Kesk += GInfo2.Item(Index).Yval
                If GInfo1Korge < GInfo.Item(Index).Yval Then
                    GInfo1Korge = Math.Round(GInfo.Item(Index).Yval, 2)
                    kellaaegKorge = GInfo.Item(Index).Xval
                End If
                If GInfo1Madal > GInfo.Item(Index).Yval Then
                    GInfo1Madal = Math.Round(GInfo.Item(Index).Yval, 2)
                    kellaaegMadal = GInfo.Item(Index).Xval
                End If
                If GInfo.Item(Index).Yval > GInfo2.Item(Index).Yval Then
                    ajaperioodKallim += 1
                End If
                Index += 1
            End While
        End If
        If periood = 0 Then
            GInfo1Kesk /= ajavahemik
            GInfo2Kesk /= ajavahemik
        Else
            GInfo1Kesk /= GInfo.Count
            GInfo2Kesk /= GInfo2.Count
        End If
        ajaperioodKallim = Math.Round((ajaperioodKallim / GInfo.Count) * 100, 2)
        ajaperioodOdavam = Math.Round(100 - ajaperioodKallim, 2)

        lblKeskHindB.Text = Math.Round(GInfo1Kesk, 2)
        lblKeskHindB.Text += " s/kWh"
        lblKeskHindF.Text = Math.Round(GInfo2Kesk, 2)
        lblKeskHindF.Text += " s/kWh"
        If GInfo1Kesk < GInfo2Kesk Then
            lblKeskHindB.BackColor = Color.Green
            lblKeskHindF.BackColor = Color.Red
        ElseIf GInfo1Kesk > GInfo2Kesk Then
            lblKeskHindB.BackColor = Color.Red
            lblKeskHindF.BackColor = Color.Green
        End If
        lblKorgePeriood.Text = kellaaegKorge
        lblKorgeHind.Text = GInfo1Korge
        lblKorgeHind.Text += " s/kWh"
        lblMadalPeriood.Text = kellaaegMadal
        lblMadalHind.Text = GInfo1Madal
        lblMadalHind.Text += " s/kWh"
        lblKorgeHind.BackColor = Color.Red
        lblMadalHind.BackColor = Color.Green
        lblProtsentKallim.Text = ajaperioodKallim
        lblProtsentKallim.Text += " s/kWh"
        lblProtsentOdavam.Text = ajaperioodOdavam
        lblProtsentOdavam.Text += " s/kWh"
        lblProtsentKallim.BackColor = Color.Red
        lblProtsentOdavam.BackColor = Color.Green
        lblError.Visible = False
    End Sub
    Private Sub joonistaGraafikBU(pktTypeB As IAndmebaas.PaketiTyyp, pktTypeU As IAndmebaas.PaketiTyyp, AegAlgus As Integer, AegLopp As Integer)
        Dim GInfo As List(Of (Xval As String, Yval As Decimal))
        Dim GInfo2 As List(Of (Xval As String, Yval As Decimal))
        Dim GetInfo As GraafikControl.IGraafikInfo
        GetInfo = New GraafikControl.CGraafikInfo
        Dim Index As Integer = 0
        Dim StructTemp As New PrjAndmebaas.IAndmebaas.PkBors
        Dim StructTemp2 As New PrjAndmebaas.IAndmebaas.PkFix
        Dim StructTemp3 As New PrjAndmebaas.IAndmebaas.PkUniv
        Dim PktType As Integer
        Dim Sum1 As Decimal
        Dim Sum2 As Decimal
        lblError2.Visible = True

        If cboxAlgus2.SelectedIndex >= cboxLopp2.SelectedIndex Then
            lblError2.Text = "Perioodi lõpp aeg ei tohi olla" +
                Environment.NewLine +
                "enne perioodi algus aega või sama."
            Exit Sub
        End If

        PktType = -1
        For Index = 0 To Paketid.Count - 1 'loop selleks et leida cboxPakett1 valitud paketti indexi listist
            If Paketid(Index).ID <> Nothing Then
                If cboxPakett.Text = Paketid(Index).Nimi Then
                    PktType = Paketid(Index).Tyyp
                    Exit For
                End If
            End If
        Next

        If PktType <> -1 Then
            Select Case PktType
                Case 0
                    StructTemp = ConnectDb.LoePakettBors(Paketid(Index).ID) 'Leitud indexiga paketi salvestatakse(olenevalt paketti tüübist) struckti ID, NIMI, JUURDETASU ja KUUTASU
                    GInfo = GetInfo.GetPaev(StructTemp.ID, PktType)
                    GInfo2 = GetInfo.GetPaev(StructUniv.ID, pktTypeU)
                Case 1
                    StructTemp2 = ConnectDb.LoePakettFix(Paketid(Index).ID)
                    GInfo = GetInfo.GetPaev(StructTemp2.ID, PktType)
                    GInfo2 = GetInfo.GetPaev(StructUniv.ID, pktTypeU)
                Case 2
                    StructTemp3 = ConnectDb.LoePakettUniv(Paketid(Index).ID)
                    GInfo = GetInfo.GetPaev(StructTemp3.ID, PktType)
                    GInfo2 = GetInfo.GetPaev(StructUniv.ID, pktTypeU)
            End Select
        Else
            If cboxAlgus2.SelectedIndex <> -1 And cboxLopp2.SelectedIndex <> -1 Then
                GInfo = GetInfo.GetPaev(StructBors.ID, pktTypeB)
                GInfo2 = GetInfo.GetPaev(StructUniv.ID, pktTypeU)
            Else
                lblError2.Text = "Valige perioodi algus ja lopp ajad ja/või pakett!"
                Exit Sub
            End If
        End If
        Index = 0
        While Index < GInfo.Count And Index < GInfo2.Count
            If Index >= cboxAlgus2.SelectedIndex And Index <= cboxLopp2.SelectedIndex Then
                Graafik1.setPoint1(GInfo.Item(Index).Xval, GInfo.Item(Index).Yval)
                Graafik1.setPoint2(GInfo2.Item(Index).Xval, GInfo2.Item(Index).Yval)
                Sum1 += GInfo.Item(Index).Yval
                Sum2 += GInfo2.Item(Index).Yval
            End If
            Index += 1
        End While
        lblError2.Visible = False
        lblKoguSum1.Text = Math.Round(Sum1)
        lblKoguSum1.Text += " s/kWh"
        lblKoguSum2.Text = Math.Round(Sum2)
        lblKoguSum2.Text += " s/kWh"
        If Sum1 < Sum2 Then
            lblKoguSum1.BackColor = Color.Green
            lblKoguSum2.BackColor = Color.Red
        Else
            lblKoguSum1.BackColor = Color.Red
            lblKoguSum2.BackColor = Color.Green
        End If
        lblKoguSum1.Visible = True
        lblKoguSum2.Visible = True
    End Sub
    'Börsi- ja fikseeritud hinna võrdlus graafikul
    Private Sub btnArvuta_Click(sender As Object, e As EventArgs) Handles btnArvuta.Click
        Me.StructBors.Nimi = "Temp"
        Me.StructBors.Juurdetasu = 0
        Me.StructBors.Kuutasu = 0
        Me.StructFix.Nimi = "Temp"
        Me.StructFix.PTariif = CDec(Val(txtFixP.Text))
        Me.StructFix.OTariif = CDec(Val(txtFixO.Text))
        Me.StructFix.Kuutasu = 0
        Dim nimekiri As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
        Dim pktTypeB As IAndmebaas.PaketiTyyp
        Dim pktTypeF As IAndmebaas.PaketiTyyp
        Dim index As Integer
        Dim I As Integer
        Dim periood As Integer

        Graafik1.ClearPoints()

        If Not IsNumeric(txtFixP.Text) Or Not IsNumeric(txtFixO.Text) Then
            lblError.Visible = True
            lblError.Text = "Sisestage päeva ja öö tariifid" +
                Environment.NewLine +
                "(ainult nubritena)."
            Exit Sub
        End If

        ConnectDb.LisaPakettBors(StructBors.Nimi, StructBors.Juurdetasu, StructBors.Kuutasu)
        ConnectDb.LisaPakettFix(StructFix.Nimi, StructFix.PTariif, StructFix.OTariif, StructFix.Kuutasu)
        nimekiri = ConnectDb.LoePakettideNimekiri()
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
        periood = cBoxPeriood.SelectedIndex
        joonistaGraafikBF(pktTypeB, pktTypeF, periood)
        ConnectDb.KustutaPakettBors(StructBors.ID)
        ConnectDb.KustutaPakettFix(StructFix.ID)
    End Sub
    'börsi ja univ pakettide võrdlus
    Private Sub btnArvuta2_Click(sender As Object, e As EventArgs) Handles btnArvuta2.Click
        Me.StructBors.Nimi = "Temp"
        Me.StructBors.Juurdetasu = 0
        Me.StructBors.Kuutasu = 0
        Me.StructUniv.Nimi = "Temp"
        Me.StructUniv.Baas = CDec(Val(txtBaas.Text))
        Me.StructUniv.Marginaal = 0
        Me.StructUniv.Kuutasu = 0
        Dim pktTypeB As IAndmebaas.PaketiTyyp
        Dim pktTypeU As IAndmebaas.PaketiTyyp
        Dim index As Integer
        Dim I As Integer
        Dim nimekiri As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
        Dim AegAlgus As Integer
        Dim AegLopp As Integer
        Graafik1.ClearPoints()

        If Not IsNumeric(txtBaas.Text) Then
            lblError2.Visible = True
            lblError2.Text = "Sisestage baas hind (ainult numbrina)."
            Exit Sub
        End If

        ConnectDb.LisaPakettBors(StructBors.Nimi, StructBors.Juurdetasu, StructBors.Kuutasu)
        ConnectDb.LisaPakettUniv(StructUniv.Nimi, StructUniv.Baas, StructUniv.Marginaal, StructUniv.Kuutasu)
        nimekiri = ConnectDb.LoePakettideNimekiri()
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
        AegAlgus = cboxAlgus2.SelectedIndex
        AegLopp = cboxLopp2.SelectedIndex
        joonistaGraafikBU(pktTypeB, pktTypeU, AegAlgus, AegLopp)
        ConnectDb.KustutaPakettBors(StructBors.ID)
        ConnectDb.KustutaPakettUniv(StructUniv.ID)
    End Sub
End Class