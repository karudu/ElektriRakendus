﻿Imports PrjAndmebaas

Public Class FormMain
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
        If String.IsNullOrEmpty(cmbPkt1Pkt.SelectedItem) Then
            PakettID1 = Nothing
        Else
            PakettID1 = GetPakettInfo(cmbPkt1Pkt.SelectedItem.ToString, cmbPkt1Tyyp.SelectedIndex)
        End If
        If String.IsNullOrEmpty(cmbPkt2Pkt.SelectedItem) Then
            PakettID2 = Nothing
        Else
            PakettID2 = GetPakettInfo(cmbPkt2Pkt.SelectedItem.ToString, cmbPkt2Tyyp.SelectedIndex)
        End If
        Dim I As Integer
        Select Case cmbPeriood.SelectedIndex
            Case 0
                If PakettID1 <> Nothing Then
                    GInfo1 = GraafikConnect.GetPaev(PakettID1, cmbPkt1Tyyp.SelectedIndex)
                    For I = 0 To GInfo1.Count - 1
                        Graafik1.setPoint1(GInfo1.Item(I).Xval, GInfo1.Item(I).Yval)
                    Next
                End If
                If PakettID2 <> Nothing Then
                    GInfo2 = GraafikConnect.GetPaev(PakettID2, cmbPkt2Tyyp.SelectedIndex)
                    For I = 0 To GInfo2.Count - 1
                        Graafik1.setPoint2(GInfo2.Item(I).Xval, GInfo2.Item(I).Yval)
                    Next
                End If
            Case 1
                If PakettID1 <> Nothing Then
                    GInfo1 = GraafikConnect.GetKuu(PakettID1, cmbPkt1Tyyp.SelectedIndex)
                    Console.WriteLine(GInfo1.Count)
                    For I = 0 To GInfo1.Count - 1
                        Graafik1.setPoint1(GInfo1.Item(I).Xval, GInfo1.Item(I).Yval)
                    Next
                End If
                If PakettID2 <> Nothing Then
                    GInfo2 = GraafikConnect.GetKuu(PakettID2, cmbPkt2Tyyp.SelectedIndex)
                    Console.WriteLine(GInfo2.Count)
                    For I = 0 To GInfo2.Count - 1
                        Graafik1.setPoint2(GInfo2.Item(I).Xval, GInfo2.Item(I).Yval)
                    Next
                End If
            Case 2
                If PakettID1 <> Nothing Then
                    GInfo1 = GraafikConnect.GetAasta(PakettID1, cmbPkt1Tyyp.SelectedIndex)
                    For I = 0 To GInfo1.Count - 1
                        Graafik1.setPoint1(GInfo1.Item(I).Xval, GInfo1.Item(I).Yval)
                    Next
                End If
                If PakettID2 <> Nothing Then
                    GInfo2 = GraafikConnect.GetAasta(PakettID2, cmbPkt2Tyyp.SelectedIndex)
                    For I = 0 To GInfo2.Count - 1
                        Graafik1.setPoint2(GInfo2.Item(I).Xval, GInfo2.Item(I).Yval)
                    Next
                End If
        End Select
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
        Console.WriteLine(Tyyp)
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
        Console.WriteLine(Tyyp)
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
End Class