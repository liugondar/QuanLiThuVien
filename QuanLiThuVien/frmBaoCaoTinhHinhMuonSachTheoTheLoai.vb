Imports BUS
Imports DTO
Imports Utility

Public Class frmBaoCaoTinhHinhMuonSachTheoTheLoai : Inherits MetroFramework.Forms.MetroForm
#Region "-   Fields   -"
    Private _baoCaoTinhHinhMuonSachTheoTheLoaiBus As BaoCaoTinhHinhMuonSachTheoTheLoaiBus
    Private _chiTietBaoCaoBus As ChiTietBaoCaoTinhHinhMuonSachTheoTheLoaiBUS
    Private _listChiTietBaoCao As List(Of ChiTietBaoCaoTinhHinhMuonSachTheoTheLoai)
#End Region

#Region "-   Constructor   -"
    Private Sub frmBaoCaoTinhHinhMuonSachTheoTheLoai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _baoCaoTinhHinhMuonSachTheoTheLoaiBus = New BaoCaoTinhHinhMuonSachTheoTheLoaiBus()
        _chiTietBaoCaoBus = New ChiTietBaoCaoTinhHinhMuonSachTheoTheLoaiBUS()

        _listChiTietBaoCao = New List(Of ChiTietBaoCaoTinhHinhMuonSachTheoTheLoai)

        LoadChiTietBaoCaoGridView()
    End Sub

#Region "-   Load chi tiet bao cao grid view   -"
    Private Sub LoadChiTietBaoCaoGridView()
        ClearSourceBeforeBinding()

        CreateTitleColumn()


        BindingSourceChiTietBaoCaoGridView()
        ''TODO: load chi tiet bao cao
    End Sub

    Private Sub BindingSourceChiTietBaoCaoGridView()
        Dim listChiTietBaoCaoDisplay = New List(Of ChiTietBaoCaoDisplay)
        Dim theLoaiSachBus = New TheLoaiSachBUS()
        For Each chiTietBaoCao In _listChiTietBaoCao
            Dim tenTheLoaiSach = String.Empty
            theLoaiSachBus.GetTenTheLoaiSachByID(tenTheLoaiSach, chiTietBaoCao.MaTheLoaiSach)

            Dim chiTietBaoCaoDisplay = New ChiTietBaoCaoDisplay()
            chiTietBaoCaoDisplay.TenTheLoaiSach = tenTheLoaiSach
            chiTietBaoCaoDisplay.SoLuongMuon = chiTietBaoCao.SoLuongMuon
            chiTietBaoCaoDisplay.TiLe = chiTietBaoCao.TiLe

            listChiTietBaoCaoDisplay.Add(chiTietBaoCaoDisplay)
        Next
        ChiTietBaoCaoDataGridView.DataSource = New BindingSource(listChiTietBaoCaoDisplay, String.Empty)
    End Sub

    Private Sub ClearSourceBeforeBinding()
        ChiTietBaoCaoDataGridView.Columns.Clear()
        ChiTietBaoCaoDataGridView.DataSource = Nothing
        ChiTietBaoCaoDataGridView.AutoGenerateColumns = False
        ChiTietBaoCaoDataGridView.AllowUserToAddRows = False
    End Sub

    Private Sub CreateTitleColumn()
        Dim tenTheLoaiColumn = New DataGridViewTextBoxColumn()
        tenTheLoaiColumn.Name = "TenTheLoaiSach"
        tenTheLoaiColumn.HeaderText = "Tên thể loại"
        tenTheLoaiColumn.DataPropertyName = "TenTheLoaiSach"
        tenTheLoaiColumn.Width = 300
        ChiTietBaoCaoDataGridView.Columns.Add(tenTheLoaiColumn)

        Dim soLuotMuonColumn = New DataGridViewTextBoxColumn()
        soLuotMuonColumn.Name = "SoLuongMuon"
        soLuotMuonColumn.HeaderText = "Số lượt mượn"
        soLuotMuonColumn.DataPropertyName = "SoLuongMuon"
        soLuotMuonColumn.Width = 200
        ChiTietBaoCaoDataGridView.Columns.Add(soLuotMuonColumn)

        Dim tiLeColumn = New DataGridViewTextBoxColumn()
        tiLeColumn.Name = "TiLe"
        tiLeColumn.HeaderText = "Tỉ lệ"
        tiLeColumn.DataPropertyName = "TiLe"
        tiLeColumn.Width = 200
        ChiTietBaoCaoDataGridView.Columns.Add(tiLeColumn)

    End Sub
#End Region
#End Region

#Region "-   Events   -"

#Region "-   ConfirmButtonClick   -"
    Private Sub ConfirmMetroButton_Click(sender As Object, e As EventArgs) Handles ConfirmMetroButton.Click
        InsertBaoCao()
        LoadDataListChiTietBaoCao()
    End Sub

    Private Sub InsertBaoCao()
        Dim thoiGian = ThoiGianCanTimDateTimePicker.Value
        _baoCaoTinhHinhMuonSachTheoTheLoaiBus.InsertByThoiGian(thoiGian)
    End Sub
    Private Sub LoadDataListChiTietBaoCao()
        Dim maBaoCao = 0
        _baoCaoTinhHinhMuonSachTheoTheLoaiBus.GetTheLastID(maBaoCao)
        _listChiTietBaoCao.Clear()
        _chiTietBaoCaoBus.SelectAllByMaBaoCaoTinhHinhMuonSachTheoTheLoai(_listChiTietBaoCao, maBaoCao)
        LoadChiTietBaoCaoGridView()
    End Sub
#End Region

#End Region
End Class