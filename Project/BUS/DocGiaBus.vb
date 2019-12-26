Imports System.Text.RegularExpressions
Imports DAO
Imports DTO
Imports Utility

Public Class DocGiaBus
#Region "-   Field   -"
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

    Private Function GetLoaiDocGia() As Result
        Dim loaiDocGiaBus = New LoaiDocGiaBus()
        Dim result = loaiDocGiaBus.SelectAll(_listLoaiDocGia)
        If _listLoaiDocGia.Count < 1 Then
            Return New Result(False, "Không thể lấy danh sách loại đôc giả", "")
        End If
        Return result
    End Function

    Public Function GetQuiDinh() As Result
        Dim quiDinhBus As QuiDinhBus = New QuiDinhBus()
        Dim layTuoiToiDaResult = quiDinhBus.GetTuoiToiDaVaToiThieu(_quiDinh)
        Dim layThoiHanResult = quiDinhBus.GetThoiHanToiDaTheDocGia(_quiDinh)
        If layThoiHanResult.FlagResult = False Then Return layThoiHanResult
        If layTuoiToiDaResult.FlagResult = False Then Return layTuoiToiDaResult
        Return New Result()
    End Function

#End Region

#Region "-   Insert   -"
    Public Function InsertOne(docGia As DocGia) As Result
        If ValidateAll(docGia).FlagResult = False Then
            Return ValidateAll(docGia)
        End If
        Dim maTheDocGia As Integer
        Dim ketQuaLayMaTheDocGia = BuildMaDocGia(maTheDocGia)
        docGia.MaTheDocGia = maTheDocGia
        docGia.NgayHetHan = docGia.NgayTao.AddMonths(_quiDinh.ThoiHanToiDaTheDocGia)
        Return _docGiaDAO.InsertOne(docGia)
    End Function


    Public Function BuildMaDocGia(ByRef maTheDocGia As String) As Result

        maTheDocGia = String.Empty
        Dim y = DateTime.Now.Year
        Dim x = y.ToString().Substring(2)
        maTheDocGia = x + "000000"

        Dim maTheCuoiCung = String.Empty
        Dim result = _docGiaDAO.GetTheLastTheDocGiaID(maTheCuoiCung)

        If result.FlagResult = True Then
            If (maTheCuoiCung <> Nothing And maTheCuoiCung.Length >= 8) Then
                Dim currentYear = DateTime.Now.Year.ToString().Substring(2)
                Dim iCurrentYear = Integer.Parse(currentYear)
                Dim currentYearOnDB = maTheCuoiCung.Substring(0, 2)
                Dim icurrentYearOnDB = Integer.Parse(currentYearOnDB)
                Dim year = iCurrentYear
                If (year < icurrentYearOnDB) Then
                    year = icurrentYearOnDB
                End If
                maTheDocGia = year.ToString()
                Dim v = maTheCuoiCung.Substring(2)
                Dim convertDecimal = Convert.ToDecimal(v)
                convertDecimal = convertDecimal + 1
                Dim tmp = convertDecimal.ToString()
                tmp = tmp.PadLeft(maTheCuoiCung.Length - 2, "0")
                maTheDocGia = maTheDocGia + tmp
            End If
        Else
            maTheDocGia = maTheDocGia + 1
        End If
        Return result
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
#End Region

#Region "-  Edit and remove   -"
    Public Function UpdateById(docGia As DocGia) As Result
        Dim validateResult = docGia.Validate()
        Dim validateYearsoldResult = ValidateYearsold(docGia.NgaySinh)
        Dim validateReaderTypeResult = ValidateReaderType(docGia.MaLoaiDocGia)

        If validateResult.FlagResult = False Then Return validateResult
        If validateYearsoldResult.FlagResult = False Then Return validateYearsoldResult
        If validateReaderTypeResult.FlagResult = False Then Return validateReaderTypeResult

        Dim result = _docGiaDAO.UpdateByReaderId(docGia)
        Return result
    End Function

    Public Function GetReaderByIdIncludeDeleted(ByRef docGia As DocGia, id As String) As Result

        Return _docGiaDAO.GetReaderByIdIncludeDeleted(docGia, id)
    End Function

    Public Function DeleteByID(maThe As String) As Result
        If String.IsNullOrWhiteSpace(maThe) Then Return New Result(False, "Mã thẻ độc giả không được để trống", "")
        Dim count = 0
        Dim rs = _docGiaDAO.CountSachDangMuon(maThe, count)
        If Not rs.FlagResult Then
            Return rs
        End If
        If count > 0 Then
            Return New Result(False, "Thẻ đang có sách mượn chưa trả", "")
        End If
        Dim result = _docGiaDAO.DeleteByReaderID(maThe)
        Return result
    End Function

#End Region

#Region "-   Select   -"
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

    Public Function GetReaderNameById(ByRef tenDocGia As String, maThe As String) As Result
        Dim result = _docGiaDAO.GetReaderNameByID(tenDocGia, maThe)
        If String.IsNullOrWhiteSpace(tenDocGia) = True Then Return New Result(False, "Lấy dữ liệu độc giả không thành công! Vui lòng kiểm tra lại mã thẻ ", "")
        Return result
    End Function

    Public Function GetExpirationDateById(ByRef ngayHetHan As DateTime, maThe As String) As Result
        Return _docGiaDAO.GetExpirationDateById(ngayHetHan, maThe)
    End Function

    Public Function GetReaderById(ByRef docGia As DocGia, maThe As String) As Result
        Return _docGiaDAO.GetReaderByID(docGia, maThe)
    End Function
#End Region
End Class
