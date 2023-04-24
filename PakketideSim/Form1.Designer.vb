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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbPkt2Pkt = New System.Windows.Forms.ComboBox()
        Me.cmbPkt2Tyyp = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbPkt1Pkt = New System.Windows.Forms.ComboBox()
        Me.cmbPkt1Tyyp = New System.Windows.Forms.ComboBox()
        Me.lblPkt2Kesk = New System.Windows.Forms.Label()
        Me.lblPkt1Kesk = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Graafik1 = New GraafikControl.Graafik()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(63, 25)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(326, 173)
        Me.DataGridView1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(63, 204)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(170, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Sisesta CSV fail"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmbPkt2Pkt)
        Me.GroupBox2.Controls.Add(Me.cmbPkt2Tyyp)
        Me.GroupBox2.Location = New System.Drawing.Point(932, 58)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(279, 169)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pakett 2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(63, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Pakett:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(35, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Paketi tüüp:"
        '
        'cmbPkt2Pkt
        '
        Me.cmbPkt2Pkt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPkt2Pkt.FormattingEnabled = True
        Me.cmbPkt2Pkt.Location = New System.Drawing.Point(133, 88)
        Me.cmbPkt2Pkt.Name = "cmbPkt2Pkt"
        Me.cmbPkt2Pkt.Size = New System.Drawing.Size(121, 24)
        Me.cmbPkt2Pkt.TabIndex = 4
        '
        'cmbPkt2Tyyp
        '
        Me.cmbPkt2Tyyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPkt2Tyyp.FormattingEnabled = True
        Me.cmbPkt2Tyyp.Location = New System.Drawing.Point(133, 33)
        Me.cmbPkt2Tyyp.Name = "cmbPkt2Tyyp"
        Me.cmbPkt2Tyyp.Size = New System.Drawing.Size(121, 24)
        Me.cmbPkt2Tyyp.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbPkt1Pkt)
        Me.GroupBox1.Controls.Add(Me.cmbPkt1Tyyp)
        Me.GroupBox1.Location = New System.Drawing.Point(621, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(279, 169)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pakett 1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(68, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Pakett:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Paketi tüüp:"
        '
        'cmbPkt1Pkt
        '
        Me.cmbPkt1Pkt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPkt1Pkt.FormattingEnabled = True
        Me.cmbPkt1Pkt.Location = New System.Drawing.Point(133, 88)
        Me.cmbPkt1Pkt.Name = "cmbPkt1Pkt"
        Me.cmbPkt1Pkt.Size = New System.Drawing.Size(121, 24)
        Me.cmbPkt1Pkt.TabIndex = 4
        '
        'cmbPkt1Tyyp
        '
        Me.cmbPkt1Tyyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPkt1Tyyp.FormattingEnabled = True
        Me.cmbPkt1Tyyp.Location = New System.Drawing.Point(133, 33)
        Me.cmbPkt1Tyyp.Name = "cmbPkt1Tyyp"
        Me.cmbPkt1Tyyp.Size = New System.Drawing.Size(121, 24)
        Me.cmbPkt1Tyyp.TabIndex = 3
        '
        'lblPkt2Kesk
        '
        Me.lblPkt2Kesk.AutoSize = True
        Me.lblPkt2Kesk.Location = New System.Drawing.Point(816, 281)
        Me.lblPkt2Kesk.Name = "lblPkt2Kesk"
        Me.lblPkt2Kesk.Size = New System.Drawing.Size(0, 16)
        Me.lblPkt2Kesk.TabIndex = 16
        '
        'lblPkt1Kesk
        '
        Me.lblPkt1Kesk.AutoSize = True
        Me.lblPkt1Kesk.Location = New System.Drawing.Point(815, 240)
        Me.lblPkt1Kesk.Name = "lblPkt1Kesk"
        Me.lblPkt1Kesk.Size = New System.Drawing.Size(0, 16)
        Me.lblPkt1Kesk.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(661, 271)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(147, 16)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Pakett 2 keskmine hind:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(661, 240)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(147, 16)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Pakett 1 keskmine hind:"
        '
        'Graafik1
        '
        Me.Graafik1.AutoSize = True
        Me.Graafik1.Location = New System.Drawing.Point(12, 291)
        Me.Graafik1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Graafik1.Name = "Graafik1"
        Me.Graafik1.Size = New System.Drawing.Size(1283, 363)
        Me.Graafik1.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1309, 665)
        Me.Controls.Add(Me.lblPkt2Kesk)
        Me.Controls.Add(Me.lblPkt1Kesk)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Graafik1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents Graafik1 As GraafikControl.Graafik
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbPkt2Pkt As ComboBox
    Friend WithEvents cmbPkt2Tyyp As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbPkt1Pkt As ComboBox
    Friend WithEvents cmbPkt1Tyyp As ComboBox
    Friend WithEvents lblPkt2Kesk As Label
    Friend WithEvents lblPkt1Kesk As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
End Class
