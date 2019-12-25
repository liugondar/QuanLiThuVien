Imports DTO
Imports BUS
Imports Utility
Imports System.Diagnostics
Public Class frmMain

    Dim ctpmBus As ChiTietPhieuMuonSach
    Dim sachBus As DauSachBus
    Dim ngBus As DocGiaBus

    Private loginAccount As Account
    Public Sub New(loginAccount As Account)
        InitializeComponent()
        Me.loginAccount = loginAccount
        If loginAccount.Type = 0 Then
            ThêmLoạiĐộcGiảToolStripMenuItem.Enabled = False
            ThêmTheLoaiToolStripMenuItem.Enabled = False
            ThêmTácGiảToolStripMenuItem.Enabled = False
            AdminToolStripMenuItem.Visible = False
            BáoCáoToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = WindowState.Maximized

        Dim result As Result
        ctpmBus = New ChiTietPhieuMuonSach()
        sachBus = New DauSachBus()
        ngBus = New DocGiaBus()

        ' Hien thi so dau sach
        Dim listSach As New List(Of DauSachDTO)
        result = sachBus.selectALL(listSach)

        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách đầu sách thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        lbSoDauSach.Text = listSach.Count.ToString()

        ' Hien thi so doc gia
        Dim listDocGia As New List(Of DocGia)
        result = ngBus.selectAllDocGia(listDocGia)

        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách độc giả thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        lbSoDocGia.Text = listDocGia.Count.ToString()

        '' Hien thi so luot muon
        'Dim listctpm As New List(Of ChiTietPhieuMuonSach)
        'result = ctpmBus.

        'If (result.FlagResult = False) Then
        '    MessageBox.Show("Lấy danh sách phiếu mượn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    System.Console.WriteLine(result.SystemMessage)
        '    Return
        'End If

        'lbSoLuotMuon.Text = listctpm.Count.ToString()






    End Sub

    Private Sub QuảnLíĐộcGiảToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLíĐộcGiảToolStripMenuItem.Click
        Dim frm = New frmDocGia(loginAccount)
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub NhậpSáchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NhậpSáchToolStripMenuItem.Click
    End Sub

    Private Sub QuảnLíSáchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLíSáchToolStripMenuItem.Click
        Dim frm = New frmQuanLiSach(loginAccount)
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
        Dim frm = New frmQuanLiLoaiDocGia(loginAccount)
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ThêmLoạiĐộcGiảToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThêmLoạiĐộcGiảToolStripMenuItem.Click
        Dim frm = New frmThemLoaiDocGia()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub NhaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThêmTheLoaiToolStripMenuItem.Click
        Dim frm = New frmThemTheLoaiSach()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub QuảnLíThểLoạiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLíThểLoạiToolStripMenuItem.Click
        Dim frm = New frmTheLoai(loginAccount)
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub NhậpTácGiảToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThêmTácGiảToolStripMenuItem.Click
        Dim frm = New frmThemTacGia()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub QuảnLíTácGiảToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLíTácGiảToolStripMenuItem.Click
        Dim frm = New frmQuanLiTacGia(loginAccount) With {
            .MdiParent = Me
        }
        frm.Show()
    End Sub

    Private Sub QuảnLíQuiĐịnhToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLíQuiĐịnhToolStripMenuItem.Click
        Dim frm = New frmQuanLiQuiDinh(loginAccount) With {
            .MdiParent = Me
        }
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

    Private Sub ThôngTinCáNhânToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThôngTinCáNhânToolStripMenuItem.Click
        Dim frm = New frmAccountProfile(loginAccount) With {
                .MdiParent = Me
            }
        AddHandler frm.UpdateAccount, AddressOf AccountProfileForm_UpdateAccount
        frm.Show()
    End Sub

    Private Function AccountProfileForm_UpdateAccount(sender As Object, e As AccountEvent) As Object
        loginAccount = e.Acc
    End Function

    Private Sub ThêmTàiKhoảnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThêmTàiKhoảnToolStripMenuItem.Click
        Dim frm = New frmThemAccount()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub QuảnLíTàiKhoảnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLíTàiKhoảnToolStripMenuItem.Click
        Dim frm = New frmQuanLiAccount()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub NhậpMớiiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NhậpMớiiToolStripMenuItem.Click
        Dim frm = New frmNhapSach()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub CậpNhậtSốLượngSáchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CậpNhậtSốLượngSáchToolStripMenuItem.Click
        Dim frm = New frmNhapThemSach()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub XóaSáchKhỏiKhoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XóaSáchKhỏiKhoToolStripMenuItem.Click
        Dim frm = New frmXoaSach()
        frm.MdiParent = Me
        frm.Show()
    End Sub
End Class
