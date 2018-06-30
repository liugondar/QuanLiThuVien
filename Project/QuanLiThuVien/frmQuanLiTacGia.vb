Imports BUS
Imports DTO
Imports Utility

Public Class frmQuanLiTacGia
    Private _tacGiaBus As TacGiaBUS
#Region "-   Constructor   -"
    Private Sub frmQuanLiTacGia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _tacGiaBus = New TacGiaBUS()
        LoadListTacGia()
    End Sub

    Private Sub LoadListTacGia()
        Try
            ClearDataGridViewData()

            CreateDataGridViewColumn()
            'Load the loai sach list
            Dim listTacGia = New List(Of TacGia)
            Dim result = _tacGiaBus.SelectAll(listTacGia)
            If (result.FlagResult = False) Then
                MessageBox.Show("Load danh sách tác giả không thành công!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            dgvDanhSachTacGia.DataSource = listTacGia
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub CreateDataGridViewColumn()
        Dim clMaTg = New DataGridViewTextBoxColumn()
        clMaTg.Name = "MaTacGia"
        clMaTg.HeaderText = "Mã tác giả"
        clMaTg.DataPropertyName = "MaTacGia"
        dgvDanhSachTacGia.Columns.Add(clMaTg)

        Dim clTenTacGia = New DataGridViewTextBoxColumn()
        clTenTacGia.Name = "TenTacGia"
        clTenTacGia.HeaderText = "Tên tác giả"
        clTenTacGia.DataPropertyName = "TenTacGia"
        clTenTacGia.Width = 200
        dgvDanhSachTacGia.Columns.Add(clTenTacGia)

    End Sub

    Private Sub ClearDataGridViewData()
        dgvDanhSachTacGia.Columns.Clear()
        dgvDanhSachTacGia.DataSource = Nothing

        dgvDanhSachTacGia.AutoGenerateColumns = False
        dgvDanhSachTacGia.AllowUserToAddRows = False
    End Sub
#End Region

#Region "-   Events    -"
    Private Sub dgvDanhSachTacGia_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDanhSachTacGia.SelectionChanged
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachTacGia.CurrentCellAddress.Y 'current row selected

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachTacGia.RowCount) Then
            Try
                Dim tacGia = CType(dgvDanhSachTacGia.Rows(currentRowIndex).DataBoundItem, TacGia)
                txtMaTacGia.Text = tacGia.MaTacGia
                txtTenTacGia.Text = tacGia.TenTacGia
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub btnCapNhap_Click(sender As Object, e As EventArgs) Handles btnCapNhap.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachTacGia.CurrentCellAddress.Y 'current row selected

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachTacGia.RowCount) Then
            Try
                Dim tacGia = New TacGia()

                '1. Mapping data from GUI control
                tacGia.MaTacGia = txtMaTacGia.Text
                tacGia.TenTacGia = txtTenTacGia.Text

                '2. Insert to DB
                Dim result As Result
                result = _tacGiaBus.UpdateById(tacGia, tacGia.MaTacGia)
                If (result.FlagResult = True) Then
                    ' Re-Load LoaiHocSinh list
                    LoadListTacGia()
                    ' Hightlight the row has been updated on table
                    dgvDanhSachTacGia.Rows(currentRowIndex).Selected = True
                    Try
                        tacGia = CType(dgvDanhSachTacGia.Rows(currentRowIndex).DataBoundItem, TacGia)
                        txtMaTacGia.Text = tacGia.MaTacGia
                        txtTenTacGia.Text = tacGia.TenTacGia
                    Catch ex As Exception
                        Console.WriteLine(ex.StackTrace)
                    End Try
                    MessageBox.Show("Cập nhật tác giả thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show(result.ApplicationMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    System.Console.WriteLine(result.SystemMessage)
                End If
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachTacGia.CurrentCellAddress.Y 'current row selected

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachTacGia.RowCount) Then
            Select Case MsgBox("Bạn có thực sự muốn xóa thể loại sách có mã: " + txtMaTacGia.Text, MsgBoxStyle.YesNo, "Information")
                Case MsgBoxResult.Yes
                    Try

                        '1. Delete from DB
                        Dim result As Result
                        result = _tacGiaBus.DeleteById(Convert.ToInt32(txtMaTacGia.Text))
                        If (result.FlagResult = True) Then

                            ' Re-Load LoaiHocSinh list
                            LoadListTacGia()

                            ' Hightlight the next row on table
                            If (currentRowIndex >= dgvDanhSachTacGia.Rows.Count) Then
                                currentRowIndex = currentRowIndex - 1
                            End If
                            If (currentRowIndex >= 0) Then
                                dgvDanhSachTacGia.Rows(currentRowIndex).Selected = True
                                Try
                                    Dim tacGia = CType(dgvDanhSachTacGia.Rows(currentRowIndex).DataBoundItem, TacGia)
                                    txtMaTacGia.Text = tacGia.MaTacGia
                                    txtTenTacGia.Text = tacGia.TenTacGia
                                Catch ex As Exception
                                    Console.WriteLine(ex.StackTrace)
                                End Try
                            End If
                            MessageBox.Show("Xóa thể loại sách thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Xóa thể loại sách không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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