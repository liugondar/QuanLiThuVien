Public Class QuiDinh
    Public Sub New()
    End Sub
    Public Sub New(row As DataRow)
        Dim doesRowContainsCorrectFields As Boolean = row.Table.Columns.Contains("TuoiToiDa") And
            row.Table.Columns.Contains("TuoiToiThieu") And
            row.Table.Columns.Contains("ThoiHanToiDaTheDocGia") And
            row.Table.Columns.Contains("ThoiHanNhanSach")
        If doesRowContainsCorrectFields = False Then
            TuoiToiDa = 0
            TuoiToiThieu = 0
            ThoiHanToiDaTheDocGia = 0
            ThoiHanNhanSach = 0
            Return
        End If
        Integer.TryParse(row("TuoiToiDa"), TuoiToiDa)
        Integer.TryParse(row("TuoiToiThieu"), TuoiToiThieu)
        Integer.TryParse(row("ThoiHanToiDaTheDocGia"), ThoiHanToiDaTheDocGia)
        Integer.TryParse(row("ThoiHanNhanSach"), ThoiHanNhanSach)

    End Sub

    Public Sub New(tuoiToiThieu As Integer, tuoiToiDa As Integer, thoiHanToiDaTheDocGia As Integer, ThoiHanNhanSach As Integer)
        Me.TuoiToiThieu = tuoiToiThieu
        Me.TuoiToiDa = tuoiToiDa
        Me.ThoiHanToiDaTheDocGia = thoiHanToiDaTheDocGia
        Me.ThoiHanNhanSach = ThoiHanNhanSach
    End Sub

    Public Property TuoiToiThieu As Integer
    Public Property TuoiToiDa As Integer
    Public Property ThoiHanToiDaTheDocGia As Integer
    Public Property ThoiHanNhanSach As Integer

End Class
