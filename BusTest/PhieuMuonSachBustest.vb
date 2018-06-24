Imports System.Text
Imports BUS
Imports DAO
Imports DTO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility

<TestClass()> Public Class PhieuMuonSachBustest

    <TestMethod()> Public Sub ValidInsertOne()
        'arr
        Dim expected = New Result()
        Dim PhieuMuonSachBus = New PhieuMuonSachBus()
        Dim phieuMuonSach = New PhieuMuonSach()
        Dim docGiaBus = New DocGiaBus()
        Dim docGiaDao = New DocGiaDAO()
        Dim maTheDocGia = String.Empty

        'act
        Dim act = New Result()
        If docGiaDao.LayMaTheDocGiaCuoiCung(maTheDocGia).FlagResult Then
            phieuMuonSach.MaTheDocGia = maTheDocGia
            phieuMuonSach.NgayMuon = DateTime.Now
            phieuMuonSach.TongSoSachMuon = 4
            phieuMuonSach.HanTra = DateTime.Now
            act = PhieuMuonSachBus.InsertOne(phieuMuonSach)
        End If

        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub

    <TestMethod()> Public Sub ValidSelectAllByMaTheDocGia()
        'arr
        Dim expected = New Result()
        Dim PhieuMuonSachBus = New PhieuMuonSachBus()
        'act
        Dim act = PhieuMuonSachBus.SelectAllByMaTheDocGia(New List(Of PhieuMuonSach), 1)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub

End Class