<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblAeg = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblVoimsus = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.comboMasin = New System.Windows.Forms.ComboBox()
        Me.Arvuta = New System.Windows.Forms.Button()
        Me.ListBors = New System.Windows.Forms.ListView()
        Me.Nimi = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Kodumasin"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblAeg)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.LblVoimsus)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.comboMasin)
        Me.GroupBox1.Controls.Add(Me.Arvuta)
        Me.GroupBox1.Controls.Add(Me.ListBors)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.ComboBox2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(371, 319)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Valikud"
        '
        'LblAeg
        '
        Me.LblAeg.AutoSize = True
        Me.LblAeg.Location = New System.Drawing.Point(215, 75)
        Me.LblAeg.Name = "LblAeg"
        Me.LblAeg.Size = New System.Drawing.Size(38, 16)
        Me.LblAeg.TabIndex = 17
        Me.LblAeg.Text = "0 min"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(171, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 20)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Aeg:"
        Me.Label7.UseCompatibleTextRendering = True
        '
        'LblVoimsus
        '
        Me.LblVoimsus.AutoSize = True
        Me.LblVoimsus.Location = New System.Drawing.Point(81, 75)
        Me.LblVoimsus.Name = "LblVoimsus"
        Me.LblVoimsus.Size = New System.Drawing.Size(30, 16)
        Me.LblVoimsus.TabIndex = 15
        Me.LblVoimsus.Text = "0 W"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Võimsus:"
        '
        'comboMasin
        '
        Me.comboMasin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboMasin.FormattingEnabled = True
        Me.comboMasin.Location = New System.Drawing.Point(178, 33)
        Me.comboMasin.Name = "comboMasin"
        Me.comboMasin.Size = New System.Drawing.Size(155, 24)
        Me.comboMasin.TabIndex = 13
        '
        'Arvuta
        '
        Me.Arvuta.Location = New System.Drawing.Point(258, 268)
        Me.Arvuta.Name = "Arvuta"
        Me.Arvuta.Size = New System.Drawing.Size(75, 23)
        Me.Arvuta.TabIndex = 9
        Me.Arvuta.Text = "Arvuta"
        Me.Arvuta.UseVisualStyleBackColor = True
        '
        'ListBors
        '
        Me.ListBors.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Nimi})
        Me.ListBors.HideSelection = False
        Me.ListBors.Location = New System.Drawing.Point(6, 182)
        Me.ListBors.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ListBors.MultiSelect = False
        Me.ListBors.Name = "ListBors"
        Me.ListBors.Size = New System.Drawing.Size(203, 109)
        Me.ListBors.TabIndex = 12
        Me.ListBors.UseCompatibleStateImageBehavior = False
        Me.ListBors.View = System.Windows.Forms.View.Details
        '
        'Nimi
        '
        Me.Nimi.Text = "Nimi"
        Me.Nimi.Width = 145
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 16)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Elektripaketi tüüp"
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"Börsipakett", "Fikseeritud", "Universaalteenus"})
        Me.ComboBox2.Location = New System.Drawing.Point(178, 107)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(155, 24)
        Me.ComboBox2.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Paketid:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(89, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Lõpphind"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(171, 32)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 22)
        Me.TextBox4.TabIndex = 7
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.TextBox4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(22, 360)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(371, 114)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tulemus"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(171, 69)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 22)
        Me.TextBox1.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 16)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Kuuhind (30 päeva)"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 478)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Arvuta As Button
    Friend WithEvents ListBors As ListView
    Friend WithEvents Nimi As ColumnHeader
    Friend WithEvents comboMasin As ComboBox
    Friend WithEvents LblAeg As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LblVoimsus As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label3 As Label
End Class
