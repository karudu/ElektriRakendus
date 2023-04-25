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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnTrendArvuta = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblDtpVahe = New System.Windows.Forms.Label()
        Me.dtpTrendLopp = New System.Windows.Forms.DateTimePicker()
        Me.dtpTrendAlgus = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTrendKesk = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.lblPakett1.Size = New System.Drawing.Size(45, 16)
        Me.lblPakett1.TabIndex = 48
        Me.lblPakett1.Text = "Pakett"
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnTrendArvuta)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.lblDtpVahe)
        Me.GroupBox2.Controls.Add(Me.dtpTrendLopp)
        Me.GroupBox2.Controls.Add(Me.dtpTrendAlgus)
        Me.GroupBox2.Location = New System.Drawing.Point(414, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(331, 190)
        Me.GroupBox2.TabIndex = 56
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Börsihinna trendid"
        '
        'btnTrendArvuta
        '
        Me.btnTrendArvuta.Location = New System.Drawing.Point(26, 89)
        Me.btnTrendArvuta.Name = "btnTrendArvuta"
        Me.btnTrendArvuta.Size = New System.Drawing.Size(75, 23)
        Me.btnTrendArvuta.TabIndex = 58
        Me.btnTrendArvuta.Text = "Arvuta"
        Me.btnTrendArvuta.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 16)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Ajavahemik"
        '
        'lblDtpVahe
        '
        Me.lblDtpVahe.AutoSize = True
        Me.lblDtpVahe.Location = New System.Drawing.Point(142, 66)
        Me.lblDtpVahe.Name = "lblDtpVahe"
        Me.lblDtpVahe.Size = New System.Drawing.Size(11, 16)
        Me.lblDtpVahe.TabIndex = 56
        Me.lblDtpVahe.Text = "-"
        Me.lblDtpVahe.Visible = False
        '
        'dtpTrendLopp
        '
        Me.dtpTrendLopp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTrendLopp.Location = New System.Drawing.Point(159, 61)
        Me.dtpTrendLopp.Name = "dtpTrendLopp"
        Me.dtpTrendLopp.Size = New System.Drawing.Size(110, 22)
        Me.dtpTrendLopp.TabIndex = 55
        Me.dtpTrendLopp.Value = New Date(2023, 4, 17, 10, 39, 15, 0)
        '
        'dtpTrendAlgus
        '
        Me.dtpTrendAlgus.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTrendAlgus.Location = New System.Drawing.Point(26, 61)
        Me.dtpTrendAlgus.Name = "dtpTrendAlgus"
        Me.dtpTrendAlgus.Size = New System.Drawing.Size(110, 22)
        Me.dtpTrendAlgus.TabIndex = 54
        Me.dtpTrendAlgus.Value = New Date(2023, 4, 17, 10, 39, 15, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(765, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 16)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Keskmine hind:"
        '
        'lblTrendKesk
        '
        Me.lblTrendKesk.AutoSize = True
        Me.lblTrendKesk.Location = New System.Drawing.Point(869, 44)
        Me.lblTrendKesk.Name = "lblTrendKesk"
        Me.lblTrendKesk.Size = New System.Drawing.Size(0, 16)
        Me.lblTrendKesk.TabIndex = 58
        '
        'FormLopphind
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1262, 673)
        Me.Controls.Add(Me.lblTrendKesk)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Graafik1)
        Me.Name = "FormLopphind"
        Me.Text = "Lõpphinna kakulaator"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblDtpVahe As Label
    Friend WithEvents dtpTrendLopp As DateTimePicker
    Friend WithEvents dtpTrendAlgus As DateTimePicker
    Friend WithEvents btnTrendArvuta As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTrendKesk As Label
End Class
