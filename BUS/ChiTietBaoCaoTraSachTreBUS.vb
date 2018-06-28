Imports DAO
Imports DTO
Imports Utility

Public Class ChiTietBaoCaoSachTraTreBus
#Region "-   Fields   -"
    Private _chiTietBaoCaoSachTraTreDaO As ChiTietBaoCaoSachTraTreDAO
    Private _phieuMuonSachBus As PhieuMuonSachBus
    Private _chiTietPhieuMuonSAchBus As ChiTietPhieuMuonSachBus
#End Region

#Region "-   Constructor   -"
    Public Sub New()
        _chiTietBaoCaoSachTraTreDaO = New ChiTietBaoCaoSachTraTreDAO()
        _phieuMuonSachBus = New PhieuMuonSachBus()
        _chiTietPhieuMuonSAchbus = New ChiTietPhieuMuonSachBus()
    End Sub

#End Region

#Region "-   Insert    -"

    Public Function InsertOne(chiTietBaoCaoSachTraTre As DTO.ChiTietBaoCaoSachTraTre) As Result
        If chiTietBaoCaoSachTraTre.ToString Is Nothing Then Return New Result(False, "Không thể nhập báo cáo không có thời gian!", "")
        Return _chiTietBaoCaoSachTraTreDaO.InsertOne(chiTietBaoCaoSachTraTre)
    End Function

    Friend Function InsertByMaBaoCaoAndDate(maBaoCAo As Integer, thoiGian As Date) As Object
        'get list phieu muon sach tra tre by date from database
        Dim listChiTietBaoCaoTraTre = New List(Of ChiTietBaoCaoSachTraTre)
        Dim getThongTinPhieuTraTreResult = _chiTietBaoCaoSachTraTreDaO.GetSoNgayTreAndMaChiTietPhieuMuonSachByDate(listChiTietBaoCaoTraTre, thoiGian)
        If Not getThongTinPhieuTraTreResult.FlagResult Then Return getThongTinPhieuTraTreResult

        ' if soNgayTraTre<0 remove item from the list
        listChiTietBaoCaoTraTre = listChiTietBaoCaoTraTre.Where(Function(x) x.SoNgayTraTre > 0).ToList()

        'insert 
        For Each chiTietBaocaoTraTre In listChiTietBaoCaoTraTre
            chiTietBaocaoTraTre.MaBaoCaoSachTraTre = maBaoCAo
            Dim insertResult = InsertOne(chiTietBaocaoTraTre)
            If Not insertResult.FlagResult Then
                'TODO: xu li khi insert 1 chi tiet bao cao khong thanh cohng
            End If
        Next
        Return New Result()
    End Function
#End Region

#Region "-   Retrieve data  -"
    Public Function GetTheLastID(ByRef maChiTietBaoCaoSacTraTre As String) As Result
        maChiTietBaoCaoSacTraTre = String.Empty
        Dim result = _chiTietBaoCaoSachTraTreDaO.GetTheLastID(maChiTietBaoCaoSacTraTre)
        If String.IsNullOrWhiteSpace(maChiTietBaoCaoSacTraTre) Then Return New Result(False, "Không thể lấy mã số cuối cùng!", "")
        Return result
    End Function

    Public Function SelectAllByMaBaoCaoSachTraTre(ByRef listChiTietBaoCao As List(Of ChiTietBaoCaoSachTraTre), maBaoCaoSachTraTre As String) As Result
        Return _chiTietBaoCaoSachTraTreDaO.SelectAllByMaBaoCaoSachTraTre(listChiTietBaoCao, maBaoCaoSachTraTre)
    End Function
#End Region
End Class
