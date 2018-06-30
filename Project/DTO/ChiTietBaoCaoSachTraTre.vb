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

    Public Sub New(row As DataRow)
        Dim doesRowContainsCorrectFields As Boolean = row.Table.Columns.Contains("MaBaoCaoSachTraTre") And
         row.Table.Columns.Contains("SoNgayTre") And
          row.Table.Columns.Contains("MaChiTietBaoCaoSachTraTre") And
          row.Table.Columns.Contains("MaChiTietPhieuMuonSach")
        If doesRowContainsCorrectFields = False Then
            MaBaoCaoSachTraTre = 0
            MaChiTietBaoCaoSachTraTre = 0
            MaChiTietPhieuMuonSach = 0
            SoNgayTraTre = 0
            Return
        End If
        MaBaoCaoSachTraTre = row("MaBaoCaoSachTraTre").ToString()
        MaBaoCaoSachTraTre = row("MaChiTietBaoCaoSachTraTre").ToString()
        MaChiTietPhieuMuonSach = row("MaChiTietPhieuMuonSach").ToString()
        Integer.TryParse(row("SoNgayTre").ToString(), SoNgayTraTre)
    End Sub
#End Region
End Class
