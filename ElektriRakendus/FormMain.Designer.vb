﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.cmbPeriood = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbPkt1Tyyp = New System.Windows.Forms.ComboBox()
        Me.cmbPkt1Pkt = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbPkt2Pkt = New System.Windows.Forms.ComboBox()
        Me.cmbPkt2Tyyp = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BtnMasinad = New System.Windows.Forms.Button()
        Me.BtnPaketid = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.BtnHinnaKalkulaator = New System.Windows.Forms.Button()
        Me.BtnElektriauto = New System.Windows.Forms.Button()
        Me.BtnVordleja = New System.Windows.Forms.Button()
        Me.BtnLopphind = New System.Windows.Forms.Button()
        Me.BtnKalkKodumasinad = New System.Windows.Forms.Button()
        Me.lblPkt2Kesk = New System.Windows.Forms.Label()
        Me.lblPkt1Kesk = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpAlgus = New System.Windows.Forms.DateTimePicker()
        Me.dtpLopp = New System.Windows.Forms.DateTimePicker()
        Me.lblDtpVahe = New System.Windows.Forms.Label()
        Me.Graafik1 = New GraafikControl.Graafik()
        Me.BtnSalvestaCsv = New System.Windows.Forms.Button()
        Me.BtnTarbimiseSim = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbPeriood
        '
        Me.cmbPeriood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriood.FormattingEnabled = True
        Me.cmbPeriood.Location = New System.Drawing.Point(83, 236)
        Me.cmbPeriood.Name = "cmbPeriood"
        Me.cmbPeriood.Size = New System.Drawing.Size(121, 24)
        Me.cmbPeriood.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 239)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Periood:"
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
        'cmbPkt1Pkt
        '
        Me.cmbPkt1Pkt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPkt1Pkt.FormattingEnabled = True
        Me.cmbPkt1Pkt.Location = New System.Drawing.Point(133, 88)
        Me.cmbPkt1Pkt.Name = "cmbPkt1Pkt"
        Me.cmbPkt1Pkt.Size = New System.Drawing.Size(121, 24)
        Me.cmbPkt1Pkt.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbPkt1Pkt)
        Me.GroupBox1.Controls.Add(Me.cmbPkt1Tyyp)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(279, 169)
        Me.GroupBox1.TabIndex = 5
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmbPkt2Pkt)
        Me.GroupBox2.Controls.Add(Me.cmbPkt2Tyyp)
        Me.GroupBox2.Location = New System.Drawing.Point(311, 26)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(279, 169)
        Me.GroupBox2.TabIndex = 7
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BtnMasinad)
        Me.GroupBox3.Controls.Add(Me.BtnPaketid)
        Me.GroupBox3.Location = New System.Drawing.Point(1087, 26)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(152, 261)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Seadistamine"
        '
        'BtnMasinad
        '
        Me.BtnMasinad.Location = New System.Drawing.Point(15, 63)
        Me.BtnMasinad.Name = "BtnMasinad"
        Me.BtnMasinad.Size = New System.Drawing.Size(131, 29)
        Me.BtnMasinad.TabIndex = 9
        Me.BtnMasinad.Text = "Kodumasinad"
        Me.BtnMasinad.UseVisualStyleBackColor = True
        '
        'BtnPaketid
        '
        Me.BtnPaketid.Location = New System.Drawing.Point(15, 29)
        Me.BtnPaketid.Name = "BtnPaketid"
        Me.BtnPaketid.Size = New System.Drawing.Size(131, 28)
        Me.BtnPaketid.TabIndex = 8
        Me.BtnPaketid.Text = "Elektripaketid"
        Me.BtnPaketid.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.BtnTarbimiseSim)
        Me.GroupBox4.Controls.Add(Me.BtnHinnaKalkulaator)
        Me.GroupBox4.Controls.Add(Me.BtnElektriauto)
        Me.GroupBox4.Controls.Add(Me.BtnVordleja)
        Me.GroupBox4.Controls.Add(Me.BtnLopphind)
        Me.GroupBox4.Controls.Add(Me.BtnKalkKodumasinad)
        Me.GroupBox4.Location = New System.Drawing.Point(759, 26)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(298, 261)
        Me.GroupBox4.TabIndex = 10
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Kalkulaatorid"
        '
        'BtnHinnaKalkulaator
        '
        Me.BtnHinnaKalkulaator.Location = New System.Drawing.Point(5, 167)
        Me.BtnHinnaKalkulaator.Name = "BtnHinnaKalkulaator"
        Me.BtnHinnaKalkulaator.Size = New System.Drawing.Size(286, 28)
        Me.BtnHinnaKalkulaator.TabIndex = 14
        Me.BtnHinnaKalkulaator.Text = "Tarbimise hinna kalkulaator"
        Me.BtnHinnaKalkulaator.UseVisualStyleBackColor = True
        '
        'BtnElektriauto
        '
        Me.BtnElektriauto.Location = New System.Drawing.Point(5, 133)
        Me.BtnElektriauto.Name = "BtnElektriauto"
        Me.BtnElektriauto.Size = New System.Drawing.Size(286, 28)
        Me.BtnElektriauto.TabIndex = 13
        Me.BtnElektriauto.Text = "Elektriauto laadimise kalkulaator"
        Me.BtnElektriauto.UseVisualStyleBackColor = True
        '
        'BtnVordleja
        '
        Me.BtnVordleja.Location = New System.Drawing.Point(5, 99)
        Me.BtnVordleja.Name = "BtnVordleja"
        Me.BtnVordleja.Size = New System.Drawing.Size(286, 28)
        Me.BtnVordleja.TabIndex = 12
        Me.BtnVordleja.Text = "Hindade võrdleja"
        Me.BtnVordleja.UseVisualStyleBackColor = True
        '
        'BtnLopphind
        '
        Me.BtnLopphind.Location = New System.Drawing.Point(5, 65)
        Me.BtnLopphind.Name = "BtnLopphind"
        Me.BtnLopphind.Size = New System.Drawing.Size(286, 28)
        Me.BtnLopphind.TabIndex = 11
        Me.BtnLopphind.Text = "Lõpphinna leidja ja börsi trendid"
        Me.BtnLopphind.UseVisualStyleBackColor = True
        '
        'BtnKalkKodumasinad
        '
        Me.BtnKalkKodumasinad.Location = New System.Drawing.Point(6, 30)
        Me.BtnKalkKodumasinad.Name = "BtnKalkKodumasinad"
        Me.BtnKalkKodumasinad.Size = New System.Drawing.Size(286, 28)
        Me.BtnKalkKodumasinad.TabIndex = 10
        Me.BtnKalkKodumasinad.Text = "Arvuta kodumasina tarbimise hind"
        Me.BtnKalkKodumasinad.UseVisualStyleBackColor = True
        '
        'lblPkt2Kesk
        '
        Me.lblPkt2Kesk.AutoSize = True
        Me.lblPkt2Kesk.Location = New System.Drawing.Point(461, 277)
        Me.lblPkt2Kesk.Name = "lblPkt2Kesk"
        Me.lblPkt2Kesk.Size = New System.Drawing.Size(0, 16)
        Me.lblPkt2Kesk.TabIndex = 15
        '
        'lblPkt1Kesk
        '
        Me.lblPkt1Kesk.AutoSize = True
        Me.lblPkt1Kesk.Location = New System.Drawing.Point(461, 236)
        Me.lblPkt1Kesk.Name = "lblPkt1Kesk"
        Me.lblPkt1Kesk.Size = New System.Drawing.Size(0, 16)
        Me.lblPkt1Kesk.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(308, 277)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(147, 16)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Pakett 2 keskmine hind:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(308, 236)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(147, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Pakett 1 keskmine hind:"
        '
        'dtpAlgus
        '
        Me.dtpAlgus.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAlgus.Location = New System.Drawing.Point(12, 277)
        Me.dtpAlgus.Name = "dtpAlgus"
        Me.dtpAlgus.Size = New System.Drawing.Size(110, 22)
        Me.dtpAlgus.TabIndex = 13
        Me.dtpAlgus.Value = New Date(2023, 4, 17, 10, 39, 15, 0)
        Me.dtpAlgus.Visible = False
        '
        'dtpLopp
        '
        Me.dtpLopp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpLopp.Location = New System.Drawing.Point(145, 277)
        Me.dtpLopp.Name = "dtpLopp"
        Me.dtpLopp.Size = New System.Drawing.Size(110, 22)
        Me.dtpLopp.TabIndex = 16
        Me.dtpLopp.Value = New Date(2023, 4, 17, 10, 39, 15, 0)
        Me.dtpLopp.Visible = False
        '
        'lblDtpVahe
        '
        Me.lblDtpVahe.AutoSize = True
        Me.lblDtpVahe.Location = New System.Drawing.Point(128, 282)
        Me.lblDtpVahe.Name = "lblDtpVahe"
        Me.lblDtpVahe.Size = New System.Drawing.Size(11, 16)
        Me.lblDtpVahe.TabIndex = 17
        Me.lblDtpVahe.Text = "-"
        Me.lblDtpVahe.Visible = False
        '
        'Graafik1
        '
        Me.Graafik1.AutoSize = True
        Me.Graafik1.Location = New System.Drawing.Point(-16, 311)
        Me.Graafik1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Graafik1.Name = "Graafik1"
        Me.Graafik1.Size = New System.Drawing.Size(1283, 363)
        Me.Graafik1.TabIndex = 0
        '
        'BtnSalvestaCsv
        '
        Me.BtnSalvestaCsv.Location = New System.Drawing.Point(311, 200)
        Me.BtnSalvestaCsv.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnSalvestaCsv.Name = "BtnSalvestaCsv"
        Me.BtnSalvestaCsv.Size = New System.Drawing.Size(234, 28)
        Me.BtnSalvestaCsv.TabIndex = 18
        Me.BtnSalvestaCsv.Text = "Salvesta andmed CSV faili"
        Me.BtnSalvestaCsv.UseVisualStyleBackColor = True
        '
        'BtnTarbimiseSim
        '
        Me.BtnTarbimiseSim.Location = New System.Drawing.Point(6, 201)
        Me.BtnTarbimiseSim.Name = "BtnTarbimiseSim"
        Me.BtnTarbimiseSim.Size = New System.Drawing.Size(286, 28)
        Me.BtnTarbimiseSim.TabIndex = 15
        Me.BtnTarbimiseSim.Text = "Tarbimise ajaloo simulaator"
        Me.BtnTarbimiseSim.UseVisualStyleBackColor = True
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1262, 673)
        Me.Controls.Add(Me.BtnSalvestaCsv)
        Me.Controls.Add(Me.lblDtpVahe)
        Me.Controls.Add(Me.dtpLopp)
        Me.Controls.Add(Me.dtpAlgus)
        Me.Controls.Add(Me.lblPkt2Kesk)
        Me.Controls.Add(Me.lblPkt1Kesk)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbPeriood)
        Me.Controls.Add(Me.Graafik1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMain"
        Me.Text = "Elektri rakenduse pealkiri"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Graafik1 As GraafikControl.Graafik
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbPeriood As ComboBox
    Friend WithEvents cmbPkt1Tyyp As ComboBox
    Friend WithEvents cmbPkt1Pkt As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbPkt2Pkt As ComboBox
    Friend WithEvents cmbPkt2Tyyp As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents BtnPaketid As Button
    Friend WithEvents BtnMasinad As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents BtnKalkKodumasinad As Button
    Friend WithEvents BtnLopphind As Button
    Friend WithEvents BtnVordleja As Button
    Friend WithEvents lblPkt2Kesk As Label
    Friend WithEvents lblPkt1Kesk As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents BtnElektriauto As Button
    Friend WithEvents BtnHinnaKalkulaator As Button
    Friend WithEvents dtpAlgus As DateTimePicker
    Friend WithEvents dtpLopp As DateTimePicker
    Friend WithEvents lblDtpVahe As Label
    Friend WithEvents BtnSalvestaCsv As Button
    Friend WithEvents BtnTarbimiseSim As Button
End Class
