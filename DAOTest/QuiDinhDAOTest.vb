Imports System.Text
Imports DAO
Imports DTO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility

<TestClass()> Public Class QuiDinhDAOTest

    <TestMethod()> Public Sub ValidSelectAll()
        'arrange
        Dim expected = New Result()
        Dim quiDinhDao = New QuiDinhDAO()
        'act
        Dim actual = quiDinhDao.SelectAll(New QuiDinh())
        'assert

        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub

    <TestMethod()> Public Sub ValidSelectTuoiToiDaTuoiToiThieu()
        'arrange
        Dim expected = New Result()
        Dim quiDinhDao = New QuiDinhDAO()
        'act
        Dim actual = quiDinhDao.LayTuoiToiDaVaToiThieu(New QuiDinh())
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub

    <TestMethod()> Public Sub ValidSelectThoiHanToiDaNhanThe()
        'arrange
        Dim expected = New Result()
        Dim quiDinhDao = New QuiDinhDAO()
        'act
        Dim actual = quiDinhDao.LayThoiHanToiDaTheDocGia(New QuiDinh())
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub
    <TestMethod()> Public Sub ValidSelectSoNgayMuonSachToiDa()
        'arrange
        Dim expected = New Result()
        Dim quiDinhDao = New QuiDinhDAO()
        'act
        Dim actual = quiDinhDao.LaySoNgayMuonSachToiDa(New QuiDinh())
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub
    <TestMethod()> Public Sub ValidSelectSoSachMuonToiDa()
        'arrange
        Dim expected = New Result()
        Dim quiDinhDao = New QuiDinhDAO()
        'act
        Dim actual = quiDinhDao.LaySoSachMuonToiDa(New QuiDinh())
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub
End Class