Imports System.Text
Imports BUS
Imports DTO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility

<TestClass()> Public Class ChiTietPhieuMuonSachBusTest

    <TestMethod()> Public Sub ValidateInsertOne()
        'arr
        Dim expected = New Result()
        Dim chiTietPhieuMuonSachBus = New ChiTietPhieuMuonSachBus()
        Dim chiTietPhieuMuonSach = New ChiTietPhieuMuonSach()
        chiTietPhieuMuonSach.MaPhieuMuonSach = 1
        chiTietPhieuMuonSach.MaSach = 1
        'act
        Dim act = chiTietPhieuMuonSachBus.InsertOne(chiTietPhieuMuonSach)
        'assert
        Assert.AreEqual(expected.ApplicationMessage, act.ApplicationMessage)
    End Sub

End Class