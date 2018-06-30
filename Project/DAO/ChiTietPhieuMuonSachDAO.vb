Imports DTO
Imports Utility

Public Class ChiTietPhieuMuonSachDAO
#Region "-   Fields   -"
    Private _dataProvider As DataProvider
#End Region

#Region "-   Constructor    -"

    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub

#End Region

#Region "-   Insert    -"

    Public Function InsertOne(chiTietPhieuMuonSach As ChiTietPhieuMuonSach) As Result
        Dim query = String.Empty
        query = String.Format("EXECUTE USP_ThemChiTietPhieuMuonSach @MaPhieuMuonSach={0} ,@MaSach={1}",
            chiTietPhieuMuonSach.MaPhieuMuonSach, chiTietPhieuMuonSach.MaSach)
        Return _dataProvider.ExcuteNonquery(query)
    End Function

#End Region

#Region "-   Delete   -"
    Public Function DeleteById(maChiPhieuMuonSach As String) As Result
        Dim query = String.Format("
delete from ChiTietPhieuMuonSach
where MaChiTietPhieuMuonSach={0}", maChiPhieuMuonSach)
        Return _dataProvider.ExcuteNonquery(query)
    End Function
#End Region

#Region "-   Retrieve data    -"

    Public Function selectAllByMaphieumuonsach(listChitietphieumuonsach As List(Of ChiTietPhieuMuonSach), maPhieuMuonSach As String) As Result
        Dim query = String.Empty
        query = String.Format("select * from chiTietPhieuMuonSach where MaPhieuMuonSach={0} and DeleteFlag='N'",
                                maPhieuMuonSach)
        Dim DataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, DataTable)
        For Each row In DataTable.Rows
            Dim chiTietPhieuMuonSach = New ChiTietPhieuMuonSach(row)
            listChitietphieumuonsach.Add(chiTietPhieuMuonSach)
        Next
        Return result
    End Function

    Public Function GetTheLastID(ByRef maChiTietPhieuMuonSach As String) As Result
        Dim query = String.Format("select top 1 [MaChiTietPhieuMuonSach]
from ChiTietPhieuMuonSach
ORDER by [MaChiTietPhieuMuonSach] desc")
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            maChiTietPhieuMuonSach = row("MaChiTietPhieuMuonSach")
        Next
        Return result
    End Function

    Public Function GetByID(ByRef chiTietPhieuMuonSach As ChiTietPhieuMuonSach, id As String) As Result
        Dim query = String.Format("Select *
    from ChiTietPhieuMuonSach
    where MaChiTietPhieuMuonSach={0}", id)
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            chiTietPhieuMuonSach = New ChiTietPhieuMuonSach(row)
        Next
        Return result
    End Function

#End Region

End Class
