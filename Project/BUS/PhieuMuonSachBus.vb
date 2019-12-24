Imports DAO
Imports DTO
Imports Utility

Public Class PhieuMuonSachBus
#Region "-   Field   -"
    Private _phieuMuonSachDAO As PhieuMuonSachDAO
    Private _quiDinh As QuiDinh
    Private _quiDinhBus As QuiDinhBus
    Public Sub New()
        _phieuMuonSachDAO = New PhieuMuonSachDAO()
        _quiDinh = New QuiDinh()
        _quiDinhBus = New QuiDinhBus()
    End Sub
#End Region

#Region "-   Insert    -"
    Public Function InsertOne(phieuMuonSach As PhieuMuonSach) As Result
#Region "guard clause"
        'Lay ma phieu muon sach tiep thieo
        Dim maPhieuMuonSach As Integer
        Dim ketQuaLayMaPhieuMuonSach = LayMaSoPhieuMuonSachTiepTheo(maPhieuMuonSach)
        If ketQuaLayMaPhieuMuonSach.FlagResult = False Then Return ketQuaLayMaPhieuMuonSach
        phieuMuonSach.MaPhieuMuonSach = maPhieuMuonSach

        'Lay qui dinh
        Dim getQuiDinhResult = GetQuiDinh()
        If getQuiDinhResult.FlagResult = False Then Return getQuiDinhResult
        phieuMuonSach.HanTra = phieuMuonSach.NgayMuon.AddDays(_quiDinh.SoNgayMuonSachToiDa)

        'Lay danh sach sach da muon truoc do
        Dim listPhieuMuonSachChuaTra = New List(Of PhieuMuonSach)
        _phieuMuonSachDAO.SelectAllPhieuMuonSachChuaTraByReaderId(listPhieuMuonSachChuaTra, phieuMuonSach.maTheDocGia)

        'kiem tra phieu muon sach hop le khong

        Dim isValidPhieuMuonSach = phieuMuonSach.ValidateMaPhieuMuonSachAndMaTheDocGia()
        If isValidPhieuMuonSach.FlagResult = False Then Return isValidPhieuMuonSach

        Dim isValidSoSachMuonToiDa = ValidateSoSachMuonToiDa(phieuMuonSach.TongSoSachMuon, listPhieuMuonSachChuaTra)
        If isValidSoSachMuonToiDa.FlagResult = False Then Return isValidSoSachMuonToiDa

        Dim isValidTheDocGia = ValidateTheDocGia(phieuMuonSach.MaTheDocGia, listPhieuMuonSachChuaTra)
        If isValidTheDocGia.FlagResult = False Then Return isValidTheDocGia

#End Region

        Return _phieuMuonSachDAO.InsertOne(phieuMuonSach)
    End Function

    Private Function ValidateTheDocGia(maTheDocGia As Integer, listPhieuMuonSachChuaTra As List(Of PhieuMuonSach)) As Result
        Dim isValidHanSuDungThe = ValidateHanSuDungThe(maTheDocGia)
        If isValidHanSuDungThe.FlagResult = False Then Return isValidHanSuDungThe

        'kiểm tra độc giả có sách quá hạn không
        Dim isValidBorrowedBook = ValidateBookBorrowed(maTheDocGia, listPhieuMuonSachChuaTra)
        If isValidBorrowedBook.FlagResult = False Then Return isValidBorrowedBook

        Return New Result()
    End Function

    Private Function ValidateBookBorrowed(maTheDocGia As Integer, listPhieuMuonSachChuaTra As List(Of PhieuMuonSach)) As Result

        For Each phieuMuonsach As PhieuMuonSach In listPhieuMuonSachChuaTra
            If phieuMuonsach.HanTra.Subtract(DateTime.Now).TotalSeconds < 0 Then Return New Result(False, "Độc giả có sách mượn quá hạn!", "")
        Next
        Return New Result()
    End Function

    Private Function ValidateHanSuDungThe(maTheDocGia As Integer) As Result
        Dim ngayHienTai = DateTime.Now
        Dim ngayHetHanThe = New DateTime()
        Dim docGiaBus = New DocGiaBus()

        Dim getNgayHetHanResult = docGiaBus.GetExpirationDateById(ngayHetHanThe, maTheDocGia)
        If getNgayHetHanResult.FlagResult = False Then Return getNgayHetHanResult

        If ngayHetHanThe.Subtract(ngayHienTai).TotalSeconds < 0 Then Return New Result(False, "Thẻ độc giả quá hạn sử dụng!", "")
        Return New Result()
    End Function

    Public Sub SelectAllSachChuaTraByPhieuMuonId(maPhieuMuonSach As String, ByRef listBook As List(Of CustomBookInfoDisplay))
        _phieuMuonSachDAO.SelectAllSachChuaTraByPhieuMuonId(maPhieuMuonSach, listBook)
    End Sub

    Private Function ValidateSoSachMuonToiDa(tongSoSachCanMuon As Integer, listPhieuMuonSachChuaTra As List(Of PhieuMuonSach)) As Result
        Dim soSachMuonTruocDo = 0
        For Each phieuMuonSach In listPhieuMuonSachChuaTra
            soSachMuonTruocDo = soSachMuonTruocDo + phieuMuonSach.TongSoSachMuon
        Next
        If tongSoSachCanMuon + soSachMuonTruocDo > _quiDinh.SoSachMuonToiDa Then Return New Result(False, String.Format("Số sách mượn tối đa vượt quá mức ( qui định Số sách mượn tối đa {0} quyển)", _quiDinh.SoSachMuonToiDa), "")
        Return New Result()
    End Function

    Public Function LayMaSoPhieuMuonSachTiepTheo(ByRef maPhieuMuonSach As String) As Result
        Dim result = _phieuMuonSachDAO.GetTheLastPhieuMuonSachID(maPhieuMuonSach)
        maPhieuMuonSach = maPhieuMuonSach + 1
        Return result
    End Function
    Public Function GetQuiDinh() As Result
        Dim layThoiHanMuonSachResult = _quiDinhBus.GetSoNgayMuonSachToiDa(_quiDinh)
        Dim laySoSachMuonToiDaResult = _quiDinhBus.GetSoSachMuonToiDa(_quiDinh)
        If laySoSachMuonToiDaResult.FlagResult = False Then Return laySoSachMuonToiDaResult
        If layThoiHanMuonSachResult.FlagResult = False Then Return layThoiHanMuonSachResult
        Return New Result()
    End Function
#End Region

#Region "-  Update   -"
    Public Function UpdateCheckOutPhieuMuonByPhieuMuonSach(PhieuMuonSach As PhieuMuonSach, listChiTietPhieuMuonSach As List(Of ChiTietPhieuMuonSach)) As Result
        If String.IsNullOrWhiteSpace(PhieuMuonSach.MaPhieuMuonSach) Then Return New Result(False, "Mã phiếu mượn không hợp lệ!", "")

        Dim checkOutResult = _phieuMuonSachDAO.UpdateCheckOutPhieuMuonByPhieuMuonSach(PhieuMuonSach)
        If checkOutResult.FlagResult = False Then Return checkOutResult

        Dim sachBus = New SachBus
        For Each chiTietPhieuMuonSach In listChiTietPhieuMuonSach
            sachBus.SetStatusSachToAvailableByID(chiTietPhieuMuonSach.MaSach)
        Next
        Return checkOutResult
    End Function



#End Region

#Region "-   Retrieve data  -"
    Public Sub SelectRentSachByDocGiaId(docGiaId As String, ByRef sachInfo As List(Of CustomBookInfoDisplay))
        _phieuMuonSachDAO.SelectRentSachByDocGiaId(docGiaId, sachInfo)
    End Sub
    Public Function SelectAllByMaTheDocGia(ByRef listPhieuMuonSach As List(Of PhieuMuonSach), maTheDocGia As String) As Result
        Return _phieuMuonSachDAO.SelectAllByMaTheDocGia(listPhieuMuonSach, maTheDocGia)
    End Function
    Public Function SelectAllSachChuaTraByReaderID(ByRef listPhieuMuonSach As List(Of PhieuMuonSach),
                                             maTheDocGia As String) As Result
        Return _phieuMuonSachDAO.SelectAllPhieuMuonSachChuaTraByReaderId(listPhieuMuonSach, maTheDocGia)
    End Function
    Public Function SelectIdTheLastOne(ByRef maphieuMuonSach As String) As Result
        Return _phieuMuonSachDAO.SelectIdTheLastOne(maphieuMuonSach)
    End Function

    Public Function GetPhieuMuonSachById(ByRef phieuMuonSach As PhieuMuonSach, maPhieuMuonSach As String) As Result
        Return _phieuMuonSachDAO.GetPhieuMuonSachById(phieuMuonSach, maPhieuMuonSach)
    End Function

    Public Function IsValidNumberOfBooks(numberOfRows As Integer) As Boolean
        GetQuiDinh()

        If numberOfRows >= _quiDinh.SoSachMuonToiDa Then Return False
        Return True
    End Function

    Public Function SelectAllPhieuTraTreByDate(ByRef listPhieuMuonSach As List(Of PhieuMuonSach), thoiGian As DateTime) As Result
        Dim result = _phieuMuonSachDAO.SelectAllPhieuMuonSachByDate(listPhieuMuonSach, thoiGian)
        _quiDinhBus.GetSoNgayMuonSachToiDa(_quiDinh)
        listPhieuMuonSach = listPhieuMuonSach.Where(Function(x) (x.NgayTra - x.NgayMuon).TotalDays > _quiDinh.SoNgayMuonSachToiDa).ToList()
        Return result
    End Function

#End Region

End Class
