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
        query &= "EXECUTE USP_ThemPhieuMuonSach "
        query &= "@MaPhieuMuonSach=" & phieuMuonSach.MaPhieuMuonSach & ", "
        query &= "@MaTheDocGia=" & phieuMuonSach.MaTheDocGia & ", "
        query &= "@NgayMuon='" & phieuMuonSach.NgayMuon & "' , "
        query &= "@HanTra='" & phieuMuonSach.HanTra & "', "
        query &= "@TongSoSachMuon=" & phieuMuonSach.TongSoSachMuon
        Return _dataProvider.ExcuteNonquery(query)
    End Function

#End Region

#Region "-   Update    -"
    Public Function UpdateCheckOutPhieuMuonByPhieuMuonSach(PhieuMuonSach As PhieuMuonSach) As Result
        'TODO: update ngay tra
        Dim query = String.Format("
update PhieuMuonSach    
set TinhTrang=1, NgayTra='{0}'
where MaPhieuMuonSach={1}
 ", PhieuMuonSach.NgayTra.ToString("MM/dd/yyyy"), PhieuMuonSach.MaPhieuMuonSach)
        Return _dataProvider.ExcuteNonquery(query)
    End Function
#End Region

#Region "-   Retrieve data    -"

    Public Function GetTheLastPhieuMuonSachID(ByRef maPhieuDocSach As String) As Result
        maPhieuDocSach = 0
        Dim query = String.Empty
        query = String.Format("select top 1 [MaPhieuMuonSach] from PhieuMuonSach where DeleteFlag='N' order by [MaPhieuMuonSach] desc")

        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
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

    Public Function SelectAllPhieuMuonSachChuaTraByReaderId(ByRef listPhieuMuonSach As List(Of PhieuMuonSach), maTheDocGia As String) As Result
        Dim query = String.Empty
        query = String.Format("Select * from PhieuMuonSach
WHERE [MaTheDocGia]={0} AND [TinhTrang]=0
and DeleteFlag='N'", maTheDocGia)

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
        query &= " Where DeleteFlag='N'" & " "
        query &= "ORDER BY [MaPhieuMuonSach] DESC "

        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
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
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
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
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            Dim PhieuMuonSach = New PhieuMuonSach(row)
            listPhieuMuonSach.Add(PhieuMuonSach)
        Next
        Return result
    End Function
#End Region
End Class