Imports BUS
Imports DAO
Imports DTO
Imports Utility

Public Class frmTaoTheDocGia

#Region "-   Fields -"
    Private _didReaderTypeComboboxLoad As Result
    Private _docGiaBus As DocGiaBus
    Private _quiDinhBus As QuiDinhBus
#End Region

#Region "-   Constructor   -"

    Private Sub FormCreateReader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _docGiaBus = New DocGiaBus()
        _quiDinhBus = New QuiDinhBus()

        _didReaderTypeComboboxLoad = LoadReaderTypeComboboxData()
        SetDefaultBirthDayTimePicker()
        LoadReaderIdTextBox()
        BindingCreateDatetimeToExpirationDate()
    End Sub

    Private Sub SetDefaultBirthDayTimePicker()
        Dim quiDinh = New QuiDinh()
        _quiDinhBus.GetTuoiToiDaVaToiThieu(quiDinh)
        DateOfBirthDateTimePicker.Value = DateTime.Now.AddYears(-quiDinh.TuoiToiThieu)
        DateOfBirthDateTimePicker.MaxDate = DateTime.Now.AddYears(-quiDinh.TuoiToiThieu)
    End Sub

    Private Function LoadReaderIdTextBox() As Result
        Dim maDocGia As String
        Dim ketQuaLayMa = _docGiaBus.BuildMaDocGia(maDocGia)
        If ketQuaLayMa.FlagResult = False Then
            MessageBox.Show("Lỗi không thể lấy mã độc giả để tiến hành tạo thẻ!")
            Return ketQuaLayMa
        End If
        ReaderIDTextBox.Text = maDocGia
        Return ketQuaLayMa
    End Function

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

#End Region

#Region "-   Events   -"

#Region "-   Insert   -"
    Private Sub CreateButton_Click_1(sender As Object, e As EventArgs) Handles CreateButton.Click
        InsertConfirm()
        LoadReaderIdTextBox()
    End Sub

    Private Sub CreateAndCloseButton_Click(sender As Object, e As EventArgs) Handles CreateAndCloseButton.Click
        If InsertConfirm() Then
            Close()
        End If
    End Sub

    Function InsertConfirm() As Boolean
        If _didReaderTypeComboboxLoad.FlagResult = False Then
            MessageBox.Show(_didReaderTypeComboboxLoad.ApplicationMessage)
            Return False
        End If
        Dim docGia = New DocGia()
        docGia.TenDocGia = UserNameTextBox.Text
        docGia.Email = EmailTextBox.Text
        docGia.DiaChi = AddressTextBox.Text
        docGia.MaLoaiDocGia = ReaderTypeComboBox.SelectedValue
        docGia.NgaySinh = DateOfBirthDateTimePicker.Value
        docGia.NgayTao = DateCreateDateTimePicker.Value

        Dim result = _docGiaBus.InsertOne(docGia)
        If result.FlagResult = False Then
            MessageBox.Show(result.ApplicationMessage)
            Return False
        Else
            MessageBox.Show("Nhập thành công")
            Return True
        End If
    End Function
#End Region

#Region "-  Binding CreateDatetime data To ExpirationDate   -"
    Private Sub DateCreateDateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles DateCreateDateTimePicker.ValueChanged
        BindingCreateDatetimeToExpirationDate()
    End Sub

    Private Function BindingCreateDatetimeToExpirationDate()
        Dim quiDinh = New QuiDinh()
        _quiDinhBus.GetThoiHanToiDaTheDocGia(quiDinh)
        Dim ngayHetHan = DateCreateDateTimePicker.Value.AddYears(quiDinh.ThoiHanToiDaTheDocGia)
        ExpirationDateTimePicker.Value = ngayHetHan
    End Function

#End Region

#End Region

End Class