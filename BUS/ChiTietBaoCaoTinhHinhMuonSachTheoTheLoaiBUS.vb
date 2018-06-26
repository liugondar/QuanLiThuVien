﻿Imports DAO
Imports DTO
Imports Utility

Public Class ChiTietBaoCaoTinhHinhMuonSachTheoTheLoaiBUS
#Region "-   Fields   -"
    Private _chiTietbaoCaoTinhHinhMuonSachTheoTheLoaiDAO As ChiTietBaoCaoTinhHinhMuonSachTheoTheLoaiDAO
    Private _theLoaiSachBus As TheLoaiSachBUS
    Private _phieuMuonSachBus As PhieuMuonSachBus
#End Region

#Region "-   Constructor   -"
    Public Sub New()
        _chiTietbaoCaoTinhHinhMuonSachTheoTheLoaiDAO = New ChiTietBaoCaoTinhHinhMuonSachTheoTheLoaiDAO()
        _theLoaiSachBus = New TheLoaiSachBUS()
        _phieuMuonSachBus = New PhieuMuonSachBus()
    End Sub

#End Region

#Region "-   Insert    -"

    Public Function InsertOne(ChiTietBaoCaoTinhHinhMuonSach As DTO.ChiTietBaoCaoTinhHinhMuonSachTheoTheLoai) As Result
        Return _chiTietbaoCaoTinhHinhMuonSachTheoTheLoaiDAO.InsertOne(ChiTietBaoCaoTinhHinhMuonSach)
    End Function


    Public Function InsertByMaBaoCaoTinhHinhMuonSachTheoTheLoaiAndDate(maBaoCao As String, thoiGian As DateTime) As Result
        'Load list the loai
        Dim listTheLoaiSAch = New List(Of TheLoaiSach)
        Dim getListTheLoaiResult = GetListTheLoaiSach(listTheLoaiSAch)
        If getListTheLoaiResult.FlagResult = False Then Return getListTheLoaiResult

        'Trong tung the loai load list phieu muon sach muon trong khoang
        'thoi gian yeu cau. Diem so luong sach muon trong phieumuonsach
        For Each theLoaiSach As TheLoaiSach In listTheLoaiSAch
            If InsertChiTietBaoCaoByMaTheLoaiSachAndTime(theLoaiSach.MaTheLoaiSach, thoiGian, maBaoCao).FlagResult = False Then
                'TODO: xu li khi 1 trong cac chi tiet insert that bai
            End If
        Next
        Return New Result()
    End Function

    Private Function InsertChiTietBaoCaoByMaTheLoaiSachAndTime(maTheLoaiSach As Integer, thoiGian As Date, maBaoCao As String) As Result
        Dim soLuotMuon = 0

        _chiTietbaoCaoTinhHinhMuonSachTheoTheLoaiDAO.GetSoLuongSachMuonByMaTheLoaiSachAndThoiGian(soLuotMuon, maTheLoaiSach, thoiGian)
        Dim chiTietBaoCao = New ChiTietBaoCaoTinhHinhMuonSachTheoTheLoai()
        chiTietBaoCao.MaBaoCaoTinhHinhMuonSachTheoTheLoai = maBaoCao
        chiTietBaoCao.MaTheLoaiSach = maTheLoaiSach
        chiTietBaoCao.SoLuongMuon = soLuotMuon
        Return InsertOne(chiTietBaoCao)
    End Function

    Private Function GetListTheLoaiSach(ByRef listTheLoaiSAch As List(Of TheLoaiSach)) As Result
        Return _theLoaiSachBus.SelectAll(listTheLoaiSAch)
    End Function

#End Region

#Region "-   Retrieve data  -"
    Public Function SelectAllByMaBaoCaoTinhHinhMuonSachTheoTheLoai(listChiTietBaoCAo As List(Of ChiTietBaoCaoTinhHinhMuonSachTheoTheLoai),
                                                                    maBaoCaoTinhHinhMuonSachTheoTheLoai As String) As Result
        Return _chiTietbaoCaoTinhHinhMuonSachTheoTheLoaiDAO.SelectAllByMaBaoCaoTinhHinhMuonSachTheoTheLoai(listChiTietBaoCAo, maBaoCaoTinhHinhMuonSachTheoTheLoai)
    End Function

#End Region
End Class
