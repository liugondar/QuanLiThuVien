Imports BUS
Imports DTO
Imports Utility

Public Class frmQuanLiQuiDinh
    Private _quiDinhBus As QuiDinhBus
    Private _quiDinh As QuiDinh
    Private loginAccount As Account

#Region "-   Constructor   -"
    Public Sub New(loginAccount As Account)
        Me.loginAccount = loginAccount
        InitializeComponent()
        'nếu là nhân viên bình thường không cho phép can thiệp sửa xoá db
        If loginAccount.Type = 0 Then
            btnUpdate.Visible = False
            btnUpdateVaDong.Visible = False
        End If
    End Sub
    Private Sub frmQuanLiQuiDinh_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _quiDinhBus = New QuiDinhBus()
        _quiDinh = New QuiDinh()
        LoadThongTinQuiDinh()
    End Sub

    Private Sub LoadThongTinQuiDinh()
        Dim result = _quiDinhBus.SelectAll(_quiDinh)
        If result.FlagResult = False Then
            MessageBox.Show("Không thể lấy danh sách các qui định!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
        txtSoNgayMuonToiDa.Text = _quiDinh.SoNgayMuonSachToiDa
        txtSoSachMuonToiDa.Text = _quiDinh.SoSachMuonToiDa
        txtThoiHanNhanSach.Text = _quiDinh.ThoiHanNhanSach
        txtThoiHanThe.Text = _quiDinh.ThoiHanToiDaTheDocGia
        txtTuoiToiDa.Text = _quiDinh.TuoiToiDa
        txtTuoiToiThieu.Text = _quiDinh.TuoiToiThieu
    End Sub
#End Region

#Region "-  Events   -"
    Private Sub btnNhap_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If Not UpdateQuiDinh().FlagResult Then
            MessageBox.Show("Cập nhật không thành công!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        MessageBox.Show("Cập nhật thành công!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        LoadThongTinQuiDinh()
    End Sub

    Private Sub btnNhapVaDong_Click(sender As Object, e As EventArgs) Handles btnUpdateVaDong.Click
        If Not UpdateQuiDinh().FlagResult Then
            MessageBox.Show("Cập nhật không thành công!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        MessageBox.Show("Cập nhật thành công!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Private Function UpdateQuiDinh() As Result
        _quiDinh.SoNgayMuonSachToiDa = txtSoNgayMuonToiDa.Text
        _quiDinh.SoSachMuonToiDa = txtSoSachMuonToiDa.Text
        _quiDinh.ThoiHanNhanSach = txtThoiHanNhanSach.Text
        _quiDinh.ThoiHanToiDaTheDocGia = txtThoiHanThe.Text
        _quiDinh.TuoiToiDa = txtTuoiToiDa.Text
        _quiDinh.TuoiToiThieu = txtTuoiToiThieu.Text

        Return _quiDinhBus.Update(_quiDinh)
    End Function
#End Region
End Class