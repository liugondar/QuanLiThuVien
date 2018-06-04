Imports System.Text
Imports DAO
Imports DTO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility

<TestClass()> Public Class TacGiaDAOTESt

    <TestMethod()> Public Sub ValidSelectAll()
        'arr
        Dim expected = New Result()
        Dim tacGiaDao = New TacGiaDAO()
        'act
        Dim actual = TacGiaDAO.SelectAll(New List(Of DTO.TacGia))
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub
    <TestMethod()> Public Sub GivenValidMaTacGia_WhenSelectTacGiabyMaTacGia_ThenTrueResultReturned()
        'arr
        Dim expected = New Result()
        Dim tacGiaDao = New TacGiaDAO()
        'act
        Dim actual = tacGiaDao.SelectTacGiaByMaTacGia(New TacGia(), 1)
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub
End Class