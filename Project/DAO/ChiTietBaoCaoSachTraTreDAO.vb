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
        Return _dataProvider.ExecuteNonquery(query)
    End Function
#End Region

#Region "-   Retrieve data    -"
    Public Function GetTheLastID(ByRef maChiTietBaoCaoSachTraTre As String) As Result
        Dim query = String.Format("select top 1 [MaChiTietBaoCaoSachTraTre]
from ChiTietBaoCaoSachTraTre
ORDER by [MaChiTietBaoCaoSachTraTre]")
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)

        For Each row In dataTable.Rows
            maChiTietBaoCaoSachTraTre = row("MaChiTietBaoCaoSachTraTre").ToString()
        Next
        Return result
    End Function

    Public Function GetSoNgayTreAndMaChiTietPhieuMuonSachByDate(ByRef listChiTietBaoCao As List(Of ChiTietBaoCaoSachTraTre), thoiGian As DateTime) As Result
        'Get all phieu muon sach in time input
        Dim query = String.Format("
select pms.NgayTra NgayTra, pms.HanTra HanTra,
ctpms.MaChiTietPhieuMuonSach MaChiTietPhieuMuonSach
from PhieuMuonSach pms,ChiTietPhieuMuonSach ctpms
where pms.DeleteFlag='N' and ctpms.DeleteFlag='N'
 and pms.TinhTrang='1' and pms.MaPhieuMuonSach=ctpms.MaPhieuMuonSach
And YEAR(NgayTra)='{0}' and month(NgayMuon)='{1}' ", thoiGian.ToString("yyyy"), thoiGian.ToString("MM"))
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            Dim chiTietBaoCao = New ChiTietBaoCaoSachTraTre()
            chiTietBaoCao.MaChiTietPhieuMuonSach = row("MaChiTietPhieuMuonSach").ToString()
            Dim ngayTra = New DateTime()
            Dim HanTra = New DateTime()
            DateTime.TryParse(row("NgayTra").ToString(), ngayTra)
            DateTime.TryParse(row("HanTra").ToString(), HanTra)
            chiTietBaoCao.SoNgayTraTre = (ngayTra - HanTra).TotalDays

            listChiTietBaoCao.Add(chiTietBaoCao)
        Next
        Return result
    End Function

    Public Function SelectAllByMaBaoCaoSachTraTre(ByRef listChiTietBaoCao As List(Of ChiTietBaoCaoSachTraTre), maBaoCaoSachTraTre As String) As Result
        Dim query = String.Format("select * from ChiTietBaoCaoSachTraTre
where DeleteFlag='N'
and MaBaoCaoSachTraTre={0}", maBaoCaoSachTraTre)

        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            Dim chiTietBaoCao = New ChiTietBaoCaoSachTraTre()
            chiTietBaoCao = New ChiTietBaoCaoSachTraTre(row)
            listChiTietBaoCao.Add(chiTietBaoCao)
        Next
        Return result
    End Function
#End Region
End Class
