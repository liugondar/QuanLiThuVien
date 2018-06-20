Public Class frmMain
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = WindowState.Maximized
    End Sub

    Private Sub LậpThẻĐộcGiảToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles LậpThẻĐộcGiảToolStripMenuItem.Click
        Dim frm = New frmTaoTheDocGia()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub QuảnLíĐộcGiảToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLíĐộcGiảToolStripMenuItem.Click
        Dim frm = New frmQuanLiTheDocGia()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub NhậpSáchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NhậpSáchToolStripMenuItem.Click
        Dim frm = New frmNhapSach()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub QuảnLíSáchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLíSáchToolStripMenuItem.Click
        Dim frm = New frmQuanLiSach()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ChoMượnSáchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChoMượnSáchToolStripMenuItem.Click
        Dim frm = New frmChoMuonSach()
        frm.MdiParent = Me
        frm.Show()
    End Sub
End Class
