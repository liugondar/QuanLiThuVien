Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility

<TestClass()> Public Class BaoCaoTinhHinhMuonSachTheoTheLoaiDAOTest

    <TestMethod()> Public Sub ValidInsertOne()
        'arr
        Dim expected = New Result()
        Dim baoCaoTinhHinhMuonSachDAO = New DAO.BaoCaoTinhHinhMuonSachTheoTheLoaiDAO()
        Dim baoCaoTinhHinhMuonSach = New DTO.BaoCaoTinhHinhMuonSachTheoTheLoai()
        baoCaoTinhHinhMuonSach.ThoiGian = DateTime.Now
        baoCaoTinhHinhMuonSach.TongSoLuotMuon = 1
        'act
        Dim act = baoCaoTinhHinhMuonSachDAO.InsertOne(baoCaoTinhHinhMuonSach)
        'asert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub

End Class