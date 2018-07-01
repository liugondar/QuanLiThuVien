Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility

<TestClass()> Public Class DataProviderTest
#Region "excute nonquery test"
    <TestMethod()> Public Sub givenInvalidQuery_WhenExcutingNonquery_thenFalseResultReturned()
        'Arrange
        Dim dataProvider = New DataProvider()
        Dim arrange = New Result(False, "", "")
        'Actual
        Dim actual = dataProvider.ExecuteNonquery("EXECUTE USP_ThemTheDocGia ")
        'Assert
        Assert.AreEqual(arrange.FlagResult, actual.FlagResult)
    End Sub
    <TestMethod()> Public Sub givenEmptyQuery_WhenExcutingNonquery_thenFalseResultReturned()
        'Arrange
        Dim dataProvider = New DataProvider()
        Dim arrange = New Result(False, "Dữ liệu nhập vào không hợp lệ", "")
        'Actual
        Dim actual = dataProvider.ExecuteNonquery("")
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
        Dim actual = dataProvider.ExecuteQuery("Select * from TheDocGia", New DataTable())
        'Assert
        Assert.AreEqual(arrange.FlagResult, actual.FlagResult)
    End Sub

    <TestMethod()> Public Sub givenInvalidQuery_WhenExcutingquery_thenFalseResultReturned()
        'Arrange
        Dim dataProvider = New DataProvider()
        Dim arrange = New Result(False, "", "")
        'Actual
        Dim actual = dataProvider.ExecuteQuery("Seleklct * from 12345 ", New DataTable())
        'Assert
        Assert.AreEqual(arrange.FlagResult, actual.FlagResult)
    End Sub
    <TestMethod()> Public Sub givenEmptyQuery_WhenExcutingquery_thenFalseResultReturned()
        'Arrange
        Dim dataProvider = New DataProvider()
        Dim arrange = New Result(False, "Không thể lấy dữ liệu", "")
        'Actual
        Dim actual = dataProvider.ExecuteQuery("", New DataTable())
        'Assert
        Assert.AreEqual(arrange.FlagResult, actual.FlagResult)
        Assert.AreEqual(arrange.ApplicationMessage, actual.ApplicationMessage)
    End Sub
#End Region
End Class