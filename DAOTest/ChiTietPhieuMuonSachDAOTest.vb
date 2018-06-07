Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports DAO
Imports Utility
Imports DTO

<TestClass()> Public Class ChiTietPhieuMuonSachDAOTest

    <TestMethod()> Public Sub ValidInsertOne()
        'arr
        Dim arr = New Result()
        Dim chiTietPhieuMuonSachDAO = New ChiTietPhieuMuonSachDAO()
        Dim chiTietPhieuMuonSach=New ChiTietPhieuMuonSach()
        chiTietPhieuMuonSach.MaPhieuMuonSach = 1
        chiTietPhieuMuonSach.MaSach = 1
        'act
        Dim act = chiTietPhieuMuonSachDAO.InsertOne(chiTietPhieuMuonSach)
        'assert
        Assert.AreEqual(arr.ApplicationMessage, act.ApplicationMessage)
    End Sub

End Class