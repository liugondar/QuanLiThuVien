Imports System.Text
Imports BUS
Imports DTO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility

<TestClass()> Public Class SachBusTest

    <TestMethod()> Public Sub ValidateInsertOneTest()
        'arrange
        Dim expected = New Result()
        Dim sachBus = New SachBus()
        Dim sach = New Sach(1, "se ve dau", 1, 1, "Kim dong2",
New DateTime(1998, 1, 1), New DateTime(1998, 1, 1), 10000)
        'act
        Dim act = sachBus.InsertOne(sach)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub
    <TestMethod()> Public Sub GivenInvalidYear_WhenInsertOne_ThenFalseResultReturned()
        'arrange
        Dim expected = New Result(False, "", "")
        Dim sachBus = New SachBus()
        Dim sach = New Sach(1, "se ve dau", 1, 1, "Kim dong2",
New DateTime(1989, 1, 1), New DateTime(1998, 1, 1), 10000)
        'act
        Dim act = sachBus.InsertOne(sach)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub
    <TestMethod()> Public Sub GivenInvalidTacGia_WhenInsertOne_ThenFalseResultReturned()
        'arrange
        Dim expected = New Result(False, "Lỗi chọn sai tác giả", "")
        Dim sachBus = New SachBus()
        Dim sach = New Sach(1, "se ve dau", 1, -1, "Kim dong2",
New DateTime(1992, 1, 1), New DateTime(1998, 1, 1), 10000)
        'act
        Dim act = sachBus.InsertOne(sach)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
        Assert.AreEqual(expected.ApplicationMessage, act.ApplicationMessage)
    End Sub
    <TestMethod()> Public Sub GivenInvalidTheLoaiSach_WhenInsertOne_ThenFalseResultReturned()
        'arrange
        Dim expected = New Result(False, "Lỗi chọn sai thể loại sách", "")
        Dim sachBus = New SachBus()
        Dim sach = New Sach(1, "se ve dau", -1, 1, "Kim dong2",
New DateTime(1992, 1, 1), New DateTime(1998, 1, 1), 10000)
        'act
        Dim act = sachBus.InsertOne(sach)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
        Assert.AreEqual(expected.ApplicationMessage, act.ApplicationMessage)
    End Sub

    <TestMethod()> Public Sub ValidSelectAll()
        'arrange
        Dim expected = New Result()
        Dim sachBus = New SachBus()
        'act
        Dim act = sachBus.SelectAll(New List(Of Sach))
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub

    <TestMethod()> Public Sub GivenValidMaSach_WhenSelectingByMaSach_ThenTrueResultReturn()
        'arrange
        Dim expected = New Result()
        Dim sachBus = New SachBus()
        'act
        Dim act = sachBus.SelectAllByMaSach(New List(Of Sach), 1)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub


    <TestMethod()> Public Sub GivenValidMaTheLoaiSach_WhenSelectingByMaSach_ThenTrueResultReturn()
        'arrange
        Dim expected = New Result()
        Dim sachBus = New SachBus()
        'act
        Dim act = sachBus.SelectAllByMaTheLoaiSach(New List(Of Sach), 1)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub



    <TestMethod()> Public Sub GivenValidMaTacGia_WhenSelectingByMaSach_ThenTrueResultReturn()
        'arrange
        Dim expected = New Result()
        Dim sachBus = New SachBus()
        'act
        Dim act = sachBus.SelectAllByMaTacGia(New List(Of Sach), 1)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub

    <TestMethod()> Public Sub GivenValidTenNhaXuatBan_WhenSelectingByMaSach_ThenTrueResultReturn()
        'arrange
        Dim expected = New Result()
        Dim sachBus = New SachBus()
        'act
        Dim act = sachBus.SelectAllByTenNhaXuatBan(New List(Of Sach), "Kim dong")
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub


    <TestMethod()> Public Sub GivenValidNgayXuatBan_WhenSelectingByMaSach_ThenTrueResultReturn()
        'arrange
        Dim expected = New Result()
        Dim sachBus = New SachBus()
        Dim ngayMin = New DateTime(1974, 1, 1)
        Dim ngayMax = DateTime.Now
        'act
        Dim act = sachBus.SelectAllByNgayXuatBan(New List(Of Sach), ngayMin, ngayMax)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub


    <TestMethod()> Public Sub GivenValidNgayNhap_WhenSelectingByMaSach_ThenTrueResultReturn()
        'arrange
        Dim expected = New Result()
        Dim sachBus = New SachBus()
        Dim ngayMin = New DateTime(1974, 1, 1)
        Dim ngayMax = DateTime.Now
        'act
        Dim act = sachBus.SelectAllByNgayNhap(New List(Of Sach), ngayMin, ngayMax)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub


    <TestMethod()> Public Sub GivenValidTriGia_WhenSelectingByMaSach_ThenTrueResultReturn()
        'arrange
        Dim expected = New Result()
        Dim sachBus = New SachBus()
        Dim triGiaMin = 0
        Dim TriGiaMax = 1000000
        'act
        Dim act = sachBus.SelectAllByTriGia(New List(Of Sach), triGiaMin, TriGiaMax)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub

End Class