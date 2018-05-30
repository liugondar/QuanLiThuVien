Imports System.Text
Imports BUS
Imports DTO
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class QuiDinhBustest
#Region "Select all test"
    <TestMethod()> Public Sub ValidSelectallTest()
        'arr
        Dim quiDinhBus = New QuiDinhBus()
        Dim expected = New List(Of QuiDinh)
        expected.Add(New QuiDinh(18, 55, 6))
        'act
        Dim actual = New List(Of QuiDinh)
        Dim result = quiDinhBus.SelectAll(actual)
        'assert
        Assert.AreEqual(result.FlagResult, True)
        Assert.AreEqual(expected.Count, actual.Count)
    End Sub
#End Region
End Class