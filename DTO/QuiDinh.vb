Public Class QuiDinh
    Public Sub New()
    End Sub
    Public Sub New(row As DataRow)
        Dim doesRowContainsCorrectFields As Boolean = row.Table.Columns.Contains("TuoiToiDa") And
            row.Table.Columns.Contains("TuoiToiThieu") And
            row.Table.Columns.Contains("ThoiHanToiDaTheDocGia")
        If doesRowContainsCorrectFields = False Then
            TuoiToiDa = 0
            TuoiToiThieu = 0
            ThoiHanToiDaTheDocGia = 0
            Return
        End If
        TuoiToiDa = Integer.Parse(row("TuoiToiDa"))
        TuoiToiThieu = Integer.Parse(row("TuoiToiThieu"))
        ThoiHanToiDaTheDocGia = Integer.Parse(row("ThoiHanToiDaTheDocGia"))
    End Sub

    Public Sub New(tuoiToiThieu As Integer, tuoiToiDa As Integer, thoiHanToiDaTheDocGia As Integer)
        Me.TuoiToiThieu = tuoiToiThieu
        Me.TuoiToiDa = tuoiToiDa
        Me.ThoiHanToiDaTheDocGia = thoiHanToiDaTheDocGia
    End Sub

    Public Property TuoiToiThieu As Integer
    Public Property TuoiToiDa As Integer
    Public Property ThoiHanToiDaTheDocGia As Integer


End Class
