Imports BUS
Imports DTO
Imports Utility
Public Class frmNhapThemSach
#Region "-   Fields    -"
    Private _sachBus As SachBus
    Private _dausachBus As DauSachBus
    Private _theLoaiBus As TheLoaiSachBUS
#End Region
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitData()
    End Sub

    Private Sub InitData()
        _sachBus = New SachBus()
        _dausachBus = New DauSachBus()
        _theLoaiBus = New TheLoaiSachBUS()
    End Sub

    Private Sub txtId_TextChanged(sender As Object, e As EventArgs) Handles txtId.TextChanged
        GetDataBaseOnId()
    End Sub

    Private Sub GetDataBaseOnId()
        Try
            Dim ds = New DauSachDTO()
            Dim result = _dausachBus.GetById(ds, txtId.Text)
            If result.FlagResult Then
                result = _theLoaiBus.GetTenTheLoaiSachByID(txtTheLoai.Text, ds.MaTheLoaiSach)
                If result.FlagResult Then
                    txtTitleBook.Text = ds.TenSach
                    nudSoLuong.Value = ds.SoLuong
                End If
            Else
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CreateButton_Click(sender As Object, e As EventArgs) Handles CreateButton.Click
        Dim rs = AddMoreBooks()
        If rs.FlagResult Then
            MessageBox.Show(Strings.Instance.GetSuccessMessage())
        End If
    End Sub

    Private Sub CreateAndCloseButton_Click(sender As Object, e As EventArgs) Handles CreateAndCloseButton.Click
        Dim rs = AddMoreBooks()

        If rs.FlagResult Then
            Me.Close()
        End If
    End Sub

    Private Function AddMoreBooks() As Result
        Try
            Dim rs = _dausachBus.ThemSachMoiVaoDauSach(txtId.Text, nudSoLuong.Value, dtpkNgayNhap.Value)
            Return rs
        Catch ex As Exception
            Strings.Instance.LogErr(ex.Message)
            Return New Result(False, ex.Message, ex.Message)
        End Try
        Return New Result(False, "Thao tác thất bại", "Unknown error")
    End Function

End Class