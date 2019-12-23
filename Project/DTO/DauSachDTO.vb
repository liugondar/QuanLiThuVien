Imports System.Windows.Forms
Imports Utility

Public Class DauSachDTO
    Public Sub New()
    End Sub

    Public Sub New(row As DataRow)
        Dim doesRowContainsCorrectFields = row.Table.Columns.Contains("MaDauSach") And
            row.Table.Columns.Contains("MaTheLoaiSach") And
            row.Table.Columns.Contains("MaTacGia") And
            row.Table.Columns.Contains("TenSach") And
            row.Table.Columns.Contains("TenNhaXuatBan") And
            row.Table.Columns.Contains("NgayNhap") And
            row.Table.Columns.Contains("NgayXuatBan") And
            row.Table.Columns.Contains("TriGia")
        If doesRowContainsCorrectFields = False Then
            Return
        End If
        Integer.TryParse(row("MaDauSach").ToString(), MaDauSach)
        Integer.TryParse(row("MaTheLoaiSach").ToString(), MaTheLoaiSach)
        Integer.TryParse(row("MaTacGia").ToString(), MaTacGia)
        TenSach = row("TenSach").ToString()
        TenNhaXuatBan = row("TenNhaXuatBan").ToString()
        DateTime.TryParse(row("NgayXuatBan").ToString(), NgayXuatBan)
        DateTime.TryParse(row("NgayNhap").ToString(), NgayNhap)
        Integer.TryParse(row("TriGia").ToString(), TriGia)
    End Sub
    Public Sub New(maDauSach As Integer, tenSach As String, maLoaiSach As Integer, maTacGia As Integer, tenNhaXuatBan As String, namXuatBan As Date, ngayNhap As Date, triGia As Integer)
        Me.MaDauSach = maDauSach
        Me.TenSach = tenSach
        Me.MaTheLoaiSach = maLoaiSach
        Me.MaTacGia = maTacGia
        Me.TenNhaXuatBan = tenNhaXuatBan
        Me.NgayXuatBan = namXuatBan
        Me.NgayNhap = ngayNhap
        Me.TriGia = triGia
    End Sub

    Public Property MaDauSach() As String
    Public Property TenSach() As String
    Public Property MaTheLoaiSach() As Integer
    Public Property MaTacGia() As Integer
    Public Property TenNhaXuatBan() As String
    Public Property NgayXuatBan() As DateTime
    Public Property NgayNhap() As DateTime
    Public Property TriGia() As Integer


    Public Function ValidateTenSachAndTenNhaXuatBan() As Result
        If String.IsNullOrWhiteSpace(TenSach).ToString() Then Return New Result(False, "Tên sách không đúng định dạng!", "")
        If String.IsNullOrWhiteSpace(TenNhaXuatBan).ToString() Then Return New Result(False, "Tên nhà xuất bản không đúng định dạng!", "")
        Return New Result()
    End Function
End Class
