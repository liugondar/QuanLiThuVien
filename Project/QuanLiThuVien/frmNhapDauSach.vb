Imports BUS
Imports DTO
Imports Utility

Public Class frmNhapSach

#Region "-  Fields   -"
    Dim dausachBus As New DauSachBus
    Dim cuonSachBus As New SachBus
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
        cuonSachBus = New SachBus()
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
<<<<<<< HEAD
=======
<<<<<<<< HEAD:Project/QuanLiThuVien/frmNhapDauSach.vb
    End Sub

    Private Sub InsertDauSach()
========
>>>>>>> loc
        LoadTxtMaDauSach()
    End Sub

    Private Function InsertDauSach() As Result
<<<<<<< HEAD
=======
>>>>>>>> loc:Project/QuanLiThuVien/frmNhapSach.vb
>>>>>>> loc
        Dim result As New Result

        Dim dausach = New DauSachDTO()
        dausach.TenSach = BookTitleTextBox.Text
        dausach.MaTheLoaiSach = CategoryComboBox.SelectedItem.MaTheLoaiSach
        dausach.MaTacGia = AuthorComboBox.SelectedItem.MaTacGia
        dausach.TenNhaXuatBan = PulisherTextBox.Text
        dausach.NgayXuatBan = PublishYearDateTimePicker.Value
        dausach.TriGia = PriceNumericUpDown.Value
        dausach.SoLuong = nudSoLuong.Value


        result = _dausachBus.InsertOne(dausach)
        If result.FlagResult = False Then
            MessageBox.Show(result.ApplicationMessage)
        Else

<<<<<<< HEAD
            For i As Integer = 1 To nudSoLuong.Value
=======
<<<<<<<< HEAD:Project/QuanLiThuVien/frmNhapDauSach.vb
            For i As Integer = 1 To dausach.SoLuong
========
            For i As Integer = 1 To nudSoLuong.Value
>>>>>>>> loc:Project/QuanLiThuVien/frmNhapSach.vb
>>>>>>> loc
                Dim cuonsach = New Sach With {
                    .MaDauSach = dausach.MaDauSach,
                    .NgayNhap = DateInputDateTimePicker.Value
                }
                cuonSachBus.InsertOne(cuonsach)
            Next
            MessageBox.Show("Đã nhập thành công đầu sách mới!")

        End If

<<<<<<< HEAD
        Return result

    End Function
=======
<<<<<<<< HEAD:Project/QuanLiThuVien/frmNhapDauSach.vb
    End Sub
========
        Return result

    End Function
>>>>>>>> loc:Project/QuanLiThuVien/frmNhapSach.vb
>>>>>>> loc




#End Region

    Private Sub CreateAndCloseButton_Click(sender As Object, e As EventArgs) Handles CreateAndCloseButton.Click
<<<<<<< HEAD
        If InsertDauSach().FlagResult Then
            Close()
        End If
    End Sub

=======
<<<<<<<< HEAD:Project/QuanLiThuVien/frmNhapDauSach.vb
        InsertDauSach()
        Close()
========
        If InsertDauSach().FlagResult Then
            Close()
        End If
>>>>>>>> loc:Project/QuanLiThuVien/frmNhapSach.vb
    End Sub

    Private Sub nudSoLuong_ValueChanged(sender As Object, e As EventArgs) 

    End Sub




>>>>>>> loc
#End Region

End Class