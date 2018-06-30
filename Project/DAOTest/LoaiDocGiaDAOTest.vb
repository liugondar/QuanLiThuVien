Imports System.Text
Imports DAO
Imports DTO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility

<TestClass()> Public Class LoaiDocGiaDAOTest

    <TestMethod()> Public Sub ValidSelectAllTest()
        'arr
        Dim expected = New Result()
        Dim loaiDocGiaDao = New LoaiDocGiaDAO()
        'act
        Dim actual = loaiDocGiaDao.SelectAll(New List(Of DTO.LoaiDocGia))
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub

    <TestMethod()> Public Sub ValidInsertOneTest()
        'arr
        Dim expected = New Result()
        Dim loaiDocGiaDao = New LoaiDocGiaDAO()
        Dim loaiDocGia = New LoaiDocGia()
        loaiDocGia.TenLoaiDocGia = "X"
        'act
        Dim actual = loaiDocGiaDao.InsertOne(loaiDocGia)
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub

End Class