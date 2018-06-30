﻿Imports System.Text
Imports BUS
Imports DAO
Imports DTO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility

<TestClass()> Public Class DocGiaBusTest

#Region "Insert one test"
    <TestMethod()> Public Sub ValidGetQuidinh()
        'arr
        Dim expected = New Result()
        Dim docGiaBus = New DocGiaBus()
        'act
        Dim act = docGiaBus.GetQuiDinh()
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub
    <TestMethod()> Public Sub GivenValidDocGia_WhenInsertOne_ThenGiveTrueResult()
        'arr
        Dim expected = New Result()
        Dim maDocGia = 0
        Dim docGiaDao = New DocGiaDAO()
        docGiaDao.GetTheLastTheDocGiaID(maDocGia)
        maDocGia = maDocGia + 1
        Dim docGia = New DocGia(maDocGia, "ahiinh", "123@gmail.com", "122c",
                      New DateTime(1998, 1, 1), DateTime.Now, DateTime.Now.AddMonths(6), 1)
        Dim docGiaBus = New DocGiaBus()
        'act
        Dim act = docGiaBus.InsertOne(docGia)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
        Assert.AreEqual(expected.ApplicationMessage, act.ApplicationMessage)
    End Sub
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
        Dim expected = New Result("False", "Lỗi chọn sai kiểu độc giả", "")
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

#Region "Select test"
    <TestMethod()> Public Sub ValidSelectAllByTypeTest()
        'arr
        Dim expected = New Result()
        Dim docGiaBus = New DocGiaBus()
        'act
        Dim act = docGiaBus.SelectAllByType(1, New List(Of DocGia))
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub

    <TestMethod()> Public Sub ValidSelectNameByIDTest()
        'arr
        Dim expected = New Result()
        Dim docGiaBus = New DocGiaBus()
        Dim tendocGia = String.Empty
        Dim maTheDocGia = String.Empty
        Dim docGiaDao = New DocGiaDAO()

        'act

        Dim act = New Result()
        If docGiaDao.GetTheLastTheDocGiaID(maTheDocGia).FlagResult Then
            act = docGiaBus.GetReaderNameById(tendocGia, maTheDocGia)
        End If
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub
#End Region

#Region "Sửa thẻ độc giả test"
    <TestMethod()> Public Sub ValidSuaTheDocGiaByTypeTest()
        'arr
        Dim expected = New Result()
        Dim docGiaBus = New DocGiaBus()
        Dim docGiaDao = New DocGiaDAO()
        Dim maDocGia = String.Empty
        'act
        Dim act = New Result()
        If docGiaDao.GetTheLastTheDocGiaID(maDocGia).FlagResult Then
            Dim docGia = New DocGia(1, "ahiinh", "123@gmail.com", "122c",
                      New DateTime(1998, 1, 1), DateTime.Now, DateTime.Now.AddMonths(6), 1)

            act = docGiaBus.UpdateById(docGia)
        End If
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub
    <TestMethod()> Public Sub GivenInvalidDocGia_WhenEditDocGia_ThenFalseResultReturned()
        'arr
        Dim expected = New Result("False", "Email không đúng định dạng,ví dụ: 123@gmail.com", "")
        Dim docGiaBus = New DocGiaBus()
        Dim docGia = New DocGia(1, "", "123mail.com", "122c",
                      New DateTime(198, 1, 1), DateTime.Now, DateTime.Now.AddMonths(6), 1)

        'act
        Dim act = docGiaBus.UpdateById(docGia)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub
    <TestMethod()> Public Sub GivenInvalidEmailFormat_WhenEditDocGia_ThenFalseResultReturned()
        'arr
        Dim expected = New Result("False", "Email không đúng định dạng,ví dụ: 123@gmail.com", "")
        Dim docGiaBus = New DocGiaBus()
        Dim docGia = New DocGia(1, "ahiinh", "123mail.com", "122c",
                      New DateTime(1998, 1, 1), DateTime.Now, DateTime.Now.AddMonths(6), 1)

        'act
        Dim act = docGiaBus.UpdateById(docGia)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
        Assert.AreEqual(expected.ApplicationMessage, act.ApplicationMessage)
    End Sub
    <TestMethod()> Public Sub GivenEmptyEmail_WhenEditDocGia_ThenFalseResultReturned()
        'arr
        Dim expected = New Result("False", "Email không đúng định dạng,ví dụ: 123@gmail.com", "")
        Dim docGiaBus = New DocGiaBus()
        Dim docGia = New DocGia(1, "ahiinh", "", "122c",
                      New DateTime(1998, 1, 1), DateTime.Now, DateTime.Now.AddMonths(6), 1)

        'act
        Dim act = docGiaBus.UpdateById(docGia)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
        Assert.AreEqual(expected.ApplicationMessage, act.ApplicationMessage)
    End Sub

    <TestMethod()> Public Sub GivenEmptyUserName_WhenEditDocGia_ThenFalseResultReturned()
        'arr
        Dim expected = New Result("False", "Tên độc giả không đúng định dạng", "")
        Dim docGiaBus = New DocGiaBus()
        Dim docGia = New DocGia(1, "", "123@mail.com", "122c",
                      New DateTime(1998, 1, 1), DateTime.Now, DateTime.Now.AddMonths(6), 1)

        'act
        Dim act = docGiaBus.UpdateById(docGia)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
        Assert.AreEqual(expected.ApplicationMessage, act.ApplicationMessage)
    End Sub

    <TestMethod()> Public Sub GivenHightYearsold_WhenEditDocGia_ThenFalseResultReturned()
        'arr
        Dim expected = New Result("False", "Tuổi quá lớn để lập thẻ", "")
        Dim docGiaBus = New DocGiaBus()
        Dim docGia = New DocGia(1, "idfasfd", "123@mail.com", "122c",
                      New DateTime(199, 1, 1), DateTime.Now, DateTime.Now.AddMonths(6), 1)

        'act
        Dim act = docGiaBus.UpdateById(docGia)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
        Assert.AreEqual(expected.ApplicationMessage, act.ApplicationMessage)
    End Sub
    <TestMethod()> Public Sub GivenLow_WhenEditDocGia_ThenFalseResultReturned()
        'arr
        Dim expected = New Result("False", "Tuổi chưa đủ để lập thẻ", "")
        Dim docGiaBus = New DocGiaBus()
        Dim docGia = New DocGia(1, "fasdf", "123@mail.com", "122c",
                      New DateTime(2010, 1, 1), DateTime.Now, DateTime.Now.AddMonths(6), 1)

        'act
        Dim act = docGiaBus.UpdateById(docGia)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
        Assert.AreEqual(expected.ApplicationMessage, act.ApplicationMessage)
    End Sub

    <TestMethod()> Public Sub GivenInvalidLoaiDocGia_WhenEditDocGia_ThenFalseResultReturned()
        'arr
        Dim expected = New Result("False", "Tuổi chưa đủ để lập thẻ", "")
        Dim docGiaBus = New DocGiaBus()
        Dim docGia = New DocGia(1, "fasdf", "123@mail.com", "122c",
                      New DateTime(2010, 1, 1), DateTime.Now, DateTime.Now.AddMonths(6), 5)

        'act
        Dim act = docGiaBus.UpdateById(docGia)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
        Assert.AreEqual(expected.ApplicationMessage, act.ApplicationMessage)
    End Sub
#End Region

#Region "Xoá thẻ độc giả test"
    <TestMethod()> Public Sub GivenValidMathe_WhenXoaTheDocGiaBangMaThe_ThenTrueResultReturned()
        'arr
        Dim expected = New Result()
        Dim docGiaBus = New DocGiaBus()
        Dim listDocGia = New List(Of DocGia)
        Dim result = docGiaBus.SelectAllByType(1, listDocGia)
        'act
        Dim act = docGiaBus.DeleteByID(listDocGia(0).MaTheDocGia)
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
    End Sub

    <TestMethod()> Public Sub GivenEmptyMathe_WhenXoaTheDocGiaBangMaThe_ThenTrueResultReturned()
        'arr
        Dim expected = New Result(False, "Mã thẻ độc giả không được để trống", "")
        Dim docGiaBus = New DocGiaBus()
        'act
        Dim act = docGiaBus.DeleteByID("")
        'assert
        Assert.AreEqual(expected.FlagResult, act.FlagResult)
        Assert.AreEqual(expected.ApplicationMessage, act.ApplicationMessage)
    End Sub
#End Region
End Class