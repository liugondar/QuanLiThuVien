Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports DAO
Imports Utility
Imports DTO
Imports BUS

<TestClass()> Public Class ChiTietPhieuMuonSachDAOTest

    <TestMethod()> Public Sub ValidInsertOne()
        'arr
        Dim arr = New Result()
        Dim chiTietPhieuMuonSachDAO = New ChiTietPhieuMuonSachDAO()
        Dim chiTietPhieuMuonSach = New ChiTietPhieuMuonSach()
        chiTietPhieuMuonSach.MaPhieuMuonSach = 1
        chiTietPhieuMuonSach.MaSach = 1
        'act
        Dim act = chiTietPhieuMuonSachDAO.InsertOne(chiTietPhieuMuonSach)
        'assert
        Assert.AreEqual(arr.ApplicationMessage, act.ApplicationMessage)
    End Sub

    <TestMethod()> Public Sub ValidSelectAllByMaphieumuonsach()
        'arr
        Dim arr = New Result()
        Dim chiTietPhieuMuonSachDAO = New ChiTietPhieuMuonSachDAO()
        Dim chiTietPhieuMuonSach = New ChiTietPhieuMuonSach()
        Dim phieuMuonSachBus = New PhieuMuonSachBus()
        Dim maPhieuMuonSAch = String.Empty
        phieuMuonSachBus.SelectIdTheLastOne(maPhieuMuonSAch)
        'act
        Dim act = chiTietPhieuMuonSachDAO.selectAllByMaphieumuonsach(New List(Of ChiTietPhieuMuonSach), maPhieuMuonSAch)
        'assert
        Assert.AreEqual(arr.ApplicationMessage, act.ApplicationMessage)
    End Sub

End Class