<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmQuanLiSach
    Inherits MetroFramework.Forms.MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQuanLiSach))
        Me.DataGridViewQuanLiSach = New System.Windows.Forms.DataGridView()
        Me.MinPriceNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.dpNamXBCanTimMin = New System.Windows.Forms.DateTimePicker()
        Me.cbTacGiaCanTim = New System.Windows.Forms.ComboBox()
        Me.cbTheLoaiCanTim = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dpNamXBCanTimMax = New System.Windows.Forms.DateTimePicker()
        Me.cbNhaXuatBanCanTim = New System.Windows.Forms.ComboBox()
        Me.cbTenSachCanTim = New System.Windows.Forms.ComboBox()
        Me.MaxPriceNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnFilter = New MetroFramework.Controls.MetroButton()
        Me.txtMaDauSachDangChon = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.nudTriGiaDangChon = New System.Windows.Forms.NumericUpDown()
        Me.dpNamXBDangChon = New System.Windows.Forms.DateTimePicker()
        Me.cbTacGiaDangChon = New System.Windows.Forms.ComboBox()
        Me.cbTheLoaiDangChon = New System.Windows.Forms.ComboBox()
        Me.txtTenNxbDangChon = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTenSachDangChon = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnUpdate = New MetroFramework.Controls.MetroButton()
        Me.btnDelete = New MetroFramework.Controls.MetroButton()
        Me.GroupBoxThongTinSachCanTim = New System.Windows.Forms.GroupBox()
        Me.GroupBoxThongTinSachDangChon = New System.Windows.Forms.GroupBox()
        Me.btnReload = New MetroFramework.Controls.MetroButton()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New MetroFramework.Controls.MetroButton()
        CType(Me.DataGridViewQuanLiSach, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinPriceNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaxPriceNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTriGiaDangChon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxThongTinSachCanTim.SuspendLayout()
        Me.GroupBoxThongTinSachDangChon.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridViewQuanLiSach
        '
        Me.DataGridViewQuanLiSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewQuanLiSach.Location = New System.Drawing.Point(59, 298)
        Me.DataGridViewQuanLiSach.Name = "DataGridViewQuanLiSach"
        Me.DataGridViewQuanLiSach.Size = New System.Drawing.Size(918, 131)
        Me.DataGridViewQuanLiSach.TabIndex = 68
        '
        'MinPriceNumericUpDown
        '
        Me.MinPriceNumericUpDown.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MinPriceNumericUpDown.Location = New System.Drawing.Point(709, 81)
        Me.MinPriceNumericUpDown.Maximum = New Decimal(New Integer() {1215752192, 23, 0, 0})
        Me.MinPriceNumericUpDown.Name = "MinPriceNumericUpDown"
        Me.MinPriceNumericUpDown.Size = New System.Drawing.Size(102, 20)
        Me.MinPriceNumericUpDown.TabIndex = 82
        Me.MinPriceNumericUpDown.ThousandsSeparator = True
        '
        'dpNamXBCanTimMin
        '
        Me.dpNamXBCanTimMin.Location = New System.Drawing.Point(709, 47)
        Me.dpNamXBCanTimMin.Name = "dpNamXBCanTimMin"
        Me.dpNamXBCanTimMin.Size = New System.Drawing.Size(102, 20)
        Me.dpNamXBCanTimMin.TabIndex = 80
        '
        'cbTacGiaCanTim
        '
        Me.cbTacGiaCanTim.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbTacGiaCanTim.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbTacGiaCanTim.FormattingEnabled = True
        Me.cbTacGiaCanTim.Location = New System.Drawing.Point(354, 80)
        Me.cbTacGiaCanTim.Name = "cbTacGiaCanTim"
        Me.cbTacGiaCanTim.Size = New System.Drawing.Size(140, 21)
        Me.cbTacGiaCanTim.TabIndex = 79
        '
        'cbTheLoaiCanTim
        '
        Me.cbTheLoaiCanTim.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbTheLoaiCanTim.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbTheLoaiCanTim.FormattingEnabled = True
        Me.cbTheLoaiCanTim.Location = New System.Drawing.Point(95, 76)
        Me.cbTheLoaiCanTim.Name = "cbTheLoaiCanTim"
        Me.cbTheLoaiCanTim.Size = New System.Drawing.Size(140, 21)
        Me.cbTheLoaiCanTim.TabIndex = 78
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(538, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 20)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "Trị giá:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(241, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 20)
        Me.Label7.TabIndex = 73
        Me.Label7.Text = "Nhà xuất bản:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(11, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 20)
        Me.Label6.TabIndex = 72
        Me.Label6.Text = "Thể loại:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(538, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 20)
        Me.Label5.TabIndex = 71
        Me.Label5.Text = "Năm xuất bản:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(241, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 20)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Tác giả:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(11, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 20)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "Tên sách:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(670, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 16)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "Từ"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(828, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 16)
        Me.Label9.TabIndex = 85
        Me.Label9.Text = "Đến"
        '
        'dpNamXBCanTimMax
        '
        Me.dpNamXBCanTimMax.Location = New System.Drawing.Point(866, 47)
        Me.dpNamXBCanTimMax.Name = "dpNamXBCanTimMax"
        Me.dpNamXBCanTimMax.Size = New System.Drawing.Size(102, 20)
        Me.dpNamXBCanTimMax.TabIndex = 86
        '
        'cbNhaXuatBanCanTim
        '
        Me.cbNhaXuatBanCanTim.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbNhaXuatBanCanTim.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbNhaXuatBanCanTim.FormattingEnabled = True
        Me.cbNhaXuatBanCanTim.Location = New System.Drawing.Point(354, 43)
        Me.cbNhaXuatBanCanTim.Name = "cbNhaXuatBanCanTim"
        Me.cbNhaXuatBanCanTim.Size = New System.Drawing.Size(140, 21)
        Me.cbNhaXuatBanCanTim.TabIndex = 90
        '
        'cbTenSachCanTim
        '
        Me.cbTenSachCanTim.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbTenSachCanTim.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbTenSachCanTim.FormattingEnabled = True
        Me.cbTenSachCanTim.Location = New System.Drawing.Point(95, 44)
        Me.cbTenSachCanTim.Name = "cbTenSachCanTim"
        Me.cbTenSachCanTim.Size = New System.Drawing.Size(140, 21)
        Me.cbTenSachCanTim.TabIndex = 91
        '
        'MaxPriceNumericUpDown
        '
        Me.MaxPriceNumericUpDown.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MaxPriceNumericUpDown.Location = New System.Drawing.Point(866, 81)
        Me.MaxPriceNumericUpDown.Maximum = New Decimal(New Integer() {1215752192, 23, 0, 0})
        Me.MaxPriceNumericUpDown.Name = "MaxPriceNumericUpDown"
        Me.MaxPriceNumericUpDown.Size = New System.Drawing.Size(102, 20)
        Me.MaxPriceNumericUpDown.TabIndex = 92
        Me.MaxPriceNumericUpDown.ThousandsSeparator = True
        Me.MaxPriceNumericUpDown.Value = New Decimal(New Integer() {1215752192, 23, 0, 0})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(670, 85)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 16)
        Me.Label12.TabIndex = 93
        Me.Label12.Text = "Từ"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(828, 85)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 16)
        Me.Label13.TabIndex = 94
        Me.Label13.Text = "Đến"
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(466, 261)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(103, 27)
        Me.btnFilter.TabIndex = 96
        Me.btnFilter.Text = "Filter"
        '
        'txtMaDauSachDangChon
        '
        Me.txtMaDauSachDangChon.Enabled = False
        Me.txtMaDauSachDangChon.Location = New System.Drawing.Point(183, 26)
        Me.txtMaDauSachDangChon.Name = "txtMaDauSachDangChon"
        Me.txtMaDauSachDangChon.Size = New System.Drawing.Size(204, 20)
        Me.txtMaDauSachDangChon.TabIndex = 100
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(34, 26)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(73, 20)
        Me.Label14.TabIndex = 115
        Me.Label14.Text = "Mã sách:"
        '
        'nudTriGiaDangChon
        '
        Me.nudTriGiaDangChon.ForeColor = System.Drawing.SystemColors.WindowText
        Me.nudTriGiaDangChon.Location = New System.Drawing.Point(584, 96)
        Me.nudTriGiaDangChon.Maximum = New Decimal(New Integer() {1215752192, 23, 0, 0})
        Me.nudTriGiaDangChon.Name = "nudTriGiaDangChon"
        Me.nudTriGiaDangChon.Size = New System.Drawing.Size(204, 20)
        Me.nudTriGiaDangChon.TabIndex = 107
        Me.nudTriGiaDangChon.ThousandsSeparator = True
        Me.nudTriGiaDangChon.Value = New Decimal(New Integer() {10000, 0, 0, 0})
        '
        'dpNamXBDangChon
        '
        Me.dpNamXBDangChon.Location = New System.Drawing.Point(584, 60)
        Me.dpNamXBDangChon.Name = "dpNamXBDangChon"
        Me.dpNamXBDangChon.Size = New System.Drawing.Size(200, 20)
        Me.dpNamXBDangChon.TabIndex = 105
        '
        'cbTacGiaDangChon
        '
        Me.cbTacGiaDangChon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbTacGiaDangChon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbTacGiaDangChon.FormattingEnabled = True
        Me.cbTacGiaDangChon.Location = New System.Drawing.Point(183, 133)
        Me.cbTacGiaDangChon.Name = "cbTacGiaDangChon"
        Me.cbTacGiaDangChon.Size = New System.Drawing.Size(204, 21)
        Me.cbTacGiaDangChon.Sorted = True
        Me.cbTacGiaDangChon.TabIndex = 103
        '
        'cbTheLoaiDangChon
        '
        Me.cbTheLoaiDangChon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbTheLoaiDangChon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbTheLoaiDangChon.FormattingEnabled = True
        Me.cbTheLoaiDangChon.Location = New System.Drawing.Point(183, 95)
        Me.cbTheLoaiDangChon.Name = "cbTheLoaiDangChon"
        Me.cbTheLoaiDangChon.Size = New System.Drawing.Size(204, 21)
        Me.cbTheLoaiDangChon.TabIndex = 102
        '
        'txtTenNxbDangChon
        '
        Me.txtTenNxbDangChon.Location = New System.Drawing.Point(584, 27)
        Me.txtTenNxbDangChon.Name = "txtTenNxbDangChon"
        Me.txtTenNxbDangChon.Size = New System.Drawing.Size(204, 20)
        Me.txtTenNxbDangChon.TabIndex = 104
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(435, 96)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 20)
        Me.Label15.TabIndex = 114
        Me.Label15.Text = "Trị giá:"
        '
        'txtTenSachDangChon
        '
        Me.txtTenSachDangChon.Location = New System.Drawing.Point(183, 60)
        Me.txtTenSachDangChon.Name = "txtTenSachDangChon"
        Me.txtTenSachDangChon.Size = New System.Drawing.Size(204, 20)
        Me.txtTenSachDangChon.TabIndex = 101
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(435, 27)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(107, 20)
        Me.Label17.TabIndex = 112
        Me.Label17.Text = "Nhà xuất bản:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(34, 96)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(68, 20)
        Me.Label18.TabIndex = 111
        Me.Label18.Text = "Thể loại:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(435, 60)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(111, 20)
        Me.Label19.TabIndex = 110
        Me.Label19.Text = "Năm xuất bản:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(34, 134)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(64, 20)
        Me.Label20.TabIndex = 109
        Me.Label20.Text = "Tác giả:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(34, 60)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(78, 20)
        Me.Label21.TabIndex = 108
        Me.Label21.Text = "Tên sách:"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(466, 634)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(103, 27)
        Me.btnUpdate.TabIndex = 116
        Me.btnUpdate.Text = "Cập nhật"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(602, 634)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(103, 27)
        Me.btnDelete.TabIndex = 117
        Me.btnDelete.Text = "Xoá"
        '
        'GroupBoxThongTinSachCanTim
        '
        Me.GroupBoxThongTinSachCanTim.Controls.Add(Me.Label5)
        Me.GroupBoxThongTinSachCanTim.Controls.Add(Me.Label2)
        Me.GroupBoxThongTinSachCanTim.Controls.Add(Me.Label3)
        Me.GroupBoxThongTinSachCanTim.Controls.Add(Me.Label6)
        Me.GroupBoxThongTinSachCanTim.Controls.Add(Me.Label7)
        Me.GroupBoxThongTinSachCanTim.Controls.Add(Me.Label4)
        Me.GroupBoxThongTinSachCanTim.Controls.Add(Me.cbTheLoaiCanTim)
        Me.GroupBoxThongTinSachCanTim.Controls.Add(Me.cbTacGiaCanTim)
        Me.GroupBoxThongTinSachCanTim.Controls.Add(Me.dpNamXBCanTimMin)
        Me.GroupBoxThongTinSachCanTim.Controls.Add(Me.MinPriceNumericUpDown)
        Me.GroupBoxThongTinSachCanTim.Controls.Add(Me.Label1)
        Me.GroupBoxThongTinSachCanTim.Controls.Add(Me.Label9)
        Me.GroupBoxThongTinSachCanTim.Controls.Add(Me.dpNamXBCanTimMax)
        Me.GroupBoxThongTinSachCanTim.Controls.Add(Me.cbNhaXuatBanCanTim)
        Me.GroupBoxThongTinSachCanTim.Controls.Add(Me.cbTenSachCanTim)
        Me.GroupBoxThongTinSachCanTim.Controls.Add(Me.Label13)
        Me.GroupBoxThongTinSachCanTim.Controls.Add(Me.MaxPriceNumericUpDown)
        Me.GroupBoxThongTinSachCanTim.Controls.Add(Me.Label12)
        Me.GroupBoxThongTinSachCanTim.Location = New System.Drawing.Point(22, 117)
        Me.GroupBoxThongTinSachCanTim.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBoxThongTinSachCanTim.Name = "GroupBoxThongTinSachCanTim"
        Me.GroupBoxThongTinSachCanTim.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBoxThongTinSachCanTim.Size = New System.Drawing.Size(989, 133)
        Me.GroupBoxThongTinSachCanTim.TabIndex = 118
        Me.GroupBoxThongTinSachCanTim.TabStop = False
        Me.GroupBoxThongTinSachCanTim.Text = "Thông tin sách cần tìm"
        '
        'GroupBoxThongTinSachDangChon
        '
        Me.GroupBoxThongTinSachDangChon.Controls.Add(Me.Label14)
        Me.GroupBoxThongTinSachDangChon.Controls.Add(Me.Label21)
        Me.GroupBoxThongTinSachDangChon.Controls.Add(Me.Label20)
        Me.GroupBoxThongTinSachDangChon.Controls.Add(Me.Label19)
        Me.GroupBoxThongTinSachDangChon.Controls.Add(Me.txtMaDauSachDangChon)
        Me.GroupBoxThongTinSachDangChon.Controls.Add(Me.Label18)
        Me.GroupBoxThongTinSachDangChon.Controls.Add(Me.Label17)
        Me.GroupBoxThongTinSachDangChon.Controls.Add(Me.nudTriGiaDangChon)
        Me.GroupBoxThongTinSachDangChon.Controls.Add(Me.txtTenSachDangChon)
        Me.GroupBoxThongTinSachDangChon.Controls.Add(Me.dpNamXBDangChon)
        Me.GroupBoxThongTinSachDangChon.Controls.Add(Me.Label15)
        Me.GroupBoxThongTinSachDangChon.Controls.Add(Me.cbTacGiaDangChon)
        Me.GroupBoxThongTinSachDangChon.Controls.Add(Me.txtTenNxbDangChon)
        Me.GroupBoxThongTinSachDangChon.Controls.Add(Me.cbTheLoaiDangChon)
        Me.GroupBoxThongTinSachDangChon.Location = New System.Drawing.Point(126, 446)
        Me.GroupBoxThongTinSachDangChon.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBoxThongTinSachDangChon.Name = "GroupBoxThongTinSachDangChon"
        Me.GroupBoxThongTinSachDangChon.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBoxThongTinSachDangChon.Size = New System.Drawing.Size(814, 174)
        Me.GroupBoxThongTinSachDangChon.TabIndex = 119
        Me.GroupBoxThongTinSachDangChon.TabStop = False
        Me.GroupBoxThongTinSachDangChon.Text = "Thông tin sách đang chọn"
        '
        'btnReload
        '
        Me.btnReload.Location = New System.Drawing.Point(335, 634)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(103, 27)
        Me.btnReload.TabIndex = 120
        Me.btnReload.Text = "Reload "
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(113, 74)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(325, 20)
        Me.txtSearch.TabIndex = 121
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(466, 71)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(103, 27)
        Me.btnSearch.TabIndex = 123
        Me.btnSearch.Text = "Search"
        '
        'frmQuanLiSach
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1040, 677)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.btnReload)
        Me.Controls.Add(Me.GroupBoxThongTinSachDangChon)
        Me.Controls.Add(Me.GroupBoxThongTinSachCanTim)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.DataGridViewQuanLiSach)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmQuanLiSach"
        Me.Text = "Quản lí sách"
        CType(Me.DataGridViewQuanLiSach, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinPriceNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaxPriceNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTriGiaDangChon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxThongTinSachCanTim.ResumeLayout(False)
        Me.GroupBoxThongTinSachCanTim.PerformLayout()
        Me.GroupBoxThongTinSachDangChon.ResumeLayout(False)
        Me.GroupBoxThongTinSachDangChon.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewQuanLiSach As DataGridView
    Friend WithEvents MinPriceNumericUpDown As NumericUpDown
    Friend WithEvents dpNamXBCanTimMin As DateTimePicker
    Friend WithEvents cbTacGiaCanTim As ComboBox
    Friend WithEvents cbTheLoaiCanTim As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents dpNamXBCanTimMax As DateTimePicker
    Friend WithEvents cbNhaXuatBanCanTim As ComboBox
    Friend WithEvents cbTenSachCanTim As ComboBox
    Friend WithEvents MaxPriceNumericUpDown As NumericUpDown
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents btnFilter As MetroFramework.Controls.MetroButton
    Friend WithEvents txtMaDauSachDangChon As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents nudTriGiaDangChon As NumericUpDown
    Friend WithEvents dpNamXBDangChon As DateTimePicker
    Friend WithEvents cbTacGiaDangChon As ComboBox
    Friend WithEvents cbTheLoaiDangChon As ComboBox
    Friend WithEvents txtTenNxbDangChon As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtTenSachDangChon As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents btnUpdate As MetroFramework.Controls.MetroButton
    Friend WithEvents btnDelete As MetroFramework.Controls.MetroButton
    Friend WithEvents GroupBoxThongTinSachCanTim As GroupBox
    Friend WithEvents GroupBoxThongTinSachDangChon As GroupBox
    Friend WithEvents btnReload As MetroFramework.Controls.MetroButton
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As MetroFramework.Controls.MetroButton
End Class
