<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalvestaCsv
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
        Me.TxtEraldaja = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblNimi = New System.Windows.Forms.Label()
        Me.LblPath = New System.Windows.Forms.Label()
        Me.RbKirjutaYle = New System.Windows.Forms.RadioButton()
        Me.RbSalvestaLoppu = New System.Windows.Forms.RadioButton()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnSaveAs = New System.Windows.Forms.Button()
        Me.TxtKval = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TxtEraldaja
        '
        Me.TxtEraldaja.Location = New System.Drawing.Point(146, 114)
        Me.TxtEraldaja.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtEraldaja.MaxLength = 1
        Me.TxtEraldaja.Name = "TxtEraldaja"
        Me.TxtEraldaja.Size = New System.Drawing.Size(34, 26)
        Me.TxtEraldaja.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(55, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Eraldaja"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 158)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Kvalifikaator"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Faili nimi:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(30, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Faili asukoht:"
        '
        'LblNimi
        '
        Me.LblNimi.AutoSize = True
        Me.LblNimi.Location = New System.Drawing.Point(143, 26)
        Me.LblNimi.Name = "LblNimi"
        Me.LblNimi.Size = New System.Drawing.Size(57, 20)
        Me.LblNimi.TabIndex = 6
        Me.LblNimi.Text = "Label5"
        '
        'LblPath
        '
        Me.LblPath.AutoSize = True
        Me.LblPath.Location = New System.Drawing.Point(143, 64)
        Me.LblPath.Name = "LblPath"
        Me.LblPath.Size = New System.Drawing.Size(57, 20)
        Me.LblPath.TabIndex = 7
        Me.LblPath.Text = "Label6"
        '
        'RbKirjutaYle
        '
        Me.RbKirjutaYle.AutoSize = True
        Me.RbKirjutaYle.Location = New System.Drawing.Point(34, 228)
        Me.RbKirjutaYle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RbKirjutaYle.Name = "RbKirjutaYle"
        Me.RbKirjutaYle.Size = New System.Drawing.Size(103, 24)
        Me.RbKirjutaYle.TabIndex = 9
        Me.RbKirjutaYle.Text = "Kirjuta üle"
        Me.RbKirjutaYle.UseVisualStyleBackColor = True
        '
        'RbSalvestaLoppu
        '
        Me.RbSalvestaLoppu.AutoSize = True
        Me.RbSalvestaLoppu.Location = New System.Drawing.Point(146, 228)
        Me.RbSalvestaLoppu.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RbSalvestaLoppu.Name = "RbSalvestaLoppu"
        Me.RbSalvestaLoppu.Size = New System.Drawing.Size(133, 24)
        Me.RbSalvestaLoppu.TabIndex = 10
        Me.RbSalvestaLoppu.Text = "Lisa faili lõppu"
        Me.RbSalvestaLoppu.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(24, 279)
        Me.BtnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(97, 36)
        Me.BtnSave.TabIndex = 11
        Me.BtnSave.Text = "Salvesta"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnSaveAs
        '
        Me.BtnSaveAs.Location = New System.Drawing.Point(146, 279)
        Me.BtnSaveAs.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnSaveAs.Name = "BtnSaveAs"
        Me.BtnSaveAs.Size = New System.Drawing.Size(143, 36)
        Me.BtnSaveAs.TabIndex = 12
        Me.BtnSaveAs.Text = "Salvesta nimega"
        Me.BtnSaveAs.UseVisualStyleBackColor = True
        '
        'TxtKval
        '
        Me.TxtKval.Location = New System.Drawing.Point(146, 154)
        Me.TxtKval.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtKval.MaxLength = 1
        Me.TxtKval.Name = "TxtKval"
        Me.TxtKval.Size = New System.Drawing.Size(34, 26)
        Me.TxtKval.TabIndex = 13
        '
        'FormSalvestaCsv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 330)
        Me.Controls.Add(Me.TxtKval)
        Me.Controls.Add(Me.BtnSaveAs)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.RbSalvestaLoppu)
        Me.Controls.Add(Me.RbKirjutaYle)
        Me.Controls.Add(Me.LblPath)
        Me.Controls.Add(Me.LblNimi)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtEraldaja)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSalvestaCsv"
        Me.ShowIcon = False
        Me.Text = "Salvesta andmed CSV faili..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtEraldaja As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LblNimi As Label
    Friend WithEvents LblPath As Label
    Friend WithEvents RbKirjutaYle As RadioButton
    Friend WithEvents RbSalvestaLoppu As RadioButton
    Friend WithEvents BtnSave As Button
    Friend WithEvents BtnSaveAs As Button
    Friend WithEvents TxtKval As TextBox
End Class
