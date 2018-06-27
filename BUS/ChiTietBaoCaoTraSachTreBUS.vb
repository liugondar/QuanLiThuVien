Imports DAO
Imports DTO
Imports Utility

Public Class ChiTietBaoCaoSachTraTreBus
#Region "-   Fields   -"
    Private _chiTietBaoCaoSachTraTreDaO As ChiTietBaoCaoSachTraTreDAO
#End Region

#Region "-   Constructor   -"
    Public Sub New()
        _chiTietBaoCaoSachTraTreDaO = New ChiTietBaoCaoSachTraTreDAO()

    End Sub

#End Region

#Region "-   Insert    -"

    Public Function InsertOne(chiTietBaoCaoSachTraTre As DTO.ChiTietBaoCaoSachTraTre) As Result
        If chiTietBaoCaoSachTraTre.ToString Is Nothing Then Return New Result(False, "Không thể nhập báo cáo không có thời gian!", "")
        Return _chiTietBaoCaoSachTraTreDaO.InsertOne(chiTietBaoCaoSachTraTre)
    End Function

#End Region

#Region "-   Retrieve data  -"
    Public Function GetTheLastID(ByRef maChiTietBaoCaoSacTraTre As String) As Result
        maChiTietBaoCaoSacTraTre = String.Empty
        Dim result = _chiTietBaoCaoSachTraTreDaO.GetTheLastID(maChiTietBaoCaoSacTraTre)
        If String.IsNullOrWhiteSpace(maChiTietBaoCaoSacTraTre) Then Return New Result(False, "Không thể lấy mã số cuối cùng!", "")
        Return result
    End Function
#End Region
End Class
