﻿Imports Utility
Imports BUS
Imports DTO

Public Class frmBaoCaoTraSachTre
#Region "-   Fields   -"
    Private _baoCaoSachTraTreBus As BaoCaoSachTraTreBus
    Private _chiTietBaoCaoBus As ChiTietBaoCaoSachTraTreBus
    Private _listChiTietBaoCaoSachTraTre As List(Of ChiTietBaoCaoSachTraTre)
    Private _phieuMuonSachBus As PhieuMuonSachBus
    Private _chiTietPhieuMuonBus As ChiTietPhieuMuonSachBus
    Private _sachBus As SachBus
#End Region

#Region "-   Constructor   -"
    Private Sub frmBaoCaoTraSachTre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _baoCaoSachTraTreBus = New BaoCaoSachTraTreBus()
        _chiTietBaoCaoBus = New ChiTietBaoCaoSachTraTreBus()
        _listChiTietBaoCaoSachTraTre = New List(Of ChiTietBaoCaoSachTraTre)
        _phieuMuonSachBus = New PhieuMuonSachBus()
        _chiTietPhieuMuonBus = New ChiTietPhieuMuonSachBus()
        _sachBus = New SachBus()

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
        tiLeColumn.DataPropertyName = "SoNgayTraTre"
        tiLeColumn.Width = 200
        ChiTietBaoCaoDataGridView.Columns.Add(tiLeColumn)

    End Sub
    Private Sub BingdingListChiTietBaoCaoToDatagridviewSource()
        Dim listChiTietDisplay = New List(Of ChiTietBaoCaoSachTraTreDisplay)
        For Each chiTietBaoCaoSachTraTre In _listChiTietBaoCaoSachTraTre

            Dim chiTietPhieuMuon = New DTO.ChiTietPhieuMuonSach()
            _chiTietPhieuMuonBus.GetByID(chiTietPhieuMuon, chiTietBaoCaoSachTraTre.MaChiTietPhieuMuonSach)
            Dim sach = New Sach()
            _sachBus.SelectSachById(sach, chiTietPhieuMuon.MaSach)
            Dim phieuMuon = New PhieuMuonSach()
            _phieuMuonSachBus.GetPhieuMuonSachById(phieuMuon, chiTietPhieuMuon.MaChiTietPhieuMuonSach)

            Dim chiTietDisplay = New ChiTietBaoCaoSachTraTreDisplay()
            chiTietDisplay.SoNgayTraTre = chiTietBaoCaoSachTraTre.SoNgayTraTre
            chiTietDisplay.TenSach = sach.TenSach
            chiTietDisplay.NgayMuon = phieuMuon.NgayMuon
            listChiTietDisplay.Add(chiTietDisplay)
        Next

        ChiTietBaoCaoDataGridView.DataSource = New BindingSource(listChiTietDisplay, String.Empty)
    End Sub


#End Region

#Region "-   Events    -"
    Private Sub ConfirmMetroButton_Click(sender As Object, e As EventArgs) Handles ConfirmMetroButton.Click
        _listChiTietBaoCaoSachTraTre.Clear()
        Dim thoiGian = ThoiGianCanTimDateTimePicker.Value
        Dim result = _baoCaoSachTraTreBus.InsertByThoiGian(thoiGian)

        Dim maBaoCao = String.Empty
        _baoCaoSachTraTreBus.GetTheLastID(maBaoCao)
        _chiTietBaoCaoBus.SelectAllByMaBaoCaoSachTraTre(_listChiTietBaoCaoSachTraTre, maBaoCao)
        LoadChiTietBaoCaoGrid()
    End Sub
#End Region
#End Region
End Class