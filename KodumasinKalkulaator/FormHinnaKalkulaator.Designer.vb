<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormHinnaKalkulaator
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormHinnaKalkulaator))
        Me.ListAjad = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtpAlgus = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnLisa = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DtpLopp = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnKustutaAeg = New System.Windows.Forms.Button()
        Me.BtnArvuta = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtVoimsus = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CbPaketid = New System.Windows.Forms.ComboBox()
        Me.TxtHind = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListAjad
        '
        Me.ListAjad.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListAjad.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListAjad.HideSelection = False
        Me.ListAjad.Location = New System.Drawing.Point(16, 48)
        Me.ListAjad.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ListAjad.MultiSelect = False
        Me.ListAjad.Name = "ListAjad"
        Me.ListAjad.Size = New System.Drawing.Size(335, 205)
        Me.ListAjad.TabIndex = 0
        Me.ListAjad.UseCompatibleStateImageBehavior = False
        Me.ListAjad.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Algus"
        Me.ColumnHeader1.Width = 110
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Lõpp"
        Me.ColumnHeader2.Width = 110
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Ajavahemikud:"
        '
        'DtpAlgus
        '
        Me.DtpAlgus.CustomFormat = "HH:mm"
        Me.DtpAlgus.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpAlgus.Location = New System.Drawing.Point(19, 68)
        Me.DtpAlgus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DtpAlgus.Name = "DtpAlgus"
        Me.DtpAlgus.Size = New System.Drawing.Size(98, 26)
        Me.DtpAlgus.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnLisa)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.DtpLopp)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DtpAlgus)
        Me.GroupBox1.Location = New System.Drawing.Point(369, 24)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(165, 228)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lisa ajavahemik"
        '
        'BtnLisa
        '
        Me.BtnLisa.Location = New System.Drawing.Point(19, 182)
        Me.BtnLisa.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnLisa.Name = "BtnLisa"
        Me.BtnLisa.Size = New System.Drawing.Size(70, 32)
        Me.BtnLisa.TabIndex = 7
        Me.BtnLisa.Text = "Lisa"
        Me.BtnLisa.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Lõpp"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'DtpLopp
        '
        Me.DtpLopp.CustomFormat = "HH:mm"
        Me.DtpLopp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpLopp.Location = New System.Drawing.Point(19, 138)
        Me.DtpLopp.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DtpLopp.Name = "DtpLopp"
        Me.DtpLopp.Size = New System.Drawing.Size(98, 26)
        Me.DtpLopp.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Algus"
        '
        'BtnKustutaAeg
        '
        Me.BtnKustutaAeg.Location = New System.Drawing.Point(388, 258)
        Me.BtnKustutaAeg.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnKustutaAeg.Name = "BtnKustutaAeg"
        Me.BtnKustutaAeg.Size = New System.Drawing.Size(146, 32)
        Me.BtnKustutaAeg.TabIndex = 8
        Me.BtnKustutaAeg.Text = "Kustuta valitud"
        Me.BtnKustutaAeg.UseVisualStyleBackColor = True
        '
        'BtnArvuta
        '
        Me.BtnArvuta.Location = New System.Drawing.Point(16, 422)
        Me.BtnArvuta.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnArvuta.Name = "BtnArvuta"
        Me.BtnArvuta.Size = New System.Drawing.Size(134, 32)
        Me.BtnArvuta.TabIndex = 9
        Me.BtnArvuta.Text = "Arvuta hind"
        Me.BtnArvuta.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(184, 429)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Tulemus:"
        '
        'TxtVoimsus
        '
        Me.TxtVoimsus.Location = New System.Drawing.Point(16, 365)
        Me.TxtVoimsus.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtVoimsus.Name = "TxtVoimsus"
        Me.TxtVoimsus.Size = New System.Drawing.Size(112, 26)
        Me.TxtVoimsus.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 339)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(161, 20)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Tarbitud võimsus (W):"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 270)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 20)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Elektripakett:"
        '
        'CbPaketid
        '
        Me.CbPaketid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbPaketid.FormattingEnabled = True
        Me.CbPaketid.Location = New System.Drawing.Point(16, 294)
        Me.CbPaketid.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbPaketid.Name = "CbPaketid"
        Me.CbPaketid.Size = New System.Drawing.Size(188, 28)
        Me.CbPaketid.TabIndex = 14
        '
        'TxtHind
        '
        Me.TxtHind.Location = New System.Drawing.Point(261, 425)
        Me.TxtHind.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtHind.Name = "TxtHind"
        Me.TxtHind.ReadOnly = True
        Me.TxtHind.Size = New System.Drawing.Size(112, 26)
        Me.TxtHind.TabIndex = 15
        '
        'FormHinnaKalkulaator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 494)
        Me.Controls.Add(Me.TxtHind)
        Me.Controls.Add(Me.CbPaketid)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtVoimsus)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnArvuta)
        Me.Controls.Add(Me.BtnKustutaAeg)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListAjad)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormHinnaKalkulaator"
        Me.Text = "Tarbimise hinna kalkulaator"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListAjad As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents Label1 As Label
    Friend WithEvents DtpAlgus As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BtnLisa As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents DtpLopp As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnKustutaAeg As Button
    Friend WithEvents BtnArvuta As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtVoimsus As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents CbPaketid As ComboBox
    Friend WithEvents TxtHind As TextBox
End Class
