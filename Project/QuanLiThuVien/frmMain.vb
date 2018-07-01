Imports DTO

Public Class frmMain
    Private loginAccount As Account
    Public Sub New(loginAccount As Account)
        InitializeComponent()
        Me.loginAccount = loginAccount
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = WindowState.Maximized
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
    Private Sub TrảSáchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrảSáchToolStripMenuItem.Click
        Dim frm = New frmTraSach()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub LậpThẻĐộcGiảToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LậpThẻĐộcGiảToolStripMenuItem.Click
        Dim frm = New frmTaoTheDocGia()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub TìnhHìnhMượnSáchTheoThểLoạiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TìnhHìnhMượnSáchTheoThểLoạiToolStripMenuItem.Click
        Dim frm = New frmBaoCaoTinhHinhMuonSachTheoTheLoai()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub TìnhHìnhTrảSáchTrễToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TìnhHìnhTrảSáchTrễToolStripMenuItem.Click
        Dim frm = New frmBaoCaoTraSachTre()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub QuảnLíLoạiĐộcGảiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLíLoạiĐộcGảiToolStripMenuItem.Click
        Dim frm = New frmQuanLiLoaiDocGia()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ThêmLoạiĐộcGiảToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThêmLoạiĐộcGiảToolStripMenuItem.Click
        Dim frm = New frmThemLoaiDocGia()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub NhaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NhaToolStripMenuItem.Click
        Dim frm = New frmThemTheLoaiSach()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub QuảnLíThểLoạiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLíThểLoạiToolStripMenuItem.Click
        Dim frm = New frmQuanLiTheLoaiSach()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub NhậpTácGiảToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NhậpTácGiảToolStripMenuItem.Click
        Dim frm = New frmThemTacGia()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub QuảnLíTácGiảToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLíTácGiảToolStripMenuItem.Click
        Dim frm = New frmQuanLiTacGia()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub QuảnLíQuiĐịnhToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLíQuiĐịnhToolStripMenuItem.Click
        Dim frm = New frmQuanLiQuiDinh()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub MeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MeToolStripMenuItem.Click
        Dim frm = New frmAboutMe()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class
