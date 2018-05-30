Imports System.Text
Imports DTO
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class LoaiDocGiaTest

#Region "DataRow parameter constructor test"
    <TestMethod()> Public Sub GivenValidRow_ToRowConstructor_ThenValidValuesReturn()
        'arrange
        Dim namesTable As DataTable = New DataTable("Names")
        Dim table = New DataTable()
        table.Columns.Add("MaLoaiDocGia", GetType(Integer))
        table.Columns.Add("TenLoaiDocGia", GetType(String))
        table.Rows.Add(1, "X")

        Dim expected = New LoaiDocGia(1, "X")
        'act
        Dim act = New LoaiDocGia(table.Rows(0))
        'assert
        Assert.AreEqual(expected.MaLoaiDocGia, act.MaLoaiDocGia)
        Assert.AreEqual(expected.TenLoaiDocGia, act.TenLoaiDocGia)

    End Sub
    <TestMethod()> Public Sub GivenInValidRow_ToRowConstructor_ThenZeroValuesReturn()
        'arrange
        Dim namesTable As DataTable = New DataTable("Names")
        Dim table = New DataTable()
        table.Columns.Add("Mai", GetType(Integer))
        table.Columns.Add("Tena", GetType(String))
        table.Rows.Add(1, "X")

        Dim expected = New LoaiDocGia(0, "")
        'act
        Dim act = New LoaiDocGia(table.Rows(0))
        'assert
        Assert.AreEqual(expected.MaLoaiDocGia, act.MaLoaiDocGia)
        Assert.AreEqual(expected.TenLoaiDocGia, act.TenLoaiDocGia)

    End Sub
    <TestMethod()> Public Sub GivenInValidMaloaiDocGiaRow_ToRowConstructor_ThenZeroValuesReturn()
        'arrange
        Dim namesTable As DataTable = New DataTable("Names")
        Dim table = New DataTable()
        table.Columns.Add("MaLoai", GetType(Integer))
        table.Columns.Add("TenLoaiDocGia", GetType(String))
        table.Rows.Add(1, "X")

        Dim expected = New LoaiDocGia(0, "")
        'act
        Dim act = New LoaiDocGia(table.Rows(0))
        'assert
        Assert.AreEqual(expected.MaLoaiDocGia, act.MaLoaiDocGia)
        Assert.AreEqual(expected.TenLoaiDocGia, act.TenLoaiDocGia)

    End Sub
    <TestMethod()> Public Sub GivenInValidTenLoaiDocGiaRow_ToRowConstructor_ThenZeroValuesReturn()
        'arrange
        Dim namesTable As DataTable = New DataTable("Names")
        Dim table = New DataTable()
        table.Columns.Add("MaLoaiDocGia", GetType(Integer))
        table.Columns.Add("Te", GetType(String))
        table.Rows.Add(1, "X")

        Dim expected = New LoaiDocGia(0, "")
        'act
        Dim act = New LoaiDocGia(table.Rows(0))
        'assert
        Assert.AreEqual(expected.MaLoaiDocGia, act.MaLoaiDocGia)
        Assert.AreEqual(expected.TenLoaiDocGia, act.TenLoaiDocGia)

    End Sub

#End Region
End Class