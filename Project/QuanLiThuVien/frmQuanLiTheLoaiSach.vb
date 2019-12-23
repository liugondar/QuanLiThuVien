Imports BUS
Imports DTO
Imports Utility

Public Class frmQuanLiTheLoaiSach
    Private theloaiSachBUS As TheLoaiSachBUS
    Private loginAccount As Account

#Region "-   Constructor   -"
    Public Sub New(loginAccount As Account)
        Me.loginAccount = loginAccount
        InitializeComponent()
        'nếu là nhân viên bình thường không cho phép can thiệp sửa xoá db
        If loginAccount.Type = 0 Then
            btnCapNhap.Visible = False
            btnXoa.Visible = False
        End If
    End Sub
    Private Sub frmQuanLiTheLoaiSach_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        theloaiSachBUS = New TheLoaiSachBUS()

        If Not LoadListTheLoaiSach().FlagResult Then MessageBox.Show("Lấy danh sách thể loại độc giả không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

    End Sub

    'get data theloaisach from db and display in datagridview
    Private Function LoadListTheLoaiSach() As Result
        Try
            ClearDataGridViewData()

            CreateDataGridViewColumn()
            'Load the loai sach list
            Dim listTheLoaiSach = New List(Of TheLoaiSach)
            Dim result = theloaiSachBUS.SelectAll(listTheLoaiSach)
            If (result.FlagResult = False) Then Return result

            dgvDanhSachTheLoaiSach.DataSource = listTheLoaiSach
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        Return New Result()
    End Function

    Private Sub CreateDataGridViewColumn()
        Dim clMaLoai = New DataGridViewTextBoxColumn()
        clMaLoai.Name = "MaTheLoaiSach"
        clMaLoai.HeaderText = "Mã Loại"
        clMaLoai.DataPropertyName = "MaTheLoaiSach"
        dgvDanhSachTheLoaiSach.Columns.Add(clMaLoai)

        Dim clTenTheLoaiSach = New DataGridViewTextBoxColumn()
        clTenTheLoaiSach.Name = "TenTheLoaiSach"
        clTenTheLoaiSach.HeaderText = "Tên Loại"
        clTenTheLoaiSach.DataPropertyName = "TenTheLoaiSach"
        clTenTheLoaiSach.Width = 200

        dgvDanhSachTheLoaiSach.Columns.Add(clTenTheLoaiSach)
    End Sub

    Private Sub ClearDataGridViewData()
        dgvDanhSachTheLoaiSach.Columns.Clear()
        dgvDanhSachTheLoaiSach.DataSource = Nothing

        dgvDanhSachTheLoaiSach.AutoGenerateColumns = False
        dgvDanhSachTheLoaiSach.AllowUserToAddRows = False
    End Sub
#End Region

#Region "-   Events   -"
    Private Sub dgvDanhSachTheLoaiSach_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDanhSachTheLoaiSach.SelectionChanged
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachTheLoaiSach.CurrentCellAddress.Y 'current row selected

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachTheLoaiSach.RowCount) Then
            Try
                Dim theLoaiSach = CType(dgvDanhSachTheLoaiSach.Rows(currentRowIndex).DataBoundItem, TheLoaiSach)
                txtMaTheLoaiSach.Text = theLoaiSach.MaTheLoaiSach
                txtTenTheLoaiSach.Text = theLoaiSach.TenTheLoaiSach
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub btnCapNhap_Click(sender As Object, e As EventArgs) Handles btnCapNhap.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvDanhSachTheLoaiSach.CurrentCellAddress.Y 'current row selected

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachTheLoaiSach.RowCount) Then
            Try
                Dim theLoaiSach As TheLoaiSach
                theLoaiSach = New TheLoaiSach()

                '1. Mapping data from GUI control
                theLoaiSach.MaTheLoaiSach = txtMaTheLoaiSach.Text
                theLoaiSach.TenTheLoaiSach = txtTenTheLoaiSach.Text

                '2. Insert to DB
                Dim result As Result
                result = theloaiSachBUS.UpdateById(theLoaiSach, theLoaiSach.MaTheLoaiSach)
                If (result.FlagResult = True) Then
                    ' Re-Load LoaiHocSinh list
                    LoadListTheLoaiSach()
                    ' Hightlight the row has been updated on table
                    dgvDanhSachTheLoaiSach.Rows(currentRowIndex).Selected = True
                    Try
                        theLoaiSach = CType(dgvDanhSachTheLoaiSach.Rows(currentRowIndex).DataBoundItem, TheLoaiSach)
                        txtMaTheLoaiSach.Text = theLoaiSach.MaTheLoaiSach
                        txtTenTheLoaiSach.Text = theLoaiSach.MaTheLoaiSach
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
        Dim currentRowIndex As Integer = dgvDanhSachTheLoaiSach.CurrentCellAddress.Y 'current row selected

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvDanhSachTheLoaiSach.RowCount) Then
            Select Case MsgBox("Bạn có thực sự muốn xóa thể loại sách có mã: " + txtMaTheLoaiSach.Text, MsgBoxStyle.YesNo, "Information")
                Case MsgBoxResult.Yes
                    Try

                        '1. Delete from DB
                        Dim result As Result
                        result = theloaiSachBUS.DeleteById(Convert.ToInt32(txtMaTheLoaiSach.Text))
                        If (result.FlagResult = True) Then

                            ' Re-Load LoaiHocSinh list
                            LoadListTheLoaiSach()

                            ' Hightlight the next row on table
                            If (currentRowIndex >= dgvDanhSachTheLoaiSach.Rows.Count) Then
                                currentRowIndex = currentRowIndex - 1
                            End If
                            If (currentRowIndex >= 0) Then
                                dgvDanhSachTheLoaiSach.Rows(currentRowIndex).Selected = True
                                Try
                                    Dim theLoaiSach = CType(dgvDanhSachTheLoaiSach.Rows(currentRowIndex).DataBoundItem, TheLoaiSach)
                                    txtMaTheLoaiSach.Text = theLoaiSach.MaTheLoaiSach
                                    txtTenTheLoaiSach.Text = theLoaiSach.TenTheLoaiSach
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