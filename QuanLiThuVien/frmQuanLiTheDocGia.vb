Imports BUS
Imports DTO
Imports Utility

Public Class frmQuanLiTheDocGia

#Region "-   Fields   -"
    Private _docGiaBus As DocGiaBus
    Private _loaiDocGiaBus As LoaiDocGiaBus
#End Region

#Region "-   Constructor   -"

    Private Sub frmQuanLiTheDocGia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _loaiDocGiaBus = New LoaiDocGiaBus()
        _docGiaBus = New DocGiaBus()
        Dim loadReaderTypeComboBoxResult = LoadReaderTypeComboBoxData()
        If loadReaderTypeComboBoxResult.FlagResult = False Then MessageBox.Show(loadReaderTypeComboBoxResult.ApplicationMessage)

        RemoveButton.BackColor = ColorTranslator.FromHtml("#DC3545")
        EditButton.BackColor = ColorTranslator.FromHtml("#28A745")
    End Sub

    Private Function LoadReaderTypeComboBoxData() As Result
        Dim listLoaiDocGia = New List(Of LoaiDocGia)
        Dim result = _loaiDocGiaBus.SelectAll(listLoaiDocGia)

        ReaderTypeComboBox.DataSource = New BindingSource(listLoaiDocGia, String.Empty)
        ReaderTypeComboBox.DisplayMember = "TenLoaiDocGia"
        ReaderTypeComboBox.ValueMember = "MaLoaiDocGia"

        LoaiDocGiaEditComboBox.DataSource = New BindingSource(listLoaiDocGia, String.Empty)
        LoaiDocGiaEditComboBox.DisplayMember = "TenLoaiDocGia"
        LoaiDocGiaEditComboBox.ValueMember = "MaLoaiDocGia"

        If listLoaiDocGia.Count < 1 Then
            Return New Result(False, "Load loại thẻ combo box không thành công!", "")
        End If

        Try
            Dim maLoai = Convert.ToInt32(ReaderTypeComboBox.SelectedValue)
            LoadListDocGia(maLoai)
        Catch ex As Exception
        End Try

        Return result
    End Function

    Function LoadListDocGia(maLoai As String) As Result
        DataGridViewQuanLiTheDocGia.Columns.Clear()
        DataGridViewQuanLiTheDocGia.DataSource = Nothing
        DataGridViewQuanLiTheDocGia.AutoGenerateColumns = False
        DataGridViewQuanLiTheDocGia.AllowUserToAddRows = False
        LoadInfoSelectedRow()

        Dim listLoaiDocGia = New List(Of DocGia)
        Dim result = _docGiaBus.SelectAllByType(maLoai, listLoaiDocGia)
        If result.FlagResult = False Then
            MessageBox.Show(result.ApplicationMessage)
            Return result
        End If

        DataGridViewQuanLiTheDocGia.DataSource = listLoaiDocGia

        Dim columnMaDocGia = New DataGridViewTextBoxColumn()
        columnMaDocGia.Name = "MaTheDocGia"
        columnMaDocGia.HeaderText = "Mã Thẻ Độc Giả"
        columnMaDocGia.DataPropertyName = "MaTheDocGia"
        DataGridViewQuanLiTheDocGia.Columns.Add(columnMaDocGia)


        Dim columnTenDocGia = New DataGridViewTextBoxColumn()
        columnTenDocGia.Name = "TenDocGia"
        columnTenDocGia.HeaderText = "Tên Độc giả"
        columnTenDocGia.DataPropertyName = "TenDocGia"
        DataGridViewQuanLiTheDocGia.Columns.Add(columnTenDocGia)


        Dim columnEmail = New DataGridViewTextBoxColumn()
        columnEmail.Name = "Email"
        columnEmail.HeaderText = "Email"
        columnEmail.DataPropertyName = "Email"
        DataGridViewQuanLiTheDocGia.Columns.Add(columnEmail)

        Dim columnDiaChi = New DataGridViewTextBoxColumn()
        columnDiaChi.Name = "DiaChi"
        columnDiaChi.HeaderText = "Địa chỉ"
        columnDiaChi.DataPropertyName = "DiaChi"
        DataGridViewQuanLiTheDocGia.Columns.Add(columnDiaChi)


        Dim columnMaLoaiDocGia = New DataGridViewTextBoxColumn()
        columnMaLoaiDocGia.Name = "MaLoaiDocGia"
        columnMaLoaiDocGia.HeaderText = "Mã loại độc giả"
        columnMaLoaiDocGia.DataPropertyName = "MaLoaiDocGia"
        DataGridViewQuanLiTheDocGia.Columns.Add(columnMaLoaiDocGia)

        Dim columnNgaySinh = New DataGridViewTextBoxColumn()
        columnNgaySinh.Name = "NgaySinh"
        columnNgaySinh.HeaderText = "Ngày Sinh"
        columnNgaySinh.DataPropertyName = "NgaySinh"
        DataGridViewQuanLiTheDocGia.Columns.Add(columnNgaySinh)

        Dim columnNgayTao = New DataGridViewTextBoxColumn()
        columnNgayTao.Name = "NgayTao"
        columnNgayTao.HeaderText = "Ngày tạo"
        columnNgayTao.DataPropertyName = "NgayTao"
        DataGridViewQuanLiTheDocGia.Columns.Add(columnNgayTao)

        Dim columnNgayHetHan = New DataGridViewTextBoxColumn()
        columnNgayHetHan.Name = "NgayHetHan"
        columnNgayHetHan.HeaderText = "Ngày hết hạn"
        columnNgayHetHan.DataPropertyName = "NgayHetHan"
        DataGridViewQuanLiTheDocGia.Columns.Add(columnNgayHetHan)
        Return result
    End Function

#End Region

#Region "-   Events   -"

    Private Sub ReaderTypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ReaderTypeComboBox.SelectedIndexChanged
        Try
            Dim maLoai = Convert.ToInt32(ReaderTypeComboBox.SelectedValue)
            LoadListDocGia(maLoai)
        Catch ex As Exception
        End Try
    End Sub

#Region "-   Load info cho thẻ độc giả được chọn   - "
    Private Sub DataGridViewQuanLiTheDocGia_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridViewQuanLiTheDocGia.SelectionChanged
        LoadInfoSelectedRow()
    End Sub

    Private Function LoadInfoSelectedRow() As Result
        Dim docGia = New DocGia()
        Dim result = GetSelectedDocGiaData(docGia)
        If result.FlagResult = False Then
            MaTheDocGiaTextBox.Text = ""
            UserNameTextBox.Text = ""
            EmailTextBox.Text = ""
            AddressTextBox.Text = ""
            BirthDateTimePicker.Value = Now
            LoaiDocGiaEditComboBox.SelectedIndex = ReaderTypeComboBox.SelectedIndex
            Return result
        End If
        MaTheDocGiaTextBox.Text = docGia.MaTheDocGia
        UserNameTextBox.Text = docGia.TenDocGia
        EmailTextBox.Text = docGia.Email
        AddressTextBox.Text = docGia.DiaChi
        BirthDateTimePicker.Value = docGia.NgaySinh
        LoaiDocGiaEditComboBox.SelectedIndex = ReaderTypeComboBox.SelectedIndex
        Return result
    End Function
#End Region

    Private Function GetSelectedDocGiaData(ByRef docGia As DocGia) As Result
        Dim currentRowIndex As Integer = DataGridViewQuanLiTheDocGia.CurrentCellAddress.Y
        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < DataGridViewQuanLiTheDocGia.RowCount) Then
            Try
                docGia = CType(DataGridViewQuanLiTheDocGia.Rows(currentRowIndex).DataBoundItem, DocGia)
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
                Return New Result(False, "Không lấy được thông tin độc giả đã chọn", "")
            End Try
        Else
            Return New Result(False, "Không lấy được thông tin độc giả đã chọn", "")
        End If

        Return New Result()
    End Function

    Private Sub EditButton_Click(sender As Object, e As EventArgs) Handles EditButton.Click
        Dim docGia = New DocGia()
        docGia.MaTheDocGia = MaTheDocGiaTextBox.Text
        docGia.TenDocGia = UserNameTextBox.Text
        docGia.Email = EmailTextBox.Text
        docGia.DiaChi = AddressTextBox.Text
        docGia.NgaySinh = BirthDateTimePicker.Value
        docGia.MaLoaiDocGia = (LoaiDocGiaEditComboBox.SelectedValue)

        Dim result = _docGiaBus.SuaTheDocGiaBangDocGia(docGia)
        If result.FlagResult = False Then
            MessageBox.Show(result.ApplicationMessage)
        Else
            MessageBox.Show("Sửa thành công")
            LoadListDocGia(docGia.MaLoaiDocGia)
        End If
    End Sub

    Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        Dim docGia = New DocGia()
        Dim getDataResult = GetSelectedDocGiaData(docGia)
        If getDataResult.FlagResult = False Then
            MessageBox.Show("Không thể nhận dạng độc giả cần xóa")
            Return
        End If

        Dim result = _docGiaBus.XoaTheDocGiaBangMaThe(docGia.MaTheDocGia)
        If result.FlagResult = False Then
            MessageBox.Show(result.ApplicationMessage)
        Else
            MessageBox.Show("Xóa thành công")
            LoadListDocGia(docGia.MaLoaiDocGia)
        End If
    End Sub

#End Region

End Class