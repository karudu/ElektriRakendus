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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Graafik1 = New GraafikControl.Graafik()
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbPeriood = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
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
        Me.Button1.Location = New System.Drawing.Point(314, 204)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Graafik1
        '
        Me.Graafik1.AutoSize = True
        Me.Graafik1.Location = New System.Drawing.Point(-8, 277)
        Me.Graafik1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Graafik1.Name = "Graafik1"
        Me.Graafik1.Size = New System.Drawing.Size(1283, 363)
        Me.Graafik1.TabIndex = 2
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1029, 249)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Periood:"
        '
        'cmbPeriood
        '
        Me.cmbPeriood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriood.FormattingEnabled = True
        Me.cmbPeriood.Location = New System.Drawing.Point(1090, 246)
        Me.cmbPeriood.Name = "cmbPeriood"
        Me.cmbPeriood.Size = New System.Drawing.Size(121, 24)
        Me.cmbPeriood.TabIndex = 10
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(207, 234)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(252, 22)
        Me.TextBox1.TabIndex = 12
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1267, 625)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbPeriood)
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
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbPeriood As ComboBox
    Friend WithEvents TextBox1 As TextBox
End Class
