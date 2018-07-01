Public Class Account

    Public Property AccountId As String
    Public Property UserName As String
    Public Property Password As String
    Public Property Type As Integer '0 is normal user,1 is admin
    Public Property DisplayName As String

    Public Sub New()
    End Sub
    Public Sub New(row As DataRow)
        Dim doesRowContainsCorrectFields = row.Table.Columns.Contains("userName") And
       row.Table.Columns.Contains("displayName") And
       row.Table.Columns.Contains("accountId") And
       row.Table.Columns.Contains("password") And
       row.Table.Columns.Contains("type")
        If doesRowContainsCorrectFields = False Then
            Return
        End If

        Integer.TryParse(row("Type").ToString(), Type)
        AccountId = row("accountId").ToString()
        Password = row("password").ToString()
        DisplayName = row("displayName").ToString()
        UserName = row("userName").ToString()
    End Sub

    Public Sub New(accountId As String, userName As String, password As String, type As Integer, displayName As Integer)
        Me.AccountId = accountId
        Me.UserName = userName
        Me.Password = password
        Me.Type = type
        Me.DisplayName = displayName
    End Sub

    Public Function ValidateAll() As Boolean
        If String.IsNullOrWhiteSpace(UserName) Then Return False
        If String.IsNullOrWhiteSpace(Password) Then Return False
        If String.IsNullOrWhiteSpace(Type) Then Return False
        If String.IsNullOrWhiteSpace(DisplayName) Then Return False

        Return True
    End Function
End Class
