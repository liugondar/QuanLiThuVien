﻿Imports System.Text.RegularExpressions
Imports DAO
Imports DTO
Imports Utility

Public Class DocGiaBus
    Private _docGiaDAO As DocGiaDAO
    Private _quiDinh As QuiDinh
    Private _listLoaiDocGia As List(Of LoaiDocGia)
    Private _ketQuaViecLayQuiDinh As Result
    Private _ketQuaViecLayLoaiDocGia As Result

    Public Sub New()
        _docGiaDAO = New DocGiaDAO()
        _quiDinh = New QuiDinh()
        _listLoaiDocGia = New List(Of LoaiDocGia)
        _ketQuaViecLayQuiDinh = GetQuiDinh()
        _ketQuaViecLayLoaiDocGia = GetLoaiDocGia()
    End Sub

    Public Function GetLoaiDocGia() As Result
        Dim loaiDocGiaBus = New LoaiDocGiaBus()
        Dim result = loaiDocGiaBus.SelectAll(_listLoaiDocGia)
        If _listLoaiDocGia.Count < 1 Then
            Return New Result(False, "Không thể lấy danh sách loại đôc giả", "")
        End If
        Return result
    End Function

    Public Function GetQuiDinh() As Result
        Dim quiDinhBus As QuiDinhBus = New QuiDinhBus()
        Dim layTuoiToiDaResult = quiDinhBus.LayTuoiToiDaVaToiThieu(_quiDinh)
        Dim layThoiHanResult = quiDinhBus.LayThoiHanToiDaTheDocGia(_quiDinh)
        If layThoiHanResult.FlagResult = False Then Return layThoiHanResult
        If layTuoiToiDaResult.FlagResult = False Then Return layTuoiToiDaResult
        Return New Result()
    End Function

    Public Function InsertOne(docGia As DocGia) As Result
        If ValidateAll(docGia).FlagResult = False Then
            Return ValidateAll(docGia)
        End If
        docGia.NgayHetHan = docGia.NgayTao.AddMonths(_quiDinh.ThoiHanToiDaTheDocGia)
        Return _docGiaDAO.InsertOne(docGia)
    End Function

    Private Function ValidateAll(docGia As DocGia) As Result
        Dim validateUserNameAndEmailResult = docGia.Validate()
        Dim validateYearsoldResult = ValidateYearsold(docGia.NgaySinh)
        Dim validateReaderTypeResult = ValidateReaderType(docGia.MaLoaiDocGia)

        If validateUserNameAndEmailResult.FlagResult = False Then Return validateUserNameAndEmailResult
        If validateYearsoldResult.FlagResult = False Then Return validateYearsoldResult
        If validateReaderTypeResult.FlagResult = False Then Return validateReaderTypeResult

        Return New Result(True)
    End Function


    Public Function SelectAllByType(maLoai As String, ByRef listDocGia As List(Of DocGia)) As Result
        If String.IsNullOrWhiteSpace(maLoai) Then
            Return New Result(False, "Mã loại độc giả không đúng!", "")
        End If
        Dim result = _docGiaDAO.SelectAllByType(maLoai, listDocGia)
        If listDocGia.Count < 1 Then
            Return New Result(False, "Danh sách các độc giả thuộc loại đang chọn hiện chưa có thành viên", "")
        End If
        Return result
    End Function

    Public Function SuaTheDocGiaBangDocGia(docGia As DocGia) As Result
        Dim validateResult = docGia.Validate()
        Dim validateYearsoldResult = ValidateYearsold(docGia.NgaySinh)
        Dim validateReaderTypeResult = ValidateReaderType(docGia.MaLoaiDocGia)

        If validateResult.FlagResult = False Then Return validateResult
        If validateYearsoldResult.FlagResult = False Then Return validateYearsoldResult
        If validateReaderTypeResult.FlagResult = False Then Return validateReaderTypeResult

        Dim result = _docGiaDAO.SuaTheDocGiaBangDocGia(docGia)
        Return result
    End Function
    Private Function ValidateReaderType(loaiDocGiaId As Integer) As Result
        Dim isMatchingValue = _listLoaiDocGia.Find(Function(x) x.MaLoaiDocGia = loaiDocGiaId)

        If isMatchingValue Is Nothing Then
            Return New Result(False, "Lỗi chọn sai kiểu độc giả", "")
        End If
        Return New Result(True)
    End Function

    Private Function ValidateYearsold(ngaySinh As Date) As Object
        Dim dateNow As Date = Date.Now()
        Dim yearsold = (dateNow - ngaySinh).TotalDays \ 365
        If yearsold < _quiDinh.TuoiToiThieu Then
            Return New Result(False, "Tuổi chưa đủ để lập thẻ", "")
        End If
        If yearsold > _quiDinh.TuoiToiDa Then
            Return New Result(False, "Tuổi quá lớn để lập thẻ", "")
        End If
        Return New Result(True)
    End Function

    Public Function XoaTheDocGiaBangMaThe(maThe As String) As Result
        If String.IsNullOrWhiteSpace(maThe) Then Return New Result(False, "Mã thẻ độc giả không được để trống", "")
        Dim result = _docGiaDAO.XoaTheDocGiaBangMaTheDocGia(maThe)
        Return result
    End Function
End Class
