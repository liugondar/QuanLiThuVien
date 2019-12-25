Public Class BaoCaoTraTreByMonth
    Public Property MaPhieuMuonSach() As String
    Public Property MaTheDocGia() As String
    Public Property TenDocGia() As String
    Public Property NgayMuon() As Date
    Public Property NgayTra() As Date
    Public Property NgayTraTre() As Integer
    Public Property TenSach() As String
    Public Property MaSach() As String
    Public Property MaDauSach() As String

    Public Sub New(row As DataRow)
        Dim doesRowContainsCorrectFields = row.Table.Columns.Contains("MaPhieuMuonSach") And
           row.Table.Columns.Contains("MaTheDocGia") And
           row.Table.Columns.Contains("TenDocGia") And
           row.Table.Columns.Contains("NgayMuon") And
           row.Table.Columns.Contains("NgayTra") And
           row.Table.Columns.Contains("NgayTraTre") And
           row.Table.Columns.Contains("TenSach") And
           row.Table.Columns.Contains("MaSach") And
           row.Table.Columns.Contains("MaDauSach")
        If doesRowContainsCorrectFields = False Then
            Return
        End If

        MaPhieuMuonSach = row("MaPhieuMuonSach")
        MaTheDocGia = row("MaTheDocGia")
        TenDocGia = row("TenDocGia")
        TenSach = row("TenSach")
        MaSach = row("MaSach")
        MaDauSach = row("MaDauSach")

        Integer.TryParse(row("NgayTraTre"), NgayTraTre)
        Date.TryParse(row("NgayMuon"), NgayMuon)
        Date.TryParse(row("NgayTra"), NgayTra)

    End Sub
End Class
