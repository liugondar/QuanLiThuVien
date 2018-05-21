Public Class DocGia
    Public Property TenDocGia As String
    Public Property Email As String
    Public Property DiaChi As String
    Public Property TenNguoiTao As String
    Public Property NgaySinh As Date
    Public Property NgayTao As Date
    Public Property NgayHetHan As Date
    Public Property LoaiDocGiaId As Integer

    Public Sub New()
    End Sub

    Public Sub New(TenDocGia As String, Email As String, DiaChi As String, TenNguoiTao As String, NgaySinh As Date, NgayTao As Date, NgayHetHan As Date,LoaiDocGiaId As Integer)
        Me.TenDocGia = TenDocGia
        Me.Email = Email
        Me.DiaChi = DiaChi
        Me.TenNguoiTao = TenNguoiTao
        Me.NgaySinh = NgaySinh
        Me.NgayTao = NgayTao
        Me.LoaiDocGiaId = LoaiDocGiaId
        Me.NgayHetHan=NgayHetHan
    End Sub
End Class
