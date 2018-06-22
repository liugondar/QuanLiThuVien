'Display thông tin sách 
Public Class CustomBookInfoDisplay

    Public Property TenSach() As String
    Public Property MaSach() As String
    Public Property TacGia() As String
    Public Property TinhTrang() As String
    Public Property NgayHetHan() As DateTime

    Public Sub New()
    End Sub

    Public Sub New(tenSach As String, maSach As String, tacGia As String, tinhTrang As Integer, ngayHetHan As Date)
        Me.TenSach = tenSach
        Me.MaSach = maSach
        Me.TacGia = tacGia
        Me.TinhTrang = tinhTrang
        Me.NgayHetHan = ngayHetHan
    End Sub
End Class
