Imports DAO
Imports DTO
Imports Utility

Public Class BaoCaoSachTraTreBus
#Region "-   Fields   -"
    Private _baoCaoSachTraTreDaO As BaoCaoSachTraTreDAO
#End Region

#Region "-   Constructor   -"
    Public Sub New()
        _baoCaoSachTraTreDaO = New BaoCaoSachTraTreDAO()

    End Sub

#End Region

#Region "-   Insert    -"

    Public Function InsertOne(baoCaoSachTraTre As DTO.BaoCaoSachTraTre) As Result
        If baoCaoSachTraTre.ToString Is Nothing Then Return New Result(False, "Không thể nhập báo cáo không có thời gian!", "")
        Return _baoCaoSachTraTreDaO.InsertOne(baoCaoSachTraTre)
    End Function

#End Region

#Region "-   Retrieve data  -"
    Public Function GetTheLastID(ByRef maBaoCaoSacTraTre As String) As Result
        maBaoCaoSacTraTre = String.Empty
        Dim result = _baoCaoSachTraTreDaO.GetTheLastID(maBaoCaoSacTraTre)
        If String.IsNullOrWhiteSpace(maBaoCaoSacTraTre) Then Return New Result(False, "Không thể lấy mã số cuối cùng!", "")
        Return result
    End Function
#End Region
End Class
