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
        Dim maTheDocGia = String.Empty
        Dim result = DocGiaDAO.GetTheLastTheDocGiaID(maTheDocGia)
        If result.FlagResult Then
            maTheDocGia = maTheDocGia + 1
        Else
            maTheDocGia = 1
        End If
        Dim docGia = New DocGia(maTheDocGia, "ahiinh", "123@gmail.com", "122c",
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
        Dim actual = DocGiaDAO.UpdateByReaderId(docGia)
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub
    <TestMethod()> Public Sub ValidXoaTheDocGia()
        'arr
        Dim expected = New Result()
        Dim DocGiaDAO = New DocGiaDAO()
        'act
        Dim actual = DocGiaDAO.DeleteByReaderID(1)
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub

    <TestMethod()> Public Sub ValidLayMaTheDocGiaCuoiCung()
        'arr
        Dim expected = New Result()
        Dim DocGiaDAO = New DocGiaDAO()
        Dim maThe As String
        'act
        Dim actual = DocGiaDAO.GetTheLastTheDocGiaID(maThe)
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub

    <TestMethod()> Public Sub ValidLayTenDocGiaBangMaThe()
        'arr
        Dim expected = New Result()
        Dim DocGiaDAO = New DocGiaDAO()
        Dim maThe As String = 1
        Dim docgia = String.Empty
        'act
        Dim actual = DocGiaDAO.GetReaderNameByID(docgia, maThe)
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub

    <TestMethod()> Public Sub ValidSelectExpirationDateByID()
        'arr
        Dim expected = New Result()
        Dim DocGiaDAO = New DocGiaDAO()
        Dim maThe As String = String.Empty
        maThe = 1
        Dim ngayHetHan = New DateTime()
        'act
        Dim actual = DocGiaDAO.GetExpirationDateById(ngayHetHan, maThe)
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub
End Class