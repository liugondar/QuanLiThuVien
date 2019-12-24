Imports QLTVDTO
Imports QLTVBus
Imports Utility
Imports System.Drawing
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

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
End Class
