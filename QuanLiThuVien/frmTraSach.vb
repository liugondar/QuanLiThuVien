Imports BUS
Imports DTO
Imports Utility
Public Class frmTraSach
#Region "-   Fields   -"
    Private _docGiaBus As DocGiaBus
    Private _phieuMuonSachBus As PhieuMuonSachBus
    Private _chiTietPhieuMuonSachBus As ChiTietPhieuMuonSachBus
    Private _sachBus As SachBus
    Private _tacGiaBus As TacGiaBUS
#End Region

#Region "-    Constructor  -"
    Private Sub frmTraSach_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _docGiaBus = New DocGiaBus()
        _phieuMuonSachBus = New PhieuMuonSachBus()
        _chiTietPhieuMuonSachBus = New ChiTietPhieuMuonSachBus()
        _sachBus = New SachBus()
        _tacGiaBus = New TacGiaBUS()
    End Sub

#End Region

#Region "-   Events    -"

#Region "-   MaPheuMuon changed   -"
    Private Sub MaPhieuMuonTextBox_TextChanged(sender As Object, e As EventArgs) Handles MaPhieuMuonTextBox.TextChanged
        Dim maPhieuMuon = MaPhieuMuonTextBox.Text

        LoadReaderInfoOfMaPhieuMuonInput(maPhieuMuon)
    End Sub


#Region "-   Load info   -"
    Private Sub LoadReaderInfoOfMaPhieuMuonInput(maPhieuMuon As String)
        Try
            Dim phieuMuonSach = New PhieuMuonSach()
            _phieuMuonSachBus.GetPhieuMuonSachById(phieuMuonSach, maPhieuMuon)

            WarningIfMaPhieuMuonUnavailable(phieuMuonSach)
            LoadThongTinDocGiaMuonVaNgayMuon(phieuMuonSach)
            LoadChiTietListSachMuon(phieuMuonSach)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub WarningIfMaPhieuMuonUnavailable(phieuMuonSach As PhieuMuonSach)
        WarningUnavailableMaPhieuMuonLabel.Visible = False
        If phieuMuonSach.MaTheDocGia = 0 Then
            WarningUnavailableMaPhieuMuonLabel.Text = "Mã phiếu mượn không tồn tại"
            WarningUnavailableMaPhieuMuonLabel.Visible = True
        End If
    End Sub

    Private Sub LoadThongTinDocGiaMuonVaNgayMuon(phieuMuonSAch As PhieuMuonSach)
        Dim docgia = New DocGia()
        _docGiaBus.GetReaderById(docgia, phieuMuonSAch.MaTheDocGia)

        MaTheDocGiaTextBox.Text = docgia.MaTheDocGia
        HoTenDocGiaMaskedTextBox.Text = docgia.TenDocGia
        BorrowDateTimePicker.Value = phieuMuonSAch.NgayMuon
    End Sub

#Region "-    Load listSachDataMuon dataGridView "
    Private Sub LoadChiTietListSachMuon(PhieuMuonSach As PhieuMuonSach)
        ClearBookBorrowedDataGridViewData()

        CreateListChiTietPMSDataGridViewTitleColumn()

        BindingSourceBookBorrowedDataGridViewData(PhieuMuonSach)

    End Sub
    Private Sub BindingSourceBookBorrowedDataGridViewData(phieuMuonSach As PhieuMuonSach)

        Dim listChiTietPhieuMuonSachDaMuon = New List(Of ChiTietPhieuMuonSach)
        Dim listSachDaMuon = New List(Of Sach)
        Dim listCustomBookInfoDisplay = New List(Of CustomBookInfoDisplay)

        _chiTietPhieuMuonSachBus.selectAllByMaphieumuonsach(listChiTietPhieuMuonSachDaMuon, phieuMuonSach.MaPhieuMuonSach)

        For Each chiTietPhieuMuonSach In listChiTietPhieuMuonSachDaMuon
            _sachBus.SelectAllByMaSach(listSachDaMuon, chiTietPhieuMuonSach.MaSach)
        Next

        For Each sach In listSachDaMuon
            Dim maPhieuMuonSach = listChiTietPhieuMuonSachDaMuon.
                Where(Function(s) s.MaSach = sach.MaSach).
                Select(Function(s) s.MaPhieuMuonSach).First()

            Dim customBook = New CustomBookInfoDisplay()
            customBook.MaSach = sach.MaSach
            customBook.TenSach = sach.TenSach
            _tacGiaBus.GetTenTacGiaByMaTacGia(customBook.TacGia, sach.MaTacGia)
            customBook.NgayHetHan = phieuMuonSach.HanTra

            Dim dateNow As Date = Date.Now()
            Dim isExpirated = If((phieuMuonSach.HanTra - dateNow).TotalSeconds < 0, True, False)
            customBook.TinhTrang = If(isExpirated, "Quá hạn", "Chưa trả")

            listCustomBookInfoDisplay.Add(customBook)
        Next

        ListSachDaMuonDataGridView.DataSource = New BindingSource(listCustomBookInfoDisplay, String.Empty)
    End Sub


    Private Sub ClearBookBorrowedDataGridViewData()
        ListSachDaMuonDataGridView.Columns.Clear()
        ListSachDaMuonDataGridView.DataSource = Nothing
        ListSachDaMuonDataGridView.AutoGenerateColumns = False
        ListSachDaMuonDataGridView.AllowUserToAddRows = False
    End Sub

    Private Sub CreateListChiTietPMSDataGridViewTitleColumn()
        Dim maSachColumn = New DataGridViewTextBoxColumn()
        maSachColumn.Name = "MaSach"
        maSachColumn.HeaderText = "Mã sách"
        maSachColumn.DataPropertyName = "MaSach"
        maSachColumn.Width = 50
        ListSachDaMuonDataGridView.Columns.Add(maSachColumn)

        Dim tenSachColumn = New DataGridViewTextBoxColumn()
        tenSachColumn.Name = "TenSach"
        tenSachColumn.HeaderText = "Tên sách"
        tenSachColumn.DataPropertyName = "TenSach"
        tenSachColumn.Width = 200
        ListSachDaMuonDataGridView.Columns.Add(tenSachColumn)

        Dim tacGiaColumn = New DataGridViewTextBoxColumn()
        tacGiaColumn.Name = "TacGia"
        tacGiaColumn.HeaderText = "Tác giả "
        tacGiaColumn.DataPropertyName = "TacGia"
        tacGiaColumn.Width = 140
        ListSachDaMuonDataGridView.Columns.Add(tacGiaColumn)

        Dim tinhTrangColumn = New DataGridViewTextBoxColumn()
        tinhTrangColumn.Name = "TinhTrang"
        tinhTrangColumn.HeaderText = "Tình trạng"
        tinhTrangColumn.DataPropertyName = "TinhTrang"
        tinhTrangColumn.Width = 100
        ListSachDaMuonDataGridView.Columns.Add(tinhTrangColumn)

        Dim ngayHetHanColumn = New DataGridViewTextBoxColumn()
        ngayHetHanColumn.Name = "NgayHetHan"
        ngayHetHanColumn.HeaderText = "Ngày hết hạn"
        ngayHetHanColumn.DataPropertyName = "NgayHetHan"
        ngayHetHanColumn.Width = 120
        ListSachDaMuonDataGridView.Columns.Add(ngayHetHanColumn)
    End Sub


#End Region

#End Region

#End Region

#Region "-  Confirm clicked   -"
    Private Sub ConfirmMetroButton_Click(sender As Object, e As EventArgs) Handles ConfirmMetroButton.Click
        Dim maPhieumuon = MaPhieuMuonTextBox.Text
        If Not WarningUnavailableMaPhieuMuonLabel.Visible Then
            If _phieuMuonSachBus.UpdateCheckOutPhieuMuonById(maPhieumuon).FlagResult Then
                MessageBox.Show("Trả sách thành công!")
            Else
                MessageBox.Show("Trả sách không thành công!")
            End If
        Else
            MessageBox.Show("Vui lòng nhập đúng mã phiếu mượn!")
        End If

    End Sub
#End Region

#End Region
End Class