'Display thông tin sách 
Public Class CustomBookInfoDisplay

    Public Property TenSach() As String
    Public Property MaDauSach() As String
    Public Property MaCuonSach() As String
    Public Property TacGia() As String
    Public Property TinhTrang() As String
    Public Property NgayHetHan() As Date
    Public Property NgayMuon() As Date

    Public Sub New()
    End Sub
    Public Sub New(row As DataRow)
        Dim doesRowContainsCorrectFields = row.Table.Columns.Contains("MaDauSach") And
          row.Table.Columns.Contains("MaSach") And
          row.Table.Columns.Contains("TenSach") And
          row.Table.Columns.Contains("TenNhaXuatBan") And
          row.Table.Columns.Contains("TinhTrang") And
          row.Table.Columns.Contains("SoNgayMuonToiDa") And
          row.Table.Columns.Contains("TenTacGia") And
          row.Table.Columns.Contains("NgayMuon")
        If doesRowContainsCorrectFields = False Then
            Return
        End If

        MaCuonSach = row("MaSach")
        MaDauSach = row("MaDauSach")
        TenSach = row("TenSach")
        TacGia = row("TenTacGia")
        TinhTrang = row("TinhTrang")
        Dim snmtd As Integer
        Integer.TryParse(row("SoNgayMuonToiDa"), snmtd)
        Date.TryParse(row("NgayMuon"), ngaymuon)
        NgayHetHan = NgayMuon.AddDays(snmtd)

    End Sub

    Public Sub New(tenSach As String, maSach As String, maCuonSach As String, tacGia As String, tinhTrang As Integer, ngayHetHan As Date)
        Me.TenSach = tenSach
        Me.MaDauSach = maSach
        Me.TacGia = tacGia
        Me.TinhTrang = tinhTrang
        Me.NgayHetHan = ngayHetHan
        Me.MaCuonSach = maCuonSach
    End Sub
End Class
