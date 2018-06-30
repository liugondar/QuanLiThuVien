Imports BUS
Imports DTO
Imports Utility

Public Class frmThemLoaiDocGia
    Private _loaiDocGiaBUS As LoaiDocGiaBus

#Region "-   Constructor"
    Private Sub frmThemLoaiDocGia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _loaiDocGiaBUS = New LoaiDocGiaBus()
        LoadMaLoaiDocGiaTiepTheo()
    End Sub

    Private Sub LoadMaLoaiDocGiaTiepTheo()
        Dim result = _loaiDocGiaBUS.GetTheNextId(txtMaLoaiDocGia.Text)
        If Not result.FlagResult Then MessageBox.Show("Lấy ID kế tiếp của Loại độc giả không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

#End Region

#Region "-   Events   -"
    Private Sub btnNhapVaDong_Click(sender As Object, e As EventArgs) Handles btnNhapVaDong.Click
        Dim result As Result = InsertLoaiDocGia()

        If (result.FlagResult = True) Then
            MessageBox.Show("Thêm loại độc giả thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTenLoaiDocGiaDocGia.Text = String.Empty
            Me.Close()
        Else
            MessageBox.Show(result.ApplicationMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If

    End Sub
    Private Sub btnNhap_Click(sender As Object, e As EventArgs) Handles btnNhap.Click
        Dim result As Result = InsertLoaiDocGia()

        If (result.FlagResult = True) Then
            MessageBox.Show("Thêm loại độc giả thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTenLoaiDocGiaDocGia.Text = String.Empty
            LoadMaLoaiDocGiaTiepTheo()
        Else
            MessageBox.Show(result.ApplicationMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If
    End Sub

    Private Function InsertLoaiDocGia() As Result
        Dim loaiDocGia As LoaiDocGia = New LoaiDocGia()

        '1. Mapping data from GUI control
        loaiDocGia.MaLoaiDocGia = Convert.ToInt32(txtMaLoaiDocGia.Text)
        loaiDocGia.TenLoaiDocGia = txtTenLoaiDocGiaDocGia.Text

        '2. Insert to DB
        Dim result As Result
        result = _loaiDocGiaBUS.InsertOne(loaiDocGia)
        Return result
    End Function
#End Region
End Class