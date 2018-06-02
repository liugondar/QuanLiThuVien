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
End Class