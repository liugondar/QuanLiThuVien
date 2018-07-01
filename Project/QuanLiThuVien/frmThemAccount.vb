Imports BUS
Imports DTO
Imports Utility

Public Class frmThemAccount
    Private Sub frmThemAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadLoaiTaiKhoanComboBox()
    End Sub

    Private Sub LoadLoaiTaiKhoanComboBox()
        Dim loaiTaiKhoanNhanVien = New LoaiTaiKhoan()
        loaiTaiKhoanNhanVien.MaLoaiTaiKhoan = 0
        loaiTaiKhoanNhanVien.TenLoaiTaiKhoan = "Nhân viên"
        cbType.Items.Add(loaiTaiKhoanNhanVien)
        Dim loaitkAdmin = New LoaiTaiKhoan()
        loaitkAdmin.MaLoaiTaiKhoan = 1
        loaitkAdmin.TenLoaiTaiKhoan = "Admin"
        cbType.Items.Add(loaitkAdmin)

        cbType.ValueMember = "MaLoaiTaiKhoan"
        cbType.DisplayMember = "TenLoaiTaiKhoan"
        cbType.SelectedIndex = 0
    End Sub

    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        InsertAccount()
    End Sub

    Private Sub btnThemVaDong_Click(sender As Object, e As EventArgs) Handles btnThemVaDong.Click
        If InsertAccount() Then
            Me.Close()
        End If
    End Sub
    Private Function InsertAccount() As Boolean
        Dim account = New Account()
        account.DisplayName = txtDisplayName.Text
        account.Password = txtPassword.Text
        account.Type = cbType.SelectedItem.MaLoaiTaiKhoan
        account.UserName = txtUserName.Text
        Dim insertResult = AccountBUS.Instance.CreateAccount(account)
        If Not insertResult.FlagResult Then
            MessageBox.Show(insertResult.ApplicationMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        MessageBox.Show("Thêm tài khoản mới thành công", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return True
    End Function
End Class