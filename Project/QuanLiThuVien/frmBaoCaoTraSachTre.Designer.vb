<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBaoCaoTraSachTre
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBaoCaoTraSachTre))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ThoiGianCanTimDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.ConfirmMetroButton = New MetroFramework.Controls.MetroButton()
        Me.ChiTietBaoCaoDataGridView = New System.Windows.Forms.DataGridView()
        Me.btnExport = New MetroFramework.Controls.MetroButton()
        CType(Me.ChiTietBaoCaoDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Thời gian:"
        '
        'ThoiGianCanTimDateTimePicker
        '
        Me.ThoiGianCanTimDateTimePicker.Location = New System.Drawing.Point(102, 78)
        Me.ThoiGianCanTimDateTimePicker.Name = "ThoiGianCanTimDateTimePicker"
        Me.ThoiGianCanTimDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.ThoiGianCanTimDateTimePicker.TabIndex = 1
        '
        'ConfirmMetroButton
        '
        Me.ConfirmMetroButton.Location = New System.Drawing.Point(358, 376)
        Me.ConfirmMetroButton.Name = "ConfirmMetroButton"
        Me.ConfirmMetroButton.Size = New System.Drawing.Size(75, 23)
        Me.ConfirmMetroButton.TabIndex = 2
        Me.ConfirmMetroButton.Text = "Xác nhận"
        '
        'ChiTietBaoCaoDataGridView
        '
        Me.ChiTietBaoCaoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ChiTietBaoCaoDataGridView.Location = New System.Drawing.Point(32, 117)
        Me.ChiTietBaoCaoDataGridView.Name = "ChiTietBaoCaoDataGridView"
        Me.ChiTietBaoCaoDataGridView.Size = New System.Drawing.Size(741, 238)
        Me.ChiTietBaoCaoDataGridView.TabIndex = 5
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(257, 376)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 23)
        Me.btnExport.TabIndex = 6
        Me.btnExport.Text = "Export"
        '
        'frmBaoCaoTraSachTre
        '
        Me.AcceptButton = Me.ConfirmMetroButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 423)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.ConfirmMetroButton)
        Me.Controls.Add(Me.ChiTietBaoCaoDataGridView)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ThoiGianCanTimDateTimePicker)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBaoCaoTraSachTre"
        Me.Text = "Báo cáo trá sách trễ"
        CType(Me.ChiTietBaoCaoDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ThoiGianCanTimDateTimePicker As DateTimePicker
    Friend WithEvents ConfirmMetroButton As MetroFramework.Controls.MetroButton
    Friend WithEvents ChiTietBaoCaoDataGridView As DataGridView
    Friend WithEvents btnExport As MetroFramework.Controls.MetroButton
End Class
