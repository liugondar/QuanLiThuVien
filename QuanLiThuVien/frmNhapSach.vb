Imports BUS
Imports DTO

Public Class frmNhapSach
    Private _tacGiaBus As TacGiaBUS
    Private _theLoaiSachBus As TheLoaiSachBUS
    Private _sachBus As SachBus
    Private _listTheLoaiSach As List(Of TheLoaiSach)
    Private _listTacGia As List(Of TacGia)
    Private Sub frmNhapSach_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _tacGiaBus = New TacGiaBUS()
        _theLoaiSachBus = New TheLoaiSachBUS()
        _sachBus = New SachBus()
        _listTacGia = New List(Of TacGia)
        _listTheLoaiSach = New List(Of TheLoaiSach)
        LoadCategoryComboboxData()
        LoadAuthorComboBoxData()

        PublishYearDateTimePicker.Format = DateTimePickerFormat.Custom
        PublishYearDateTimePicker.CustomFormat = "yyyy"
        PublishYearDateTimePicker.ShowUpDown = True

        DateInputDateTimePicker.Format = DateTimePickerFormat.Custom
        DateInputDateTimePicker.CustomFormat = "yyyy"
        DateInputDateTimePicker.ShowUpDown = True
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

    Private Sub CreateButton_Click(sender As Object, e As EventArgs) Handles CreateButton.Click
        InsertSach()
    End Sub

    Private Sub InsertSach()
        Dim sach = New Sach()
        sach.TenSach = BookTitleTextBox.Text
        sach.MaTheLoaiSach = CategoryComboBox.SelectedValue
        sach.MaTacGia = AuthorComboBox.SelectedValue
        sach.TenNhaXuatBan = PulisherTextBox.Text
        sach.NgayXuatBan = PublishYearDateTimePicker.Value
        sach.NgayNhap = DateInputDateTimePicker.Value
        sach.TriGia = PriceNumericUpDown.Value

        Dim result = _sachBus.InsertOne(sach)
        If result.FlagResult = False Then
            MessageBox.Show(result.ApplicationMessage)
        Else
            MessageBox.Show("Đã nhập thành công sách mới!")
        End If
    End Sub

    Private Sub CreateAndCloseButton_Click(sender As Object, e As EventArgs) Handles CreateAndCloseButton.Click
        InsertSach()
        Close()
    End Sub


End Class