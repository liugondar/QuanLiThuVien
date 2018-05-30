Public Class LoaiDocGia
    Public Property MaLoaiDocGia As Integer
    Public Property TenLoaiDocGia As String
    Public Sub New()
    End Sub
    Public Sub New(row As DataRow)
        Dim doesRowContainsCorrectFields As Boolean = row.Table.Columns.Contains("MaLoaiDocGia") And
            row.Table.Columns.Contains("TenLoaiDocGia")
        If doesRowContainsCorrectFields = False Then
            MaLoaiDocGia = 0
            TenLoaiDocGia = ""
            Return
        End If
        MaLoaiDocGia = Integer.Parse(row("MaLoaiDocGia"))
        TenLoaiDocGia = (row("TenLoaiDocGia")).ToString()
    End Sub

    Public Sub New(LoaiDocGiaId As Integer, TenLoaiDocGia As String)
        Me.MaLoaiDocGia = LoaiDocGiaId
        Me.TenLoaiDocGia = TenLoaiDocGia
    End Sub
End Class
