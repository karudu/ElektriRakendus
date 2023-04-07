Imports PrjAndmebaas

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbPeriood.Items.Add("Päev")
        cmbPeriood.Items.Add("Kuu")
        cmbPeriood.Items.Add("Aasta")
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

    Private Sub cmbPeriood_DropDownClosed(sender As Object, e As EventArgs) Handles cmbPeriood.DropDownClosed
        Dim GInfo1 As List(Of (Xval As String, Yval As Decimal))
        Dim GInfo2 As List(Of (Xval As String, Yval As Decimal))
        Dim GraafikConnect As GraafikControl.IGraafikInfo
        GraafikConnect = New GraafikControl.CGraafikInfo
        Graafik1.ClearPoints()
        Dim PakettID1 As Integer
        Dim PakettID2 As Integer
        PakettID1 = GetPakettInfo(cmbPkt1Pkt.SelectedItem.ToString, cmbPkt1Tyyp.SelectedIndex)
        PakettID2 = GetPakettInfo(cmbPkt2Pkt.SelectedItem.ToString, cmbPkt2Tyyp.SelectedIndex)
        Console.WriteLine(PakettID1)
        Console.WriteLine(PakettID2)
        Dim I As Integer
        Select Case cmbPeriood.SelectedIndex
            Case 0
                GInfo1 = GraafikConnect.GetPaev(PakettID1, cmbPkt1Tyyp.SelectedIndex)
                GInfo2 = GraafikConnect.GetPaev(PakettID2, cmbPkt2Tyyp.SelectedIndex)
                For I = 0 To GInfo1.Count - 1
                    Graafik1.setPoint1(GInfo1.Item(I).Xval, GInfo1.Item(I).Yval)
                    Graafik1.setPoint2(GInfo2.Item(I).Xval, GInfo2.Item(I).Yval)
                Next
            Case 1
                GInfo1 = GraafikConnect.GetKuu(PakettID1, cmbPkt1Tyyp.SelectedIndex)
                GInfo2 = GraafikConnect.GetKuu(PakettID2, cmbPkt2Tyyp.SelectedIndex)
                I = 0
                While I < GInfo1.Count - 1 And I < GInfo2.Count - 1
                    Graafik1.setPoint1(GInfo1.Item(I).Xval, GInfo1.Item(I).Yval)
                    Graafik1.setPoint2(GInfo2.Item(I).Xval, GInfo2.Item(I).Yval)
                    I += 1
                End While
            Case 2
                GInfo1 = GraafikConnect.GetAasta(PakettID1, cmbPkt1Tyyp.SelectedIndex)
                GInfo2 = GraafikConnect.GetAasta(PakettID2, cmbPkt2Tyyp.SelectedIndex)
                I = 0
                While I < GInfo1.Count - 1 And I < GInfo2.Count - 1
                    Graafik1.setPoint1(GInfo1.Item(I).Xval, GInfo1.Item(I).Yval)
                    Graafik1.setPoint2(GInfo2.Item(I).Xval, GInfo2.Item(I).Yval)
                    I += 1
                End While
        End Select
    End Sub

    Private Sub cmbPkt1Tyyp_DropDownClosed(sender As Object, e As EventArgs) Handles cmbPkt1Tyyp.DropDownClosed
        cmbPkt1Pkt.Items.Clear()
        AddPaketid1(cmbPkt1Tyyp.SelectedIndex)
    End Sub

    Private Sub AddPaketid1(ByVal Tyyp As Integer)
        Dim Paketid As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
        Dim Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp)
        Dim Andmebaas As New CAndmebaas
        Paketid = Andmebaas.LoePakettideNimekiri
        Select Case Tyyp
            Case 0
                Pakett.Tyyp = IAndmebaas.PaketiTyyp.PAKETT_BORS
            Case 1
                Pakett.Tyyp = IAndmebaas.PaketiTyyp.PAKETT_FIX
            Case 2
                Pakett.Tyyp = IAndmebaas.PaketiTyyp.PAKETT_UNIV
        End Select
        Select Case Pakett.Tyyp
            Case IAndmebaas.PaketiTyyp.PAKETT_BORS
                For Each Pakett In Paketid
                    Dim PakettBors As New IAndmebaas.PkBors
                    PakettBors = Andmebaas.LoePakettBors(Pakett.ID)
                    If String.IsNullOrEmpty(PakettBors.Nimi) Then
                        Continue For
                    Else
                        cmbPkt1Pkt.Items.Add(PakettBors.Nimi)
                    End If

                Next
            Case IAndmebaas.PaketiTyyp.PAKETT_FIX
                For Each Pakett In Paketid
                    Dim PakettFix As New IAndmebaas.PkFix
                    PakettFix = Andmebaas.LoePakettFix(Pakett.ID)
                    If String.IsNullOrEmpty(PakettFix.Nimi) Then
                        Continue For
                    Else
                        cmbPkt1Pkt.Items.Add(PakettFix.Nimi)
                    End If
                Next
            Case IAndmebaas.PaketiTyyp.PAKETT_UNIV
                For Each Pakett In Paketid
                    Dim PakettUniv As New IAndmebaas.PkUniv
                    PakettUniv = Andmebaas.LoePakettUniv(Pakett.ID)
                    If String.IsNullOrEmpty(PakettUniv.Nimi) Then
                        Continue For
                    Else
                        cmbPkt1Pkt.Items.Add(PakettUniv.Nimi)
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
        Dim Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp)
        Dim Andmebaas As New CAndmebaas
        Paketid = Andmebaas.LoePakettideNimekiri
        Console.WriteLine(Tyyp)
        Select Case Tyyp
            Case 0
                Pakett.Tyyp = IAndmebaas.PaketiTyyp.PAKETT_BORS
            Case 1
                Pakett.Tyyp = IAndmebaas.PaketiTyyp.PAKETT_FIX
            Case 2
                Pakett.Tyyp = IAndmebaas.PaketiTyyp.PAKETT_UNIV
        End Select
        Select Case Pakett.Tyyp
            Case IAndmebaas.PaketiTyyp.PAKETT_BORS
                For Each Pakett In Paketid
                    Dim PakettBors As New IAndmebaas.PkBors
                    PakettBors = Andmebaas.LoePakettBors(Pakett.ID)
                    If String.IsNullOrEmpty(PakettBors.Nimi) Then
                        Continue For
                    Else
                        cmbPkt2Pkt.Items.Add(PakettBors.Nimi)
                    End If

                Next
            Case IAndmebaas.PaketiTyyp.PAKETT_FIX
                For Each Pakett In Paketid
                    Dim PakettFix As New IAndmebaas.PkFix
                    PakettFix = Andmebaas.LoePakettFix(Pakett.ID)
                    If String.IsNullOrEmpty(PakettFix.Nimi) Then
                        Continue For
                    Else
                        cmbPkt2Pkt.Items.Add(PakettFix.Nimi)
                    End If
                Next
            Case IAndmebaas.PaketiTyyp.PAKETT_UNIV
                For Each Pakett In Paketid
                    Dim PakettUniv As New IAndmebaas.PkUniv
                    PakettUniv = Andmebaas.LoePakettUniv(Pakett.ID)
                    If String.IsNullOrEmpty(PakettUniv.Nimi) Then
                        Continue For
                    Else
                        cmbPkt2Pkt.Items.Add(PakettUniv.Nimi)
                    End If
                Next
        End Select
    End Sub
    Private Function GetPakettInfo(ByVal Nimi As String, Tyyp As Integer) As Integer
        Dim ID As Integer
        Dim Paketid As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
        Dim Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp)
        Dim Andmebaas As New CAndmebaas
        Paketid = Andmebaas.LoePakettideNimekiri
        Console.WriteLine(Tyyp)
        Select Case Tyyp
            Case 0
                Pakett.Tyyp = IAndmebaas.PaketiTyyp.PAKETT_BORS
            Case 1
                Pakett.Tyyp = IAndmebaas.PaketiTyyp.PAKETT_FIX
            Case 2
                Pakett.Tyyp = IAndmebaas.PaketiTyyp.PAKETT_UNIV
        End Select
        Select Case Pakett.Tyyp
            Case IAndmebaas.PaketiTyyp.PAKETT_BORS
                For Each Pakett In Paketid
                    Dim PakettBors As New IAndmebaas.PkBors
                    PakettBors = Andmebaas.LoePakettBors(Pakett.ID)
                    If Nimi = PakettBors.Nimi Then
                        ID = PakettBors.ID
                        Return ID
                    End If
                Next
            Case IAndmebaas.PaketiTyyp.PAKETT_FIX
                For Each Pakett In Paketid
                    Dim PakettFix As New IAndmebaas.PkFix
                    PakettFix = Andmebaas.LoePakettFix(Pakett.ID)
                    If Nimi = PakettFix.Nimi Then
                        ID = PakettFix.ID
                        Return ID
                    End If
                Next
            Case IAndmebaas.PaketiTyyp.PAKETT_UNIV
                For Each Pakett In Paketid
                    Dim PakettUniv As New IAndmebaas.PkUniv
                    PakettUniv = Andmebaas.LoePakettUniv(Pakett.ID)
                    If Nimi = PakettUniv.Nimi Then
                        ID = PakettUniv.ID
                        Return ID
                    End If
                Next
        End Select

        Return ID
    End Function
End Class
