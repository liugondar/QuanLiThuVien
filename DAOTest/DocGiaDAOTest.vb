Imports System.Text
Imports DAO
Imports DTO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility

<TestClass()> Public Class DocGiaDAOTest

    <TestMethod()> Public Sub ValidInsertOneTest()
        'arr
        Dim expected = New Result()
        Dim DocGiaDAO = New DocGiaDAO()
        Dim docGia = New DocGia(1, "ahiinh", "123@gmail.com", "122c",
                      New DateTime(1998, 1, 1), DateTime.Now, DateTime.Now.AddMonths(6), 1)

        'act
        Dim actual = DocGiaDAO.InsertOne(docGia)
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub
    <TestMethod()> Public Sub ValidSelectAllByType()
        'arr
        Dim expected = New Result()
        Dim DocGiaDAO = New DocGiaDAO()
        'act
        Dim actual = DocGiaDAO.SelectAllByType(1, New List(Of DocGia))
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub

    <TestMethod()> Public Sub ValidSuaTheDocGia()
        'arr
        Dim expected = New Result()
        Dim DocGiaDAO = New DocGiaDAO()
        Dim docGia = New DocGia(1, "Gondar", "123@gmail.com", "122c",
                      New DateTime(1998, 1, 1), DateTime.Now, DateTime.Now.AddMonths(6), 1)

        'act
        Dim actual = DocGiaDAO.SuaTheDocGiaMaTheDocGia(docGia)
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub
End Class