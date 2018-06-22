Imports DAO
Imports DTO
Imports Utility

Public Class ChiTietPhieuMuonSachBus
    Private _chiTietPhieuMuonSachDAO As ChiTietPhieuMuonSachDAO
    Public Sub New()
        _chiTietPhieuMuonSachDAO = New ChiTietPhieuMuonSachDAO()
    End Sub
    Public Function InsertOne(chiTietPhieuMuonSach As ChiTietPhieuMuonSach) As Result
        Return _chiTietPhieuMuonSachDAO.InsertOne(chiTietPhieuMuonSach)
    End Function

    Public Function selectAllByMaphieumuonsach(ByRef listChitietphieumuonsach As List(Of ChiTietPhieuMuonSach),
                                               maPhieuMuonSach As String) As Result
        Return _chiTietPhieuMuonSachDAO.selectAllByMaphieumuonsach(listChitietphieumuonsach, maPhieuMuonSach)
    End Function
End Class
