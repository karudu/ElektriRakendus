<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPakettideVordlus
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
        Me.cboxPakett1 = New System.Windows.Forms.ComboBox()
        Me.cBoxPakett2 = New System.Windows.Forms.ComboBox()
        Me.lblPakett2 = New System.Windows.Forms.Label()
        Me.lblPakett1 = New System.Windows.Forms.Label()
        Me.txtFixP = New System.Windows.Forms.TextBox()
        Me.lblFixHind = New System.Windows.Forms.Label()
        Me.btnArvuta = New System.Windows.Forms.Button()
        Me.btnArvutaPkt = New System.Windows.Forms.Button()
        Me.txtFixO = New System.Windows.Forms.TextBox()
        Me.lblPTariif = New System.Windows.Forms.Label()
        Me.lblOTariif = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblPeriood1 = New System.Windows.Forms.Label()
        Me.cBoxPeriood = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblPeriood2 = New System.Windows.Forms.Label()
        Me.cboxAlgus = New System.Windows.Forms.ComboBox()
        Me.lblUniText = New System.Windows.Forms.Label()
        Me.txtBaas = New System.Windows.Forms.TextBox()
        Me.lblBaas = New System.Windows.Forms.Label()
        Me.btnArvuta2 = New System.Windows.Forms.Button()
        Me.cboxLopp = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Graafik1
        '
        Me.Graafik1.Location = New System.Drawing.Point(-1, 308)
        Me.Graafik1.Name = "Graafik1"
        Me.Graafik1.Size = New System.Drawing.Size(1262, 363)
        Me.Graafik1.TabIndex = 40
        '
        'cboxPakett1
        '
        Me.cboxPakett1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxPakett1.FormattingEnabled = True
        Me.cboxPakett1.Items.AddRange(New Object() {"Börsihind", "Fikseeritud hind", "Universaalteenus", "Universaalteenusega seotud pakett"})
        Me.cboxPakett1.Location = New System.Drawing.Point(891, 44)
        Me.cboxPakett1.Name = "cboxPakett1"
        Me.cboxPakett1.Size = New System.Drawing.Size(121, 24)
        Me.cboxPakett1.TabIndex = 41
        '
        'cBoxPakett2
        '
        Me.cBoxPakett2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBoxPakett2.FormattingEnabled = True
        Me.cBoxPakett2.Items.AddRange(New Object() {"Börsihind", "Fikseeritud hind", "Universaalteenus", "Universaalteenusega seotud pakett"})
        Me.cBoxPakett2.Location = New System.Drawing.Point(1054, 44)
        Me.cBoxPakett2.Name = "cBoxPakett2"
        Me.cBoxPakett2.Size = New System.Drawing.Size(121, 24)
        Me.cBoxPakett2.TabIndex = 42
        '
        'lblPakett2
        '
        Me.lblPakett2.AutoSize = True
        Me.lblPakett2.Location = New System.Drawing.Point(1051, 25)
        Me.lblPakett2.Name = "lblPakett2"
        Me.lblPakett2.Size = New System.Drawing.Size(55, 16)
        Me.lblPakett2.TabIndex = 43
        Me.lblPakett2.Text = "Pakett 2"
        '
        'lblPakett1
        '
        Me.lblPakett1.AutoSize = True
        Me.lblPakett1.Location = New System.Drawing.Point(888, 25)
        Me.lblPakett1.Name = "lblPakett1"
        Me.lblPakett1.Size = New System.Drawing.Size(55, 16)
        Me.lblPakett1.TabIndex = 44
        Me.lblPakett1.Text = "Pakett 1"
        '
        'txtFixP
        '
        Me.txtFixP.Location = New System.Drawing.Point(9, 86)
        Me.txtFixP.Name = "txtFixP"
        Me.txtFixP.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtFixP.Size = New System.Drawing.Size(116, 22)
        Me.txtFixP.TabIndex = 45
        '
        'lblFixHind
        '
        Me.lblFixHind.AutoSize = True
        Me.lblFixHind.Location = New System.Drawing.Point(6, 40)
        Me.lblFixHind.Name = "lblFixHind"
        Me.lblFixHind.Size = New System.Drawing.Size(111, 16)
        Me.lblFixHind.TabIndex = 46
        Me.lblFixHind.Text = "Sisestage fix hind"
        '
        'btnArvuta
        '
        Me.btnArvuta.Location = New System.Drawing.Point(6, 178)
        Me.btnArvuta.Name = "btnArvuta"
        Me.btnArvuta.Size = New System.Drawing.Size(75, 23)
        Me.btnArvuta.TabIndex = 47
        Me.btnArvuta.Text = "Arvuta"
        Me.btnArvuta.UseVisualStyleBackColor = True
        '
        'btnArvutaPkt
        '
        Me.btnArvutaPkt.Location = New System.Drawing.Point(924, 196)
        Me.btnArvutaPkt.Name = "btnArvutaPkt"
        Me.btnArvutaPkt.Size = New System.Drawing.Size(75, 23)
        Me.btnArvutaPkt.TabIndex = 48
        Me.btnArvutaPkt.Text = "Arvuta"
        Me.btnArvutaPkt.UseVisualStyleBackColor = True
        '
        'txtFixO
        '
        Me.txtFixO.Location = New System.Drawing.Point(165, 86)
        Me.txtFixO.Name = "txtFixO"
        Me.txtFixO.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtFixO.Size = New System.Drawing.Size(116, 22)
        Me.txtFixO.TabIndex = 49
        '
        'lblPTariif
        '
        Me.lblPTariif.AutoSize = True
        Me.lblPTariif.Location = New System.Drawing.Point(6, 67)
        Me.lblPTariif.Name = "lblPTariif"
        Me.lblPTariif.Size = New System.Drawing.Size(136, 16)
        Me.lblPTariif.TabIndex = 50
        Me.lblPTariif.Text = "Päeva tariif (sentides)"
        '
        'lblOTariif
        '
        Me.lblOTariif.AutoSize = True
        Me.lblOTariif.Location = New System.Drawing.Point(162, 67)
        Me.lblOTariif.Name = "lblOTariif"
        Me.lblOTariif.Size = New System.Drawing.Size(114, 16)
        Me.lblOTariif.TabIndex = 51
        Me.lblOTariif.Text = "Öö tariif (sentides)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblPeriood1)
        Me.GroupBox1.Controls.Add(Me.cBoxPeriood)
        Me.GroupBox1.Controls.Add(Me.lblFixHind)
        Me.GroupBox1.Controls.Add(Me.lblOTariif)
        Me.GroupBox1.Controls.Add(Me.txtFixP)
        Me.GroupBox1.Controls.Add(Me.lblPTariif)
        Me.GroupBox1.Controls.Add(Me.btnArvuta)
        Me.GroupBox1.Controls.Add(Me.txtFixO)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 207)
        Me.GroupBox1.TabIndex = 52
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Börsi- ja fikseeritudhinna võrdlus"
        '
        'lblPeriood1
        '
        Me.lblPeriood1.AutoSize = True
        Me.lblPeriood1.Location = New System.Drawing.Point(6, 118)
        Me.lblPeriood1.Name = "lblPeriood1"
        Me.lblPeriood1.Size = New System.Drawing.Size(55, 16)
        Me.lblPeriood1.TabIndex = 53
        Me.lblPeriood1.Text = "Periood"
        '
        'cBoxPeriood
        '
        Me.cBoxPeriood.FormattingEnabled = True
        Me.cBoxPeriood.Items.AddRange(New Object() {"Päev", "Kuu", "Aasta"})
        Me.cBoxPeriood.Location = New System.Drawing.Point(9, 137)
        Me.cBoxPeriood.Name = "cBoxPeriood"
        Me.cBoxPeriood.Size = New System.Drawing.Size(121, 24)
        Me.cBoxPeriood.TabIndex = 52
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboxLopp)
        Me.GroupBox2.Controls.Add(Me.lblPeriood2)
        Me.GroupBox2.Controls.Add(Me.cboxAlgus)
        Me.GroupBox2.Controls.Add(Me.lblUniText)
        Me.GroupBox2.Controls.Add(Me.txtBaas)
        Me.GroupBox2.Controls.Add(Me.lblBaas)
        Me.GroupBox2.Controls.Add(Me.btnArvuta2)
        Me.GroupBox2.Location = New System.Drawing.Point(338, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 207)
        Me.GroupBox2.TabIndex = 54
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Börsi- ja universaalhinna võrdlus"
        '
        'lblPeriood2
        '
        Me.lblPeriood2.AutoSize = True
        Me.lblPeriood2.Location = New System.Drawing.Point(6, 118)
        Me.lblPeriood2.Name = "lblPeriood2"
        Me.lblPeriood2.Size = New System.Drawing.Size(55, 16)
        Me.lblPeriood2.TabIndex = 53
        Me.lblPeriood2.Text = "Periood"
        '
        'cboxAlgus
        '
        Me.cboxAlgus.FormattingEnabled = True
        Me.cboxAlgus.Items.AddRange(New Object() {"Päev", "Kuu", "Aasta"})
        Me.cboxAlgus.Location = New System.Drawing.Point(9, 137)
        Me.cboxAlgus.Name = "cboxAlgus"
        Me.cboxAlgus.Size = New System.Drawing.Size(121, 24)
        Me.cboxAlgus.TabIndex = 52
        '
        'lblUniText
        '
        Me.lblUniText.AutoSize = True
        Me.lblUniText.Location = New System.Drawing.Point(6, 40)
        Me.lblUniText.Name = "lblUniText"
        Me.lblUniText.Size = New System.Drawing.Size(274, 16)
        Me.lblUniText.TabIndex = 46
        Me.lblUniText.Text = "Sisestage universaal hind (ilma marginaalita)"
        '
        'txtBaas
        '
        Me.txtBaas.Location = New System.Drawing.Point(9, 86)
        Me.txtBaas.Name = "txtBaas"
        Me.txtBaas.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtBaas.Size = New System.Drawing.Size(116, 22)
        Me.txtBaas.TabIndex = 45
        '
        'lblBaas
        '
        Me.lblBaas.AutoSize = True
        Me.lblBaas.Location = New System.Drawing.Point(6, 67)
        Me.lblBaas.Name = "lblBaas"
        Me.lblBaas.Size = New System.Drawing.Size(129, 16)
        Me.lblBaas.TabIndex = 50
        Me.lblBaas.Text = "Baas hind (sentides)"
        '
        'btnArvuta2
        '
        Me.btnArvuta2.Location = New System.Drawing.Point(6, 178)
        Me.btnArvuta2.Name = "btnArvuta2"
        Me.btnArvuta2.Size = New System.Drawing.Size(75, 23)
        Me.btnArvuta2.TabIndex = 47
        Me.btnArvuta2.Text = "Arvuta"
        Me.btnArvuta2.UseVisualStyleBackColor = True
        '
        'cboxLopp
        '
        Me.cboxLopp.FormattingEnabled = True
        Me.cboxLopp.Items.AddRange(New Object() {"Päev", "Kuu", "Aasta"})
        Me.cboxLopp.Location = New System.Drawing.Point(136, 137)
        Me.cboxLopp.Name = "cboxLopp"
        Me.cboxLopp.Size = New System.Drawing.Size(121, 24)
        Me.cboxLopp.TabIndex = 54
        '
        'FormPakettideVordlus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1262, 673)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnArvutaPkt)
        Me.Controls.Add(Me.lblPakett1)
        Me.Controls.Add(Me.lblPakett2)
        Me.Controls.Add(Me.cBoxPakett2)
        Me.Controls.Add(Me.cboxPakett1)
        Me.Controls.Add(Me.Graafik1)
        Me.Name = "FormPakettideVordlus"
        Me.Text = "Pakettide võrdlus"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Graafik1 As GraafikControl.Graafik
    Friend WithEvents cboxPakett1 As ComboBox
    Friend WithEvents cBoxPakett2 As ComboBox
    Friend WithEvents lblPakett2 As Label
    Friend WithEvents lblPakett1 As Label
    Friend WithEvents txtFixP As TextBox
    Friend WithEvents lblFixHind As Label
    Friend WithEvents btnArvuta As Button
    Friend WithEvents btnArvutaPkt As Button
    Friend WithEvents txtFixO As TextBox
    Friend WithEvents lblPTariif As Label
    Friend WithEvents lblOTariif As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblPeriood1 As Label
    Friend WithEvents cBoxPeriood As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblPeriood2 As Label
    Friend WithEvents cboxAlgus As ComboBox
    Friend WithEvents lblUniText As Label
    Friend WithEvents txtBaas As TextBox
    Friend WithEvents lblBaas As Label
    Friend WithEvents btnArvuta2 As Button
    Friend WithEvents cboxLopp As ComboBox
End Class
