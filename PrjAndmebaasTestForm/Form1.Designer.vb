<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.BtnLisaBors = New System.Windows.Forms.Button()
        Me.BtnLisaUniv = New System.Windows.Forms.Button()
        Me.BtnLisaFix = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnLisaBors
        '
        Me.BtnLisaBors.Location = New System.Drawing.Point(36, 33)
        Me.BtnLisaBors.Name = "BtnLisaBors"
        Me.BtnLisaBors.Size = New System.Drawing.Size(195, 37)
        Me.BtnLisaBors.TabIndex = 0
        Me.BtnLisaBors.Text = "Lisa börsipakett"
        Me.BtnLisaBors.UseVisualStyleBackColor = True
        '
        'BtnLisaUniv
        '
        Me.BtnLisaUniv.Location = New System.Drawing.Point(36, 147)
        Me.BtnLisaUniv.Name = "BtnLisaUniv"
        Me.BtnLisaUniv.Size = New System.Drawing.Size(195, 37)
        Me.BtnLisaUniv.TabIndex = 1
        Me.BtnLisaUniv.Text = "Lisa universaalpakett"
        Me.BtnLisaUniv.UseVisualStyleBackColor = True
        '
        'BtnLisaFix
        '
        Me.BtnLisaFix.Location = New System.Drawing.Point(36, 91)
        Me.BtnLisaFix.Name = "BtnLisaFix"
        Me.BtnLisaFix.Size = New System.Drawing.Size(195, 37)
        Me.BtnLisaFix.TabIndex = 2
        Me.BtnLisaFix.Text = "Lisa fiks. pakett"
        Me.BtnLisaFix.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.BtnLisaFix)
        Me.Controls.Add(Me.BtnLisaUniv)
        Me.Controls.Add(Me.BtnLisaBors)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnLisaBors As Button
    Friend WithEvents BtnLisaUniv As Button
    Friend WithEvents BtnLisaFix As Button
End Class
