
Imports PrjAndmebaas

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
                    cmbTrendPkt.Items.Add(PakettBors.Nimi)
                End If
            End If
        Next
    End Sub


    Private Sub Arvuta(ByVal flag As Integer)
        PktType = -1
        Dim Index As Integer
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
        If flag = 0 Then
            If PktType <> -1 Then
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
        Else
            If PktType <> -1 Then
                Me.StructBors = ConnectDb.LoePakettBors(Paketid(Index).ID) 'Leitud indexiga paketi salvestatakse(olenevalt paketti tüübist) struckti ID, NIMI, JUURDETASU ja KUUTASU
                GInfo = GetInfo.GetCustom(StructBors.ID, PktType, dtpTrendAlgus.Value, dtpTrendLopp.Value)
                For Index = 0 To GInfo.Count - 1
                    Graafik1.setPoint1(GInfo.Item(Index).Xval, GInfo.Item(Index).Yval)
                Next
            End If
        End If
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

