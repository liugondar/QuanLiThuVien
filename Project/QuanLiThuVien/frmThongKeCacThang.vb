Imports DTO
Imports BUS
Imports Utility
Public Class frmThongKeCacThang
    Private Property listTk As List(Of ThongKeSoLuotMuon)
    Private Sub frmThongKeCacThang_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        listTk = New List(Of DTO.ThongKeSoLuotMuon)
        Dim now = Date.Now
        Dim oldDate = New Date(now.Year, now.Month - 3, now.Day)
        dtpkFromDate.Value = oldDate
        dtpkToDate.Value = now
        CalcThongKe(oldDate, now)
    End Sub

    Private Sub CalcThongKe(fromDate As Date, toDate As Date)
        Try
            listTk.Clear()
            Dim diffResult As Integer = DateDiff(DateInterval.Month, fromDate, toDate)
            Strings.Instance.LogMess(diffResult)

            For i = 0 To diffResult
                Dim temp = fromDate.AddMonths(i)
                listTk.Add(New ThongKeSoLuotMuon(temp))
            Next
            ThongKeBus.Instance.CountBorowTimesByMonths(listTk)

            renderListThongKe(listTk)

        Catch ex As Exception
            Strings.Instance.LogErr(ex.Message)
        End Try
    End Sub

    Private Sub renderListThongKe(listTk As List(Of ThongKeSoLuotMuon))
        If (chartThang.Series.Count > 0) Then
            chartThang.Series.RemoveAt(0)
        End If

        chartThang.Series.Add("LentAmount")
        For Each tk In listTk
            chartThang.Series(0).Points.AddXY(tk.Month.ToString(DateHelper.Instance.GetFormatMonth()), tk.SoLuotMuon)
            If listTk.Count < 15 Then
                chartThang.Series(0).IsValueShownAsLabel = True
            End If
        Next
    End Sub

    Private Sub btnThongKe_Click(sender As Object, e As EventArgs) Handles btnThongKe.Click
        CalcThongKe(dtpkFromDate.Value, dtpkToDate.Value)
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim fm = DateHelper.Instance.GetFormatMonth()
        ExportExcel.Instance.Export("Từ " & dtpkFromDate.Value.ToString(fm) & " tới " & dtpkToDate.Value.ToString(fm), LayDulieu(), "c")
    End Sub

    Private Function LayDulieu() As DataTable
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("Month")
        dt.Columns.Add("SoLuotMuon")
        For Each item In listTk
            Dim row = dt.NewRow()
            row("Month") = item.Month.ToString(DateHelper.Instance.GetFormatMonth())
            row("SoLuotMuon") = item.SoLuotMuon
            dt.Rows.Add(row)
        Next
        Return dt
    End Function
End Class