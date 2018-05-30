Imports BUS
Imports DTO
Imports Utility

Public Class frmQuanLiTheDocGia
    Private _docGiaBus As DocGiaBus
    Private _loaiDocGiaBus As LoaiDocGiaBus
    Private _listLoaiDocGia As List(Of LoaiDocGia)
    Private Sub frmQuanLiTheDocGia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _loaiDocGiaBus = New LoaiDocGiaBus()
        _listLoaiDocGia = New List(Of LoaiDocGia)
        _docGiaBus = New DocGiaBus()
        LoadReaderTypeComboBoxData()
    End Sub

    Private Sub LoadReaderTypeComboBoxData()
        Try

            Dim result = _loaiDocGiaBus.SelectAll(_listLoaiDocGia)
            For Each readerType In _listLoaiDocGia
                ReaderTypeComboBox.Items.Add(readerType)
            Next

            ReaderTypeComboBox.SelectedIndex = 0
            ReaderTypeComboBox.DisplayMember = "TenLoaiDocGia"
            ReaderTypeComboBox.ValueMember = "LoaiDocGiaId"
        Catch ex As ArgumentException
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Function LoadListDocGia(maLoai As String) As Result
        Dim loaiDocGiaBus = New LoaiDocGiaBus()
        Dim listLoaiDocGia = New List(Of LoaiDocGia)
        Dim result = loaiDocGiaBus.SelectAll(listLoaiDocGia)

        ReaderTypeComboBox.DataSource = New BindingSource(listLoaiDocGia, String.Empty)
        ReaderTypeComboBox.SelectedIndex = 0
        ReaderTypeComboBox.DisplayMember = "TenLoaiDocGia"
        ReaderTypeComboBox.ValueMember = "MaLoaiDocGia"
        Return result
    End Function

    Private Sub ReaderTypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ReaderTypeComboBox.SelectedIndexChanged
        Try
            Dim maLoai = Convert.ToInt32(ReaderTypeComboBox.SelectedValue)
            LoadListDocGia(maLoai)
        Catch ex As Exception

        End Try
    End Sub
End Class