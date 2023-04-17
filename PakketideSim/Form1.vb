Imports System.IO
Imports PrjAndmebaas
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Security.Cryptography

Public Class Form1

    Dim lopp As Date
    Dim Algus As Date
    Dim ofd As OpenFileDialog = New OpenFileDialog() With {.Filter = "Text file|*.CSV"}
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If ofd.ShowDialog() = DialogResult.OK Then
            Dim lines As List(Of String) = File.ReadAllLines(ofd.FileName).ToList
            Dim h As Integer = 1
            Dim j As Integer = lines.Count
            Dim CSV As List(Of Class1) = New List(Of Class1)
            For i As Integer = 1 To lines.Count - 1

                Dim data As String() = lines(i).Split(",")
                CSV.Add(New Class1() With {
                    .dateS = data(0),
                    .Voimsus = data(1)
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
        TextBox1.Text = Algus



    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddPaketiTyybid()
        Graafik1.InitGraph()
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
End Class


