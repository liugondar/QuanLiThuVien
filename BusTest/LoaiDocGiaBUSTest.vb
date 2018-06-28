Imports System.Text
Imports BUS
Imports DTO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility

<TestClass()> Public Class LoaiDocGiaBUSTest
#Region "Select all test"
    <TestMethod()> Public Sub ValidSelectAllTest()
        'arrange
        Dim expected = New Result
        Dim loaiDocGiaBus = New LoaiDocGiaBus()
        Dim listLoaiDocGia = New List(Of LoaiDocGia)
        'actual
        Dim actual = loaiDocGiaBus.SelectAll(listLoaiDocGia)
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
        Assert.AreNotEqual(0, listLoaiDocGia.Count)
    End Sub

#End Region
End Class