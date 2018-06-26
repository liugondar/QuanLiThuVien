Imports System.Text
Imports DTO
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class ChiTietBaoCaoTinhHinhMuonSachTheoTheLoaiTest

    <TestMethod()> Public Sub GivenValidRow_WhenRowConstructoring_ThenValidValuesReturned()
        'arrange
        Dim namesTable As DataTable = New DataTable("Names")
        Dim table = New DataTable()

        table.Columns.Add("MaChiTietBaoCaoTinhHinhMuonSachTheoTheLoai", GetType(String))
        table.Columns.Add("MaBaoCaoTinhHinhMuonSachTheoTheLoai", GetType(String))
        table.Columns.Add("MaTheLoaiSach", GetType(String))
        table.Columns.Add("SoLuongMuon", GetType(String))
        table.Columns.Add("TiLe", GetType(String))
        table.Columns.Add("DeleteFlag", GetType(String))
        table.Rows.Add("1", "1", "1", "1", "0.9", "N")


        Dim expected = New ChiTietBaoCaoTinhHinhMuonSachTheoTheLoai(1, 1, 1, 1, 0.9)

        'act
        Dim act = New ChiTietBaoCaoTinhHinhMuonSachTheoTheLoai(table.Rows(0))

        'assert
        Assert.AreEqual(expected.MaBaoCaoTinhHinhMuonSachTheoTheLoai, act.MaBaoCaoTinhHinhMuonSachTheoTheLoai)
        Assert.AreEqual(expected.MaChiTietBaoCaoTinhHinhMuonSachTheoTheLoai, act.MaChiTietBaoCaoTinhHinhMuonSachTheoTheLoai)
        Assert.AreEqual(expected.MaTheLoaiSach, act.MaTheLoaiSach)
        Assert.AreEqual(expected.SoLuongMuon, act.SoLuongMuon)
        Assert.AreEqual(expected.TiLe, act.TiLe)
    End Sub

End Class