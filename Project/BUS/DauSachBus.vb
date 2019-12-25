Imports System.Windows.Forms
Imports DAO
Imports DTO
Imports Utility

Public Class DauSachBus
#Region "-   field   -"
    Private _dausachDAO As DauSachDAO
    Private _sachBus As SachBus
    Private _quiDinh As QuiDinh
    Private _danhSachTacGia As List(Of TacGia)
    Private _danhSachTheLoaiSach As List(Of TheLoaiSach)
    Private _ketQuaLayQuiDinh As Result
    Public Sub New()
        _dausachDAO = New DauSachDAO()
        _danhSachTacGia = New List(Of TacGia)
        _danhSachTheLoaiSach = New List(Of TheLoaiSach)
        _sachBus = New SachBus()
        _ketQuaLayQuiDinh = GetQuiDinh()
        GetDanhSachTacGia()
        GetDanhSachTheLoaiSach()
    End Sub

    Private Function GetQuiDinh() As Result
        Dim quiDinhBus = New QuiDinhBus()
        Dim result = quiDinhBus.SelectAll(_quiDinh)
        Return result
    End Function

    Public Function SelectAllByMaCuonSach(ByRef dauSach As DauSachDTO, txtDauSachId As String) As Result
        Return _dausachDAO.SelectAllByMaCuonSach(dauSach, txtDauSachId)
    End Function

    Private Function GetDanhSachTacGia() As Result
        Dim tacGiaBus = New TacGiaBUS()
        Dim result = tacGiaBus.SelectAll(_danhSachTacGia)
        Return result
    End Function
    Private Function GetDanhSachTheLoaiSach() As Result
        Dim theLoaiSachBus = New TheLoaiSachBUS()
        Dim result = theLoaiSachBus.SelectAll(_danhSachTheLoaiSach)
        Return result
    End Function
#End Region

#Region "-   insert one   -"
    Public Function InsertOne(dausach As DauSachDTO) As Result
        Dim getNextIDResult = GetNextId(dausach.MaDauSach)
        Dim validateResult = Validate(dausach)
        If validateResult.FlagResult = False Then Return validateResult
        Return _dausachDAO.InsertOne(dausach)
    End Function
<<<<<<< HEAD
    Public Function InsertMore(dausach As DauSachDTO) As Result
        Dim getNextIDResult = GetNextId(dausach.MaDauSach)
        Dim validateResult = Validate(dausach)
        If validateResult.FlagResult = False Then Return validateResult
        Return _dausachDAO.InsertOne(dausach)
    End Function
    Private Function Validatehan(dausach As DauSachDTO) As Result
        If _ketQuaLayQuiDinh.FlagResult = False Then Return New Result(False, "Không thể lấy qui định trong cơ sở dữ liệu để xác nhập thông tin sách!", "")
        Dim validateTenSachVaTenNhaXuatBanResult = dausach.ValidateTenSachAndTenNhaXuatBan()
        Dim validateNgayXuatBanResult = ValidateNgayXuatBan(dausach.NgayXuatBan, dausach.NgayNhap)
        Dim validateTheLoaiSachResult = ValidateTheLoaiSach(dausach.MaTheLoaiSach)
        Dim validateTacGiaResult = ValidateTacGia(dausach.MaTacGia)

        If validateTenSachVaTenNhaXuatBanResult.FlagResult = False Then Return validateTenSachVaTenNhaXuatBanResult
        If validateNgayXuatBanResult.FlagResult = False Then Return validateNgayXuatBanResult
        If validateTheLoaiSachResult.FlagResult = False Then Return validateTheLoaiSachResult
        If validateTacGiaResult.FlagResult = False Then Return validateTacGiaResult

        Return New Result()
    End Function
    Private Function Validatetime(dausach As DauSachDTO) As Result
=======


    Private Function Validate(dausach As DauSachDTO) As Result
>>>>>>> origin/phat-dev
        If _ketQuaLayQuiDinh.FlagResult = False Then Return New Result(False, "Không thể lấy qui định trong cơ sở dữ liệu để xác nhập thông tin sách!", "")
        Dim validateTenSachVaTenNhaXuatBanResult = dausach.ValidateTenSachAndTenNhaXuatBan()
        Dim validateTheLoaiSachResult = ValidateTheLoaiSach(dausach.MaTheLoaiSach)
        Dim validateTacGiaResult = ValidateTacGia(dausach.MaTacGia)

        If validateTenSachVaTenNhaXuatBanResult.FlagResult = False Then Return validateTenSachVaTenNhaXuatBanResult
        If validateTheLoaiSachResult.FlagResult = False Then Return validateTheLoaiSachResult
        If validateTacGiaResult.FlagResult = False Then Return validateTacGiaResult

        Return New Result()
    End Function
    Private Function ValidateNgayXuatBan(ngayXuatBan As DateTime, ngayNhap As DateTime) As Result

        Dim timeSpan = ngayNhap.Subtract(ngayXuatBan)
        Dim khoangCachNhanSach = timeSpan.TotalDays / 365

        If khoangCachNhanSach > _quiDinh.ThoiHanNhanSach Then Return New Result(False, "Không nhận sách có ngày xuất bản quá " & _quiDinh.ThoiHanNhanSach, "")
        Return New Result()
    End Function
    Private Function ValidateTheLoaiSach(maTheLoaiSach As Integer) As Result
        Dim isMatchingValues = _danhSachTheLoaiSach.Find(Function(x) x.MaTheLoaiSach = maTheLoaiSach)
        If isMatchingValues Is Nothing Then Return New Result(False, "Lỗi chọn sai thể loại sách", "")
        Return New Result()
    End Function
    Private Function ValidateTacGia(maTacGia As Integer) As Result
        Dim isMatchingValues = _danhSachTacGia.Find(Function(x) x.MaTacGia = maTacGia)
        If isMatchingValues Is Nothing Then Return New Result(False, "Lỗi chọn sai tác giả", "")
        Return New Result()
    End Function
#End Region

#Region "-   Update and delete  -"
    Public Function ThemSachMoiVaoDauSach(id As String, amount As Decimal, ngayNhap As Date) As Result
        Dim rs As Result = _dausachDAO.UpdateQuanlityBook(id, amount)
        If rs.FlagResult Then
            Dim dausach = New DauSachDTO()
            GetById(dausach, id)
            Dim cuonsach = New Sach()
            cuonsach.MaDauSach = id
            cuonsach.NgayNhap = ngayNhap
            cuonsach.TinhTrang = 0
            Return _sachBus.InsertOne(cuonsach)
        End If
        Return rs
    End Function
    Public Function UpdateQuanlity(id As String, amount As Decimal) As Result
        Dim rs As Result = _dausachDAO.UpdateQuanlityBook(id, amount)
        Return rs
    End Function

    Public Function Update(dausach As DauSachDTO) As Result
        Dim validateTenSachAndTenNXBResult = dausach.ValidateTenSachAndTenNhaXuatBan()
        If Not validateTenSachAndTenNXBResult.FlagResult Then Return validateTenSachAndTenNXBResult

        If String.IsNullOrWhiteSpace(dausach.MaDauSach) Then Return New Result(False, "Mã đầu sách không hợp lệ!", "")
        Return _dausachDAO.Update(dausach)
    End Function

    Public Function DeleteById(id As String) As Result
        If String.IsNullOrWhiteSpace(id) Then Return New Result(False, "Mã đầu sách không hợp lệ!", "")
        Return _dausachDAO.DeleteById(id)
    End Function
#End Region

#Region "-   Retrieve data  -"
    Public Function SelectAll(ByRef listDauSach As List(Of DauSachDTO)) As Result
        Dim result = _dausachDAO.SelectAll(listDauSach)
        Return result
    End Function

    Public Function SelectALLBySpecificConditions(ByRef listDauSach As List(Of DauSachDTO), dausach As DauSachDTO,
                                               NgayXuatBanMin As DateTime, NgayXuatBanMax As DateTime,
                                               TriGiaMin As Double, TriGiaMax As Double) As Result
        Return _dausachDAO.SelectAllBySpecificConditions(listDauSach, dausach,
                                                      NgayXuatBanMin, NgayXuatBanMax,
                                                        TriGiaMin, TriGiaMax)
    End Function

    Public Function SelectAllByMaDauSach(listDauSach As List(Of DauSachDTO), maDauSach As String) As Result
        Dim result = _dausachDAO.SelectAllByMaDauSach(listDauSach, maDauSach)
        Return result
    End Function

    Public Function SelectSachById(ByRef dausach As DauSachDTO, maDauSach As String) As Result
        'Guard clause
        If String.IsNullOrWhiteSpace(maDauSach) Then Return New Result(False, "Mã đầu sách không tồn tại", "")

        Return _dausachDAO.SelectDauSachById(dausach, maDauSach)
    End Function

    Public Function SelectByType(maDauSach As String, ByRef tenSach As String, ByRef theLoai As String,
                                 ByRef tacGia As String, ByRef tinhTrangSach As Integer) As Result
        Return _dausachDAO.SelectByType(maDauSach, tenSach, theLoai, tacGia, tinhTrangSach)
    End Function

    Public Function GetNextId(ByRef maDauSach) As Result
        maDauSach = String.Empty
        Dim result = _dausachDAO.GetTheLastID(maDauSach)
        maDauSach = If(String.IsNullOrWhiteSpace(maDauSach), 1, maDauSach + 1)
        Return result
    End Function

    Public Function GetById(ByRef dausach As DauSachDTO, maDauSach As Integer) As Result
        If String.IsNullOrWhiteSpace(maDauSach) Then Return New Result(False, "Mã đầu sách không hợp lệ!", "")
        Return _dausachDAO.GetByID(dausach, maDauSach)
    End Function


#End Region

End Class
