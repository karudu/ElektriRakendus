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
        Me.txtLoppHind = New System.Windows.Forms.TextBox()
        Me.lblLoppHind = New System.Windows.Forms.Label()
        Me.lblPakett1 = New System.Windows.Forms.Label()
        Me.cboxPakett1 = New System.Windows.Forms.ComboBox()
        Me.lblPakett2 = New System.Windows.Forms.Label()
        Me.cboxPakett2 = New System.Windows.Forms.ComboBox()
        Me.lblAjav = New System.Windows.Forms.Label()
        Me.cboxAjavAlgus = New System.Windows.Forms.ComboBox()
        Me.cboxAjavLopp = New System.Windows.Forms.ComboBox()
        Me.lblAjavAlgus = New System.Windows.Forms.Label()
        Me.lblAjavLopp = New System.Windows.Forms.Label()
        Me.btnArvuta = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtLoppHind
        '
        Me.txtLoppHind.Location = New System.Drawing.Point(560, 59)
        Me.txtLoppHind.Name = "txtLoppHind"
        Me.txtLoppHind.ReadOnly = True
        Me.txtLoppHind.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtLoppHind.Size = New System.Drawing.Size(210, 22)
        Me.txtLoppHind.TabIndex = 0
        Me.txtLoppHind.Text = "Empty"
        '
        'lblLoppHind
        '
        Me.lblLoppHind.AutoSize = True
        Me.lblLoppHind.Location = New System.Drawing.Point(557, 9)
        Me.lblLoppHind.Name = "lblLoppHind"
        Me.lblLoppHind.Size = New System.Drawing.Size(63, 16)
        Me.lblLoppHind.TabIndex = 1
        Me.lblLoppHind.Text = "Lõpphind"
        '
        'lblPakett1
        '
        Me.lblPakett1.AutoSize = True
        Me.lblPakett1.Location = New System.Drawing.Point(12, 9)
        Me.lblPakett1.Name = "lblPakett1"
        Me.lblPakett1.Size = New System.Drawing.Size(55, 16)
        Me.lblPakett1.TabIndex = 2
        Me.lblPakett1.Text = "Pakett 1"
        '
        'cboxPakett1
        '
        Me.cboxPakett1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxPakett1.FormattingEnabled = True
        Me.cboxPakett1.Items.AddRange(New Object() {"Börsihind", "Fikseeritud hind", "Universaalteenus", "Universaalteenusega seotud pakett"})
        Me.cboxPakett1.Location = New System.Drawing.Point(12, 59)
        Me.cboxPakett1.Name = "cboxPakett1"
        Me.cboxPakett1.Size = New System.Drawing.Size(121, 24)
        Me.cboxPakett1.TabIndex = 3
        '
        'lblPakett2
        '
        Me.lblPakett2.AutoSize = True
        Me.lblPakett2.Location = New System.Drawing.Point(146, 9)
        Me.lblPakett2.Name = "lblPakett2"
        Me.lblPakett2.Size = New System.Drawing.Size(55, 16)
        Me.lblPakett2.TabIndex = 4
        Me.lblPakett2.Text = "Pakett 2"
        '
        'cboxPakett2
        '
        Me.cboxPakett2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxPakett2.FormattingEnabled = True
        Me.cboxPakett2.Items.AddRange(New Object() {"Börsihind", "Fikseeritud hind", "Universaalteenus", "Universaalteenusega seotud pakett"})
        Me.cboxPakett2.Location = New System.Drawing.Point(149, 59)
        Me.cboxPakett2.Name = "cboxPakett2"
        Me.cboxPakett2.Size = New System.Drawing.Size(121, 24)
        Me.cboxPakett2.TabIndex = 5
        '
        'lblAjav
        '
        Me.lblAjav.AutoSize = True
        Me.lblAjav.Location = New System.Drawing.Point(282, 9)
        Me.lblAjav.Name = "lblAjav"
        Me.lblAjav.Size = New System.Drawing.Size(78, 16)
        Me.lblAjav.TabIndex = 6
        Me.lblAjav.Text = "Ajavahemik"
        '
        'cboxAjavAlgus
        '
        Me.cboxAjavAlgus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxAjavAlgus.FormattingEnabled = True
        Me.cboxAjavAlgus.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.cboxAjavAlgus.Location = New System.Drawing.Point(285, 59)
        Me.cboxAjavAlgus.Name = "cboxAjavAlgus"
        Me.cboxAjavAlgus.Size = New System.Drawing.Size(75, 24)
        Me.cboxAjavAlgus.TabIndex = 7
        '
        'cboxAjavLopp
        '
        Me.cboxAjavLopp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxAjavLopp.FormattingEnabled = True
        Me.cboxAjavLopp.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.cboxAjavLopp.Location = New System.Drawing.Point(366, 59)
        Me.cboxAjavLopp.Name = "cboxAjavLopp"
        Me.cboxAjavLopp.Size = New System.Drawing.Size(75, 24)
        Me.cboxAjavLopp.TabIndex = 8
        '
        'lblAjavAlgus
        '
        Me.lblAjavAlgus.AutoSize = True
        Me.lblAjavAlgus.Location = New System.Drawing.Point(282, 34)
        Me.lblAjavAlgus.Name = "lblAjavAlgus"
        Me.lblAjavAlgus.Size = New System.Drawing.Size(41, 16)
        Me.lblAjavAlgus.TabIndex = 9
        Me.lblAjavAlgus.Text = "Algus"
        '
        'lblAjavLopp
        '
        Me.lblAjavLopp.AutoSize = True
        Me.lblAjavLopp.Location = New System.Drawing.Point(363, 34)
        Me.lblAjavLopp.Name = "lblAjavLopp"
        Me.lblAjavLopp.Size = New System.Drawing.Size(38, 16)
        Me.lblAjavLopp.TabIndex = 10
        Me.lblAjavLopp.Text = "Lõpp"
        '
        'btnArvuta
        '
        Me.btnArvuta.Location = New System.Drawing.Point(463, 59)
        Me.btnArvuta.Name = "btnArvuta"
        Me.btnArvuta.Size = New System.Drawing.Size(75, 23)
        Me.btnArvuta.TabIndex = 11
        Me.btnArvuta.Text = "Arvuta"
        Me.btnArvuta.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 553)
        Me.Controls.Add(Me.btnArvuta)
        Me.Controls.Add(Me.lblAjavLopp)
        Me.Controls.Add(Me.lblAjavAlgus)
        Me.Controls.Add(Me.cboxAjavLopp)
        Me.Controls.Add(Me.cboxAjavAlgus)
        Me.Controls.Add(Me.lblAjav)
        Me.Controls.Add(Me.cboxPakett2)
        Me.Controls.Add(Me.lblPakett2)
        Me.Controls.Add(Me.cboxPakett1)
        Me.Controls.Add(Me.lblPakett1)
        Me.Controls.Add(Me.lblLoppHind)
        Me.Controls.Add(Me.txtLoppHind)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtLoppHind As TextBox
    Friend WithEvents lblLoppHind As Label
    Friend WithEvents lblPakett1 As Label
    Friend WithEvents cboxPakett1 As ComboBox
    Friend WithEvents lblPakett2 As Label
    Friend WithEvents cboxPakett2 As ComboBox
    Friend WithEvents lblAjav As Label
    Friend WithEvents cboxAjavAlgus As ComboBox
    Friend WithEvents cboxAjavLopp As ComboBox
    Friend WithEvents lblAjavAlgus As Label
    Friend WithEvents lblAjavLopp As Label
    Friend WithEvents btnArvuta As Button
End Class
