Imports BUS
Imports DTO
Imports Utility

Public Class frmNhapSach

#Region "-  Fields   -"
    Dim cuonsachBus As New DauSachBus
    Private _tacGiaBus As TacGiaBUS
    Private _theLoaiSachBus As TheLoaiSachBUS
    Private _dausachBus As DauSachBus
    Private _listTheLoaiSach As List(Of TheLoaiSach)
    Private _listTacGia As List(Of TacGia)

#End Region

#Region "-  Constructor  -"

    Private Sub frmNhapSach_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _tacGiaBus = New TacGiaBUS()
        _theLoaiSachBus = New TheLoaiSachBUS()
        _dausachBus = New DauSachBus()
        _listTacGia = New List(Of TacGia)
        _listTheLoaiSach = New List(Of TheLoaiSach)
        LoadCategoryComboboxData()
        LoadAuthorComboBoxData()

        PublishYearDateTimePicker.Format = DateTimePickerFormat.Custom
        PublishYearDateTimePicker.CustomFormat = "yyyy"
        PublishYearDateTimePicker.ShowUpDown = True
        PublishYearDateTimePicker.MaxDate = Now

        DateInputDateTimePicker.MaxDate = Now
        LoadTxtMaDauSach()
    End Sub

    Private Sub LoadTxtMaDauSach()
        Dim maDauSach = String.Empty
        _dausachBus.GetNextId(maDauSach)
        txtMaDauSach.Text = maDauSach
    End Sub

    Private Sub LoadAuthorComboBoxData()
        Dim result = _tacGiaBus.SelectAll(_listTacGia)
        If result.FlagResult = False Then
            MessageBox.Show(result.ApplicationMessage)
            Return
        End If

        AuthorComboBox.DataSource = New BindingSource(_listTacGia, String.Empty)
        AuthorComboBox.DisplayMember = "TenTacGia"
        AuthorComboBox.ValueMember = "MaTacGia"
    End Sub

    Private Sub LoadCategoryComboboxData()

        Dim result = _theLoaiSachBus.SelectAll(_listTheLoaiSach)
        If result.FlagResult = False Then
            MessageBox.Show(result.ApplicationMessage)
            Return
        End If

        CategoryComboBox.DataSource = New BindingSource(_listTheLoaiSach, String.Empty)
        CategoryComboBox.DisplayMember = "TenTheLoaiSach"
        CategoryComboBox.ValueMember = "MaTheLoaiSach"

    End Sub
#End Region

#Region "-   Events   -"

#Region "-   Create button clicked  -"
    Private Sub CreateButton_Click(sender As Object, e As EventArgs) Handles CreateButton.Click
        InsertDauSach()
    End Sub

    Private Sub InsertDauSach()
        Dim result As New Result

        Dim dausach = New DauSachDTO()
        dausach.TenSach = BookTitleTextBox.Text
        dausach.MaTheLoaiSach = CategoryComboBox.SelectedItem.MaTheLoaiSach
        dausach.MaTacGia = AuthorComboBox.SelectedItem.MaTacGia
        dausach.TenNhaXuatBan = PulisherTextBox.Text
        dausach.NgayXuatBan = PublishYearDateTimePicker.Value
        dausach.NgayNhap = DateInputDateTimePicker.Value
        dausach.TriGia = PriceNumericUpDown.Value

        result = _dausachBus.InsertOne(dausach)
        If result.FlagResult = False Then
            MessageBox.Show(result.ApplicationMessage)
        Else
            MessageBox.Show("Đã nhập thành công đầu sách mới!")
        End If

        'For i As Integer = 1 To nudSoLuong.Value
        '    Dim cuonsach As New DauSachDTO
        '    Dim macuonsach As String
        '    macuonsach = ""
        '    cuonsachBus.buildMaCuonSach(macuonsach)

        '    cuonsach.MaCuonSach = macuonsach
        '    cuonsach.TinhTrang = txbTinhTrang.Text
        '    cuonsach.DauSach = txtMaSach.Text
        '    cuonsach.SoKe = nudViTriKe.Value

        '    result = cuonsachBus.insert(cuonsach)
        '    If result.FlagResult = False Then
        '        Dim mes = "Thêm cuốn sách thất bại: " + macuonsach + "\n" + result.SystemMessage
        '        MessageBox.Show(mes, "Lỗi", MessageBoxButtons.OK)
        '    End If
        'Next


    End Sub




#End Region

    Private Sub CreateAndCloseButton_Click(sender As Object, e As EventArgs) Handles CreateAndCloseButton.Click
        InsertDauSach()
        Close()
    End Sub

    Private Sub nudSoLuong_ValueChanged(sender As Object, e As EventArgs) Handles nudSoLuong.ValueChanged

    End Sub




#End Region

End Class