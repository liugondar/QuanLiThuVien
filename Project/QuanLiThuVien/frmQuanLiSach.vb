Imports BUS
Imports DTO
Imports Utility

Public Class frmQuanLiSach

#Region "-   Fields    -"
    Private _theLoaiSachBus As TheLoaiSachBUS
    Private _tacGiaBus As TacGiaBUS
    Private _sachBus As SachBus
    Private _listTheLoaiSach As List(Of TheLoaiSach)
    Private _listTacGia As List(Of TacGia)
    Private _listSach As List(Of Sach)
    Private loginAccount As Account

#End Region

#Region "-   Constructor   -"
    Public Sub New(loginAccount As Account)
        Me.loginAccount = loginAccount
        InitializeComponent()
        'nếu là nhân viên bình thường không cho phép can thiệp sửa xoá db
        If loginAccount.Type = 0 Then
            btnDelete.Visible = False
            btnUpdate.Visible = False
        End If
    End Sub
    Private Sub frmQuanLiSach_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitComponenents()
    End Sub

    Private Sub InitComponenents()
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


        cbTenSachCanTim.DataSource = New BindingSource(_listSach, String.Empty)
        cbTenSachCanTim.DisplayMember = "TenSach"
        cbTenSachCanTim.ValueMember = "MaSach"

        Dim listNhaXuatBan = New List(Of Sach)
        Dim nhaXuatBanComparer = New TenNhaXuatBanComparer()

        listNhaXuatBan = _listSach.Distinct(nhaXuatBanComparer).ToList()
        cbNhaXuatBanCanTim.DataSource = New BindingSource(listNhaXuatBan, String.Empty)
        cbNhaXuatBanCanTim.DisplayMember = "TenNhaXuatBan"
        cbNhaXuatBanCanTim.ValueMember = "TenNhaXuatBan"
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

        cbTheLoaiCanTim.DataSource = New BindingSource(_listTheLoaiSach, String.Empty)
        cbTheLoaiCanTim.DisplayMember = "TenTheLoaiSach"
        cbTheLoaiCanTim.ValueMember = "MaTheLoaiSach"
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

        cbTacGiaCanTim.DataSource = New BindingSource(_listTacGia, String.Empty)
        cbTacGiaCanTim.DisplayMember = "TenTacGia"
        cbTacGiaCanTim.ValueMember = "MaTacGia"
    End Sub

    Private Sub InitDateTimePickers()
        dpNgayNhapMin.Format = DateTimePickerFormat.Custom
        dpNgayNhapMin.CustomFormat = "yyyy"
        dpNgayNhapMin.ShowUpDown = True
        dpNgayNhapMin.MaxDate = Now
        dpNgayNhapMin.Value = New Date(1753, 1, 1)

        dpNgayNhapMax.Format = DateTimePickerFormat.Custom
        dpNgayNhapMax.CustomFormat = "yyyy"
        dpNgayNhapMax.ShowUpDown = True
        dpNgayNhapMax.MaxDate = Now

        dpNamXBCanTimMin.Format = DateTimePickerFormat.Custom
        dpNamXBCanTimMin.CustomFormat = "yyyy"
        dpNamXBCanTimMin.ShowUpDown = True
        dpNamXBCanTimMin.MaxDate = Now
        dpNamXBCanTimMin.Value = New Date(1753, 1, 1)

        dpNamXBCanTimMax.Format = DateTimePickerFormat.Custom
        dpNamXBCanTimMax.CustomFormat = "yyyy"
        dpNamXBCanTimMax.ShowUpDown = True
        dpNamXBCanTimMax.MaxDate = Now
    End Sub
#End Region

#Region "-   Events   -"

#Region "-   search Button click   -"
    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SearchByDataInput()
    End Sub

    Private Sub SearchByDataInput()

        'get input data
        Dim sach = New Sach()
        sach.MaSach = cbTenSachCanTim.SelectedValue
        sach.MaTacGia = cbTacGiaCanTim.SelectedValue
        sach.MaTheLoaiSach = cbTheLoaiCanTim.SelectedValue
        sach.TenNhaXuatBan = If(cbNhaXuatBanCanTim.SelectedValue = "-----------------------------", -1, cbNhaXuatBanCanTim.SelectedValue)
        Dim ngayXuatBanMin = dpNamXBCanTimMin.Value
        Dim ngayXuatBanMax = dpNamXBCanTimMax.Value
        Dim ngayNhapMin = dpNgayNhapMin.Value
        Dim ngayNhapMax = dpNgayNhapMax.Value
        Dim triGiaMin = MinPriceNumericUpDown.Value
        Dim triGiaMax = MaxPriceNumericUpDown.Value

        'Load searched list to datagridview
        Dim listThoaMan = New List(Of Sach)
        _sachBus.SelectALLBySpecificConditions(listThoaMan, sach,
                                               ngayXuatBanMin, ngayXuatBanMax,
                                                ngayNhapMin, ngayNhapMax,
                                                triGiaMin, triGiaMax)
        LoadListSach(listThoaMan)
    End Sub

    Private Sub LoadListSach(listSach As List(Of Sach))
        DataGridViewQuanLiSach.Columns.Clear()
        DataGridViewQuanLiSach.DataSource = Nothing
        DataGridViewQuanLiSach.AutoGenerateColumns = False
        DataGridViewQuanLiSach.AllowUserToAddRows = False
        Dim columnMaSach = New DataGridViewTextBoxColumn()
        columnMaSach.Name = "MaSach"
        columnMaSach.HeaderText = "Mã Sách"
        columnMaSach.DataPropertyName = "MaSach"
        columnMaSach.Width = 100
        DataGridViewQuanLiSach.Columns.Add(columnMaSach)

        Dim columnTenSach = New DataGridViewTextBoxColumn()
        columnTenSach.Name = "TenSach"
        columnTenSach.HeaderText = "Tên Sách"
        columnTenSach.DataPropertyName = "TenSach"
        columnTenSach.Width = 250
        DataGridViewQuanLiSach.Columns.Add(columnTenSach)

        Dim columnTenTheLoaiSach = New DataGridViewTextBoxColumn()
        columnTenTheLoaiSach.Name = "TenTheLoaiSach"
        columnTenTheLoaiSach.HeaderText = "Thể loại sách"
        columnTenTheLoaiSach.DataPropertyName = "TenTheLoaiSach"
        columnTenTheLoaiSach.Width = 200
        DataGridViewQuanLiSach.Columns.Add(columnTenTheLoaiSach)

        Dim columnTenTacGia = New DataGridViewTextBoxColumn()
        columnTenTacGia.Name = "TenTacGia"
        columnTenTacGia.HeaderText = "Tên tác giả"
        columnTenTacGia.DataPropertyName = "TenTacGia"
        columnTenTacGia.Width = 200
        DataGridViewQuanLiSach.Columns.Add(columnTenTacGia)

        Dim columnTriGia = New DataGridViewTextBoxColumn()
        columnTriGia.Name = "TinhTrang"
        columnTriGia.HeaderText = "Tình trạng"
        columnTriGia.DataPropertyName = "TinhTrang"
        columnTriGia.Width = 150
        DataGridViewQuanLiSach.Columns.Add(columnTriGia)

        For index = 0 To listSach.Count - 1
            'load ten the loai sach
            Dim maTheLoaiSachTemp = listSach(index).MaTheLoaiSach
            Dim tenTheLoaiSachTemp As String
            Dim ListTheLoaiSachThoaMan = From tls In _listTheLoaiSach
                                         Where tls.MaTheLoaiSach = maTheLoaiSachTemp
                                         Select tls

            For Each theLoaiSach In ListTheLoaiSachThoaMan
                tenTheLoaiSachTemp = theLoaiSach.TenTheLoaiSach
            Next
            'load ten tac gia
            Dim maTacGiaTemp = listSach(index).MaTacGia
            Dim tenTacGiaTemp As String
            Dim listTacGiaThoaMan = From tg In _listTacGia
                                    Where tg.MaTacGia = maTacGiaTemp
                                    Select tg
            For Each tacGia In listTacGiaThoaMan
                tenTacGiaTemp = tacGia.TenTacGia
            Next

            'load ten tinh trang
            Dim tinhTrangTemp = If(listSach(index).TinhTrang = 0, "Còn", "Hết")

            DataGridViewQuanLiSach.Rows.Add(listSach(index).MaSach,
            listSach(index).TenSach, tenTheLoaiSachTemp, tenTacGiaTemp,
             tinhTrangTemp)
        Next
    End Sub

#End Region

#Region "-   Load info selected row in datagridview   -"
    Private Sub DataGridViewQuanLiSach_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridViewQuanLiSach.SelectionChanged
        Try
            LoadInfoSelectedRow()
        Catch
        End Try
    End Sub

    Private Function LoadInfoSelectedRow() As Result
        Dim sach = New Sach()
        Dim result = GetSelectedSachData(sach)
        If result.FlagResult = False Then Return result

        If sach Is Nothing Then Return New Result(False, "", "")

        LoadThongTinSachCanTimGroupBox(sach)
        Return result
    End Function

    Private Function GetSelectedSachData(ByRef sach As Sach) As Result
        Dim currentRowIndex As Integer = DataGridViewQuanLiSach.CurrentCellAddress.Y
        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < DataGridViewQuanLiSach.RowCount) Then
            Try
                Dim MaSach = Convert.ToInt32(DataGridViewQuanLiSach.Rows(currentRowIndex).Cells("MaSach").Value.ToString())
                sach = New Sach()
                sach.MaSach = MaSach
                _sachBus.GetById(sach, MaSach)
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
                Return New Result(False, "Không lấy được thông tin độc giả đã chọn", "")
            End Try
        Else
            Return New Result(False, "Không lấy được thông tin độc giả đã chọn", "")
        End If

        Return New Result()
    End Function

    Private Sub LoadThongTinSachCanTimGroupBox(sach As Sach)
        txtMaSachDangChon.Text = sach.MaSach
        txtTenNxbDangChon.Text = sach.TenNhaXuatBan
        txtTenSachDangChon.Text = sach.TenSach

        Dim listTacGia = _listTacGia.Where(Function(x) x.MaTacGia <> -1).ToList()
        cbTacGiaDangChon.DataSource = listTacGia
        cbTacGiaDangChon.DisplayMember = "TenTacGia"
        cbTacGiaDangChon.ValueMember = "MaTacGia"
        Dim selectedTacGia = _listTacGia.Where(Function(x) x.MaTacGia = sach.MaTacGia).FirstOrDefault
        cbTacGiaDangChon.SelectedIndex = cbTacGiaDangChon.Items.IndexOf(selectedTacGia)

        Dim listTheLoai = _listTheLoaiSach.Where(Function(x) x.MaTheLoaiSach <> -1).ToList()
        cbTheLoaiDangChon.DataSource = listTheLoai
        cbTheLoaiDangChon.DisplayMember = "TenTheLoaiSach"
        cbTheLoaiDangChon.ValueMember = "MaTheLoaiSach"
        Dim selectedTheLoai = _listTheLoaiSach.Where(Function(x) x.MaTheLoaiSach = sach.MaTheLoaiSach).FirstOrDefault
        cbTheLoaiDangChon.SelectedIndex = cbTheLoaiDangChon.Items.IndexOf(selectedTheLoai)

        dpNamXBDangChon.Value = sach.NgayXuatBan
        dpNgayNhapDangChon.Value = sach.NgayNhap
        nudTriGiaDangChon.Value = sach.TriGia
    End Sub

#End Region

#Region "-    Update,Delete selected row    -"
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Dim sach = New Sach()
            sach.MaSach = txtMaSachDangChon.Text
            sach.TenSach = txtTenSachDangChon.Text
            sach.TenNhaXuatBan = txtTenNxbDangChon.Text
            sach.MaTheLoaiSach = cbTheLoaiDangChon.SelectedItem.maTheLoaiSach
            sach.MaTacGia = cbTacGiaDangChon.SelectedItem.MaTacGia
            sach.NgayXuatBan = dpNamXBDangChon.Value
            sach.TriGia = nudTriGiaDangChon.Value

            Dim result = _sachBus.Update(sach)
            If result.FlagResult Then
                MessageBox.Show("Cập nhật thành công thông tin sách!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                SearchByDataInput()
            Else
                MessageBox.Show("Cập nhật không thành công thông tin sách!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Cập nhật không thành công thông tin sách!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Console.WriteLine(ex)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            Dim MaSach = txtMaSachDangChon.Text
            Dim result = _sachBus.DeleteById(MaSach)
            If result.FlagResult Then
                MessageBox.Show("Xoá thành công thông tin sách!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                SearchByDataInput()
            Else
                MessageBox.Show("Xoá không thành công thông tin sách!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Xoá không thành công thông tin sách!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Console.WriteLine(ex)
        End Try
    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        Me.Controls.Clear()
        Me.InitializeComponent()
        InitComponenents()
    End Sub
#End Region

#End Region

End Class