<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLisaKodumasin
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
        Me.TxtNimi = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtAeg = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtVoimsus = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnLisa = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TxtNimi
        '
        Me.TxtNimi.Location = New System.Drawing.Point(149, 23)
        Me.TxtNimi.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtNimi.Name = "TxtNimi"
        Me.TxtNimi.Size = New System.Drawing.Size(218, 22)
        Me.TxtNimi.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(106, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Nimi"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtAeg
        '
        Me.TxtAeg.Location = New System.Drawing.Point(149, 104)
        Me.TxtAeg.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtAeg.Name = "TxtAeg"
        Me.TxtAeg.Size = New System.Drawing.Size(218, 22)
        Me.TxtAeg.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Kasutuse aeg (min)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtVoimsus
        '
        Me.TxtVoimsus.Location = New System.Drawing.Point(149, 63)
        Me.TxtVoimsus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtVoimsus.Name = "TxtVoimsus"
        Me.TxtVoimsus.Size = New System.Drawing.Size(218, 22)
        Me.TxtVoimsus.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(56, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Võimsus (W)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnLisa
        '
        Me.BtnLisa.Location = New System.Drawing.Point(122, 151)
        Me.BtnLisa.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnLisa.Name = "BtnLisa"
        Me.BtnLisa.Size = New System.Drawing.Size(146, 26)
        Me.BtnLisa.TabIndex = 7
        Me.BtnLisa.Text = "Lisa uus kodumasin"
        Me.BtnLisa.UseVisualStyleBackColor = True
        '
        'FormLisaKodumasin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(387, 198)
        Me.Controls.Add(Me.TxtNimi)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtAeg)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtVoimsus)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnLisa)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FormLisaKodumasin"
        Me.Text = "Lisa kodumasin"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtNimi As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtAeg As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtVoimsus As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnLisa As Button
End Class
