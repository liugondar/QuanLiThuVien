Imports DAO
Imports DTO
Imports Utility

Public Class BaoCaoSachTraTreBus
#Region "-   Fields   -"
    Private _baoCaoSachTraTreDaO As BaoCaoSachTraTreDAO
    Private _chiTietBaoCaoBus As ChiTietBaoCaoSachTraTreBus
#End Region

#Region "-   Constructor   -"
    Public Sub New()
        _baoCaoSachTraTreDaO = New BaoCaoSachTraTreDAO()
        _chiTietBaoCaoBus = New ChiTietBaoCaoSachTraTreBus()
    End Sub

#End Region

#Region "-   Insert    -"

    Public Function InsertOne(baoCaoSachTraTre As DTO.BaoCaoSachTraTre) As Result
        If baoCaoSachTraTre Is Nothing Then Return New Result(False, "Không thể nhập báo cáo không có thời gian!", "")
        Return _baoCaoSachTraTreDaO.InsertOne(baoCaoSachTraTre)
    End Function

    Public Function InsertByThoiGian(thoiGian As DateTime) As Result
        'Insert baoCaoTinhHinhMuonSachTheoTheLoai 
        Dim insertBaoCaoResult = InsertBaoCaoTraTre(thoiGian)
        If insertBaoCaoResult.FlagResult = False Then Return insertBaoCaoResult

        Dim maBaoCAo = 0
        Dim getBaoCaoIdResult = _baoCaoSachTraTreDaO.GetTheLastID(maBaoCAo)
        If getBaoCaoIdResult.FlagResult = False Then
            Return New Result(False, "", "")
        End If

        Dim insertChiTietBaoCaoResult = _chiTietBaoCaoBus.InsertByMaBaoCaoAndDate(maBaoCAo, thoiGian)
        If insertChiTietBaoCaoResult.FlagResult = False Then Return insertChiTietBaoCaoResult

        Return New Result()
    End Function

    Private Function InsertBaoCaoTraTre(thoiGian As Date) As Object
        Dim baoCaoSachTraTre = New BaoCaoSachTraTre()
        baoCaoSachTraTre.ThoiGian = thoiGian
        Return InsertOne(baoCaoSachTraTre)
    End Function

#End Region

#Region "-   Retrieve data  -"
    Public Function GetTheLastID(ByRef maBaoCaoSachTraTre As String) As Result
        maBaoCaoSachTraTre = String.Empty
        Dim result = _baoCaoSachTraTreDaO.GetTheLastID(maBaoCaoSachTraTre)
        If String.IsNullOrWhiteSpace(maBaoCaoSachTraTre) Then Return New Result(False, "Không thể lấy mã số cuối cùng!", "")
        Return result
    End Function

    Public Function GetTinhHinhTraTreByMonth(month As Date, ByRef baocao As List(Of BaoCaoTraTreByMonth)) As Result
        Return _baoCaoSachTraTreDaO.GetTinhHinhTraTreByMonth(month, baocao)
    End Function

#End Region
End Class
