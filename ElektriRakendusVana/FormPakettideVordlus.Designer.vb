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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPakettideVordlus))
        Me.txtFixP = New System.Windows.Forms.TextBox()
        Me.lblFixHind = New System.Windows.Forms.Label()
        Me.btnArvuta = New System.Windows.Forms.Button()
        Me.txtFixO = New System.Windows.Forms.TextBox()
        Me.lblPTariif = New System.Windows.Forms.Label()
        Me.lblOTariif = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblLopp = New System.Windows.Forms.Label()
        Me.lblAlgus = New System.Windows.Forms.Label()
        Me.cboxLopp = New System.Windows.Forms.ComboBox()
        Me.cboxAlgus = New System.Windows.Forms.ComboBox()
        Me.lblPeriood1 = New System.Windows.Forms.Label()
        Me.cBoxPeriood = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cBoxPeriood2 = New System.Windows.Forms.ComboBox()
        Me.cboxPakett = New System.Windows.Forms.ComboBox()
        Me.lblLopp2 = New System.Windows.Forms.Label()
        Me.lblAlgus2 = New System.Windows.Forms.Label()
        Me.cboxLopp2 = New System.Windows.Forms.ComboBox()
        Me.cboxAlgus2 = New System.Windows.Forms.ComboBox()
        Me.lblUniText = New System.Windows.Forms.Label()
        Me.txtBaas = New System.Windows.Forms.TextBox()
        Me.lblBaas = New System.Windows.Forms.Label()
        Me.btnArvuta2 = New System.Windows.Forms.Button()
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblKoguSum1 = New System.Windows.Forms.Label()
        Me.lblKoguSum2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Graafik1 = New GraafikControl.Graafik()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblKoguSum3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtFixP
        '
        Me.txtFixP.Location = New System.Drawing.Point(10, 108)
        Me.txtFixP.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtFixP.Name = "txtFixP"
        Me.txtFixP.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtFixP.Size = New System.Drawing.Size(130, 26)
        Me.txtFixP.TabIndex = 45
        '
        'lblFixHind
        '
        Me.lblFixHind.AutoSize = True
        Me.lblFixHind.Location = New System.Drawing.Point(6, 49)
        Me.lblFixHind.Name = "lblFixHind"
        Me.lblFixHind.Size = New System.Drawing.Size(191, 20)
        Me.lblFixHind.TabIndex = 46
        Me.lblFixHind.Text = "Sisestage fikseeritud hind"
        '
        'btnArvuta
        '
        Me.btnArvuta.Location = New System.Drawing.Point(6, 266)
        Me.btnArvuta.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnArvuta.Name = "btnArvuta"
        Me.btnArvuta.Size = New System.Drawing.Size(84, 29)
        Me.btnArvuta.TabIndex = 47
        Me.btnArvuta.Text = "Arvuta"
        Me.btnArvuta.UseVisualStyleBackColor = True
        '
        'txtFixO
        '
        Me.txtFixO.Location = New System.Drawing.Point(186, 108)
        Me.txtFixO.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtFixO.Name = "txtFixO"
        Me.txtFixO.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtFixO.Size = New System.Drawing.Size(130, 26)
        Me.txtFixO.TabIndex = 49
        '
        'lblPTariif
        '
        Me.lblPTariif.AutoSize = True
        Me.lblPTariif.Location = New System.Drawing.Point(6, 82)
        Me.lblPTariif.Name = "lblPTariif"
        Me.lblPTariif.Size = New System.Drawing.Size(161, 20)
        Me.lblPTariif.TabIndex = 50
        Me.lblPTariif.Text = "Päeva tariif (sentides)"
        '
        'lblOTariif
        '
        Me.lblOTariif.AutoSize = True
        Me.lblOTariif.Location = New System.Drawing.Point(183, 82)
        Me.lblOTariif.Name = "lblOTariif"
        Me.lblOTariif.Size = New System.Drawing.Size(138, 20)
        Me.lblOTariif.TabIndex = 51
        Me.lblOTariif.Text = "Öö tariif (sentides)"
        '
        'GroupBox1
        '
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
        Me.GroupBox1.Location = New System.Drawing.Point(14, 15)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(338, 362)
        Me.GroupBox1.TabIndex = 52
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Börsi- ja fikseeritud hinna võrdlus"
        '
        'lblLopp
        '
        Me.lblLopp.AutoSize = True
        Me.lblLopp.Location = New System.Drawing.Point(150, 205)
        Me.lblLopp.Name = "lblLopp"
        Me.lblLopp.Size = New System.Drawing.Size(45, 20)
        Me.lblLopp.TabIndex = 58
        Me.lblLopp.Text = "Lopp"
        '
        'lblAlgus
        '
        Me.lblAlgus.AutoSize = True
        Me.lblAlgus.Location = New System.Drawing.Point(6, 205)
        Me.lblAlgus.Name = "lblAlgus"
        Me.lblAlgus.Size = New System.Drawing.Size(49, 20)
        Me.lblAlgus.TabIndex = 57
        Me.lblAlgus.Text = "Algus"
        '
        'cboxLopp
        '
        Me.cboxLopp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxLopp.FormattingEnabled = True
        Me.cboxLopp.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.cboxLopp.Location = New System.Drawing.Point(153, 229)
        Me.cboxLopp.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboxLopp.Name = "cboxLopp"
        Me.cboxLopp.Size = New System.Drawing.Size(136, 28)
        Me.cboxLopp.TabIndex = 56
        '
        'cboxAlgus
        '
        Me.cboxAlgus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxAlgus.FormattingEnabled = True
        Me.cboxAlgus.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.cboxAlgus.Location = New System.Drawing.Point(10, 229)
        Me.cboxAlgus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboxAlgus.Name = "cboxAlgus"
        Me.cboxAlgus.Size = New System.Drawing.Size(136, 28)
        Me.cboxAlgus.TabIndex = 55
        '
        'lblPeriood1
        '
        Me.lblPeriood1.AutoSize = True
        Me.lblPeriood1.Location = New System.Drawing.Point(6, 148)
        Me.lblPeriood1.Name = "lblPeriood1"
        Me.lblPeriood1.Size = New System.Drawing.Size(63, 20)
        Me.lblPeriood1.TabIndex = 53
        Me.lblPeriood1.Text = "Periood"
        '
        'cBoxPeriood
        '
        Me.cBoxPeriood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBoxPeriood.FormattingEnabled = True
        Me.cBoxPeriood.Items.AddRange(New Object() {"Tund", "Päev", "Kuu", "Aasta"})
        Me.cBoxPeriood.Location = New System.Drawing.Point(10, 171)
        Me.cBoxPeriood.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cBoxPeriood.Name = "cBoxPeriood"
        Me.cBoxPeriood.Size = New System.Drawing.Size(136, 28)
        Me.cBoxPeriood.TabIndex = 52
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cBoxPeriood2)
        Me.GroupBox2.Controls.Add(Me.cboxPakett)
        Me.GroupBox2.Controls.Add(Me.lblLopp2)
        Me.GroupBox2.Controls.Add(Me.lblAlgus2)
        Me.GroupBox2.Controls.Add(Me.cboxLopp2)
        Me.GroupBox2.Controls.Add(Me.cboxAlgus2)
        Me.GroupBox2.Controls.Add(Me.lblUniText)
        Me.GroupBox2.Controls.Add(Me.txtBaas)
        Me.GroupBox2.Controls.Add(Me.lblBaas)
        Me.GroupBox2.Controls.Add(Me.btnArvuta2)
        Me.GroupBox2.Location = New System.Drawing.Point(793, 15)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(338, 362)
        Me.GroupBox2.TabIndex = 54
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Börsi- ja universaalhinna võrdlus"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 148)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 20)
        Me.Label11.TabIndex = 60
        Me.Label11.Text = "Periood"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 261)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 20)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Pakett"
        '
        'cBoxPeriood2
        '
        Me.cBoxPeriood2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBoxPeriood2.FormattingEnabled = True
        Me.cBoxPeriood2.Items.AddRange(New Object() {"Tund", "Päev", "Kuu", "Aasta"})
        Me.cBoxPeriood2.Location = New System.Drawing.Point(10, 171)
        Me.cBoxPeriood2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cBoxPeriood2.Name = "cBoxPeriood2"
        Me.cBoxPeriood2.Size = New System.Drawing.Size(136, 28)
        Me.cBoxPeriood2.TabIndex = 59
        '
        'cboxPakett
        '
        Me.cboxPakett.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxPakett.FormattingEnabled = True
        Me.cboxPakett.Items.AddRange(New Object() {"Börsihind", "Fikseeritud hind", "Universaalteenus", "Universaalteenusega seotud pakett"})
        Me.cboxPakett.Location = New System.Drawing.Point(10, 286)
        Me.cboxPakett.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboxPakett.Name = "cboxPakett"
        Me.cboxPakett.Size = New System.Drawing.Size(136, 28)
        Me.cboxPakett.TabIndex = 58
        '
        'lblLopp2
        '
        Me.lblLopp2.AutoSize = True
        Me.lblLopp2.Location = New System.Drawing.Point(154, 205)
        Me.lblLopp2.Name = "lblLopp2"
        Me.lblLopp2.Size = New System.Drawing.Size(45, 20)
        Me.lblLopp2.TabIndex = 56
        Me.lblLopp2.Text = "Lopp"
        '
        'lblAlgus2
        '
        Me.lblAlgus2.AutoSize = True
        Me.lblAlgus2.Location = New System.Drawing.Point(6, 206)
        Me.lblAlgus2.Name = "lblAlgus2"
        Me.lblAlgus2.Size = New System.Drawing.Size(49, 20)
        Me.lblAlgus2.TabIndex = 55
        Me.lblAlgus2.Text = "Algus"
        '
        'cboxLopp2
        '
        Me.cboxLopp2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxLopp2.FormattingEnabled = True
        Me.cboxLopp2.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.cboxLopp2.Location = New System.Drawing.Point(153, 228)
        Me.cboxLopp2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboxLopp2.Name = "cboxLopp2"
        Me.cboxLopp2.Size = New System.Drawing.Size(136, 28)
        Me.cboxLopp2.TabIndex = 54
        '
        'cboxAlgus2
        '
        Me.cboxAlgus2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxAlgus2.FormattingEnabled = True
        Me.cboxAlgus2.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.cboxAlgus2.Location = New System.Drawing.Point(10, 228)
        Me.cboxAlgus2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboxAlgus2.Name = "cboxAlgus2"
        Me.cboxAlgus2.Size = New System.Drawing.Size(136, 28)
        Me.cboxAlgus2.TabIndex = 52
        '
        'lblUniText
        '
        Me.lblUniText.AutoSize = True
        Me.lblUniText.Location = New System.Drawing.Point(6, 49)
        Me.lblUniText.Name = "lblUniText"
        Me.lblUniText.Size = New System.Drawing.Size(321, 20)
        Me.lblUniText.TabIndex = 46
        Me.lblUniText.Text = "Sisestage universaalhind (ilma marginaalita):"
        '
        'txtBaas
        '
        Me.txtBaas.Location = New System.Drawing.Point(10, 108)
        Me.txtBaas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtBaas.Name = "txtBaas"
        Me.txtBaas.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtBaas.Size = New System.Drawing.Size(130, 26)
        Me.txtBaas.TabIndex = 45
        '
        'lblBaas
        '
        Me.lblBaas.AutoSize = True
        Me.lblBaas.Location = New System.Drawing.Point(6, 82)
        Me.lblBaas.Name = "lblBaas"
        Me.lblBaas.Size = New System.Drawing.Size(150, 20)
        Me.lblBaas.TabIndex = 50
        Me.lblBaas.Text = "Baashind (sentides)"
        '
        'btnArvuta2
        '
        Me.btnArvuta2.Location = New System.Drawing.Point(10, 322)
        Me.btnArvuta2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnArvuta2.Name = "btnArvuta2"
        Me.btnArvuta2.Size = New System.Drawing.Size(84, 29)
        Me.btnArvuta2.TabIndex = 47
        Me.btnArvuta2.Text = "Arvuta"
        Me.btnArvuta2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(366, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Keskmine hind"
        '
        'lblKeskHindB
        '
        Me.lblKeskHindB.AutoSize = True
        Me.lblKeskHindB.Location = New System.Drawing.Point(489, 111)
        Me.lblKeskHindB.Name = "lblKeskHindB"
        Me.lblKeskHindB.Size = New System.Drawing.Size(0, 20)
        Me.lblKeskHindB.TabIndex = 56
        '
        'lblKeskHindF
        '
        Me.lblKeskHindF.AutoSize = True
        Me.lblKeskHindF.Location = New System.Drawing.Point(489, 141)
        Me.lblKeskHindF.Name = "lblKeskHindF"
        Me.lblKeskHindF.Size = New System.Drawing.Size(0, 20)
        Me.lblKeskHindF.TabIndex = 57
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(366, 174)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(227, 20)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Börsi kõrgeim ja madalaim hind"
        '
        'lblKorgePeriood
        '
        Me.lblKorgePeriood.AutoSize = True
        Me.lblKorgePeriood.Location = New System.Drawing.Point(608, 209)
        Me.lblKorgePeriood.Name = "lblKorgePeriood"
        Me.lblKorgePeriood.Size = New System.Drawing.Size(0, 20)
        Me.lblKorgePeriood.TabIndex = 59
        '
        'lblKorgeHind
        '
        Me.lblKorgeHind.AutoSize = True
        Me.lblKorgeHind.Location = New System.Drawing.Point(489, 242)
        Me.lblKorgeHind.Name = "lblKorgeHind"
        Me.lblKorgeHind.Size = New System.Drawing.Size(0, 20)
        Me.lblKorgeHind.TabIndex = 60
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(366, 281)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(370, 20)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = "Mitu protsenti ajast on börsihind fikseeritud hinnast:"
        '
        'lblMadalPeriood
        '
        Me.lblMadalPeriood.AutoSize = True
        Me.lblMadalPeriood.Location = New System.Drawing.Point(608, 248)
        Me.lblMadalPeriood.Name = "lblMadalPeriood"
        Me.lblMadalPeriood.Size = New System.Drawing.Size(0, 20)
        Me.lblMadalPeriood.TabIndex = 62
        '
        'lblMadalHind
        '
        Me.lblMadalHind.AutoSize = True
        Me.lblMadalHind.Location = New System.Drawing.Point(489, 209)
        Me.lblMadalHind.Name = "lblMadalHind"
        Me.lblMadalHind.Size = New System.Drawing.Size(0, 20)
        Me.lblMadalHind.TabIndex = 63
        '
        'lblProtsentKallim
        '
        Me.lblProtsentKallim.AutoSize = True
        Me.lblProtsentKallim.Location = New System.Drawing.Point(489, 312)
        Me.lblProtsentKallim.Name = "lblProtsentKallim"
        Me.lblProtsentKallim.Size = New System.Drawing.Size(0, 20)
        Me.lblProtsentKallim.TabIndex = 64
        '
        'lblProtsentOdavam
        '
        Me.lblProtsentOdavam.AutoSize = True
        Me.lblProtsentOdavam.Location = New System.Drawing.Point(489, 342)
        Me.lblProtsentOdavam.Name = "lblProtsentOdavam"
        Me.lblProtsentOdavam.Size = New System.Drawing.Size(0, 20)
        Me.lblProtsentOdavam.TabIndex = 65
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(366, 99)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 20)
        Me.Label14.TabIndex = 66
        Me.Label14.Text = "Börsil:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(366, 129)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 20)
        Me.Label15.TabIndex = 67
        Me.Label15.Text = "Fikseeritud:"
        '
        'lblProK
        '
        Me.lblProK.AutoSize = True
        Me.lblProK.Location = New System.Drawing.Point(366, 312)
        Me.lblProK.Name = "lblProK"
        Me.lblProK.Size = New System.Drawing.Size(50, 20)
        Me.lblProK.TabIndex = 68
        Me.lblProK.Text = "Kallim"
        '
        'lblProO
        '
        Me.lblProO.AutoSize = True
        Me.lblProO.Location = New System.Drawing.Point(366, 342)
        Me.lblProO.Name = "lblProO"
        Me.lblProO.Size = New System.Drawing.Size(68, 20)
        Me.lblProO.TabIndex = 69
        Me.lblProO.Text = "Odavam"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1137, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(296, 20)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "Võrreldava paketi kogusumma (Pakett 1)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(1137, 231)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(286, 20)
        Me.Label7.TabIndex = 61
        Me.Label7.Text = "Universaalhinna kogusumma (Pakett 2)"
        '
        'lblKoguSum1
        '
        Me.lblKoguSum1.AutoSize = True
        Me.lblKoguSum1.Location = New System.Drawing.Point(1137, 196)
        Me.lblKoguSum1.Name = "lblKoguSum1"
        Me.lblKoguSum1.Size = New System.Drawing.Size(103, 20)
        Me.lblKoguSum1.TabIndex = 70
        Me.lblKoguSum1.Text = "lblKoguSum1"
        '
        'lblKoguSum2
        '
        Me.lblKoguSum2.AutoSize = True
        Me.lblKoguSum2.Location = New System.Drawing.Point(1137, 271)
        Me.lblKoguSum2.Name = "lblKoguSum2"
        Me.lblKoguSum2.Size = New System.Drawing.Size(103, 20)
        Me.lblKoguSum2.TabIndex = 71
        Me.lblKoguSum2.Text = "lblKoguSum2"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(366, 209)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 20)
        Me.Label8.TabIndex = 72
        Me.Label8.Text = "Kõrgeim hind:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(366, 248)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(115, 20)
        Me.Label10.TabIndex = 73
        Me.Label10.Text = "Madalaim hind:"
        '
        'Graafik1
        '
        Me.Graafik1.Location = New System.Drawing.Point(-1, 385)
        Me.Graafik1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Graafik1.Name = "Graafik1"
        Me.Graafik1.Size = New System.Drawing.Size(1419, 454)
        Me.Graafik1.TabIndex = 40
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1137, 305)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(248, 20)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "Börsihinna kogusumma (Pakett 3)"
        '
        'lblKoguSum3
        '
        Me.lblKoguSum3.AutoSize = True
        Me.lblKoguSum3.Location = New System.Drawing.Point(1137, 338)
        Me.lblKoguSum3.Name = "lblKoguSum3"
        Me.lblKoguSum3.Size = New System.Drawing.Size(103, 20)
        Me.lblKoguSum3.TabIndex = 75
        Me.lblKoguSum3.Text = "lblKoguSum3"
        '
        'FormPakettideVordlus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1419, 841)
        Me.Controls.Add(Me.lblKoguSum3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblKoguSum2)
        Me.Controls.Add(Me.lblKoguSum1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label7)
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
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FormPakettideVordlus"
        Me.Text = "Hindade võrdleja"
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
    Friend WithEvents cboxAlgus2 As ComboBox
    Friend WithEvents lblUniText As Label
    Friend WithEvents txtBaas As TextBox
    Friend WithEvents lblBaas As Label
    Friend WithEvents btnArvuta2 As Button
    Friend WithEvents cboxLopp2 As ComboBox
    Friend WithEvents lblLopp2 As Label
    Friend WithEvents lblAlgus2 As Label
    Friend WithEvents lblLopp As Label
    Friend WithEvents lblAlgus As Label
    Friend WithEvents cboxLopp As ComboBox
    Friend WithEvents cboxAlgus As ComboBox
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
    Friend WithEvents Label4 As Label
    Friend WithEvents cboxPakett As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblKoguSum1 As Label
    Friend WithEvents lblKoguSum2 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cBoxPeriood2 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblKoguSum3 As Label
End Class
