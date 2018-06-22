Imports System.Text
Imports BUS
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility

<TestClass()> Public Class TheLoaiSachBusTest

    <TestMethod()> Public Sub ValidSelectAll()
        'arr
        Dim expected = New Result()
        Dim theLoaiSachBus = New TheLoaiSachBUS()
        'act
        Dim actual = theLoaiSachBus.SelectAll(New List(Of DTO.TheLoaiSach))
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub
    <TestMethod()> Public Sub ValidSelectAllByMaTheLoaiSach()
        'arr
        Dim expected = New Result()
        Dim theLoaiSachBus = New TheLoaiSachBUS()
        'act
        Dim actual = theLoaiSachBus.SelectTheLoaiSachByMaTheLoaiSach(New DTO.TheLoaiSach(), 1)
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub

End Class