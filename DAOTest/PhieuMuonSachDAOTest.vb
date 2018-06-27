Imports System.Text
Imports BUS
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
        Dim act = phieuMuonSachDAO.GetTheLastPhieuMuonSachID(maPhieu)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub

    <TestMethod()> Public Sub ValidInsertOne()
        'arr
        Dim expected = New Result()
        Dim phieuMuonSachDAO = New PhieuMuonSachDAO()
        Dim PhieuMuonSAch = New PhieuMuonSach()
        Dim maPhieuMuonSach = String.Empty
        phieuMuonSachDAO.SelectIdTheLastOne(maPhieuMuonSach)
        maPhieuMuonSach = maPhieuMuonSach + 1

        Dim docGiaDao = New DocGiaDAO()
        Dim maTheDocGia = String.Empty
        Dim resultLayMaThe = docGiaDao.GetTheLastTheDocGiaID(maTheDocGia)

        Dim act = New Result
        If resultLayMaThe.FlagResult Then
            PhieuMuonSAch.MaPhieuMuonSach = maPhieuMuonSach
            PhieuMuonSAch.MaTheDocGia = maTheDocGia
            PhieuMuonSAch.NgayMuon = New DateTime(2018, 6, 6)
            PhieuMuonSAch.HanTra = New DateTime(2018, 6, 12)
            PhieuMuonSAch.TongSoSachMuon = 2
            'act
            act = phieuMuonSachDAO.InsertOne(PhieuMuonSAch)
        End If

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

    <TestMethod()> Public Sub ValidSeleteOneByID()
        'arr
        Dim expected = New Result()
        Dim phieuMuonSachDAO = New PhieuMuonSachDAO()
        Dim s = String.Empty
        'act
        Dim act = New Result
        If phieuMuonSachDAO.SelectIdTheLastOne(s).FlagResult Then
            act = phieuMuonSachDAO.GetPhieuMuonSachById(New PhieuMuonSach(), s)
        End If
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub
End Class