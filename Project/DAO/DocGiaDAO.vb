Imports DTO
Imports Utility

Public Class DocGiaDAO
#Region "-   Fields   -"

    Private _dataProvider As DataProvider

#End Region

#Region "-   Constructor   -"

    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub

#End Region

#Region "-   Insert,update and delete -"

    Public Function InsertOne(docGia As DocGia) As Result
        Dim formatDate = DateHelper.Instance.GetFormatType()
        Dim query As String = String.Empty
        query &= "EXECUTE USP_ThemTheDocGia "
        query &= "@MaTheDocGia=N'" & docGia.MaTheDocGia & "', "
        query &= "@TenDocGia=N'" & docGia.TenDocGia & "', "
        query &= "@Email=N'" & docGia.Email & "', "
        query &= "@DiaChi =N'" & docGia.DiaChi & "', "
        query &= "@MaLoaiDocGia=" & docGia.MaLoaiDocGia & ", "
        query &= "@NgaySinh='" & docGia.NgaySinh.ToString(formatDate) & "', "
        query &= "@NgayTao='" & docGia.NgayTao.ToString(formatDate) & "', "
        query &= "@NgayHetHan='" & docGia.NgayHetHan.ToString(formatDate) & "' "

        Dim result = _dataProvider.ExecuteNonquery(query)
        Return result
    End Function

    Public Function DeleteByReaderID(maThe As String) As Result
        Dim query As String = String.Empty
        query &= "EXECUTE USP_XoaTheDocGia "
        query &= "@MaTheDocGia=" & maThe
         query &= "@NgaySinh='" & docGia.NgaySinh.ToString(formatDate) & "', "
        query &= "@NgayTao='" & docGia.NgayTao.ToString(formatDate) & "', "
        query &= "@NgayHetHan='" & docGia.NgayHetHan.ToString(formatDate) & "' "
        Dim result = _dataProvider.ExecuteNonquery(query)
        Return result
    End Function

    Public Function UpdateByReaderId(DocGia As DocGia) As Result
        Dim query As String = String.Empty
        Dim formatDate = DateHelper.Instance.GetFormatType()
        query &= "EXECUTE USP_SuaTheDocGia "
        query &= "@MaTheDocGia=N'" & DocGia.MaTheDocGia & "', "
        query &= "@TenDocGia=N'" & DocGia.TenDocGia & "', "
        query &= "@Email=N'" & DocGia.Email & "', "
        query &= "@DiaChi =N'" & DocGia.DiaChi & "', "
        query &= "@MaLoaiDocGia=" & DocGia.MaLoaiDocGia & ", "
        query &= "@NgaySinh='" & DocGia.NgaySinh.ToString(formatDate) & "'"
        Dim result = _dataProvider.ExecuteNonquery(query)
        Return result
    End Function

#End Region

#Region "-   Retrieve data    -"

    Public Function SelectAllByType(maLoai As String, ByRef listDocGia As List(Of DocGia)) As Result
        Dim dieuKienMaLoai = If(maLoai = -1, "1=1", "[MaLoaiDocGia]=" & maLoai)
        Dim query As String = String.Empty
        query = String.Format("select * from TheDocGia where {0} and DeleteFlag='N'", dieuKienMaLoai)
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            Dim docGia = New DocGia(row)
            listDocGia.Add(docGia)
        Next

        Return result
    End Function

    Public Function SelectAllDocGia(ByRef listDocGia As List(Of DocGia)) As Result
        Dim query = String.Empty
        query &= "Select * from TheDocGia where DeleteFlag='N'"
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        If result.FlagResult = True Then
            For Each row In dataTable.Rows
                Dim docgia = New DocGia(row)
                listDocGia.Add(docgia)
            Next
        End If
        Return result
    End Function

    Public Function GetReaderNameByID(ByRef tenDocGia As String, maThe As String) As Result
        Dim query As String = String.Empty
        query = String.Format("select TenDocGia from TheDocGia where MaTheDocGia={0} and DeleteFlag='N'", maThe)

        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            tenDocGia = row("TenDocGia")
        Next
        Return result
    End Function

    Public Function GetTheLastTheDocGiaID(ByRef maTheDocGia As String) As Result
        Dim query As String = String.Empty
        query &= "select top 1 [MaTheDocGia] "
        query &= "from TheDocGia "
          query &= "@MaTheDocGia=N'" & DocGia.MaTheDocGia & "', "
        query &= "@TenDocGia=N'" & DocGia.TenDocGia & "', "
        query &= "ORDER BY [MaTheDocGia] DESC "
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            maTheDocGia = row("MaTheDocGia")
        Next
        Return result
    End Function

    Public Function GetExpirationDateById(ByRef ngayHetHan As DateTime, maThe As String) As Result
        Dim query = String.Empty
        query = String.Format("Select ngayHetHan from TheDocGia where MaTheDocGia={0} and DeleteFlag='N'", maThe)
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            DateTime.TryParse(row("NgayHetHan").ToString(), ngayHetHan)
        Next
        Return result
    End Function

    Public Function GetReaderByID(ByRef docGia As DocGia, maThe As String) As Object
        Dim query As String = String.Empty
        query = String.Format("select * from TheDocGia where MaTheDocGia={0} and DeleteFlag='N'", maThe)

        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            docGia = New DocGia(row)
        Next
        Return result
    End Function

    
    Public Function GetReaderByTen(ByRef docGia As DocGia, maThe As String) As Object
        Dim query As String = String.Empty
        query = String.Format("select * from TheDocGia where MaTheDocGia={0} and DeleteFlag='N'", maThe)
  query = String.Format("select * from TheDocGia where {0} and DeleteFlag='N'", dieuKienMaLoai)
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            docGia = New DocGia(row)
        Next
        Return result
    End Function

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
End Class
