Imports System.Text
Imports BUS
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility

<TestClass()> Public Class TacGiaBusTest

    <TestMethod()> Public Sub ValidSelectAll()
        'arr
        Dim expected = New Result()
        Dim tacGiaBus = New TacGiaBUS()
        'act
        Dim actual = tacGiaBus.SelectAll(New List(Of DTO.TacGia))
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub
    <TestMethod()> Public Sub GivenValidMaTacGia_WhenSelectTacGiabyMaTacGia_ThenTrueResultReturned()
        'arr
        Dim expected = New Result()
        Dim tacGiaBus = New TacGiaBUS()
        'act
        Dim actual = tacGiaBus.SelectTacGiaByMaTacGia(New DTO.TacGia(), 1)
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub
End Class