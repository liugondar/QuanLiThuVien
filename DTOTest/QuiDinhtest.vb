Imports System.Text
Imports DTO
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class QuiDinhtest

#Region "Row constructor test"
    <TestMethod()> Public Sub GivenValidRow_ToRowParameterConstructor_ThenValidResultReturned()
        'arrange
        Dim namesTable As DataTable = New DataTable("Names")
        Dim table = New DataTable()
        table.Columns.Add("TuoiToiDa", GetType(Integer))
        table.Columns.Add("TuoiToiThieu", GetType(Integer))
        table.Columns.Add("ThoiHanToiDaTheDocGia", GetType(Integer))
        table.Columns.Add("ThoiHanNhanSach", GetType(Integer))
        table.Rows.Add(5, 5, 6, 8)

        Dim expected = New QuiDinh(5, 5, 6, 8)
        'act
        Dim act = New QuiDinh(table.Rows(0))
        'assert
        Assert.AreEqual(expected.TuoiToiDa, act.TuoiToiDa)
        Assert.AreEqual(expected.TuoiToiThieu, act.TuoiToiThieu)
        Assert.AreEqual(expected.ThoiHanToiDaTheDocGia, act.ThoiHanToiDaTheDocGia)
        Assert.AreEqual(expected.ThoiHanNhanSach, act.ThoiHanNhanSach)
    End Sub
    <TestMethod()> Public Sub GivenInvalidTuoiToiDaRow_ToRowParameterConstructor_ThenValidResultReturned()
        'arrange
        Dim namesTable As DataTable = New DataTable("Names")
        Dim table = New DataTable()
        table.Columns.Add("TuoiToi", GetType(Integer))
        table.Columns.Add("TuoiToiThieu", GetType(Integer))
        table.Columns.Add("ThoiHanToiDaTheDocGia", GetType(Integer))
        table.Columns.Add("ThoiHanNhanSach", GetType(Integer))
        table.Rows.Add(5, 5, 6, 8)

        Dim expected = New QuiDinh(0, 0, 0, 0)
        'act
        Dim act = New QuiDinh(table.Rows(0))
        'assert
        Assert.AreEqual(expected.TuoiToiDa, act.TuoiToiDa)
        Assert.AreEqual(expected.TuoiToiThieu, act.TuoiToiThieu)
        Assert.AreEqual(expected.ThoiHanToiDaTheDocGia, act.ThoiHanToiDaTheDocGia)
        Assert.AreEqual(expected.ThoiHanNhanSach, act.ThoiHanNhanSach)

    End Sub
    <TestMethod()> Public Sub GivenInvalidTuoiToiThieuRow_ToRowParameterConstructor_ThenValidResultReturned()
        'arrange
        Dim namesTable As DataTable = New DataTable("Names")
        Dim table = New DataTable()
        table.Columns.Add("TuoiToiDa", GetType(Integer))
        table.Columns.Add("TuoiToi", GetType(Integer))
        table.Columns.Add("ThoiHanToiDaTheDocGia", GetType(Integer))
        table.Columns.Add("ThoiHanNhanSach", GetType(Integer))

        table.Rows.Add(5, 5, 6, 8)

        Dim expected = New QuiDinh(0, 0, 0, 0)
        'act
        Dim act = New QuiDinh(table.Rows(0))
        'assert
        Assert.AreEqual(expected.TuoiToiDa, act.TuoiToiDa)
        Assert.AreEqual(expected.TuoiToiThieu, act.TuoiToiThieu)
        Assert.AreEqual(expected.ThoiHanToiDaTheDocGia, act.ThoiHanToiDaTheDocGia)
        Assert.AreEqual(expected.ThoiHanNhanSach, act.ThoiHanNhanSach)

    End Sub

    <TestMethod()> Public Sub GivenInvalidTuoiHanToiDaRow_ToRowParameterConstructor_ThenValidResultReturned()
        'arrange
        Dim namesTable As DataTable = New DataTable("Names")
        Dim table = New DataTable()
        table.Columns.Add("TuoiToiDa", GetType(Integer))
        table.Columns.Add("TuoiToiThieu", GetType(Integer))
        table.Columns.Add("Thoi", GetType(Integer))
        table.Columns.Add("ThoiHanNhanSach", GetType(Integer))

        table.Rows.Add(5, 5, 6, 8)

        Dim expected = New QuiDinh(0, 0, 0, 0)
        'act
        Dim act = New QuiDinh(table.Rows(0))
        'assert
        Assert.AreEqual(expected.TuoiToiDa, act.TuoiToiDa)
        Assert.AreEqual(expected.TuoiToiThieu, act.TuoiToiThieu)
        Assert.AreEqual(expected.ThoiHanToiDaTheDocGia, act.ThoiHanToiDaTheDocGia)
        Assert.AreEqual(expected.ThoiHanNhanSach, act.ThoiHanNhanSach)

    End Sub
    <TestMethod()> Public Sub GivenInvalidTuoiHanToiDaNMhanSachRow_ToRowParameterConstructor_ThenValidResultReturned()
        'arrange
        Dim namesTable As DataTable = New DataTable("Names")
        Dim table = New DataTable()
        table.Columns.Add("TuoiToiDa", GetType(Integer))
        table.Columns.Add("TuoiToiThieu", GetType(Integer))
        table.Columns.Add("ThoiHanToiDaTheDocGia", GetType(Integer))
        table.Columns.Add("ThoiHaanSach", GetType(Integer))

        table.Rows.Add(5, 5, 6, 8)

        Dim expected = New QuiDinh(0, 0, 0, 0)
        'act
        Dim act = New QuiDinh(table.Rows(0))
        'assert
        Assert.AreEqual(expected.TuoiToiDa, act.TuoiToiDa)
        Assert.AreEqual(expected.TuoiToiThieu, act.TuoiToiThieu)
        Assert.AreEqual(expected.ThoiHanToiDaTheDocGia, act.ThoiHanToiDaTheDocGia)
        Assert.AreEqual(expected.ThoiHanNhanSach, act.ThoiHanNhanSach)

    End Sub
#End Region
End Class