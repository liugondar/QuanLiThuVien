Imports BUS
Imports DTO
Imports Utility

Public Class frmQuanLiLoaiDocGia

    Private loaiDocGiaBUS As LoaiDocGiaBus

#Region "-    Constructor   -"

    Private Sub frmQuanLyLoaiDocGia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaiDocGiaBUS = New LoaiDocGiaBus()
        'Load LoaiDocGiaDTO list
        LoadListLoaiDocGia()
    End Sub

    Private Sub LoadListLoaiDocGia()
        ' Load LoaiHocSinh list
        Dim listLoaiDocGia = New List(Of LoaiDocGia)
        Dim result As Result
        result = loaiDocGiaBUS.SelectAll(listLoaiDocGia)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách loại độc giả không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        dgvDanhSachLoaiDocGia.Columns.Clear()
        dgvDanhSachLoaiDocGia.DataSource = Nothing

        dgvDanhSachLoaiDocGia.AutoGenerateColumns = False
        dgvDanhSachLoaiDocGia.AllowUserToAddRows = False
        dgvDanhSachLoaiDocGia.DataSource = listLoaiDocGia

        Dim clMaLoai = New DataGridViewTextBoxColumn()
        clMaLoai.Name = "MaLoaiDocGia"
        clMaLoai.HeaderText = "Mã Loại"
        clMaLoai.DataPropertyName = "MaLoaiDocGia"
        clMaLoai.Width = 100
        dgvDanhSachLoaiDocGia.Columns.Add(clMaLoai)

        Dim clTenLoaiDocGia = New DataGridViewTextBoxColumn()
        clTenLoaiDocGia.Name = "TenLoaiDocGia"
        clTenLoaiDocGia.HeaderText = "Tên Loại"
        clTenLoaiDocGia.DataPropertyName = "TenLoaiDocGia"
        clTenLoaiDocGia.Width = 113
        dgvDanhSachLoaiDocGia.Columns.Add(clTenLoaiDocGia)
    End Sub

#End Region

#Region "-   Events   -"
    Private Sub dgvDanhSachLoaiDocGia_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDanhSachLoaiDocGia.SelectionChanged
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachLoaiDocGia.CurrentCellAddress.Y 'current row selected

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachLoaiDocGia.RowCount) Then
            Try
                Dim loaiDocGia = CType(dgvDanhSachLoaiDocGia.Rows(currentRowIndex).DataBoundItem, LoaiDocGia)
                txtMaLoai.Text = loaiDocGia.MaLoaiDocGia
                txtTenLoai.Text = loaiDocGia.TenLoaiDocGia
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub btnCapNhap_Click(sender As Object, e As EventArgs) Handles btnCapNhap.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachLoaiDocGia.CurrentCellAddress.Y 'current row selected
        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachLoaiDocGia.RowCount) Then
            Try
                Dim loaiDocGia As LoaiDocGia
                loaiDocGia = New LoaiDocGia()

                '1. Mapping data from GUI control
                loaiDocGia.MaLoaiDocGia = Convert.ToInt32(txtMaLoai.Text)
                loaiDocGia.TenLoaiDocGia = txtTenLoai.Text

                '2. Insert to DB
                Dim result As Result
                result = loaiDocGiaBUS.UpdateById(loaiDocGia, loaiDocGia.MaLoaiDocGia)
                If (result.FlagResult) Then
                    ' Re-Load LoaiHocSinh list
                    LoadListLoaiDocGia()
                    ' Hightlight the row has been updated on table
                    dgvDanhSachLoaiDocGia.Rows(currentRowIndex).Selected = True
                    Try
                        loaiDocGia = CType(dgvDanhSachLoaiDocGia.Rows(currentRowIndex).DataBoundItem, LoaiDocGia)
                        txtMaLoai.Text = loaiDocGia.MaLoaiDocGia
                        txtTenLoai.Text = loaiDocGia.TenLoaiDocGia
                    Catch ex As Exception
                        Console.WriteLine(ex.StackTrace)
                    End Try
                    MessageBox.Show("Cập nhật loại độc giả thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Cập nhật loại độc giả không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    System.Console.WriteLine(result.SystemMessage)
                End If
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachLoaiDocGia.CurrentCellAddress.Y 'current row selected

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachLoaiDocGia.RowCount) Then
            Select Case MsgBox("Bạn có thực sự muốn xóa loại độc giả có mã: " + txtMaLoai.Text, MsgBoxStyle.YesNo, "Information")
                Case MsgBoxResult.Yes
                    Try
                        '1. Delete from DB
                        Dim result As Result
                        result = loaiDocGiaBUS.DeleteById(Convert.ToInt32(txtMaLoai.Text))
                        If (result.FlagResult = True) Then

                            ' Re-Load LoaiHocSinh list
                            LoadListLoaiDocGia()

                            ' Hightlight the next row on table
                            If (currentRowIndex >= dgvDanhSachLoaiDocGia.Rows.Count) Then
                                currentRowIndex = currentRowIndex - 1
                            End If
                            If (currentRowIndex >= 0) Then
                                dgvDanhSachLoaiDocGia.Rows(currentRowIndex).Selected = True
                                Try
                                    Dim loaiDocGia = CType(dgvDanhSachLoaiDocGia.Rows(currentRowIndex).DataBoundItem, LoaiDocGia)
                                    txtMaLoai.Text = loaiDocGia.MaLoaiDocGia
                                    txtTenLoai.Text = loaiDocGia.TenLoaiDocGia
                                Catch ex As Exception
                                    Console.WriteLine(ex.StackTrace)
                                End Try
                            End If
                            MessageBox.Show("Xóa loại độc giả thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Xóa loại độc giả không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            System.Console.WriteLine(result.SystemMessage)
                        End If
                    Catch ex As Exception
                        Console.WriteLine(ex.StackTrace)
                    End Try
                Case MsgBoxResult.No
                    Return
            End Select

        End If

    End Sub
#End Region
End Class