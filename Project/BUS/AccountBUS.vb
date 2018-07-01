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

#End Region

#Region "-   Update    -"
    Public Function changeAccountProfile(ByVal AccountId As Integer, ByVal newAccountDisplayName As String, ByVal newpassword As String) As Result
        If String.IsNullOrWhiteSpace(newAccountDisplayName) Then Return New Result(False, "Tên hiển thị tài khoản trống!", "")
        If String.IsNullOrWhiteSpace(newpassword) Then Return New Result(False, "Password mới trống!", "")
        Return DAO.AccountDAO.Instance.changeAccountProfile(AccountId, newAccountDisplayName, newpassword)
    End Function

#End Region

#Region "-   Insert   -"
    Public Function CreateAccount(account As Account) As Result
        If Not account.ValidateAll() Then Return New Result(False, "Tạo tài khoảng không thành công,Vui lòng kiểm tra lại thông tin tài khoản!", "")
        Return AccountDAO.Instance.CreateAccount(account)
    End Function
#End Region



End Class
