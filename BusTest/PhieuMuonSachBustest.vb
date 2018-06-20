Imports System.Text
Imports BUS
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
        Dim listDocGia = New List(Of DocGia)
        docGiaBus.SelectAllByType(1, listDocGia)
        phieuMuonSach.MaTheDocGia = listDocGia(0).MaTheDocGia
        phieuMuonSach.NgayMuon = DateTime.Now
        phieuMuonSach.TongSoSachMuon = 4
        'act
        Dim act = PhieuMuonSachBus.InsertOne(phieuMuonSach)
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