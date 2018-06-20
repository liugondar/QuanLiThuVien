Imports BUS
Imports DTO
Imports Utility

Public Class frmChoMuonSach
#Region "-  Fields  -"
    Private _quiDinhBus As QuiDinhBus
    Private _docGiaBus As DocGiaBus
    Private _phieuMuonSachBus As PhieuMuonSachBus
    Private _sachBus As SachBus
    Private _listSach As List(Of Sach)
    Private _listControlBookInfoControl As List(Of BookInfoControl)
#End Region

#Region "-  Constructor  -"
    Private Sub frmChoMuonSach_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' -  Init Fields contant objects  
        _quiDinhBus = New QuiDinhBus()
        _docGiaBus = New DocGiaBus()
        _phieuMuonSachBus = New PhieuMuonSachBus()
        _listControlBookInfoControl = New List(Of BookInfoControl)
        _sachBus = New SachBus()

        '"-  Load data for controls  -"
        MapBorrowDateToExpirationDate()
        LoadListSachMuonDataGridView(New List(Of PhieuMuonSach))


        ' design
        SachCanThuePanel.VerticalScroll.Value = VerticalScroll.Minimum
        'TODO: Không hiển thị chỗ nhập sách nếu độc giả đã mượn đủ số sách
        Dim bookInfoControl = New BookInfoControl()
        bookInfoControl.Location = New Point(0, 0)
        AddHandler bookInfoControl.UC_Button_Click, AddressOf SachInfoControl_UC_ButtonClicked
        Dim sttTextBox As TextBox = bookInfoControl.GetSTTTextBox
        'TODO: Hiển thị danh sách data cho các combo box
        sttTextBox.Text = 1

        SachCanThuePanel.Controls.Add(bookInfoControl)
        _listControlBookInfoControl.Add(bookInfoControl)
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
        LoadListSachMuonDataGridView(listPhieuMuonSach)
    End Sub

    Private Sub LoadListSachMuonDataGridView(listPhieuMuonSach As List(Of PhieuMuonSach))
        ListSachMuonDataGridView.Columns.Clear()
        ListSachMuonDataGridView.DataSource = Nothing
        ListSachMuonDataGridView.AutoGenerateColumns = False
        ListSachMuonDataGridView.AllowUserToAddRows = False

        ListSachMuonDataGridView.DataSource = New BindingSource(listPhieuMuonSach, String.Empty)

        Dim maSachColumn = New DataGridViewTextBoxColumn()
        maSachColumn.Name = "MaSach"
        maSachColumn.HeaderText = "Mã sách"
        maSachColumn.DataPropertyName = "MaSach"
        maSachColumn.Width = 50
        ListSachMuonDataGridView.Columns.Add(maSachColumn)

        Dim tenSachColumn = New DataGridViewTextBoxColumn()
        tenSachColumn.Name = "TenSach"
        tenSachColumn.HeaderText = "Tên sách"
        tenSachColumn.DataPropertyName = "TenSach"
        tenSachColumn.Width = 200
        ListSachMuonDataGridView.Columns.Add(tenSachColumn)

        Dim tacGiaColumn = New DataGridViewTextBoxColumn()
        tacGiaColumn.Name = "TacGia"
        tacGiaColumn.HeaderText = "Tác giả "
        tacGiaColumn.DataPropertyName = "TacGia"
        tacGiaColumn.Width = 140
        ListSachMuonDataGridView.Columns.Add(tacGiaColumn)

        Dim tinhTrangColumn = New DataGridViewTextBoxColumn()
        tinhTrangColumn.Name = "TinhTrang"
        tinhTrangColumn.HeaderText = "Tình trạng"
        tinhTrangColumn.DataPropertyName = "TinhTrang"
        tinhTrangColumn.Width = 100
        ListSachMuonDataGridView.Columns.Add(tinhTrangColumn)

        Dim ngayHetHanColumn = New DataGridViewTextBoxColumn()
        ngayHetHanColumn.Name = "NgayHetHan"
        ngayHetHanColumn.HeaderText = "Ngày hết hạn"
        ngayHetHanColumn.DataPropertyName = "NgayHetHan"
        ngayHetHanColumn.Width = 120
        ListSachMuonDataGridView.Columns.Add(ngayHetHanColumn)
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

        If sender.isButtonClick = False Then
            XuLiKhiButtonTrongControlChuaClick(control)
        Else
            XuLiKhiButtonDaClickDeTaoDongMoi(sender)
        End If
    End Sub

    ' Xử lí khi book info control đã được click, click tiếp để bỏ dòng
    Private Sub XuLiKhiButtonDaClickDeTaoDongMoi(sender As Object)
        Try
            SachCanThuePanel.Controls.Remove(sender)
            _listControlBookInfoControl.Remove(sender)
            If SachCanThuePanel.Controls.Count >= 1 Then
                SachCanThuePanel.Controls(0).Location = New Point(0, 0)
                Dim bookInfoControlTemp As BookInfoControl = SachCanThuePanel.Controls(0)
                bookInfoControlTemp.GetSTTTextBox.Text = 1

                For index = 1 To SachCanThuePanel.Controls.Count - 1
                    Dim yLocation = SachCanThuePanel.Controls(index - 1).Location.Y + SachCanThuePanel.Controls(index - 1).Height
                    bookInfoControlTemp = SachCanThuePanel.Controls(index)
                    bookInfoControlTemp.GetSTTTextBox.Text = index + 1
                    SachCanThuePanel.Controls(index).Location = New Point(0, yLocation)
                Next
            End If
        Catch

        End Try
    End Sub

    'Xử lí khi book info control vừa được tạo, click để tạo hàng mới
    Private Sub XuLiKhiButtonTrongControlChuaClick(control As BookInfoControl)
        Try
            'Guard clause 
            Dim validateAmountBookCanBorrowResult = IsValidAmountBookCanBorrow()
            If validateAmountBookCanBorrowResult.FlagResult = False Then
                MessageBox.Show(validateAmountBookCanBorrowResult.ApplicationMessage)
                control.isButtonClick = True
                Return
            End If

            'Add new row 
            AddNewRow(control)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AddNewRow(control As BookInfoControl)
        Dim bookInfoControl = New BookInfoControl()

        Dim y = control.Location.Y + control.Height
        bookInfoControl.Location = New Point(0, y)
        bookInfoControl.GetSTTTextBox.Text = _listControlBookInfoControl.Count + 1
        AddHandler bookInfoControl.UC_Button_Click, AddressOf SachInfoControl_UC_ButtonClicked

        Dim titleComboBox As ComboBox = bookInfoControl.GetTitleComboBox
        titleComboBox.DataSource = _listSach
        titleComboBox.DisplayMember = "TenSach"

        _listControlBookInfoControl.Add(bookInfoControl)
        SachCanThuePanel.Controls.Add(bookInfoControl)
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