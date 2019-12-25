Imports BUS
Imports DTO
Imports Utility

Public Class frmDocGia

#Region "-   Fields   -"
    Private _docGiaBus As DocGiaBus
    Private _loaiDocGiaBus As LoaiDocGiaBus
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
    Private Sub frmQuanLiTheDocGia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _loaiDocGiaBus = New LoaiDocGiaBus()
        _docGiaBus = New DocGiaBus()
        Dim loadReaderTypeComboBoxResult = LoadReaderTypeComboBoxData()
        If loadReaderTypeComboBoxResult.FlagResult = False Then
            MessageBox.Show(loadReaderTypeComboBoxResult.ApplicationMessage)
            Me.Close()
        End If

    End Sub

    Private Function LoadReaderTypeComboBoxData() As Result
        Dim listLoaiDocGia = New List(Of LoaiDocGia)
        Dim firstLoaiDocGia = New LoaiDocGia()
        firstLoaiDocGia.MaLoaiDocGia = -1
        firstLoaiDocGia.TenLoaiDocGia = "Tất cả"
        listLoaiDocGia.Add(firstLoaiDocGia)
        Dim result = _loaiDocGiaBus.SelectAll(listLoaiDocGia)

        ReaderTypeComboBox.DataSource = New BindingSource(listLoaiDocGia, String.Empty)
        ReaderTypeComboBox.DisplayMember = "TenLoaiDocGia"
        ReaderTypeComboBox.ValueMember = "MaLoaiDocGia"

        cbLoaiDocGiaEdit.DataSource = New BindingSource(listLoaiDocGia, String.Empty)
        cbLoaiDocGiaEdit.DisplayMember = "TenLoaiDocGia"
        cbLoaiDocGiaEdit.ValueMember = "MaLoaiDocGia"

        If listLoaiDocGia.Count < 1 Then
            Return New Result(False, "Load loại danh sách thẻ độc giả không thành công!", "")
        End If

        Try
            Dim maLoai = Convert.ToInt32(ReaderTypeComboBox.SelectedValue)
            LoadListDocGia(maLoai)
        Catch ex As Exception
        End Try

        Return result
    End Function

    Function LoadListDocGia(maLoai As String) As Result
        ClearDataGridViewSource()

        CreateDataGridViewColumn()

        Dim listLoaiDocGia = New List(Of DocGia)
        Dim result = _docGiaBus.SelectAllByType(maLoai, listLoaiDocGia)
        If result.FlagResult = False Then
            ResetSpecificRowSelectedControlTextInfo()
            Return result
        End If

        DataGridViewQuanLiTheDocGia.DataSource = listLoaiDocGia

        LoadInfoSelectedRow()

        Return result
    End Function

    Private Sub ClearDataGridViewSource()
        DataGridViewQuanLiTheDocGia.Columns.Clear()
        DataGridViewQuanLiTheDocGia.DataSource = Nothing
        DataGridViewQuanLiTheDocGia.AutoGenerateColumns = False
        DataGridViewQuanLiTheDocGia.AllowUserToAddRows = False
    End Sub

    Private Sub CreateDataGridViewColumn()
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
    End Sub

#End Region

#Region "-   Events   -"

    Private Sub ReaderTypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ReaderTypeComboBox.SelectedIndexChanged
        Try
            Dim maLoai = Convert.ToInt32(ReaderTypeComboBox.SelectedValue)
            ResetSpecificRowSelectedControlTextInfo()
            LoadListDocGia(maLoai)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ResetSpecificRowSelectedControlTextInfo()
        txtUserName.ResetText()
        txtAddress.ResetText()
        txtEmail.ResetText()
        txtMaTheDocGia.ResetText()
    End Sub

#Region "-   Load info cho thẻ độc giả được chọn   - "
    Private Sub DataGridViewQuanLiTheDocGia_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridViewQuanLiTheDocGia.SelectionChanged
        LoadInfoSelectedRow()
    End Sub

    Private Function LoadInfoSelectedRow() As Result
        Dim docGia = New DocGia()
        Dim result = GetSelectedDocGiaData(docGia)
        If result.FlagResult = False Then
            txtMaTheDocGia.Text = ""
            txtUserName.Text = ""
            txtEmail.Text = ""
            txtAddress.Text = ""
            dtpBirthDate.Value = Now
            cbLoaiDocGiaEdit.SelectedIndex = ReaderTypeComboBox.SelectedIndex
            Return result
        End If
        txtMaTheDocGia.Text = docGia.MaTheDocGia
        txtUserName.Text = docGia.TenDocGia
        txtEmail.Text = docGia.Email
        txtAddress.Text = docGia.DiaChi
        dtpBirthDate.Value = docGia.NgaySinh
        cbLoaiDocGiaEdit.SelectedIndex = ReaderTypeComboBox.SelectedIndex
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

    Private Sub EditButton_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If MessageBox.Show("Bạn có chắc thay đổi thông tin?", "Thông Báo", MessageBoxButtons.OKCancel) = System.Windows.Forms.DialogResult.OK Then
            Try
                Dim docGia = New DocGia()
                docGia.MaTheDocGia = txtMaTheDocGia.Text
                docGia.TenDocGia = txtUserName.Text
                docGia.Email = txtEmail.Text
                docGia.DiaChi = txtAddress.Text
                docGia.NgaySinh = dtpBirthDate.Value
                docGia.MaLoaiDocGia = (cbLoaiDocGiaEdit.SelectedValue)

                Dim result = _docGiaBus.UpdateById(docGia)
                If result.FlagResult = False Then
                    MessageBox.Show(result.ApplicationMessage)
                    Return
                Else
                    MessageBox.Show("Sửa thành công", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadListDocGia(docGia.MaLoaiDocGia)
                End If
            Catch
            End Try
        End If
    End Sub

    Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim docGia = New DocGia()
        Dim getDataResult = GetSelectedDocGiaData(docGia)
        Select Case MsgBox("Bạn có thực sự muốn xóa thể loại sách có mã: " + docGia.MaTheDocGia.ToString(), MsgBoxStyle.YesNo, "Information")
            Case MsgBoxResult.Yes
                If getDataResult.FlagResult = False Then
                    MessageBox.Show("Không thể nhận dạng độc giả cần xóa")
                    Return
                End If

                Dim result = _docGiaBus.DeleteByID(docGia.MaTheDocGia)
                If result.FlagResult = False Then
                    MessageBox.Show(result.ApplicationMessage)
                Else
                    MessageBox.Show("Xóa thành công")
                    LoadListDocGia(docGia.MaLoaiDocGia)
                End If
            Case MsgBoxResult.No
                Return
        End Select
    End Sub

#End Region

End Class