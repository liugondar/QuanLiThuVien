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

#Region "-   Update   -"
    Public Function changeAccountProfile(ByVal AccountId As Integer, ByVal newAccountDisplayName As String, ByVal newpassword As String) As Result
        Dim salt As String = BCrypt.Net.BCrypt.GenerateSalt()
        Dim passwordHash As String = BCrypt.Net.BCrypt.HashPassword(newpassword, salt)
        Dim doesPasswordMatch As Boolean = BCrypt.Net.BCrypt.Verify(newpassword, passwordHash)

        If doesPasswordMatch Then
            Dim query = String.Format("EXEC USP_changeAccountProfile @AccountId={0} , @newAccountDisplayName='{1}', @password='{2}', @salt='{3}'",
                                      AccountId, newAccountDisplayName, passwordHash, salt
                                      )
            Dim result = DataProvider.Instance.ExecuteNonquery(query)
        End If

        Return New Result()
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

#End Region


End Class

