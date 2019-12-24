Imports DAO
Imports DTO
Imports Utility

Public Class AccountBUS
#Region "-  Fields   -"
    Private Shared _instance As AccountBUS

    Public Shared Property Instance As AccountBUS
        Get
            If _instance Is Nothing Then _instance = New AccountBUS()
            Return _instance
        End Get
        Private Set(ByVal value As AccountBUS)
            _instance = value
        End Set
    End Property

    Private Sub New()
    End Sub
#End Region

#Region "-   Retrieve data  -"
    Public Function Login(ByVal userName As String, ByVal password As String) As Result
        If String.IsNullOrWhiteSpace(userName) Then Return New Result(False, "Tên đăng nhập trống !", "")
        If String.IsNullOrWhiteSpace(password) Then Return New Result(False, "Password trống!", "")
        Return DAO.AccountDAO.Instance.Login(userName, password)
    End Function

    Public Function getAccountByUserName(ByRef account As Account, ByVal userName As String) As Result
        If String.IsNullOrWhiteSpace(userName) Then Return New Result(False, "Tên đăng nhập trống !", "")
        Return DAO.AccountDAO.Instance.getAccountByUserName(account, userName)
    End Function

    Public Function SelectAll(ByRef listAccount As List(Of Account)) As Result
        Return DAO.AccountDAO.Instance.SelectAll(listAccount)
    End Function
    Public Function SelectAllByType(ByRef listAccount As List(Of Account), type As String) As Result
        If String.IsNullOrWhiteSpace(type) Then Return New Result(False, "Empty type", "")
        Return DAO.AccountDAO.Instance.SelectAllByType(listAccount, type)
    End Function

#End Region

#Region "-   Update    -"
    Public Function UpdateAccount(newAccountProfile As Account) As Result
        If String.IsNullOrWhiteSpace(newAccountProfile.UserName) Then Return New Result(False, "Tên đăng nhập trống !", "")
        If String.IsNullOrWhiteSpace(newAccountProfile.Type) Then Return New Result(False, "Loại tài khoản trống!", "")
        If String.IsNullOrWhiteSpace(newAccountProfile.DisplayName) Then Return New Result(False, "Tên hiển thị nhập trống !", "")

        Return AccountDAO.Instance.UpdateAccount(newAccountProfile)
    End Function
    Public Function ChangeAccount(newAccountProfile As Account) As Result
        If String.IsNullOrWhiteSpace(newAccountProfile.UserName) Then Return New Result(False, "Tên đăng nhập trống !", "")
        If String.IsNullOrWhiteSpace(newAccountProfile.Type) Then Return New Result(False, "Loại tài khoản trống!", "")
        If String.IsNullOrWhiteSpace(newAccountProfile.DisplayName) Then Return New Result(False, "Tên hiển thị nhập trống !", "")

        Return AccountDAO.Instance.UpdateAccount(newAccountProfile)
    End Function

#End Region

#Region "-   Insert   -"
    Public Function CreateAccount(account As Account) As Result
        If Not account.ValidateAll() Then Return New Result(False, "Tạo tài khoảng không thành công,Vui lòng kiểm tra lại thông tin tài khoản!", "")
        Return AccountDAO.Instance.CreateAccount(account)
    End Function

    Public Function UpdateAccountTypeByUserName(account As Account) As Result
        If String.IsNullOrWhiteSpace(account.UserName) Then Return New Result(False, "Tài khoản trống", "")
        If String.IsNullOrWhiteSpace(account.Type) Then Return New Result(False, "Tài khoản trống", "")
        Return AccountDAO.Instance.UpdateAccountTypeByUserName(account)
    End Function
    Public Function UpdateAccountTypeByUserMail(account As Account) As Result
        If String.IsNullOrWhiteSpace(account.UserName) Then Return New Result(False, "Tài khoản trống", "")
        If String.IsNullOrWhiteSpace(account.Type) Then Return New Result(False, "Tài khoản trống", "")
        Return AccountDAO.Instance.UpdateAccountTypeByUserName(account)
    End Function

    Public Function DeleteByUserName(userName As String) As Object
        If String.IsNullOrWhiteSpace(userName) Then Return New Result(False, "Tài khoản trống", "")
        Return AccountDAO.Instance.DeleteByUserName(userName)
    End Function
    Public Function DeleteByUserMail(userName As String) As Object
        If String.IsNullOrWhiteSpace(userName) Then Return New Result(False, "Tài khoản trống", "")
        Return AccountDAO.Instance.DeleteByUserName(userName)
    End Function
#End Region



End Class
