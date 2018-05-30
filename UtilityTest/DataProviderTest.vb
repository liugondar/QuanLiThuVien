Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility

<TestClass()> Public Class DataProviderTest
#Region "excute nonquery test"
    <TestMethod()> Public Sub givenValidQuery_WhenExcutingNonquery_thenTrueResultReturned()
        'Arrange
        Dim dataProvider = New DataProvider()
        Dim arrange = New Result()
        'Actual
        Dim actual = dataProvider.ExcuteNonquery("EXECUTE USP_ThemTheDocGia @TenDocGia=N'Dinh',@Email=N'ahihi',@DiaChi =N'122c',@MaLoaiDocGia=1,@NgaySinh='1/1/1998',@NgayTao='5/30/2018 12:40:29 AM',@NgayHetHan='11/30/2018 12:40:29 AM'")
        'Assert
        Assert.AreEqual(arrange.FlagResult, actual.FlagResult)
    End Sub

    <TestMethod()> Public Sub givenInvalidQuery_WhenExcutingNonquery_thenFalseResultReturned()
        'Arrange
        Dim dataProvider = New DataProvider()
        Dim arrange = New Result(False, "", "")
        'Actual
        Dim actual = dataProvider.ExcuteNonquery("EXECUTE USP_ThemTheDocGia ")
        'Assert
        Assert.AreEqual(arrange.FlagResult, actual.FlagResult)
    End Sub
    <TestMethod()> Public Sub givenEmptyQuery_WhenExcutingNonquery_thenFalseResultReturned()
        'Arrange
        Dim dataProvider = New DataProvider()
        Dim arrange = New Result(False, "Dữ liệu nhập vào không hợp lệ", "")
        'Actual
        Dim actual = dataProvider.ExcuteNonquery("")
        'Assert
        Assert.AreEqual(arrange.FlagResult, actual.FlagResult)
        Assert.AreEqual(arrange.ApplicationMessage, actual.ApplicationMessage)
    End Sub
#End Region

#Region "Excute query test "
    <TestMethod()> Public Sub givenValidQuery_WhenExcutingQuery_thenTrueResultReturned()
        'Arrange
        Dim dataProvider = New DataProvider()
        Dim arrange = New Result()
        'Actual
        Dim actual = dataProvider.ExcuteQuery("Select * from TheDocGia", New DataTable())
        'Assert
        Assert.AreEqual(arrange.FlagResult, actual.FlagResult)
    End Sub

    <TestMethod()> Public Sub givenInvalidQuery_WhenExcutingquery_thenFalseResultReturned()
        'Arrange
        Dim dataProvider = New DataProvider()
        Dim arrange = New Result(False, "", "")
        'Actual
        Dim actual = dataProvider.ExcuteQuery("Seleklct * from 12345 ", New DataTable())
        'Assert
        Assert.AreEqual(arrange.FlagResult, actual.FlagResult)
    End Sub
    <TestMethod()> Public Sub givenEmptyQuery_WhenExcutingquery_thenFalseResultReturned()
        'Arrange
        Dim dataProvider = New DataProvider()
        Dim arrange = New Result(False, "Không thể lấy dữ liệu", "")
        'Actual
        Dim actual = dataProvider.ExcuteQuery("", New DataTable())
        'Assert
        Assert.AreEqual(arrange.FlagResult, actual.FlagResult)
        Assert.AreEqual(arrange.ApplicationMessage, actual.ApplicationMessage)
    End Sub
#End Region
End Class