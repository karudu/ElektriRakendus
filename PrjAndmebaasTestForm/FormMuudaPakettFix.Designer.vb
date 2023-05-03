<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMuudaPakettFix
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMuudaPakettFix))
        Me.TxtOTariif = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtNimi = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtKuutasu = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtPTariif = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnLisa = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TxtOTariif
        '
        resources.ApplyResources(Me.TxtOTariif, "TxtOTariif")
        Me.TxtOTariif.Name = "TxtOTariif"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'TxtNimi
        '
        resources.ApplyResources(Me.TxtNimi, "TxtNimi")
        Me.TxtNimi.Name = "TxtNimi"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'TxtKuutasu
        '
        resources.ApplyResources(Me.TxtKuutasu, "TxtKuutasu")
        Me.TxtKuutasu.Name = "TxtKuutasu"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'TxtPTariif
        '
        resources.ApplyResources(Me.TxtPTariif, "TxtPTariif")
        Me.TxtPTariif.Name = "TxtPTariif"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'BtnLisa
        '
        resources.ApplyResources(Me.BtnLisa, "BtnLisa")
        Me.BtnLisa.Name = "BtnLisa"
        Me.BtnLisa.UseVisualStyleBackColor = True
        '
        'FormMuudaPakettFix
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TxtOTariif)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtNimi)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtKuutasu)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtPTariif)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnLisa)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMuudaPakettFix"
        Me.ShowIcon = False
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtOTariif As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtNimi As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtKuutasu As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtPTariif As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnLisa As Button
End Class
