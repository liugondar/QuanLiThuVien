Imports Utility
Imports BUS
Imports DTO
Imports Excel = Microsoft.Office.Interop.Excel
Imports ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat


Public Class frmBaoCaoTraSachTre
#Region "-   Fields   -"
    Private _baoCaoSachTraTreBus As BaoCaoSachTraTreBus
    Private _chiTietBaoCaoBus As ChiTietBaoCaoSachTraTreBus
    Private _listChiTietBaoCaoSachTraTre As List(Of ChiTietBaoCaoSachTraTre)
    Private _phieuMuonSachBus As PhieuMuonSachBus
    Private _chiTietPhieuMuonBus As ChiTietPhieuMuonSachBus
    Private _sachBus As SachBus
    Dim directory As String = My.Application.Info.DirectoryPath
    Private _listbaocao As List(Of BaoCaoTraTreByMonth)

#End Region

#Region "-   Constructor   -"
    Private Sub frmBaoCaoTraSachTre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _baoCaoSachTraTreBus = New BaoCaoSachTraTreBus()
        _chiTietBaoCaoBus = New ChiTietBaoCaoSachTraTreBus()
        _listChiTietBaoCaoSachTraTre = New List(Of ChiTietBaoCaoSachTraTre)
        _phieuMuonSachBus = New PhieuMuonSachBus()
        _chiTietPhieuMuonBus = New ChiTietPhieuMuonSachBus()
        _sachBus = New SachBus()
        _listbaocao = New List(Of BaoCaoTraTreByMonth)

        ThoiGianCanTimDateTimePicker.Format = DateTimePickerFormat.Custom
        ThoiGianCanTimDateTimePicker.CustomFormat = "MM/yyyy"

        LoadChiTietBaoCaoGrid()
    End Sub

#Region "-   Load chi tiet bao cao   -"
    Private Sub LoadChiTietBaoCaoGrid()
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
        Dim phieuMuonIdClmn = New DataGridViewTextBoxColumn()
        phieuMuonIdClmn.Name = "MaPhieuMuonSach"
        phieuMuonIdClmn.HeaderText = "Mã phiếu mượn"
        phieuMuonIdClmn.DataPropertyName = "MaPhieuMuonSach"
        phieuMuonIdClmn.Width = 50
        ChiTietBaoCaoDataGridView.Columns.Add(phieuMuonIdClmn)

        Dim MaTheDocGia = New DataGridViewTextBoxColumn()
        MaTheDocGia.Name = "MaTheDocGia"
        MaTheDocGia.HeaderText = "MaTheDocGia"
        MaTheDocGia.DataPropertyName = "MaTheDocGia"
        MaTheDocGia.Width = 50
        ChiTietBaoCaoDataGridView.Columns.Add(MaTheDocGia)


        Dim TenDocGia = New DataGridViewTextBoxColumn()
        TenDocGia.Name = "TenDocGia"
        TenDocGia.HeaderText = "TenDocGia"
        TenDocGia.DataPropertyName = "TenDocGia"
        TenDocGia.Width = 50
        ChiTietBaoCaoDataGridView.Columns.Add(TenDocGia)


        Dim NgayMuon = New DataGridViewTextBoxColumn()
        NgayMuon.Name = "NgayMuon"
        NgayMuon.HeaderText = "Ngày mượn"
        NgayMuon.DataPropertyName = "NgayMuon"
        NgayMuon.Width = 50
        ChiTietBaoCaoDataGridView.Columns.Add(NgayMuon)

        Dim NgayTra = New DataGridViewTextBoxColumn()
        NgayTra.Name = "NgayTra"
        NgayTra.HeaderText = "NgayTra"
        NgayTra.DataPropertyName = "NgayTra"
        NgayTra.Width = 50
        ChiTietBaoCaoDataGridView.Columns.Add(NgayTra)


    End Sub
    Private Sub BingdingListChiTietBaoCaoToDatagridviewSource()
        ChiTietBaoCaoDataGridView.DataSource = New BindingSource(_listbaocao, String.Empty)

    End Sub


#End Region

#Region "-   Events    -"
    Private Sub ConfirmMetroButton_Click(sender As Object, e As EventArgs) Handles ConfirmMetroButton.Click
        _listChiTietBaoCaoSachTraTre.Clear()
        _listbaocao.Clear()
        Dim thoiGian = ThoiGianCanTimDateTimePicker.Value
        Dim rs = _baoCaoSachTraTreBus.GetTinhHinhTraTreByMonth(thoiGian, _listbaocao)
        LoadChiTietBaoCaoGrid()
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ExportExcel.Instance.Export("Báo cáo trả sách trễ tại " & ThoiGianCanTimDateTimePicker.Value.ToString("MM,yyyy"), LayDulieu())
    End Sub

    Private Function LayDulieu() As DataTable
        Dim dt As DataTable = New DataTable()

        For Each col As DataGridViewColumn In ChiTietBaoCaoDataGridView.Columns
            dt.Columns.Add(col.Name)
        Next

        For Each row As DataGridViewRow In ChiTietBaoCaoDataGridView.Rows
            Dim dRow As DataRow = dt.NewRow()

            For Each cell As DataGridViewCell In row.Cells
                dRow(cell.ColumnIndex) = cell.Value
            Next

            dt.Rows.Add(dRow)
        Next


        Return dt
    End Function
#End Region
#End Region
End Class