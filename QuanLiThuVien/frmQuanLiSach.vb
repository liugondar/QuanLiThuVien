Imports BUS
Imports DTO
Imports Utility

Public Class frmQuanLiSach
    Private _theLoaiSachBus As TheLoaiSachBUS
    Private _tacGiaBus As TacGiaBUS
    Private _sachBus As SachBus
    Private _listTheLoaiSach As List(Of TheLoaiSach)
    Private _listTacGia As List(Of TacGia)
    Private _listSach As List(Of Sach)
    Private Sub frmQuanLiSach_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _theLoaiSachBus = New TheLoaiSachBUS()
        _tacGiaBus = New TacGiaBUS()
        _sachBus = New SachBus()
        _listSach = New List(Of Sach)
        _listTacGia = New List(Of TacGia)
        _listTheLoaiSach = New List(Of TheLoaiSach)

        InitDateTimePickers()
        InitAuthorsComboBoxData()
        InitCategoryComboboxData()
        InitBookTitleComboboxDataAndPuslisherComboBoxData()
    End Sub

    Private Sub InitBookTitleComboboxDataAndPuslisherComboBoxData()
        Dim sachTemp = New Sach()
        sachTemp.TenSach = "-----------------------------"
        sachTemp.TenNhaXuatBan = "-----------------------------"
        sachTemp.MaSach = -1
        _listSach.Add(sachTemp)
        Dim result = _sachBus.SelectAll(_listSach)
        If result.FlagResult = False Then
            MessageBox.Show(result.ApplicationMessage)
            Return
        End If


        BookTitleComboBox.DataSource = New BindingSource(_listSach, String.Empty)
        BookTitleComboBox.DisplayMember = "TenSach"
        BookTitleComboBox.ValueMember = "MaSach"

        Dim listNhaXuatBan = New List(Of Sach)
        Dim nhaXuatBanComparer = New TenNhaXuatBanComparer()

        listNhaXuatBan = _listSach.Distinct(nhaXuatBanComparer).ToList()
        PublisherComboBox.DataSource = New BindingSource(listNhaXuatBan, String.Empty)
        PublisherComboBox.DisplayMember = "TenNhaXuatBan"
        PublisherComboBox.ValueMember = "TenNhaXuatBan"
    End Sub

    Private Sub InitCategoryComboboxData()
        Dim theLoaiTemp = New TheLoaiSach()
        theLoaiTemp.TenTheLoaiSach = "-----------------------------"
        theLoaiTemp.MaTheLoaiSach = -1
        _listTheLoaiSach.Add(theLoaiTemp)
        Dim Result = _theLoaiSachBus.SelectAll(_listTheLoaiSach)
        If Result.FlagResult = False Then
            MessageBox.Show(Result.ApplicationMessage)
            Return
        End If

        CategoryComboBox.DataSource = New BindingSource(_listTheLoaiSach, String.Empty)
        CategoryComboBox.DisplayMember = "TenTheLoaiSach"
        CategoryComboBox.ValueMember = "MaTheLoaiSach"
    End Sub

    Private Sub InitAuthorsComboBoxData()
        Dim tacGiaTemp = New TacGia()
        tacGiaTemp.TenTacGia = "-----------------------------"
        tacGiaTemp.MaTacGia = -1
        _listTacGia.Add(tacGiaTemp)
        Dim result = _tacGiaBus.SelectAll(_listTacGia)
        If result.FlagResult = False Then
            MessageBox.Show(result.ApplicationMessage)
            Return
        End If

        AuthorComboBox.DataSource = New BindingSource(_listTacGia, String.Empty)
        AuthorComboBox.DisplayMember = "TenTacGia"
        AuthorComboBox.ValueMember = "MaTacGia"
    End Sub

    Private Sub InitDateTimePickers()
        MinDateInputDateTimePicker.Format = DateTimePickerFormat.Custom
        MinDateInputDateTimePicker.CustomFormat = "yyyy"
        MinDateInputDateTimePicker.ShowUpDown = True
        MinDateInputDateTimePicker.MaxDate = Now
        MinDateInputDateTimePicker.Value = New Date(1753, 1, 1)

        MaxDateInputDateTimePicker.Format = DateTimePickerFormat.Custom
        MaxDateInputDateTimePicker.CustomFormat = "yyyy"
        MaxDateInputDateTimePicker.ShowUpDown = True
        MaxDateInputDateTimePicker.MaxDate = Now

        MinPublishYearDateTimePicker.Format = DateTimePickerFormat.Custom
        MinPublishYearDateTimePicker.CustomFormat = "yyyy"
        MinPublishYearDateTimePicker.ShowUpDown = True
        MinPublishYearDateTimePicker.MaxDate = Now
        MinPublishYearDateTimePicker.Value = New Date(1753, 1, 1)

        MaxPublishYearDateTimePicker.Format = DateTimePickerFormat.Custom
        MaxPublishYearDateTimePicker.CustomFormat = "yyyy"
        MaxPublishYearDateTimePicker.ShowUpDown = True
        MaxPublishYearDateTimePicker.MaxDate = Now
    End Sub

    Private Sub CreateButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
#Region "Lấy thông tin input"
        Dim maSach = BookTitleComboBox.SelectedValue
        Dim maTacGia = AuthorComboBox.SelectedValue
        Dim maTheLoaiSach = CategoryComboBox.SelectedValue
        Dim tenNhaXuatBan = PublisherComboBox.SelectedValue
        Dim ngayXuatBanMin = MinPublishYearDateTimePicker.Value
        Dim ngayXuatBanMax = MaxPublishYearDateTimePicker.Value
        Dim ngayNhapMin = MinDateInputDateTimePicker.Value
        Dim ngayNhapMax = MaxDateInputDateTimePicker.Value
        Dim triGiaMin = MinPriceNumericUpDown.Value
        Dim triGiaMax = MaxPriceNumericUpDown.Value

        Console.WriteLine(maSach)

        Dim listSachTheoMaSach = New List(Of Sach)
        Dim listSachTheoTacGia = New List(Of Sach)
        Dim listSachTheoTheLoai = New List(Of Sach)
        Dim listSachTheoNhaXuatBan = New List(Of Sach)
        Dim listSachTheoNgayXuatBan = New List(Of Sach)
        Dim listSachTheoNgayNhap = New List(Of Sach)
        Dim listSachTheoTriGia = New List(Of Sach)
#End Region
#Region "Guard clause"
        Dim resultSelectAllByMaSach = _sachBus.SelectAllByMaSach(listSachTheoMaSach, maSach)
        Dim resultSelectAllByTacGia = _sachBus.SelectAllByMaTacGia(listSachTheoTacGia, maTacGia)
        Dim resultSelectAllByTheLoai = _sachBus.SelectAllByMaTheLoaiSach(listSachTheoTheLoai, maTheLoaiSach)
        Dim resultSelectAllByNhaXuatBan = _sachBus.SelectAllByTenNhaXuatBan(listSachTheoNhaXuatBan, tenNhaXuatBan)
        Dim resultSelectAllByNgayXuatBan = _sachBus.SelectAllByNgayXuatBan(listSachTheoNgayXuatBan, ngayXuatBanMin, ngayXuatBanMax)
        Dim resultSelectAllByNgayNhap = _sachBus.SelectAllByNgayNhap(listSachTheoNgayNhap, ngayNhapMin, ngayNhapMax)
        Dim resultSelectAllByTriGia = _sachBus.SelectAllByTriGia(listSachTheoTriGia, triGiaMin, triGiaMax)

        Dim layListSachThoaManResult = resultSelectAllByMaSach.FlagResult And
        resultSelectAllByTacGia.FlagResult And
        resultSelectAllByTheLoai.FlagResult And
        resultSelectAllByNhaXuatBan.FlagResult And
        resultSelectAllByNgayXuatBan.FlagResult And
        resultSelectAllByNgayNhap.FlagResult And
        resultSelectAllByTriGia.FlagResult
        If layListSachThoaManResult = False Then Return
#End Region
        Dim sachComparer = New SachComparer()

        Dim listThoaMan = listSachTheoTriGia.Intersect(listSachTheoNgayNhap, sachComparer).ToList()
        listThoaMan = listThoaMan.Intersect(listSachTheoNgayXuatBan, New SachComparer()).ToList()

        If BookTitleComboBox.SelectedValue <> -1 Then listThoaMan = listThoaMan.Intersect(listSachTheoMaSach, sachComparer).ToList()
        If PublisherComboBox.SelectedValue <> "-----------------------------" Then listThoaMan = listThoaMan.Intersect(listSachTheoNhaXuatBan, sachComparer).ToList()
        If AuthorComboBox.SelectedValue <> -1 Then listThoaMan.Intersect(listSachTheoTacGia, sachComparer).ToList()
        If CategoryComboBox.SelectedValue <> -1 Then listThoaMan = listThoaMan.Intersect(listSachTheoTheLoai, sachComparer).ToList()

        LoadListSach(listThoaMan)
    End Sub

    Function LoadListSach(listSach As List(Of Sach))
        DataGridViewQuanLiSach.Columns.Clear()
        DataGridViewQuanLiSach.DataSource = Nothing
        DataGridViewQuanLiSach.AutoGenerateColumns = False
        DataGridViewQuanLiSach.AllowUserToAddRows = False

        Dim columnMaSach = New DataGridViewTextBoxColumn()
        columnMaSach.Name = "MaSach"
        columnMaSach.HeaderText = "Mã Sách"
        columnMaSach.DataPropertyName = "MaSach"
        DataGridViewQuanLiSach.Columns.Add(columnMaSach)


        Dim columnTenSach = New DataGridViewTextBoxColumn()
        columnTenSach.Name = "TenSach"
        columnTenSach.HeaderText = "Tên Sách"
        columnTenSach.DataPropertyName = "TenSach"
        DataGridViewQuanLiSach.Columns.Add(columnTenSach)


        Dim columnTenTheLoaiSach = New DataGridViewTextBoxColumn()
        columnTenTheLoaiSach.Name = "TenTheLoaiSach"
        columnTenTheLoaiSach.HeaderText = "Thể loại sách"
        columnTenTheLoaiSach.DataPropertyName = "TenTheLoaiSach"
        DataGridViewQuanLiSach.Columns.Add(columnTenTheLoaiSach)

        Dim columnTenTacGia = New DataGridViewTextBoxColumn()
        columnTenTacGia.Name = "TenTacGia"
        columnTenTacGia.HeaderText = "Tên tác giả"
        columnTenTacGia.DataPropertyName = "TenTacGia"
        DataGridViewQuanLiSach.Columns.Add(columnTenTacGia)


        Dim columnTenNhaXuatBan = New DataGridViewTextBoxColumn()
        columnTenNhaXuatBan.Name = "TenNhaXuatBan"
        columnTenNhaXuatBan.HeaderText = "Tên nhà xuất bản"
        columnTenNhaXuatBan.DataPropertyName = "TenNhaXuatBan"
        DataGridViewQuanLiSach.Columns.Add(columnTenNhaXuatBan)

        Dim columnNayXuatBan = New DataGridViewTextBoxColumn()
        columnNayXuatBan.Name = "NgayXuatBan"
        columnNayXuatBan.HeaderText = "Năm xuất bản"
        columnNayXuatBan.DataPropertyName = "NgayXuatBAn"
        DataGridViewQuanLiSach.Columns.Add(columnNayXuatBan)

        Dim columnNgayNhap = New DataGridViewTextBoxColumn()
        columnNgayNhap.Name = "NgayNhap"
        columnNgayNhap.HeaderText = "Ngày nhập"
        columnNgayNhap.DataPropertyName = "NgayNhap"
        DataGridViewQuanLiSach.Columns.Add(columnNgayNhap)

        Dim columnTriGia = New DataGridViewTextBoxColumn()
        columnTriGia.Name = "TriGia"
        columnTriGia.HeaderText = "Trị giá"
        columnTriGia.DataPropertyName = "TriGia"
        DataGridViewQuanLiSach.Columns.Add(columnTriGia)

        For index = 0 To listSach.Count - 1
            Dim maTheLoaiSachTemp = listSach(index).MaTheLoaiSach
            Dim tenTheLoaiSachTemp As String
            Dim ListTheLoaiSachThoaMan = From tls In _listTheLoaiSach
                                         Where tls.MaTheLoaiSach = maTheLoaiSachTemp
                                         Select tls

            For Each theLoaiSach In ListTheLoaiSachThoaMan
                tenTheLoaiSachTemp = theLoaiSach.TenTheLoaiSach
            Next

            Dim maTacGiaTemp = listSach(index).MaTacGia
            Dim tenTacGiaTemp As String
            Dim listTacGiaThoaMan = From tg In _listTacGia
                                    Where tg.MaTacGia = maTheLoaiSachTemp
                                    Select tg
            For Each tacGia In listTacGiaThoaMan
                tenTacGiaTemp = tacGia.TenTacGia
            Next

            DataGridViewQuanLiSach.Rows.Add(listSach(index).MaSach,
            listSach(index).TenSach, tenTheLoaiSachTemp, tenTacGiaTemp, listSach(index).TenNhaXuatBan,
            listSach(index).NgayXuatBan.ToString("yyyy"), listSach(index).NgayNhap.ToString("dd/MM/yyyy"), listSach(index).TriGia)
        Next
    End Function

    Private Sub DataGridViewQuanLiSach_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridViewQuanLiSach.SelectionChanged
        Dim sach = New Sach()
        Dim result = GetSelectedSachData(sach)
        Console.WriteLine(sach.MaSach)
    End Sub

    Private Function GetSelectedSachData(ByRef sach As Sach) As Result
        Dim currentRowIndex As Integer = DataGridViewQuanLiSach.CurrentCellAddress.Y
        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < DataGridViewQuanLiSach.RowCount) Then
            Try
                sach = New Sach()
                sach.MaSach = Convert.ToInt32(DataGridViewQuanLiSach.Rows(currentRowIndex).Cells("MaSach").Value.ToString())
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
                Return New Result(False, "Không lấy được thông tin độc giả đã chọn", "")
            End Try
        Else
            Return New Result(False, "Không lấy được thông tin độc giả đã chọn", "")
        End If

        Return New Result()
    End Function
End Class