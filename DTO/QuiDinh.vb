Public Class QuiDinh
    Private v1 As Integer
    Private v2 As Integer
    Private v3 As Integer
    Private v4 As Integer
    Private v5 As Integer
    Private v6 As Integer
    Public Property SoSachMuonToiDa() As Integer
    Public Property TuoiToiThieu() As Integer
    Public Property TuoiToiDa() As Integer
    Public Property ThoiHanToiDaTheDocGia() As Integer
    Public Property ThoiHanNhanSach() As Integer
    Public Property SoNgayMuonSachToiDa() As Integer
    Public Sub New()
    End Sub
    Public Sub New(row As DataRow)
        Dim doesRowContainsCorrectFields As Boolean = row.Table.Columns.Contains("TuoiToiDa") And
            row.Table.Columns.Contains("TuoiToiThieu") And
            row.Table.Columns.Contains("ThoiHanToiDaTheDocGia") And
            row.Table.Columns.Contains("ThoiHanNhanSach") And
            row.Table.Columns.Contains("SoNgayMuonToiDa") And
            row.Table.Columns.Contains("SoSachMuonToiDa")
        If doesRowContainsCorrectFields = False Then
            TuoiToiDa = 0
            TuoiToiThieu = 0
            ThoiHanToiDaTheDocGia = 0
            ThoiHanNhanSach = 0
            SoNgayMuonSachToiDa = 0
            Return
        End If
        Integer.TryParse(row("TuoiToiDa"), TuoiToiDa)
        Integer.TryParse(row("TuoiToiThieu"), TuoiToiThieu)
        Integer.TryParse(row("ThoiHanToiDaTheDocGia"), ThoiHanToiDaTheDocGia)
        Integer.TryParse(row("ThoiHanNhanSach"), ThoiHanNhanSach)
        Integer.TryParse(row("SoNgayMuonToiDa"), SoNgayMuonSachToiDa)
        Integer.TryParse(row("SoSachMuonToiDa"), SoSachMuonToiDa)

    End Sub

    Public Sub New(tuoiToiThieu As Integer, tuoiToiDa As Integer, thoiHanToiDaTheDocGia As Integer, ThoiHanNhanSach As Integer)
        Me.TuoiToiThieu = tuoiToiThieu
        Me.TuoiToiDa = tuoiToiDa
        Me.ThoiHanToiDaTheDocGia = thoiHanToiDaTheDocGia
        Me.ThoiHanNhanSach = ThoiHanNhanSach
    End Sub

    Public Sub New(tuoiToiThieu As Integer, tuoiToiDa As Integer, thoiHanToiDaTheDocGia As Integer, ThoiHanNhanSach As Integer, SoNgayMuonSachToiDa As Integer, SoSachMuonToiDa As Integer)
        Me.TuoiToiThieu = tuoiToiThieu
        Me.TuoiToiDa = tuoiToiDa
        Me.ThoiHanToiDaTheDocGia = thoiHanToiDaTheDocGia
        Me.ThoiHanNhanSach = ThoiHanNhanSach
        Me.SoNgayMuonSachToiDa = SoNgayMuonSachToiDa
        Me.SoSachMuonToiDa = SoSachMuonToiDa
    End Sub
End Class
