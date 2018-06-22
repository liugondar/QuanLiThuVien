<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BookInfoControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.STTTextBox = New System.Windows.Forms.TextBox()
        Me.Button = New System.Windows.Forms.Button()
        Me.BookIdTextBox = New Utility.PlaceHolderTextBox()
        Me.BookTitleTextBox = New Utility.PlaceHolderTextBox()
        Me.TypeOfBookTextBox = New Utility.PlaceHolderTextBox()
        Me.AuthorTextBox = New Utility.PlaceHolderTextBox()
        Me.SuspendLayout()
        '
        'STTTextBox
        '
        Me.STTTextBox.Enabled = False
        Me.STTTextBox.Location = New System.Drawing.Point(18, 11)
        Me.STTTextBox.Name = "STTTextBox"
        Me.STTTextBox.Size = New System.Drawing.Size(51, 20)
        Me.STTTextBox.TabIndex = 7
        '
        'Button
        '
        Me.Button.BackColor = System.Drawing.Color.DarkRed
        Me.Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button.Location = New System.Drawing.Point(710, 8)
        Me.Button.Margin = New System.Windows.Forms.Padding(0)
        Me.Button.Name = "Button"
        Me.Button.Size = New System.Drawing.Size(72, 26)
        Me.Button.TabIndex = 8
        Me.Button.Text = "Xóa"
        Me.Button.UseVisualStyleBackColor = False
        '
        'BookIdTextBox
        '
        Me.BookIdTextBox.ForeColor = System.Drawing.Color.Gray
        Me.BookIdTextBox.IsPlaceHolder = True
        Me.BookIdTextBox.Location = New System.Drawing.Point(75, 12)
        Me.BookIdTextBox.Name = "BookIdTextBox"
        Me.BookIdTextBox.PlaceHolderText = "Mã sách"
        Me.BookIdTextBox.Size = New System.Drawing.Size(115, 20)
        Me.BookIdTextBox.TabIndex = 12
        Me.BookIdTextBox.Text = "Mã sách"
        '
        'BookTitleTextBox
        '
        Me.BookTitleTextBox.Enabled = False
        Me.BookTitleTextBox.ForeColor = System.Drawing.Color.Gray
        Me.BookTitleTextBox.IsPlaceHolder = True
        Me.BookTitleTextBox.Location = New System.Drawing.Point(196, 12)
        Me.BookTitleTextBox.Name = "BookTitleTextBox"
        Me.BookTitleTextBox.PlaceHolderText = "Tên sách"
        Me.BookTitleTextBox.Size = New System.Drawing.Size(149, 20)
        Me.BookTitleTextBox.TabIndex = 13
        Me.BookTitleTextBox.Text = "Tên sách"
        '
        'TypeOfBookTextBox
        '
        Me.TypeOfBookTextBox.Enabled = False
        Me.TypeOfBookTextBox.ForeColor = System.Drawing.Color.Gray
        Me.TypeOfBookTextBox.IsPlaceHolder = True
        Me.TypeOfBookTextBox.Location = New System.Drawing.Point(351, 12)
        Me.TypeOfBookTextBox.Name = "TypeOfBookTextBox"
        Me.TypeOfBookTextBox.PlaceHolderText = "Tên sách"
        Me.TypeOfBookTextBox.Size = New System.Drawing.Size(155, 20)
        Me.TypeOfBookTextBox.TabIndex = 14
        Me.TypeOfBookTextBox.Text = "Thể loại"
        '
        'AuthorTextBox
        '
        Me.AuthorTextBox.Enabled = False
        Me.AuthorTextBox.ForeColor = System.Drawing.Color.Gray
        Me.AuthorTextBox.IsPlaceHolder = True
        Me.AuthorTextBox.Location = New System.Drawing.Point(512, 11)
        Me.AuthorTextBox.Name = "AuthorTextBox"
        Me.AuthorTextBox.PlaceHolderText = "Tác giả"
        Me.AuthorTextBox.Size = New System.Drawing.Size(183, 20)
        Me.AuthorTextBox.TabIndex = 15
        Me.AuthorTextBox.Text = "Tác giả"
        '
        'BookInfoControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.AuthorTextBox)
        Me.Controls.Add(Me.TypeOfBookTextBox)
        Me.Controls.Add(Me.BookTitleTextBox)
        Me.Controls.Add(Me.BookIdTextBox)
        Me.Controls.Add(Me.Button)
        Me.Controls.Add(Me.STTTextBox)
        Me.Name = "BookInfoControl"
        Me.Size = New System.Drawing.Size(793, 37)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents STTTextBox As Windows.Forms.TextBox
    Friend WithEvents Button As Windows.Forms.Button
    Friend WithEvents BookIdTextBox As PlaceHolderTextBox
    Friend WithEvents BookTitleTextBox As PlaceHolderTextBox
    Friend WithEvents TypeOfBookTextBox As PlaceHolderTextBox
    Friend WithEvents AuthorTextBox As PlaceHolderTextBox
End Class
