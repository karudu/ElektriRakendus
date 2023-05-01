Imports PrjAndmebaas

Public Class FormLopphind
    'FAILINIMI: FormLopphind.vb
    'AUTOR: Carl Strömberg
    'LOODUD: 20.03.2023
    'MUUDETUD: 01.05.2023
    '
    'KIRJELDUS: See klass on Lõpphind nüüd ja Börsitrendid kasutajaloode jaoks mõeldud form. 
    '           Selle klassi abil saab näha valitud paketi arvutatud hetket ja tuleviku lõpphinda.

    'EELTINGIMUSED: On olemas ühendus andmebaasiga ja andmebaasist on loetud kõik olevad paketid.
    '

    Dim Paketid As New List(Of (ID As Integer, Nimi As String, Tyyp As IAndmebaas.PaketiTyyp))
    Dim ConnectDb As New CAndmebaas
    Public StructBors As New PrjAndmebaas.IAndmebaas.PkBors
    Public StructFix As New PrjAndmebaas.IAndmebaas.PkFix
    Public StructUniv As New PrjAndmebaas.IAndmebaas.PkUniv
    Public PktType As New PrjAndmebaas.IAndmebaas.PaketiTyyp

    'Laeb kõik paketid andmebaasist ComboBox-i ning algselt
    'kustutab samast ComboBox-ist kõik Item-id ja paneb ajavahemiku
    'ComboBox-i ja Labeli nähtavuse vääraks.
    'Sisendparameetrid: sender, e
    Private Sub FormLopphind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Index As Integer

        lblAjavLopp.Visible = False
        cboxALTund.Visible = False
        cboxALTund.Items.Clear()
        cboxPakett1.Items.Clear()

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
    Private Sub btnArvuta_Click(sender As Object, e As EventArgs) Handles btnArvuta.Click
        Dim Index As Integer
        Dim GInfo As List(Of (Xval As String, Yval As Decimal))
        Dim GetInfo As GraafikControl.IGraafikInfo
        GetInfo = New GraafikControl.CGraafikInfo
        txtLoppHind.Text = Nothing
        PktType = -1

        'Kustutab graafikul eelnevalt joonistatud graafik
        'Sub ClearPoints võetud Graafik.vb-st
        Graafik1.ClearPoints()

        'Loop selleks, et leida cboxPakett1 valitud paketi paketi tüübi(PktType)
        For Index = 0 To Paketid.Count - 1
            If Paketid(Index).ID <> Nothing Then
                If cboxPakett1.Text = Paketid(Index).Nimi Then
                    PktType = Paketid(Index).Tyyp
                    Exit For
                End If
            End If
        Next

        'If lause selleks, et tuvastada, kas paketti on valitud ComboBoxi-st või mitte
        If PktType <> -1 Then

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
    End Sub
End Class

