Imports DAO
Imports DTO
Imports Utility

Public Class SachBus
#Region "-   field   -"
    Private _sachDAO As SachDAO
    Private _quiDinh As QuiDinh
    Private _danhSachTacGia As List(Of TacGia)
    Private _danhSachTheLoaiSach As List(Of TheLoaiSach)
    Private _ketQuaLayQuiDinh As Result
    Public Sub New()
        _sachDAO = New SachDAO()
        _danhSachTacGia = New List(Of TacGia)
        _danhSachTheLoaiSach = New List(Of TheLoaiSach)
        _ketQuaLayQuiDinh = GetQuiDinh()
        GetDanhSachTacGia()
        GetDanhSachTheLoaiSach()
    End Sub

    Private Function GetQuiDinh() As Result
        Dim quiDinhBus = New QuiDinhBus()
        Dim result = quiDinhBus.SelectAll(_quiDinh)
        Return result
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
    Public Function InsertOne(sach As Sach) As Result
        Dim validateResult = Validate(sach)
        If validateResult.FlagResult = False Then Return validateResult
        Return _sachDAO.InsertOne(sach)
    End Function
    Private Function Validate(sach As Sach) As Result
        If _ketQuaLayQuiDinh.FlagResult = False Then Return New Result(False, "Không thể lấy qui định trong cơ sở dữ liệu để xác nhập thông tin sách!", "")
        Dim validateTenSachVaTenNhaXuatBanResult = sach.Validate()
        Dim validateNgayXuatBanResult = ValidateNgayXuatBan(sach.NgayXuatBan, sach.NgayNhap)
        Dim validateTheLoaiSachResult = ValidateTheLoaiSach(sach.MaTheLoaiSach)
        Dim validateTacGiaResult = ValidateTacGia(sach.MaTacGia)

        If validateTenSachVaTenNhaXuatBanResult.FlagResult = False Then Return validateTenSachVaTenNhaXuatBanResult
        If validateNgayXuatBanResult.FlagResult = False Then Return validateNgayXuatBanResult
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

#Region "-   Retrieve data  -"
    Public Function SelectAll(ByRef listSach As List(Of Sach)) As Result
        Dim result = _sachDAO.SelectAll(listSach)
        Return result
    End Function

    Public Function SelectALLBySpecificConditions(ByRef listSach As List(Of Sach), sach As Sach,
                                               NgayXuatBanMin As DateTime, NgayXuatBanMax As DateTime,
                                               NgayNhapMin As DateTime, NgayNhapMax As DateTime,
                                               TriGiaMin As Double, TriGiaMax As Double) As Result
        Return _sachDAO.SelectAllBySpecificConditions(listSach, sach,
                                                      NgayXuatBanMin, NgayXuatBanMax,
                                                      NgayNhapMin, NgayNhapMax,
                                                        TriGiaMin, TriGiaMax)
    End Function

    Public Function SelectAllByMaSach(listSach As List(Of Sach), maSach As String) As Result
        Dim result = _sachDAO.SelectAllByMaSach(listSach, maSach)
        Return result
    End Function

    Public Function SelectAllByMaTheLoaiSach(listSach As List(Of Sach), maTheLoaiSach As String) As Result
        Dim result = _sachDAO.SelectAllByMaTheLoaiSach(listSach, maTheLoaiSach)
        Return result
    End Function
    Public Function SelectAllByMaTacGia(listSach As List(Of Sach), maTacGia As String) As Result
        Dim result = _sachDAO.SelectAllByMaTacGia(listSach, maTacGia)
        Return result
    End Function

    Public Function SelectAllByTenNhaXuatBan(listSach As List(Of Sach), tenNhaXuatBan As String) As Result
        Dim result = _sachDAO.SelectAllByTenNhaXuatBan(listSach, tenNhaXuatBan)
        Return result
    End Function

    Public Function SelectAllByNgayXuatBan(listSach As List(Of Sach), ngayMin As DateTime, ngayMax As DateTime) As Result
        Dim result = _sachDAO.SelectAllByNgayXuatBan(listSach, ngayMin, ngayMax)
        Return result
    End Function

    Public Function SelectAllByNgayNhap(listSach As List(Of Sach), ngayMin As DateTime, ngayMax As DateTime) As Result
        Dim result = _sachDAO.SelectAllByNgayNhap(listSach, ngayMin, ngayMax)
        Return result
    End Function

    Public Function SelectAllByTriGia(listSach As List(Of Sach), triGiaMin As String, triGiaMax As String) As Result
        Dim result = _sachDAO.SelectAllByTriGia(listSach, triGiaMin, triGiaMax)
        Return result
    End Function

    Public Function SelectAllByBookIdBookTitleAuthorIdTypeID(ByRef listSach As List(Of Sach),
                                                                      SachYeuCau As Sach) As Result
        'Guard clause
        If String.IsNullOrWhiteSpace(SachYeuCau.MaSach) Then SachYeuCau.MaSach = -1
        If String.IsNullOrWhiteSpace(SachYeuCau.TenSach) Then SachYeuCau.TenSach = -1
        If String.IsNullOrWhiteSpace(SachYeuCau.MaTheLoaiSach) Then SachYeuCau.MaTheLoaiSach = -1
        If String.IsNullOrWhiteSpace(SachYeuCau.MaTacGia) Then SachYeuCau.MaTacGia = -1

        Return _sachDAO.SelectBookIdBookTitleAuthorIdTypeIDBySpecificRequest(listSach, SachYeuCau)
    End Function


    Public Function SelectSachById(ByRef sach As Sach, maSach As String) As Result
        'Guard clause
        If String.IsNullOrWhiteSpace(sach.MaSach) Then Return New Result(False, "Mã sách không tồn tại", "")
        Return _sachDAO.SelectSachByMaSach(sach, maSach)
    End Function
#End Region
End Class
