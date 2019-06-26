Public Class ChiTietBaoCaoSachTraTreDisplay
    Public Sub New()
    End Sub

    Public Sub New(tenSach As String, ngayMuon As String, soNgayTraTre As Integer)
        Me.TenSach = tenSach
        Me.NgayMuon = ngayMuon
        Me.SoNgayTraTre = soNgayTraTre
    End Sub

    Public Property TenSach As String
    Public Property NgayMuon As String
    Public Property SoNgayTraTre As Integer

End Class
