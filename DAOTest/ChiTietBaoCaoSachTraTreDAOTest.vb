Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility
Imports DAO
Imports DTO
Imports BUS

<TestClass()> Public Class ChiTietBaoCaoSachTraTreDAOTest

    <TestMethod()> Public Sub ValidGetSoNgayTreAndMaChiTietPhieuMuonSachByDate()
        'arr
        Dim expected = New Result()
        Dim chiTietBaoCaoDAo = New ChiTietBaoCaoSachTraTreDAO()
        'act
        Dim actual = chiTietBaoCaoDAo.GetSoNgayTreAndMaChiTietPhieuMuonSachByDate(New List(Of ChiTietBaoCaoSachTraTre), DateTime.Now)
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub

    <TestMethod()> Public Sub ValidSelectAllByMaBaoCao()
        'arr
        Dim expected = New Result()
        Dim chiTietBaoCaoDAo = New ChiTietBaoCaoSachTraTreDAO()
        Dim maBaoCao = String.Empty
        Dim baoCaoBus = New BaoCaoSachTraTreBus()
        Dim actual = New Result
        'act
        If Not baoCaoBus.GetTheLastID(maBaoCao).FlagResult Then
            actual = chiTietBaoCaoDAo.SelectAllByMaBaoCaoSachTraTre(New List(Of ChiTietBaoCaoSachTraTre), maBaoCao)
        End If
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub


End Class