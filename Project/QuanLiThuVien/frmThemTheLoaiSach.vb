Imports BUS
Imports DTO
Imports Utility
Public Class frmThemTheLoaiSach
    Private _theloaiSachBus As TheLoaiSachBUS
#Region "-   Constructor   -"
    Private Sub frmThemTheLoaiSach_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _theloaiSachBus = New TheLoaiSachBUS()
        LoadMaTheLoaiSachTiepTheo()
    End Sub

    Private Sub LoadMaTheLoaiSachTiepTheo()
        Dim result = _theloaiSachBus.GetTheNextID(txtMaTheLoaiSach.Text)
        If Not result.FlagResult Then
            MessageBox.Show("Không thể lấy mã thể loại tiếp theo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
    End Sub
#End Region

#Region "-   Events    -"
    Private Sub btnNhap_Click(sender As Object, e As EventArgs) Handles btnNhap.Click
        Dim insertResult = InsertTheLoaiSach()
        If Not insertResult.FlagResult Then
            MessageBox.Show(insertResult.ApplicationMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        MessageBox.Show("Thêm thành công!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        LoadMaTheLoaiSachTiepTheo()
    End Sub

    Private Sub btnNhapVaDong_Click(sender As Object, e As EventArgs) Handles btnNhapVaDong.Click
        Dim insertResult = InsertTheLoaiSach()
        If Not insertResult.FlagResult Then
            MessageBox.Show(insertResult.ApplicationMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        MessageBox.Show("Thêm thành công!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub
    Private Function InsertTheLoaiSach() As Result
        Dim theLoaiSach = New TheLoaiSach()
        theLoaiSach.TenTheLoaiSach = txtTenTheLoaiSach.Text
        Return _theloaiSachBus.InsertOne(theLoaiSach)
    End Function
#End Region
End Class