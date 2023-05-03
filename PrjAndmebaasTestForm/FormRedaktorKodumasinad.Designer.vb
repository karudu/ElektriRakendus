<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormRedaktorKodumasinad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormRedaktorKodumasinad))
        Me.BtnKustutaMasin = New System.Windows.Forms.Button()
        Me.BtnMuudaMasin = New System.Windows.Forms.Button()
        Me.ListMasinad = New System.Windows.Forms.ListView()
        Me.Nimi = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Voimsus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Aeg = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BtnLisaMasin = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnKustutaMasin
        '
        Me.BtnKustutaMasin.Location = New System.Drawing.Point(544, 98)
        Me.BtnKustutaMasin.Name = "BtnKustutaMasin"
        Me.BtnKustutaMasin.Size = New System.Drawing.Size(130, 37)
        Me.BtnKustutaMasin.TabIndex = 15
        Me.BtnKustutaMasin.Text = "Kustuta"
        Me.BtnKustutaMasin.UseVisualStyleBackColor = True
        '
        'BtnMuudaMasin
        '
        Me.BtnMuudaMasin.Location = New System.Drawing.Point(544, 55)
        Me.BtnMuudaMasin.Name = "BtnMuudaMasin"
        Me.BtnMuudaMasin.Size = New System.Drawing.Size(130, 37)
        Me.BtnMuudaMasin.TabIndex = 14
        Me.BtnMuudaMasin.Text = "Muuda"
        Me.BtnMuudaMasin.UseVisualStyleBackColor = True
        '
        'ListMasinad
        '
        Me.ListMasinad.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Nimi, Me.Voimsus, Me.Aeg})
        Me.ListMasinad.HideSelection = False
        Me.ListMasinad.Location = New System.Drawing.Point(12, 12)
        Me.ListMasinad.MultiSelect = False
        Me.ListMasinad.Name = "ListMasinad"
        Me.ListMasinad.Size = New System.Drawing.Size(526, 149)
        Me.ListMasinad.TabIndex = 13
        Me.ListMasinad.UseCompatibleStateImageBehavior = False
        Me.ListMasinad.View = System.Windows.Forms.View.Details
        '
        'Nimi
        '
        Me.Nimi.Text = "Nimi"
        Me.Nimi.Width = 145
        '
        'Voimsus
        '
        Me.Voimsus.Text = "Võimsus"
        Me.Voimsus.Width = 100
        '
        'Aeg
        '
        Me.Aeg.Text = "Kasutuse aeg"
        Me.Aeg.Width = 80
        '
        'BtnLisaMasin
        '
        Me.BtnLisaMasin.Location = New System.Drawing.Point(544, 12)
        Me.BtnLisaMasin.Name = "BtnLisaMasin"
        Me.BtnLisaMasin.Size = New System.Drawing.Size(130, 37)
        Me.BtnLisaMasin.TabIndex = 12
        Me.BtnLisaMasin.Text = "Uus"
        Me.BtnLisaMasin.UseVisualStyleBackColor = True
        '
        'FormRedaktorKodumasinad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 176)
        Me.Controls.Add(Me.BtnKustutaMasin)
        Me.Controls.Add(Me.BtnMuudaMasin)
        Me.Controls.Add(Me.ListMasinad)
        Me.Controls.Add(Me.BtnLisaMasin)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormRedaktorKodumasinad"
        Me.Text = "Kodumasinad"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnKustutaMasin As Button
    Friend WithEvents BtnMuudaMasin As Button
    Friend WithEvents ListMasinad As ListView
    Friend WithEvents Nimi As ColumnHeader
    Friend WithEvents Voimsus As ColumnHeader
    Friend WithEvents Aeg As ColumnHeader
    Friend WithEvents BtnLisaMasin As Button
End Class
