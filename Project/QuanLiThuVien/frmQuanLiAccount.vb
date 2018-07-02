Imports BUS
Imports DTO
Imports Utility

Public Class frmQuanLiAccount
    Private _listLoaiTK As List(Of LoaiTaiKhoan)
#Region "-   Constructor  -"
    Private Sub frmQuanLiAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _listLoaiTK = New List(Of LoaiTaiKhoan)
        LoadDefaultCB()
        LoadDataGridView()
    End Sub

    Private Sub LoadDefaultCB()
        Dim loaiTaiKhoanNhanVien = New LoaiTaiKhoan()
        loaiTaiKhoanNhanVien.MaLoaiTaiKhoan = 0
        loaiTaiKhoanNhanVien.TenLoaiTaiKhoan = "Nhân viên"
        _listLoaiTK.Add(loaiTaiKhoanNhanVien)

        Dim loaitkAdmin = New LoaiTaiKhoan()
        loaitkAdmin.MaLoaiTaiKhoan = 1
        loaitkAdmin.TenLoaiTaiKhoan = "Quản lí"
        _listLoaiTK.Add(loaitkAdmin)

        cbDefaultType.DataSource = New BindingSource(_listLoaiTK, String.Empty)
        cbDefaultType.ValueMember = "MaLoaiTaiKhoan"
        cbDefaultType.DisplayMember = "TenLoaiTaiKhoan"
        cbDefaultType.SelectedIndex = 0

        cbUpdateType.DataSource = New BindingSource(_listLoaiTK, String.Empty)
        cbUpdateType.ValueMember = "MaLoaiTaiKhoan"
        cbUpdateType.DisplayMember = "TenLoaiTaiKhoan"
        cbUpdateType.SelectedIndex = 0
    End Sub
#End Region

#Region "-   Events   -"
#Region "-   load dataGridview by default type   -"
    Private Sub cbDefaultType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDefaultType.SelectedIndexChanged
        LoadDataGridView()
    End Sub

    Private Sub LoadDataGridView()
        ClearDataGridViewSource()

        CreateDataGridViewColumn()

        Dim listAccount = New List(Of Account)
        Try
            Dim type = cbDefaultType.SelectedItem.MaLoaiTaiKhoan
            AccountBUS.Instance.SelectAllByType(listAccount, type)
            dgvListAccount.DataSource = New BindingSource(listAccount, String.Empty)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ClearDataGridViewSource()
        dgvListAccount.Columns.Clear()
        dgvListAccount.DataSource = Nothing
        dgvListAccount.AutoGenerateColumns = False
        dgvListAccount.AllowUserToAddRows = False
    End Sub

    Private Sub CreateDataGridViewColumn()
        Dim columnAccountID = New DataGridViewTextBoxColumn()
        columnAccountID.Name = "AccountId"
        columnAccountID.HeaderText = "ID"
        columnAccountID.DataPropertyName = "AccountId"
        dgvListAccount.Columns.Add(columnAccountID)

        Dim columnUsrName = New DataGridViewTextBoxColumn()
        columnUsrName.Name = "UserName"
        columnUsrName.HeaderText = "Tên tài khoản"
        columnUsrName.DataPropertyName = "UserName"
        dgvListAccount.Columns.Add(columnUsrName)

        Dim columnDisplayName = New DataGridViewTextBoxColumn()
        columnDisplayName.Name = "DisplayName"
        columnDisplayName.HeaderText = "Tên hiển thị"
        columnDisplayName.DataPropertyName = "DisplayName"
        columnDisplayName.Width = 150
        dgvListAccount.Columns.Add(columnDisplayName)
    End Sub
#End Region

#Region "-  Load info selected datagridview row   -"
    Private Sub DataGridViewQuanLiTheDocGia_SelectionChanged(sender As Object, e As EventArgs) Handles dgvListAccount.SelectionChanged
        LoadInfoSelectedRow()
    End Sub

    Private Function LoadInfoSelectedRow() As Result
        Try
            Dim account = New Account()
            Dim result = GetSelectedAccount(account)
            If result.FlagResult = False Then
                txtDisplayName.Text = String.Empty
                txtUserName.Text = String.Empty
                Return result
            End If
            txtDisplayName.Text = account.DisplayName
            txtUserName.Text = account.UserName
            Return result

        Catch ex As Exception

        End Try
    End Function
    Private Function GetSelectedAccount(ByRef account As Account) As Result
        Dim currentRowIndex As Integer = dgvListAccount.CurrentCellAddress.Y
        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvListAccount.RowCount) Then
            Try
                account = CType(dgvListAccount.Rows(currentRowIndex).DataBoundItem, Account)
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
                Return New Result(False, "Không lấy được thông tin độc giả đã chọn", "")
            End Try
        Else
            Return New Result(False, "Không lấy được thông tin độc giả đã chọn", "")
        End If

        Return New Result()
    End Function

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If MessageBox.Show("Bạn có chắc thay đổi thông tin?", "Thông Báo", MessageBoxButtons.OKCancel) = System.Windows.Forms.DialogResult.OK Then
            Try
                Dim account = New Account()
                account.UserName = txtUserName.Text
                account.Type = cbUpdateType.SelectedItem.MaLoaiTaiKhoan
                Dim result = AccountBUS.Instance.UpdateAccountTypeByUserName(account)
                If result.FlagResult Then
                    MessageBox.Show("Sửa thành công", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadDataGridView()
                Else
                    MessageBox.Show("Sửa không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MessageBox.Show("Bạn có muốn xoá tài khoản " & txtUserName.Text, "Thông Báo", MessageBoxButtons.OKCancel) = System.Windows.Forms.DialogResult.OK Then
            Try
                Dim result = AccountBUS.Instance.DeleteByUserName(txtUserName.Text)
                If result.FlagResult Then
                    MessageBox.Show("Xoá thành công", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadDataGridView()
                Else
                    MessageBox.Show("Xoá không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub


#End Region
#End Region
End Class