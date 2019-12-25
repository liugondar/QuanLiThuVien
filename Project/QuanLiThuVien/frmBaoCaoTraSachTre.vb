<<<<<<< HEAD
﻿Imports QLTVDTO
Imports QLTVBus
Imports Utility
Imports System.Drawing
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
=======
﻿Imports Utility
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
>>>>>>> loc-dev

Public Class ucBaoCaoSachTre
    Dim tsBus As New ThamSoBUS
    Dim sachBus As New DauSachBUS
    Dim thoigian As New DateTime
    Dim result As New Result

    Private Sub btnThongKe_Click(sender As Object, e As EventArgs) Handles btnThongKe.Click
        dgThongKe.Rows.Clear()

        Dim thamso As New ThamSoDTO
        result = tsBus.selectALL(thamso)

        If result.FlagResult = False Then
            MessageBox.Show("Lỗi truy xuất dữ liệu. Lập thống kê thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            dtpNgay.Focus()
            Return
        End If

        Dim listten As New List(Of String)
        Dim listngay As New List(Of DateTime)
        thoigian = New DateTime(dtpNgay.Value.Year, dtpNgay.Value.Month, dtpNgay.Value.Day)

        If thoigian > Today Or thoigian.Year < 2000 Then
            MessageBox.Show("Thời gian không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'result = DauSachBUS.selectSachTre(thoigian, thamso.HanMuonSach, listten, listngay)

        If result.FlagResult = False Then
            MessageBox.Show("Lỗi truy xuất dữ liệu. Lập thống kê thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            dtpNgay.Focus()
            Return
        End If

        showresult(listten, listngay)

    End Sub

    Private Sub showresult(listten As List(Of String), listngay As List(Of DateTime))

        If (listten.Count = 0) Then
            MessageBox.Show("Không có sách trả trễ vào ngày " + thoigian.Day.ToString() + "/" + thoigian.Month.ToString() + "/" + thoigian.Year.ToString() + ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        For i As Integer = 0 To listten.Count - 1
            Dim s As String()
            Dim thoigiantre = (thoigian - listngay.ElementAt(i)).TotalDays
            Console.WriteLine(thoigiantre)
            s = New String() {listten.ElementAt(i), listngay.ElementAt(i), thoigiantre.ToString()}
            dgThongKe.Rows.Add(s)
        Next
    End Sub

    Private Sub dgThongKe_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgThongKe.RowPostPaint
        Using b As SolidBrush = New SolidBrush(dgThongKe.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString((e.RowIndex + 1).ToString(), dgThongKe.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 12, e.RowBounds.Location.Y + 1)
        End Using
    End Sub

    Private Sub btnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
        Dim parent As ucBaoCaoSachTre
        parent = sender.Parent
        Dim grandpar = New ucBaoCao
        grandpar = parent.Parent
        Dim grgrpar = New FlowLayoutPanel
        grgrpar = grandpar.Parent
        grgrpar.Controls.Clear()
        Dim grgrgrpar = New frmHome
        grgrgrpar = grgrpar.Parent
        grgrgrpar.btnNguoiDung.selected = False
        Dim ucBaoCao As New ucBaoCao
        grgrpar.Controls.Add(ucBaoCao)
    End Sub

    Private Sub ucBaoCaoSachTre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.ForeColor = Color.FromArgb(89, 94, 241)
        dtpNgay.Value = Today
    End Sub

    Private Sub btnXuatBaoCao_Click(sender As Object, e As EventArgs) Handles btnXuatBaoCao.Click
        Try
            Dim path As String = "\baocaosachtre.pdf"
            Dim myFont As String = "C:\Windows\Fonts\Calibri.ttf"

            ' open folder browser
            Using fbd As New FolderBrowserDialog()
                Dim rs As New DialogResult()
                rs = fbd.ShowDialog

                If rs = DialogResult.OK And Not String.IsNullOrWhiteSpace(fbd.SelectedPath) Then
                    path = fbd.SelectedPath.ToString() + path
                Else
                    Return
                End If
            End Using


            ' dinh dang file
            Dim doc As Document = New iTextSharp.text.Document(PageSize.LETTER, 30, 30, 50, 50)
            Dim wrtr As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(path, FileMode.Create))

            ' mo file
            doc.Open()
            doc.NewPage()

            ' font chu, mau sac
            Dim bfR As BaseFont = BaseFont.CreateFont(myFont, BaseFont.IDENTITY_H, BaseFont.EMBEDDED)
            Dim clrBlack As BaseColor = New BaseColor(0, 0, 0)

            Dim fntTitle As iTextSharp.text.Font = New iTextSharp.text.Font(bfR, 16, iTextSharp.text.Font.BOLD, clrBlack)
            Dim fntHead As iTextSharp.text.Font = New iTextSharp.text.Font(bfR, 12, iTextSharp.text.Font.BOLD, clrBlack)
            Dim fntHead2 As iTextSharp.text.Font = New iTextSharp.text.Font(bfR, 12, iTextSharp.text.Font.ITALIC, clrBlack)
            Dim fntNormal As iTextSharp.text.Font = New iTextSharp.text.Font(bfR, 12, iTextSharp.text.Font.NORMAL, clrBlack)

            ' title
            Dim title As New Paragraph(New Chunk("BÁO CÁO THỐNG KÊ SÁCH TRẢ TRỄ", fntTitle))
            title.Alignment = Element.ALIGN_CENTER
            title.SpacingAfter = 50.0F
            doc.Add(title)

            ' thong so
            Dim s As String = "Ngày: " + dtpNgay.Value.Date.ToString() + "/" + dtpNgay.Value.Month.ToString() + "/" + dtpNgay.Value.Year.ToString()

            Dim thongso As New Paragraph(s, fntHead2)
            thongso.Alignment = Element.ALIGN_CENTER
            thongso.SpacingAfter = 20.0F

            doc.Add(thongso)


            ' datagrid
            '' width
            Dim ketqua As New Paragraph("Kết quả thống kê: ", fntHead)
            ketqua.SpacingBefore = 20.0F
            ketqua.SpacingAfter = 20.0F
            doc.Add(ketqua)

<<<<<<< HEAD
            Dim pdftable As New PdfPTable(dgThongKe.Columns.Count)
            pdftable.TotalWidth = 400.0F
            pdftable.LockedWidth = True

            '' set width for columns
            Dim widths(0 To dgThongKe.Columns.Count - 1) As Single
            For i As Integer = 0 To dgThongKe.Columns.Count - 1
                widths(i) = 1.0F * (dgThongKe.Columns(i).Width / 600.0F)
            Next

            pdftable.SetWidths(widths)
            pdftable.HorizontalAlignment = 0

            '''''

            ' header on datagrid
            Dim pdfcell As PdfPCell = New PdfPCell
            For i As Integer = 0 To dgThongKe.Columns.Count - 1
                pdfcell = New PdfPCell(New Phrase(New Chunk(dgThongKe.Columns(i).HeaderText, fntHead2)))
                pdfcell.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                pdftable.AddCell(pdfcell)
            Next


            ''''
            ' rows on datagrid
            For i As Integer = 0 To dgThongKe.Rows.Count - 1
                For j As Integer = 0 To dgThongKe.Columns.Count - 1
                    pdfcell = New PdfPCell(New Phrase(dgThongKe(j, i).Value.ToString(), fntNormal))
                    pdftable.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                    pdftable.AddCell(pdfcell)
                Next
            Next

            ''''
            doc.Add(pdftable)

            ' close
            doc.Close()

            MessageBox.Show("Xuất kết quả báo cáo thành công!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return

        Catch ex As Exception
            MessageBox.Show("Xuất kết quả báo cáo thất bại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try
    End Sub

     Private Sub frmBaoCaoTinhHinhMuonSachTheoTheLoai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _baoCaoTinhHinhMuonSachTheoTheLoaiBus = New BaoCaoTinhHinhMuonSachTheoTheLoaiBus()
        _chiTietBaoCaoBus = New ChiTietBaoCaoTinhHinhMuonSachTheoTheLoaiBUS()

        _listChiTietBaoCao = New List(Of ChiTietBaoCaoTinhHinhMuonSachTheoTheLoai)
=======
#Region "-   Constructor   -"
    Private Sub frmBaoCaoTraSachTre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _baoCaoSachTraTreBus = New BaoCaoSachTraTreBus()
        _chiTietBaoCaoBus = New ChiTietBaoCaoSachTraTreBus()
        _listChiTietBaoCaoSachTraTre = New List(Of ChiTietBaoCaoSachTraTre)
        _phieuMuonSachBus = New PhieuMuonSachBus()
        _chiTietPhieuMuonBus = New ChiTietPhieuMuonSachBus()
        _sachBus = New SachBus()
        _listbaocao = New List(Of BaoCaoTraTreByMonth)
>>>>>>> loc-dev

        ThoiGianCanTimDateTimePicker.Format = DateTimePickerFormat.Custom
        ThoiGianCanTimDateTimePicker.CustomFormat = "MM/yyyy"
        LoadChiTietBaoCaoGridViewAndTongLuotMuonLabel()
    End Sub

#Region "-   Load chi tiet bao cao grid view   -"
    Private Sub LoadChiTietBaoCaoGridViewAndTongLuotMuonLabel()
        ClearSourceBeforeBinding()

        CreateTitleColumn()

        BindingSourceChiTietBaoCaoGridViewAndTongSoLuotMuonLabel()
    End Sub

    Private Sub BindingSourceChiTietBaoCaoGridViewAndTongSoLuotMuonLabel()
        Dim listChiTietBaoCaoDisplay = New List(Of ChiTietBaoCaoTheoTheLoaiDisplay)
        Dim theLoaiSachBus = New TheLoaiSachBUS()
        Dim tongSoLuotMuon = 0
        For Each chiTietBaoCao In _listChiTietBaoCao
            Dim tenTheLoaiSach = String.Empty
            theLoaiSachBus.GetTenTheLoaiSachByID(tenTheLoaiSach, chiTietBaoCao.MaTheLoaiSach)

            Dim chiTietBaoCaoDisplay = New ChiTietBaoCaoTheoTheLoaiDisplay()
            chiTietBaoCaoDisplay.TenTheLoaiSach = tenTheLoaiSach
            chiTietBaoCaoDisplay.SoLuongMuon = chiTietBaoCao.SoLuongMuon
            chiTietBaoCaoDisplay.TiLe = (chiTietBaoCao.TiLe * 100).ToString() + "%"

            listChiTietBaoCaoDisplay.Add(chiTietBaoCaoDisplay)

            tongSoLuotMuon += chiTietBaoCao.SoLuongMuon
        Next
        ChiTietBaoCaoDataGridView.DataSource = New BindingSource(listChiTietBaoCaoDisplay, String.Empty)
        TongLuotMuonLabel.Text = "Tổng số lượt mượn: " & tongSoLuotMuon
    End Sub

    Private Sub ClearSourceBeforeBinding()
        ChiTietBaoCaoDataGridView.Columns.Clear()
        ChiTietBaoCaoDataGridView.DataSource = Nothing
        ChiTietBaoCaoDataGridView.AutoGenerateColumns = False
        ChiTietBaoCaoDataGridView.AllowUserToAddRows = False
    End Sub

    Private Sub CreateTitleColumn()
<<<<<<< HEAD
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
=======
        Dim phieuMuonIdClmn = New DataGridViewTextBoxColumn()
        phieuMuonIdClmn.Name = "MaPhieuMuonSach"
        phieuMuonIdClmn.HeaderText = "Mã phiếu mượn"
        phieuMuonIdClmn.DataPropertyName = "MaPhieuMuonSach"
        phieuMuonIdClmn.Width = 50
        ChiTietBaoCaoDataGridView.Columns.Add(phieuMuonIdClmn)

        Dim MaTheDocGia = New DataGridViewTextBoxColumn()
        MaTheDocGia.Name = "MaTheDocGia"
        MaTheDocGia.HeaderText = "Mã thẻ độc giả"
        MaTheDocGia.DataPropertyName = "MaTheDocGia"
        MaTheDocGia.Width = 150
        ChiTietBaoCaoDataGridView.Columns.Add(MaTheDocGia)


        Dim TenDocGia = New DataGridViewTextBoxColumn()
        TenDocGia.Name = "TenDocGia"
        TenDocGia.HeaderText = "Tên độc giả"
        TenDocGia.DataPropertyName = "TenDocGia"
        TenDocGia.Width = 150
        ChiTietBaoCaoDataGridView.Columns.Add(TenDocGia)


        Dim NgayMuon = New DataGridViewTextBoxColumn()
        NgayMuon.Name = "NgayMuon"
        NgayMuon.HeaderText = "Ngày mượn"
        NgayMuon.DataPropertyName = "NgayMuon"
        NgayMuon.Width = 150
        ChiTietBaoCaoDataGridView.Columns.Add(NgayMuon)

        Dim NgayTra = New DataGridViewTextBoxColumn()
        NgayTra.Name = "NgayTra"
        NgayTra.HeaderText = "Ngày trả"
        NgayTra.DataPropertyName = "NgayTra"
        NgayTra.Width = 150
        ChiTietBaoCaoDataGridView.Columns.Add(NgayTra)


        Dim NgayTraTre = New DataGridViewTextBoxColumn()
        NgayTraTre.Name = "NgayTraTre"
        NgayTraTre.HeaderText = "Ngày trả trễ"
        NgayTraTre.DataPropertyName = "NgayTraTre"
        NgayTraTre.Width = 100
        ChiTietBaoCaoDataGridView.Columns.Add(NgayTraTre)

        Dim MaSach = New DataGridViewTextBoxColumn()
        MaSach.Name = "MaSach"
        MaSach.HeaderText = "Mã sách"
        MaSach.DataPropertyName = "MaSach"
        MaSach.Width = 50
        ChiTietBaoCaoDataGridView.Columns.Add(MaSach)

        Dim MaDauSach = New DataGridViewTextBoxColumn()
        MaDauSach.Name = "MaDauSach"
        MaDauSach.HeaderText = "Mã đầu sách"
        MaDauSach.DataPropertyName = "MaDauSach"
        MaDauSach.Width = 100
        ChiTietBaoCaoDataGridView.Columns.Add(MaDauSach)

        Dim TenSach = New DataGridViewTextBoxColumn()
        TenSach.Name = "TenSach"
        TenSach.HeaderText = "Tên Sách"
        TenSach.DataPropertyName = "TenSach"
        TenSach.Width = 150
        ChiTietBaoCaoDataGridView.Columns.Add(TenSach)


    End Sub
    Private Sub BingdingListChiTietBaoCaoToDatagridviewSource()
        ChiTietBaoCaoDataGridView.DataSource = New BindingSource(_listbaocao, String.Empty)
>>>>>>> loc-dev

#Region "-   ConfirmButtonClick   -"
    Private Sub ConfirmMetroButton_Click(sender As Object, e As EventArgs) Handles ConfirmMetroButton.Click
        InsertBaoCao()
        LoadDataListChiTietBaoCao()
    End Sub

<<<<<<< HEAD
    Private Sub InsertBaoCao()
        Dim thoiGian = ThoiGianCanTimDateTimePicker.Value
        _baoCaoTinhHinhMuonSachTheoTheLoaiBus.InsertByThoiGian(thoiGian)
    End Sub
    Private Sub LoadDataListChiTietBaoCao()
        Dim maBaoCao = 0
        _baoCaoTinhHinhMuonSachTheoTheLoaiBus.GetTheLastID(maBaoCao)
        _listChiTietBaoCao.Clear()
        _chiTietBaoCaoBus.SelectAllByMaBaoCaoTinhHinhMuonSachTheoTheLoai(_listChiTietBaoCao, maBaoCao)
        LoadChiTietBaoCaoGridViewAndTongLuotMuonLabel()
=======

#End Region

#Region "-   Events    -"
    Private Sub ConfirmMetroButton_Click(sender As Object, e As EventArgs) Handles ConfirmMetroButton.Click
        _listChiTietBaoCaoSachTraTre.Clear()
        _listbaocao.Clear()
        Dim thoiGian = ThoiGianCanTimDateTimePicker.Value
        Dim rs = _baoCaoSachTraTreBus.GetTinhHinhTraTreByMonth(thoiGian, _listbaocao)
        LoadChiTietBaoCaoGrid()
>>>>>>> loc-dev
    End Sub

    Private Sub ExportButton_Click(sender As Object, e As EventArgs) Handles ExportButton.Click
        ExportExcel.Instance.Export("Báo cáo trả sách theo thể loại " & ThoiGianCanTimDateTimePicker.Value.ToString("MM,yyyy"), LayDulieu())
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
End Class
