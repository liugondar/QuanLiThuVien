Imports DTO
Imports Utility

Public Class ChiTietPhieuMuonSachDAO
    Private _dataProvider As DataProvider
    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub
    Public Function InsertOne(chiTietPhieuMuonSach As ChiTietPhieuMuonSach) As Result
        Dim query = String.Empty
        query = String.Format("insert into ChiTietPhieuMuonSach
            (MaPhieuMuonSach,MaSach) VALUES({0},{1})",
            chiTietPhieuMuonSach.MaPhieuMuonSach, chiTietPhieuMuonSach.MaSach)
        Return _dataProvider.ExcuteNonquery(query)
    End Function

    Public Function selectAllByMaphieumuonsach(listChitietphieumuonsach As List(Of ChiTietPhieuMuonSach), maPhieuMuonSach As String) As Result
        Dim query = String.Empty
        query = String.Format("select * from chiTietPhieuMuonSach where MaPhieuMuonSach={0}",
                                maPhieuMuonSach)
        Dim DataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, DataTable)
        For Each row In DataTable.Rows
            Dim chiTietPhieuMuonSach = New ChiTietPhieuMuonSach(row)
            listChitietphieumuonsach.Add(chiTietPhieuMuonSach)
        Next
        Return result
    End Function
End Class
