Imports System.Text
Imports DTO
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class TacGiaTest

#Region "Row constructor testing"
    <TestMethod()> Public Sub GivenValidRow_WhenRowContructoring_ThenValidValuesReturned()
        'arrange
        Dim namesTable As DataTable = New DataTable("Names")
        Dim table = New DataTable()

        table.Columns.Add("MaTacGia", GetType(String))
        table.Columns.Add("TenTacGia", GetType(String))
        table.Rows.Add("1", "Mai Anh Dinh")

        Dim expected = New TacGia(1, "Mai Anh Dinh")

        'act
        Dim act = New TacGia(table.Rows(0))

        'assert
        Assert.AreEqual(expected.MaTacGia, act.MaTacGia)
        Assert.AreEqual(expected.TenTacGia, act.TenTacGia)
    End Sub
    <TestMethod()> Public Sub GivenInvalidMaTacGiaRow_WhenRowContructoring_ThenDefaultValuesReturned()
        'arrange
        Dim namesTable As DataTable = New DataTable("Names")
        Dim table = New DataTable()

        table.Columns.Add("Maa", GetType(String))
        table.Columns.Add("TenTacGia", GetType(String))
        table.Rows.Add("1", "Mai Anh Dinh")

        Dim expected = New TacGia()

        'act
        Dim act = New TacGia(table.Rows(0))

        'assert
        Assert.AreEqual(expected.MaTacGia, act.MaTacGia)
        Assert.AreEqual(expected.TenTacGia, act.TenTacGia)
    End Sub

    <TestMethod()> Public Sub GivenInvalidTenTacGiaRow_WhenRowContructoring_ThenDefaultValuesReturned()
        'arrange
        Dim namesTable As DataTable = New DataTable("Names")
        Dim table = New DataTable()

        table.Columns.Add("MaTacGia", GetType(String))
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