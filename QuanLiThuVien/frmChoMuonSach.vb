Imports BUS
Imports DTO
Imports Utility

Public Class frmChoMuonSach
#Region "-  Fields  -"
    Private _quiDinhBus As QuiDinhBus
    Private _docGiaBus As DocGiaBus
    Private _tacGiaBus As TacGiaBUS
    Private _theLoaiSachBus As TheLoaiSachBUS
    Private _sachBus As SachBus
    Private _phieuMuonSachBus As PhieuMuonSachBus

    Private _listSach As List(Of Sach)
    Private _listTacGia As List(Of TacGia)
    Private _listTheLoaiSach As List(Of TheLoaiSach)

    Private _listControlBookInfoControl As List(Of BookInfoControl)
    Private AddNewRowButton As Button
#End Region

#Region "-  Constructor  -"
    Private Sub frmChoMuonSach_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' -  Init Fields contant objects  
        _quiDinhBus = New QuiDinhBus()
        _docGiaBus = New DocGiaBus()
        _phieuMuonSachBus = New PhieuMuonSachBus()
        _sachBus = New SachBus()
        _tacGiaBus = New TacGiaBUS()
        _theLoaiSachBus = New TheLoaiSachBUS()

        _listSach = New List(Of Sach)
        _listTacGia = New List(Of TacGia)
        _listTheLoaiSach = New List(Of TheLoaiSach)

        _listControlBookInfoControl = New List(Of BookInfoControl)

        AddNewRowButton = New Button()

        '"-  Load data for controls  -"
        If MapBorrowDateToExpirationDate().FlagResult = False Then Return
        LoadListSachDaMuonDataGridView(New List(Of PhieuMuonSach))
        If LoadDataListSachCoTheMuon().FlagResult = False Then Return
        If LoadDataListTheLoaiSachCoTheMuon().FlagResult = False Then Return
        If LoadDataListTenGiaSachCoTheMuon().FlagResult = False Then Return

        ' design
        SachCanThuePanel.VerticalScroll.Value = VerticalScroll.Minimum
        'TODO: Không hiển thị chỗ nhập sách nếu độc giả đã mượn đủ số sách

        AddNewRowButton.BackColor = ColorTranslator.FromHtml("#28A745")
        AddNewRowButton.Text = "Thêm dòng"
        AddNewRowButton.ForeColor = Color.White
        AddNewRowButton.Font = New Font("Microsoft Sans Serif", 10)
        AddNewRowButton.Width = 72
        AddNewRowButton.Height = 26
        AddNewRowButton.FlatStyle = FlatStyle.Flat
        AddNewRowButton.FlatAppearance.BorderSize = 0
        AddHandler AddNewRowButton.Click, AddressOf addNewRowButton_Click

        AddNewRow()

        Try
            Dim firstControlBookInfoElement = _listControlBookInfoControl(0)
            AddNewRowButton.Location = New Point(firstControlBookInfoElement.GetButton().Location.X,
                                             firstControlBookInfoElement.Height + firstControlBookInfoElement.Location.Y + 10)
        Catch
        End Try

        SachCanThuePanel.Controls.Add(AddNewRowButton)
    End Sub

    Private Function LoadDataListTenGiaSachCoTheMuon() As Result
        Dim tacGia = New TacGia(-1, "--- Chọn tên tác giả ---")
        _listTacGia.Add(tacGia)
        Return _tacGiaBus.SelectAll(_listTacGia)
    End Function

    Private Function LoadDataListTheLoaiSachCoTheMuon() As Result
        Dim theLoaiSach = New TheLoaiSach(-1, "--- Chọn thể loại sách ---")
        _listTheLoaiSach.Add(theLoaiSach)
        Return _theLoaiSachBus.SelectAll(_listTheLoaiSach)
    End Function

    Private Function LoadDataListSachCoTheMuon() As Result
        Dim sach = New Sach()
        sach.MaSach = -1
        sach.TenSach = "--- Chọn tên sách ---"
        _listSach.Add(sach)
        Return _sachBus.SelectAll(_listSach)
    End Function

    Private Sub addNewRowButton_Click(sender As Object, e As EventArgs)
        Try
            'Guard clause 
            Dim validateAmountBookCanBorrowResult = IsValidAmountBookCanBorrow()
            If validateAmountBookCanBorrowResult.FlagResult = False Then
                MessageBox.Show(validateAmountBookCanBorrowResult.ApplicationMessage)
                Return
            End If

            'Add new row 
            AddNewRow()
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "-  Events  -"
    Private Sub sachInfoControl_BookIdTextBoxChanged(sender As Object, e As EventArgs)
    End Sub

    'Thay đổi ngày hết hạn mượn sách khi ngày mượn sách thay đổi
    Private Sub BorrowDateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles BorrowDateTimePicker.ValueChanged
        MapBorrowDateToExpirationDate()
    End Sub

    Private Function MapBorrowDateToExpirationDate() As Result
        Dim quiDinh = New QuiDinh()
        Dim result = _quiDinhBus.LaySoNgayMuonSachToiDa(quiDinh)
        If result.FlagResult = False Then Return result

        ExpirationTimePicker.Value =
            BorrowDateTimePicker.Value.AddDays(quiDinh.SoNgayMuonSachToiDa)
        Return result
    End Function

    'Thay đổi thông tin thẻ độc giả khi người dùng nhập vào mã thẻ độc giả
    Private Sub ReaderIdTextBox_TextChanged(sender As Object, e As EventArgs) Handles ReaderIdTextBox.TextChanged
        Dim docGia = New DocGia()
        Dim getReaderDataResult = GetReaderDataById(docGia)
        If getReaderDataResult.FlagResult = False Then
            'TODO: xu li viec khong the lay thong tin doc gia
        End If

        UserNameTextBox.Text = docGia.TenDocGia

        Dim listPhieuMuonSach = New List(Of PhieuMuonSach)
        Dim ketQuaLayPhieuMuonSach =
            _phieuMuonSachBus.SelectAllByMaTheDocGia(listPhieuMuonSach,
                                                     docGia.MaTheDocGia)
        LoadListSachDaMuonDataGridView(listPhieuMuonSach)
    End Sub

    Private Sub LoadListSachDaMuonDataGridView(listPhieuMuonSachDaMuon As List(Of PhieuMuonSach))
        ListSachDaMuonDataGridView.Columns.Clear()
        ListSachDaMuonDataGridView.DataSource = Nothing
        ListSachDaMuonDataGridView.AutoGenerateColumns = False
        ListSachDaMuonDataGridView.AllowUserToAddRows = False

        ListSachDaMuonDataGridView.DataSource = New BindingSource(listPhieuMuonSachDaMuon, String.Empty)

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

    Private Function GetReaderDataById(ByRef docGia As DocGia) As Result
        If String.IsNullOrWhiteSpace(ReaderIdTextBox.Text) = True Then Return New Result(False, "", "")
        docGia.MaTheDocGia = ReaderIdTextBox.Text
        Return _docGiaBus.
            LayTenDocGiaBangMaThe(docGia.TenDocGia, docGia.MaTheDocGia)
    End Function

#End Region

#Region "-  Events for Custom controls  -"
    'Event thêm cho phần custom control hiển thị control để mượn sách
    'Control có hai trạng thái 
    '1 là đã click button để tạo dòng mới, button hiện thị có thể xóa dòng
    '2 là button chưa click là hàng cuối cùng có thể click tạo dòng mới để nhập

    Private Sub SachInfoControl_UC_ButtonClicked(sender As Object, e As EventArgs)
        Dim control As BookInfoControl = sender

        XoaDong(control)
    End Sub

    ' Xử lí khi book info control đã được click, click tiếp để bỏ dòng
    Private Sub XoaDong(bookInfoControl As BookInfoControl)
        Try
            SachCanThuePanel.Controls.Remove(bookInfoControl)
            _listControlBookInfoControl.Remove(bookInfoControl)
            If _listControlBookInfoControl.Count >= 1 Then
                _listControlBookInfoControl(0).Location = New Point(0, 0)
                Dim bookInfoControlTemp As BookInfoControl = SachCanThuePanel.Controls(0)
                bookInfoControlTemp.GetSTTTextBox.Text = 1

                For index = 1 To _listControlBookInfoControl.Count - 1
                    Dim yLocation = _listControlBookInfoControl(index - 1).Location.Y + _listControlBookInfoControl(index - 1).Height
                    bookInfoControlTemp = SachCanThuePanel.Controls(index)
                    bookInfoControlTemp.GetSTTTextBox.Text = index + 1
                    _listControlBookInfoControl(index).Location = New Point(0, yLocation)
                Next

                AddNewRowButton.Location = New Point(AddNewRowButton.Location.X,
                                                     _listControlBookInfoControl(_listControlBookInfoControl.Count - 1).Location.Y)
            Else
                AddNewRowButton.Location = New Point(AddNewRowButton.Location.X,
                                                 0)
            End If
        Catch

        End Try
    End Sub

    'Xử lí khi book info control vừa được tạo, click để tạo hàng mới
    Private Sub AddNewRow()
        Dim bookInfoControl = New BookInfoControl()

        If _listControlBookInfoControl.Count < 1 Then
            bookInfoControl.Location = New Point(0, 0)
            bookInfoControl.GetSTTTextBox.Text = 1
        Else
            Dim control = _listControlBookInfoControl(_listControlBookInfoControl.Count - 1)
            Dim y = control.Location.Y + control.Height
            bookInfoControl.Location = New Point(0, y)
            bookInfoControl.GetSTTTextBox.Text = _listControlBookInfoControl.Count + 1
        End If

        AddHandler bookInfoControl.UC_Button_Click, AddressOf SachInfoControl_UC_ButtonClicked

        Dim titleComboBox As ComboBox = bookInfoControl.GetTitleComboBox
        Dim bookIdTextBox As PlaceHolderTextBox = bookInfoControl.GetBookIdTextBox
        Dim typeOfBookComboBox As ComboBox = bookInfoControl.GetTypeOfBookComboBox
        Dim authorOfBookComboBox As ComboBox = bookInfoControl.GetAuthorComboBox

        bookIdTextBox.PlaceHolderText = "Nhập mã sách"
        titleComboBox.DataSource = _listSach
        titleComboBox.DisplayMember = "TenSach"
        titleComboBox.ValueMember = "MaSach"
        typeOfBookComboBox.DataSource = _listTheLoaiSach
        typeOfBookComboBox.DisplayMember = "TenTheLoaiSach"
        typeOfBookComboBox.ValueMember = "MaTheLoaiSach"
        authorOfBookComboBox.DataSource = _listTacGia
        authorOfBookComboBox.DisplayMember = "TenTacGia"
        authorOfBookComboBox.ValueMember = "MaTacGia"

        _listControlBookInfoControl.Add(bookInfoControl)
        SachCanThuePanel.Controls.Add(bookInfoControl)
        Dim lastBookInfoControl = _listControlBookInfoControl(_listControlBookInfoControl.Count - 1)
        AddNewRowButton.Location = New Point(AddNewRowButton.Location.X,
                                             lastBookInfoControl.Location.Y + lastBookInfoControl.Height + 10)
    End Sub

    Private Function IsValidAmountBookCanBorrow() As Result
        'TODO: giới hạn control có thể add
        Dim quiDinh = New QuiDinh()
        Dim result = _quiDinhBus.LaySoSachMuonToiDa(quiDinh)
        If _listControlBookInfoControl.Count >= quiDinh.SoSachMuonToiDa Then
            Return New Result(False, "Đã đạt tối đa số lượng sách đã mượn :" + quiDinh.SoSachMuonToiDa.ToString(), "")
        End If
        Return New Result(True, "", "")
    End Function
#End Region
End Class