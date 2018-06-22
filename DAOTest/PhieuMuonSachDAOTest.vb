Imports System.Text
Imports DAO
Imports DTO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility

<TestClass()> Public Class PhieuMuonSachDAOTest

    <TestMethod()> Public Sub ValidLayMaSoPhieuMuonSachCuoiCung()
        'arr
        Dim expected = New Result()
        Dim phieuMuonSachDAO = New PhieuMuonSachDAO()
        Dim maPhieu As Integer
        'act
        Dim act = phieuMuonSachDAO.LayMaSoPhieuMuonSachCuoiCung(maPhieu)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub

    <TestMethod()> Public Sub ValidInsertOne()
        'arr
        Dim expected = New Result()
        Dim phieuMuonSachDAO = New PhieuMuonSachDAO()
        Dim PhieuMuonSAch = New PhieuMuonSach()
        PhieuMuonSAch.MaTheDocGia = 2
        PhieuMuonSAch.NgayMuon = New DateTime(2018, 6, 6)
        PhieuMuonSAch.HanTra = New DateTime(2018, 6, 12)
        PhieuMuonSAch.TongSoSachMuon = 2
        'act
        Dim act = phieuMuonSachDAO.InsertOne(PhieuMuonSAch)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub
    <TestMethod()> Public Sub ValidSelectAllByMaTheDocGia()
        'arr
        Dim expected = New Result()
        Dim phieuMuonSachDAO = New PhieuMuonSachDAO()
        'act
        Dim act = phieuMuonSachDAO.SelectAllByMaTheDocGia(New List(Of PhieuMuonSach), 1)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub

    <TestMethod()> Public Sub ValidIDTheLastOne()
        'arr
        Dim expected = New Result()
        Dim phieuMuonSachDAO = New PhieuMuonSachDAO()
        Dim s = String.Empty
        'act
        Dim act = phieuMuonSachDAO.SelectIdTheLastOne(s)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub

End Class