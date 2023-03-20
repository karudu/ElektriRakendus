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
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Nimi = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Juurdetasu = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Kuutasu = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'BtnLisaBors
        '
        Me.BtnLisaBors.Location = New System.Drawing.Point(667, 44)
        Me.BtnLisaBors.Name = "BtnLisaBors"
        Me.BtnLisaBors.Size = New System.Drawing.Size(195, 37)
        Me.BtnLisaBors.TabIndex = 0
        Me.BtnLisaBors.Text = "Lisa börsipakett"
        Me.BtnLisaBors.UseVisualStyleBackColor = True
        '
        'BtnLisaUniv
        '
        Me.BtnLisaUniv.Location = New System.Drawing.Point(667, 158)
        Me.BtnLisaUniv.Name = "BtnLisaUniv"
        Me.BtnLisaUniv.Size = New System.Drawing.Size(195, 37)
        Me.BtnLisaUniv.TabIndex = 1
        Me.BtnLisaUniv.Text = "Lisa universaalpakett"
        Me.BtnLisaUniv.UseVisualStyleBackColor = True
        '
        'BtnLisaFix
        '
        Me.BtnLisaFix.Location = New System.Drawing.Point(667, 102)
        Me.BtnLisaFix.Name = "BtnLisaFix"
        Me.BtnLisaFix.Size = New System.Drawing.Size(195, 37)
        Me.BtnLisaFix.TabIndex = 2
        Me.BtnLisaFix.Text = "Lisa fiks. pakett"
        Me.BtnLisaFix.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Nimi, Me.Juurdetasu, Me.Kuutasu})
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(36, 44)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(567, 181)
        Me.ListView1.TabIndex = 3
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'Nimi
        '
        Me.Nimi.Text = "Nimi"
        Me.Nimi.Width = 223
        '
        'Juurdetasu
        '
        Me.Juurdetasu.Text = "Juurdetasu (senti/kWh)"
        Me.Juurdetasu.Width = 179
        '
        'Kuutasu
        '
        Me.Kuutasu.Text = "Kuutasu (senti/kWh)"
        Me.Kuutasu.Width = 158
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(899, 450)
        Me.Controls.Add(Me.ListView1)
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
    Friend WithEvents ListView1 As ListView
    Friend WithEvents Nimi As ColumnHeader
    Friend WithEvents Juurdetasu As ColumnHeader
    Friend WithEvents Kuutasu As ColumnHeader
End Class
