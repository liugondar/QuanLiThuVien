Imports System.Text
Imports BUS
Imports DTO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility

<TestClass()> Public Class QuiDinhBustest
#Region "Select test"
    <TestMethod()> Public Sub ValidSelectallTest()
        'arr
        Dim quiDinhBus = New QuiDinhBus()
        Dim expected = New Result()
        'act
        Dim quiDinh = New QuiDinh
        Dim actual = quiDinhBus.SelectAll(quiDinh)
        'assert
        Assert.AreEqual(expected.FlagResult, actual.FlagResult)
    End Sub

#End Region

End Class