Imports System.Text
Imports BUS
Imports DTO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility

<TestClass()> Public Class DocGiaBusTest

    <TestMethod()> Public Sub ValidGetLoaiDocGia()
        'arr
        Dim expected = New Result()
        Dim docGiaBus = New DocGiaBus()
        'act
        Dim act = docGiaBus.GetLoaiDocGia()
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub
    <TestMethod()> Public Sub ValidGetQuidinh()
        'arr
        Dim expected = New Result()
        Dim docGiaBus = New DocGiaBus()
        'act
        Dim act = docGiaBus.GetQuiDinh()
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub
#Region "Insert one test"
    <TestMethod()> Public Sub GivenLowYearsold_WhenInsertOne_ThenGiveFalseResult()
        'arr
        Dim expected = New Result("False", "Tuổi chưa đủ để lập thẻ", "")
        Dim docGia = New DocGia(1, "ahiinh", "123@gmail.com", "122c",
                      New DateTime(2008, 1, 1), DateTime.Now, DateTime.Now.AddMonths(6), 1)
        Dim docGiaBus = New DocGiaBus()
        'act
        Dim act = docGiaBus.InsertOne(docGia)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
        Assert.AreEqual(expected.ApplicationMessage, act.ApplicationMessage)
    End Sub
    <TestMethod()> Public Sub GivenHightYearsold_WhenInsertOne_ThenGiveFalseResult()
        'arr
        Dim expected = New Result("False", "Tuổi quá lớn để lập thẻ", "")
        Dim docGia = New DocGia(1, "ahiinh", "123@gmail.com", "122c",
                      New DateTime(1000, 1, 1), DateTime.Now, DateTime.Now.AddMonths(6), 1)
        Dim docGiaBus = New DocGiaBus()
        'act
        Dim act = docGiaBus.InsertOne(docGia)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
        Assert.AreEqual(expected.ApplicationMessage, act.ApplicationMessage)
    End Sub
    <TestMethod()> Public Sub GivenInvalidLoaiDocGia_WhenInsertOne_ThenGiveFalseResult()
        'arr
        Dim expected = New Result("False", "Lỗi nhập vào kiểu người dùng", "")
        Dim docGia = New DocGia(1, "ahiinh", "123@gmail.com", "122c",
                      New DateTime(1998, 1, 1), DateTime.Now, DateTime.Now.AddMonths(6), 100)
        Dim docGiaBus = New DocGiaBus()
        'act
        Dim act = docGiaBus.InsertOne(docGia)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
        Assert.AreEqual(expected.ApplicationMessage, act.ApplicationMessage)
    End Sub

    <TestMethod()> Public Sub GivenInvalidEmail_WhenInsertOne_ThenGiveFalseResult()
        'arr
        Dim expected = New Result("False", "Email không đúng định dạng,ví dụ: 123@gmail.com", "")
        Dim docGia = New DocGia(1, "ahiinh", "123mail.com", "122c",
                      New DateTime(1998, 1, 1), DateTime.Now, DateTime.Now.AddMonths(6), 1)
        Dim docGiaBus = New DocGiaBus()
        'act
        Dim act = docGiaBus.InsertOne(docGia)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
        Assert.AreEqual(expected.ApplicationMessage, act.ApplicationMessage)
    End Sub
#End Region
End Class