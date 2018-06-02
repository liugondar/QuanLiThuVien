Imports System.Text
Imports DAO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility

<TestClass()> Public Class TheLoaiSachDAOTest

    <TestMethod()> Public Sub ValidSelectAll()
        'arr
        Dim expected = New Result()
        Dim theLoaiSachDao = New TheLoaiSachDAO()
        'act
        Dim actual = theLoaiSachDao.SelectAll(New List(Of DTO.TheLoaiSach))
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub

End Class