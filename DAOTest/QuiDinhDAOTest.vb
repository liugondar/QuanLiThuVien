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
        Dim actual = quiDinhDao.SelectAll(New List(Of QuiDinh))
        'assert

        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub

End Class