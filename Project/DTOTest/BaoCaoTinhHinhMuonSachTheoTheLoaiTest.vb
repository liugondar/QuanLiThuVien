Imports DTO
Imports Utility
<TestClass()> Public Class BaoCaoTinhHinhMuonSachTheoTheLoaiTest
    <TestMethod()> Public Sub GivenValidRow_WhenRowConstructoring_ThenValidValuesReturned()
        'arrange
        Dim namesTable As DataTable = New DataTable("Names")
        Dim table = New DataTable()

        table.Columns.Add("MaBaoCaoTinhHinhMuonSachTheoTheLoai", GetType(String))
        table.Columns.Add("ThoiGian", GetType(String))
        table.Columns.Add("TongSoLuotMuon", GetType(String))
        table.Columns.Add("DeleteFlag", GetType(String))
        table.Rows.Add("1", "01/01/2000", "1", "N")


        Dim expected = New BaoCaoTinhHinhMuonSachTheoTheLoai(1, New DateTime(2000, 1, 1), 1)

        'act
        Dim act = New BaoCaoTinhHinhMuonSachTheoTheLoai(table.Rows(0))

        'assert
        Assert.AreEqual(expected.MaBaoCaoTinhHinhMuonSachTheoTheLoai, act.MaBaoCaoTinhHinhMuonSachTheoTheLoai)
        Assert.AreEqual(expected.ThoiGian, act.ThoiGian)
        Assert.AreEqual(expected.TongSoLuotMuon, act.TongSoLuotMuon)
    End Sub
End Class
