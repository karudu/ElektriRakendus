<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLopphind
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
        Me.Graafik1 = New GraafikControl.Graafik()
        Me.btnArvuta = New System.Windows.Forms.Button()
        Me.lblAjavLopp = New System.Windows.Forms.Label()
        Me.cboxALTund = New System.Windows.Forms.ComboBox()
        Me.cboxPakett1 = New System.Windows.Forms.ComboBox()
        Me.lblPakett1 = New System.Windows.Forms.Label()
        Me.lblLoppHind = New System.Windows.Forms.Label()
        Me.txtLoppHind = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Graafik1
        '
        Me.Graafik1.Location = New System.Drawing.Point(1, 243)
        Me.Graafik1.Name = "Graafik1"
        Me.Graafik1.Size = New System.Drawing.Size(1262, 363)
        Me.Graafik1.TabIndex = 53
        '
        'btnArvuta
        '
        Me.btnArvuta.Location = New System.Drawing.Point(20, 79)
        Me.btnArvuta.Name = "btnArvuta"
        Me.btnArvuta.Size = New System.Drawing.Size(75, 23)
        Me.btnArvuta.TabIndex = 52
        Me.btnArvuta.Text = "Arvuta"
        Me.btnArvuta.UseVisualStyleBackColor = True
        '
        'lblAjavLopp
        '
        Me.lblAjavLopp.AutoSize = True
        Me.lblAjavLopp.Location = New System.Drawing.Point(154, 28)
        Me.lblAjavLopp.Name = "lblAjavLopp"
        Me.lblAjavLopp.Size = New System.Drawing.Size(135, 16)
        Me.lblAjavLopp.TabIndex = 51
        Me.lblAjavLopp.Text = "Valige kindla aja hind"
        '
        'cboxALTund
        '
        Me.cboxALTund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxALTund.FormattingEnabled = True
        Me.cboxALTund.Location = New System.Drawing.Point(157, 47)
        Me.cboxALTund.Name = "cboxALTund"
        Me.cboxALTund.Size = New System.Drawing.Size(75, 24)
        Me.cboxALTund.TabIndex = 50
        '
        'cboxPakett1
        '
        Me.cboxPakett1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxPakett1.FormattingEnabled = True
        Me.cboxPakett1.Items.AddRange(New Object() {"Börsihind", "Fikseeritud hind", "Universaalteenus", "Universaalteenusega seotud pakett"})
        Me.cboxPakett1.Location = New System.Drawing.Point(20, 47)
        Me.cboxPakett1.Name = "cboxPakett1"
        Me.cboxPakett1.Size = New System.Drawing.Size(121, 24)
        Me.cboxPakett1.TabIndex = 49
        '
        'lblPakett1
        '
        Me.lblPakett1.AutoSize = True
        Me.lblPakett1.Location = New System.Drawing.Point(17, 28)
        Me.lblPakett1.Name = "lblPakett1"
        Me.lblPakett1.Size = New System.Drawing.Size(55, 16)
        Me.lblPakett1.TabIndex = 48
        Me.lblPakett1.Text = "Pakett 1"
        '
        'lblLoppHind
        '
        Me.lblLoppHind.AutoSize = True
        Me.lblLoppHind.Location = New System.Drawing.Point(17, 112)
        Me.lblLoppHind.Name = "lblLoppHind"
        Me.lblLoppHind.Size = New System.Drawing.Size(63, 16)
        Me.lblLoppHind.TabIndex = 47
        Me.lblLoppHind.Text = "Lõpphind"
        '
        'txtLoppHind
        '
        Me.txtLoppHind.Location = New System.Drawing.Point(20, 136)
        Me.txtLoppHind.Name = "txtLoppHind"
        Me.txtLoppHind.ReadOnly = True
        Me.txtLoppHind.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtLoppHind.Size = New System.Drawing.Size(210, 22)
        Me.txtLoppHind.TabIndex = 46
        Me.txtLoppHind.Text = "Empty"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblPakett1)
        Me.GroupBox1.Controls.Add(Me.txtLoppHind)
        Me.GroupBox1.Controls.Add(Me.lblLoppHind)
        Me.GroupBox1.Controls.Add(Me.btnArvuta)
        Me.GroupBox1.Controls.Add(Me.cboxPakett1)
        Me.GroupBox1.Controls.Add(Me.lblAjavLopp)
        Me.GroupBox1.Controls.Add(Me.cboxALTund)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(334, 190)
        Me.GroupBox1.TabIndex = 55
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lõpphinna kalkulaator"
        '
        'FormLopphind
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1262, 673)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Graafik1)
        Me.Name = "FormLopphind"
        Me.Text = "Lõpphinna kakulaator"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Graafik1 As GraafikControl.Graafik
    Friend WithEvents btnArvuta As Button
    Friend WithEvents lblAjavLopp As Label
    Friend WithEvents cboxALTund As ComboBox
    Friend WithEvents cboxPakett1 As ComboBox
    Friend WithEvents lblPakett1 As Label
    Friend WithEvents lblLoppHind As Label
    Friend WithEvents txtLoppHind As TextBox
    Friend WithEvents GroupBox1 As GroupBox
End Class
