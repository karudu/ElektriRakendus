
Imports PrjAndmebaas
Imports System.DateTime

Public Class FormLopphind
    Dim Paketid As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
    Dim ConnectDb As New CAndmebaas
    Public StructBors As New PrjAndmebaas.IAndmebaas.PkBors
    Public StructFix As New PrjAndmebaas.IAndmebaas.PkFix
    Public StructUniv As New PrjAndmebaas.IAndmebaas.PkUniv
    Public PktType As New PrjAndmebaas.IAndmebaas.PaketiTyyp
    Private Sub FormLopphind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblAjavLopp.Visible = False
        cboxALTund.Visible = False
        cboxALTund.Items.Clear()
        cboxPakett1.Items.Clear()
        'initseerime kalendri
        dtpTrendAlgus.Value = Date.Now()
        dtpTrendLopp.Value = Date.Now()
        'load pakettid to combobox
        Dim Andmebaas As New CAndmebaas
        Paketid = Andmebaas.LoePakettideNimekiri
        'Dim Index As Integer
        For Each Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp) In Paketid
            If Pakett.Tyyp = IAndmebaas.PaketiTyyp.PAKETT_BORS Then
                Dim PakettBors As New IAndmebaas.PkBors
                PakettBors = Andmebaas.LoePakettBors(Pakett.ID)
                If String.IsNullOrEmpty(PakettBors.Nimi) Then
                    Continue For
                Else
                    cboxPakett1.Items.Add(PakettBors.Nimi)
                End If
            End If
        Next
    End Sub

    Private Sub Arvuta(ByVal flag As Integer)
        Dim Index As Integer
        Dim GInfoKesk As Decimal
        PktType = -1
        For Index = 0 To Paketid.Count - 1 'loop selleks et leida cboxPakett1 valitud paketti indexi listist
            If Paketid(Index).ID <> Nothing Then
                If cboxPakett1.Text = Paketid(Index).Nimi Then
                    PktType = Paketid(Index).Tyyp
                    Exit For
                End If
            End If
        Next
        Dim GInfo As List(Of (Xval As String, Yval As Decimal))
        Dim GetInfo As GraafikControl.IGraafikInfo
        GetInfo = New GraafikControl.CGraafikInfo
        Graafik1.ClearPoints()
        txtLoppHind.Text = Nothing
        If flag = 0 Then 'on valitud lopphinna leidja
            If PktType <> -1 Then 'kui pakett on leitud
                Me.StructBors = ConnectDb.LoePakettBors(Paketid(Index).ID) 'Leitud indexiga paketi salvestatakse(olenevalt paketti tüübist) struckti ID, NIMI, JUURDETASU ja KUUTASU
                GInfo = GetInfo.GetPaev(StructBors.ID, PktType)
                For Index = 0 To GInfo.Count - 1
                    Graafik1.setPoint1(GInfo.Item(Index).Xval, GInfo.Item(Index).Yval)
                Next
                txtLoppHind.Text += "Börsihinna pakett"
                If cboxALTund.SelectedIndex <> -1 Then 'if lause selleks, et saaks vaadata kindla kellaaja hind txtLopphind textboxis
                    txtLoppHind.Text = GInfo.Item(cboxALTund.SelectedIndex).Yval
                    txtLoppHind.Text += " senti/kWh"
                End If
                If cboxALTund.Items.Count < 24 Then 'lisab comboboxi graafikul olevad kellaajad
                    For Index = 0 To GInfo.Count - 1
                        cboxALTund.Items.Add(GInfo.Item(Index).Xval)
                        cboxALTund.Visible = True
                        lblAjavLopp.Visible = True
                    Next
                End If
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
    Private Sub btnVordlus_Click(sender As Object, e As EventArgs)
        Dim FormVordlus As New FormPakettideVordlus
        FormVordlus.ShowDialog()
    End Sub

End Class

