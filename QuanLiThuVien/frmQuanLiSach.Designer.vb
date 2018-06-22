<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuanLiSach
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
        Me.DataGridViewQuanLiSach = New System.Windows.Forms.DataGridView()
        Me.MinPriceNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.MinDateInputDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.MinPublishYearDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.AuthorComboBox = New System.Windows.Forms.ComboBox()
        Me.CategoryComboBox = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.MaxPublishYearDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.MaxDateInputDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.PublisherComboBox = New System.Windows.Forms.ComboBox()
        Me.BookTitleComboBox = New System.Windows.Forms.ComboBox()
        Me.MaxPriceNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.SearchButton = New MetroFramework.Controls.MetroButton()
        CType(Me.DataGridViewQuanLiSach, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinPriceNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaxPriceNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewQuanLiSach
        '
        Me.DataGridViewQuanLiSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewQuanLiSach.Location = New System.Drawing.Point(54, 221)
        Me.DataGridViewQuanLiSach.Name = "DataGridViewQuanLiSach"
        Me.DataGridViewQuanLiSach.Size = New System.Drawing.Size(918, 182)
        Me.DataGridViewQuanLiSach.TabIndex = 68
        '
        'MinPriceNumericUpDown
        '
        Me.MinPriceNumericUpDown.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MinPriceNumericUpDown.Location = New System.Drawing.Point(729, 145)
        Me.MinPriceNumericUpDown.Maximum = New Decimal(New Integer() {1215752192, 23, 0, 0})
        Me.MinPriceNumericUpDown.Name = "MinPriceNumericUpDown"
        Me.MinPriceNumericUpDown.Size = New System.Drawing.Size(102, 20)
        Me.MinPriceNumericUpDown.TabIndex = 82
        Me.MinPriceNumericUpDown.ThousandsSeparator = True
        '
        'MinDateInputDateTimePicker
        '
        Me.MinDateInputDateTimePicker.Location = New System.Drawing.Point(729, 115)
        Me.MinDateInputDateTimePicker.Name = "MinDateInputDateTimePicker"
        Me.MinDateInputDateTimePicker.Size = New System.Drawing.Size(102, 20)
        Me.MinDateInputDateTimePicker.TabIndex = 81
        '
        'MinPublishYearDateTimePicker
        '
        Me.MinPublishYearDateTimePicker.Location = New System.Drawing.Point(729, 81)
        Me.MinPublishYearDateTimePicker.Name = "MinPublishYearDateTimePicker"
        Me.MinPublishYearDateTimePicker.Size = New System.Drawing.Size(102, 20)
        Me.MinPublishYearDateTimePicker.TabIndex = 80
        '
        'AuthorComboBox
        '
        Me.AuthorComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.AuthorComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.AuthorComboBox.FormattingEnabled = True
        Me.AuthorComboBox.Location = New System.Drawing.Point(374, 114)
        Me.AuthorComboBox.Name = "AuthorComboBox"
        Me.AuthorComboBox.Size = New System.Drawing.Size(140, 21)
        Me.AuthorComboBox.TabIndex = 79
        '
        'CategoryComboBox
        '
        Me.CategoryComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CategoryComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CategoryComboBox.FormattingEnabled = True
        Me.CategoryComboBox.Location = New System.Drawing.Point(115, 110)
        Me.CategoryComboBox.Name = "CategoryComboBox"
        Me.CategoryComboBox.Size = New System.Drawing.Size(140, 21)
        Me.CategoryComboBox.TabIndex = 78
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(558, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 20)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "Trị giá:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(558, 111)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 20)
        Me.Label8.TabIndex = 74
        Me.Label8.Text = "Ngày Nhập:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(261, 78)
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
        Me.Label6.Location = New System.Drawing.Point(31, 112)
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
        Me.Label5.Location = New System.Drawing.Point(558, 81)
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
        Me.Label3.Location = New System.Drawing.Point(261, 111)
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
        Me.Label2.Location = New System.Drawing.Point(31, 76)
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
        Me.Label1.Location = New System.Drawing.Point(690, 82)
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
        Me.Label9.Location = New System.Drawing.Point(848, 83)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 16)
        Me.Label9.TabIndex = 85
        Me.Label9.Text = "Đến"
        '
        'MaxPublishYearDateTimePicker
        '
        Me.MaxPublishYearDateTimePicker.Location = New System.Drawing.Point(886, 81)
        Me.MaxPublishYearDateTimePicker.Name = "MaxPublishYearDateTimePicker"
        Me.MaxPublishYearDateTimePicker.Size = New System.Drawing.Size(102, 20)
        Me.MaxPublishYearDateTimePicker.TabIndex = 86
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(690, 115)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 16)
        Me.Label10.TabIndex = 87
        Me.Label10.Text = "Từ"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(848, 118)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 16)
        Me.Label11.TabIndex = 88
        Me.Label11.Text = "Đến"
        '
        'MaxDateInputDateTimePicker
        '
        Me.MaxDateInputDateTimePicker.Location = New System.Drawing.Point(886, 114)
        Me.MaxDateInputDateTimePicker.Name = "MaxDateInputDateTimePicker"
        Me.MaxDateInputDateTimePicker.Size = New System.Drawing.Size(102, 20)
        Me.MaxDateInputDateTimePicker.TabIndex = 89
        '
        'PublisherComboBox
        '
        Me.PublisherComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.PublisherComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.PublisherComboBox.FormattingEnabled = True
        Me.PublisherComboBox.Location = New System.Drawing.Point(374, 77)
        Me.PublisherComboBox.Name = "PublisherComboBox"
        Me.PublisherComboBox.Size = New System.Drawing.Size(140, 21)
        Me.PublisherComboBox.TabIndex = 90
        '
        'BookTitleComboBox
        '
        Me.BookTitleComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.BookTitleComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.BookTitleComboBox.FormattingEnabled = True
        Me.BookTitleComboBox.Location = New System.Drawing.Point(115, 78)
        Me.BookTitleComboBox.Name = "BookTitleComboBox"
        Me.BookTitleComboBox.Size = New System.Drawing.Size(140, 21)
        Me.BookTitleComboBox.TabIndex = 91
        '
        'MaxPriceNumericUpDown
        '
        Me.MaxPriceNumericUpDown.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MaxPriceNumericUpDown.Location = New System.Drawing.Point(886, 145)
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
        Me.Label12.Location = New System.Drawing.Point(690, 149)
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
        Me.Label13.Location = New System.Drawing.Point(848, 147)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 16)
        Me.Label13.TabIndex = 94
        Me.Label13.Text = "Đến"
        '
        'SearchButton
        '
        Me.SearchButton.Location = New System.Drawing.Point(434, 180)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(103, 23)
        Me.SearchButton.TabIndex = 96
        Me.SearchButton.Text = "Tìm kiếm"
        '
        'frmQuanLiSach
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(995, 454)
        Me.Controls.Add(Me.SearchButton)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.MaxPriceNumericUpDown)
        Me.Controls.Add(Me.BookTitleComboBox)
        Me.Controls.Add(Me.PublisherComboBox)
        Me.Controls.Add(Me.MaxDateInputDateTimePicker)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.MaxPublishYearDateTimePicker)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MinPriceNumericUpDown)
        Me.Controls.Add(Me.MinDateInputDateTimePicker)
        Me.Controls.Add(Me.MinPublishYearDateTimePicker)
        Me.Controls.Add(Me.AuthorComboBox)
        Me.Controls.Add(Me.CategoryComboBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataGridViewQuanLiSach)
        Me.Name = "frmQuanLiSach"
        Me.Text = "frmQuanLiSach"
        CType(Me.DataGridViewQuanLiSach, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinPriceNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaxPriceNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewQuanLiSach As DataGridView
    Friend WithEvents MinPriceNumericUpDown As NumericUpDown
    Friend WithEvents MinDateInputDateTimePicker As DateTimePicker
    Friend WithEvents MinPublishYearDateTimePicker As DateTimePicker
    Friend WithEvents AuthorComboBox As ComboBox
    Friend WithEvents CategoryComboBox As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents MaxPublishYearDateTimePicker As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents MaxDateInputDateTimePicker As DateTimePicker
    Friend WithEvents PublisherComboBox As ComboBox
    Friend WithEvents BookTitleComboBox As ComboBox
    Friend WithEvents MaxPriceNumericUpDown As NumericUpDown
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents SearchButton As MetroFramework.Controls.MetroButton
End Class
