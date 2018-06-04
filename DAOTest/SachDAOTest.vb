Imports System.Text
Imports DAO
Imports DTO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility

<TestClass()> Public Class SachDAOTest

    <TestMethod()> Public Sub GivenValidSach_WhenInsertingOne_ThenTrueResultReturned()
        'arrange
        Dim expected = New Result()
        Dim sachDao = New SachDAO()
        Dim sach = New Sach(1, "Di ve dau", 1, 1, "Kim dong",
New DateTime(1998, 1, 1), New DateTime(1998, 1, 1), 10000)
        'act
        Dim act = sachDao.InsertOne(sach)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub

    <TestMethod()> Public Sub ValidSelectAll()
        'arrange
        Dim expected = New Result()
        Dim sachDao = New SachDAO()
        'act
        Dim act = sachDao.SelectAll(New List(Of Sach))
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub
    <TestMethod()> Public Sub GivenValidMaSach_WhenSelectingByMaSach_ThenTrueResultReturn()
        'arrange
        Dim expected = New Result()
        Dim sachDao = New SachDAO()
        'act
        Dim act = sachDao.SelectAllByMaSach(New List(Of Sach), 1)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub
    <TestMethod()> Public Sub GivenValidMaTheLoaiSach_WhenSelectingByMaSach_ThenTrueResultReturn()
        'arrange
        Dim expected = New Result()
        Dim sachDao = New SachDAO()
        'act
        Dim act = sachDao.SelectAllByMaTheLoaiSach(New List(Of Sach), 1)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub

    <TestMethod()> Public Sub GivenValidMaTacGia_WhenSelectingByMaSach_ThenTrueResultReturn()
        'arrange
        Dim expected = New Result()
        Dim sachDao = New SachDAO()
        'act
        Dim act = sachDao.SelectAllByMaTacGia(New List(Of Sach), 1)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub

    <TestMethod()> Public Sub GivenValidTenNhaXuatBan_WhenSelectingByMaSach_ThenTrueResultReturn()
        'arrange
        Dim expected = New Result()
        Dim sachDao = New SachDAO()
        'act
        Dim act = sachDao.SelectAllByTenNhaXuatBan(New List(Of Sach), "Kim Dong")
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub

    <TestMethod()> Public Sub GivenValidNgayXuatBan_WhenSelectingByMaSach_ThenTrueResultReturn()
        'arrange
        Dim expected = New Result()
        Dim sachDao = New SachDAO()
        Dim ngayMin = New DateTime(1974, 1, 1)
        Dim ngayMax = DateTime.Now
        'act
        Dim act = sachDao.SelectAllByNgayXuatBan(New List(Of Sach), ngayMin, ngayMax)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub

    <TestMethod()> Public Sub GivenValidNgayNhap_WhenSelectingByMaSach_ThenTrueResultReturn()
        'arrange
        Dim expected = New Result()
        Dim sachDao = New SachDAO()
        Dim ngayMin = New DateTime(1974, 1, 1)
        Dim ngayMax = DateTime.Now
        'act
        Dim act = sachDao.SelectAllByNgayNhap(New List(Of Sach), ngayMin, ngayMax)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub

    <TestMethod()> Public Sub GivenValidTriGia_WhenSelectingByMaSach_ThenTrueResultReturn()
        'arrange
        Dim expected = New Result()
        Dim sachDao = New SachDAO()
        Dim triGiaMin = 0
        Dim triGiaMax = 1000000
        'act
        Dim act = sachDao.SelectAllByTriGia(New List(Of Sach), triGiaMin, triGiaMax)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub
End Class