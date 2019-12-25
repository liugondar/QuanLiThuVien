Imports BUS
Imports DTO
Imports Utility

Public Class frmAccountProfile
    Private loginAccount As Account

    Public Sub New(loginAccount As Account)
        Me.loginAccount = loginAccount
        InitializeComponent()
        txtUserName.Text = loginAccount.UserName
        txtDisplayName.Text = loginAccount.DisplayName
    End Sub

    Public Event UpdateAccount As EventHandler(Of AccountEvent)

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If MessageBox.Show("Bạn có chắc thay đổi thông tin?", "Thông Báo", MessageBoxButtons.OKCancel) = System.Windows.Forms.DialogResult.OK Then

            '1. Guard clause
            If String.IsNullOrWhiteSpace(txtDisplayName.Text) Then
                MessageBox.Show("Tên hiển thị trống!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If String.IsNullOrWhiteSpace(txtPassword.Text) Then
                MessageBox.Show("Password trống !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If txtNewPassword.Text <> txtNewPasswordConfirm.Text Then
                MessageBox.Show("Password mới không giống nhau!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If Not AccountBUS.Instance.Login(loginAccount.UserName, txtPassword.Text).FlagResult Then
                MessageBox.Show("Password đã nhập không chính xác!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            '2. Update account
            Dim newAccountProfile = New Account()
            newAccountProfile.UserName = loginAccount.UserName
            newAccountProfile.AccountId = loginAccount.AccountId
            newAccountProfile.DisplayName = txtDisplayName.Text
            newAccountProfile.Password = txtNewPassword.Text
            newAccountProfile.Type = loginAccount.Type
            Dim updateResult = AccountBUS.Instance.UpdateAccount(newAccountProfile)
            If updateResult.FlagResult = False Then
                MessageBox.Show("Cập nhật không thành công!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            AccountBUS.Instance.getAccountByUserName(loginAccount, loginAccount.UserName)
            RaiseEvent UpdateAccount(Me, New AccountEvent(loginAccount))
            MessageBox.Show("Cập nhật thành công!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class