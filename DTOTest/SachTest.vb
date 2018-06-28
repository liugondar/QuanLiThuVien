Imports System.Text
Imports DTO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility

<TestClass()> Public Class SachTest

#Region "Constructor test"
    <TestMethod()> Public Sub GivenValidRow_WhenRowConstructoring_ThenValidValuesReturned()
        'arrange
        Dim namesTable As DataTable = New DataTable("Names")
        Dim table = New DataTable()

        table.Columns.Add("MaSach", GetType(String))
        table.Columns.Add("MaTheLoaiSach", GetType(String))
        table.Columns.Add("MaTacGia", GetType(String))
        table.Columns.Add("TenSach", GetType(String))
        table.Columns.Add("TenNhaXuatBan", GetType(String))
        table.Columns.Add("NgayNhap", GetType(DateTime))
        table.Columns.Add("NgayXuatBan", GetType(DateTime))
        table.Columns.Add("TriGia", GetType(String))
        table.Columns.Add("TinhTrang", GetType(String))
        table.Rows.Add("1", "1", "1", "Di ve dau", "Kim dong",
                      New DateTime(1998, 1, 1), New DateTime(1998, 1, 1), "10000", 0)

        Dim expected = New Sach(1, "Di ve dau", 1, 1, "Kim dong",
New DateTime(1998, 1, 1), New DateTime(1998, 1, 1), 10000, 0)

        'act
        Dim act = New Sach(table.Rows(0))

        'assert
        Assert.AreEqual(expected.MaSach, act.MaSach)
        Assert.AreEqual(expected.MaTacGia, act.MaTacGia)
        Assert.AreEqual(expected.MaTheLoaiSach, act.MaTheLoaiSach)
        Assert.AreEqual(expected.TenNhaXuatBan, act.TenNhaXuatBan)
        Assert.AreEqual(expected.TenSach, act.TenSach)
        Assert.AreEqual(expected.NgayNhap, act.NgayNhap)
        Assert.AreEqual(expected.NgayXuatBan, act.NgayXuatBan)
        Assert.AreEqual(expected.TriGia, act.TriGia)
    End Sub
    <TestMethod()> Public Sub GivenInvalidRow_WhenRowConstructoring_ThenDefaultValuesReturned()
        'arrange
        Dim namesTable As DataTable = New DataTable("Names")
        Dim table = New DataTable()

        table.Columns.Add("MaSfdasfach", GetType(String))
        table.Columns.Add("MaThefdLoaiSach", GetType(String))
        table.Columns.Add("MaTafdcfdfGia", GetType(String))
        table.Columns.Add("TenSach", GetType(String))
        table.Columns.Add("TenNhfdaXuatBan", GetType(String))
        table.Columns.Add("NgayNfdhap", GetType(DateTime))
        table.Columns.Add("NgayXduatBan", GetType(DateTime))
        table.Columns.Add("TriGiaa", GetType(String))
        table.Rows.Add("1", "1", "1", "Di ve dau", "Kim dong",
                      New DateTime(1998, 1, 1), New DateTime(1998, 1, 1), "10000")

        Dim expected = New Sach()

        'act
        Dim act = New Sach(table.Rows(0))

        'assert
        Assert.AreEqual(expected.MaSach, act.MaSach)
        Assert.AreEqual(expected.MaTacGia, act.MaTacGia)
        Assert.AreEqual(expected.MaTheLoaiSach, act.MaTheLoaiSach)
        Assert.AreEqual(expected.TenNhaXuatBan, act.TenNhaXuatBan)
        Assert.AreEqual(expected.TenSach, act.TenSach)
        Assert.AreEqual(expected.NgayNhap, act.NgayNhap)
        Assert.AreEqual(expected.NgayXuatBan, act.NgayXuatBan)
        Assert.AreEqual(expected.TriGia, act.TriGia)
    End Sub

#End Region
#Region "Validate testing"
    <TestMethod()> Public Sub GivenValidValue_WhenValidating_ThenTrueResultReturned()
        'arrange
        Dim expected = New Result()
        'act
        Dim sach = New Sach(1, "Di ve dau", 1, 1, "Kim dong",
New DateTime(1998, 1, 1), New DateTime(1998, 1, 1), 10000)
        Dim act = sach.ValidateTenSachAndTenNhaXuatBan()

        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub

    <TestMethod()> Public Sub GivenInvalidTenSach_WhenValidating_ThenFalseResultReturned()
        'arrange
        Dim expected = New Result(False, "Tên sách không đúng định dạng!", "")
        'act
        Dim sach = New Sach(0, "", 1, 1, "Kim dong",
New DateTime(1998, 1, 1), New DateTime(1998, 1, 1), 10000)
        Dim act = sach.ValidateTenSachAndTenNhaXuatBan()

        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
        Assert.AreEqual(expected.ApplicationMessage, act.ApplicationMessage)
    End Sub

    <TestMethod()> Public Sub GivenInvalidTenNhaXuatBan_WhenValidating_ThenFalseResultReturned()
        'arrange
        Dim expected = New Result(False, "Tên nhà xuất bản không đúng định dạng!", "")
        'act
        Dim sach = New Sach(0, "12334", 1, 1, "",
New DateTime(1998, 1, 1), New DateTime(1998, 1, 1), 10000)
        Dim act = sach.ValidateTenSachAndTenNhaXuatBan()

        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
        Assert.AreEqual(expected.ApplicationMessage, act.ApplicationMessage)
    End Sub
#End Region
End Class