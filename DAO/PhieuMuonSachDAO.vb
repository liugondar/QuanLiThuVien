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

    Public Function SelectAllByMaTheDocGia(ByRef listPhieuMuonSach As List(Of PhieuMuonSach), maTheDocGia As String) As Result
        Dim query = String.Empty
        query &= "select * "
        query &= "from PhieuMuonSach "
        query &= "Where MaTheDocGia=" & maTheDocGia

        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        If result.FlagResult = False Then Return New Result(False, "Không thể lấy danh sach phiếu mượn sách đã có!", "")
        For Each row In dataTable.Rows
            Dim phieuMuonSach = New PhieuMuonSach()
            phieuMuonSach.MaPhieuMuonSach = 0
            phieuMuonSach = New PhieuMuonSach(row)
            listPhieuMuonSach.Add(phieuMuonSach)
        Next
        Return result
    End Function

    Public Function SelectIdTheLastOne(ByRef maPhieuMuonSach As String) As Result
        Dim query As String = String.Empty
        query &= "select top 1 [MaPhieuMuonSach] "
        query &= "from PhieuMuonSach "
        query &= "ORDER BY [MaTheDocGia] DESC "
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            maPhieuMuonSach = row("MaPhieuMuonSach")
        Next
        Return result
    End Function
End Class
