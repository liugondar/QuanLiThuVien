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
        query &= "EXECUTE USP_ThemDocGia"
        query &= "@TenDocGia=N'" & docGia.TenDocGia & "',"
        query &= "@TenNguoiTao =N'" & docGia.TenNguoiTao & "',"
        query &= "@Email=N'" & docGia.Email & "',"
        query &= "@DiaChi =N'" & docGia.DiaChi & "',"
        query &= "@LoaiDocGiaId=" & docGia.LoaiDocGiaId & ","
        query &= "@NgaySinh='" & docGia.NgaySinh & "',"
        query &= "@NgayTao='" & docGia.NgayTao & "',"
        query &= "@NgayHetHan='"& docGia.NgayHetHan &"'"

        Dim result = _dataProvider.ExcuteNonquery(query)
        Return result
    End Function
End Class
