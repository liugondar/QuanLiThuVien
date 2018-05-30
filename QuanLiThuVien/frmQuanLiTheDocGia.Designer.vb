<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmQuanLiTheDocGia
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
        Me.RemoveButton = New System.Windows.Forms.Button()
        Me.EditButton = New System.Windows.Forms.Button()
        Me.BirthDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.AddressTextBox = New System.Windows.Forms.TextBox()
        Me.EmailTextBox = New System.Windows.Forms.TextBox()
        Me.UserNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ReaderTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.DataGridViewQuanLiTheDocGia = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridViewQuanLiTheDocGia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RemoveButton
        '
        Me.RemoveButton.Location = New System.Drawing.Point(374, 506)
        Me.RemoveButton.Name = "RemoveButton"
        Me.RemoveButton.Size = New System.Drawing.Size(101, 23)
        Me.RemoveButton.TabIndex = 48
        Me.RemoveButton.Text = "Xóa"
        Me.RemoveButton.UseVisualStyleBackColor = True
        '
        'EditButton
        '
        Me.EditButton.Location = New System.Drawing.Point(250, 506)
        Me.EditButton.Name = "EditButton"
        Me.EditButton.Size = New System.Drawing.Size(103, 23)
        Me.EditButton.TabIndex = 47
        Me.EditButton.Text = "Cập nhật"
        Me.EditButton.UseVisualStyleBackColor = True
        '
        'BirthDateTimePicker
        '
        Me.BirthDateTimePicker.Location = New System.Drawing.Point(343, 468)
        Me.BirthDateTimePicker.Name = "BirthDateTimePicker"
        Me.BirthDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.BirthDateTimePicker.TabIndex = 44
        '
        'AddressTextBox
        '
        Me.AddressTextBox.Location = New System.Drawing.Point(343, 425)
        Me.AddressTextBox.Name = "AddressTextBox"
        Me.AddressTextBox.Size = New System.Drawing.Size(204, 20)
        Me.AddressTextBox.TabIndex = 43
        '
        'EmailTextBox
        '
        Me.EmailTextBox.Location = New System.Drawing.Point(343, 378)
        Me.EmailTextBox.Name = "EmailTextBox"
        Me.EmailTextBox.Size = New System.Drawing.Size(204, 20)
        Me.EmailTextBox.TabIndex = 42
        '
        'UserNameTextBox
        '
        Me.UserNameTextBox.Location = New System.Drawing.Point(343, 335)
        Me.UserNameTextBox.Name = "UserNameTextBox"
        Me.UserNameTextBox.Size = New System.Drawing.Size(204, 20)
        Me.UserNameTextBox.TabIndex = 41
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(213, 464)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 20)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "Ngày sinh:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(213, 374)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 20)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Email:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(213, 420)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 20)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Địa chỉ :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(213, 335)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 20)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Họ và tên:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(212, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 20)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Loại độc giả"
        '
        'ReaderTypeComboBox
        '
        Me.ReaderTypeComboBox.FormattingEnabled = True
        Me.ReaderTypeComboBox.Location = New System.Drawing.Point(322, 29)
        Me.ReaderTypeComboBox.Name = "ReaderTypeComboBox"
        Me.ReaderTypeComboBox.Size = New System.Drawing.Size(142, 21)
        Me.ReaderTypeComboBox.TabIndex = 50
        '
        'DataGridViewQuanLiTheDocGia
        '
        Me.DataGridViewQuanLiTheDocGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewQuanLiTheDocGia.Location = New System.Drawing.Point(97, 90)
        Me.DataGridViewQuanLiTheDocGia.Name = "DataGridViewQuanLiTheDocGia"
        Me.DataGridViewQuanLiTheDocGia.Size = New System.Drawing.Size(650, 199)
        Me.DataGridViewQuanLiTheDocGia.TabIndex = 51
        '
        'frmQuanLiTheDocGia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 541)
        Me.Controls.Add(Me.DataGridViewQuanLiTheDocGia)
        Me.Controls.Add(Me.ReaderTypeComboBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RemoveButton)
        Me.Controls.Add(Me.EditButton)
        Me.Controls.Add(Me.BirthDateTimePicker)
        Me.Controls.Add(Me.AddressTextBox)
        Me.Controls.Add(Me.EmailTextBox)
        Me.Controls.Add(Me.UserNameTextBox)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmQuanLiTheDocGia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Quản lí thẻ độc giả"
        CType(Me.DataGridViewQuanLiTheDocGia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RemoveButton As Button
    Friend WithEvents EditButton As Button
    Friend WithEvents BirthDateTimePicker As DateTimePicker
    Friend WithEvents AddressTextBox As TextBox
    Friend WithEvents EmailTextBox As TextBox
    Friend WithEvents UserNameTextBox As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ReaderTypeComboBox As ComboBox
    Friend WithEvents DataGridViewQuanLiTheDocGia As DataGridView
End Class
