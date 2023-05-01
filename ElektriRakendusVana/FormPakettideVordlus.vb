﻿Imports System.Net.Security
Imports PrjAndmebaas
Imports GraafikControl
Public Class FormPakettideVordlus
    'FAILINIMI: FormPakettideVordlus.vb
    'AUTOR: Carl Strömberg
    'LOODUD: 05.04.2023
    'MUUDETUD: 01.05.2023
    '
    'KIRJELDUS: See klass on loodud kui formina UserStoryde US004 ja US017 jaoks.
    '           See klass võrdleb börsi ja fikseeritud hindasid ning kuvab
    '           võrdluse tulemust kasutajale. Samuti võrdleb klass börsi hinda,
    '           universaalteenuse hinda(ilma marginaalita) ja kasutajalt valitud
    '           paketi hinda ja kuvab kasutajale võrdluse tulemused.

    'EELTINGIMUSED: On olemas ühendus andmebaasiga ja andmebaasist on loetud kõik olevad paketid.
    '
    Dim Paketid As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
    ReadOnly ConnectDb As New CAndmebaas
    Public StructBors As New PrjAndmebaas.IAndmebaas.PkBors
    Public StructFix As New PrjAndmebaas.IAndmebaas.PkFix
    Public StructUniv As New PrjAndmebaas.IAndmebaas.PkUniv

    'Muudab konkreetsed Label-id ja ComboBox-id nähtamatuks kasutajale
    'Sisendparameetrid: -
    Private Sub LabelInvis()
        cboxAlgus.Visible = False
        cboxLopp.Visible = False
        lblAlgus.Visible = False
        lblLopp.Visible = False
        cboxAlgus2.Visible = False
        cboxLopp2.Visible = False
        lblAlgus2.Visible = False
        lblLopp2.Visible = False
        lblKoguSum1.Visible = False
        lblKoguSum2.Visible = False
        lblKoguSum3.Visible = False
    End Sub

    'Formi load sub. Laeb ComboBox-i andmebaasis olevad paketid. 
    'Sisendparameetrid:
    '   sender: Object
    '   e: Event arguments
    Private Sub FormPakettideVordlus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Index As Integer

        'Kustutab ComboBox-ist kõik itemid
        cboxPakett.Items.Clear()

        'Laeb kõik paketid andmebaasist lisit
        'Funktsioon LoePakettideNimekiri võetud CAndmebaas.vb-st
        Paketid = ConnectDb.LoePakettideNimekiri

        'Laeb kõik listis olevad paketid ComboBox-i
        For Index = 0 To Paketid.Count - 1
            cboxPakett.Items.Add(Paketid(Index).Nimi)
        Next

        'Konkreetsed labelid nähtamatuks
        LabelInvis()
    End Sub

    'Börsi ja fix hinna võrdluses ajavahemiku ComboBox-id ja Label-ite
    'nähtavuse muutmine.
    'Sisendparameetrid:
    '   sender: Object
    '   e: Event arguments
    Private Sub cBoxPeriood_DropDownClosed(sender As Object, e As EventArgs) Handles cBoxPeriood.DropDownClosed

        'Select Case perioodi ComboBox-i jaoks
        Select Case cBoxPeriood.SelectedIndex

            'Kui on valitud ComboBox-ist "tund"
            Case 0
                cboxAlgus.Visible = True
                cboxLopp.Visible = True
                lblAlgus.Visible = True
                lblLopp.Visible = True

                'Kui ComboBox-ist ei ole valitud "tund"
            Case Else
                cboxAlgus.Visible = False
                cboxLopp.Visible = False
                lblAlgus.Visible = False
                lblLopp.Visible = False
        End Select
    End Sub

    'Börsi ja univ hinna võrdluses ajavahemiku ComboBox-id ja Label-ite
    'nähtavuse muutmine.
    'Sisendparameetrid:
    '   sender: Object
    '   e: Event arguments
    Private Sub cboxPeriood2_DropDownClosed(sender As Object, e As EventArgs) Handles cBoxPeriood2.DropDownClosed

        'Select Case perioodi ComboBox-i jaoks
        Select Case cBoxPeriood2.SelectedIndex

            'Kui on valitud ComboBox-ist "tund"
            Case 0
                cboxAlgus2.Visible = True
                cboxLopp2.Visible = True
                lblAlgus2.Visible = True
                lblLopp2.Visible = True

                'Kui ei ole valitud ComboBox-ist "tund"
            Case Else
                cboxAlgus2.Visible = False
                cboxLopp2.Visible = False
                lblAlgus2.Visible = False
                lblLopp2.Visible = False
        End Select
    End Sub

    'Joonistab börsi ja fix hinnad graafikule ning kuvab võrdluse tulemused kasutajale.
    'Sisendparameetrid:
    '   pktTypeB: Paketi tüüp börss
    '   pktTypeF: Paketi tüüp fix
    '   periood: Perioodi ComboBox-ist valitud periood (tund, päev, kuu, aasta)
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

        'Konkreetsed labelid nähtamatuks
        LabelInvis()

        'Select Case perioodi ComboBox-i jaoks
        Select Case periood

            'ComboBox-ist valitud "tund"
            Case 0

                'If lause, et kontrolliga kas ajavahemik on valitud
                If cboxAlgus.SelectedIndex = -1 And cboxLopp.SelectedIndex = -1 Then
                    MsgBox("Valige perioodi algus ja lopp ajad")
                    Exit Sub
                End If

                'kontroll selleks, et ajavahemik oleks õigesti valitud.
                'Ajavahemiku algus aeg ei oleks hiljem kui lopp aeg.
                If cboxAlgus.SelectedIndex >= cboxLopp.SelectedIndex Then
                    MsgBox("Perioodi lõpp aeg ei saa olla enne" +
                    Environment.NewLine +
                    "perioodi algus aega või sama.")
                    Exit Sub
                End If

                'GInfo-sse salvestatakse börsi hinnad ja nendele vastavad ajad
                'GInfo2-te salvestatakse fix hinnad ja nendele vastavad ajad
                'Funktioon GetPaev on võetud CGraafikInfo.vb-st
                GInfo = GetInfo.GetPaev(StructBors.ID, pktTypeB)
                GInfo2 = GetInfo.GetPaev(StructFix.ID, pktTypeF)

                'ComboBox-ist valitud "päev"
            Case 1

                'GInfo-sse salvestatakse börsi hinnad ja nendele vastavad ajad
                'GInfo2-te salvestatakse fix hinnad ja nendele vastavad ajad
                'Funktioon GetPaev on võetud CGraafikInfo.vb-st
                GInfo = GetInfo.GetPaev(StructBors.ID, pktTypeB)
                GInfo2 = GetInfo.GetPaev(StructFix.ID, pktTypeF)

                'ComboBox-ist valitud "kuu"
            Case 2

                'GInfo-sse salvestatakse börsi hinnad ja nendele vastavad ajad
                'GInfo2-te salvestatakse fix hinnad ja nendele vastavad ajad
                'Funktioon GetKuu on võetud CGraafikInfo.vb-st
                GInfo = GetInfo.GetKuu(StructBors.ID, pktTypeB)
                GInfo2 = GetInfo.GetKuu(StructFix.ID, pktTypeF)

                'ComboBox-ist valitud "aasta"
            Case 3

                'GInfo-sse salvestatakse börsi hinnad ja nendele vastavad ajad
                'GInfo2-te salvestatakse fix hinnad ja nendele vastavad ajad
                'Funktioon GetAasta on võetud CGraafikInfo.vb-st
                GInfo = GetInfo.GetAasta(StructBors.ID, pktTypeB)
                GInfo2 = GetInfo.GetAasta(StructFix.ID, pktTypeF)

                'Pole midagi ComboBox-ist valitud
            Case Else
                MsgBox("Valige periood!")
                Exit Sub
        End Select

        'kontroll selleks, et leida kas perioodi ComboBox-ist on valitud "tund"
        If periood = 0 Then

            'tsükkel, mis ei ületa ajavahemiku aegade arvu 
            While Index < GInfo.Count And Index < GInfo2.Count

                'kontroll selleks, et leida kas index asub ajavahemiku vahel
                If Index >= cboxAlgus.SelectedIndex And Index <= cboxLopp.SelectedIndex Then

                    'Graafikule joonistatakse börsi ja fix hinnad vastavatele kellaaegadele
                    'funktsioonid setPoint1 ja setPoint2 võetud Graafik.vb-st
                    Graafik1.setPoint1(GInfo.Item(Index).Xval, GInfo.Item(Index).Yval)
                    Graafik1.setPoint2(GInfo2.Item(Index).Xval, GInfo2.Item(Index).Yval)

                    'keskmise hinna muutujatele hinna lisamine
                    GInfo1Kesk += GInfo.Item(Index).Yval
                    GInfo2Kesk += GInfo2.Item(Index).Yval

                    'kontroll et leida, mis kell on börsi hind kõrgeim
                    If GInfo1Korge < GInfo.Item(Index).Yval Then
                        GInfo1Korge = Math.Round(GInfo.Item(Index).Yval, 2)
                        kellaaegKorge = GInfo.Item(Index).Xval
                    End If

                    'kontroll et leida, mis kell on bärsi hind madalaim
                    If GInfo1Madal > GInfo.Item(Index).Yval Then
                        GInfo1Madal = Math.Round(GInfo.Item(Index).Yval, 2)
                        kellaaegMadal = GInfo.Item(Index).Xval
                    End If

                    'kontroll et leida, mitu tundi on börsi hind kallim kui fix hind
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
        lblProtsentKallim.Text += "%"
        lblProtsentOdavam.Text = ajaperioodOdavam
        lblProtsentOdavam.Text += "%"
        lblProtsentKallim.BackColor = Color.Red
        lblProtsentOdavam.BackColor = Color.Green
    End Sub
    Private Sub joonistaGraafikBU(pktTypeB As IAndmebaas.PaketiTyyp, pktTypeU As IAndmebaas.PaketiTyyp, periood As Integer, AegAlgus As Integer, AegLopp As Integer)
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
            MsgBox("Sisestage päeva ja öö tariifid" +
                Environment.NewLine +
                "(ainult nubritena).")
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
End Class