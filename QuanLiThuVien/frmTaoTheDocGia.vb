Imports BUS
Imports DAO
Imports DTO
Public Class frmTaoTheDocGia
    Private Sub CreateButton_Click_1(sender As Object, e As EventArgs) Handles CreateButton.Click
        InsertConfirm()
    End Sub
    Function InsertConfirm() As Boolean
        Dim docGia = New DocGia()
        docGia.TenDocGia = UserNameTextBox.Text
        docGia.TenNguoiTao = CreatorTextBox.Text
        docGia.Email = EmailTextBox.Text
        docGia.DiaChi = AddressTextBox.Text
        docGia.LoaiDocGiaId = ReaderTypeComboBox.SelectedItem.LoaiDocGiaId
        docGia.NgaySinh = DateOfBirthDateTimePicker.Value
        docGia.NgayTao = DateCreateDateTimePicker.Value

        Dim readerBus = New DocGiaBus()
        Dim result = readerBus.Insert1(docGia)
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
        InitReaderTypeComboboxData()
    End Sub

    Private Sub InitReaderTypeComboboxData()
        Dim readerTypeBus = New LoaiDocGiaBus()
        Dim _listReaderType = readerTypeBus.SelectAll()

        For Each readerType In _listReaderType
            ReaderTypeComboBox.Items.Add(readerType)
        Next

        ReaderTypeComboBox.SelectedIndex = 0
        ReaderTypeComboBox.DisplayMember = "TenLoaiDocGia"
        ReaderTypeComboBox.ValueMember = "LoaiDocGiaId"
    End Sub

End Class