Imports System.Text
Imports DAO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility

<TestClass()> Public Class TacGiaDAOTESt

    <TestMethod()> Public Sub ValidSelectAll()
        'arr
        Dim expected = New Result()
        'act
        Dim tacGiaDao = New TacGiaDAO()
        Dim actual = tacGiaDao.SelectAll(New List(Of DTO.TacGia))
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub

End Class