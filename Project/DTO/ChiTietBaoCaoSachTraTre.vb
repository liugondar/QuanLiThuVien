Public Class ChiTietBaoCaoSachTraTre

#Region "-   Properties  -"
    Public Property MaChiTietBaoCaoSachTraTre() As String
    Public Property MaBaoCaoSachTraTre() As String
    Public Property MaChiTietPhieuMuonSach() As String
    Public Property SoNgayTraTre() As Integer
#End Region

#Region "-   Constructor  -"
    Public Sub New(maChiTietBaoCaoSachTraTre As String, maBaoCaoSachTraTre As String, maChiTietPhieuMuonSach As String, soNgayTraTre As Integer)
        Me.MaChiTietBaoCaoSachTraTre = maChiTietBaoCaoSachTraTre
        Me.MaBaoCaoSachTraTre = maBaoCaoSachTraTre
        Me.MaChiTietPhieuMuonSach = maChiTietPhieuMuonSach
        Me.SoNgayTraTre = soNgayTraTre
    End Sub

    Public Sub New()
    End Sub

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

       Public Sub New(maBaoCaoSachTraTre As String, thoiGian As Date)
        Me.MaBaoCaoSachTraTre = maBaoCaoSachTraTre
        Me.ThoiGian = thoiGian
    End Sub

    Public Sub New()
    End Sub
    Public Sub New(row As DataRow)
        Dim doesRowContainsCorrectFields As Boolean = row.Table.Columns.Contains("MaBaoCaoSachTraTre") And
         row.Table.Columns.Contains("ThoiGian")
        If doesRowContainsCorrectFields = False Then
            MaBaoCaoSachTraTre = 0
            ThoiGian = DateTime.Now
            Return
        End If
        MaBaoCaoSachTraTre = row("MaBaoCaoSachTraTre")
        DateTime.TryParse(row("ThoiGian").ToString(), ThoiGian)
    End Sub
#End Region
End Class
