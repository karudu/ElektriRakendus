<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Graafik
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.HinnaGraafik = New System.Windows.Forms.DataVisualization.Charting.Chart()
        CType(Me.HinnaGraafik, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HinnaGraafik
        '
        ChartArea1.AxisX.Interval = 1.0R
        ChartArea1.AxisX.IsMarginVisible = False
        ChartArea1.BackColor = System.Drawing.Color.White
        ChartArea1.BackSecondaryColor = System.Drawing.Color.White
        ChartArea1.Name = "ChartArea1"
        ChartArea1.ShadowColor = System.Drawing.Color.White
        Me.HinnaGraafik.ChartAreas.Add(ChartArea1)
        Me.HinnaGraafik.Cursor = System.Windows.Forms.Cursors.Arrow
        Legend1.Name = "Legend1"
        Me.HinnaGraafik.Legends.Add(Legend1)
        Me.HinnaGraafik.Location = New System.Drawing.Point(3, 0)
        Me.HinnaGraafik.Name = "HinnaGraafik"
        Me.HinnaGraafik.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Series1.BorderWidth = 3
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine
        Series1.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Series1.IsXValueIndexed = True
        Series1.Legend = "Legend1"
        Series1.Name = "Pakett 1"
        Series1.YValuesPerPoint = 2
        Series2.BorderWidth = 3
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine
        Series2.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Series2.IsXValueIndexed = True
        Series2.Legend = "Legend1"
        Series2.Name = "Pakett 2"
        Me.HinnaGraafik.Series.Add(Series1)
        Me.HinnaGraafik.Series.Add(Series2)
        Me.HinnaGraafik.Size = New System.Drawing.Size(1277, 360)
        Me.HinnaGraafik.TabIndex = 0
        Me.HinnaGraafik.Text = "Chart1"
        '
        'Graafik
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.HinnaGraafik)
        Me.Name = "Graafik"
        Me.Size = New System.Drawing.Size(1280, 360)
        CType(Me.HinnaGraafik, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents HinnaGraafik As DataVisualization.Charting.Chart
End Class
