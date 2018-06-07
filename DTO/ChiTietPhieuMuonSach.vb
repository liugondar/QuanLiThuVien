Public Class ChiTietPhieuMuonSach
    Public Property MaChiTietPhieuMuonSach() As Integer
    Public Property MaPhieuMuonSach() As Integer
    Public Property MaSach() As Integer
    Public Sub New(maChiTietPhieuMuonSach As Integer, maPhieuMuonSach As Integer, maSach As Integer)
        Me.MaChiTietPhieuMuonSach = maChiTietPhieuMuonSach
        Me.MaPhieuMuonSach = maPhieuMuonSach
        Me.MaSach = maSach
    End Sub
    Public Sub New()
    End Sub
End Class
