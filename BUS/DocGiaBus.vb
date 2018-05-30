Imports System.Text.RegularExpressions
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
        _quiDinh = New QuiDinh
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
        Dim listQuiDinh = New List(Of QuiDinh)
        Dim result = quiDinhBus.SelectAll(listQuiDinh)
        If listQuiDinh.Count < 1 Then
            Return New Result(False, "Không thể lấy qui định phục vụ việc kiểm tra thông tin nhập thẻ độc giả", "")
        End If
        _quiDinh = listQuiDinh(0)
        Return result
    End Function

    Public Function InsertOne(docGia As DocGia) As Result
        If ValidateAll(docGia).FlagResult = False Then
            Return ValidateAll(docGia)
        End If
        docGia.NgayHetHan = docGia.NgayTao.AddMonths(_quiDinh.ThoiHanToiDaTheDocGia)
        Return _docGiaDAO.InsertOne(docGia)
    End Function

    Public Function SelectAllByType(maLoai As String) As Result
        If String.IsNullOrWhiteSpace(maLoai) Then
            Return New Result(False, "Mã loại độc giả không đúng!", "")
        End If
        'TODO: select all by type doc gia bus
        Return New Result()
    End Function

    Private Function ValidateAll(docGia As DocGia) As Result
        Dim validateUserNameResult = ValidateUserName(docGia.TenDocGia)
        Dim validateEmailResult = ValidateEmail(docGia.Email)
        Dim validateYearsoldResult = ValidateYearsold(docGia.NgaySinh)
        Dim validateReaderTypeResult = ValidateReaderType(docGia.MaLoaiDocGia)

        If validateUserNameResult.FlagResult = False Then Return validateUserNameResult
        If validateEmailResult.FlagResult = False Then Return validateEmailResult
        If validateYearsoldResult.FlagResult = False Then Return validateYearsoldResult
        If validateReaderTypeResult.FlagResult = False Then Return validateReaderTypeResult

        Return New Result(True)
    End Function

    Private Function ValidateEmail(Email As String) As Result
        If String.IsNullOrWhiteSpace(Email) Then Return New Result(False, "Email không đúng định dạng,ví dụ: 123@gmail.com", "")
        If (Regex.IsMatch(Email, "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$") = False) Then Return New Result(False, "Email không đúng định dạng,ví dụ: 123@gmail.com", "")
        Return New Result()
    End Function


    Private Function ValidateUserName(tenDocGia As String) As Result
        If String.IsNullOrWhiteSpace(tenDocGia) Then
            Return New Result(False, "Tên độc giả không đúng định dạng", "")
        End If
        Return New Result()
    End Function

    Private Function ValidateReaderType(loaiDocGiaId As Integer) As Result
        Dim matchingValues = _listLoaiDocGia.Find(Function(x) x.MaLoaiDocGia = loaiDocGiaId)

        If matchingValues Is Nothing Then
            Return New Result(False, "Lỗi nhập vào kiểu người dùng", "")
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
End Class
