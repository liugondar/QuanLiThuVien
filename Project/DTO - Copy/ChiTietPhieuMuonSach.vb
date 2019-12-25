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

    Public Sub New(row As DataRow)
        Dim doesRowContainsCorrectFields = row.Table.Columns.Contains("MaChiTietPhieuMuonSach") And
          row.Table.Columns.Contains("MaPhieuMuonSach") And
        row.Table.Columns.Contains("MaSach")
        If doesRowContainsCorrectFields = False Then
            Return
        End If

        MaPhieuMuonSach = row("MaPhieuMuonSach").ToString()
        MaChiTietPhieuMuonSach = row("MaChiTietPhieuMuonSach").ToString()
        MaSach = row("MaSach").ToString()
    End Sub
End Class
