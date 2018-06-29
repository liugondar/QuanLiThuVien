Imports System.Text
Imports BUS
Imports DAO
Imports DTO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility

<TestClass()> Public Class ChiTietPhieuMuonSachBusTest

    <TestMethod()> Public Sub ValidateInsertOne()
        'arr
        Dim expected = New Result()
        Dim chiTietPhieuMuonSachBus = New ChiTietPhieuMuonSachBus()
        Dim chiTietPhieuMuonSach = New ChiTietPhieuMuonSach()
        Dim sachDao = New SachDAO()
        Dim maSach = String.Empty
        Dim phieuMuonSachDAO = New PhieuMuonSachDAO()
        Dim maPhieuMuonSAch = String.Empty

        phieuMuonSachDAO.GetTheLastPhieuMuonSachID(maPhieuMuonSAch)
        sachDao.GetTheLastID(maSach)

        chiTietPhieuMuonSach.MaPhieuMuonSach = maPhieuMuonSAch
        chiTietPhieuMuonSach.MaSach = maSach
        'act
        Dim act = chiTietPhieuMuonSachBus.InsertOne(chiTietPhieuMuonSach)
        'assert
        Assert.AreEqual(expected.ApplicationMessage, act.ApplicationMessage)
    End Sub

End Class