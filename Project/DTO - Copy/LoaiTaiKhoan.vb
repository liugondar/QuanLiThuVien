Public Class LoaiTaiKhoan

    Public Property MaLoaiTaiKhoan As String
    Public Property TenLoaiTaiKhoan As String
    Public Sub New()
    End Sub

    Public Sub New(maLoaiTaiKhoan As String, tenLoaiTaiKhoan As String)
        Me.MaLoaiTaiKhoan = maLoaiTaiKhoan
        Me.TenLoaiTaiKhoan = tenLoaiTaiKhoan
    End Sub
End Class
