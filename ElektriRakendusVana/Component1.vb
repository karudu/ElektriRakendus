Imports PrjAndmebaas
Imports GraafikControl
Imports PakettideVordlus
Public Class Component1
    Implements Interface1

    Dim Paketid As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
    ReadOnly ConnectDb As New CAndmebaas
    Public StructBors As New PrjAndmebaas.IAndmebaas.PkBors
    Public StructFix As New PrjAndmebaas.IAndmebaas.PkFix
    Public StructUniv As New PrjAndmebaas.IAndmebaas.PkUniv
    Public Sub LabelInvis() Implements Interface1.LabelInvis
        'cboxAlgus.Visible = False
        'cboxLopp.Visible = False
        'lblAlgus.Visible = False
        'lblLopp.Visible = False
        cboxAlgus2.Visible = False
        cboxLopp2.Visible = False
        lblAlgus2.Visible = False
        lblLopp2.Visible = False
        lblKoguSum1.Visible = False
        lblKoguSum2.Visible = False
        lblKoguSum3.Visible = False
    End Sub
    Public Sub btnArvuta2_Click(sender As Object, e As EventArgs) Implements Interface1.btnArvuta2_Click
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
        Dim periood As Integer
        Graafik1.ClearPoints()

        If Not IsNumeric(txtBaas.Text) Then
            MsgBox("Sisestage baas hind (ainult numbrina).")
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
        periood = cBoxPeriood2.SelectedIndex
        joonistaGraafikBU(pktTypeB, pktTypeU, periood, AegAlgus, AegLopp)
        ConnectDb.KustutaPakettBors(StructBors.ID)
        ConnectDb.KustutaPakettUniv(StructUniv.ID)
    End Sub

    Public Sub joonistaGraafikBU(pktTypeB As IAndmebaas.PaketiTyyp, pktTypeU As IAndmebaas.PaketiTyyp, periood As Integer, AegAlgus As Integer, AegLopp As Integer) Implements Interface1.joonistaGraafikBU
        Dim GInfo As List(Of (Xval As String, Yval As Decimal))
        Dim GInfo2 As List(Of (Xval As String, Yval As Decimal))
        Dim Ginfo3 As List(Of (Xval As String, Yval As Decimal))
        Dim GetInfo As GraafikControl.IGraafikInfo
        GetInfo = New GraafikControl.CGraafikInfo
        Dim Index As Integer
        Dim Index2 As Integer
        Dim StructTemp As New PrjAndmebaas.IAndmebaas.PkBors
        Dim StructTemp2 As New PrjAndmebaas.IAndmebaas.PkFix
        Dim StructTemp3 As New PrjAndmebaas.IAndmebaas.PkUniv
        Dim PktType As Integer
        Dim Sum1 As Decimal
        Dim Sum2 As Decimal
        Dim Sum3 As Decimal

        LabelInvis()
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
            Select Case periood
                Case 0
                    If AegAlgus = -1 And AegLopp = -1 Then
                        MsgBox("Valige perioodi algus ja lopp ajad")
                        Exit Sub
                    End If
                    If AegAlgus >= AegLopp Then
                        MsgBox("Perioodi lõpp aeg ei saa olla enne" +
                        Environment.NewLine +
                        "perioodi algus aega või sama.")
                        Exit Sub
                    End If
                    Select Case PktType
                        Case 0
                            StructTemp = ConnectDb.LoePakettBors(Paketid(Index).ID) 'Leitud indexiga paketi salvestatakse(olenevalt paketti tüübist) struckti ID, NIMI, JUURDETASU ja KUUTASU
                            GInfo = GetInfo.GetPaev(StructTemp.ID, PktType)
                            GInfo2 = GetInfo.GetPaev(StructUniv.ID, pktTypeU)
                            Ginfo3 = GetInfo.GetPaev(StructBors.ID, pktTypeB)
                        Case 1
                            StructTemp2 = ConnectDb.LoePakettFix(Paketid(Index).ID)
                            GInfo = GetInfo.GetPaev(StructTemp2.ID, PktType)
                            GInfo2 = GetInfo.GetPaev(StructUniv.ID, pktTypeU)
                            Ginfo3 = GetInfo.GetPaev(StructBors.ID, pktTypeB)
                        Case 2
                            StructTemp3 = ConnectDb.LoePakettUniv(Paketid(Index).ID)
                            GInfo = GetInfo.GetPaev(StructTemp3.ID, PktType)
                            GInfo2 = GetInfo.GetPaev(StructUniv.ID, pktTypeU)
                            Ginfo3 = GetInfo.GetPaev(StructBors.ID, pktTypeB)
                    End Select
                Case 1
                    Select Case PktType
                        Case 0
                            StructTemp = ConnectDb.LoePakettBors(Paketid(Index).ID) 'Leitud indexiga paketi salvestatakse(olenevalt paketti tüübist) struckti ID, NIMI, JUURDETASU ja KUUTASU
                            GInfo = GetInfo.GetPaev(StructTemp.ID, PktType)
                            GInfo2 = GetInfo.GetPaev(StructUniv.ID, pktTypeU)
                            Ginfo3 = GetInfo.GetPaev(StructBors.ID, pktTypeB)
                        Case 1
                            StructTemp2 = ConnectDb.LoePakettFix(Paketid(Index).ID)
                            GInfo = GetInfo.GetPaev(StructTemp2.ID, PktType)
                            GInfo2 = GetInfo.GetPaev(StructUniv.ID, pktTypeU)
                            Ginfo3 = GetInfo.GetPaev(StructBors.ID, pktTypeB)
                        Case 2
                            StructTemp3 = ConnectDb.LoePakettUniv(Paketid(Index).ID)
                            GInfo = GetInfo.GetPaev(StructTemp3.ID, PktType)
                            GInfo2 = GetInfo.GetPaev(StructUniv.ID, pktTypeU)
                            Ginfo3 = GetInfo.GetPaev(StructBors.ID, pktTypeB)
                    End Select
                Case 2
                    Select Case PktType
                        Case 0
                            StructTemp = ConnectDb.LoePakettBors(Paketid(Index).ID) 'Leitud indexiga paketi salvestatakse(olenevalt paketti tüübist) struckti ID, NIMI, JUURDETASU ja KUUTASU
                            GInfo = GetInfo.GetKuu(StructTemp.ID, PktType)
                            GInfo2 = GetInfo.GetKuu(StructUniv.ID, pktTypeU)
                            Ginfo3 = GetInfo.GetKuu(StructBors.ID, pktTypeB)
                        Case 1
                            StructTemp2 = ConnectDb.LoePakettFix(Paketid(Index).ID)
                            GInfo = GetInfo.GetKuu(StructTemp2.ID, PktType)
                            GInfo2 = GetInfo.GetKuu(StructUniv.ID, pktTypeU)
                            Ginfo3 = GetInfo.GetKuu(StructBors.ID, pktTypeB)
                        Case 2
                            StructTemp3 = ConnectDb.LoePakettUniv(Paketid(Index).ID)
                            GInfo = GetInfo.GetKuu(StructTemp3.ID, PktType)
                            GInfo2 = GetInfo.GetKuu(StructUniv.ID, pktTypeU)
                            Ginfo3 = GetInfo.GetKuu(StructBors.ID, pktTypeB)
                    End Select
                Case 3
                    Select Case PktType
                        Case 0
                            StructTemp = ConnectDb.LoePakettBors(Paketid(Index).ID) 'Leitud indexiga paketi salvestatakse(olenevalt paketti tüübist) struckti ID, NIMI, JUURDETASU ja KUUTASU
                            GInfo = GetInfo.GetAasta(StructTemp.ID, PktType)
                            GInfo2 = GetInfo.GetAasta(StructUniv.ID, pktTypeU)
                            Ginfo3 = GetInfo.GetAasta(StructBors.ID, pktTypeB)
                        Case 1
                            StructTemp2 = ConnectDb.LoePakettFix(Paketid(Index).ID)
                            GInfo = GetInfo.GetAasta(StructTemp2.ID, PktType)
                            GInfo2 = GetInfo.GetAasta(StructUniv.ID, pktTypeU)
                            Ginfo3 = GetInfo.GetAasta(StructBors.ID, pktTypeB)
                        Case 2
                            StructTemp3 = ConnectDb.LoePakettUniv(Paketid(Index).ID)
                            GInfo = GetInfo.GetAasta(StructTemp3.ID, PktType)
                            GInfo2 = GetInfo.GetAasta(StructUniv.ID, pktTypeU)
                            Ginfo3 = GetInfo.GetAasta(StructBors.ID, pktTypeB)
                    End Select
                Case Else
                    MsgBox("Valige periood!")
                    Exit Sub
            End Select
        Else
            MsgBox("Valige pakett!")
            Exit Sub
        End If
        Index2 = Index
        Index = 0
        If periood = 0 Then
            While Index < GInfo.Count And Index < GInfo2.Count And Index < Ginfo3.Count
                If Index >= AegAlgus And Index <= AegLopp Then
                    Graafik1.setPoint1(GInfo.Item(Index).Xval, GInfo.Item(Index).Yval)
                    Graafik1.setPoint2(GInfo2.Item(Index).Xval, GInfo2.Item(Index).Yval)
                    Graafik1.setPoint3(Ginfo3.Item(Index).Xval, Ginfo3.Item(Index).Yval)
                    Sum1 += GInfo.Item(Index).Yval
                    Sum2 += GInfo2.Item(Index).Yval
                    Sum3 += Ginfo3.Item(Index).Yval
                End If
                Index += 1
            End While
        Else
            While Index < GInfo.Count And Index < GInfo2.Count And Index < Ginfo3.Count
                Graafik1.setPoint1(GInfo.Item(Index).Xval, GInfo.Item(Index).Yval)
                Graafik1.setPoint2(GInfo2.Item(Index).Xval, GInfo2.Item(Index).Yval)
                Graafik1.setPoint3(Ginfo3.Item(Index).Xval, Ginfo3.Item(Index).Yval)
                Sum1 += GInfo.Item(Index).Yval
                Sum2 += GInfo2.Item(Index).Yval
                Sum3 += Ginfo3.Item(Index).Yval
                Index += 1
            End While
        End If
        lblKoguSum1.Text = Math.Round(Sum1)
        lblKoguSum1.Text += " s/kWh"
        lblKoguSum2.Text = Math.Round(Sum2)
        lblKoguSum2.Text += " s/kWh"
        lblKoguSum3.Text = Math.Round(Sum3)
        lblKoguSum3.Text += " s/kWh"
        If Sum1 < Sum2 Then
            lblKoguSum1.BackColor = Color.Green
            lblKoguSum2.BackColor = Color.Red
            If Sum1 < Sum3 Then
                lblKoguSum1.BackColor = Color.Green
                lblKoguSum3.BackColor = Color.Red
            Else
                lblKoguSum1.BackColor = Color.Red
                lblKoguSum3.BackColor = Color.Green
            End If
        Else
            lblKoguSum1.BackColor = Color.Red
            lblKoguSum2.BackColor = Color.Green
            If Sum2 < Sum3 Then
                lblKoguSum2.BackColor = Color.Green
                lblKoguSum3.BackColor = Color.Red
            Else
                lblKoguSum2.BackColor = Color.Red
                lblKoguSum3.BackColor = Color.Green
            End If
        End If
        lblKoguSum1.Visible = True
        lblKoguSum2.Visible = True
        lblKoguSum3.Visible = True
    End Sub
End Class
