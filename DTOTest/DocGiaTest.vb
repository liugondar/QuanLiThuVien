Imports System.Text
Imports DTO
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class DocGiaTest

    <TestMethod()> Public Sub GivenValidRow_ToRowConstructor_ThenValidValuesReturn()
        'arrange
        Dim namesTable As DataTable = New DataTable("Names")
        Dim table = New DataTable()

        table.Columns.Add("MaTheDocGia", GetType(Integer))
        table.Columns.Add("TenDocGia", GetType(String))
        table.Columns.Add("Email", GetType(String))
        table.Columns.Add("DiaChi", GetType(String))
        table.Columns.Add("NgaySinh", GetType(DateTime))
        table.Columns.Add("NgayTao", GetType(DateTime))
        table.Columns.Add("NgayHetHan", GetType(DateTime))
        table.Columns.Add("MaLoaiDocGia", GetType(Integer))
        table.Rows.Add(1, "Dinh", "123@gmail.com", "122c",
                      New DateTime(1998, 1, 1), New DateTime(1998, 1, 1), New DateTime(1998, 1, 1).AddMonths(6), 1)

        Dim expected = New DocGia(1, "Dinh", "123@gmail.com", "122c",
                      New DateTime(1998, 1, 1), New DateTime(1998, 1, 1), New DateTime(1998, 1, 1).AddMonths(6), 1)
        'act
        Dim act = New DocGia(table.Rows(0))
        'assert
        Assert.AreEqual(expected.MaTheDocGia, act.MaTheDocGia)
        Assert.AreEqual(expected.TenDocGia, act.TenDocGia)
        Assert.AreEqual(expected.Email, act.Email)
        Assert.AreEqual(expected.DiaChi, act.DiaChi)
        Assert.AreEqual(expected.NgaySinh, act.NgaySinh)
        Assert.AreEqual(expected.NgayTao, act.NgayTao)
        Assert.AreEqual(expected.NgayHetHan, act.NgayHetHan)
        Assert.AreEqual(expected.MaLoaiDocGia, act.MaLoaiDocGia)

    End Sub
    <TestMethod()> Public Sub GivenInvalidRow_ToRowConstructor_ThenInvalidValuesReturn()
        'arrange
        Dim namesTable As DataTable = New DataTable("Names")
        Dim table = New DataTable()

        table.Columns.Add("Mffa", GetType(Integer))
        table.Columns.Add("Ten", GetType(String))
        table.Columns.Add("Email", GetType(String))
        table.Columns.Add("Di", GetType(String))
        table.Columns.Add("Naag", GetType(DateTime))
        table.Columns.Add("", GetType(DateTime))
        table.Columns.Add("gon", GetType(DateTime))
        table.Columns.Add("Ma", GetType(Integer))
        table.Rows.Add(1, "Dinh", "123@gmail.com", "122c",
                      New DateTime(1998, 1, 1), New DateTime(1998, 1, 1), New DateTime(1998, 1, 1).AddMonths(6), 1)

        Dim expected = New DocGia(0, "", "", "",
                      DateTime.Now, DateTime.Now, DateTime.Now, 0)
        'act
        Dim act = New DocGia(table.Rows(0))
        'assert
        Assert.AreEqual(expected.MaTheDocGia, act.MaTheDocGia)
        Assert.AreEqual(expected.TenDocGia, act.TenDocGia)
        Assert.AreEqual(expected.Email, act.Email)
        Assert.AreEqual(expected.DiaChi, act.DiaChi)
        Assert.AreEqual(expected.MaLoaiDocGia, act.MaLoaiDocGia)

    End Sub

End Class