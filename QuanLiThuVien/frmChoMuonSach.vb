﻿Imports BUS
Imports DTO
Imports Utility
Imports MetroFramework.Forms

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

        If _tacGiaBus.SelectAll(_listTacGia).FlagResult = False Then Return
        If _theLoaiSachBus.SelectAll(_listTheLoaiSach).FlagResult = False Then Return
        If _sachBus.SelectAll(_listSach).FlagResult = False Then Return

        ' design
        'TODO: Không hiển thị chỗ nhập sách nếu độc giả đã mượn đủ số sách

        AddNewRowButton.BackColor = ColorTranslator.FromHtml("#28A745")
        AddNewRowButton.Text = "Thêm dòng"
        AddNewRowButton.ForeColor = Color.White
        AddNewRowButton.Font = New Font("Microsoft Sans Serif", 10)
        AddNewRowButton.Width = 72
        AddNewRowButton.Height = 26
        AddNewRowButton.FlatStyle = FlatStyle.Flat
        AddNewRowButton.Location = New Point(SachCanThuePanel.Width - AddNewRowButton.Width, 0)
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
            Return
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
        AddHandler bookInfoControl.UC_BookIDTextBox_TextChanged, AddressOf SachInfoControl_UC_BookIDTextBoxChanged

        _listControlBookInfoControl.Add(bookInfoControl)
        SachCanThuePanel.Controls.Add(bookInfoControl)

        Dim lastBookInfoControl = _listControlBookInfoControl(_listControlBookInfoControl.Count - 1)
        AddNewRowButton.Location = New Point(AddNewRowButton.Location.X,
                                             lastBookInfoControl.Location.Y + lastBookInfoControl.Height + 10)
    End Sub

    Private Sub SachInfoControl_UC_BookIDTextBoxChanged(sender As Object, e As EventArgs)
        DongBoHoaThongTinSachCanMuon(sender)
    End Sub

    Private Sub DongBoHoaThongTinSachCanMuon(sender As Object)
        Try
            Dim bookInfoControl As BookInfoControl = sender
            Dim maSach = bookInfoControl.GetBookIdTextBox.Text

            If String.IsNullOrWhiteSpace(maSach) Then Return

            Dim sach = New Sach()
            Dim tacGia = New TacGia()
            Dim theLoaiSach = New TheLoaiSach()
            sach.MaSach = maSach

            _sachBus.SelectTenSachByMaSach(sach, maSach)
            _tacGiaBus.SelectTacGiaByMaTacGia(tacGia, maSach)
            _theLoaiSachBus.SelectTheLoaiSachByMaTheLoaiSach(theLoaiSach, maSach)

            bookInfoControl.GetAuthorTextBox.text = tacGia.TenTacGia
            bookInfoControl.GetTypeOfBookTextBox.text = theLoaiSach.TenTheLoaiSach
            bookInfoControl.GetTitleTextBox.text = sach.TenSach

        Catch ex As Exception
        End Try
    End Sub
    Private Sub SachInfoControl_UC_ButtonClicked(sender As Object, e As EventArgs)
        Dim control As BookInfoControl = sender
        XoaDong(control)
    End Sub


    Private Function IsValidAmountBookCanBorrow() As Result
        'TODO: kiem tra so sach da muon+ voi so sach can muon co vuot qua qui dinh hay khong
        Dim quiDinh = New QuiDinh()
        Dim result = _quiDinhBus.LaySoSachMuonToiDa(quiDinh)
        If _listControlBookInfoControl.Count >= quiDinh.SoSachMuonToiDa Then
            Return New Result(False, "Đã đạt tối đa số lượng sách đã mượn :" + quiDinh.SoSachMuonToiDa.ToString(), "")
        End If
        Return New Result(True, "", "")
    End Function


    ' Xử lí khi book info control đã được click, click tiếp để bỏ dòng
    Private Sub XoaDong(bookInfoControl As BookInfoControl)
        Try
            RemoveDongCanXoa(bookInfoControl)

            If _listControlBookInfoControl.Count >= 1 Then
                MoveTheOtherRowsToNewLocation(bookInfoControl)
            Else
                SetAddNewRowButtonLocationToFirstRow()
            End If
        Catch
        End Try
    End Sub

    Private Sub MoveTheOtherRowsToNewLocation(bookInfoControl As BookInfoControl)
        Dim firstControl = _listControlBookInfoControl(0)
        firstControl.Location = New Point(0, 0)
        firstControl.GetSTTTextBox.Text = 1

        If _listControlBookInfoControl.Count > 1 Then
            For index = 1 To _listControlBookInfoControl.Count - 1
                Dim previousControl As BookInfoControl = _listControlBookInfoControl(index - 1)
                Dim currentControl As BookInfoControl = _listControlBookInfoControl(index)

                Dim yLocation = previousControl.Location.Y +
                    previousControl.Height

                currentControl.GetSTTTextBox.Text = index + 1
                currentControl.TabIndex = 5 + index
                currentControl.Location = New Point(0, yLocation)
            Next
        End If

        Dim lastBookInfoControl = _listControlBookInfoControl(_listControlBookInfoControl.Count - 1)
        AddNewRowButton.Location = New Point(AddNewRowButton.Location.X,
                                             lastBookInfoControl.Location.Y + bookInfoControl.Height + 10)
    End Sub

    Private Sub SetAddNewRowButtonLocationToFirstRow()
        AddNewRowButton.Location = New Point(AddNewRowButton.Location.X,
                                                     0)
    End Sub

    Private Sub RemoveDongCanXoa(bookInfoControl As BookInfoControl)
        SachCanThuePanel.Controls.Remove(bookInfoControl)
        _listControlBookInfoControl.Remove(bookInfoControl)
    End Sub


#End Region
End Class