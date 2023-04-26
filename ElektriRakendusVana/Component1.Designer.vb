Partial Class Component1
    Inherits System.ComponentModel.Component

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

    End Sub

    'Component overrides dispose to clean up the component list.
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

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblKoguSum3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblKoguSum2 = New System.Windows.Forms.Label()
        Me.lblKoguSum1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
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
        Me.Graafik1 = New GraafikControl.Graafik()
        Me.GroupBox2.SuspendLayout()
        '
        'lblKoguSum3
        '
        Me.lblKoguSum3.AutoSize = True
        Me.lblKoguSum3.Location = New System.Drawing.Point(1011, 270)
        Me.lblKoguSum3.Name = "lblKoguSum3"
        Me.lblKoguSum3.Size = New System.Drawing.Size(86, 16)
        Me.lblKoguSum3.TabIndex = 75
        Me.lblKoguSum3.Text = "lblKoguSum3"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1011, 244)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(209, 16)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "Börsihinna kogu summa (Pakett 3)"
        '
        'lblKoguSum2
        '
        Me.lblKoguSum2.AutoSize = True
        Me.lblKoguSum2.Location = New System.Drawing.Point(1011, 217)
        Me.lblKoguSum2.Name = "lblKoguSum2"
        Me.lblKoguSum2.Size = New System.Drawing.Size(86, 16)
        Me.lblKoguSum2.TabIndex = 71
        Me.lblKoguSum2.Text = "lblKoguSum2"
        '
        'lblKoguSum1
        '
        Me.lblKoguSum1.AutoSize = True
        Me.lblKoguSum1.Location = New System.Drawing.Point(1011, 157)
        Me.lblKoguSum1.Name = "lblKoguSum1"
        Me.lblKoguSum1.Size = New System.Drawing.Size(86, 16)
        Me.lblKoguSum1.TabIndex = 70
        Me.lblKoguSum1.Text = "lblKoguSum1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1011, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(241, 16)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "Võreldav paketi kogu summa (Pakett 1)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(1011, 185)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(240, 16)
        Me.Label7.TabIndex = 61
        Me.Label7.Text = "Universaalhinna kogu summa (Pakett2)"
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
        Me.GroupBox2.Location = New System.Drawing.Point(705, 12)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(300, 290)
        Me.GroupBox2.TabIndex = 54
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Börsi- ja universaalhinna võrdlus"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(5, 118)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 16)
        Me.Label11.TabIndex = 60
        Me.Label11.Text = "Periood"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 209)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 16)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Pakett"
        '
        'cBoxPeriood2
        '
        Me.cBoxPeriood2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBoxPeriood2.FormattingEnabled = True
        Me.cBoxPeriood2.Items.AddRange(New Object() {"Tund", "Päev", "Kuu", "Aasta"})
        Me.cBoxPeriood2.Location = New System.Drawing.Point(9, 137)
        Me.cBoxPeriood2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cBoxPeriood2.Name = "cBoxPeriood2"
        Me.cBoxPeriood2.Size = New System.Drawing.Size(121, 24)
        Me.cBoxPeriood2.TabIndex = 59
        '
        'cboxPakett
        '
        Me.cboxPakett.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxPakett.FormattingEnabled = True
        Me.cboxPakett.Items.AddRange(New Object() {"Börsihind", "Fikseeritud hind", "Universaalteenus", "Universaalteenusega seotud pakett"})
        Me.cboxPakett.Location = New System.Drawing.Point(9, 229)
        Me.cboxPakett.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboxPakett.Name = "cboxPakett"
        Me.cboxPakett.Size = New System.Drawing.Size(121, 24)
        Me.cboxPakett.TabIndex = 58
        '
        'lblLopp2
        '
        Me.lblLopp2.AutoSize = True
        Me.lblLopp2.Location = New System.Drawing.Point(137, 164)
        Me.lblLopp2.Name = "lblLopp2"
        Me.lblLopp2.Size = New System.Drawing.Size(38, 16)
        Me.lblLopp2.TabIndex = 56
        Me.lblLopp2.Text = "Lopp"
        '
        'lblAlgus2
        '
        Me.lblAlgus2.AutoSize = True
        Me.lblAlgus2.Location = New System.Drawing.Point(5, 165)
        Me.lblAlgus2.Name = "lblAlgus2"
        Me.lblAlgus2.Size = New System.Drawing.Size(41, 16)
        Me.lblAlgus2.TabIndex = 55
        Me.lblAlgus2.Text = "Algus"
        '
        'cboxLopp2
        '
        Me.cboxLopp2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxLopp2.FormattingEnabled = True
        Me.cboxLopp2.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.cboxLopp2.Location = New System.Drawing.Point(136, 182)
        Me.cboxLopp2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboxLopp2.Name = "cboxLopp2"
        Me.cboxLopp2.Size = New System.Drawing.Size(121, 24)
        Me.cboxLopp2.TabIndex = 54
        '
        'cboxAlgus2
        '
        Me.cboxAlgus2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxAlgus2.FormattingEnabled = True
        Me.cboxAlgus2.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.cboxAlgus2.Location = New System.Drawing.Point(9, 182)
        Me.cboxAlgus2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboxAlgus2.Name = "cboxAlgus2"
        Me.cboxAlgus2.Size = New System.Drawing.Size(121, 24)
        Me.cboxAlgus2.TabIndex = 52
        '
        'lblUniText
        '
        Me.lblUniText.AutoSize = True
        Me.lblUniText.Location = New System.Drawing.Point(5, 39)
        Me.lblUniText.Name = "lblUniText"
        Me.lblUniText.Size = New System.Drawing.Size(274, 16)
        Me.lblUniText.TabIndex = 46
        Me.lblUniText.Text = "Sisestage universaal hind (ilma marginaalita)"
        '
        'txtBaas
        '
        Me.txtBaas.Location = New System.Drawing.Point(9, 86)
        Me.txtBaas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtBaas.Name = "txtBaas"
        Me.txtBaas.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtBaas.Size = New System.Drawing.Size(116, 22)
        Me.txtBaas.TabIndex = 45
        '
        'lblBaas
        '
        Me.lblBaas.AutoSize = True
        Me.lblBaas.Location = New System.Drawing.Point(5, 66)
        Me.lblBaas.Name = "lblBaas"
        Me.lblBaas.Size = New System.Drawing.Size(129, 16)
        Me.lblBaas.TabIndex = 50
        Me.lblBaas.Text = "Baas hind (sentides)"
        '
        'btnArvuta2
        '
        Me.btnArvuta2.Location = New System.Drawing.Point(9, 258)
        Me.btnArvuta2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnArvuta2.Name = "btnArvuta2"
        Me.btnArvuta2.Size = New System.Drawing.Size(75, 23)
        Me.btnArvuta2.TabIndex = 47
        Me.btnArvuta2.Text = "Arvuta"
        Me.btnArvuta2.UseVisualStyleBackColor = True
        '
        'Graafik1
        '
        Me.Graafik1.Location = New System.Drawing.Point(-1, 308)
        Me.Graafik1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Graafik1.Name = "Graafik1"
        Me.Graafik1.Size = New System.Drawing.Size(1261, 363)
        Me.Graafik1.TabIndex = 40
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()

    End Sub

    Friend WithEvents lblKoguSum3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblKoguSum2 As Label
    Friend WithEvents lblKoguSum1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cBoxPeriood2 As ComboBox
    Friend WithEvents cboxPakett As ComboBox
    Friend WithEvents lblLopp2 As Label
    Friend WithEvents lblAlgus2 As Label
    Friend WithEvents cboxLopp2 As ComboBox
    Friend WithEvents cboxAlgus2 As ComboBox
    Friend WithEvents lblUniText As Label
    Friend WithEvents txtBaas As TextBox
    Friend WithEvents lblBaas As Label
    Friend WithEvents btnArvuta2 As Button
    Friend WithEvents Graafik1 As GraafikControl.Graafik
End Class
