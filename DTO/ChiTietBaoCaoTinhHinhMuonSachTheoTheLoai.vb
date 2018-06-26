Public Class ChiTietBaoCaoTinhHinhMuonSachTheoTheLoai

#Region "-   Properties   -"
    Public Property MaChiTietBaoCaoTinhHinhMuonSachTheoTheLoai As String
    Public Property MaBaoCaoTinhHinhMuonSachTheoTheLoai As String
    Public Property MaTheLoaiSach As String
    Public Property SoLuongMuon As Integer
    Public Property TiLe As Double
#End Region

#Region "-   Constructor   -"
    Public Sub New()
    End Sub
    Public Sub New(row As DataRow)
        Dim doesRowContainsCorrectFields = row.Table.Columns.Contains("MaBaoCaoTinhHinhMuonSachTheoTheLoai") And
            row.Table.Columns.Contains("MaChiTietBaoCaoTinhHinhMuonSachTheoTheLoai") And
        row.Table.Columns.Contains("MaTheLoaiSach") And
        row.Table.Columns.Contains("SoLuongMuon") And
        row.Table.Columns.Contains("TiLe")
        If doesRowContainsCorrectFields = False Then
            Return
        End If

        MaBaoCaoTinhHinhMuonSachTheoTheLoai = row("MaBaoCaoTinhHinhMuonSachTheoTheLoai").ToString()
        MaChiTietBaoCaoTinhHinhMuonSachTheoTheLoai = row("MaChiTietBaoCaoTinhHinhMuonSachTheoTheLoai").ToString()
        MaTheLoaiSach = row("maTheLoaiSach").ToString()
        Integer.TryParse(row("SoLuongMuon").ToString(), SoLuongMuon)
        Double.TryParse(row("TiLe").ToString(), TiLe)
    End Sub

    Public Sub New(maChiTietBaoCaoTinhHinhMuonSachTheoTheLoai As String, maBaoCaoTinhHinhMuonSachTheoTheLoai As String, maTheLoaiSach As String, soLuongMuon As Integer, tiLe As Double)
        Me.MaChiTietBaoCaoTinhHinhMuonSachTheoTheLoai = maChiTietBaoCaoTinhHinhMuonSachTheoTheLoai
        Me.MaBaoCaoTinhHinhMuonSachTheoTheLoai = maBaoCaoTinhHinhMuonSachTheoTheLoai
        Me.MaTheLoaiSach = maTheLoaiSach
        Me.SoLuongMuon = soLuongMuon
        Me.TiLe = tiLe
    End Sub

#End Region

End Class
