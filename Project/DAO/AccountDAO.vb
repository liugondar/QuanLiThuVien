Imports DTO
Imports Utility

Public Class AccountDAO

#Region "-   Fields   -"
    Private Shared _instance As AccountDAO

    Public Shared Property Instance As AccountDAO
        Get
            If _instance Is Nothing Then _instance = New AccountDAO()
            Return _instance
        End Get
        Private Set(ByVal value As AccountDAO)
            _instance = value
        End Set
    End Property

    Private Sub New()
    End Sub
#End Region

#Region "-  Insert   -"
    Public Function CreateAccount(account As Account) As Result
        Dim salt As String = BCrypt.Net.BCrypt.GenerateSalt()
        Dim passwordHash = BCrypt.Net.BCrypt.HashPassword(account.Password, salt)
        Dim doesPasswordMatch = BCrypt.Net.BCrypt.Verify(account.Password, passwordHash)

        Dim isRegisterSuccessfull = New Result(False, "Tạo tài khoản k thành công!", "")
        If doesPasswordMatch Then
            Dim query = String.Format("EXEC USP_CreateAccount @userName=N'{0}',
@displayName=N'{1}',@password=N'{2}',
@salt=N'{3}',@type={4}", account.UserName,
account.DisplayName, passwordHash,
salt, account.Type)
            isRegisterSuccessfull = DataProvider.Instance.ExecuteNonquery(query)
        End If

        Return isRegisterSuccessfull
    End Function
#End Region

#Region "-   Update  and delete -"
    Public Function UpdateAccount(newAccountProfile As Account) As Result
        Dim salt As String = BCrypt.Net.BCrypt.GenerateSalt()
        Dim newpassword = newAccountProfile.Password
        Dim passwordHash As String = BCrypt.Net.BCrypt.HashPassword(newpassword, salt)
        Dim doesPasswordMatch As Boolean = BCrypt.Net.BCrypt.Verify(newpassword, passwordHash)
        Dim result = New Result()

        If doesPasswordMatch Then
            Dim dieuKienPassword = If(
        String.IsNullOrWhiteSpace(newAccountProfile.Password),
        "",
        String.Format(",[Password]='{0}',
salt='{1}'", passwordHash, salt))
            Dim query = String.Format("update Account
set DisplayName='{0}' {1}
where AccountId={2}", newAccountProfile.DisplayName, dieuKienPassword,
newAccountProfile.AccountId)
            result = DataProvider.Instance.ExecuteNonquery(query)
        End If

        Return result
    End Function

    Public Function UpdateAccountTypeByUserName(account As Account) As Result
        Dim query = String.Format("Update account set type={0} where userName='{1}'",
account.Type, account.UserName)
        Return DataProvider.Instance.ExecuteNonquery(query)
    End Function

    Public Function DeleteByUserName(userName As String) As Result
        Dim query = String.Format("delete from Account where UserName='{0}'", userName)
        Return DataProvider.Instance.ExecuteNonquery(query)
    End Function

#End Region

#Region "-   Retrieve data   -"
    Public Function Login(ByVal userName As String, ByVal password As String) As Result
        Dim query1 As String = "select salt from account where userName='" & userName & "'"
        Dim salt As String = String.Empty
        Dim doesPasswordMatch = False
        Dim passwordHash As String = String.Empty
        Dim temp = New DataTable()
        Dim getSaltResult = DataProvider.Instance.ExecuteQuery(query1, temp)

        For Each item As DataRow In temp.Rows
            salt = item("salt").ToString()
        Next

        If salt <> "" Then
            passwordHash = BCrypt.Net.BCrypt.HashPassword(password, salt)
            doesPasswordMatch = BCrypt.Net.BCrypt.Verify(password, passwordHash)
        End If

        If doesPasswordMatch Then
            Dim query = String.Format("EXEC dbo.USP_LOGIN @username ='{0}', @password='{1}' ",
                                            userName, passwordHash)
            Dim accountTable = New DataTable()
            Dim result = DataProvider.Instance.ExecuteQuery(query, accountTable)
            If result.FlagResult = False Then Return result
            If accountTable.Rows.Count > 0 Then Return New Result()
        End If

        Return New Result(False, "Đăng nhập không thành công! ", "")
    End Function



    Public Function getAccountByUserName(ByRef account As Account, ByVal userName As String) As Result
        Dim data = New DataTable()
        Dim query = "select * from account where username='" & userName & "'"
        Dim result = DataProvider.Instance.ExecuteQuery(query, data)

        For Each item As DataRow In data.Rows
            account = New Account(item)
        Next

        Return result
    End Function

    Public Function SelectAll(ByRef listAccount As List(Of Account)) As Result
        Dim query = "Select * from account"
        Dim dataTAble = New DataTable()
        Dim result = DataProvider.Instance.ExecuteQuery(query, dataTAble)
        For Each row In dataTAble.Rows
            Dim account = New Account(row)
            listAccount.Add(account)
        Next
        Return result
    End Function

    Public Function SelectAllByType(ByRef listAccount As List(Of Account), type As String) As Result
        Dim query = "Select * from account where type=" & type
        Dim dataTAble = New DataTable()
        Dim result = DataProvider.Instance.ExecuteQuery(query, dataTAble)
        For Each row In dataTAble.Rows
            Dim account = New Account(row)
            listAccount.Add(account)
        Next
        Return result
    End Function

#End Region


End Class

