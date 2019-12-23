Imports BUS
Imports DTO
Imports Utility

Public Class frmChoMuonSach

#Region "-  Fields   -"
    Private _quiDinhBus As QuiDinhBus
    Private _docGiaBus As DocGiaBus
    Private _tacGiaBus As TacGiaBUS
    Private _theLoaiSachBus As TheLoaiSachBUS
    Private _sachBus As SachBus
    Private _phieuMuonSachBus As PhieuMuonSachBus
    Private _chiTietPhieuMuonSach As ChiTietPhieuMuonSachBus

    Private _listPhieuMuonSachDaMuon As List(Of PhieuMuonSach)
    Private _listSach As List(Of Sach)
    Private _listTacGia As List(Of TacGia)
    Private _listTheLoaiSach As List(Of TheLoaiSach)


    Private AddNewRowButton As Button

#End Region

#Region "-   Constructor    -"
    Private Sub frmChoMuonSach_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitComponenents()
    End Sub
    Private Sub InitComponenents()
        ' -  Init Fields contant objects  
        _quiDinhBus = New QuiDinhBus()
        _docGiaBus = New DocGiaBus()
        _phieuMuonSachBus = New PhieuMuonSachBus()
        _sachBus = New SachBus()
        _tacGiaBus = New TacGiaBUS()
        _theLoaiSachBus = New TheLoaiSachBUS()
        _chiTietPhieuMuonSach = New ChiTietPhieuMuonSachBus()

        _listPhieuMuonSachDaMuon = New List(Of PhieuMuonSach)
        _listSach = New List(Of Sach)
        _listTacGia = New List(Of TacGia)
        _listTheLoaiSach = New List(Of TheLoaiSach)

        '"-  Load data for controls  -"
        LoadMaPhieuMuonSach()
        CreateListSachCanMuonDataGridViewColumn()

        If MapBorrowDateToExpirationDate().FlagResult = False Then Return
        LoadListSachDaMuonDataGridView(New List(Of PhieuMuonSach))

        If _tacGiaBus.SelectAll(_listTacGia).FlagResult = False Then Return
        If _theLoaiSachBus.SelectAll(_listTheLoaiSach).FlagResult = False Then Return
        'If _sachBus.SelectAll(_listSach).FlagResult = False Then Return

    End Sub

    Private Sub CreateListSachCanMuonDataGridViewColumn()
        dgvDanhSachCanMuon.Columns.Clear()
        dgvDanhSachCanMuon.DataSource = Nothing

        dgvDanhSachCanMuon.AutoGenerateColumns = False
        dgvDanhSachCanMuon.AllowUserToAddRows = False
        Dim clMa = New DataGridViewTextBoxColumn()
        clMa.Name = "MaSach"
        clMa.HeaderText = "Mã Sách"
        clMa.DataPropertyName = "MaSach"
        dgvDanhSachCanMuon.Columns.Add(clMa)

        Dim clTenSach = New DataGridViewTextBoxColumn()
        clTenSach.Name = "TenSach"
        clTenSach.HeaderText = "Tên Sách"
        clTenSach.DataPropertyName = "TenSach"
        dgvDanhSachCanMuon.Columns.Add(clTenSach)

        Dim clTheLoai = New DataGridViewTextBoxColumn()
        clTheLoai.Name = "TheLoai"
        clTheLoai.HeaderText = "Thể Loại"
        clTheLoai.DataPropertyName = "TheLoai"
        dgvDanhSachCanMuon.Columns.Add(clTheLoai)

        Dim clTacGia = New DataGridViewTextBoxColumn()
        clTacGia.Name = "TacGia"
        clTacGia.HeaderText = "Tác Giả"
        clTacGia.DataPropertyName = "Tacgia"
        dgvDanhSachCanMuon.Columns.Add(clTacGia)

        dgvDanhSachCanMuon.Columns(3).Width = 170

    End Sub

    Private Sub LoadMaPhieuMuonSach()
        Dim maPhieuMuonSach = String.Empty
        Dim result = _phieuMuonSachBus.LayMaSoPhieuMuonSachTiepTheo(maPhieuMuonSach)
        If result.FlagResult = True Then PhieuMuonSachIdTextBox.Text = maPhieuMuonSach
    End Sub

#End Region

#Region "-  Events  -"

#Region "-   Thay đổi ngày hết hạn mượn sách khi ngày mượn sách thay đổi   -"
    'Thay đổi ngày hết hạn mượn sách khi ngày mượn sách thay đổi
    Private Sub BorrowDateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles BorrowDateTimePicker.ValueChanged
        MapBorrowDateToExpirationDate()
    End Sub

    Private Function MapBorrowDateToExpirationDate() As Result
        Dim quiDinh = New QuiDinh()
        Dim result = _quiDinhBus.GetSoNgayMuonSachToiDa(quiDinh)
        If result.FlagResult = False Then Return result

        ExpirationTimePicker.Value =
            BorrowDateTimePicker.Value.AddDays(quiDinh.SoNgayMuonSachToiDa)
        Return result
    End Function

#End Region

#Region "-   Thay doi thong tin the doc gia khi ma doc gia thay doi   -"
    'Thay đổi thông tin thẻ độc giả khi người dùng nhập vào mã thẻ độc giả
    Private Sub ReaderIdTextBox_TextChanged(sender As Object, e As EventArgs) Handles ReaderIdTextBox.TextChanged
        RenderDataWhenReaderIdTextBoxChanged()
    End Sub

    Private Sub RenderDataWhenReaderIdTextBoxChanged()
        Dim docGia = New DocGia()
        Dim getReaderDataResult = GetReaderDataById(docGia)
        If getReaderDataResult.FlagResult = False Then
            docGia.TenDocGia = String.Empty
        End If

        UserNameTextBox.Text = docGia.TenDocGia

        _listPhieuMuonSachDaMuon.Clear()
        Dim ketQuaLayPhieuMuonSach =
            _phieuMuonSachBus.SelectAllSachChuaTraByReaderID(_listPhieuMuonSachDaMuon,
                                                     docGia.MaTheDocGia)
        LoadListSachDaMuonDataGridView(_listPhieuMuonSachDaMuon)
    End Sub

    Private Function GetReaderDataById(ByRef docGia As DocGia) As Result
        Try
            If String.IsNullOrWhiteSpace(ReaderIdTextBox.Text) = True Then Return New Result(False, "", "")
            docGia.MaTheDocGia = ReaderIdTextBox.Text
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
        Return _docGiaBus.
            GetReaderNameById(docGia.TenDocGia, docGia.MaTheDocGia)
    End Function
#End Region

#Region "-   Display warning reader id valdiate label depend on reader id   -"
    Private Sub ReaderIdTextBox_lostFocus(sender As Object, e As EventArgs) Handles ReaderIdTextBox.LostFocus

        Dim maTheDocGia = ReaderIdTextBox.Text

        WarningValidateReaderIdLabel.Visible = False
        If String.IsNullOrWhiteSpace(maTheDocGia) Then
            WarningValidateReaderIdLabel.Text = "Vui lòng nhập thẻ độc giả!"
            WarningValidateReaderIdLabel.Visible = True
            Return
        End If
        If Not IsReaderCardExist(maTheDocGia) Then Return
        If Not IsValidExpirationDateCard(maTheDocGia) Then Return
        If haveExpirationBookBorrowed(maTheDocGia) Then Return
    End Sub

    Private Function IsReaderCardExist(maTheDocGia As String) As Boolean

        Dim isTheDocGiaExist = _docGiaBus.GetReaderNameById(String.Empty, maTheDocGia)
        If isTheDocGiaExist.FlagResult = False Then
            WarningValidateReaderIdLabel.Text = "Mã thẻ độc giả không tồn tại!"
            WarningValidateReaderIdLabel.Visible = True
            Return False
        End If
        Return True
    End Function
    Private Function IsValidExpirationDateCard(maTheDocGia As String) As Boolean

        Dim expirationDate = New DateTime()
        _docGiaBus.GetExpirationDateById(expirationDate, maTheDocGia)

        If expirationDate.Subtract(DateTime.Now).TotalSeconds < 0 Then
            WarningValidateReaderIdLabel.Text = "Mã thẻ độc giả hết hạn sử dụng!"
            WarningValidateReaderIdLabel.Visible = True
            Return False
        End If
        Return True
    End Function
    Private Function haveExpirationBookBorrowed(maTheDocGia As String) As Boolean
        Dim listPhieuMuonSach = New List(Of PhieuMuonSach)
        If _phieuMuonSachBus.SelectAllSachChuaTraByReaderID(listPhieuMuonSach, maTheDocGia).FlagResult = False Then Return False

        For Each phieuMuonSAch In listPhieuMuonSach
            If phieuMuonSAch.HanTra.Subtract(DateTime.Now).TotalSeconds < 0 Then
                WarningValidateReaderIdLabel.Text = "Mã thẻ độc giả có sách mượn quá hạn!"
                WarningValidateReaderIdLabel.Visible = True
                Return True
            End If
        Next
        Return False
    End Function

#End Region

#Region "-   Load list sach da muon datagridview   -"
    Private Sub LoadListSachDaMuonDataGridView(listPhieuMuonSachDaMuon As List(Of PhieuMuonSach))
        ClearBookBorrowedDataGridViewData()

        BindingSourceBookBorrowedDataGridViewData(listPhieuMuonSachDaMuon)

        AddColumnTitle()
    End Sub

    Private Sub AddColumnTitle()
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
        tinhTrangColumn.Width = 120
        ListSachDaMuonDataGridView.Columns.Add(tinhTrangColumn)

        Dim ngayHetHanColumn = New DataGridViewTextBoxColumn()
        ngayHetHanColumn.Name = "NgayHetHan"
        ngayHetHanColumn.HeaderText = "Ngày hết hạn"
        ngayHetHanColumn.DataPropertyName = "NgayHetHan"
        ngayHetHanColumn.Width = 140
        ListSachDaMuonDataGridView.Columns.Add(ngayHetHanColumn)
    End Sub

    Private Sub BindingSourceBookBorrowedDataGridViewData(listPhieuMuonSachDaMuon As List(Of PhieuMuonSach))

        If listPhieuMuonSachDaMuon.Count < 1 Then Return
        Dim listChiTietPhieuMuonSachDaMuon = New List(Of ChiTietPhieuMuonSach)
        Dim listSachDaMuon = New List(Of Sach)
        Dim listCustomBookInfoDisplay = New List(Of CustomBookInfoDisplay)

        For Each phieuMuonSach In listPhieuMuonSachDaMuon
            _chiTietPhieuMuonSach.selectAllByMaphieumuonsach(listChiTietPhieuMuonSachDaMuon, phieuMuonSach.MaPhieuMuonSach)
        Next

        For Each chiTietPhieuMuonSach In listChiTietPhieuMuonSachDaMuon
            ' TODO: fix sach
            '_sachBus.SelectAllByMaSach(listSachDaMuon, chiTietPhieuMuonSach.MaSach)
        Next

        For Each sach In listSachDaMuon
            Dim maPhieuMuonSach = listChiTietPhieuMuonSachDaMuon.
                Where(Function(s) s.MaSach = sach.MaSach).
                Select(Function(s) s.MaPhieuMuonSach).First()

            Dim phieuMuonSach = listPhieuMuonSachDaMuon.Where(Function(s) s.MaPhieuMuonSach = maPhieuMuonSach).First()

            Dim customBook = New CustomBookInfoDisplay()
            customBook.MaSach = sach.MaSach
            'customBook.TenSach = sach.TenSach
            '_tacGiaBus.GetTenTacGiaByMaTacGia(customBook.TacGia, sach.MaTacGia)
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

#End Region

#Region "-   Cập nhật thông tin sách chọn khi masach thay đổi    -"
    Private Sub txtMaSach_TextChanged(sender As Object, e As EventArgs) Handles txtMaSach.TextChanged
        Try
            Dim maSach = txtMaSach.Text
            LoadInfoBook(maSach)

        Catch ex As Exception
        End Try
    End Sub
    Private Sub LoadInfoBook(maSach As String)
        Dim tenSach = String.Empty
        Dim tacGia = String.Empty
        Dim theLoai = String.Empty
        Dim tinhTrangSach = 0
        Dim result As Result

        'result = _sachBus.SelectByType(maSach, tenSach, theLoai, tacGia, tinhTrangSach)

        txtTenSach.Text = tenSach
        txtTacGia.Text = tacGia
        txtTheLoai.Text = theLoai

        txtTinhTrangSach.Text = If(tinhTrangSach = 0, "Còn", "Đã hết sách")
        txtTinhTrangSach.BackColor = txtTinhTrangSach.BackColor
        txtTinhTrangSach.ForeColor = If(tinhTrangSach = 0, Color.Black, Color.Red)

    End Sub
#End Region

#Region "-  Thêm và bớt sách cần mượn"
    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        'Guard clause: c Handles btnThem.Clicka chua
        If WarningValidateReaderIdLabel.Visible Or String.IsNullOrWhiteSpace(ReaderIdTextBox.Text) Then
            MessageBox.Show("Vui lòng nhập mã thẻ độc giả!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim isUnvalidBookInfo As Boolean = String.IsNullOrWhiteSpace(txtMaSach.Text) Or
            String.IsNullOrWhiteSpace(txtTenSach.Text) Or
            String.IsNullOrWhiteSpace(txtTinhTrangSach.Text) Or
            String.IsNullOrWhiteSpace(txtTheLoai.Text) Or
            String.IsNullOrWhiteSpace(txtTacGia.Text)
        If isUnvalidBookInfo Then
            Return
        End If


        If Not _phieuMuonSachBus.IsValidNumberOfBooks(dgvDanhSachCanMuon.Rows.Count + ListSachDaMuonDataGridView.Rows.Count) Then
            MessageBox.Show("Quá số lượng sách cho mượn", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If


        If (txtTinhTrangSach.Text = "Đã hết sách") Then
            MessageBox.Show("Sách đã cho mượn", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        'Add distince book info
        ThemInfoSachCanMuonVaoDataGridView()
    End Sub

    Private Sub ThemInfoSachCanMuonVaoDataGridView()
        Dim rnum As Integer = dgvDanhSachCanMuon.Rows.Add()

        dgvDanhSachCanMuon.Rows.Item(rnum).Cells("MaSach").Value = txtMaSach.Text
        dgvDanhSachCanMuon.Rows.Item(rnum).Cells("TenSach").Value = txtTenSach.Text
        dgvDanhSachCanMuon.Rows.Item(rnum).Cells("TheLoai").Value = txtTheLoai.Text
        dgvDanhSachCanMuon.Rows.Item(rnum).Cells("TacGia").Value = txtTacGia.Text

        Dim numberOfRows = dgvDanhSachCanMuon.Rows.Count - 1 'subtract the last row which is an editing row
        Dim i As Integer = 0

        While i < numberOfRows

            For j As Integer = (numberOfRows) To (i + 1) Step -1
                If dgvDanhSachCanMuon.Rows(i).Cells("MaSach").Value.ToString() = dgvDanhSachCanMuon.Rows(j).Cells("MaSach").Value.ToString() Then
                    dgvDanhSachCanMuon.Rows.Remove(dgvDanhSachCanMuon.Rows(j))
                    numberOfRows -= 1
                End If
            Next
            i += 1
        End While

    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click

        For Each row As DataGridViewRow In dgvDanhSachCanMuon.SelectedRows
            dgvDanhSachCanMuon.Rows.RemoveAt(row.Index)
        Next
    End Sub
#End Region

#Region "-   Insert confirm button click   -"
    Private Sub ConfirmButton_Click(sender As Object, e As EventArgs) Handles ConfirmButton.Click

        Dim insertPhieuMuonSachResult = InsertPhieuMuonSach()
        If insertPhieuMuonSachResult.FlagResult = False Then
            MessageBox.Show(insertPhieuMuonSachResult.ApplicationMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim insertCacChiTietPhieuMuonSachResult = InsertCacChiTietPhieuMuonSachTuongUng()
        If insertCacChiTietPhieuMuonSachResult.FlagResult = False Then
            MessageBox.Show("Cho mượn sách không thành công!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        MessageBox.Show("Thêm phiếu mượn sách thành công", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Update sachdatmuon grid view
        RenderDataWhenReaderIdTextBoxChanged()
        'Reset sach can muon dataGridview
        dgvDanhSachCanMuon.Rows.Clear()
        dgvDanhSachCanMuon.Refresh()
        'Update ma phieu muon sach tiep theo
        PhieuMuonSachIdTextBox.Text = PhieuMuonSachIdTextBox.Text + 1
    End Sub

    Private Function InsertCacChiTietPhieuMuonSachTuongUng() As Result
        Dim maPhieuMuonSachHienTai = String.Empty
        _phieuMuonSachBus.SelectIdTheLastOne(maPhieuMuonSachHienTai)

        Dim numberOfRows = dgvDanhSachCanMuon.Rows.Count - 1
        For i As Integer = 0 To numberOfRows
            Dim chiTietPhieuMuonSach = New ChiTietPhieuMuonSach()
            chiTietPhieuMuonSach.MaPhieuMuonSach = maPhieuMuonSachHienTai
            chiTietPhieuMuonSach.MaSach = dgvDanhSachCanMuon.Rows(i).Cells("MaSach").Value.ToString()

            Dim insertChitietphieumuonsachResult = _chiTietPhieuMuonSach.InsertOne(chiTietPhieuMuonSach)
            If insertChitietphieumuonsachResult.FlagResult = False Then
                Return insertChitietphieumuonsachResult
            End If
        Next

        Return New Result()
    End Function

    Private Function InsertPhieuMuonSach() As Result
        Dim phieuMuonSAch = New PhieuMuonSach()
        phieuMuonSAch.MaTheDocGia = ReaderIdTextBox.Text
        phieuMuonSAch.NgayMuon = BorrowDateTimePicker.Value
        phieuMuonSAch.HanTra = ExpirationTimePicker.Value
        Dim insertPhieumuonsachResult = _phieuMuonSachBus.InsertOne(phieuMuonSAch)
        If insertPhieumuonsachResult.FlagResult = False Then Return insertPhieumuonsachResult
        Return New Result()
    End Function

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        Me.Controls.Clear()
        Me.InitializeComponent()
        InitComponenents()
    End Sub

#End Region

#End Region

End Class