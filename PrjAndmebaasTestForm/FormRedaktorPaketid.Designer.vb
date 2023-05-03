<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRedaktorPaketid
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormRedaktorPaketid))
        Me.BtnLisaBors = New System.Windows.Forms.Button()
        Me.BtnLisaUniv = New System.Windows.Forms.Button()
        Me.BtnLisaFix = New System.Windows.Forms.Button()
        Me.ListBors = New System.Windows.Forms.ListView()
        Me.Nimi = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Juurdetasu = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Kuutasu = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListFix = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListUniv = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Universaalpaketid = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnMuudaBors = New System.Windows.Forms.Button()
        Me.BtnKustutaBors = New System.Windows.Forms.Button()
        Me.BtnKustutaFix = New System.Windows.Forms.Button()
        Me.BtnMuudaFix = New System.Windows.Forms.Button()
        Me.BtnKustutaUniv = New System.Windows.Forms.Button()
        Me.BtnMuudaUniv = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnLisaBors
        '
        Me.BtnLisaBors.Location = New System.Drawing.Point(677, 38)
        Me.BtnLisaBors.Name = "BtnLisaBors"
        Me.BtnLisaBors.Size = New System.Drawing.Size(130, 37)
        Me.BtnLisaBors.TabIndex = 0
        Me.BtnLisaBors.Text = "Uus"
        Me.BtnLisaBors.UseVisualStyleBackColor = True
        '
        'BtnLisaUniv
        '
        Me.BtnLisaUniv.Location = New System.Drawing.Point(677, 415)
        Me.BtnLisaUniv.Name = "BtnLisaUniv"
        Me.BtnLisaUniv.Size = New System.Drawing.Size(130, 37)
        Me.BtnLisaUniv.TabIndex = 1
        Me.BtnLisaUniv.Text = "Uus"
        Me.BtnLisaUniv.UseVisualStyleBackColor = True
        '
        'BtnLisaFix
        '
        Me.BtnLisaFix.Location = New System.Drawing.Point(677, 226)
        Me.BtnLisaFix.Name = "BtnLisaFix"
        Me.BtnLisaFix.Size = New System.Drawing.Size(130, 37)
        Me.BtnLisaFix.TabIndex = 2
        Me.BtnLisaFix.Text = "Uus"
        Me.BtnLisaFix.UseVisualStyleBackColor = True
        '
        'ListBors
        '
        Me.ListBors.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Nimi, Me.Juurdetasu, Me.Kuutasu})
        Me.ListBors.HideSelection = False
        Me.ListBors.Location = New System.Drawing.Point(28, 38)
        Me.ListBors.MultiSelect = False
        Me.ListBors.Name = "ListBors"
        Me.ListBors.Size = New System.Drawing.Size(629, 149)
        Me.ListBors.TabIndex = 3
        Me.ListBors.UseCompatibleStateImageBehavior = False
        Me.ListBors.View = System.Windows.Forms.View.Details
        '
        'Nimi
        '
        Me.Nimi.Text = "Nimi"
        Me.Nimi.Width = 145
        '
        'Juurdetasu
        '
        Me.Juurdetasu.Text = "Juurdetasu"
        Me.Juurdetasu.Width = 100
        '
        'Kuutasu
        '
        Me.Kuutasu.Text = "Kuutasu"
        Me.Kuutasu.Width = 80
        '
        'ListFix
        '
        Me.ListFix.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader7})
        Me.ListFix.HideSelection = False
        Me.ListFix.Location = New System.Drawing.Point(28, 226)
        Me.ListFix.MultiSelect = False
        Me.ListFix.Name = "ListFix"
        Me.ListFix.Size = New System.Drawing.Size(629, 149)
        Me.ListFix.TabIndex = 5
        Me.ListFix.UseCompatibleStateImageBehavior = False
        Me.ListFix.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nimi"
        Me.ColumnHeader1.Width = 140
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Päevatariif"
        Me.ColumnHeader2.Width = 100
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Öötariif"
        Me.ColumnHeader3.Width = 100
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Kuutasu"
        '
        'ListUniv
        '
        Me.ListUniv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader8})
        Me.ListUniv.HideSelection = False
        Me.ListUniv.Location = New System.Drawing.Point(28, 415)
        Me.ListUniv.MultiSelect = False
        Me.ListUniv.Name = "ListUniv"
        Me.ListUniv.Size = New System.Drawing.Size(629, 149)
        Me.ListUniv.TabIndex = 6
        Me.ListUniv.UseCompatibleStateImageBehavior = False
        Me.ListUniv.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Nimi"
        Me.ColumnHeader4.Width = 140
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Baashind"
        Me.ColumnHeader5.Width = 100
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Marginaal"
        Me.ColumnHeader6.Width = 100
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Kuutasu"
        '
        'Universaalpaketid
        '
        Me.Universaalpaketid.AutoSize = True
        Me.Universaalpaketid.Location = New System.Drawing.Point(24, 392)
        Me.Universaalpaketid.Name = "Universaalpaketid"
        Me.Universaalpaketid.Size = New System.Drawing.Size(135, 20)
        Me.Universaalpaketid.TabIndex = 7
        Me.Universaalpaketid.Text = "Universaalpaketid"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 202)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 20)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Fikseeritud paketid"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Börsipaketid"
        '
        'BtnMuudaBors
        '
        Me.BtnMuudaBors.Location = New System.Drawing.Point(677, 81)
        Me.BtnMuudaBors.Name = "BtnMuudaBors"
        Me.BtnMuudaBors.Size = New System.Drawing.Size(130, 37)
        Me.BtnMuudaBors.TabIndex = 10
        Me.BtnMuudaBors.Text = "Muuda"
        Me.BtnMuudaBors.UseVisualStyleBackColor = True
        '
        'BtnKustutaBors
        '
        Me.BtnKustutaBors.Location = New System.Drawing.Point(677, 124)
        Me.BtnKustutaBors.Name = "BtnKustutaBors"
        Me.BtnKustutaBors.Size = New System.Drawing.Size(130, 37)
        Me.BtnKustutaBors.TabIndex = 11
        Me.BtnKustutaBors.Text = "Kustuta"
        Me.BtnKustutaBors.UseVisualStyleBackColor = True
        '
        'BtnKustutaFix
        '
        Me.BtnKustutaFix.Location = New System.Drawing.Point(677, 312)
        Me.BtnKustutaFix.Name = "BtnKustutaFix"
        Me.BtnKustutaFix.Size = New System.Drawing.Size(130, 37)
        Me.BtnKustutaFix.TabIndex = 13
        Me.BtnKustutaFix.Text = "Kustuta"
        Me.BtnKustutaFix.UseVisualStyleBackColor = True
        '
        'BtnMuudaFix
        '
        Me.BtnMuudaFix.Location = New System.Drawing.Point(677, 269)
        Me.BtnMuudaFix.Name = "BtnMuudaFix"
        Me.BtnMuudaFix.Size = New System.Drawing.Size(130, 37)
        Me.BtnMuudaFix.TabIndex = 12
        Me.BtnMuudaFix.Text = "Muuda"
        Me.BtnMuudaFix.UseVisualStyleBackColor = True
        '
        'BtnKustutaUniv
        '
        Me.BtnKustutaUniv.Location = New System.Drawing.Point(677, 501)
        Me.BtnKustutaUniv.Name = "BtnKustutaUniv"
        Me.BtnKustutaUniv.Size = New System.Drawing.Size(130, 37)
        Me.BtnKustutaUniv.TabIndex = 15
        Me.BtnKustutaUniv.Text = "Kustuta"
        Me.BtnKustutaUniv.UseVisualStyleBackColor = True
        '
        'BtnMuudaUniv
        '
        Me.BtnMuudaUniv.Location = New System.Drawing.Point(677, 458)
        Me.BtnMuudaUniv.Name = "BtnMuudaUniv"
        Me.BtnMuudaUniv.Size = New System.Drawing.Size(130, 37)
        Me.BtnMuudaUniv.TabIndex = 14
        Me.BtnMuudaUniv.Text = "Muuda"
        Me.BtnMuudaUniv.UseVisualStyleBackColor = True
        '
        'FormRedaktorPaketid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 576)
        Me.Controls.Add(Me.BtnKustutaUniv)
        Me.Controls.Add(Me.BtnMuudaUniv)
        Me.Controls.Add(Me.BtnKustutaFix)
        Me.Controls.Add(Me.BtnMuudaFix)
        Me.Controls.Add(Me.BtnKustutaBors)
        Me.Controls.Add(Me.BtnMuudaBors)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Universaalpaketid)
        Me.Controls.Add(Me.ListUniv)
        Me.Controls.Add(Me.ListFix)
        Me.Controls.Add(Me.ListBors)
        Me.Controls.Add(Me.BtnLisaFix)
        Me.Controls.Add(Me.BtnLisaUniv)
        Me.Controls.Add(Me.BtnLisaBors)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormRedaktorPaketid"
        Me.Text = "Elektripaketid"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnLisaBors As Button
    Friend WithEvents BtnLisaUniv As Button
    Friend WithEvents BtnLisaFix As Button
    Friend WithEvents ListBors As ListView
    Friend WithEvents Nimi As ColumnHeader
    Friend WithEvents Juurdetasu As ColumnHeader
    Friend WithEvents Kuutasu As ColumnHeader
    Friend WithEvents ListFix As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ListUniv As ListView
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents Universaalpaketid As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents BtnMuudaBors As Button
    Friend WithEvents BtnKustutaBors As Button
    Friend WithEvents BtnKustutaFix As Button
    Friend WithEvents BtnMuudaFix As Button
    Friend WithEvents BtnKustutaUniv As Button
    Friend WithEvents BtnMuudaUniv As Button
End Class
