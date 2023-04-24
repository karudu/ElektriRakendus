﻿Imports System.IO
Imports PrjAndmebaas
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Security.Cryptography
Imports System.Windows.Forms.LinkLabel

Public Class Form1

    Dim lopp As Date
    Dim Algus As Date
    Dim nupp As Boolean



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ofd As OpenFileDialog = New OpenFileDialog() With {.Filter = "Text file|*.CSV"}
        If ofd.ShowDialog() = DialogResult.OK Then
            Dim CSV As List(Of Class1) = New List(Of Class1)
            Dim lines As List(Of String) = File.ReadAllLines(ofd.FileName).ToList
            Dim h As Integer = 1
            Dim c As Integer
            nupp = True
            For i As Integer = 1 To lines.Count - 1

                Dim data As String() = lines(i).Split(",")
                Dim isValidDate As Boolean = IsDate(data(0))
                If isValidDate = False Then
                    MessageBox.Show("CSV failis pole on vigane kuupäev ", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    MessageBox.Show("Vigane osa" + data(0) + "viga asub real" + (i + 1).ToString, "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If IsNumeric(data(1)) = False Then
                    MessageBox.Show("CSV failis pole on vigane võimsus ", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    MessageBox.Show(" Vigane osa" + data(1) + "viga asub real" + (i + 1).ToString, "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                CSV.Add(New Class1() With {
                   .Kuupäev = data(0),
                    .Voimsus_kWh = data(1)
                })
                If i = h Then
                    lopp = data(0)
                End If
                If h = 1 Then
                    Algus = data(0)

                End If
                h = h + 1
            Next
            DataGridView1.DataSource = CSV

        End If



    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddPaketiTyybid()
        Graafik1.InitGraph1()
        UuendaPaketid()
    End Sub

    Private Sub cmbPkt1Tyyp_DropDownClosed(sender As Object, e As EventArgs) Handles cmbPkt1Tyyp.DropDownClosed
        cmbPkt1Pkt.Items.Clear()
        AddPaketid1(cmbPkt1Tyyp.SelectedIndex)
    End Sub
    Private Sub cmbPkt2Tyyp_DropDownClosed(sender As Object, e As EventArgs) Handles cmbPkt2Tyyp.DropDownClosed
        cmbPkt2Pkt.Items.Clear()
        AddPaketid2(cmbPkt2Tyyp.SelectedIndex)
    End Sub

    Private Sub AddPaketiTyybid()
        cmbPkt1Tyyp.Items.Add("Börsi")
        cmbPkt1Tyyp.Items.Add("Fikseeritud")
        cmbPkt1Tyyp.Items.Add("Universaal")
        cmbPkt2Tyyp.Items.Add("Börsi")
        cmbPkt2Tyyp.Items.Add("Fikseeritud")
        cmbPkt2Tyyp.Items.Add("Universaal")
    End Sub

    Private Sub UuendaPaketid()
        Dim GInfo1 As List(Of (Xval As String, Yval As Decimal))
        Dim GInfo2 As List(Of (Xval As String, Yval As Decimal))
        Dim GraafikConnect As GraafikControl.IGraafikInfo
        GraafikConnect = New GraafikControl.CGraafikInfo
        Dim GInfo1Kesk As Decimal
        Dim GInfo2Kesk As Decimal
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
        Dim h As Integer = 1



        Dim I As Integer


        If PakettID1 <> Nothing Then
            GInfo1 = GraafikConnect.GetCustom(PakettID1, cmbPkt1Tyyp.SelectedIndex, Algus, lopp)
            Console.WriteLine(GInfo1.Count)
            For I = 0 To GInfo1.Count - 1
                Console.WriteLine(GInfo1.Item(I).Xval)
                Console.WriteLine(GInfo1.Item(I).Yval)
                Graafik1.setPoint1(GInfo1.Item(I).Xval, (GInfo1.Item(I).Yval * CDec(DataGridView1.Rows(I).Cells(1).Value.ToString()) / 100))
                GInfo1Kesk += GInfo1.Item(I).Yval * CDec(DataGridView1.Rows(I).Cells(1).Value.ToString()) / 100
            Next
            GInfo1Kesk = GInfo1Kesk / GInfo1.Count
            lblPkt1Kesk.Text = GInfo1Kesk.ToString("N2") + " €/kWh"
        End If


        If PakettID2 <> Nothing Then
            GInfo2 = GraafikConnect.GetCustom(PakettID2, cmbPkt2Tyyp.SelectedIndex, Algus, lopp)
            Console.WriteLine(GInfo2.Count)
            For I = 0 To GInfo2.Count - 1

                Graafik1.setPoint2(GInfo2.Item(I).Xval, (GInfo2.Item(I).Yval * CDec(DataGridView1.Rows(I).Cells(1).Value.ToString()) / 100))
                GInfo2Kesk += (GInfo2.Item(I).Yval * CDec(DataGridView1.Rows(I).Cells(1).Value.ToString()) / 100)
            Next
            GInfo2Kesk = GInfo2Kesk / GInfo2.Count
            lblPkt2Kesk.Text = GInfo2Kesk.ToString("N2") + " €/kWh"
        End If


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

    Private Sub Graafik1_Load(sender As Object, e As EventArgs) Handles Graafik1.Load

    End Sub

    Private Sub cmbPkt1Pkt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPkt1Pkt.SelectedIndexChanged
        If nupp = True Then
            UuendaPaketid()
        Else
            MessageBox.Show("Pole sisestatud CSV fail", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


    End Sub

    Private Sub cmbPkt2Pkt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPkt2Pkt.SelectedIndexChanged
        If nupp = True Then
            UuendaPaketid()
        Else
            MessageBox.Show("Pole sisestatud CSV fail", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class


