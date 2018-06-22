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

    Public Function selectAllByMaphieumuonsach(listChitietphieumuonsach As List(Of ChiTietPhieuMuonSach)) As Result
        Throw New NotImplementedException()
    End Function
End Class
