Imports DAO
Imports DTO
Imports Utility

Public Class ChiTietPhieuMuonSachBus
#Region "-   Fields   -"
    Private _chiTietPhieuMuonSachDAO As ChiTietPhieuMuonSachDAO
    Private _sachBus As SachBus
#End Region

#Region "-   Constructor   -"
    Public Sub New()
        _chiTietPhieuMuonSachDAO = New ChiTietPhieuMuonSachDAO()
        _sachBus = New SachBus()
    End Sub
#End Region

#Region "-   Insert   -"
    Public Function InsertOne(chiTietPhieuMuonSach As ChiTietPhieuMuonSach) As Result
        Dim insertResult = _chiTietPhieuMuonSachDAO.InsertOne(chiTietPhieuMuonSach)
        If insertResult.FlagResult = False Then Return insertResult

        'Dim updateSachInfoResult = _sachBus.SetStatusSachToUnavailableByID(chiTietPhieuMuonSach.MaSach)
        'If updateSachInfoResult.FlagResult = False Then
        '    Dim lastID = String.Empty
        '    _chiTietPhieuMuonSachDAO.GetTheLastID(lastID)
        '    DeleteById(lastID)
        '    'Return updateSachInfoResult
        'End If
        Return New Result()
    End Function
#End Region

#Region "-   Delete   -"
    Public Function DeleteById(maPhieuMuonSach As String) As Result
        Return _chiTietPhieuMuonSachDAO.DeleteById(maPhieuMuonSach)
    End Function
#End Region

#Region "-   Retrieve data   -"
    Public Function selectAllByMaphieumuonsach(ByRef listChitietphieumuonsach As List(Of ChiTietPhieuMuonSach),
                                               maPhieuMuonSach As String) As Result
        Return _chiTietPhieuMuonSachDAO.selectAllByMaphieumuonsach(listChitietphieumuonsach, maPhieuMuonSach)
    End Function

    Public Function GetByID(ByRef chiTietPhieuMuonSach As ChiTietPhieuMuonSach, id As String) As Result
        Return _chiTietPhieuMuonSachDAO.GetByID(chiTietPhieuMuonSach, id)
    End Function
    Public Function selectALL(ByRef list As List(Of ChiTietPhieuMuonSach)) As Result
        Return _chiTietPhieuMuonSachDAO.SelectAll(list)
    End Function


#End Region
End Class
