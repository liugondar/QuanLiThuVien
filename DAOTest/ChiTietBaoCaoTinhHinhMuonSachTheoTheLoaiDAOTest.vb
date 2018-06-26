Imports DAO
Imports Utility

<TestClass()> Public Class ChiTietBaoCaoTinhHinhMuonSachTheoTheLoaiDAOTest
    <TestMethod()> Public Sub ValidInsertOne()
        'arr
        Dim expected = New Result()
        Dim ChiTietbaoCaoTinhHinhMuonSachDAO = New DAO.ChiTietBaoCaoTinhHinhMuonSachTheoTheLoaiDAO()
        Dim ChiTietbaoCaoTinhHinhMuonSach = New DTO.ChiTietBaoCaoTinhHinhMuonSachTheoTheLoai()
        ChiTietbaoCaoTinhHinhMuonSach.MaBaoCaoTinhHinhMuonSachTheoTheLoai = 1
        ChiTietbaoCaoTinhHinhMuonSach.MaTheLoaiSach = 1
        ChiTietbaoCaoTinhHinhMuonSach.SoLuongMuon = 2
        ChiTietbaoCaoTinhHinhMuonSach.TiLe = 0.7
        'act
        Dim act = ChiTietbaoCaoTinhHinhMuonSachDAO.InsertOne(ChiTietbaoCaoTinhHinhMuonSach)
        'asert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub

    <TestMethod()> Public Sub ValidSelectByMaBaoCaoTinhHinhMuonSachTheoTheLoai()
        'arr
        Dim expected = New Result()
        Dim ChiTietbaoCaoTinhHinhMuonSachDAO = New DAO.ChiTietBaoCaoTinhHinhMuonSachTheoTheLoaiDAO()
        Dim listOfChiTietbaoCaoTinhHinhMuonSach = New List(Of DTO.ChiTietBaoCaoTinhHinhMuonSachTheoTheLoai)

        Dim maBaoCAo = String.Empty
        Dim baocaoDaO = New BaoCaoTinhHinhMuonSachTheoTheLoaiDAO()
        Dim act = New Result()
        If baocaoDaO.GetTheLastID(maBaoCAo).FlagResult = True Then
            act = ChiTietbaoCaoTinhHinhMuonSachDAO.SelectAllByMaBaoCaoTinhHinhMuonSachTheoTheLoai(listOfChiTietbaoCaoTinhHinhMuonSach, maBaoCAo)
        End If
        'act
        'asert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub

End Class
