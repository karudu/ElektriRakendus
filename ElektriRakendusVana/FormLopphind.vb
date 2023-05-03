'FAILINIMI: FormLopphind.vb
'AUTOR: Carl Strömberg
'LOODUD: 20.03.2023
'MUUDETUD: 01.05.2023
'
'KIRJELDUS: See klass on Lõpphind nüüd ja Börsitrendid kasutajaloode jaoks mõeldud form. 
'           Selle klassi abil saab näha valitud paketi arvutatud hetket ja tuleviku lõpphinda.

'EELTINGIMUSED: On olemas ühendus andmebaasiga ja andmebaasist on loetud kõik olevad paketid.

Imports PrjAndmebaas
Imports System.DateTime
Public Class FormLopphind
    Dim Paketid As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
    Dim ConnectDb As New CAndmebaas
    Public StructBors As New PrjAndmebaas.IAndmebaas.PkBors
    Public StructFix As New PrjAndmebaas.IAndmebaas.PkFix
    Public StructUniv As New PrjAndmebaas.IAndmebaas.PkUniv
    Public PktType As New PrjAndmebaas.IAndmebaas.PaketiTyyp

    'Laeb kõik paketid andmebaasist ComboBox-i ning algselt
    'kustutab samast ComboBox-ist kõik Item-id ja paneb ajavahemiku
    'ComboBox-i ja Labeli nähtavuse vääraks.
    'Sisendparameetrid:
    '   sender: Object
    '   e: Event arguments
    Private Sub FormLopphind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Index As Integer

        lblAjavLopp.Visible = False
        cboxALTund.Visible = False
        cboxALTund.Items.Clear()
        cboxPakett1.Items.Clear()

        'initseerime kalendri
        dtpTrendAlgus.Value = Date.Now()
        dtpTrendLopp.Value = Date.Now()

        'Lae andmebaasist kõik paketid Paketide listi
        'LoePakettideNimekiri funktsioon võetud CAndmebaas.vb-st
        Paketid = ConnectDb.LoePakettideNimekiri

        'Lisa iga pakett ComboBox-i
        For Index = 0 To Paketid.Count - 1
            cboxPakett1.Items.Add(Paketid(Index).Nimi)
        Next
    End Sub

    'Nuppu vajutamisel arvutatakse ja näidatakse kasutajale valitud paketti
    'graafikul ja valitud kellaajal paketi lõpphinda.
    'Sisendparamaeetrid: sender, e
    Private Sub Arvuta(ByVal flag As Integer)
        Dim Index As Integer
        Dim GInfoKesk As Decimal
        PktType = -1
        Dim GInfo As List(Of (Xval As String, Yval As Decimal))
        Dim GetInfo As GraafikControl.IGraafikInfo
        GetInfo = New GraafikControl.CGraafikInfo

        'Kustutab graafikul eelnevalt joonistatud graafik
        'Sub ClearPoints võetud Graafik.vb-st
        Graafik1.ClearPoints()
        txtLoppHind.Text = Nothing

        For Index = 0 To Paketid.Count - 1 'loop selleks et leida cboxPakett1 valitud paketti indexi listist
            If Paketid(Index).ID <> Nothing Then
                If cboxPakett1.Text = Paketid(Index).Nimi Then
                    PktType = Paketid(Index).Tyyp
                    Exit For
                End If
            End If
        Next

        If flag = 0 Then 'on valitud lopphinna leidja
            'If lause selleks, et tuvastada, kas paketti on valitud ComboBoxi-st või mitte
            If PktType <> -1 Then 'kui pakett on leitud

                'Kui pakett oli valitud ComboBox-ist, siis Select Case leiab,
                'mis on valitud paketi tüüp (PktType) 
                Select Case PktType
                    'Tegemist on börsi paketiga
                    Case 0
                        'Leitud börsi paketi andmed salvestatakse strukti
                        'Funktsioon LoePakettBors võetud CAndmebaas.vb
                        Me.StructBors = ConnectDb.LoePakettBors(Paketid(Index).ID)

                        'Ginfo listi salvestatakse börsi paketi päeva ajad ning nendele vastavad hinnad
                        'Funktsioon GetPaev võetud CGraafikInfo.vb-st
                        GInfo = GetInfo.GetPaev(StructBors.ID, PktType)

                        'Joonistab graafikule börsi paketi hinnad.
                        'Funkstioon setPoint1 võetud CGraafikInfo.vb-st
                        For Index = 0 To GInfo.Count - 1
                            Graafik1.setPoint1(GInfo.Item(Index).Xval, GInfo.Item(Index).Yval)
                        Next

                        txtLoppHind.Text += "Börsihinna pakett"

                        'if lause selleks, et saaks vaadata börsi paketi hinda kindlal kellaajal
                        If cboxALTund.SelectedIndex <> -1 Then
                            txtLoppHind.Text = GInfo.Item(cboxALTund.SelectedIndex).Yval
                            txtLoppHind.Text += " senti/kWh"
                        End If
                    'Tegemist on fikseeritud paketiga
                    Case 1
                        'Leitud fikseeritud paketi andmed salvestatakse strukti
                        'Funktsioon LoePakettFix võetud CAndmebaas.vb
                        Me.StructFix = ConnectDb.LoePakettFix(Paketid(Index).ID)

                        'Ginfo listi salvestatakse fix paketi päeva ajad ning nendele vastavad hinnad
                        'Funktsioon GetPaev võetud CGraafikInfo.vb-st
                        GInfo = GetInfo.GetPaev(StructFix.ID, PktType)

                        'Joonistab graafikule fix paketi hinnad.
                        'Funkstioon setPoint1 võetud CGraafikInfo.vb-st
                        For Index = 0 To GInfo.Count - 1
                            Graafik1.setPoint1(GInfo.Item(Index).Xval, GInfo.Item(Index).Yval)
                        Next

                        txtLoppHind.Text += "Fikseeritud pakett"

                        'if lause selleks, et saaks vaadata fix paketi hinda kindlal kellaajal
                        If cboxALTund.SelectedIndex <> -1 Then
                            txtLoppHind.Text = GInfo.Item(cboxALTund.SelectedIndex).Yval
                            txtLoppHind.Text += " senti/kWh"
                        End If
                    'Tegemist on universaal paketiga
                    Case 2
                        'Leitud universaal paketi andmed salvestatakse strukti
                        'Funktsioon LoePakettUniv võetud CAndmebaas.vb
                        Me.StructUniv = ConnectDb.LoePakettUniv(Paketid(Index).ID)

                        'Ginfo listi salvestatakse univ paketi päeva ajad ning nendele vastavad hinnad
                        'Funktsioon GetPaev võetud CGraafikInfo.vb-st
                        GInfo = GetInfo.GetPaev(StructUniv.ID, PktType)

                        'Joonistab graafikule univ paketi hinnad.
                        'Funkstioon setPoint1 võetud CGraafikInfo.vb-st
                        For Index = 0 To GInfo.Count - 1
                            Graafik1.setPoint1(GInfo.Item(Index).Xval, GInfo.Item(Index).Yval)
                        Next

                        txtLoppHind.Text += "Universaal pakett"

                        'if lause selleks, et saaks vaadata univ paketi hinda kindlal kellaajal
                        If cboxALTund.SelectedIndex <> -1 Then
                            txtLoppHind.Text = GInfo.Item(cboxALTund.SelectedIndex).Yval
                            txtLoppHind.Text += " senti/kWh"
                        End If
                End Select

                'lisab ajavahemiku ComboBox-i graafikul olevad kellaajad
                'ja muudab ajavahemiku ComboBox-i ja Labeli nähtavuse tõeseks
                If cboxALTund.Items.Count < 24 Then
                    For Index = 0 To GInfo.Count - 1
                        cboxALTund.Items.Add(GInfo.Item(Index).Xval)
                        cboxALTund.Visible = True
                        lblAjavLopp.Visible = True
                    Next
                End If

                'Kui paketi tüüp on -1 ehk pole valitud ComboBox-ist paketti,
                'antakse kasutajale seda teada.
            Else
                txtLoppHind.Text = "Valige pakett"
                Exit Sub
            End If
        Else 'on valitud borsihinna trendid
            GInfo = GetInfo.GetCustom(StructBors.ID, PktType, dtpTrendAlgus.Value, dtpTrendLopp.Value, 1)
            If GInfo IsNot Nothing Then
                If GInfo.Count > 50 Then
                    For Index = 0 To GInfo.Count - 1
                        If Index Mod 5 = 0 Then
                            Graafik1.setPoint1(GInfo.Item(Index).Xval, GInfo.Item(Index).Yval)
                        Else
                            Graafik1.setPoint1(" ", GInfo.Item(Index).Yval)
                        End If
                        GInfoKesk += GInfo.Item(Index).Yval
                    Next
                Else
                    For Index = 0 To GInfo.Count - 1
                        Graafik1.setPoint1(GInfo.Item(Index).Xval, GInfo.Item(Index).Yval)
                        GInfoKesk += GInfo.Item(Index).Yval
                    Next
                End If
                GInfoKesk /= GInfo.Count
                lblTrendKesk.Text = GInfoKesk.ToString("N2") + (" s/kWh")
                LeiaKalleimJaOdavaim()
            End If
        End If
    End Sub
    Private Sub LeiaKalleimJaOdavaim()
        Dim Index As Integer
        Dim OdavaimAeg(24) As Integer
        Dim KalleimAeg(24) As Integer
        For Index = 0 To 23 'algvaartustame massiivi
            OdavaimAeg(Index) = 0
            KalleimAeg(Index) = 0
        Next
        Dim AlgAeg = New Date(dtpTrendAlgus.Value.Year, dtpTrendAlgus.Value.Month, dtpTrendAlgus.Value.Day, 0, 0, 0)
        Dim LoppAeg = New Date(dtpTrendLopp.Value.Year, dtpTrendLopp.Value.Month, dtpTrendLopp.Value.Day, 0, 0, 0)
        If AlgAeg = LoppAeg Then
            If DaysInMonth(LoppAeg.Year, LoppAeg.Month) = LoppAeg.Day Then
                If LoppAeg.Month = 12 Then
                    LoppAeg = New Date(LoppAeg.Year + 1, 1, 1, 0, 0, 0)
                Else
                    LoppAeg = New Date(LoppAeg.Year, LoppAeg.Month + 1, 1, 0, 0, 0)
                End If
            Else
                LoppAeg = New Date(LoppAeg.Year, LoppAeg.Month, LoppAeg.Day + 1, 0, 0, 0)
            End If
        Else
            LoppAeg = New Date(LoppAeg.Year, LoppAeg.Month, LoppAeg.Day, 0, 0, 0)
        End If
        Dim TS As New TimeSpan
        TS = LoppAeg.Subtract(AlgAeg)
        Dim Tunnid As Integer = TS.TotalHours
        Dim Hinnad As New List(Of Decimal)
        Dim J As Integer
        For Index = 0 To Tunnid - 1 Step 24
            Dim OdavaimH As Integer = 0
            Dim KalleimH As Integer = 0
            Hinnad = ConnectDb.LoeBorsihinnadSentkWh(AlgAeg, 24) 'loeme borshinnad andmebaasist
            Dim OdavaimHind As Decimal = Hinnad.Item(0)
            Dim KalleimHind As Decimal = Hinnad.Item(0)
            For J = 0 To 23 'leiame antud paeval koige odavama ja kalleima kellaaja
                If Hinnad.Item(J) < OdavaimHind Then
                    OdavaimHind = Hinnad.Item(J)
                    OdavaimH = J
                End If
                If Hinnad.Item(J) > KalleimHind Then
                    KalleimHind = Hinnad.Item(J)
                    KalleimH = J
                End If
            Next
            OdavaimAeg(OdavaimH) += 1
            KalleimAeg(KalleimH) += 1
            AlgAeg = AlgAeg.AddDays(1)
        Next
        Dim OdavaimTundVal As Integer = OdavaimAeg(0)
        Dim KalleimTundVal As Integer = KalleimAeg(0)
        Dim OdavaimTund As Integer = 0
        Dim KalleimTund As Integer = 0
        For Index = 0 To 23
            If OdavaimAeg(Index) > OdavaimTundVal Then
                OdavaimTundVal = OdavaimAeg(Index)
                OdavaimTund = Index
            End If
            If KalleimAeg(Index) > KalleimTundVal Then
                KalleimTundVal = KalleimAeg(Index)
                KalleimTund = Index
            End If
        Next
        lblOdavaim.Text = OdavaimTund.ToString + (":00")
        lblKalleim.Text = KalleimTund.ToString + (":00")
    End Sub

    Private Sub btnArvuta_Click(sender As Object, e As EventArgs) Handles btnArvuta.Click
        Arvuta(0)
    End Sub
    Private Sub btnTrendArvuta_Click(sender As Object, e As EventArgs) Handles btnTrendArvuta.Click
        Arvuta(1)
    End Sub
End Class

