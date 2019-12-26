<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThongKeCacThang
    Inherits MetroFramework.Forms.MetroForm
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmThongKeCacThang))
        Me.chartThang = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.btnThongKe = New MetroFramework.Controls.MetroButton()
        Me.dtpkFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpkToDate = New System.Windows.Forms.DateTimePicker()
        Me.btnExport = New MetroFramework.Controls.MetroButton()
        CType(Me.chartThang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chartThang
        '
        Me.chartThang.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.TileFlipXY
        Me.chartThang.BackSecondaryColor = System.Drawing.Color.Transparent
        Me.chartThang.BorderSkin.BackColor = System.Drawing.Color.DimGray
        Me.chartThang.BorderSkin.BorderWidth = 0
        ChartArea1.Name = "ChartArea1"
        Me.chartThang.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.chartThang.Legends.Add(Legend1)
        Me.chartThang.Location = New System.Drawing.Point(38, 176)
        Me.chartThang.Name = "chartThang"
        Me.chartThang.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry
        Me.chartThang.Size = New System.Drawing.Size(889, 357)
        Me.chartThang.TabIndex = 0
        Me.chartThang.Text = "Chart1"
        '
        'btnThongKe
        '
        Me.btnThongKe.Location = New System.Drawing.Point(511, 145)
        Me.btnThongKe.Name = "btnThongKe"
        Me.btnThongKe.Size = New System.Drawing.Size(114, 25)
        Me.btnThongKe.TabIndex = 4
        Me.btnThongKe.Text = "Thống kê"
        Me.btnThongKe.Theme = MetroFramework.MetroThemeStyle.Light
        '
        'dtpkFromDate
        '
        Me.dtpkFromDate.Location = New System.Drawing.Point(247, 97)
        Me.dtpkFromDate.Name = "dtpkFromDate"
        Me.dtpkFromDate.Size = New System.Drawing.Size(229, 20)
        Me.dtpkFromDate.TabIndex = 119
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(508, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 18)
        Me.Label2.TabIndex = 120
        Me.Label2.Text = "To"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(183, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 18)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "From"
        '
        'dtpkToDate
        '
        Me.dtpkToDate.Location = New System.Drawing.Point(552, 97)
        Me.dtpkToDate.Name = "dtpkToDate"
        Me.dtpkToDate.Size = New System.Drawing.Size(211, 20)
        Me.dtpkToDate.TabIndex = 122
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(362, 145)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(114, 25)
        Me.btnExport.TabIndex = 123
        Me.btnExport.Text = "Export excel"
        Me.btnExport.Theme = MetroFramework.MetroThemeStyle.Light
        '
        'frmThongKeCacThang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(950, 556)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.dtpkToDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpkFromDate)
        Me.Controls.Add(Me.btnThongKe)
        Me.Controls.Add(Me.chartThang)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmThongKeCacThang"
        Me.Text = "Thống kê lượt mượn theo tháng"
        CType(Me.chartThang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnThongKe As MetroFramework.Controls.MetroButton
    Friend WithEvents chartThang As DataVisualization.Charting.Chart
    Friend WithEvents dtpkFromDate As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpkToDate As DateTimePicker
    Friend WithEvents btnExport As MetroFramework.Controls.MetroButton
End Class
