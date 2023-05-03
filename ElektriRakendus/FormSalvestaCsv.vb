Public Class FormSalvestaCsv
    ' Staatilised muutujad
    Shared FailiNimi As String = Nothing
    Shared FailiPath As String = Nothing
    Shared Exporter As CSVExporterDNF.IExporter = New CSVExporterDNF.CExporter

    ' Akna avamine
    Private Sub FormSalvestaCsv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Raadionupud
        RbSalvestaLoppu.Checked = True
        RbKirjutaYle.Checked = False
        ' Kui faili pole varem valitud, siis niisama salvestada ei saa
        If FailiNimi = Nothing Then
            BtnSave.Enabled = False
        Else
            BtnSave.Enabled = True
        End If
        ' Kuva faili nimi ja asukoht
        LblNimi.Text = FailiNimi
        LblPath.Text = FailiPath
        ' Vaikimisi eraldaja ja kvalifikaator
        TxtEraldaja.Text = ","
        TxtKval.Text = """"
    End Sub
    ' Salvestab graafiku andmed praeguselt valitud CSV faili
    Private Sub SalvestaAndmed(ByRef Exporter As CSVExporterDNF.IExporter)
        ' Leia graafiku pakettide ja hindade arv, ja mis paketid on seal olemas
        Dim PakettideArv = FormMain.Graafik1.NumItems()
        Dim HindadeArv = FormMain.Graafik1.NumPoints()
        Dim RidadeArv = HindadeArv * PakettideArv
        Dim Pakett1Olemas = FormMain.Graafik1.HasItem(0)
        Dim Pakett2Olemas = FormMain.Graafik1.HasItem(1)

        ' Leia pakettide nimed
        Dim Pakett1Nimi As String = Nothing
        Dim Pakett2Nimi As String = Nothing
        If Pakett1Olemas Then Pakett1Nimi = FormMain.cmbPkt1Pkt.Text
        If Pakett2Olemas Then Pakett2Nimi = FormMain.cmbPkt2Pkt.Text

        ' Andmete massiiv
        Dim Andmed(RidadeArv, 2) As String ' (read, väljad)
        ' CSV päis: aeg, pakett, hind (on vaja?)
        Andmed(0, 0) = "aeg"
        Andmed(0, 1) = "pakett"
        Andmed(0, 2) = "hind"

        ' Loe graafiku andmed
        Dim HindIndex = 1
        For Hind As Integer = 1 To HindadeArv
            ' Esimene pakett
            If Pakett1Olemas Then
                Andmed(HindIndex, 0) = FormMain.Graafik1.GetPointX(0, Hind - 1) ' Aeg
                Andmed(HindIndex, 1) = Pakett1Nimi ' Paketi nimi
                Andmed(HindIndex, 2) = Math.Round(FormMain.Graafik1.GetPoint(0, Hind - 1), 2). ' Hind
                                       ToString(Globalization.CultureInfo.InvariantCulture)
                HindIndex += 1
            End If
            ' Teine pakett
            If Pakett2Olemas Then
                Andmed(HindIndex, 0) = FormMain.Graafik1.GetPointX(1, Hind - 1) ' Aeg
                Andmed(HindIndex, 1) = Pakett2Nimi ' Paketi nimi
                Andmed(HindIndex, 2) = Math.Round(FormMain.Graafik1.GetPoint(1, Hind - 1), 2). ' Hind
                                       ToString(Globalization.CultureInfo.InvariantCulture)
                HindIndex += 1
            End If
        Next

        ' Salvesta CSV faili
        Exporter.delimiter = TxtEraldaja.Text
        Exporter.textQualifier = TxtKval.Text
        Exporter.saveDataToCsv(Andmed, RbSalvestaLoppu.Checked)
    End Sub

    ' Vali aknast uus fail ja salvesta CSV fail
    Private Sub BtnSaveAs_Click(sender As Object, e As EventArgs) Handles BtnSaveAs.Click
        ' Kontrolli, kas antud seaded on õiged
        If TxtEraldaja.Text = Nothing Then
            MessageBox.Show("Sisesta CSV eraldaja", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If TxtKval.Text = Nothing Then
            MessageBox.Show("Sisesta CSV kvalifikaator", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Näita Save As dialoogi ja saa sealt fail
        Dim Path = Exporter.setFileToSave()

        ' Kui fail on antud, siis salvesta see
        If Path <> Nothing Then
            ' Kuva uus faili nimi ja asukoht
            FailiPath = Path
            FailiNimi = IO.Path.GetFileName(Path)
            LblNimi.Text = FailiNimi
            LblPath.Text = FailiPath
            ' Nüüd saab ilma valimata salvestada
            BtnSave.Enabled = True

            ' Salvesta fail
            SalvestaAndmed(Exporter)
            Me.Close()
        End If
    End Sub

    ' Salvesta eelnevalt valitud CSV fail
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        ' Kontrolli, kas antud seaded on õiged
        If TxtEraldaja.Text = Nothing Then
            MessageBox.Show("Sisesta CSV eraldaja", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If TxtKval.Text = Nothing Then
            MessageBox.Show("Sisesta CSV kvalifikaator", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Salvesta fail
        SalvestaAndmed(Exporter)
        Me.Close()
    End Sub
End Class