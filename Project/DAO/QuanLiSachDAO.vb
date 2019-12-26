Imports Utility
Imports DTO

Public Class QuanLiSachDAO

    Private Shared oInstance As QuanLiSachDAO = New QuanLiSachDAO

    Private Sub New()
    End Sub

    Public Shared ReadOnly Property Instance As QuanLiSachDAO
        Get
            Return oInstance
        End Get
    End Property

    Public Function SearchSachByString(query As String, ByRef listDauSach As List(Of DauSachDTO)) As Result
        Dim rs = New Result()
        Dim strarr() As String
        strarr = query.Split(" "c)

        For Each s As String In strarr
            Dim qr = String.Format("
SELECT tg.MaTacGia, tg.TenTacGia, ds.MaDauSach, ds.MaTheLoaiSach, ds.NgayXuatBan, ds.SoLuong, ds.TenNhaXuatBan, ds.TenSach, ds.TriGia
FROM DauSach ds, TacGia tg
WHERE (TenSach LIKE  '%{0}%'
or TenTacGia LIKE '%{0}%')
and tg.MaTacGia= ds.MaTacGia
", s)
            Dim tb = New DataTable()
            rs = DataProvider.Instance.ExecuteQuery(qr, tb)
            For Each r In tb.Rows
                Dim ds = New DauSachDTO(r)
                listDauSach.Add(ds)
            Next
        Next

        Return rs
    End Function
End Class