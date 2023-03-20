<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.cmbPeriood = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Graafik1 = New GraafikControl.Graafik()
        Me.SuspendLayout()
        '
        'cmbPeriood
        '
        Me.cmbPeriood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriood.FormattingEnabled = True
        Me.cmbPeriood.Location = New System.Drawing.Point(1085, 222)
        Me.cmbPeriood.Name = "cmbPeriood"
        Me.cmbPeriood.Size = New System.Drawing.Size(121, 24)
        Me.cmbPeriood.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1024, 225)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Periood:"
        '
        'Graafik1
        '
        Me.Graafik1.AutoSize = True
        Me.Graafik1.Location = New System.Drawing.Point(-11, 316)
        Me.Graafik1.Name = "Graafik1"
        Me.Graafik1.Size = New System.Drawing.Size(1283, 363)
        Me.Graafik1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1262, 673)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbPeriood)
        Me.Controls.Add(Me.Graafik1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Graafik1 As GraafikControl.Graafik
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbPeriood As ComboBox
End Class
