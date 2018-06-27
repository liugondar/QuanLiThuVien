Imports DTO
Imports Utility
Public Class ChiTietBaoCaoSachTraTreDAO
#Region "-   Fields   -"
    Private _dataProvider As DataProvider
#End Region

#Region "-   Constructor   -"
    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub

#End Region

#Region "-  Insert   -"
    Public Function InsertOne(ChiTietBaoCaoSachTraTre As ChiTietBaoCaoSachTraTre) As Result
        Dim query = String.Format("
EXECUTE USP_NhapChiTietBaoCaoSachTraTre @MaBaoCaoSachTraTre={0},
@MaChiTietPhieuMuonSach={1},
@SoNgayTre={2}", ChiTietBaoCaoSachTraTre.MaBaoCaoSachTraTre,
ChiTietBaoCaoSachTraTre.MaChiTietPhieuMuonSach,
ChiTietBaoCaoSachTraTre.SoNgayTraTre)
        Return _dataProvider.ExcuteNonquery(query)
    End Function
#End Region

#Region "-   Retrieve data    -"
    Public Function GetTheLastID(ByRef maChiTietBaoCaoSachTraTre As String) As Result
        Dim query = String.Format("select top 1 [MaChiTietBaoCaoSachTraTre]
from ChiTietBaoCaoSachTraTre
ORDER by [MaChiTietBaoCaoSachTraTre]")
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)

        For Each row In dataTable.Rows
            maChiTietBaoCaoSachTraTre = row("MaChiTietBaoCaoSachTraTre").ToString()
        Next
        Return result
    End Function
#End Region
End Class
