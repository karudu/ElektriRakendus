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
        Me.txtFixP = New System.Windows.Forms.TextBox()
        Me.lblFixHind = New System.Windows.Forms.Label()
        Me.btnArvuta = New System.Windows.Forms.Button()
        Me.txtFixO = New System.Windows.Forms.TextBox()
        Me.lblPTariif = New System.Windows.Forms.Label()
        Me.lblOTariif = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblError = New System.Windows.Forms.Label()
        Me.lblLopp = New System.Windows.Forms.Label()
        Me.lblAlgus = New System.Windows.Forms.Label()
        Me.cboxLopp = New System.Windows.Forms.ComboBox()
        Me.cboxAlgus = New System.Windows.Forms.ComboBox()
        Me.lblPeriood1 = New System.Windows.Forms.Label()
        Me.cBoxPeriood = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblError2 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboxLopp2 = New System.Windows.Forms.ComboBox()
        Me.lblPeriood2 = New System.Windows.Forms.Label()
        Me.cboxAlgus2 = New System.Windows.Forms.ComboBox()
        Me.lblUniText = New System.Windows.Forms.Label()
        Me.txtBaas = New System.Windows.Forms.TextBox()
        Me.lblBaas = New System.Windows.Forms.Label()
        Me.btnArvuta2 = New System.Windows.Forms.Button()
        Me.Graafik1 = New GraafikControl.Graafik()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblKeskHindB = New System.Windows.Forms.Label()
        Me.lblKeskHindF = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblKorgePeriood = New System.Windows.Forms.Label()
        Me.lblKorgeHind = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblMadalPeriood = New System.Windows.Forms.Label()
        Me.lblMadalHind = New System.Windows.Forms.Label()
        Me.lblProtsentKallim = New System.Windows.Forms.Label()
        Me.lblProtsentOdavam = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblProK = New System.Windows.Forms.Label()
        Me.lblProO = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.btnArvuta.Location = New System.Drawing.Point(6, 213)
        Me.btnArvuta.Name = "btnArvuta"
        Me.btnArvuta.Size = New System.Drawing.Size(75, 23)
        Me.btnArvuta.TabIndex = 47
        Me.btnArvuta.Text = "Arvuta"
        Me.btnArvuta.UseVisualStyleBackColor = True
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
        Me.GroupBox1.Controls.Add(Me.lblError)
        Me.GroupBox1.Controls.Add(Me.lblLopp)
        Me.GroupBox1.Controls.Add(Me.lblAlgus)
        Me.GroupBox1.Controls.Add(Me.cboxLopp)
        Me.GroupBox1.Controls.Add(Me.cboxAlgus)
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
        Me.GroupBox1.Size = New System.Drawing.Size(300, 290)
        Me.GroupBox1.TabIndex = 52
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Börsi- ja fikseeritudhinna võrdlus"
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.Location = New System.Drawing.Point(8, 239)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(73, 16)
        Me.lblError.TabIndex = 59
        Me.lblError.Text = "Error Label"
        '
        'lblLopp
        '
        Me.lblLopp.AutoSize = True
        Me.lblLopp.Location = New System.Drawing.Point(133, 164)
        Me.lblLopp.Name = "lblLopp"
        Me.lblLopp.Size = New System.Drawing.Size(38, 16)
        Me.lblLopp.TabIndex = 58
        Me.lblLopp.Text = "Lopp"
        '
        'lblAlgus
        '
        Me.lblAlgus.AutoSize = True
        Me.lblAlgus.Location = New System.Drawing.Point(6, 164)
        Me.lblAlgus.Name = "lblAlgus"
        Me.lblAlgus.Size = New System.Drawing.Size(41, 16)
        Me.lblAlgus.TabIndex = 57
        Me.lblAlgus.Text = "Algus"
        '
        'cboxLopp
        '
        Me.cboxLopp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxLopp.FormattingEnabled = True
        Me.cboxLopp.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.cboxLopp.Location = New System.Drawing.Point(136, 183)
        Me.cboxLopp.Name = "cboxLopp"
        Me.cboxLopp.Size = New System.Drawing.Size(121, 24)
        Me.cboxLopp.TabIndex = 56
        '
        'cboxAlgus
        '
        Me.cboxAlgus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxAlgus.FormattingEnabled = True
        Me.cboxAlgus.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.cboxAlgus.Location = New System.Drawing.Point(9, 183)
        Me.cboxAlgus.Name = "cboxAlgus"
        Me.cboxAlgus.Size = New System.Drawing.Size(121, 24)
        Me.cboxAlgus.TabIndex = 55
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
        Me.cBoxPeriood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBoxPeriood.FormattingEnabled = True
        Me.cBoxPeriood.Items.AddRange(New Object() {"Tund", "Päev", "Kuu", "Aasta"})
        Me.cBoxPeriood.Location = New System.Drawing.Point(9, 137)
        Me.cBoxPeriood.Name = "cBoxPeriood"
        Me.cBoxPeriood.Size = New System.Drawing.Size(121, 24)
        Me.cBoxPeriood.TabIndex = 52
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblError2)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cboxLopp2)
        Me.GroupBox2.Controls.Add(Me.lblPeriood2)
        Me.GroupBox2.Controls.Add(Me.cboxAlgus2)
        Me.GroupBox2.Controls.Add(Me.lblUniText)
        Me.GroupBox2.Controls.Add(Me.txtBaas)
        Me.GroupBox2.Controls.Add(Me.lblBaas)
        Me.GroupBox2.Controls.Add(Me.btnArvuta2)
        Me.GroupBox2.Location = New System.Drawing.Point(950, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 290)
        Me.GroupBox2.TabIndex = 54
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Börsi- ja universaalhinna võrdlus"
        '
        'lblError2
        '
        Me.lblError2.AutoSize = True
        Me.lblError2.Location = New System.Drawing.Point(8, 239)
        Me.lblError2.Name = "lblError2"
        Me.lblError2.Size = New System.Drawing.Size(73, 16)
        Me.lblError2.TabIndex = 57
        Me.lblError2.Text = "Error Label"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(219, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 16)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Lopp"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(89, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 16)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Algus"
        '
        'cboxLopp2
        '
        Me.cboxLopp2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxLopp2.FormattingEnabled = True
        Me.cboxLopp2.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.cboxLopp2.Location = New System.Drawing.Point(136, 137)
        Me.cboxLopp2.Name = "cboxLopp2"
        Me.cboxLopp2.Size = New System.Drawing.Size(121, 24)
        Me.cboxLopp2.TabIndex = 54
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
        'cboxAlgus2
        '
        Me.cboxAlgus2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxAlgus2.FormattingEnabled = True
        Me.cboxAlgus2.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.cboxAlgus2.Location = New System.Drawing.Point(9, 137)
        Me.cboxAlgus2.Name = "cboxAlgus2"
        Me.cboxAlgus2.Size = New System.Drawing.Size(121, 24)
        Me.cboxAlgus2.TabIndex = 52
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
        Me.btnArvuta2.Location = New System.Drawing.Point(6, 213)
        Me.btnArvuta2.Name = "btnArvuta2"
        Me.btnArvuta2.Size = New System.Drawing.Size(75, 23)
        Me.btnArvuta2.TabIndex = 47
        Me.btnArvuta2.Text = "Arvuta"
        Me.btnArvuta2.UseVisualStyleBackColor = True
        '
        'Graafik1
        '
        Me.Graafik1.Location = New System.Drawing.Point(-1, 308)
        Me.Graafik1.Name = "Graafik1"
        Me.Graafik1.Size = New System.Drawing.Size(1262, 363)
        Me.Graafik1.TabIndex = 40
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(325, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 16)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Keskmine hind"
        '
        'lblKeskHindB
        '
        Me.lblKeskHindB.AutoSize = True
        Me.lblKeskHindB.Location = New System.Drawing.Point(407, 79)
        Me.lblKeskHindB.Name = "lblKeskHindB"
        Me.lblKeskHindB.Size = New System.Drawing.Size(0, 16)
        Me.lblKeskHindB.TabIndex = 56
        '
        'lblKeskHindF
        '
        Me.lblKeskHindF.AutoSize = True
        Me.lblKeskHindF.Location = New System.Drawing.Point(407, 104)
        Me.lblKeskHindF.Name = "lblKeskHindF"
        Me.lblKeskHindF.Size = New System.Drawing.Size(0, 16)
        Me.lblKeskHindF.TabIndex = 57
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(325, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(195, 16)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Börsi kõrgeim ja madalaim hind"
        '
        'lblKorgePeriood
        '
        Me.lblKorgePeriood.AutoSize = True
        Me.lblKorgePeriood.Location = New System.Drawing.Point(325, 167)
        Me.lblKorgePeriood.Name = "lblKorgePeriood"
        Me.lblKorgePeriood.Size = New System.Drawing.Size(0, 16)
        Me.lblKorgePeriood.TabIndex = 59
        '
        'lblKorgeHind
        '
        Me.lblKorgeHind.AutoSize = True
        Me.lblKorgeHind.Location = New System.Drawing.Point(325, 194)
        Me.lblKorgeHind.Name = "lblKorgeHind"
        Me.lblKorgeHind.Size = New System.Drawing.Size(0, 16)
        Me.lblKorgeHind.TabIndex = 60
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(325, 225)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(305, 16)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = "Mitu protsenti ajast on börsi hind fikseeritud hinnast"
        '
        'lblMadalPeriood
        '
        Me.lblMadalPeriood.AutoSize = True
        Me.lblMadalPeriood.Location = New System.Drawing.Point(407, 167)
        Me.lblMadalPeriood.Name = "lblMadalPeriood"
        Me.lblMadalPeriood.Size = New System.Drawing.Size(0, 16)
        Me.lblMadalPeriood.TabIndex = 62
        '
        'lblMadalHind
        '
        Me.lblMadalHind.AutoSize = True
        Me.lblMadalHind.Location = New System.Drawing.Point(407, 194)
        Me.lblMadalHind.Name = "lblMadalHind"
        Me.lblMadalHind.Size = New System.Drawing.Size(0, 16)
        Me.lblMadalHind.TabIndex = 63
        '
        'lblProtsentKallim
        '
        Me.lblProtsentKallim.AutoSize = True
        Me.lblProtsentKallim.Location = New System.Drawing.Point(407, 250)
        Me.lblProtsentKallim.Name = "lblProtsentKallim"
        Me.lblProtsentKallim.Size = New System.Drawing.Size(0, 16)
        Me.lblProtsentKallim.TabIndex = 64
        '
        'lblProtsentOdavam
        '
        Me.lblProtsentOdavam.AutoSize = True
        Me.lblProtsentOdavam.Location = New System.Drawing.Point(407, 275)
        Me.lblProtsentOdavam.Name = "lblProtsentOdavam"
        Me.lblProtsentOdavam.Size = New System.Drawing.Size(0, 16)
        Me.lblProtsentOdavam.TabIndex = 65
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(325, 79)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 16)
        Me.Label14.TabIndex = 66
        Me.Label14.Text = "Börsil:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(325, 104)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 16)
        Me.Label15.TabIndex = 67
        Me.Label15.Text = "Fikseeritud:"
        '
        'lblProK
        '
        Me.lblProK.AutoSize = True
        Me.lblProK.Location = New System.Drawing.Point(325, 250)
        Me.lblProK.Name = "lblProK"
        Me.lblProK.Size = New System.Drawing.Size(43, 16)
        Me.lblProK.TabIndex = 68
        Me.lblProK.Text = "Kallim"
        '
        'lblProO
        '
        Me.lblProO.AutoSize = True
        Me.lblProO.Location = New System.Drawing.Point(325, 275)
        Me.lblProO.Name = "lblProO"
        Me.lblProO.Size = New System.Drawing.Size(59, 16)
        Me.lblProO.TabIndex = 69
        Me.lblProO.Text = "Odavam"
        '
        'FormPakettideVordlus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1262, 673)
        Me.Controls.Add(Me.lblProO)
        Me.Controls.Add(Me.lblProK)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lblProtsentOdavam)
        Me.Controls.Add(Me.lblProtsentKallim)
        Me.Controls.Add(Me.lblMadalHind)
        Me.Controls.Add(Me.lblMadalPeriood)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblKorgeHind)
        Me.Controls.Add(Me.lblKorgePeriood)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblKeskHindF)
        Me.Controls.Add(Me.lblKeskHindB)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
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
    Friend WithEvents txtFixP As TextBox
    Friend WithEvents lblFixHind As Label
    Friend WithEvents btnArvuta As Button
    Friend WithEvents txtFixO As TextBox
    Friend WithEvents lblPTariif As Label
    Friend WithEvents lblOTariif As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblPeriood1 As Label
    Friend WithEvents cBoxPeriood As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblPeriood2 As Label
    Friend WithEvents cboxAlgus2 As ComboBox
    Friend WithEvents lblUniText As Label
    Friend WithEvents txtBaas As TextBox
    Friend WithEvents lblBaas As Label
    Friend WithEvents btnArvuta2 As Button
    Friend WithEvents cboxLopp2 As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblLopp As Label
    Friend WithEvents lblAlgus As Label
    Friend WithEvents cboxLopp As ComboBox
    Friend WithEvents cboxAlgus As ComboBox
    Friend WithEvents lblError As Label
    Friend WithEvents lblError2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblKeskHindB As Label
    Friend WithEvents lblKeskHindF As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblKorgePeriood As Label
    Friend WithEvents lblKorgeHind As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblMadalPeriood As Label
    Friend WithEvents lblMadalHind As Label
    Friend WithEvents lblProtsentKallim As Label
    Friend WithEvents lblProtsentOdavam As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents lblProK As Label
    Friend WithEvents lblProO As Label
End Class
