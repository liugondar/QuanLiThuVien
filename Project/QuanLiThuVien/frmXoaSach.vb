Imports BUS
Imports DTO
Imports Utility
Public Class frmXoaSach
    Private _sachBus As SachBus
    Private _tacGiaBus As TacGiaBUS
    Private _dauSachBus As DauSachBus
    Private Sub frmXoaSach_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _sachBus = New SachBus()
        _dauSachBus = New DauSachBus()
        _tacGiaBus = New TacGiaBUS()
    End Sub

    Private Sub txtSachId_TextChanged(sender As Object, e As EventArgs) Handles txtSachId.TextChanged
        Try
            Dim sach = New Sach()
            Dim rs = _sachBus.SelectById(txtSachId.Text, sach)
            Strings.Instance.LogMess(sach.MaDauSach)
            If rs.FlagResult Then
                Dim dauSach = New DauSachDTO()
                rs = _dauSachBus.SelectAllByMaCuonSach(dauSach, txtSachId.Text)
                If rs.FlagResult Then
                    txtDauSachId.Text = dauSach.MaDauSach
                    txtTitleBook.Text = dauSach.TenSach
                    txtTheLoai.Text = dauSach.MaTheLoaiSach
                    txtNgayNhap.Text = sach.NgayNhap.ToString(DateHelper.Instance.GetFormatType())
                    Dim tacGia = New TacGia()
                    _tacGiaBus.SelectTacGiaByMaTacGia(tacGia, dauSach.MaTacGia)
                    txtAuthor.Text = tacGia.TenTacGia
                End If
            End If
        Catch ex As Exception
            Strings.Instance.LogErr(ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnTraHet.Click
        Dim rs = DeleteBook()
        MessageBox.Show(rs.ApplicationMessage)
        ResetAllField()
    End Sub

    Private Sub ResetAllField()
        txtSachId.Text = String.Empty
        txtDauSachId.Text = String.Empty
        txtNgayNhap.Text = String.Empty
        txtAuthor.Text = String.Empty
        txtTheLoai.Text = String.Empty
        txtTitleBook.Text = String.Empty
    End Sub

    Private Function DeleteBook() As Result
        Try
            Dim sach = New Sach()
            Dim rs = _sachBus.DeleteById(txtSachId.Text, txtDauSachId.Text)
            rs.ApplicationMessage = Strings.Instance.GetSuccessMessage()
            Return rs
        Catch ex As Exception
            Strings.Instance.LogErr(ex.Message)
            'Return New Result(False, Strings.Instance.GetErrMessage(), ex.Message)
            Return New Result(False, ex.Message, ex.Message)
        End Try
        Return New Result()
    End Function

    Private Sub btnDeletethenClose(sender As Object, e As EventArgs) Handles btnPayOne.Click
        Dim rs = DeleteBook()
        If rs.FlagResult Then
            Me.Close()
        Else
            MessageBox.Show(rs.ApplicationMessage)
        End If
    End Sub
End Class