Imports BUS
Imports DAO
Imports DTO

Public Class frmLogin
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Tạo account mặc định nếu db chưa có account
        Dim listAccount = New List(Of Account)
        Dim result = AccountBUS.Instance.SelectAll(listAccount)
        If result.FlagResult Then
            result.FlagResult = listAccount.Count > 1
        End If

    End Sub

  
    Private Sub CreateDefaultAdminAccount()
        Try
            Dim account = New Account()
            account.UserName = "admin"
            account.DisplayName = "admin"
            account.Password = "admin"
            account.Type = 1
            AccountBUS.Instance.CreateAccount(account)
        Catch
        End Try
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim userName As String = txtUsername.Text
        Dim password As String = txtPassword.Text
    End Sub

    Private Function Login(userName As String, password As String) As Boolean
        Return DAO.AccountDAO.Instance.Login(userName, password).FlagResult
    End Function

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If MessageBox.Show("Bạn có thật sự muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel) = System.Windows.Forms.DialogResult.OK Then
            Application.[Exit]()
        End If
    End Sub

      Private Sub CreateDefaultUserAccount()
        Try
            Dim account = New Account()
            account.UserName = "user"
            account.DisplayName = "user"
            account.Password = "user"
            account.Type = 0
            AccountBUS.Instance.CreateAccount(account)
        Catch
        End Try
    End Sub


End Class