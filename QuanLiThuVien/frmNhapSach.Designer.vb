<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNhapSach
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
        Me.CreateAndCloseButton = New System.Windows.Forms.Button()
        Me.CreateButton = New System.Windows.Forms.Button()
        Me.BookTitleTextBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PulisherTextBox = New System.Windows.Forms.TextBox()
        Me.CategoryComboBox = New System.Windows.Forms.ComboBox()
        Me.AuthorComboBox = New System.Windows.Forms.ComboBox()
        Me.PublishYearDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.DateInputDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.PriceNumericUpDown = New System.Windows.Forms.NumericUpDown()
        CType(Me.PriceNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CreateAndCloseButton
        '
        Me.CreateAndCloseButton.Location = New System.Drawing.Point(258, 344)
        Me.CreateAndCloseButton.Name = "CreateAndCloseButton"
        Me.CreateAndCloseButton.Size = New System.Drawing.Size(101, 23)
        Me.CreateAndCloseButton.TabIndex = 9
        Me.CreateAndCloseButton.Text = "Nhập và đóng"
        Me.CreateAndCloseButton.UseVisualStyleBackColor = True
        '
        'CreateButton
        '
        Me.CreateButton.Location = New System.Drawing.Point(107, 344)
        Me.CreateButton.Name = "CreateButton"
        Me.CreateButton.Size = New System.Drawing.Size(103, 23)
        Me.CreateButton.TabIndex = 8
        Me.CreateButton.Text = "Nhập"
        Me.CreateButton.UseVisualStyleBackColor = True
        '
        'BookTitleTextBox
        '
        Me.BookTitleTextBox.Location = New System.Drawing.Point(217, 77)
        Me.BookTitleTextBox.Name = "BookTitleTextBox"
        Me.BookTitleTextBox.Size = New System.Drawing.Size(204, 20)
        Me.BookTitleTextBox.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(68, 257)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 20)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "Ngày Nhập:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(68, 187)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 20)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "Nhà xuất bản:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(68, 113)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 20)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Thể loại:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(68, 220)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 20)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "Năm xuất bản:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(68, 151)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 20)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Tác giả:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(68, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 20)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Tên sách:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(132, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 29)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Thông tin sách"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(68, 293)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 20)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Trị giá:"
        '
        'PulisherTextBox
        '
        Me.PulisherTextBox.Location = New System.Drawing.Point(217, 187)
        Me.PulisherTextBox.Name = "PulisherTextBox"
        Me.PulisherTextBox.Size = New System.Drawing.Size(204, 20)
        Me.PulisherTextBox.TabIndex = 4
        '
        'CategoryComboBox
        '
        Me.CategoryComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CategoryComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CategoryComboBox.FormattingEnabled = True
        Me.CategoryComboBox.Location = New System.Drawing.Point(217, 112)
        Me.CategoryComboBox.Name = "CategoryComboBox"
        Me.CategoryComboBox.Size = New System.Drawing.Size(204, 21)
        Me.CategoryComboBox.TabIndex = 2
        '
        'AuthorComboBox
        '
        Me.AuthorComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.AuthorComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.AuthorComboBox.FormattingEnabled = True
        Me.AuthorComboBox.Location = New System.Drawing.Point(217, 150)
        Me.AuthorComboBox.Name = "AuthorComboBox"
        Me.AuthorComboBox.Size = New System.Drawing.Size(204, 21)
        Me.AuthorComboBox.Sorted = True
        Me.AuthorComboBox.TabIndex = 3
        '
        'PublishYearDateTimePicker
        '
        Me.PublishYearDateTimePicker.Location = New System.Drawing.Point(217, 220)
        Me.PublishYearDateTimePicker.Name = "PublishYearDateTimePicker"
        Me.PublishYearDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.PublishYearDateTimePicker.TabIndex = 5
        '
        'DateInputDateTimePicker
        '
        Me.DateInputDateTimePicker.Location = New System.Drawing.Point(217, 257)
        Me.DateInputDateTimePicker.Name = "DateInputDateTimePicker"
        Me.DateInputDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.DateInputDateTimePicker.TabIndex = 6
        '
        'PriceNumericUpDown
        '
        Me.PriceNumericUpDown.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PriceNumericUpDown.Location = New System.Drawing.Point(217, 293)
        Me.PriceNumericUpDown.Maximum = New Decimal(New Integer() {1215752192, 23, 0, 0})
        Me.PriceNumericUpDown.Name = "PriceNumericUpDown"
        Me.PriceNumericUpDown.Size = New System.Drawing.Size(204, 20)
        Me.PriceNumericUpDown.TabIndex = 7
        Me.PriceNumericUpDown.ThousandsSeparator = True
        Me.PriceNumericUpDown.Value = New Decimal(New Integer() {10000, 0, 0, 0})
        '
        'frmNhapSach
        '
        Me.AcceptButton = Me.CreateButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 404)
        Me.Controls.Add(Me.PriceNumericUpDown)
        Me.Controls.Add(Me.DateInputDateTimePicker)
        Me.Controls.Add(Me.PublishYearDateTimePicker)
        Me.Controls.Add(Me.AuthorComboBox)
        Me.Controls.Add(Me.CategoryComboBox)
        Me.Controls.Add(Me.PulisherTextBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CreateAndCloseButton)
        Me.Controls.Add(Me.CreateButton)
        Me.Controls.Add(Me.BookTitleTextBox)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmNhapSach"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nhập sách"
        CType(Me.PriceNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CreateAndCloseButton As Button
    Friend WithEvents CreateButton As Button
    Friend WithEvents BookTitleTextBox As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PulisherTextBox As TextBox
    Friend WithEvents CategoryComboBox As ComboBox
    Friend WithEvents AuthorComboBox As ComboBox
    Friend WithEvents PublishYearDateTimePicker As DateTimePicker
    Friend WithEvents DateInputDateTimePicker As DateTimePicker
    Friend WithEvents PriceNumericUpDown As NumericUpDown
End Class
