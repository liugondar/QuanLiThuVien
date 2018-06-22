Public Class ChiTietPhieuMuonSach
    Public Property MaChiTietPhieuMuonSach() As String
    Public Property MaPhieuMuonSach() As String
    Public Property MaSach() As String
    Public Sub New(maChiTietPhieuMuonSach As Integer, maPhieuMuonSach As Integer, maSach As Integer)
        Me.MaChiTietPhieuMuonSach = maChiTietPhieuMuonSach
        Me.MaPhieuMuonSach = maPhieuMuonSach
        Me.MaSach = maSach
    End Sub
    Public Sub New()
    End Sub
End Class
