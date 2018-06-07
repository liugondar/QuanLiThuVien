Imports DTO

Public Class PhieuMuonSach

    Public Property MaPhieuMuonSach() As Integer
    Public Property MaTheDocGia() As Integer
    Public Property NgayMuon() As DateTime
    Public Property NgayTra As DateTime
    Public Property HanTra() As DateTime
    Public Property TongSoSachMuon() As Integer
    Public Property TinhTrang() As Integer
    Enum CacTinhTrang
        Vailable
        Unvailable
    End Enum
    Public Sub New()
    End Sub

    Public Sub New(row As DataRow)
        Dim doesRowContainsCorrectFields = row.Table.Columns.Contains("MaPhieuMuonSach") And
         row.Table.Columns.Contains("MaTheDocGia") And
         row.Table.Columns.Contains("NgayMuon") And
         row.Table.Columns.Contains("HanTra") And
         row.Table.Columns.Contains("TinhTrang") And
         row.Table.Columns.Contains("NgayTra")

        If doesRowContainsCorrectFields = False Then
            MaPhieuMuonSach = 0
            MaTheDocGia = 0
            NgayMuon = DateTime.Now
            NgayTra = DateTime.Now
            HanTra = Date.Now
            TinhTrang = 0
            Return
        End If

        Integer.TryParse(row("MaPhieuMuonSach").ToString(), MaPhieuMuonSach)
        Integer.TryParse(row("MaTheDocGia").ToString(), MaTheDocGia)
        DateTime.TryParse(row("NgayMuon").ToString(), NgayMuon)
        DateTime.TryParse(row("NgayTra").ToString(), NgayTra)
        DateTime.TryParse(row("HanTra").ToString(), HanTra)
        Integer.TryParse(row("TinhTrang").ToString(), TinhTrang)
    End Sub

    Public Sub New(maPhieuMuonSach As Integer, maTheDocGia As Integer, ngayMuon As Date, ngayTra As Date, hanTra As Date, tongSoSachMuon As Integer, tinhTrang As Integer)
        Me.MaPhieuMuonSach = maPhieuMuonSach
        Me.MaTheDocGia = maTheDocGia
        Me.NgayMuon = ngayMuon
        Me.NgayTra = ngayTra
        Me.HanTra = hanTra
        Me.TongSoSachMuon = tongSoSachMuon
        Me.TinhTrang = tinhTrang
    End Sub
End Class

