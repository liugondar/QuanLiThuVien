Imports BUS
Imports DAO
Imports DTO
Imports Utility

Public Class frmTaoTheDocGia
    Private didReaderTypeComboboxLoad As Boolean
    Private Sub CreateButton_Click_1(sender As Object, e As EventArgs) Handles CreateButton.Click
        InsertConfirm()
    End Sub
    Function InsertConfirm() As Boolean
        If didReaderTypeComboboxLoad = False Then
            MessageBox.Show("Dữ liệu nhập không thành công do lỗi không load được loại độc giả ")
            Return False
        End If
        Dim docGia = New DocGia()
        docGia.TenDocGia = UserNameTextBox.Text
        docGia.Email = EmailTextBox.Text
        docGia.DiaChi = AddressTextBox.Text
        docGia.MaLoaiDocGia = ReaderTypeComboBox.SelectedValue
        docGia.NgaySinh = DateOfBirthDateTimePicker.Value
        docGia.NgayTao = DateCreateDateTimePicker.Value

        Dim readerBus = New DocGiaBus()
        Dim result = readerBus.InsertOne(docGia)
        If result.FlagResult = False Then
            MessageBox.Show(result.ApplicationMessage)
            Return False
        Else
            MessageBox.Show("Nhập thành công")
            Return True
        End If
    End Function

    Private Sub CreateAndCloseButton_Click(sender As Object, e As EventArgs) Handles CreateAndCloseButton.Click
        If InsertConfirm() Then
            Close()
        End If
    End Sub

    Private Sub FormCreateReader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        didReaderTypeComboboxLoad = LoadReaderTypeComboboxData().FlagResult
    End Sub

    Private Function LoadReaderTypeComboboxData() As Result
        Dim loaiDocGiaBus = New LoaiDocGiaBus()
        Dim listLoaiDocGia = New List(Of LoaiDocGia)
        Dim result = loaiDocGiaBus.SelectAll(listLoaiDocGia)

        ReaderTypeComboBox.DataSource = New BindingSource(listLoaiDocGia, String.Empty)
        ReaderTypeComboBox.SelectedIndex = 0
        ReaderTypeComboBox.DisplayMember = "TenLoaiDocGia"
        ReaderTypeComboBox.ValueMember = "MaLoaiDocGia"

        Return result
    End Function

End Class