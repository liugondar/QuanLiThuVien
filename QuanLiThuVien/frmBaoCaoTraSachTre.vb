Public Class frmBaoCaoTraSachTre
#Region "-   Fields   -"

#End Region

#Region "-   Constructor   -"
    Private Sub frmBaoCaoTraSachTre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ThoiGianCanTimDateTimePicker.Format = DateTimePickerFormat.Custom
        ThoiGianCanTimDateTimePicker.CustomFormat = "MM/yyyy"

        LoadChiTietBaoCaoGridViewAndTongLuotMuonLabel()
    End Sub

#Region "-   Load chi tiet bao cao   -"
    Private Sub LoadChiTietBaoCaoGridViewAndTongLuotMuonLabel()
        ClearSourceBeforeBinding()

        CreateTitleColumn()

        BingdingListChiTietBaoCaoToDatagridviewSource()
    End Sub


    Private Sub ClearSourceBeforeBinding()
        ChiTietBaoCaoDataGridView.Columns.Clear()
        ChiTietBaoCaoDataGridView.DataSource = Nothing
        ChiTietBaoCaoDataGridView.AutoGenerateColumns = False
        ChiTietBaoCaoDataGridView.AllowUserToAddRows = False
    End Sub

    Private Sub CreateTitleColumn()
        Dim tenTheLoaiColumn = New DataGridViewTextBoxColumn()
        tenTheLoaiColumn.Name = "TenSach"
        tenTheLoaiColumn.HeaderText = "Tên sách"
        tenTheLoaiColumn.DataPropertyName = "TenSach"
        tenTheLoaiColumn.Width = 300
        ChiTietBaoCaoDataGridView.Columns.Add(tenTheLoaiColumn)

        Dim soLuotMuonColumn = New DataGridViewTextBoxColumn()
        soLuotMuonColumn.Name = "NgayMuon"
        soLuotMuonColumn.HeaderText = "Ngày mượn"
        soLuotMuonColumn.DataPropertyName = "NgayMuon"
        soLuotMuonColumn.Width = 200
        ChiTietBaoCaoDataGridView.Columns.Add(soLuotMuonColumn)

        Dim tiLeColumn = New DataGridViewTextBoxColumn()
        tiLeColumn.Name = "SoNgayTraTre"
        tiLeColumn.HeaderText = "Số ngày trả trễ"
        tiLeColumn.DataPropertyName = "Số ngày trả trễ"
        tiLeColumn.Width = 200
        ChiTietBaoCaoDataGridView.Columns.Add(tiLeColumn)

    End Sub
    Private Sub BingdingListChiTietBaoCaoToDatagridviewSource()
    End Sub
#End Region
#End Region
End Class