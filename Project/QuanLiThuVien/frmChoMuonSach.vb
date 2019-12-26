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
    Private _dauSachBus As DauSachBus
    Private _phieuMuonSachBus As PhieuMuonSachBus
    Private _chiTietPhieuMuonSach As ChiTietPhieuMuonSachBus

    Private _listPhieuMuonSachDaMuon As List(Of PhieuMuonSach)
    Private _listSach As List(Of Sach)
    Private _listTacGia As List(Of TacGia)
    Private _listTheLoaiSach As List(Of TheLoaiSach)
    Private _listIdCuonSachAvailable As List(Of Integer)
    Private _sachDangChon As Sach


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
        _dauSachBus = New DauSachBus()

        _listPhieuMuonSachDaMuon = New List(Of PhieuMuonSach)
        _listSach = New List(Of Sach)
        _listTacGia = New List(Of TacGia)
        _listTheLoaiSach = New List(Of TheLoaiSach)
        _sachDangChon = New Sach()

        '"-  Load data for controls  -"
        LoadMaPhieuMuonSach()
        CreateListSachCanMuonDataGridViewColumn()

        If MapBorrowDateToExpirationDate().FlagResult = False Then Return
        LoadListSachDaMuonDataGridView(New List(Of CustomBookInfoDisplay))

        If _tacGiaBus.SelectAll(_listTacGia).FlagResult = False Then Return
        If _theLoaiSachBus.SelectAll(_listTheLoaiSach).FlagResult = False Then Return

    End Sub

    Private Sub CreateListSachCanMuonDataGridViewColumn()
        dgvDanhSachCanMuon.Columns.Clear()
        dgvDanhSachCanMuon.DataSource = Nothing

        dgvDanhSachCanMuon.AutoGenerateColumns = False
        dgvDanhSachCanMuon.AllowUserToAddRows = False
        Dim clMa = New DataGridViewTextBoxColumn()
        clMa.Name = "MaDauSach"
        clMa.HeaderText = "Mã Đầu Sách"
        clMa.DataPropertyName = "MaDauSach"
        dgvDanhSachCanMuon.Columns.Add(clMa)

        Dim clMaCuonSAch = New DataGridViewTextBoxColumn()
        clMaCuonSAch.Name = "MaCuonSach"
        clMaCuonSAch.HeaderText = "Mã Cuốn Sách"
        clMaCuonSAch.DataPropertyName = "MaCuonSach"
        dgvDanhSachCanMuon.Columns.Add(clMaCuonSAch)

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
        UserNameTextBox.Text = ""
        Dim docGia As DocGia
        Dim result = _docGiaBus.GetReaderById(docGia, ReaderIdTextBox.Text)
        If (result.FlagResult AndAlso docGia IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(docGia.TenDocGia)) Then
            UserNameTextBox.Text = docGia.TenDocGia
            Dim sachInfo As List(Of CustomBookInfoDisplay)
            sachInfo = New List(Of CustomBookInfoDisplay)
            _phieuMuonSachBus.SelectRentSachByDocGiaId(ReaderIdTextBox.Text, sachInfo)
            LoadListSachDaMuonDataGridView(sachInfo)
        End If

    End Sub

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
    Private Sub LoadListSachDaMuonDataGridView(sachInfo As List(Of CustomBookInfoDisplay))
        ClearBookBorrowedDataGridViewData()

        BindingSourceBookBorrowedDataGridViewData(sachInfo)

        AddColumnTitle()
    End Sub

    Private Sub AddColumnTitle()
        Dim maSachColumn = New DataGridViewTextBoxColumn()
        maSachColumn.Name = "MaDauSach"
        maSachColumn.HeaderText = "Mã đầu sách"
        maSachColumn.DataPropertyName = "MaDauSach"
        maSachColumn.Width = 50
        ListSachDaMuonDataGridView.Columns.Add(maSachColumn)

        Dim csIdClmn = New DataGridViewTextBoxColumn()
        csIdClmn.Name = "MaCuonSach"
        csIdClmn.HeaderText = "Mã sách"
        csIdClmn.DataPropertyName = "MaCuonSach"
        csIdClmn.Width = 50
        ListSachDaMuonDataGridView.Columns.Add(csIdClmn)

        Dim phieuMuonIdClmn = New DataGridViewTextBoxColumn()
        phieuMuonIdClmn.Name = "MaPhieuMuonSach"
        phieuMuonIdClmn.HeaderText = "Mã phiếu mượn sách"
        phieuMuonIdClmn.DataPropertyName = "MaPhieuMuonSach"
        phieuMuonIdClmn.Width = 50
        ListSachDaMuonDataGridView.Columns.Add(phieuMuonIdClmn)


        Dim tinhTrangColumn = New DataGridViewTextBoxColumn()
        tinhTrangColumn.Name = "TinhTrang"
        tinhTrangColumn.HeaderText = "Tình trạng"
        tinhTrangColumn.DataPropertyName = "TinhTrang"
        tinhTrangColumn.Width = 120
        ListSachDaMuonDataGridView.Columns.Add(tinhTrangColumn)


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

        Dim ngMuonCln = New DataGridViewTextBoxColumn()
        ngMuonCln.Name = "NgayMuon"
        ngMuonCln.HeaderText = "Ngày mượn"
        ngMuonCln.DataPropertyName = "NgayMuon"
        ngMuonCln.Width = 140
        ListSachDaMuonDataGridView.Columns.Add(ngMuonCln)

        Dim ngayHetHanColumn = New DataGridViewTextBoxColumn()
        ngayHetHanColumn.Name = "NgayHetHan"
        ngayHetHanColumn.HeaderText = "Ngày hết hạn"
        ngayHetHanColumn.DataPropertyName = "NgayHetHan"
        ngayHetHanColumn.Width = 140
        ListSachDaMuonDataGridView.Columns.Add(ngayHetHanColumn)
    End Sub

    Private Sub BindingSourceBookBorrowedDataGridViewData(customBook As List(Of CustomBookInfoDisplay))
        ListSachDaMuonDataGridView.DataSource = New BindingSource(customBook, String.Empty)
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
            Dim maCuonSach = txtMaSach.Text
            LoadInfoBook(maCuonSach)

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("errror" & ex.ToString)

        End Try
    End Sub
    Private Sub LoadInfoBook(maCS As String)
        resetSachInputFields()
        Dim tacGia = String.Empty
        Dim theLoai = String.Empty
        Dim result As Result

        result = _sachBus.SelectById(maCS, _sachDangChon)
        Dim dauSach = New DauSachDTO()

        Try
            If (result.FlagResult) Then
                _dauSachBus.GetById(dauSach, _sachDangChon.MaDauSach)
                _tacGiaBus.GetTenTacGiaByMaTacGia(tacGia, dauSach.MaTacGia)
                _theLoaiSachBus.GetTenTheLoaiSachByID(theLoai, dauSach.MaTheLoaiSach)
                If result.FlagResult Then
                    txtTenSach.Text = dauSach.TenSach
                    txtTacGia.Text = tacGia
                    txtTheLoai.Text = theLoai
                    txtSlSachCon.Text = If(_sachDangChon.TinhTrang = 0, "Còn", "Đã hết Sách")
                    txtSlSachCon.BackColor = txtSlSachCon.BackColor
                    txtSlSachCon.ForeColor = If(Not _sachDangChon.TinhTrang = 0, Color.Red, Color.Black)
                End If
            Else
                txtTenSach.Text = String.Empty
                txtTacGia.Text = String.Empty
                txtTheLoai.Text = String.Empty
            End If

        Catch ex As Exception

            txtTenSach.Text = String.Empty
            txtTacGia.Text = String.Empty
            txtTheLoai.Text = String.Empty
        End Try
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
            String.IsNullOrWhiteSpace(txtSlSachCon.Text) Or
            String.IsNullOrWhiteSpace(txtTheLoai.Text) Or
            String.IsNullOrWhiteSpace(txtTacGia.Text)
        If isUnvalidBookInfo Then
            Return
        End If


        If Not _phieuMuonSachBus.IsValidNumberOfBooks(dgvDanhSachCanMuon.Rows.Count + ListSachDaMuonDataGridView.Rows.Count) Then
            MessageBox.Show("Quá số lượng sách cho mượn", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If


        If (txtSlSachCon.Text = "Đã hết sách") Then
            MessageBox.Show("Sách đã cho mượn", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        'Add distince book info
        ThemInfoSachCanMuonVaoDataGridView()
        resetSachInputFields()
    End Sub

    Private Sub resetSachInputFields()
        txtTenSach.Text = String.Empty
        txtTacGia.Text = String.Empty
        txtTheLoai.Text = String.Empty
        txtSlSachCon.Text = String.Empty
    End Sub

    Private Sub ThemInfoSachCanMuonVaoDataGridView()
        addOneRowToGrid(txtMaSach.Text)
    End Sub

    Private Sub addOneRowToGrid(id As Integer)
        System.Console.WriteLine("Log text")
        Dim maDauSach = txtMaSach.Text
        Dim maCuonSach = id
        Dim tenSach = txtTenSach.Text
        Dim theLoai = txtTheLoai.Text
        Dim tacGia = txtTacGia.Text

        dgvDanhSachCanMuon.Rows.Add(New String() {maDauSach, maCuonSach, tenSach, theLoai, tacGia})
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
            chiTietPhieuMuonSach.MaSach = dgvDanhSachCanMuon.Rows(i).Cells("MaCuonSach").Value.ToString()

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

    Private Sub MetroLabel7_Click(sender As Object, e As EventArgs) Handles MetroLabel7.Click

    End Sub

#End Region

#End Region

End Class