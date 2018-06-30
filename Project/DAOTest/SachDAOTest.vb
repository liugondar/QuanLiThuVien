Imports System.Text
Imports BUS
Imports DAO
Imports DTO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility

<TestClass()> Public Class SachDAOTest

    <TestMethod()> Public Sub GivenValidSach_WhenInsertingOne_ThenTrueResultReturned()
        'arrange
        Dim expected = New Result()
        Dim sachDao = New SachDAO()
        Dim sachBus = New SachBus()
        Dim maSach = String.Empty
        sachBus.GetNextId(maSach)
        Dim sach = New Sach(maSach, "Di ve dau", 1, 1, "Kim dong",
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
    <TestMethod()> Public Sub ValidSetStatusSachToUnavailableByID()
        'arrange
        Dim expected = New Result()
        Dim sachDao = New SachDAO()
        Dim maSach = String.Empty
        'act
        Dim act = New Result()
        If sachDao.GetTheLastID(maSach).FlagResult = True Then
            act = sachDao.SetStatusSachToUnavailableByID(maSach)
        End If
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub
End Class