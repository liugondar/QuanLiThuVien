Imports System.Text
Imports DTO
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class TheLoaiSachTest

#Region "Row constructor testing"
    <TestMethod()> Public Sub GivenValidRow_WhenRowContructoring_ThenValidValuesReturned()
        'arrange
        Dim namesTable As DataTable = New DataTable("Names")
        Dim table = New DataTable()

        table.Columns.Add("MaTheLoaiSach", GetType(String))
        table.Columns.Add("TenTheLoaiSach", GetType(String))
        table.Rows.Add("1", "Mai Anh Dinh")

        Dim expected = New TheLoaiSach(1, "Mai Anh Dinh")

        'act
        Dim act = New TheLoaiSach(table.Rows(0))

        'assert
        Assert.AreEqual(expected.MaTheLoaiSach, act.MaTheLoaiSach)
        Assert.AreEqual(expected.TenTheLoaiSach, act.TenTheLoaiSach)
    End Sub
    <TestMethod()> Public Sub GivenInvalidMaTheLoaiSachRow_WhenRowContructoring_ThenDefaultValuesReturned()
        'arrange
        Dim namesTable As DataTable = New DataTable("Names")
        Dim table = New DataTable()

        table.Columns.Add("Maa", GetType(String))
        table.Columns.Add("TenTheLoaiSach", GetType(String))
        table.Rows.Add("1", "Mai Anh Dinh")

        Dim expected = New TheLoaiSach()

        'act
        Dim act = New TheLoaiSach(table.Rows(0))

        'assert
        Assert.AreEqual(expected.MaTheLoaiSach, act.MaTheLoaiSach)
        Assert.AreEqual(expected.TenTheLoaiSach, act.TenTheLoaiSach)
    End Sub

    <TestMethod()> Public Sub GivenInvalidTenTheLoaiSachRow_WhenRowContructoring_ThenDefaultValuesReturned()
        'arrange
        Dim namesTable As DataTable = New DataTable("Names")
        Dim table = New DataTable()

        table.Columns.Add("MaTheLoaiSach", GetType(String))
        table.Columns.Add("TacdfsadfGia", GetType(String))
        table.Rows.Add("1", "Mai Anh Dinh")

        Dim expected = New TacGia()

        'act
        Dim act = New TacGia(table.Rows(0))

        'assert
        Assert.AreEqual(expected.MaTacGia, act.MaTacGia)
        Assert.AreEqual(expected.TenTacGia, act.TenTacGia)
    End Sub
#End Region

End Class