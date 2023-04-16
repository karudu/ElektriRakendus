<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOdavadAjad
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CbKestus = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DtpKuupaev = New System.Windows.Forms.DateTimePicker()
        Me.TxtLoppAeg = New System.Windows.Forms.TextBox()
        Me.TxtAlgusAeg = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnGo = New System.Windows.Forms.Button()
        Me.RtxAjad = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'CbKestus
        '
        Me.CbKestus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbKestus.FormattingEnabled = True
        Me.CbKestus.Items.AddRange(New Object() {"1 h", "2 h", "3 h", "4 h", "5 h", "6 h", "7 h", "8 h", "9 h", "10 h", "11 h", "12 h"})
        Me.CbKestus.Location = New System.Drawing.Point(135, 19)
        Me.CbKestus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CbKestus.Name = "CbKestus"
        Me.CbKestus.Size = New System.Drawing.Size(178, 24)
        Me.CbKestus.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Laadimise kestus:"
        '
        'DtpKuupaev
        '
        Me.DtpKuupaev.Location = New System.Drawing.Point(135, 46)
        Me.DtpKuupaev.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DtpKuupaev.Name = "DtpKuupaev"
        Me.DtpKuupaev.Size = New System.Drawing.Size(178, 22)
        Me.DtpKuupaev.TabIndex = 4
        '
        'TxtLoppAeg
        '
        Me.TxtLoppAeg.Location = New System.Drawing.Point(135, 98)
        Me.TxtLoppAeg.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtLoppAeg.Name = "TxtLoppAeg"
        Me.TxtLoppAeg.Size = New System.Drawing.Size(106, 22)
        Me.TxtLoppAeg.TabIndex = 5
        Me.TxtLoppAeg.Text = "23:59"
        '
        'TxtAlgusAeg
        '
        Me.TxtAlgusAeg.Location = New System.Drawing.Point(135, 72)
        Me.TxtAlgusAeg.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtAlgusAeg.Name = "TxtAlgusAeg"
        Me.TxtAlgusAeg.Size = New System.Drawing.Size(106, 22)
        Me.TxtAlgusAeg.TabIndex = 6
        Me.TxtAlgusAeg.Text = "00:00"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(63, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Kuupäev:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(83, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Algus:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(86, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Lõpp:"
        '
        'BtnGo
        '
        Me.BtnGo.Location = New System.Drawing.Point(135, 133)
        Me.BtnGo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnGo.Name = "BtnGo"
        Me.BtnGo.Size = New System.Drawing.Size(157, 31)
        Me.BtnGo.TabIndex = 10
        Me.BtnGo.Text = "Leia ajavahemikud"
        Me.BtnGo.UseVisualStyleBackColor = True
        '
        'RtxAjad
        '
        Me.RtxAjad.Location = New System.Drawing.Point(340, 19)
        Me.RtxAjad.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RtxAjad.Name = "RtxAjad"
        Me.RtxAjad.Size = New System.Drawing.Size(183, 320)
        Me.RtxAjad.TabIndex = 11
        Me.RtxAjad.Text = ""
        '
        'FormOdavadAjad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(537, 345)
        Me.Controls.Add(Me.RtxAjad)
        Me.Controls.Add(Me.BtnGo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtAlgusAeg)
        Me.Controls.Add(Me.TxtLoppAeg)
        Me.Controls.Add(Me.DtpKuupaev)
        Me.Controls.Add(Me.CbKestus)
        Me.Controls.Add(Me.Label2)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FormOdavadAjad"
        Me.Text = "Leia odavaimad ajavahemikud"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CbKestus As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DtpKuupaev As DateTimePicker
    Friend WithEvents TxtLoppAeg As TextBox
    Friend WithEvents TxtAlgusAeg As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents BtnGo As Button
    Friend WithEvents RtxAjad As RichTextBox
End Class
