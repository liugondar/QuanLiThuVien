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
        Me.BookTitleComboBox = New System.Windows.Forms.ComboBox()
        Me.TypeOfBookComboBox = New System.Windows.Forms.ComboBox()
        Me.AuthorComboBox = New System.Windows.Forms.ComboBox()
        Me.STTTextBox = New System.Windows.Forms.TextBox()
        Me.Button = New System.Windows.Forms.Button()
        Me.BookIdTextBox = New Utility.PlaceHolderTextBox()
        Me.SuspendLayout()
        '
        'BookTitleComboBox
        '
        Me.BookTitleComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.BookTitleComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.BookTitleComboBox.FormattingEnabled = True
        Me.BookTitleComboBox.Location = New System.Drawing.Point(196, 11)
        Me.BookTitleComboBox.Name = "BookTitleComboBox"
        Me.BookTitleComboBox.Size = New System.Drawing.Size(149, 21)
        Me.BookTitleComboBox.TabIndex = 4
        '
        'TypeOfBookComboBox
        '
        Me.TypeOfBookComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TypeOfBookComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TypeOfBookComboBox.FormattingEnabled = True
        Me.TypeOfBookComboBox.Location = New System.Drawing.Point(351, 11)
        Me.TypeOfBookComboBox.Name = "TypeOfBookComboBox"
        Me.TypeOfBookComboBox.Size = New System.Drawing.Size(155, 21)
        Me.TypeOfBookComboBox.TabIndex = 5
        '
        'AuthorComboBox
        '
        Me.AuthorComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.AuthorComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.AuthorComboBox.FormattingEnabled = True
        Me.AuthorComboBox.Location = New System.Drawing.Point(512, 10)
        Me.AuthorComboBox.Name = "AuthorComboBox"
        Me.AuthorComboBox.Size = New System.Drawing.Size(195, 21)
        Me.AuthorComboBox.TabIndex = 6
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
        Me.BookIdTextBox.IsPlaceHolder = True
        Me.BookIdTextBox.Location = New System.Drawing.Point(75, 12)
        Me.BookIdTextBox.Name = "BookIdTextBox"
        Me.BookIdTextBox.PlaceHolderText = "hello"
        Me.BookIdTextBox.Size = New System.Drawing.Size(115, 20)
        Me.BookIdTextBox.TabIndex = 9
        '
        'BookInfoControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.BookIdTextBox)
        Me.Controls.Add(Me.Button)
        Me.Controls.Add(Me.STTTextBox)
        Me.Controls.Add(Me.AuthorComboBox)
        Me.Controls.Add(Me.TypeOfBookComboBox)
        Me.Controls.Add(Me.BookTitleComboBox)
        Me.Name = "BookInfoControl"
        Me.Size = New System.Drawing.Size(793, 37)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BookTitleComboBox As Windows.Forms.ComboBox
    Friend WithEvents TypeOfBookComboBox As Windows.Forms.ComboBox
    Friend WithEvents AuthorComboBox As Windows.Forms.ComboBox
    Friend WithEvents STTTextBox As Windows.Forms.TextBox
    Friend WithEvents Button As Windows.Forms.Button
    Friend WithEvents BookIdTextBox As PlaceHolderTextBox
End Class
