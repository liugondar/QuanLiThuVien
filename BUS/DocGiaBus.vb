Imports DAO
Imports DTO
Imports Utility

Public Class DocGiaBus
    Private _readerDAO As DocGiaDAO
    Private _tuoiToiDa As Integer
    Private _tuoiToiThieu As Integer
    Private _duration As Integer
    Private _listReaderType As List(Of LoaiDocGia)

    Public Sub New()
        _readerDAO = New DocGiaDAO()
        GetQuiDinh()
        GetLoaiDocGia()
    End Sub

    Private Sub GetLoaiDocGia()
        Dim loaiDocGiaBus = New LoaiDocGiaBus()
        _listReaderType = loaiDocGiaBus.SelectAll()
    End Sub

    Private Sub GetQuiDinh()
        Dim quiDinhBus As QuiDinhBus = New QuiDinhBus()
        Dim data As DataTable = quiDinhBus.SelectAll()
        For Each row As DataRow In data.Rows
            _tuoiToiDa = Integer.Parse(row.ItemArray(0))
            _tuoiToiThieu = Integer.Parse(row.ItemArray(1))
            _duration = Integer.Parse(row.ItemArray(2))
        Next
    End Sub

    Function Insert1(docGia As DocGia) As Result
        If ValidateAll(docGia).FlagResult = False Then
            Return ValidateAll(docGia)
        End If
        docGia.NgayHetHan = docGia.NgayTao.AddMonths(_duration)
        Return _readerDAO.InsertOne(docGia)
    End Function

    Private Function ValidateAll(docGia As DocGia) As Result
        If ValidateUserName(docGia.TenDocGia) = False Then
            Return New Result(False, "user name không hợp lệ", "")
        End If

        If ValidateEmail(docGia.Email) = False Then
            Return New Result(False, "Email không hợp lệ", "")
        End If

        If ValidateYearsold(docGia.NgaySinh).FlagResult = False Then
            Return ValidateYearsold(docGia.NgaySinh)
        End If

        If ValidateReaderType(docGia.MaLoaiDocGia).FlagResult = False Then
            Return ValidateReaderType(docGia.MaLoaiDocGia)
        End If

        Return New Result(True)
    End Function

    Private Function ValidateEmail(Email As String) As Boolean
        If String.IsNullOrWhiteSpace(Email) Then
            Return False
        End If
        Return True
    End Function

    Private Function ValidateCreator(tenNguoiTao As String) As Boolean
        If String.IsNullOrWhiteSpace(tenNguoiTao) Then
            Return False
        End If
        Return True
    End Function

    Private Function ValidateUserName(tenDocGia As String) As Boolean
        If String.IsNullOrWhiteSpace(tenDocGia) Then
            Return False
        End If
        Return True
    End Function

    Private Function ValidateReaderType(loaiDocGiaId As Integer) As Object
        Dim matchingValues = _listReaderType.Find(Function(x) x.LoaiDocGiaId = loaiDocGiaId)

        If matchingValues Is Nothing Then
            Return New Result(False, "Lỗi nhập vào kiểu người dùng", "")
        End If
        Return New Result(True)
    End Function


    Private Function ValidateYearsold(ngaySinh As Date) As Object
        Dim dateNow As Date = Date.Now()
        Dim yearsold = (dateNow - ngaySinh).TotalDays \ 365
        If yearsold < _tuoiToiThieu Then
            Return New Result(False, "Tuổi chưa đủ để lập thẻ", "")
        End If
        If yearsold > _tuoiToiDa Then
            Return New Result(False, "Tuổi quá lớn để lập thẻ", "")
        End If
        Return New Result(True)
    End Function
End Class
