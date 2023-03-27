<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMuudaKodumasin
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
        Me.BtnMuuda = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TxtNimi
        '
        Me.TxtNimi.Location = New System.Drawing.Point(180, 24)
        Me.TxtNimi.Name = "TxtNimi"
        Me.TxtNimi.Size = New System.Drawing.Size(245, 26)
        Me.TxtNimi.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(131, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 20)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Nimi"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtAeg
        '
        Me.TxtAeg.Location = New System.Drawing.Point(180, 125)
        Me.TxtAeg.Name = "TxtAeg"
        Me.TxtAeg.Size = New System.Drawing.Size(245, 26)
        Me.TxtAeg.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 20)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Kasutuse aeg (min)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtVoimsus
        '
        Me.TxtVoimsus.Location = New System.Drawing.Point(180, 74)
        Me.TxtVoimsus.Name = "TxtVoimsus"
        Me.TxtVoimsus.Size = New System.Drawing.Size(245, 26)
        Me.TxtVoimsus.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(75, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 20)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Võimsus (W)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnMuuda
        '
        Me.BtnMuuda.Location = New System.Drawing.Point(149, 184)
        Me.BtnMuuda.Name = "BtnMuuda"
        Me.BtnMuuda.Size = New System.Drawing.Size(164, 33)
        Me.BtnMuuda.TabIndex = 14
        Me.BtnMuuda.Text = "Muuda kodumasinat"
        Me.BtnMuuda.UseVisualStyleBackColor = True
        '
        'FormMuudaKodumasin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 231)
        Me.Controls.Add(Me.TxtNimi)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtAeg)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtVoimsus)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnMuuda)
        Me.Name = "FormMuudaKodumasin"
        Me.Text = "Muuda kodumasinat"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtNimi As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtAeg As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtVoimsus As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnMuuda As Button
End Class
