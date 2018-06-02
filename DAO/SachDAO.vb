Imports DTO
Imports Utility

Public Class SachDAO
    Private _dataProvider As DataProvider

    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub

    Public Function InsertOne(sach As Sach) As Result
        Dim query = String.Empty
        query &= "EXECUTE USP_NhapSach "
        query &= "@TenSach = N'" & sach.TenSach & "',"
        query &= "@MaTheLoaiSach =" & sach.MaTheLoaiSach & " ,"
        query &= "@MaTacGia =" & sach.MaTacGia & " ,"
        query &= "@TenNhaXuatBan =N'" & sach.TenNhaXuatBan & "',"
        query &= "@NgayXuatBan='" & sach.NgayXuatBan & "' ,"
        query &= "@NgayNhap='" & sach.NgayNhap & "' ,"
        query &= "@TriGia =" & sach.TriGia & " "

        Dim result = _dataProvider.ExcuteNonquery(query)
        Return result
    End Function
End Class
