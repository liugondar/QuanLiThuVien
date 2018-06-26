Imports DAO
Imports DTO
Imports Utility

Public Class BaoCaoTinhHinhMuonSachTheoTheLoaiBus
#Region "-   Fields   -"
    Private _baoCaoTinhHinhMuonSachTheoTheLoaiDAO As BaoCaoTinhHinhMuonSachTheoTheLoaiDAO
    Private _chiTietBaoCaoBus As ChiTietBaoCaoTinhHinhMuonSachTheoTheLoaiBUS
#End Region

#Region "-   Constructor   -"
    Public Sub New()
        _baoCaoTinhHinhMuonSachTheoTheLoaiDAO = New BaoCaoTinhHinhMuonSachTheoTheLoaiDAO()
        _chiTietBaoCaoBus = New ChiTietBaoCaoTinhHinhMuonSachTheoTheLoaiBUS()

    End Sub

#End Region

#Region "-   Insert    -"

    Public Function InsertOne(baoCaoTinhHinhMuonSach As DTO.BaoCaoTinhHinhMuonSachTheoTheLoai) As Result
        Return _baoCaoTinhHinhMuonSachTheoTheLoaiDAO.InsertOne(baoCaoTinhHinhMuonSach)
    End Function


    'Input thời gian, insert baoCao và chitietbaocao phụ thuộc vào thời gian đó
    Public Function InsertByThoiGian(thoiGian As DateTime) As Result

        'Insert baoCaoTinhHinhMuonSachTheoTheLoai 
        Dim insertBaoCaoResult = InsertBaoCaoTinhHinhMuonSach(thoiGian)
        If insertBaoCaoResult.FlagResult = False Then Return insertBaoCaoResult

        Dim maBaoCAo = 0
        Dim getBaoCaoIdResult = _baoCaoTinhHinhMuonSachTheoTheLoaiDAO.GetTheLastID(maBaoCAo)
        If getBaoCaoIdResult.FlagResult = False Then
            'TODO: delete bao cao and list chitietbaocao insert before then return
        End If

        Return _chiTietBaoCaoBus.InsertByMaBaoCaoTinhHinhMuonSachTheoTheLoaiAndDate(maBaoCAo, thoiGian)
    End Function

    Private Function InsertBaoCaoTinhHinhMuonSach(thoiGian As Date) As Result
        Dim baoCaoTinhHinhMuonSach = New BaoCaoTinhHinhMuonSachTheoTheLoai()
        baoCaoTinhHinhMuonSach.ThoiGian = thoiGian
        Return InsertOne(baoCaoTinhHinhMuonSach)
    End Function


#End Region

#Region "-   Retrieve data  -"
    Public Function GetTheLastID(ByRef maBaoCaoTinhHinhMuonSachTheoTheLoai) As Result
        Return _baoCaoTinhHinhMuonSachTheoTheLoaiDAO.GetTheLastID(maBaoCaoTinhHinhMuonSachTheoTheLoai)
    End Function
#End Region

End Class
