Imports DTO
Imports Utility

Public Class PhieuMuonSachDAO
    Private _dataProvider As DataProvider

    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub


    Public Function InsertOne(phieuMuonSach As PhieuMuonSach) As Result
        Dim query = String.Empty
        query &= "EXECUTE USP_ThemPhieuMuonSach "
        query &= "@MaPhieuMuonSach=" & phieuMuonSach.MaPhieuMuonSach & ", "
        query &= "@MaTheDocGia=" & phieuMuonSach.MaTheDocGia & ", "
        query &= "@NgayMuon='" & phieuMuonSach.NgayMuon & "' , "
        query &= "@HanTra='" & phieuMuonSach.HanTra & "', "
        query &= "@TongSoSachMuon=" & phieuMuonSach.TongSoSachMuon
        Return _dataProvider.ExcuteNonquery(query)
    End Function

    Public Function LayMaSoPhieuMuonSachCuoiCung(ByRef maPhieuDocSach As Integer) As Result
        Dim query = String.Empty
        query &= "select top 1 * "
        query &= "from PhieuMuonSach "
        query &= "ORDER BY [MaPhieuMuonSach] DESC "

        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        If result.FlagResult = False Then Return New Result(False, "Không thể lấy mã phiếu mượn sách gần nhất!", "")
        Dim phieuMuonSach = New PhieuMuonSach()
        phieuMuonSach.MaPhieuMuonSach = 0
        For Each row In dataTable.Rows
            phieuMuonSach = New PhieuMuonSach(row)
        Next

        maPhieuDocSach = phieuMuonSach.MaPhieuMuonSach
        Return result
    End Function
End Class
