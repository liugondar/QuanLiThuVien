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
        Dim query As String = String.Empty
        query &= "EXECUTE USP_ThemTheDocGia "
        query &= "@MaTheDocGia=N'" & docGia.MaTheDocGia & "', "
        query &= "@TenDocGia=N'" & docGia.TenDocGia & "', "
        query &= "@Email=N'" & docGia.Email & "', "
        query &= "@DiaChi =N'" & docGia.DiaChi & "', "
        query &= "@MaLoaiDocGia=" & docGia.MaLoaiDocGia & ", "
        query &= "@NgaySinh='" & docGia.NgaySinh & "', "
        query &= "@NgayTao='" & docGia.NgayTao & "', "
        query &= "@NgayHetHan='" & docGia.NgayHetHan & "' "

        Dim result = _dataProvider.ExcuteNonquery(query)
        Return result
    End Function

    Public Function DeleteByReaderID(maThe As String) As Result
        Dim query As String = String.Empty
        query &= "EXECUTE USP_XoaTheDocGia "
        query &= "@MaTheDocGia=" & maThe
        Dim result = _dataProvider.ExcuteNonquery(query)
        Return result
    End Function

    Public Function UpdateByReaderId(DocGia As DocGia) As Result
        Dim query As String = String.Empty
        query &= "EXECUTE USP_SuaTheDocGia "
        query &= "@MaTheDocGia=N'" & DocGia.MaTheDocGia & "', "
        query &= "@TenDocGia=N'" & DocGia.TenDocGia & "', "
        query &= "@Email=N'" & DocGia.Email & "', "
        query &= "@DiaChi =N'" & DocGia.DiaChi & "', "
        query &= "@MaLoaiDocGia=" & DocGia.MaLoaiDocGia & ", "
        query &= "@NgaySinh='" & DocGia.NgaySinh & "'"
        Dim result = _dataProvider.ExcuteNonquery(query)
        Return result
    End Function

#End Region

#Region "-   Retrieve data    -"

    Public Function SelectAllByType(maLoai As String, ByRef listDocGia As List(Of DocGia)) As Result
        Dim query As String = String.Empty
        query = String.Format("select * from TheDocGia where [MaLoaiDocGia]={0} and DeleteFlag='N'", maLoai)
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            Dim docGia = New DocGia(row)
            listDocGia.Add(docGia)
        Next

        Return result
    End Function

    Public Function GetReaderNameByID(ByRef tenDocGia As String, maThe As String) As Result
        Dim query As String = String.Empty
        query = String.Format("select TenDocGia from TheDocGia where MaTheDocGia={0} and DeleteFlag='N'", maThe)

        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            tenDocGia = row("TenDocGia")
        Next
        Return result
    End Function

    Public Function GetTheLastTheDocGiaID(ByRef maTheDocGia As String) As Result
        Dim query As String = String.Empty
        query &= "select top 1 [MaTheDocGia] "
        query &= "from TheDocGia "
        query &= "Where deleteFlag='N'"
        query &= "ORDER BY [MaTheDocGia] DESC "
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            maTheDocGia = row("MaTheDocGia")
        Next
        Return result
    End Function

    Public Function GetExpirationDateById(ByRef ngayHetHan As DateTime, maThe As String) As Result
        Dim query = String.Empty
        query = String.Format("Select ngayHetHan from TheDocGia where MaTheDocGia={0} and DeleteFlag='N'", maThe)
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            DateTime.TryParse(row("NgayHetHan").ToString(), ngayHetHan)
        Next
        Return result
    End Function

    Public Function GetReaderByID(ByRef docGia As DocGia, maThe As String) As Object
        Dim query As String = String.Empty
        query = String.Format("select * from TheDocGia where MaTheDocGia={0} and DeleteFlag='N'", maThe)

        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            docGia = New DocGia(row)
        Next
        Return result
    End Function

#End Region
End Class
