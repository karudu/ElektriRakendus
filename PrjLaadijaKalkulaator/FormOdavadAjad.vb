Imports PrjAndmebaas

Public Class FormOdavadAjad
    Private Sub BtnGo_Click(sender As Object, e As EventArgs) Handles BtnGo.Click
        If CbKestus.SelectedItem = Nothing Then
            MessageBox.Show("Vali laadimise kestus", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim Andmebaas As New CAndmebaas
        Dim Kuupaev As Date = DtpKuupaev.Value
        Kuupaev = New Date(Kuupaev.Year, Kuupaev.Month, Kuupaev.Day, 0, 0, 0)
        Dim AlgusAeg As Date = Date.ParseExact(TxtAlgusAeg.Text, "HH:mm", Nothing)
        Dim Algus As New Date(Kuupaev.Year, Kuupaev.Month, Kuupaev.Day,
                              AlgusAeg.Hour, AlgusAeg.Minute, AlgusAeg.Second)
        Dim LoppAeg As Date = Date.ParseExact(TxtLoppAeg.Text, "HH:mm", Nothing)
        Dim Lopp As New Date(Kuupaev.Year, Kuupaev.Month, Kuupaev.Day,
                              LoppAeg.Hour, LoppAeg.Minute, LoppAeg.Second)
        Dim Kestus = CbKestus.SelectedIndex + 1
        Dim Kestus15 = Kestus * 4
        Dim KestusAeg = New TimeSpan(Kestus, 0, 0)

        If Not Algus.Minute Mod 15 = 0 Then
            Algus = Algus.AddMinutes(-(Algus.Minute Mod 15))
            TxtAlgusAeg.Text = Algus.ToString("HH:mm")
        End If
        If (Not Lopp.Minute Mod 15 = 0) And
           Not (Lopp.Hour = 23 And Lopp.Minute = 59) Then
            Lopp = Lopp.AddMinutes(-(Lopp.Minute Mod 15))
            TxtLoppAeg.Text = Lopp.ToString("HH:mm")
        End If

        Dim Borsihinnad As New List(Of Decimal)
        Try
            Borsihinnad = Andmebaas.LoeBorsihinnadSentkWh(Kuupaev, 24)
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Aeg As Date = AlgusAeg
        Dim Ajad As New List(Of (Nimi As String, Hind As Decimal))
        While True
            Dim Hind As Decimal = 0
            If Aeg + KestusAeg > LoppAeg Then Exit While

            Dim ArvutaAeg = Aeg
            For i = 0 To Kestus15 - 1
                Hind += Borsihinnad(ArvutaAeg.Hour) / 4
                ArvutaAeg = ArvutaAeg.AddMinutes(15)
            Next

            Ajad.Add((Aeg.ToString("HH:mm") & " - " & (Aeg + KestusAeg).ToString("HH:mm"),
                     Hind))
            Aeg = Aeg.AddMinutes(15)
        End While

        Ajad = Ajad.OrderBy(Function(X) X.Hind).ToList
        RtxAjad.Clear()
        For Each A In Ajad
            RtxAjad.AppendText(A.Nimi & " (" & Math.Round(A.Hind, 2).ToString &
                                  ")" & Environment.NewLine)
        Next
    End Sub
End Class