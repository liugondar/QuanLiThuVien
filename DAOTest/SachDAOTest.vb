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

End Class