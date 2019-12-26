Imports BUS
Imports DTO
Imports Utility

Public Class frmQuanLiSach

#Region "-   Fields    -"
    Private _theLoaiSachBus As TheLoaiSachBUS
    Private _sachBus As SachBus
    Private _tacGiaBus As TacGiaBUS
    Private _dausachBus As DauSachBus
    Private _listTheLoaiSach As List(Of TheLoaiSach)
    Private _listTacGia As List(Of TacGia)
    Private _listDauSach As List(Of DauSachDTO)
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
        SearchByDataInput()
    End Sub

    Private Sub InitComponenents()
        _theLoaiSachBus = New TheLoaiSachBUS()
        _tacGiaBus = New TacGiaBUS()
        _sachBus = New SachBus()
        _dausachBus = New DauSachBus()
        _listDauSach = New List(Of DauSachDTO)
        _listTacGia = New List(Of TacGia)
        _listTheLoaiSach = New List(Of TheLoaiSach)

        InitDateTimePickers()
        InitAuthorsComboBoxData()
        InitCategoryComboboxData()
        InitBookTitleComboboxDataAndPuslisherComboBoxData()
    End Sub

    Private Sub InitBookTitleComboboxDataAndPuslisherComboBoxData()
        Dim sachTemp = New DauSachDTO()
        sachTemp.TenSach = "-----------------------------"
        sachTemp.TenNhaXuatBan = "-----------------------------"
        sachTemp.MaDauSach = -1
        _listDauSach.Add(sachTemp)
        Dim result = _dausachBus.SelectAll(_listDauSach)
        If result.FlagResult = False Then
            MessageBox.Show(result.ApplicationMessage)
            Return
        End If


        cbTenSachCanTim.DataSource = New BindingSource(_listDauSach, String.Empty)
        cbTenSachCanTim.DisplayMember = "TenSach"
        cbTenSachCanTim.ValueMember = "TenSach"

        Dim listNhaXuatBan = New List(Of DauSachDTO)
        Dim nhaXuatBanComparer = New TenNhaXuatBanComparer()

        listNhaXuatBan = _listDauSach.Distinct(nhaXuatBanComparer).ToList()
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
    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        SearchByDataInput()
    End Sub

    Private Sub SearchByDataInput()

        'get input data
        Dim dausach = New DauSachDTO()
        dausach.TenSach = If(cbTenSachCanTim.SelectedValue = "-----------------------------", "-1", cbTenSachCanTim.SelectedValue)
        dausach.MaTacGia = cbTacGiaCanTim.SelectedValue
        dausach.MaTheLoaiSach = cbTheLoaiCanTim.SelectedValue
        dausach.TenNhaXuatBan = If(cbNhaXuatBanCanTim.SelectedValue = "-----------------------------", -1, cbNhaXuatBanCanTim.SelectedValue)
        Dim ngayXuatBanMin = dpNamXBCanTimMin.Value
        Dim ngayXuatBanMax = dpNamXBCanTimMax.Value
        Dim triGiaMin = MinPriceNumericUpDown.Value
        Dim triGiaMax = MaxPriceNumericUpDown.Value

        'Load searched list to datagridview
        Dim listThoaMan = New List(Of DauSachDTO)
        _dausachBus.SelectALLBySpecificConditions(listThoaMan, dausach,
                                               ngayXuatBanMin, ngayXuatBanMax,
                                                triGiaMin, triGiaMax)
        LoadListDauSach(listThoaMan)
    End Sub

    Private Sub LoadListDauSach(listDauSach As List(Of DauSachDTO))
        InitDataGridColumn()

        For index = 0 To listDauSach.Count - 1
            'load ten the loai sach
            Dim soluong = 0
            Dim maTheLoaiSachTemp = listDauSach(index).MaTheLoaiSach
            Dim tenTheLoaiSachTemp As String
            Dim ListTheLoaiSachThoaMan = From tls In _listTheLoaiSach
                                         Where tls.MaTheLoaiSach = maTheLoaiSachTemp
                                         Select tls

            For Each theLoaiSach In ListTheLoaiSachThoaMan
                tenTheLoaiSachTemp = theLoaiSach.TenTheLoaiSach
            Next
            'load ten tac gia
            Dim maTacGiaTemp = listDauSach(index).MaTacGia
            Dim tenTacGiaTemp As String
            Dim listTacGiaThoaMan = From tg In _listTacGia
                                    Where tg.MaTacGia = maTacGiaTemp
                                    Select tg
            For Each tacGia In listTacGiaThoaMan
                tenTacGiaTemp = tacGia.TenTacGia
            Next

            soluong = _sachBus.getQuanlity(listDauSach(index).MaDauSach)
            Dim slCon = 0
            _sachBus.getAvailableQuanlity(listDauSach(index).MaDauSach, slCon)

                 DataGridViewQuanLiSach.Rows.Add(listDauSach(index).MaDauSach,
            listDauSach(index).TenSach, tenTheLoaiSachTemp, tenTacGiaTemp, soluong, slCon)
        Next
    End Sub

    Private Sub InitDataGridColumn()
        DataGridViewQuanLiSach.Columns.Clear()
        DataGridViewQuanLiSach.DataSource = Nothing
        DataGridViewQuanLiSach.AutoGenerateColumns = False
        DataGridViewQuanLiSach.AllowUserToAddRows = False
        Dim columnMaDauSach = New DataGridViewTextBoxColumn()
        columnMaDauSach.Name = "MaDauSach"
        columnMaDauSach.HeaderText = "Mã Đầu Sách"
        columnMaDauSach.DataPropertyName = "MaSach"
        columnMaDauSach.Width = 100
        DataGridViewQuanLiSach.Columns.Add(columnMaDauSach)

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

        Dim clnSoLuong = New DataGridViewTextBoxColumn()
        clnSoLuong.Name = "TongSoLuong"
        clnSoLuong.HeaderText = "Tổng số lượng"
        clnSoLuong.DataPropertyName = "TongSoLuong"
        clnSoLuong.Width = 150
        DataGridViewQuanLiSach.Columns.Add(clnSoLuong)

        Dim clnSoLuongCon = New DataGridViewTextBoxColumn()
        clnSoLuongCon.Name = "SoLuongcon"
        clnSoLuongCon.HeaderText = "Số lượng trong kho"
        clnSoLuongCon.DataPropertyName = "SoLuongcon"
        clnSoLuongCon.Width = 150
        DataGridViewQuanLiSach.Columns.Add(clnSoLuongCon)
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
        Dim dausach = New DauSachDTO()
        Dim result = GetSelectedSachData(dausach)
        If result.FlagResult = False Then Return result

        If dausach Is Nothing Then Return New Result(False, "", "")

        LoadThongTinSachCanTimGroupBox(dausach)
        Return result
    End Function

    Private Function GetSelectedSachData(ByRef dausach As DauSachDTO) As Result
        Dim currentRowIndex As Integer = DataGridViewQuanLiSach.CurrentCellAddress.Y
        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < DataGridViewQuanLiSach.RowCount) Then
            Try
                Dim MaDauSach = Convert.ToInt32(DataGridViewQuanLiSach.Rows(currentRowIndex).Cells("MaDauSach").Value.ToString())
                dausach = New DauSachDTO()
                dausach.MaDauSach = MaDauSach
                _dausachBus.GetById(dausach, MaDauSach)
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
                Return New Result(False, "Không lấy được thông tin độc giả đã chọn", "")
            End Try
        Else
            Return New Result(False, "Không lấy được thông tin độc giả đã chọn", "")
        End If

        Return New Result()
    End Function

    Private Sub LoadThongTinSachCanTimGroupBox(dausach As DauSachDTO)
        txtMaDauSachDangChon.Text = dausach.MaDauSach
        txtTenNxbDangChon.Text = dausach.TenNhaXuatBan
        txtTenSachDangChon.Text = dausach.TenSach

        Dim listTacGia = _listTacGia.Where(Function(x) x.MaTacGia <> -1).ToList()
        cbTacGiaDangChon.DataSource = listTacGia
        cbTacGiaDangChon.DisplayMember = "TenTacGia"
        cbTacGiaDangChon.ValueMember = "MaTacGia"
        Dim selectedTacGia = _listTacGia.Where(Function(x) x.MaTacGia = dausach.MaTacGia).FirstOrDefault
        cbTacGiaDangChon.SelectedIndex = cbTacGiaDangChon.Items.IndexOf(selectedTacGia)

        Dim listTheLoai = _listTheLoaiSach.Where(Function(x) x.MaTheLoaiSach <> -1).ToList()
        cbTheLoaiDangChon.DataSource = listTheLoai
        cbTheLoaiDangChon.DisplayMember = "TenTheLoaiSach"
        cbTheLoaiDangChon.ValueMember = "MaTheLoaiSach"
        Dim selectedTheLoai = _listTheLoaiSach.Where(Function(x) x.MaTheLoaiSach = dausach.MaTheLoaiSach).FirstOrDefault
        cbTheLoaiDangChon.SelectedIndex = cbTheLoaiDangChon.Items.IndexOf(selectedTheLoai)

        dpNamXBDangChon.Value = dausach.NgayXuatBan
        nudTriGiaDangChon.Value = dausach.TriGia
    End Sub

#End Region

#Region "-    Update,Delete selected row    -"
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If MessageBox.Show("Bạn có chắc thay đổi thông tin?", "Thông Báo", MessageBoxButtons.OKCancel) = System.Windows.Forms.DialogResult.OK Then
            Try
                Dim dausach = New DauSachDTO()
                dausach.MaDauSach = txtMaDauSachDangChon.Text
                dausach.TenSach = txtTenSachDangChon.Text
                dausach.TenNhaXuatBan = txtTenNxbDangChon.Text
                dausach.MaTheLoaiSach = cbTheLoaiDangChon.SelectedItem.maTheLoaiSach
                dausach.MaTacGia = cbTacGiaDangChon.SelectedItem.MaTacGia
                dausach.NgayXuatBan = dpNamXBDangChon.Value
                dausach.TriGia = nudTriGiaDangChon.Value

                Dim result = _dausachBus.Update(dausach)
                If result.FlagResult Then
                    MessageBox.Show("Cập nhật thành công thông tin đầu sách!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SearchByDataInput()
                Else
                    MessageBox.Show("Cập nhật không thành công thông tin đầu sách!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Cập nhật không thành công thông tin đầu sách!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Console.WriteLine(ex)
            End Try
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MessageBox.Show("Bạn có muốn xoá đầu sách có mã: " & txtMaDauSachDangChon.Text, "Thông Báo", MessageBoxButtons.OKCancel) = System.Windows.Forms.DialogResult.OK Then

            Try
                Dim MaDauSach = txtMaDauSachDangChon.Text
                Dim result = _dausachBus.DeleteById(MaDauSach)
                If result.FlagResult Then
                    MessageBox.Show("Xoá thành công thông tin đầu sách!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SearchByDataInput()
                Else
                    MessageBox.Show("Xoá không thành công thông tin đầu sách!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Xoá không thành công thông tin đầu sách!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Console.WriteLine(ex)
            End Try
        End If
    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        Me.Controls.Clear()
        Me.InitializeComponent()
        InitComponenents()
    End Sub

    Private Sub DataGridViewQuanLiSach_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewQuanLiSach.CellContentClick

    End Sub

    Private Sub GroupBoxThongTinSachCanTim_Enter(sender As Object, e As EventArgs) Handles GroupBoxThongTinSachCanTim.Enter

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SearchInfo()

    End Sub

    Private Sub SearchInfo()
        Try
            Dim listSear = New List(Of DauSachDTO)
            QuanLiSachBus.Instance.SearchSachByString(txtSearch.Text, listSear)
            LoadListDauSach(listSear)
        Catch ex As Exception
            Strings.Instance.LogErr(ex.Message)
        End Try
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        Strings.Instance.LogMess(e.KeyCode)
        If e.KeyCode = Keys.Enter Then
            SearchInfo()
        End If
    End Sub
#End Region

#End Region

End Class