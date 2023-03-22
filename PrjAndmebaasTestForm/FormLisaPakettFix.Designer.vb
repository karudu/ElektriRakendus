<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLisaPakettFix
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
        Me.TxtKuutasu = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtPTariif = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnLisa = New System.Windows.Forms.Button()
        Me.TxtOTariif = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TxtNimi
        '
        Me.TxtNimi.Location = New System.Drawing.Point(191, 34)
        Me.TxtNimi.Name = "TxtNimi"
        Me.TxtNimi.Size = New System.Drawing.Size(245, 26)
        Me.TxtNimi.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(137, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 20)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Nimi"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtKuutasu
        '
        Me.TxtKuutasu.Location = New System.Drawing.Point(191, 184)
        Me.TxtKuutasu.Name = "TxtKuutasu"
        Me.TxtKuutasu.Size = New System.Drawing.Size(245, 26)
        Me.TxtKuutasu.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(94, 187)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 20)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Kuutasu (€)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtPTariif
        '
        Me.TxtPTariif.Location = New System.Drawing.Point(191, 84)
        Me.TxtPTariif.Name = "TxtPTariif"
        Me.TxtPTariif.Size = New System.Drawing.Size(245, 26)
        Me.TxtPTariif.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 20)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Päevatariif (senti/kWh)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnLisa
        '
        Me.BtnLisa.Location = New System.Drawing.Point(141, 235)
        Me.BtnLisa.Name = "BtnLisa"
        Me.BtnLisa.Size = New System.Drawing.Size(164, 33)
        Me.BtnLisa.TabIndex = 7
        Me.BtnLisa.Text = "Lisa uus pakett"
        Me.BtnLisa.UseVisualStyleBackColor = True
        '
        'TxtOTariif
        '
        Me.TxtOTariif.Location = New System.Drawing.Point(191, 134)
        Me.TxtOTariif.Name = "TxtOTariif"
        Me.TxtOTariif.Size = New System.Drawing.Size(245, 26)
        Me.TxtOTariif.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(41, 137)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 20)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Öötariif (senti/kWh)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FormLisaPakettFix
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 296)
        Me.Controls.Add(Me.TxtOTariif)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtNimi)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtKuutasu)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtPTariif)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnLisa)
        Me.Name = "FormLisaPakettFix"
        Me.Text = "Lisa fikseeritud pakett"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtNimi As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtKuutasu As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtPTariif As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnLisa As Button
    Friend WithEvents TxtOTariif As TextBox
    Friend WithEvents Label4 As Label
End Class
