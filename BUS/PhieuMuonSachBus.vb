Imports DAO
Imports DTO
Imports Utility

Public Class PhieuMuonSachBus
    Private _phieuMuonSachDAO As PhieuMuonSachDAO
    Private _quiDinh As QuiDinh
    Public Sub New()
        _phieuMuonSachDAO = New PhieuMuonSachDAO()
        _quiDinh = New QuiDinh()
    End Sub

    Public Function InsertOne(phieuMuonSach As PhieuMuonSach) As Result
#Region "guard clause"
        'Lay danh sach qui dinh va kiem tra
        Dim getQuiDinhResult = GetQuiDinh()
        If getQuiDinhResult.FlagResult = False Then Return getQuiDinhResult
        phieuMuonSach.HanTra = phieuMuonSach.NgayMuon.AddDays(_quiDinh.SoNgayMuonSachToiDa)

        Dim ketQuaKiemTraSoSachMuonToiDa = ValidateSoSachMuonToiDa(phieuMuonSach.TongSoSachMuon)
        If ketQuaKiemTraSoSachMuonToiDa.FlagResult = False Then Return ketQuaKiemTraSoSachMuonToiDa

        Dim ketQuaKiemTraTheDocGia = ValidateTheDocGia(phieuMuonSach.MaTheDocGia)
        If ketQuaKiemTraTheDocGia.FlagResult = False Then Return ketQuaKiemTraTheDocGia

        'Lay ma phieu muon sach tiep thieo
#End Region
        Dim maPhieuMuonSach As Integer
        Dim ketQuaLayMaPhieuMuonSach = LayMaSoPhieuMuonSachTiepTheo(maPhieuMuonSach)
        If ketQuaLayMaPhieuMuonSach.FlagResult = False Then Return ketQuaLayMaPhieuMuonSach
        phieuMuonSach.MaPhieuMuonSach = maPhieuMuonSach

        Return _phieuMuonSachDAO.InsertOne(phieuMuonSach)
    End Function

    Private Function ValidateTheDocGia(maTheDocGia As Integer) As Result
        'TODO: validate tinh trang the con han su dung khong
        Dim validateTinhtrangtheResult = ValidateTinhTrangThe(maTheDocGia)
        If validateTinhtrangtheResult.FlagResult = False Then Return validateTinhtrangtheResult
        'TODO: validate tinh trang the khong co sach muon qua han
        Return New Result()
    End Function

    Private Function ValidateTinhTrangThe(maTheDocGia As Integer) As Result
        Dim ngayHienTai = DateTime.Now
        Dim ngayHetHanThe = New DateTime()
        Dim docGiaBus = New DocGiaBus()

        Dim getNgayHetHanResult = docGiaBus.SelectExpirationDateById(ngayHetHanThe, maTheDocGia)
        If getNgayHetHanResult.FlagResult = False Then Return getNgayHetHanResult

        If ngayHetHanThe.Subtract(ngayHienTai).TotalSeconds < 0 Then Return New Result(False, "Thẻ độc giả quá hạn sử dụng!", "")
        Return New Result()
    End Function

    Private Function ValidateSoSachMuonToiDa(tongSoSachMuon As Integer) As Result
        If tongSoSachMuon > _quiDinh.SoNgayMuonSachToiDa Then Return New Result(False, String.Format("Số sách mượn tối đa vượt quá mức ( qui định Số sách mượn tối đa {0} quyển)", _quiDinh.SoSachMuonToiDa), "")
        Return New Result()
    End Function

    Private Function LayMaSoPhieuMuonSachTiepTheo(ByRef maPhieuMuonSach) As Result
        Dim result = _phieuMuonSachDAO.LayMaSoPhieuMuonSachCuoiCung(maPhieuMuonSach)
        maPhieuMuonSach = maPhieuMuonSach + 1
        Return result
    End Function
    Public Function GetQuiDinh() As Result
        Dim quiDinhBus = New QuiDinhBus()
        Dim layThoiHanMuonSachResult = quiDinhBus.LaySoNgayMuonSachToiDa(_quiDinh)
        Dim laySoSachMuonToiDaResult = quiDinhBus.LaySoSachMuonToiDa(_quiDinh)
        If laySoSachMuonToiDaResult.FlagResult = False Then Return laySoSachMuonToiDaResult
        If layThoiHanMuonSachResult.FlagResult = False Then Return layThoiHanMuonSachResult
        Return New Result()
    End Function

    Public Function SelectAllByMaTheDocGia(ByRef listPhieuMuonSach As List(Of PhieuMuonSach), maTheDocGia As String) As Result
        Return _phieuMuonSachDAO.SelectAllByMaTheDocGia(listPhieuMuonSach, maTheDocGia)
    End Function

    Public Function SelectIdTheLastOne(ByRef maphieuMuonSach As String) As Result
        Return _phieuMuonSachDAO.SelectIdTheLastOne(maphieuMuonSach)
    End Function
End Class
