Imports System.IO
Imports PrjAndmebaas
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Security.Cryptography
Imports System.Windows.Forms.LinkLabel
Imports System.Net.Security
Imports System.Reflection

Public Class Form1

    Dim lopp As Date
    Dim Algus As Date
    Dim nupp As Boolean



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim CSV As PakketideSim.Interface1
        CSV = New PakketideSim.Class1
        Dim Gcsv1 As List(Of (Kuupäev As String, Voimsus_kWh As Decimal))
        Dim ofd As OpenFileDialog = New OpenFileDialog() With {.Filter = "Text file|*.CSV"}
        Dim table As New DataTable()
        table.Columns.Add("FirstName", GetType(String))
        table.Columns.Add("Voimsus", GetType(Decimal))
        nupp = True

        'If ofd.ShowDialog() = DialogResult.OK Then
        '    Dim CS As List(Of Class1) = New List(Of Class1)
        '    Dim lines As List(Of String) = File.ReadAllLines(ofd.FileName).ToList
        '    Dim h As Integer = 1

        '   
        '    For i As Integer = 1 To lines.Count - 1

        '        Dim data As String() = lines(i).Split(",")
        '        Dim isValidDate As Boolean = IsDate(data(0))
        '        If isValidDate = False Then 'kontroll kas kuupäeval on korektne forormaat'

        '            MessageBox.Show("CSV failis on vigane kuupäev ", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            MessageBox.Show(" Vigane osa " + data(0) + " viga asub real" + (i + 1).ToString, "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            Exit Sub
        '        End If
        '        If IsNumeric(data(1)) = False Then 'kontroll kas võõimsuses on numbrid ikka'
        '            MessageBox.Show("CSV failis on vigane võimsus ", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            MessageBox.Show(" Vigane osa " + data(1) + " viga asub real" + (i + 1).ToString, "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            Exit Sub
        '        End If


        '        CS.Add(New Class1() With {'lisab andmed  DataGridView1'
        '        .Kuupäev = data(0),'lisab kuupaeva  DataGridView1'
        '            .Voimsus_kWh = data(1)'lisab voimsuse  DataGridView1'
        '        })
        '        If i = h Then
        '            lopp = data(0)
        '        End If
        '        If h = 1 Then
        '            Algus = data(0)

        '        End If
        '        h = h + 1
        '    Next
        '    ''DataGridView1.DataSource = CS


        'End If

        If ofd.ShowDialog() = DialogResult.OK Then
            Dim lines As List(Of String) = File.ReadAllLines(ofd.FileName).ToList
            Gcsv1 = CSV.LoeCSV(lines, ofd)
            For i As Integer = 1 To Gcsv1.Count - 1
                table.Rows.Add({Gcsv1.Item(i).Kuupäev, Gcsv1.Item(i).Voimsus_kWh})
                If i = 1 Then
                    Algus = Gcsv1.Item(i).Kuupäev
                End If
                If i = Gcsv1.Count - 1 Then
                    lopp = Gcsv1.Item(i).Kuupäev
                End If


            Next
            DataGridView1.DataSource = table
            Console.WriteLine(lopp)
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
        'comboboxi varjandi lisamine
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


        If PakettID1 <> Nothing Then 'vormistab pakett 1 graafiku
            GInfo1 = GraafikConnect.GetCustom(PakettID1, cmbPkt1Tyyp.SelectedIndex, Algus, lopp)
            Console.WriteLine(GInfo1.Count)
            For I = 0 To GInfo1.Count - 1

                Dim kuupaev1 As Date = DataGridView1.Rows(I).Cells(0).Value.ToString()
                Dim kuupaev2 As Date
                Console.WriteLine(DataGridView1.Rows(I).Cells(0).Value.ToString())

                If Not (DateTime.Compare(kuupaev1, kuupaev2.AddDays(1)) = 0) And Not I = 0 Then

                    TextBox1.Text = kuupaev1
                    MessageBox.Show("CSV failis kuupaevad pole jarjestiku  ", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    MessageBox.Show("viga asub real " + (I).ToString, "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                kuupaev2 = kuupaev1
                Console.WriteLine(GInfo1.Item(I).Xval)
                Console.WriteLine(GInfo1.Item(I).Yval)
                Graafik1.setPoint1(GInfo1.Item(I).Xval, (GInfo1.Item(I).Yval * CDec(DataGridView1.Rows(I).Cells(1).Value.ToString()) / 100))
                GInfo1Kesk += GInfo1.Item(I).Yval * CDec(DataGridView1.Rows(I).Cells(1).Value.ToString()) / 100
            Next

            GInfo1Kesk = GInfo1Kesk / GInfo1.Count
            lblPkt1Kesk.Text = GInfo1Kesk.ToString("N2") + " €/kWh"
        End If


        If PakettID2 <> Nothing Then 'vormistab pakett 2 graafiku
            GInfo2 = GraafikConnect.GetCustom(PakettID2, cmbPkt2Tyyp.SelectedIndex, Algus, lopp)
            Console.WriteLine(GInfo2.Count)
            For I = 0 To GInfo2.Count - 1
                Dim kuupaev1 As Date = DataGridView1.Rows(I).Cells(0).Value.ToString()
                Dim kuupaev2 As Date
                If Not (DateTime.Compare(kuupaev1, kuupaev2.AddDays(1)) = 0) And Not I = 0 Then
                    Exit Sub
                End If
                kuupaev2 = kuupaev1

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

    Private Sub AddPaketid1(ByVal Tyyp As Integer) 'vormistab pakett 1 comboboxi koik paketid valitud elemendi puhul
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
End Class


