Imports DAO
Imports DTO
Imports Utility
<TestClass()> Public Class BaoCaoSachTraTreDAOTest
    <TestMethod()> Public Sub ValidInsertOne()
        'arr
        Dim baoCaoSachTraTreDao = New BaoCaoSachTraTreDAO()
        Dim baoCao = New BaoCaoSachTraTre()
        baoCao.ThoiGian = DateTime.Now

        Dim expected = New Result()
        'act
        Dim act = baoCaoSachTraTreDao.InsertOne(baoCao)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub

    <TestMethod()> Public Sub ValidGetTheLastID()
        'arr
        Dim baoCaoSachTraTreDao = New BaoCaoSachTraTreDAO()
        Dim id = String.Empty

        Dim expected = New Result()
        'act
        Dim act = baoCaoSachTraTreDao.GetTheLastID(id)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub
End Class
