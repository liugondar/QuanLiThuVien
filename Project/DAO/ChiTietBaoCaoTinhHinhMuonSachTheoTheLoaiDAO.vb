Imports DTO
Imports Utility

Public Class ChiTietBaoCaoTinhHinhMuonSachTheoTheLoaiDAO
#Region "-  Fields   -"
    Private _dataProvider As DataProvider
#End Region

#Region "-  Constructor   -"
    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub

#End Region

#Region "-   Insert   -"
    Public Function InsertOne(chiTietbaoCaoTinhHinhMuonSachTheoTheLoai As ChiTietBaoCaoTinhHinhMuonSachTheoTheLoai) As Result

        Dim query = String.Format("
EXEC USP_NhapChiTietBaoCaoTinhHinhMuonSachTheoTheLoai 
@MaBaoCaoTinhHinhMuonSachTheoTheLoai={0},
@MaTheLoaiSach={1},
@SoLuongMuon={2}",
        chiTietbaoCaoTinhHinhMuonSachTheoTheLoai.MaBaoCaoTinhHinhMuonSachTheoTheLoai,
        chiTietbaoCaoTinhHinhMuonSachTheoTheLoai.MaTheLoaiSach,
        chiTietbaoCaoTinhHinhMuonSachTheoTheLoai.SoLuongMuon
)
        Return _dataProvider.ExecuteNonquery(query)
    End Function

    Public Function InsertMore(chiTietbaoCaoTinhHinhMuonSachTheoTheLoai As ChiTietBaoCaoTinhHinhMuonSachTheoTheLoai) As Result

        Dim query = String.Format("
EXEC USP_NhapChiTietBaoCaoTinhHinhMuonSachTheoTheLoai 
@MaBaoCaoTinhHinhMuonSachTheoTheLoai={0},
@MaTheLoaiSach={1},
@SoLuongMuon={2}",
        chiTietbaoCaoTinhHinhMuonSachTheoTheLoai.MaBaoCaoTinhHinhMuonSachTheoTheLoai,
        chiTietbaoCaoTinhHinhMuonSachTheoTheLoai.MaTheLoaiSach,
        chiTietbaoCaoTinhHinhMuonSachTheoTheLoai.SoLuongMuon
)
        Return _dataProvider.ExecuteNonquery(query)
    End Function

#End Region

#Region "-   Update    -"
    Public Function UpdateTiLe(maChiTietBaoCaoTinhHinhMuonSachTheoTheLoai As String, tiLe As Single) As Result
        Dim query = String.Format("execute USP_UpdateTiLeChiTietBaoCaoTheoTheLoai
 @MaChiTietBaoCaoTinhHinhMuonSachTheoTheLoai={0},
@tiLe={1}", maChiTietBaoCaoTinhHinhMuonSachTheoTheLoai, tiLe)
        Return _dataProvider.ExecuteNonquery(query)
    End Function
#End Region

#Region "-   Retrieve data    -"
    Public Function GetSoLuongSachMuonByMaTheLoaiSachAndThoiGian(ByRef soLuongSachMuon As String,
                                                                 maTheLoaiSach As String, thoiGian As DateTime) As Result

        Dim month = thoiGian.ToString("MM")
        Dim year = thoiGian.ToString("yyyy")
        Dim query = String.Format("select COUNT(DISTINCT(ctpms.MaChiTietPhieuMuonSach)) as SoLuotMuon
from PhieuMuonSach pms,ChiTietPhieuMuonSach ctpms, sach s
where ctpms.DeleteFlag='N' and s.DeleteFlag='N' and pms.DeleteFlag='N'
and pms.MaPhieuMuonSach=ctpms.MaPhieuMuonSach and ctpms.MaSach=s.MaSach
and s.MaTheLoaiSach={0} and Year(pms.NgayMuon)='{1}' and MONTH(pms.NgayMuon)='{2}'", maTheLoaiSach, year, month)
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            soLuongSachMuon = row("SoLuotMuon").ToString()
        Next
        Return result
    End Function

    Public Function SelectAllByMaBaoCaoTinhHinhMuonSachTheoTheLoai(listChiTietBaoCao As List(Of ChiTietBaoCaoTinhHinhMuonSachTheoTheLoai),
                                                                   maBaoCaoTinhHinhMuonSachTheoTheLoai As String) As Result
        Dim query = String.Format("SELECT * from ChiTietBaoCaoTinhHinhMuonSachTheotheLoai
where MaBaoCaoTinhHinhMuonSachTheoTheLoai={0}", maBaoCaoTinhHinhMuonSachTheoTheLoai)
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            Dim chiTietBaoCao = New ChiTietBaoCaoTinhHinhMuonSachTheoTheLoai(row)
            listChiTietBaoCao.Add(chiTietBaoCao)
        Next
        Return result
    End Function


#End Region

End Class
