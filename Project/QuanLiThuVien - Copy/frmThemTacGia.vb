Imports BUS
Imports DTO
Imports Utility

Public Class frmThemTacGia
    Private tacGiaBUS As TacGiaBUS
#Region "-   Constructor   -"
    Private Sub frmThemTacGia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tacGiaBUS = New TacGiaBUS()

        LoadMaTacGiaTiepTheo()
    End Sub

    Private Sub LoadMaTacGiaTiepTheo()
        ' Get Next ID
        Dim nextID As Integer
        Dim result As Result
        result = tacGiaBUS.GetTheNextID(nextID)
        If (result.FlagResult = True) Then
            txtMaTacGia.Text = nextID.ToString()
        Else
            MessageBox.Show("Lấy ID kế tiếp của Tác giả không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If
    End Sub

#End Region

#Region "-   Events    -"

    Private Sub btnNhap_Click(sender As Object, e As EventArgs) Handles btnNhap.Click
        Dim insertResult = InsertTacGia()
        If Not insertResult.FlagResult Then
            MessageBox.Show(insertResult.ApplicationMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        MessageBox.Show("Thêm loại độc giả thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        txtTenTacGia.Text = String.Empty
        LoadMaTacGiaTiepTheo()
    End Sub

    Private Sub btnNhapVaDong_Click(sender As Object, e As EventArgs) Handles btnNhapVaDong.Click
        Dim insertResult = InsertTacGia()
        If Not insertResult.FlagResult Then
            MessageBox.Show(insertResult.ApplicationMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        MessageBox.Show("Thêm loại độc giả thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Private Function InsertTacGia() As Result
        Dim tacGia = New TacGia()
        tacGia.MaTacGia = Convert.ToInt32(txtMaTacGia.Text)
        tacGia.TenTacGia = txtTenTacGia.Text

        Return tacGiaBUS.InsertOne(tacGia)
    End Function
#End Region
End Class