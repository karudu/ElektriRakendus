<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMuudaPakettUniv
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
        Me.TxtMarginaal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtNimi = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtKuutasu = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtBaas = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnLisa = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TxtMarginaal
        '
        Me.TxtMarginaal.Location = New System.Drawing.Point(229, 110)
        Me.TxtMarginaal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtMarginaal.Name = "TxtMarginaal"
        Me.TxtMarginaal.Size = New System.Drawing.Size(218, 22)
        Me.TxtMarginaal.TabIndex = 33
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(189, 16)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Pakkuja marginaal (senti/kWh)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtNimi
        '
        Me.TxtNimi.Location = New System.Drawing.Point(229, 30)
        Me.TxtNimi.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtNimi.Name = "TxtNimi"
        Me.TxtNimi.Size = New System.Drawing.Size(218, 22)
        Me.TxtNimi.TabIndex = 31
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(189, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 16)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Nimi"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtKuutasu
        '
        Me.TxtKuutasu.Location = New System.Drawing.Point(229, 150)
        Me.TxtKuutasu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtKuutasu.Name = "TxtKuutasu"
        Me.TxtKuutasu.Size = New System.Drawing.Size(218, 22)
        Me.TxtKuutasu.TabIndex = 29
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(143, 153)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Kuutasu (€)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtBaas
        '
        Me.TxtBaas.Location = New System.Drawing.Point(229, 70)
        Me.TxtBaas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtBaas.Name = "TxtBaas"
        Me.TxtBaas.Size = New System.Drawing.Size(218, 22)
        Me.TxtBaas.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(82, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 16)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Baashind (senti/kWh)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnLisa
        '
        Me.BtnLisa.Location = New System.Drawing.Point(164, 191)
        Me.BtnLisa.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnLisa.Name = "BtnLisa"
        Me.BtnLisa.Size = New System.Drawing.Size(146, 26)
        Me.BtnLisa.TabIndex = 25
        Me.BtnLisa.Text = "Muuda paketti"
        Me.BtnLisa.UseVisualStyleBackColor = True
        '
        'FormMuudaPakettUniv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 238)
        Me.Controls.Add(Me.TxtMarginaal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtNimi)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtKuutasu)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtBaas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnLisa)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FormMuudaPakettUniv"
        Me.Text = "Muuda universaalpaketti"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtMarginaal As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtNimi As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtKuutasu As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtBaas As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnLisa As Button
End Class
