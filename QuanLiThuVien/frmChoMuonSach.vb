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
    Private _chiTietPhieuMuonSach As ChiTietPhieuMuonSachBus

    Private _listPhieuMuonSachDaMuon As List(Of PhieuMuonSach)
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
        _chiTietPhieuMuonSach = New ChiTietPhieuMuonSachBus()

        _listPhieuMuonSachDaMuon = New List(Of PhieuMuonSach)
        _listSach = New List(Of Sach)
        _listTacGia = New List(Of TacGia)
        _listTheLoaiSach = New List(Of TheLoaiSach)

        _listControlBookInfoControl = New List(Of BookInfoControl)

        AddNewRowButton = New Button()

        '"-  Load data for controls  -"
        LoadMaPhieuMuonSach()

        If MapBorrowDateToExpirationDate().FlagResult = False Then Return
        LoadListSachDaMuonDataGridView(New List(Of PhieuMuonSach))

        If _tacGiaBus.SelectAll(_listTacGia).FlagResult = False Then Return
        If _theLoaiSachBus.SelectAll(_listTheLoaiSach).FlagResult = False Then Return
        If _sachBus.SelectAll(_listSach).FlagResult = False Then Return

        ' design
        AddHandler ReaderIdTextBox.LostFocus, AddressOf ReaderIdTextBox_lostFocus
        CreateControlInChoMuonSachPanel()
    End Sub

    Private Sub CreateControlInChoMuonSachPanel()
        SachCanMuonPanel.Controls.Clear()

        AddNewRowButton.BackColor = ColorTranslator.FromHtml("#28A745")
        AddNewRowButton.Text = "Thêm dòng"
        AddNewRowButton.ForeColor = Color.White
        AddNewRowButton.Font = New Font("Microsoft Sans Serif", 10)
        AddNewRowButton.Width = 72
        AddNewRowButton.Height = 26
        AddNewRowButton.FlatStyle = FlatStyle.Flat
        AddNewRowButton.Location = New Point(SachCanMuonPanel.Width - AddNewRowButton.Width, 0)
        AddNewRowButton.FlatAppearance.BorderSize = 0
        RemoveHandler AddNewRowButton.Click, AddressOf addNewRowButton_Click
        AddHandler AddNewRowButton.Click, AddressOf addNewRowButton_Click

        Dim quiDinh = New QuiDinh()
        _quiDinhBus.LaySoSachMuonToiDa(quiDinh)
        Dim listPhieuSachDAMuon = New List(Of PhieuMuonSach)
        _phieuMuonSachBus.SelectAllSachChuaTraByReaderID(listPhieuSachDAMuon, ReaderIdTextBox.Text)

        If _listPhieuMuonSachDaMuon.Count < quiDinh.SoSachMuonToiDa Then
            AddNewRow()
        End If

        Try
            Dim firstControlBookInfoElement = _listControlBookInfoControl(0)
            AddNewRowButton.Location = New Point(firstControlBookInfoElement.GetButton().Location.X,
                                             firstControlBookInfoElement.Height + firstControlBookInfoElement.Location.Y + 10)
        Catch
        End Try

        SachCanMuonPanel.Controls.Add(AddNewRowButton)
    End Sub

#Region "-    Display warning reader id valdiate label depend on reader id"
    Private Sub ReaderIdTextBox_lostFocus(sender As Object, e As EventArgs)
        If Not IsReaderCardExist() Then Return
        If Not IsValidExpirationDateCard() Then Return
        If haveExpirationBookBorrowed() Then Return
        WarningValidateReaderIdLabel.Visible = False

    End Sub

    Private Function IsReaderCardExist() As Boolean
        Dim maTheDocGia = ReaderIdTextBox.Text

        Dim isTheDocGiaExist = _docGiaBus.SelectReaderNameById(String.Empty, maTheDocGia)
        If isTheDocGiaExist.FlagResult = False Then
            WarningValidateReaderIdLabel.Text = "Mã thẻ độc giả không tồn tại!"
            WarningValidateReaderIdLabel.Visible = True
            Return False
        End If
        Return True
    End Function
    Private Function IsValidExpirationDateCard() As Boolean
        Dim maTheDocGia = ReaderIdTextBox.Text

        Dim expirationDate = New DateTime()
        _docGiaBus.SelectExpirationDateById(expirationDate, maTheDocGia)

        If expirationDate.Subtract(DateTime.Now).TotalSeconds < 0 Then
            WarningValidateReaderIdLabel.Text = "Mã thẻ độc giả hết hạn sử dụng!"
            WarningValidateReaderIdLabel.Visible = True
            Return False
        End If
        Return True
    End Function
    Private Function haveExpirationBookBorrowed() As Boolean
        Dim maTheDocGia = ReaderIdTextBox.Text
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

    Private Sub LoadMaPhieuMuonSach()
        Dim maPhieuMuonSach = String.Empty
        Dim result = _phieuMuonSachBus.LayMaSoPhieuMuonSachTiepTheo(maPhieuMuonSach)
        If result.FlagResult = True Then PhieuMuonSachIdTextBox.Text = maPhieuMuonSach
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
            UserNameTextBox.Text = String.Empty
            Return
        End If

        UserNameTextBox.Text = docGia.TenDocGia

        _listPhieuMuonSachDaMuon.Clear()
        Dim ketQuaLayPhieuMuonSach =
            _phieuMuonSachBus.SelectAllSachChuaTraByReaderID(_listPhieuMuonSachDaMuon,
                                                     docGia.MaTheDocGia)
        LoadListSachDaMuonDataGridView(_listPhieuMuonSachDaMuon)
    End Sub

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
        tinhTrangColumn.Width = 100
        ListSachDaMuonDataGridView.Columns.Add(tinhTrangColumn)

        Dim ngayHetHanColumn = New DataGridViewTextBoxColumn()
        ngayHetHanColumn.Name = "NgayHetHan"
        ngayHetHanColumn.HeaderText = "Ngày hết hạn"
        ngayHetHanColumn.DataPropertyName = "NgayHetHan"
        ngayHetHanColumn.Width = 120
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
            _sachBus.SelectAllByMaSach(listSachDaMuon, chiTietPhieuMuonSach.MaSach)
        Next

        For Each sach In listSachDaMuon
            Dim maPhieuMuonSach = listChiTietPhieuMuonSachDaMuon.
                Where(Function(s) s.MaSach = sach.MaSach).
                Select(Function(s) s.MaPhieuMuonSach).First()

            Dim phieuMuonSach = listPhieuMuonSachDaMuon.Where(Function(s) s.MaPhieuMuonSach = maPhieuMuonSach).First()

            Dim customBook = New CustomBookInfoDisplay()
            customBook.MaSach = sach.MaSach
            customBook.TenSach = sach.TenSach
            _tacGiaBus.SelectTenTacGiaByMaTacGia(customBook.TacGia, sach.MaTacGia)
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

    Private Function GetReaderDataById(ByRef docGia As DocGia) As Result
        Try
            If String.IsNullOrWhiteSpace(ReaderIdTextBox.Text) = True Then Return New Result(False, "", "")
            docGia.MaTheDocGia = ReaderIdTextBox.Text
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
        Return _docGiaBus.
            SelectReaderNameById(docGia.TenDocGia, docGia.MaTheDocGia)
    End Function

#Region "-   Insert confirm button click   -"
    Private Sub ConfirmButton_Click(sender As Object, e As EventArgs) Handles ConfirmButton.Click
        RemoveNoneBookInfoRow()

        Dim insertPhieuMuonSachResult = InsertPhieuMuonSach()
        If insertPhieuMuonSachResult.FlagResult = False Then
            _listControlBookInfoControl.Clear()
            CreateControlInChoMuonSachPanel()
            MessageBox.Show(insertPhieuMuonSachResult.ApplicationMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim insertCacChiTietPhieuMuonSachResult = InsertCacChiTietPhieuMuonSachTuongUng()
        If insertCacChiTietPhieuMuonSachResult.FlagResult = False Then
            _listControlBookInfoControl.Clear()
            CreateControlInChoMuonSachPanel()
            MessageBox.Show("Cho mượn sách không thành công!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        MessageBox.Show("Thêm phiếu mượn sách thành công", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Function InsertCacChiTietPhieuMuonSachTuongUng() As Result
        Dim maPhieuMuonSachHienTai = String.Empty
        _phieuMuonSachBus.SelectIdTheLastOne(maPhieuMuonSachHienTai)

        For Each control As BookInfoControl In _listControlBookInfoControl
            Dim chiTietPhieuMuonSach = New ChiTietPhieuMuonSach()
            chiTietPhieuMuonSach.MaPhieuMuonSach = maPhieuMuonSachHienTai
            chiTietPhieuMuonSach.MaSach = control.GetBookIdTextBox.text
            Dim insertChitietphieumuonsachResult = _chiTietPhieuMuonSach.InsertOne(chiTietPhieuMuonSach)
            If insertChitietphieumuonsachResult.FlagResult = False Then
                'TODO: xóa phiếu mượn sách và các chi tiết phiếu mượn sách đã insert phía trước
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
        phieuMuonSAch.TongSoSachMuon = _listControlBookInfoControl.Count
        Dim insertPhieumuonsachResult = _phieuMuonSachBus.InsertOne(phieuMuonSAch)
        If insertPhieumuonsachResult.FlagResult = False Then Return insertPhieumuonsachResult
        Return New Result()
    End Function

    Private Sub RemoveNoneBookInfoRow()
        'remove none info row
        For index = 0 To _listControlBookInfoControl.Count - 1
            If _listControlBookInfoControl.Count < 1 Then Return
            If RemoveSpecificRowIfItEmptyBookId(index) Then index = index - 1
        Next
    End Sub

    Private Function RemoveSpecificRowIfItEmptyBookId(index As Integer) As Boolean
        Dim Control = _listControlBookInfoControl(index)
        Dim isEmptyTextBox = Control.GetBookIdTextBox.Text = Control.GetBookIdTextBox.PlaceHolderText Or String.IsNullOrWhiteSpace(Control.GetBookIdTextBox.Text)
        If isEmptyTextBox Then
            _listControlBookInfoControl.Remove(Control)
            Return True
        End If
        Return False
    End Function
#End Region

#End Region

#Region "-  Events for Custom book info controls  -"
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
        SachCanMuonPanel.Controls.Add(bookInfoControl)

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

            Console.WriteLine("Ma sach: " & maSach)
            _sachBus.SelectTenSachByMaSach(sach, maSach)
            _tacGiaBus.SelectTacGiaByMaTacGia(tacGia, sach.MaTacGia)
            _theLoaiSachBus.SelectTheLoaiSachByMaTheLoaiSach(theLoaiSach, sach.MaTheLoaiSach)
            Console.WriteLine("MaThe loai: " & theLoaiSach.MaTheLoaiSach)
            Console.WriteLine("Ma tac gia: " & tacGia.MaTacGia)

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
        Dim quiDinh = New QuiDinh()
        Dim result = _quiDinhBus.LaySoSachMuonToiDa(quiDinh)

        Dim listChiTietPhieuMuonSAchDaMuon = New List(Of ChiTietPhieuMuonSach)
        For Each phieuMuonSach In _listPhieuMuonSachDaMuon
            _chiTietPhieuMuonSach.selectAllByMaphieumuonsach(listChiTietPhieuMuonSAchDaMuon, phieuMuonSach.MaPhieuMuonSach)
        Next
        If _listControlBookInfoControl.Count + listChiTietPhieuMuonSAchDaMuon.Count >= quiDinh.SoSachMuonToiDa Then
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
        SachCanMuonPanel.Controls.Remove(bookInfoControl)
        _listControlBookInfoControl.Remove(bookInfoControl)
    End Sub

#End Region

End Class