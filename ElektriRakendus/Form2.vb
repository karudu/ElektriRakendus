Imports System.Diagnostics.Eventing.Reader
Imports PrjAndmebaas

Public Class Form2

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UuendaPaketid()
    End Sub
    Private Sub UuendaPaketid()
        Dim Paketid As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
        Dim Andmebaas As New CAndmebaas
        Paketid = Andmebaas.LoePakettideNimekiri
        ListBors.Items.Clear()
        Select Case ComboBox2.SelectedIndex
            Case 0
                For Each Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp) In Paketid
                    Select Case Pakett.Tyyp
                        Case IAndmebaas.PaketiTyyp.PAKETT_BORS
                            Dim PakettBors As New IAndmebaas.PkBors
                            PakettBors = Andmebaas.LoePakettBors(Pakett.ID)
                            Dim Item As New ListViewItem(PakettBors.Nimi)
                            Item.SubItems.Add(Math.Round(PakettBors.Juurdetasu, 2).ToString & " senti/kWh")
                            Item.SubItems.Add("€" & Math.Round(PakettBors.Kuutasu, 2).ToString)
                            Item.SubItems.Add(0)
                            Item.SubItems.Add(Pakett.ID)
                            ListBors.Items.Add(Item)
                    End Select
                    ' ID on subitem 4
                    ' CInt(ListBors.Items(i).SubItems(4).Text)
                Next
            Case 1
                ' For Each Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp) In Paketid
                'Select Case Pakett.Tyyp
                'Case IAndmebaas.PaketiTyyp.PAKETT_FIX
                ' Dim PakettFix As New IAndmebaas.PkFix
                ' PakettFix = Andmebaas.LoePakettFix(Pakett.ID)
                ' Dim Item As New ListViewItem(PakettFix.Nimi)
                'Item.SubItems.Add(Math.Round(PakettFix.PTariif, 2).ToString & " senti/kWh")
                ' Item.SubItems.Add(Math.Round(PakettFix.OTariif, 2).ToString & " senti/kWh")
                'Item.SubItems.Add("€" & Math.Round(PakettFix.Kuutasu, 2).ToString)
                'Item.SubItems.Add(Pakett.ID)
                'ListBors.Items.Add(Item)
                'End Select
                'Next
            Case 2
                ' For Each Pakett As (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp) In Paketid
                'Select Case Pakett.Tyyp
                'Case IAndmebaas.PaketiTyyp.PAKETT_UNIV
                'Dim PakettUniv As New IAndmebaas.PkUniv
                'PakettUniv = Andmebaas.LoePakettUniv(Pakett.ID)
                'Dim Item As New ListViewItem(PakettUniv.Nimi)
                'Item.SubItems.Add(Math.Round(PakettUniv.Baas, 2).ToString & " senti/kWh")
                'Item.SubItems.Add(Math.Round(PakettUniv.Marginaal, 2).ToString & " senti/kWh")
                'Item.SubItems.Add("€" & Math.Round(PakettUniv.Kuutasu, 2).ToString)
                'Item.SubItems.Add(Pakett.ID)
                'ListBors.Items.Add(Item)
                'End Select
                ' Next

        End Select
        Dim sadasd As Integer = 0
    End Sub


    Private Sub tootle(ByRef Kalkulaator As Kalkulaator)
        TextBox4.Text = Kalkulaator.Rahalinekulu
    End Sub
    Private Sub Arvuta_Click(sender As Object, e As EventArgs) Handles Arvuta.Click
        UuendaPaketid()
        If Not ListBors.SelectedItems.Count = 0 Then
            Exit Sub

        End If
        Select Case ComboBox2.SelectedIndex
                Case 0
                    Dim Andmebaas As New CAndmebaas
                    Dim Pakett As New IAndmebaas.PkBors
                    Dim ID As Integer
                ID = CInt(ListBors.SelectedItems(0).SubItems(4).Text) ' ID on subitem 4
                Pakett = Andmebaas.LoePakettBors(ID)
                Dim KodumasinaKasutus As New KodumasinaKasutus(Pakett.Kuutasu, TextBox1.Text, KasutusAeg.Text)
                TextBox4.Text = ID
                'tootle(KodumasinaKasutus)
            Case 1
                    Dim Andmebaas As New CAndmebaas
                    Dim Pakett As New IAndmebaas.PkFix
                    Dim ID As Integer
                ID = CInt(ListBors.SelectedItems(0).SubItems(4).Text) ' ID on subitem 4
                Pakett = Andmebaas.LoePakettFix(ID)
                Dim KodumasinaKasutus As New KodumasinaKasutus(Pakett.Kuutasu, TextBox1.Text, KasutusAeg.Text)

            Case 2

                    ''Dim Andmebaas As New CAndmebaas
                    ''Dim Pakett As New IAndmebaas.PkUniv
                    ''Dim ID As Integer
                    ''ID = CInt(ListBors.SelectedItems(0).SubItems(4).Text) ' ID on subitem 4
                    'Pakett = Andmebaas.LoePakettUniv(ID)
                    'Dim KodumasinaKasutus As New KodumasinaKasutus(Pakett.Kuutasu, SeadmeV.Text, KasutusAeg.Text)
                    ''tootle(KodumasinaKasutus)
            End Select


        'If IsNumeric(SeadmeV.Text) = True And IsNumeric(KasutusAeg.Text) = True Then


        ''Dim KodumasinaKasutus As New KodumasinaKasutus(TextBox1.Text, SeadmeV.Text, KasutusAeg.Text)
        ''tootle(KodumasinaKasutus)

    End Sub

    Private Sub ListBors_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBors.SelectedIndexChanged

    End Sub

    Private Sub KasutusAeg_TextChanged(sender As Object, e As EventArgs) Handles KasutusAeg.TextChanged
        UuendaPaketid()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        UuendaPaketid()
    End Sub
End Class