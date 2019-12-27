Imports BUS
Imports Utility
Imports DTO
Public Class frmTraSachTheoMaDocGia
    Private _docGiaBus As DocGiaBus
    Private _listSachDisplay As List(Of CustomBookInfoDisplay)
    Private _chiTietPhieuMuonSachBus As ChiTietPhieuMuonSachBus


    Private Sub frmTraSachTheoMaDocGia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _docGiaBus = New DocGiaBus()
        _chiTietPhieuMuonSachBus = New ChiTietPhieuMuonSachBus()
        _listSachDisplay = New List(Of CustomBookInfoDisplay)

        loadDocGiaIDCB()

    End Sub

    Private Sub loadDocGiaIDCB()
        Dim listDocGia = New List(Of DocGia)
        Try
            _docGiaBus.SelectAll(listDocGia)
            cbDocGiaId.DataSource = New BindingSource(listDocGia, String.Empty)
            cbDocGiaId.DisplayMember = "MaTheDocGia"
            cbDocGiaId.ValueMember = "MaTheDocGia"
            cbDocGiaId.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbDocGiaId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDocGiaId.SelectedIndexChanged
        Try
            _docGiaBus.GetReaderNameById(txtNameDg.Text, cbDocGiaId.SelectedValue)

            BindingBorrowBooksByDocgiaId(cbDocGiaId.SelectedValue)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub BindingBorrowBooksByDocgiaId(readerId As String)
        ClearBookBorrowedDataGridViewData()

        CreateListChiTietPMSDataGridViewTitleColumn()

        getGridData(readerId)

    End Sub

    Private Sub getGridData(readerId As String)
        Try
            TraSachTheoIdBus.Instance.GetInfoBookLentByReaderId(cbDocGiaId.SelectedValue, _listSachDisplay)

            dtgSachDangMuon.DataSource = New BindingSource(_listSachDisplay, String.Empty)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CreateListChiTietPMSDataGridViewTitleColumn()

        Dim mcsCln = New DataGridViewTextBoxColumn()
        mcsCln.Name = "MaCuonSach"
        mcsCln.HeaderText = "Mã cuốn sách"
        mcsCln.DataPropertyName = "MaCuonSach"
        mcsCln.Width = 50
        dtgSachDangMuon.Columns.Add(mcsCln)

        Dim tenSachColumn = New DataGridViewTextBoxColumn()
        tenSachColumn.Name = "TenSach"
        tenSachColumn.HeaderText = "Tên sách"
        tenSachColumn.DataPropertyName = "TenSach"
        tenSachColumn.Width = 200
        dtgSachDangMuon.Columns.Add(tenSachColumn)

        Dim tacGiaColumn = New DataGridViewTextBoxColumn()
        tacGiaColumn.Name = "TacGia"
        tacGiaColumn.HeaderText = "Tác giả "
        tacGiaColumn.DataPropertyName = "TacGia"
        tacGiaColumn.Width = 140
        dtgSachDangMuon.Columns.Add(tacGiaColumn)

        Dim tinhTrangColumn = New DataGridViewTextBoxColumn()
        tinhTrangColumn.Name = "NgayMuon"
        tinhTrangColumn.HeaderText = "Ngày mượn"
        tinhTrangColumn.DataPropertyName = "NgayMuon"
        tinhTrangColumn.Width = 100
        dtgSachDangMuon.Columns.Add(tinhTrangColumn)

        Dim ngayHetHanColumn = New DataGridViewTextBoxColumn()
        ngayHetHanColumn.Name = "NgayHetHan"
        ngayHetHanColumn.HeaderText = "Ngày hết hạn"
        ngayHetHanColumn.DataPropertyName = "NgayHetHan"
        ngayHetHanColumn.Width = 120
        dtgSachDangMuon.Columns.Add(ngayHetHanColumn)
    End Sub

    Private Sub ClearBookBorrowedDataGridViewData()
        dtgSachDangMuon.Columns.Clear()
        dtgSachDangMuon.DataSource = Nothing
        dtgSachDangMuon.AutoGenerateColumns = False
        dtgSachDangMuon.AllowUserToAddRows = False
        _listSachDisplay.Clear()
    End Sub

    Private Sub btnPayOne_Click(sender As Object, e As EventArgs) Handles btnPayOne.Click
        If dtgSachDangMuon.SelectedRows.Count = 0 Then
            MessageBox.Show("Vui lòng chọn sách cần trả!")
            Return
        End If



        Dim rsAll = True
        For Each row As DataGridViewRow In dtgSachDangMuon.SelectedRows
            Dim rs = _chiTietPhieuMuonSachBus.
                    ReturnBookByPhieuMuonSachIdAndBookId(cbDocGiaId.SelectedValue,
                                                         row.Cells("MaCuonSach").Value,
                                                         dtpkNgayTra.Value)
            If Not rs.FlagResult Then
                rsAll = False
            End If
        Next

        If rsAll Then
            MessageBox.Show("Trả sách thành công!")
        Else
            MessageBox.Show("Trả sách không thành công!")
        End If
        BindingBorrowBooksByDocgiaId(cbDocGiaId.SelectedValue)
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub txtNameDg_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles txtNameDg.MaskInputRejected

    End Sub
End Class