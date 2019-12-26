<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmQuanLiTheDocGia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQuanLiTheDocGia))
        Me.dtpBirthDate = New System.Windows.Forms.DateTimePicker()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ReaderTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.DataGridViewQuanLiTheDocGia = New System.Windows.Forms.DataGridView()
        Me.txtMaTheDocGia = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbLoaiDocGiaEdit = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnUpdate = New MetroFramework.Controls.MetroButton()
        Me.btnDelete = New MetroFramework.Controls.MetroButton()
        CType(Me.DataGridViewQuanLiTheDocGia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpBirthDate
        '
        Me.dtpBirthDate.Location = New System.Drawing.Point(347, 520)
        Me.dtpBirthDate.Name = "dtpBirthDate"
        Me.dtpBirthDate.Size = New System.Drawing.Size(204, 20)
        Me.dtpBirthDate.TabIndex = 5
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(347, 477)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(204, 20)
        Me.txtAddress.TabIndex = 4
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(347, 430)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(204, 20)
        Me.txtEmail.TabIndex = 3
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(347, 387)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(204, 20)
        Me.txtUserName.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(217, 516)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 20)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "Ngày sinh:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(217, 426)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 20)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Email:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(217, 472)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 20)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Địa chỉ :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(217, 387)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 20)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Họ và tên:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(228, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 20)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Loại độc giả"
        '
        'ReaderTypeComboBox
        '
        Me.ReaderTypeComboBox.FormattingEnabled = True
        Me.ReaderTypeComboBox.Location = New System.Drawing.Point(338, 77)
        Me.ReaderTypeComboBox.Name = "ReaderTypeComboBox"
        Me.ReaderTypeComboBox.Size = New System.Drawing.Size(142, 21)
        Me.ReaderTypeComboBox.TabIndex = 1
        '
        'DataGridViewQuanLiTheDocGia
        '
        Me.DataGridViewQuanLiTheDocGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewQuanLiTheDocGia.Location = New System.Drawing.Point(52, 124)
        Me.DataGridViewQuanLiTheDocGia.Name = "DataGridViewQuanLiTheDocGia"
        Me.DataGridViewQuanLiTheDocGia.Size = New System.Drawing.Size(703, 206)
        Me.DataGridViewQuanLiTheDocGia.TabIndex = 51
        '
        'txtMaTheDocGia
        '
        Me.txtMaTheDocGia.Location = New System.Drawing.Point(347, 347)
        Me.txtMaTheDocGia.Name = "txtMaTheDocGia"
        Me.txtMaTheDocGia.ReadOnly = True
        Me.txtMaTheDocGia.Size = New System.Drawing.Size(204, 20)
        Me.txtMaTheDocGia.TabIndex = 53
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(217, 347)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 20)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "Mã thẻ độc giả"
        '
        'cbLoaiDocGiaEdit
        '
        Me.cbLoaiDocGiaEdit.FormattingEnabled = True
        Me.cbLoaiDocGiaEdit.Location = New System.Drawing.Point(347, 556)
        Me.cbLoaiDocGiaEdit.Name = "cbLoaiDocGiaEdit"
        Me.cbLoaiDocGiaEdit.Size = New System.Drawing.Size(204, 21)
        Me.cbLoaiDocGiaEdit.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(217, 557)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 20)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "Loại độc giả"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(271, 594)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(86, 23)
        Me.btnUpdate.TabIndex = 55
        Me.btnUpdate.Text = "Cập nhật"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(380, 594)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(86, 23)
        Me.btnDelete.TabIndex = 56
        Me.btnDelete.Text = "Xoá thẻ"
        '
        'frmQuanLiTheDocGia
        '
        Me.AcceptButton = Me.btnUpdate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(822, 634)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.cbLoaiDocGiaEdit)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtMaTheDocGia)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DataGridViewQuanLiTheDocGia)
        Me.Controls.Add(Me.ReaderTypeComboBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpBirthDate)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmQuanLiTheDocGia"
        Me.Text = "Quản lí thẻ độc giả"
        CType(Me.DataGridViewQuanLiTheDocGia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpBirthDate As DateTimePicker
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtUserName As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ReaderTypeComboBox As ComboBox
    Friend WithEvents DataGridViewQuanLiTheDocGia As DataGridView
    Friend WithEvents txtMaTheDocGia As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cbLoaiDocGiaEdit As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnUpdate As MetroFramework.Controls.MetroButton
    Friend WithEvents btnDelete As MetroFramework.Controls.MetroButton
End Class
