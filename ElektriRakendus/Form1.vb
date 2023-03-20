Imports System.Security.Cryptography

Public Class Form1
    Dim loppHind As Double
    Dim borss As Double = 12.43 'näiteks 3H börsi hind
    Dim lisaHind As Double = 0.684 'senti/kWh
    Dim kindelHind As Double = 30.23 'senti/kWh
    Dim marginaalHind As Double = 15.21
    Dim kuutasu As Double = 11.47
    Dim baasHind As Double = 32.98

    Private Sub btnArvuta_Click(sender As Object, e As EventArgs) Handles btnArvuta.Click
        loppHind = 0 'Lõpphinna algväärtustamine
        Select Case cboxPakett1.SelectedIndex
            Case 0
                'Kontroll, et kasutaja ei valiks algus aega hilem kui lõpp aeg
                If cboxAjavAlgus.SelectedIndex <= cboxAjavLopp.SelectedIndex Then
                    For index As Integer = cboxAjavAlgus.SelectedIndex To cboxAjavLopp.SelectedIndex
                        'Tsükkel, et saaks arvutada mitme tunniga lõpphinda
                        loppHind += borss + lisaHind
                    Next
                    txtLoppHind.Text = loppHind
                    txtLoppHind.Text += "senti/kWh"
                End If
            Case 1
                'Kontroll, et kasutaja ei valiks algus aega hilisemaks kui lõpp aeg
                If cboxAjavAlgus.SelectedIndex <= cboxAjavLopp.SelectedIndex Then
                    For index As Integer = cboxAjavAlgus.SelectedIndex To cboxAjavLopp.SelectedIndex
                        loppHind += kindelHind
                    Next
                    txtLoppHind.Text = loppHind
                    txtLoppHind.Text += "senti/kWh"
                End If
            Case 2

            Case 3
            Case Else
                txtLoppHind.Text = "Pole valitud pakett"
        End Select
    End Sub
End Class
