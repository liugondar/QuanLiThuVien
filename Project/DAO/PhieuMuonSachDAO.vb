﻿Imports DTO
Imports Utility

Public Class PhieuMuonSachDAO
#Region "-   Fields    -"

    Private _dataProvider As DataProvider

#End Region

#Region "-   Constructor  -"

    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub

#End Region

#Region "-   Insert   -"

    Public Function InsertOne(phieuMuonSach As PhieuMuonSach) As Result
        Dim query = String.Empty
        Dim formatDate = DateHelper.Instance.GetFormatType()
        query &= "EXECUTE USP_ThemPhieuMuonSach "
        query &= "@MaPhieuMuonSach=" & phieuMuonSach.MaPhieuMuonSach & ", "
        query &= "@MaTheDocGia=" & phieuMuonSach.MaTheDocGia & ", "
        query &= "@NgayMuon='" & phieuMuonSach.NgayMuon.ToString(formatDate) & "' , "
        query &= "@HanTra='" & phieuMuonSach.HanTra.ToString(formatDate) & "', "
        query &= "@TongSoSachMuon=" & phieuMuonSach.TongSoSachMuon
        Return _dataProvider.ExecuteNonquery(query)
    End Function

#End Region

#Region "-   Update    -"
    Public Function UpdateCheckOutPhieuMuonByPhieuMuonSach(PhieuMuonSach As PhieuMuonSach, ngayTra As Date) As Result
        Dim formatDate = DateHelper.Instance.GetFormatType()
        Dim qr = "EXECUTE dbo.ReturnAllBookByPhieuMuonId " + PhieuMuonSach.MaPhieuMuonSach + ", '" + ngayTra.ToString(formatDate) + "'"

        Return _dataProvider.ExecuteNonquery(qr)
    End Function
#End Region

#Region "-   Retrieve data    -"

    Public Function GetTheLastPhieuMuonSachID(ByRef maPhieuDocSach As String) As Result
        maPhieuDocSach = 0
        Dim query = String.Empty
        query = String.Format("select top 1 [MaPhieuMuonSach] from PhieuMuonSach where DeleteFlag='N' order by [MaPhieuMuonSach] desc")

        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        If result.FlagResult = False Then Return New Result(False, "Không thể lấy mã phiếu mượn sách gần nhất!", "")
        Dim phieuMuonSach = New PhieuMuonSach()
        phieuMuonSach.MaPhieuMuonSach = 0
        For Each row In dataTable.Rows
            maPhieuDocSach = row("MaPhieuMuonSach").ToString()
        Next

        Return result
    End Function

    Public Function SelectAllByMaTheDocGia(ByRef listPhieuMuonSach As List(Of PhieuMuonSach), maTheDocGia As String) As Result
        Dim query = String.Empty
        query &= "select * "
        query &= "from PhieuMuonSach "
        query &= "Where MaTheDocGia=" & maTheDocGia
        query &= " And DeleteFlag='N'" & " "


        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        If result.FlagResult = False Then Return New Result(False, "Không thể lấy danh sach phiếu mượn sách đã có!", "")
        For Each row In dataTable.Rows
            Dim phieuMuonSach = New PhieuMuonSach()
            phieuMuonSach.MaPhieuMuonSach = 0
            phieuMuonSach = New PhieuMuonSach(row)
            listPhieuMuonSach.Add(phieuMuonSach)
        Next
        Return result
    End Function

    Public Function SelectAllPhieuMuonSachChuaTraByReaderId(ByRef listPhieuMuonSach As List(Of PhieuMuonSach), maTheDocGia As String) As Result
        Dim query = "EXECUTE dbo.USP_getPhieuMuonSachNotPayByDocGiaId " + maTheDocGia
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        If result.FlagResult = False Then Return New Result(False, "Không thể lấy danh sach phiếu mượn sách đã có!", "")
        For Each row In dataTable.Rows
            Dim phieuMuonSach = New PhieuMuonSach()
            phieuMuonSach.MaPhieuMuonSach = 0
            phieuMuonSach = New PhieuMuonSach(row)
            listPhieuMuonSach.Add(phieuMuonSach)
        Next
        Return result
    End Function

    Public Sub SelectAllSachChuaTraByPhieuMuonId(maPhieuMuonSach As String, ByRef listBook As List(Of CustomBookInfoDisplay))
        Dim qr = "EXECUTE dbo.USP_SelectRentInfo " + maPhieuMuonSach
        Dim dtb = New DataTable()
        Dim res = _dataProvider.ExecuteQuery(qr, dtb)
        For Each row In dtb.Rows
            Dim sachInfo = New CustomBookInfoDisplay(row)
            listBook.Add(sachInfo)
        Next
    End Sub

    Public Function SelectIdTheLastOne(ByRef maPhieuMuonSach As String) As Result
        Dim query As String = String.Empty
        query &= "select top 1 [MaPhieuMuonSach] "
        query &= "from PhieuMuonSach "
        query &= " Where DeleteFlag='N'" & " "
        query &= "ORDER BY [MaPhieuMuonSach] DESC "

        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            maPhieuMuonSach = row("MaPhieuMuonSach")
        Next
        Return result
    End Function

    Public Function GetPhieuMuonSachById(ByRef phieuMuonSach As PhieuMuonSach, maPhieuMuonSach As String) As Result
        Dim query = String.Format("
select * from PhieuMuonSach
where MaPhieuMuonSach={0} And DeleteFlag='N'", maPhieuMuonSach)
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            phieuMuonSach = New PhieuMuonSach(row)
        Next
        Return result
    End Function

    Public Function SelectAllPhieuMuonSachByDate(ByRef listPhieuMuonSach As List(Of PhieuMuonSach), thoiGian As DateTime) As Result
        'Get all phieu muon sach in time input
        Dim query = String.Format("
select * from PhieuMuonSach
where DeleteFlag='N' and TinhTrang='1'
And YEAR(NgayTra)='{0}' and month(NgayMuon)='{1}'
", thoiGian.ToString("yyyy"), thoiGian.ToString("MM"))
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            Dim PhieuMuonSach = New PhieuMuonSach(row)
            listPhieuMuonSach.Add(PhieuMuonSach)
        Next
        Return result
    End Function

    Public Sub SelectRentSachByDocGiaId(docGiaId As String, ByRef listSach As List(Of CustomBookInfoDisplay))
        Dim qr = "EXECUTE dbo.SelectRentSachByDocGiaId " + docGiaId

        Dim dtb = New DataTable()
        Dim res = _dataProvider.ExecuteQuery(qr, dtb)
        For Each row In dtb.Rows
            Dim sachInfo = New CustomBookInfoDisplay(row)
            listSach.Add(sachInfo)
        Next

    End Sub
#End Region
End Class
