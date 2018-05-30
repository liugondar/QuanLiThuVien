Imports DTO
Imports Utility

Public Class DocGiaDAO
    Private _dataProvider As DataProvider
    Private _reader As DocGia

    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub
    Public Function InsertOne(docGia As DocGia) As Result
        Dim query As String = String.Empty
        query &= "EXECUTE USP_ThemTheDocGia "
        query &= "@TenDocGia=N'" & docGia.TenDocGia & "',"
        query &= "@Email=N'" & docGia.Email & "',"
        query &= "@DiaChi =N'" & docGia.DiaChi & "',"
        query &= "@MaLoaiDocGia=" & docGia.MaLoaiDocGia & ","
        query &= "@NgaySinh='" & docGia.NgaySinh & "',"
        query &= "@NgayTao='" & docGia.NgayTao & "',"
        query &= "@NgayHetHan='"& docGia.NgayHetHan &"'"

        Dim result = _dataProvider.ExcuteNonquery(query)
        Return result
    End Function

    Public Function SelectAllByType(maLoai As String, ByRef listDocGia As List(Of DocGia)) As Result
        Dim query As String = String.Empty
        query &= "select * from TheDocGia WHERE MaLoaiDocGia=" & maLoai
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            Dim docGia = New DocGia(row)
            listDocGia.Add(docGia)
        Next
        If listDocGia.Count < 1 Then
            Return New Result(False, "Không thể lấy danh sách độc giả theo loại", "")
        End If
        Return result
    End Function

End Class
