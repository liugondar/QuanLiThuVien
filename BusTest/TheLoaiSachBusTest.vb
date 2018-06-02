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

End Class