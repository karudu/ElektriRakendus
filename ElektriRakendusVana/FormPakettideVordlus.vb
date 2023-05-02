Imports System.Net.Security
Imports PrjAndmebaas
Imports GraafikControl
Public Class FormPakettideVordlus
    'FAILINIMI: FormPakettideVordlus.vb
    'AUTOR: Carl Strömberg
    'LOODUD: 05.04.2023
    'MUUDETUD: 02.05.2023
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

                'Pole mitte midagi ComboBox-ist valitud
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

            'Kui ComboBoxist on valitud midagi muud peale "tund"
        Else

            'tsükkel, mis ei ületa ajavahemiku aegade arvu 
            While Index < GInfo.Count And Index < GInfo2.Count

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

                'kontroll et leida, mis kell on börsi hind madalaim
                If GInfo1Madal > GInfo.Item(Index).Yval Then
                    GInfo1Madal = Math.Round(GInfo.Item(Index).Yval, 2)
                    kellaaegMadal = GInfo.Item(Index).Xval
                End If

                'kontroll et leida, mitu tundi on börsi hind kallim kui fix hind
                If GInfo.Item(Index).Yval > GInfo2.Item(Index).Yval Then
                    ajaperioodKallim += 1
                End If

                Index += 1

            End While
        End If

        'Börsi ja fikseeritud keskmiste hindade arvutamine
        'Kui perioodi ComboBox-is valitud "tund"
        If periood = 0 Then
            GInfo1Kesk /= ajavahemik
            GInfo2Kesk /= ajavahemik
            'Kui perioodi ComboBox-is valitud "päev", "kuu", "aasta"
        Else
            GInfo1Kesk /= GInfo.Count
            GInfo2Kesk /= GInfo2.Count
        End If

        'Ajaperiood millal börsi hind on fix hinnast kallim arvutamine (protsentides)
        'ja Label-itele väätsuste omistamine
        ajaperioodKallim = Math.Round((ajaperioodKallim / GInfo.Count) * 100, 2)
        ajaperioodOdavam = Math.Round(100 - ajaperioodKallim, 2)
        lblKeskHindB.Text = Math.Round(GInfo1Kesk, 2)
        lblKeskHindB.Text += " s/kWh"
        lblKeskHindF.Text = Math.Round(GInfo2Kesk, 2)
        lblKeskHindF.Text += " s/kWh"

        'Keskmiste hindade Label-ite värvimine
        'Kui börsi hind odavam
        If GInfo1Kesk < GInfo2Kesk Then

            lblKeskHindB.BackColor = Color.Green
            lblKeskHindF.BackColor = Color.Red

            'Kui fix hind odavam
        ElseIf GInfo1Kesk > GInfo2Kesk Then

            lblKeskHindB.BackColor = Color.Red
            lblKeskHindF.BackColor = Color.Green

        End If

        'Label-itele väärtuste omistamine ja värvimine
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

    'Joonistab valitud paketi, börsi ja univ hinnad graafikule ning kuvab võrdluse tulemused kasutajale.
    'Sisendparameetrid:
    '   pktTypeB: Paketi tüüp börss
    '   pktTypeF: Paketi tüüp fix
    '   periood: Perioodi ComboBox-ist valitud periood (tund, päev, kuu, aasta)
    '   AegAlgus: Algus aja CoboBox-ist valitud graafiku esimene tund
    '   AegLopp: Lopp aja ComboBox-ist valitud graafiku viimane tund
    Private Sub joonistaGraafikBU(pktTypeB As IAndmebaas.PaketiTyyp, pktTypeU As IAndmebaas.PaketiTyyp, periood As Integer, AegAlgus As Integer, AegLopp As Integer)
        Dim GInfo As List(Of (Xval As String, Yval As Decimal))
        Dim GInfo2 As List(Of (Xval As String, Yval As Decimal))
        Dim Ginfo3 As List(Of (Xval As String, Yval As Decimal))
        Dim GetInfo As GraafikControl.IGraafikInfo
        GetInfo = New GraafikControl.CGraafikInfo
        Dim Index As Integer
        Dim StructTemp As New PrjAndmebaas.IAndmebaas.PkBors
        Dim StructTemp2 As New PrjAndmebaas.IAndmebaas.PkFix
        Dim StructTemp3 As New PrjAndmebaas.IAndmebaas.PkUniv
        Dim PktType As Integer = -1
        Dim Sum1 As Decimal
        Dim Sum2 As Decimal
        Dim Sum3 As Decimal

        'Konkreetsed labelid nähtamatuks
        LabelInvis()

        'Tsükkel selleks, et leida valitud paketi paketi tüüpi
        For Index = 0 To Paketid.Count - 1
            If Paketid(Index).ID <> Nothing Then
                If cboxPakett.Text = Paketid(Index).Nimi Then
                    PktType = Paketid(Index).Tyyp
                    Exit For
                End If
            End If
        Next

        'Kontroll, kas võrreldav pakett on ComboBox-ist valitud
        If PktType <> -1 Then

            'Select Case perioodi ComboBox-i jaoks
            Select Case periood

                'ComboBox-ist valitud "tund"
                Case 0

                    'kontroll, kas Algus ja Lõpp aja ComboBox-id on tühjad
                    If AegAlgus = -1 And AegLopp = -1 Then
                        MsgBox("Valige perioodi algus ja lopp ajad")
                        Exit Sub
                    End If

                    'kontroll, kas Algus aja ComboBox-i kellaaeg on suurem
                    'kui Lõpp aja ComboBox-i kellaaeg  
                    If AegAlgus >= AegLopp Then
                        MsgBox("Perioodi lõpp aeg ei saa olla enne" +
                        Environment.NewLine +
                        "perioodi algus aega või sama.")
                        Exit Sub
                    End If

                    'Select Case selleks, et leida millist tüüpi pakett kasutaja valis
                    Select Case PktType

                        'Paketi tüüp: Börss
                        Case 0

                            'Omistatakse valitud pakett StructTemp muutujasse ning
                            'valitud paketi, börsi ja univ hindade kellajad ja
                            'nendele vastavad hinnad salvestatakse listidesse
                            'Funktsioon LoePakettBors võetud CAndmebaas.vb-st ja GetPaev võetud Graafik.vb-st
                            StructTemp = ConnectDb.LoePakettBors(Paketid(Index).ID)
                            GInfo = GetInfo.GetPaev(StructTemp.ID, PktType)
                            GInfo2 = GetInfo.GetPaev(StructUniv.ID, pktTypeU)
                            Ginfo3 = GetInfo.GetPaev(StructBors.ID, pktTypeB)

                            'Paketi tüüp: Fix
                        Case 1

                            'Omistatakse valitud pakett StructTemp2 muutujasse ning
                            'valitud paketi, börsi ja univ hindade kellajad ja
                            'nendele vastavad hinnad salvestatakse listidesse
                            'Funktsioon LoePakettFix võetud CAndmebaas.vb-st ja GetPaev võetud Graafik.vb-st
                            StructTemp2 = ConnectDb.LoePakettFix(Paketid(Index).ID)
                            GInfo = GetInfo.GetPaev(StructTemp2.ID, PktType)
                            GInfo2 = GetInfo.GetPaev(StructUniv.ID, pktTypeU)
                            Ginfo3 = GetInfo.GetPaev(StructBors.ID, pktTypeB)

                            'Paketi tüüp: Univ
                        Case 2

                            'Omistatakse valitud pakett StructTemp3 muutujasse ning
                            'valitud paketi, börsi ja univ hindade kellajad ja
                            'nendele vastavad hinnad salvestatakse listidesse
                            'Funktsioon LoePakettUniv võetud CAndmebaas.vb-st ja GetPaev võetud Graafik.vb-st
                            StructTemp3 = ConnectDb.LoePakettUniv(Paketid(Index).ID)
                            GInfo = GetInfo.GetPaev(StructTemp3.ID, PktType)
                            GInfo2 = GetInfo.GetPaev(StructUniv.ID, pktTypeU)
                            Ginfo3 = GetInfo.GetPaev(StructBors.ID, pktTypeB)
                    End Select

                    'ComboBox-ist valitud "paev"
                Case 1

                    'Select Case selleks, et leida millist tüüpi pakett kasutaja valis
                    Select Case PktType

                        'Paketi tüüp: Börss
                        Case 0

                            'Omistatakse valitud pakett StructTemp muutujasse ning
                            'valitud paketi, börsi ja univ hindade kellajad ja
                            'nendele vastavad hinnad salvestatakse listidesse
                            'Funktsioon LoePakettBors võetud CAndmebaas.vb-st ja GetPaev võetud Graafik.vb-st
                            StructTemp = ConnectDb.LoePakettBors(Paketid(Index).ID) 'Leitud indexiga paketi salvestatakse(olenevalt paketti tüübist) struckti ID, NIMI, JUURDETASU ja KUUTASU
                            GInfo = GetInfo.GetPaev(StructTemp.ID, PktType)
                            GInfo2 = GetInfo.GetPaev(StructUniv.ID, pktTypeU)
                            Ginfo3 = GetInfo.GetPaev(StructBors.ID, pktTypeB)

                            'Paketi tüüp: Fix
                        Case 1

                            'Omistatakse valitud pakett StructTemp2 muutujasse ning
                            'valitud paketi, börsi ja univ hindade kellajad ja
                            'nendele vastavad hinnad salvestatakse listidesse
                            'Funktsioon LoePakettFix võetud CAndmebaas.vb-st ja GetPaev võetud Graafik.vb-st
                            StructTemp2 = ConnectDb.LoePakettFix(Paketid(Index).ID)
                            GInfo = GetInfo.GetPaev(StructTemp2.ID, PktType)
                            GInfo2 = GetInfo.GetPaev(StructUniv.ID, pktTypeU)
                            Ginfo3 = GetInfo.GetPaev(StructBors.ID, pktTypeB)

                            'Paketi tüüp: Univ
                        Case 2

                            'Omistatakse valitud pakett StructTemp3 muutujasse ning
                            'valitud paketi, börsi ja univ hindade kellajad ja
                            'nendele vastavad hinnad salvestatakse listidesse
                            'Funktsioon LoePakettUniv võetud CAndmebaas.vb-st ja GetPaev võetud Graafik.vb-st
                            StructTemp3 = ConnectDb.LoePakettUniv(Paketid(Index).ID)
                            GInfo = GetInfo.GetPaev(StructTemp3.ID, PktType)
                            GInfo2 = GetInfo.GetPaev(StructUniv.ID, pktTypeU)
                            Ginfo3 = GetInfo.GetPaev(StructBors.ID, pktTypeB)

                    End Select

                    'ComboBox-ist valitud "kuu"
                Case 2

                    'Select Case selleks, et leida millist tüüpi pakett kasutaja valis
                    Select Case PktType

                        'Paketi tüüp: Börss
                        Case 0

                            'Omistatakse valitud pakett StructTemp muutujasse ning
                            'valitud paketi, börsi ja univ hindade kellajad ja
                            'nendele vastavad hinnad salvestatakse listidesse
                            'Funktsioon LoePakettBors võetud CAndmebaas.vb-st ja GetKuu võetud Graafik.vb-st
                            StructTemp = ConnectDb.LoePakettBors(Paketid(Index).ID) 'Leitud indexiga paketi salvestatakse(olenevalt paketti tüübist) struckti ID, NIMI, JUURDETASU ja KUUTASU
                            GInfo = GetInfo.GetKuu(StructTemp.ID, PktType)
                            GInfo2 = GetInfo.GetKuu(StructUniv.ID, pktTypeU)
                            Ginfo3 = GetInfo.GetKuu(StructBors.ID, pktTypeB)

                            'Paketi tüüp: Fix
                        Case 1

                            'Omistatakse valitud pakett StructTemp2 muutujasse ning
                            'valitud paketi, börsi ja univ hindade kellajad ja
                            'nendele vastavad hinnad salvestatakse listidesse
                            'Funktsioon LoePakettFix võetud CAndmebaas.vb-st ja GetKuu võetud Graafik.vb-st
                            StructTemp2 = ConnectDb.LoePakettFix(Paketid(Index).ID)
                            GInfo = GetInfo.GetKuu(StructTemp2.ID, PktType)
                            GInfo2 = GetInfo.GetKuu(StructUniv.ID, pktTypeU)
                            Ginfo3 = GetInfo.GetKuu(StructBors.ID, pktTypeB)

                            'Paketi tüüp: Univ
                        Case 2

                            'Omistatakse valitud pakett StructTemp3 muutujasse ning
                            'valitud paketi, börsi ja univ hindade kellajad ja
                            'nendele vastavad hinnad salvestatakse listidesse
                            'Funktsioon LoePakettUniv võetud CAndmebaas.vb-st ja GetKuu võetud Graafik.vb-st
                            StructTemp3 = ConnectDb.LoePakettUniv(Paketid(Index).ID)
                            GInfo = GetInfo.GetKuu(StructTemp3.ID, PktType)
                            GInfo2 = GetInfo.GetKuu(StructUniv.ID, pktTypeU)
                            Ginfo3 = GetInfo.GetKuu(StructBors.ID, pktTypeB)

                    End Select

                    'ComboBox-ist valitud "aasta"
                Case 3

                    'Select Case selleks, et leida millist tüüpi pakett kasutaja valis
                    Select Case PktType

                        'Paketi tüüp: Börss
                        Case 0

                            'Omistatakse valitud pakett StructTemp muutujasse ning
                            'valitud paketi, börsi ja univ hindade kellajad ja
                            'nendele vastavad hinnad salvestatakse listidesse
                            'Funktsioon LoePakettBors võetud CAndmebaas.vb-st ja GetAasta võetud Graafik.vb-st
                            StructTemp = ConnectDb.LoePakettBors(Paketid(Index).ID) 'Leitud indexiga paketi salvestatakse(olenevalt paketti tüübist) struckti ID, NIMI, JUURDETASU ja KUUTASU
                            GInfo = GetInfo.GetAasta(StructTemp.ID, PktType)
                            GInfo2 = GetInfo.GetAasta(StructUniv.ID, pktTypeU)
                            Ginfo3 = GetInfo.GetAasta(StructBors.ID, pktTypeB)

                            'Paketi tüüp: Fix
                        Case 1

                            'Omistatakse valitud pakett StructTemp2 muutujasse ning
                            'valitud paketi, börsi ja univ hindade kellajad ja
                            'nendele vastavad hinnad salvestatakse listidesse
                            'Funktsioon LoePakettFix võetud CAndmebaas.vb-st ja GetAasta võetud Graafik.vb-st
                            StructTemp2 = ConnectDb.LoePakettFix(Paketid(Index).ID)
                            GInfo = GetInfo.GetAasta(StructTemp2.ID, PktType)
                            GInfo2 = GetInfo.GetAasta(StructUniv.ID, pktTypeU)
                            Ginfo3 = GetInfo.GetAasta(StructBors.ID, pktTypeB)

                            'Paketi tüüp: Univ
                        Case 2

                            'Omistatakse valitud pakett StructTemp3 muutujasse ning
                            'valitud paketi, börsi ja univ hindade kellajad ja
                            'nendele vastavad hinnad salvestatakse listidesse
                            'Funktsioon LoePakettUniv võetud CAndmebaas.vb-st ja GetAasta võetud Graafik.vb-st
                            StructTemp3 = ConnectDb.LoePakettUniv(Paketid(Index).ID)
                            GInfo = GetInfo.GetAasta(StructTemp3.ID, PktType)
                            GInfo2 = GetInfo.GetAasta(StructUniv.ID, pktTypeU)
                            Ginfo3 = GetInfo.GetAasta(StructBors.ID, pktTypeB)

                    End Select

                    'ComboBox-ist ei ole midagi valitud
                Case Else
                    MsgBox("Valige periood!")
                    Exit Sub
            End Select

            'Kui pakett ei ole paketi ComboBox-ist valitud
        Else
            MsgBox("Valige pakett!")
            Exit Sub
        End If

        'Index muutuja nullimine
        Index = 0

        'Kontroll, millist perioodi valiti
        'Valitud periood on "tund"
        If periood = 0 Then

            'Tsükkel, et läbida iga kellaaja hind valitud paketil, univ hinnal ja börsi hinnal
            While Index < GInfo.Count And Index < GInfo2.Count And Index < Ginfo3.Count

                'Kontroll, kui index on valitud ajavahemiku vahel siis joonistatakse graafik
                If Index >= AegAlgus And Index <= AegLopp Then

                    'Joonistab graafiku.
                    'Funktsioonid setPoint1, 2 ja 3 võetud Graafik.vb-st
                    Graafik1.setPoint1(GInfo.Item(Index).Xval, GInfo.Item(Index).Yval)
                    Graafik1.setPoint2(GInfo2.Item(Index).Xval, GInfo2.Item(Index).Yval)
                    Graafik1.setPoint3(Ginfo3.Item(Index).Xval, Ginfo3.Item(Index).Yval)

                    'Valitud paketi, börsi ja univ hindade kogusumma arvutamine
                    Sum1 += GInfo.Item(Index).Yval
                    Sum2 += GInfo2.Item(Index).Yval
                    Sum3 += Ginfo3.Item(Index).Yval

                End If

                Index += 1
            End While

            'Valitud periood on "päev", "kuu", "aasta"
        Else

            'Tsükkel, et läbida iga kellaaja hind valitud paketil, univ hinnal ja börsi hinnal
            While Index < GInfo.Count And Index < GInfo2.Count And Index < Ginfo3.Count

                'Joonistab graafiku.
                'Funktsioonid setPoint1, 2 ja 3 võetud Graafik.vb-st
                Graafik1.setPoint1(GInfo.Item(Index).Xval, GInfo.Item(Index).Yval)
                Graafik1.setPoint2(GInfo2.Item(Index).Xval, GInfo2.Item(Index).Yval)
                Graafik1.setPoint3(Ginfo3.Item(Index).Xval, Ginfo3.Item(Index).Yval)

                'Valitud paketi, börsi ja univ hindade kogusumma arvutamine
                Sum1 += GInfo.Item(Index).Yval
                Sum2 += GInfo2.Item(Index).Yval
                Sum3 += Ginfo3.Item(Index).Yval

                Index += 1
            End While

        End If

        'Summade väärtused Label-itele omistamine
        lblKoguSum1.Text = Math.Round(Sum1)
        lblKoguSum1.Text += " s/kWh"
        lblKoguSum2.Text = Math.Round(Sum2)
        lblKoguSum2.Text += " s/kWh"
        lblKoguSum3.Text = Math.Round(Sum3)
        lblKoguSum3.Text += " s/kWh"

        'Summa Label-ite värvimine vastavalt,
        'kui valitud paketi summa on odavam kui univ hinna summa
        If Sum1 < Sum2 Then

            lblKoguSum1.BackColor = Color.Green
            lblKoguSum2.BackColor = Color.Red

            'kui valitud paketi summa on odavam kui börsi hinna summa
            If Sum1 < Sum3 Then

                lblKoguSum1.BackColor = Color.Green
                lblKoguSum3.BackColor = Color.Red

                'Kui börsi hinna summa on odavam kui valitud paketi summa 
            Else

                lblKoguSum1.BackColor = Color.Red
                lblKoguSum3.BackColor = Color.Green

            End If

            'kui univ hinna summa on odavam kui valitud paketi summa
        Else

            lblKoguSum1.BackColor = Color.Red
            lblKoguSum2.BackColor = Color.Green

            'kui univ hinna summa on odavam kui börsi hinna summa
            If Sum2 < Sum3 Then

                lblKoguSum2.BackColor = Color.Green
                lblKoguSum3.BackColor = Color.Red

                'kui börsi hinna summa on odavam kui univ hinna summa
            Else

                lblKoguSum2.BackColor = Color.Red
                lblKoguSum3.BackColor = Color.Green

            End If

        End If

        'Summade Label-ite nähtavuse muutmine nähtavaks
        lblKoguSum1.Visible = True
        lblKoguSum2.Visible = True
        lblKoguSum3.Visible = True
    End Sub

    'Arvuta nupp vajutamisel joonistatakse börsi ja fikseeritud hindade graafik,
    'vastavalt valitud parameetritele.
    'Sisendparameetrid:
    '   sender: Object
    '   e: Event arguments
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
        Dim periood As Integer

        'Kustutab graafikul joonistatud graafiku
        'Funktsioon ClearPoints võetud Graafik.vb-st 
        Graafik1.ClearPoints()

        'Kontroll, kas päeva tariifi ja öö tariifi on sisestatud numbrilised väärtused
        If Not IsNumeric(txtFixP.Text) Or Not IsNumeric(txtFixO.Text) Then
            MsgBox("Sisestage päeva ja öö tariifid" +
                Environment.NewLine +
                "(ainult nubritena).")
            Exit Sub
        End If

        'Andmebaasi lisatakse kaks ajutist paketti, millega tehtakse võrdlus ning hiljem kustutatakse.
        'Omistatakse nimekiri muutujasse pakettide nimekiri listina
        'Funktsioonid LisaPakettBors, LisaPakettFix ja LoePakettideNimekiri võetud CAndmebaas.vb-st
        ConnectDb.LisaPakettBors(StructBors.Nimi, StructBors.Juurdetasu, StructBors.Kuutasu)
        ConnectDb.LisaPakettFix(StructFix.Nimi, StructFix.PTariif, StructFix.OTariif, StructFix.Kuutasu)
        nimekiri = ConnectDb.LoePakettideNimekiri()

        'Tsükkel, et leida koostatud börsi paketi ID numbri ja omistada börsi strukti.
        'Samuti pktTypeB muutujale omistada börsi tüübi väärtuse.
        For index = 0 To nimekiri.Count - 1
            If nimekiri(index).Tyyp = IAndmebaas.PaketiTyyp.PAKETT_BORS Then
                Me.StructBors.ID = nimekiri(index).ID
                pktTypeB = IAndmebaas.PaketiTyyp.PAKETT_BORS
            End If
        Next

        'Tsükkel, et leida koostatud fix paketi ID numbri ja omistada fix strukti.
        'Samuti pktTypeF muutujale omistada fix tüübi väärtuse.
        For index = 0 To nimekiri.Count - 1
            If nimekiri(index).Tyyp = IAndmebaas.PaketiTyyp.PAKETT_FIX Then
                Me.StructFix.ID = nimekiri(index).ID
                pktTypeF = IAndmebaas.PaketiTyyp.PAKETT_FIX
            End If
        Next

        'Omistab perioodi muutujale perioodi ComboBox-ist valitud väärtuse
        periood = cBoxPeriood.SelectedIndex

        'Joonistab graafikule börsi hinna ja fix hinna
        joonistaGraafikBF(pktTypeB, pktTypeF, periood)

        'Kustutab eelnevalt koostatud ajutised pakettid andmebaasist.
        'Funktsioonid KustutaPakettBors ja KustutaPakettFix võetud CAndmebaas.vb-st 
        ConnectDb.KustutaPakettBors(StructBors.ID)
        ConnectDb.KustutaPakettFix(StructFix.ID)

    End Sub

    'Arvuta nupp vajutamisel joonistatakse börsi hind, börsi ja univ pakettide graafik,
    'vastavalt valitud parameetritele.
    'Sisendparameetrid:
    '   sender: Object
    '   e: Event arguments
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

        'Kustutab graafikul joonistatud graafiku
        'Funktsioon ClearPoints võetud Graafik.vb-st 
        Graafik1.ClearPoints()

        'Kontroll, kas baashind sisestati numbrilise väärtusena
        If Not IsNumeric(txtBaas.Text) Then
            MsgBox("Sisestage baas hind (ainult numbrina).")
            Exit Sub
        End If

        'Andmebaasi lisatakse kaks ajutist paketti, millega tehtakse võrdlus ning hiljem kustutatakse.
        'Omistatakse nimekiri muutujasse pakettide nimekiri listina
        'Funktsioonid LisaPakettBors, LisaPakettUniv ja LoePakettideNimekiri võetud CAndmebaas.vb-st
        ConnectDb.LisaPakettBors(StructBors.Nimi, StructBors.Juurdetasu, StructBors.Kuutasu)
        ConnectDb.LisaPakettUniv(StructUniv.Nimi, StructUniv.Baas, StructUniv.Marginaal, StructUniv.Kuutasu)
        nimekiri = ConnectDb.LoePakettideNimekiri()

        'Tsükkel, et leida koostatud börsi paketi ID numbri ja omistada börsi strukti.
        'Samuti pktTypeB muutujale omistada börsi tüübi väärtuse.
        For index = 0 To nimekiri.Count - 1
            If nimekiri(index).Tyyp = IAndmebaas.PaketiTyyp.PAKETT_BORS Then
                Me.StructBors.ID = nimekiri(index).ID
                pktTypeB = IAndmebaas.PaketiTyyp.PAKETT_BORS
                I = index
            End If
        Next

        'Tsükkel, et leida koostatud univ paketi ID numbri ja omistada univ strukti.
        'Samuti pktTypeU muutujale omistada univ tüübi väärtuse.
        For index = 0 To nimekiri.Count - 1
            If nimekiri(index).Tyyp = IAndmebaas.PaketiTyyp.PAKETT_UNIV Then
                Me.StructUniv.ID = nimekiri(index).ID
                pktTypeU = IAndmebaas.PaketiTyyp.PAKETT_UNIV
                I = index
            End If
        Next

        'Muutujate omistamine, vastavalt kasutaja poolt valitud väärtusetele
        AegAlgus = cboxAlgus2.SelectedIndex
        AegLopp = cboxLopp2.SelectedIndex
        periood = cBoxPeriood2.SelectedIndex

        'Joonistab börsi hinna, börsi- ja univ pakettide graafiku
        joonistaGraafikBU(pktTypeB, pktTypeU, periood, AegAlgus, AegLopp)

        'Kustutab eelnevalt koostatud ajutised pakettid andmebaasist.
        'Funktsioonid KustutaPakettBors ja KustutaPakettUniv võetud CAndmebaas.vb-st 
        ConnectDb.KustutaPakettBors(StructBors.ID)
        ConnectDb.KustutaPakettUniv(StructUniv.ID)
    End Sub
End Class