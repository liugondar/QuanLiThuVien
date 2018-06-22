<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmChoMuonSach
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
        Me.ReaderIdTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ExpirationTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.BorrowDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.UserNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListSachDaMuonDataGridView = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SachCanThuePanel = New System.Windows.Forms.Panel()
        Me.ConfirmButton = New MetroFramework.Controls.MetroButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        CType(Me.ListSachDaMuonDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReaderIdTextBox
        '
        Me.ReaderIdTextBox.Location = New System.Drawing.Point(208, 73)
        Me.ReaderIdTextBox.Name = "ReaderIdTextBox"
        Me.ReaderIdTextBox.Size = New System.Drawing.Size(182, 20)
        Me.ReaderIdTextBox.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(85, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 20)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Mã thẻ độc giả:"
        '
        'ExpirationTimePicker
        '
        Me.ExpirationTimePicker.Enabled = False
        Me.ExpirationTimePicker.Location = New System.Drawing.Point(550, 111)
        Me.ExpirationTimePicker.Name = "ExpirationTimePicker"
        Me.ExpirationTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.ExpirationTimePicker.TabIndex = 4
        '
        'BorrowDateTimePicker
        '
        Me.BorrowDateTimePicker.Location = New System.Drawing.Point(550, 73)
        Me.BorrowDateTimePicker.Name = "BorrowDateTimePicker"
        Me.BorrowDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.BorrowDateTimePicker.TabIndex = 3
        '
        'UserNameTextBox
        '
        Me.UserNameTextBox.Enabled = False
        Me.UserNameTextBox.Location = New System.Drawing.Point(208, 110)
        Me.UserNameTextBox.Name = "UserNameTextBox"
        Me.UserNameTextBox.Size = New System.Drawing.Size(182, 20)
        Me.UserNameTextBox.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(420, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 20)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "Ngày mượn:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(420, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 20)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Ngày hết hạn:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(85, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 20)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Họ và tên:"
        '
        'ListSachDaMuonDataGridView
        '
        Me.ListSachDaMuonDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ListSachDaMuonDataGridView.Location = New System.Drawing.Point(43, 180)
        Me.ListSachDaMuonDataGridView.Name = "ListSachDaMuonDataGridView"
        Me.ListSachDaMuonDataGridView.Size = New System.Drawing.Size(788, 191)
        Me.ListSachDaMuonDataGridView.TabIndex = 51
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(39, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(212, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Danh sách sách đang mượn:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(39, 393)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(191, 20)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "Thông tin sách cần mượn:"
        '
        'SachCanThuePanel
        '
        Me.SachCanThuePanel.Location = New System.Drawing.Point(43, 445)
        Me.SachCanThuePanel.Name = "SachCanThuePanel"
        Me.SachCanThuePanel.Size = New System.Drawing.Size(788, 184)
        Me.SachCanThuePanel.TabIndex = 55
        '
        'ConfirmButton
        '
        Me.ConfirmButton.Location = New System.Drawing.Point(377, 638)
        Me.ConfirmButton.Name = "ConfirmButton"
        Me.ConfirmButton.Size = New System.Drawing.Size(103, 23)
        Me.ConfirmButton.TabIndex = 98
        Me.ConfirmButton.Text = "Xác nhận"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(66, 423)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 16)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "STT"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(136, 423)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 16)
        Me.Label8.TabIndex = 105
        Me.Label8.Text = "Mã sách"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(270, 423)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 16)
        Me.Label9.TabIndex = 106
        Me.Label9.Text = "Tên sách"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(421, 424)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 16)
        Me.Label10.TabIndex = 107
        Me.Label10.Text = "Thể loại"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(572, 423)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 16)
        Me.Label11.TabIndex = 108
        Me.Label11.Text = "Tác giả"
        '
        'frmChoMuonSach
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(891, 684)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ConfirmButton)
        Me.Controls.Add(Me.SachCanThuePanel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ListSachDaMuonDataGridView)
        Me.Controls.Add(Me.ReaderIdTextBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ExpirationTimePicker)
        Me.Controls.Add(Me.BorrowDateTimePicker)
        Me.Controls.Add(Me.UserNameTextBox)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmChoMuonSach"
        Me.Text = "Mượn sách"
        CType(Me.ListSachDaMuonDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ReaderIdTextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ExpirationTimePicker As DateTimePicker
    Friend WithEvents BorrowDateTimePicker As DateTimePicker
    Friend WithEvents UserNameTextBox As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ListSachDaMuonDataGridView As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents SachCanThuePanel As Panel
    Friend WithEvents ConfirmButton As MetroFramework.Controls.MetroButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
End Class
