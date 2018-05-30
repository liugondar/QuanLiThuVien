<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ThẻĐộcGiảToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LậpThẻĐộcGiảToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuảnLíĐộcGiảToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ThẻĐộcGiảToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(909, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ThẻĐộcGiảToolStripMenuItem
        '
        Me.ThẻĐộcGiảToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LậpThẻĐộcGiảToolStripMenuItem, Me.QuảnLíĐộcGiảToolStripMenuItem})
        Me.ThẻĐộcGiảToolStripMenuItem.Name = "ThẻĐộcGiảToolStripMenuItem"
        Me.ThẻĐộcGiảToolStripMenuItem.Size = New System.Drawing.Size(81, 20)
        Me.ThẻĐộcGiảToolStripMenuItem.Text = "Thẻ độc giả"
        '
        'LậpThẻĐộcGiảToolStripMenuItem
        '
        Me.LậpThẻĐộcGiảToolStripMenuItem.Name = "LậpThẻĐộcGiảToolStripMenuItem"
        Me.LậpThẻĐộcGiảToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.LậpThẻĐộcGiảToolStripMenuItem.Text = "Lập thẻ độc giả"
        '
        'QuảnLíĐộcGiảToolStripMenuItem
        '
        Me.QuảnLíĐộcGiảToolStripMenuItem.Name = "QuảnLíĐộcGiảToolStripMenuItem"
        Me.QuảnLíĐộcGiảToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.QuảnLíĐộcGiảToolStripMenuItem.Text = "Quản Lí độc giả"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 288)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.Name = "frmMain"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ThẻĐộcGiảToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LậpThẻĐộcGiảToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuảnLíĐộcGiảToolStripMenuItem As ToolStripMenuItem
End Class
