Imports PrjAndmebaas

Public Class FormMain
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbPeriood.Items.Add("Päev")
        cmbPeriood.Items.Add("Kuu")
        cmbPeriood.Items.Add("Aasta")
        cmbPeriood.Items.Add("Otsi")
        dtpAlgus.Value = Date.Now()
        dtpLopp.Value = Date.Now()
        AddPaketiTyybid()
        Graafik1.InitGraph()
    End Sub

    Private Sub AddPaketiTyybid()
        cmbPkt1Tyyp.Items.Add("Börsi")
        cmbPkt1Tyyp.Items.Add("Fikseeritud")
        cmbPkt1Tyyp.Items.Add("Universaal")
        cmbPkt2Tyyp.Items.Add("Börsi")
        cmbPkt2Tyyp.Items.Add("Fikseeritud")
        cmbPkt2Tyyp.Items.Add("Universaal")
    End Sub

    Private Sub Uuenda_Graafik()
        Dim GInfo1 As List(Of (Xval As String, Yval As Decimal))
        Dim GInfo2 As List(Of (Xval As String, Yval As Decimal))
        Dim GraafikConnect As GraafikControl.IGraafikInfo
        GraafikConnect = New GraafikControl.CGraafikInfo
        Dim GInfo1Kesk As Decimal
        Dim GInfo2Kesk As Decimal
        Graafik1.ClearPoints()
        Dim PakettID1 As Integer
        Dim PakettID2 As Integer
        'kontrollime kas pakett 1 on valitud
        If String.IsNullOrEmpty(cmbPkt1Pkt.SelectedItem) Then
            PakettID1 = Nothing
        Else
            PakettID1 = GetPakettInfo(cmbPkt1Pkt.SelectedItem.ToString, cmbPkt1Tyyp.SelectedIndex)
        End If
        'kontrollime kas pakett 2 on valitud
        If String.IsNullOrEmpty(cmbPkt2Pkt.SelectedItem) Then
            PakettID2 = Nothing
        Else
            PakettID2 = GetPakettInfo(cmbPkt2Pkt.SelectedItem.ToString, cmbPkt2Tyyp.SelectedIndex)
        End If
        Dim I As Integer
        Select Case cmbPeriood.SelectedIndex 'paketitüübi valik(0=börs, 1=fix, 2=universaal)
            Case 0
                If PakettID1 <> Nothing Then
                    GInfo1 = GraafikConnect.GetPaev(PakettID1, cmbPkt1Tyyp.SelectedIndex)
                    For I = 0 To GInfo1.Count - 1
                        Graafik1.setPoint1(GInfo1.Item(I).Xval, GInfo1.Item(I).Yval)
                        GInfo1Kesk += GInfo1.Item(I).Yval
                    Next
                    GInfo1Kesk = GInfo1Kesk / GInfo1.Count
                    lblPkt1Kesk.Text = GInfo1Kesk.ToString("N2") + " s/kWh"
                End If
                If PakettID2 <> Nothing Then
                    GInfo2 = GraafikConnect.GetPaev(PakettID2, cmbPkt2Tyyp.SelectedIndex)
                    For I = 0 To GInfo2.Count - 1
                        Graafik1.setPoint2(GInfo2.Item(I).Xval, GInfo2.Item(I).Yval)
                        GInfo2Kesk += GInfo2.Item(I).Yval
                    Next
                    GInfo2Kesk = GInfo2Kesk / GInfo2.Count
                    lblPkt2Kesk.Text = GInfo2Kesk.ToString("N2") + " s/kWh"
                End If
            Case 1
                If PakettID1 <> Nothing Then
                    GInfo1 = GraafikConnect.GetKuu(PakettID1, cmbPkt1Tyyp.SelectedIndex)
                    For I = 0 To GInfo1.Count - 1
                        Graafik1.setPoint1(GInfo1.Item(I).Xval, GInfo1.Item(I).Yval)
                        GInfo1Kesk += GInfo1.Item(I).Yval
                    Next
                    GInfo1Kesk = GInfo1Kesk / GInfo1.Count
                    lblPkt1Kesk.Text = GInfo1Kesk.ToString("N2") + " s/kWh"
                End If
                If PakettID2 <> Nothing Then
                    GInfo2 = GraafikConnect.GetKuu(PakettID2, cmbPkt2Tyyp.SelectedIndex)
                    For I = 0 To GInfo2.Count - 1
                        Graafik1.setPoint2(GInfo2.Item(I).Xval, GInfo2.Item(I).Yval)
                        GInfo2Kesk += GInfo2.Item(I).Yval
                    Next
                    GInfo2Kesk = GInfo2Kesk / GInfo2.Count
                    lblPkt2Kesk.Text = GInfo2Kesk.ToString("N2") + " s/kWh"
                End If
            Case 2
                If PakettID1 <> Nothing Then
                    GInfo1 = GraafikConnect.GetAasta(PakettID1, cmbPkt1Tyyp.SelectedIndex)
                    For I = 0 To GInfo1.Count - 1
                        Graafik1.setPoint1(GInfo1.Item(I).Xval, GInfo1.Item(I).Yval)
                        GInfo1Kesk += GInfo1.Item(I).Yval
                    Next
                    GInfo1Kesk = GInfo1Kesk / GInfo1.Count
                    lblPkt1Kesk.Text = GInfo1Kesk.ToString("N2") + " s/kWh"
                End If
                If PakettID2 <> Nothing Then
                    GInfo2 = GraafikConnect.GetAasta(PakettID2, cmbPkt2Tyyp.SelectedIndex)
                    For I = 0 To GInfo2.Count - 1
                        Graafik1.setPoint2(GInfo2.Item(I).Xval, GInfo2.Item(I).Yval)
                        GInfo2Kesk += GInfo2.Item(I).Yval
                    Next
                    GInfo2Kesk = GInfo2Kesk / GInfo2.Count
                    lblPkt2Kesk.Text = GInfo2Kesk.ToString("N2") + " s/kWh"
                End If
            Case 3
                If DateTime.Compare(dtpAlgus.Value, dtpLopp.Value) > 0 Then 'kas alguskuupäev on ikka enne lõppkuupäeva
                    MessageBox.Show("Alguskuupäev peab olema enne lõppkuupäeva!")
                    Return
                End If
                If PakettID1 <> Nothing Then
                    GInfo1 = GraafikConnect.GetCustom(PakettID1, cmbPkt1Tyyp.SelectedIndex, dtpAlgus.Value, dtpLopp.Value, 0)
                    If GInfo1.Count > 50 Then
                        For I = 0 To GInfo1.Count - 1
                            If I Mod 5 = 0 Then
                                Graafik1.setPoint1(GInfo1.Item(I).Xval, GInfo1.Item(I).Yval)
                            Else
                                Graafik1.setPoint1(" ", GInfo1.Item(I).Yval)
                            End If
                            GInfo1Kesk += GInfo1.Item(I).Yval
                        Next
                    Else
                        For I = 0 To GInfo1.Count - 1
                            Graafik1.setPoint1(GInfo1.Item(I).Xval, GInfo1.Item(I).Yval)
                            GInfo1Kesk += GInfo1.Item(I).Yval
                        Next
                    End If
                    GInfo1Kesk = GInfo1Kesk / GInfo1.Count
                    lblPkt1Kesk.Text = GInfo1Kesk.ToString("N2") + " s/kWh"
                End If
                If PakettID2 <> Nothing Then
                    GInfo2 = GraafikConnect.GetCustom(PakettID2, cmbPkt2Tyyp.SelectedIndex, dtpAlgus.Value, dtpLopp.Value, 0)
                    If GInfo2.Count > 50 Then
                        For I = 0 To GInfo2.Count - 1
                            If I Mod 5 = 0 Then
                                Graafik1.setPoint2(GInfo2.Item(I).Xval, GInfo2.Item(I).Yval)
                            Else
                                Graafik1.setPoint2(" ", GInfo2.Item(I).Yval)
                            End If
                            GInfo2Kesk += GInfo2.Item(I).Yval
                        Next
                    Else
                        For I = 0 To GInfo2.Count - 1
                            Graafik1.setPoint2(GInfo2.Item(I).Xval, GInfo2.Item(I).Yval)
                            GInfo2Kesk += GInfo2.Item(I).Yval
                        Next
                    End If
                    GInfo2Kesk = GInfo2Kesk / GInfo2.Count
                    lblPkt2Kesk.Text = GInfo2Kesk.ToString("N2") + " s/kWh"
                End If
        End Select
        'Toome parema keskmise hinna esile värviga
        If PakettID1 <> Nothing And PakettID2 <> Nothing Then
            If GInfo1Kesk < GInfo2Kesk Then
                lblPkt1Kesk.BackColor = Color.Green
                lblPkt2Kesk.BackColor = Color.Red
            Else
                lblPkt2Kesk.BackColor = Color.Green
                lblPkt1Kesk.BackColor = Color.Red
            End If
        End If
    End Sub

    Private Sub cmbPkt1Tyyp_DropDownClosed(sender As Object, e As EventArgs) Handles cmbPkt1Tyyp.DropDownClosed
        cmbPkt1Pkt.Items.Clear()
        AddPaketid1(cmbPkt1Tyyp.SelectedIndex)
    End Sub

    Private Sub AddPaketid1(ByVal Tyyp As Integer)
        Dim Paketid As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
        Dim Andmebaas As New CAndmebaas
        Paketid = Andmebaas.LoePakettideNimekiri
        Select Case Tyyp
            Case IAndmebaas.PaketiTyyp.PAKETT_BORS
                For Each Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp) In Paketid
                    If Pakett.Tyyp = IAndmebaas.PaketiTyyp.PAKETT_BORS Then
                        Dim PakettBors As New IAndmebaas.PkBors
                        PakettBors = Andmebaas.LoePakettBors(Pakett.ID)
                        If String.IsNullOrEmpty(PakettBors.Nimi) Then
                            Continue For
                        Else
                            cmbPkt1Pkt.Items.Add(PakettBors.Nimi)
                        End If
                    End If
                Next
            Case IAndmebaas.PaketiTyyp.PAKETT_FIX
                For Each Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp) In Paketid
                    If Pakett.Tyyp = IAndmebaas.PaketiTyyp.PAKETT_FIX Then
                        Dim PakettFix As New IAndmebaas.PkFix
                        PakettFix = Andmebaas.LoePakettFix(Pakett.ID)
                        If String.IsNullOrEmpty(PakettFix.Nimi) Then
                            Continue For
                        Else
                            cmbPkt1Pkt.Items.Add(PakettFix.Nimi)
                        End If
                    End If
                Next
            Case IAndmebaas.PaketiTyyp.PAKETT_UNIV
                For Each Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp) In Paketid
                    If Pakett.Tyyp = IAndmebaas.PaketiTyyp.PAKETT_UNIV Then
                        Dim PakettUniv As New IAndmebaas.PkUniv
                        PakettUniv = Andmebaas.LoePakettUniv(Pakett.ID)
                        If String.IsNullOrEmpty(PakettUniv.Nimi) Then
                            Continue For
                        Else
                            cmbPkt1Pkt.Items.Add(PakettUniv.Nimi)
                        End If
                    End If
                Next
        End Select
    End Sub

    Private Sub cmbPkt2Tyyp_DropDownClosed(sender As Object, e As EventArgs) Handles cmbPkt2Tyyp.DropDownClosed
        cmbPkt2Pkt.Items.Clear()
        AddPaketid2(cmbPkt2Tyyp.SelectedIndex)
    End Sub

    Private Sub AddPaketid2(ByVal Tyyp As Integer)
        Dim Paketid As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
        Dim Andmebaas As New CAndmebaas
        Paketid = Andmebaas.LoePakettideNimekiri
        Select Case Tyyp
            Case IAndmebaas.PaketiTyyp.PAKETT_BORS
                For Each Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp) In Paketid
                    If Pakett.Tyyp = IAndmebaas.PaketiTyyp.PAKETT_BORS Then
                        Dim PakettBors As New IAndmebaas.PkBors
                        PakettBors = Andmebaas.LoePakettBors(Pakett.ID)
                        If String.IsNullOrEmpty(PakettBors.Nimi) Then
                            Continue For
                        Else
                            cmbPkt2Pkt.Items.Add(PakettBors.Nimi)
                        End If
                    End If
                Next
            Case IAndmebaas.PaketiTyyp.PAKETT_FIX
                For Each Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp) In Paketid
                    If Pakett.Tyyp = IAndmebaas.PaketiTyyp.PAKETT_FIX Then
                        Dim PakettFix As New IAndmebaas.PkFix
                        PakettFix = Andmebaas.LoePakettFix(Pakett.ID)
                        If String.IsNullOrEmpty(PakettFix.Nimi) Then
                            Continue For
                        Else
                            cmbPkt2Pkt.Items.Add(PakettFix.Nimi)
                        End If
                    End If
                Next
            Case IAndmebaas.PaketiTyyp.PAKETT_UNIV
                For Each Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp) In Paketid
                    If Pakett.Tyyp = IAndmebaas.PaketiTyyp.PAKETT_UNIV Then
                        Dim PakettUniv As New IAndmebaas.PkUniv
                        PakettUniv = Andmebaas.LoePakettUniv(Pakett.ID)
                        If String.IsNullOrEmpty(PakettUniv.Nimi) Then
                            Continue For
                        Else
                            cmbPkt2Pkt.Items.Add(PakettUniv.Nimi)
                        End If
                    End If
                Next
        End Select
    End Sub
    Private Function GetPakettInfo(ByVal Nimi As String, Tyyp As Integer) As Integer
        Dim ID As Integer
        Dim Paketid As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
        Dim Andmebaas As New CAndmebaas
        Paketid = Andmebaas.LoePakettideNimekiri
        Select Case Tyyp
            Case IAndmebaas.PaketiTyyp.PAKETT_BORS
                For Each Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp) In Paketid
                    If Pakett.Tyyp = IAndmebaas.PaketiTyyp.PAKETT_BORS Then
                        Dim PakettBors As New IAndmebaas.PkBors
                        PakettBors = Andmebaas.LoePakettBors(Pakett.ID)
                        If Nimi = PakettBors.Nimi Then
                            ID = PakettBors.ID
                            Return ID
                        End If
                    End If
                Next
            Case IAndmebaas.PaketiTyyp.PAKETT_FIX
                For Each Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp) In Paketid
                    If Pakett.Tyyp = IAndmebaas.PaketiTyyp.PAKETT_FIX Then
                        Dim PakettFix As New IAndmebaas.PkFix
                        PakettFix = Andmebaas.LoePakettFix(Pakett.ID)
                        If Nimi = PakettFix.Nimi Then
                            ID = PakettFix.ID
                            Return ID
                        End If
                    End If
                Next
            Case IAndmebaas.PaketiTyyp.PAKETT_UNIV
                For Each Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp) In Paketid
                    If Pakett.Tyyp = IAndmebaas.PaketiTyyp.PAKETT_UNIV Then
                        Dim PakettUniv As New IAndmebaas.PkUniv
                        PakettUniv = Andmebaas.LoePakettUniv(Pakett.ID)
                        If Nimi = PakettUniv.Nimi Then
                            ID = PakettUniv.ID
                            Return ID
                        End If
                    End If
                Next
        End Select

        Return ID
    End Function

    Private Sub BtnPaketid_Click(sender As Object, e As EventArgs) Handles BtnPaketid.Click
        Dim Form As New PrjAndmebaasTestForm.FormRedaktorPaketid
        Form.Show()
    End Sub

    Private Sub BtnMasinad_Click(sender As Object, e As EventArgs) Handles BtnMasinad.Click
        Dim Form As New PrjAndmebaasTestForm.FormRedaktorKodumasinad
        Form.Show()
    End Sub

    Private Sub BtnKalkKodumasinad_Click(sender As Object, e As EventArgs) Handles BtnKalkKodumasinad.Click
        Dim Form As New KodumasinKalkulaator.FormKodumasinKalkulaator
        Form.Show()
    End Sub

    Private Sub BtnLopphind_Click(sender As Object, e As EventArgs) Handles BtnLopphind.Click
        Dim Form As New PakettideVordlus.FormLopphind
        Form.Show()
    End Sub

    Private Sub BtnVordleja_Click(sender As Object, e As EventArgs) Handles BtnVordleja.Click
        Dim Form As New PakettideVordlus.FormPakettideVordlus
        Form.Show()
    End Sub

    Private Sub BtnElektriauto_Click(sender As Object, e As EventArgs) Handles BtnElektriauto.Click
        Dim Form As New PrjLaadijaKalkulaator.Form1
        Form.Show()
    End Sub

    Private Sub BtnHinnaKalkulaator_Click(sender As Object, e As EventArgs) Handles BtnHinnaKalkulaator.Click
        Dim Form As New KodumasinKalkulaator.FormHinnaKalkulaator
        Form.Show()
    End Sub

    Private Sub cmbPkt1Pkt_DropDownClosed(sender As Object, e As EventArgs) Handles cmbPkt1Pkt.DropDownClosed
        If String.IsNullOrEmpty(cmbPeriood.SelectedItem) Then
            Return
        ElseIf String.IsNullOrEmpty(cmbPkt1Pkt.SelectedItem) And String.IsNullOrEmpty(cmbPkt2Pkt.SelectedItem) Then
            Return
        Else
            Uuenda_Graafik()
        End If
    End Sub

    Private Sub cmbPeriood_DropDownClosed(sender As Object, e As EventArgs) Handles cmbPeriood.DropDownClosed
        If cmbPeriood.SelectedIndex = 3 Then
            dtpAlgus.Show()
            dtpLopp.Show()
            lblDtpVahe.Show()
        Else
            dtpAlgus.Hide()
            dtpLopp.Hide()
            lblDtpVahe.Hide()
        End If

        If String.IsNullOrEmpty(cmbPeriood.SelectedItem) Then
            Return
        ElseIf String.IsNullOrEmpty(cmbPkt1Pkt.SelectedItem) And String.IsNullOrEmpty(cmbPkt2Pkt.SelectedItem) Then
            Return
        Else
            Uuenda_Graafik()
        End If
    End Sub

    Private Sub cmbPkt2Pkt_DropDownClosed(sender As Object, e As EventArgs) Handles cmbPkt2Pkt.DropDownClosed
        If String.IsNullOrEmpty(cmbPeriood.SelectedItem) Then
            Return
        ElseIf String.IsNullOrEmpty(cmbPkt1Pkt.SelectedItem) And String.IsNullOrEmpty(cmbPkt2Pkt.SelectedItem) Then
            Return
        Else
            Uuenda_Graafik()
        End If
    End Sub

    Private Sub dtpAlgus_CloseUp(sender As Object, e As EventArgs) Handles dtpAlgus.CloseUp
        If String.IsNullOrEmpty(cmbPeriood.SelectedItem) Then
            Return
        ElseIf String.IsNullOrEmpty(cmbPkt1Pkt.SelectedItem) And String.IsNullOrEmpty(cmbPkt2Pkt.SelectedItem) Then
            Return
        Else
            Uuenda_Graafik()
        End If
    End Sub

    Private Sub dtpLopp_CloseUp(sender As Object, e As EventArgs) Handles dtpLopp.CloseUp
        If String.IsNullOrEmpty(cmbPeriood.SelectedItem) Then
            Return
        ElseIf String.IsNullOrEmpty(cmbPkt1Pkt.SelectedItem) And String.IsNullOrEmpty(cmbPkt2Pkt.SelectedItem) Then
            Return
        Else
            Uuenda_Graafik()
        End If
    End Sub
End Class
