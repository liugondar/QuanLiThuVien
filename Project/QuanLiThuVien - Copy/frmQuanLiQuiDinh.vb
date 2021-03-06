﻿Imports BUS
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
        If MessageBox.Show("Bạn có chắc thay đổi thông tin?", "Thông Báo", MessageBoxButtons.OKCancel) = System.Windows.Forms.DialogResult.OK Then

            If Not UpdateQuiDinh().FlagResult Then
                MessageBox.Show("Cập nhật không thành công!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            MessageBox.Show("Cập nhật thành công!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadThongTinQuiDinh()
        End If
    End Sub

    Private Sub btnNhapVaDong_Click(sender As Object, e As EventArgs) Handles btnUpdateVaDong.Click
        If MessageBox.Show("Bạn có chắc thay đổi thông tin?", "Thông Báo", MessageBoxButtons.OKCancel) = System.Windows.Forms.DialogResult.OK Then
            Dim updateQuiDinhResult = UpdateQuiDinh()

            If Not updateQuiDinhResult.FlagResult Then
                Dim message = "Cập nhật không thành công!"
                If Not String.IsNullOrEmpty(updateQuiDinhResult.ApplicationMessage) Then message = updateQuiDinhResult.ApplicationMessage
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            MessageBox.Show("Cập nhật thành công!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub

    Private Function UpdateQuiDinh() As Result
        Dim validateResult = ValidateField()
        If validateResult.FlagResult = False Then Return validateResult
        _quiDinh.SoNgayMuonSachToiDa = txtSoNgayMuonToiDa.Text
        _quiDinh.SoSachMuonToiDa = txtSoSachMuonToiDa.Text
        _quiDinh.ThoiHanNhanSach = txtThoiHanNhanSach.Text
        _quiDinh.ThoiHanToiDaTheDocGia = txtThoiHanThe.Text
        _quiDinh.TuoiToiDa = txtTuoiToiDa.Text
        _quiDinh.TuoiToiThieu = txtTuoiToiThieu.Text

        Return _quiDinhBus.Update(_quiDinh)
    End Function

    Private Function ValidateField() As Result
        If String.IsNullOrEmpty(txtSoNgayMuonToiDa.Text) Then Return New Result(False, "Xin nhập số ngày mượng tối đa!", "")
        If String.IsNullOrEmpty(txtTuoiToiThieu.Text) Then Return New Result(False, "Xin nhập tuổi tối thiểu!", "")
        If String.IsNullOrEmpty(txtTuoiToiDa.Text) Then Return New Result(False, "Xin nhập tuổi tối đa!", "")
        If String.IsNullOrEmpty(txtThoiHanThe.Text) Then Return New Result(False, "Xin nhập thời hạn thẻ!", "")
        If String.IsNullOrEmpty(txtSoSachMuonToiDa.Text) Then Return New Result(False, "Xin nhập số mượng tối đa!", "")
        If String.IsNullOrEmpty(txtThoiHanNhanSach.Text) Then Return New Result(False, "Xin nhập thời hạn nhận sách!", "")
        If String.IsNullOrEmpty(txtThoiHanThe.Text) Then Return New Result(False, "Xin nhập thời hạn thẻ!", "")

        Return New Result(True)
    End Function
#End Region
End Class