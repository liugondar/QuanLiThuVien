Imports Excel = Microsoft.Office.Interop.Excel
Imports Utility
Imports ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat
Imports System.Windows.Forms

Public NotInheritable Class ExportExcel
    Private Shared ReadOnly _instance As New Lazy(Of ExportExcel)(Function() New ExportExcel(), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication)

    Private Sub New()
    End Sub

    Public Shared ReadOnly Property Instance() As ExportExcel
        Get
            Return _instance.Value
        End Get
    End Property

    Public Function Export(title As String, data As System.Data.DataTable, Optional ByVal chartRangeInput As String = "d")
        Try
            Dim xlApp As Excel.Application = New Microsoft.Office.Interop.Excel.Application()
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            Dim chartRange As Excel.Range
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            ' english
            'xlWorkSheet = xlWorkBook.Sheets("sheet1")
            xlWorkSheet = CType(xlWorkBook.Sheets(1), Excel.Worksheet)
            xlWorkSheet.Range("a2", "f2").Merge()
            xlWorkSheet.Cells(2, 1) = title
            xlWorkSheet.Cells(2, 1).VerticalAlignment = Excel.Constants.xlCenter
            xlWorkSheet.Cells(2, 1).HorizontalAlignment = Excel.Constants.xlCenter
            xlWorkSheet.Cells(2, 1).Font.Size = 18
            xlWorkSheet.Cells(2, 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue)
            xlWorkSheet.Cells(2, 1).Font.Bold = True
            Dim dc As DataColumn
            Dim dr As DataRow
            Dim colIndex As Integer = 1
            Dim rowIndex As Integer = 3
            Dim stt As Integer = 0
            '// tên tiêu đề table
            xlWorkSheet.Cells(4, 1) = "STT"
            For Each dc In data.Columns
                colIndex = colIndex + 1
                xlWorkSheet.Cells(4, colIndex) = dc.ColumnName
            Next
            'export the rows 
            For Each dr In data.Rows
                stt = stt + 1
                rowIndex = rowIndex + 1
                colIndex = 1
                For Each dc In data.Columns
                    colIndex = colIndex + 1
                    xlWorkSheet.Cells(rowIndex + 1, 1) = "'" & stt & "."
                    xlWorkSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                Next
            Next

            Dim maxRow = data.Rows.Count

            xlWorkSheet.Range("a1", "z200").RowHeight = 20
            xlWorkSheet.Cells(4, 1).VerticalAlignment = Excel.Constants.xlCenter
            xlWorkSheet.Cells(4, 1).HorizontalAlignment = Excel.Constants.xlCenter
            xlWorkSheet.Range("a5", "a200").HorizontalAlignment = Excel.Constants.xlCenter
            xlWorkSheet.Range("a5", "a200").Font.Bold = True
            chartRange = xlWorkSheet.Range("a4", chartRangeInput & "4")
            chartRange.EntireColumn.AutoFit()
            chartRange.Font.Bold = True
            chartRange.RowHeight = 25
            chartRange.Font.Size = 14
            xlWorkSheet.Range("a1", "z20").VerticalAlignment = Excel.Constants.xlCenter
            xlWorkSheet.Range("a1", "z1").HorizontalAlignment = Excel.Constants.xlCenter
            chartRange.HorizontalAlignment = Excel.Constants.xlCenter
            chartRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
            chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
            xlWorkSheet.Range("c4", "c149").Font.Bold = True
            xlWorkSheet.Range("a4", chartRangeInput & maxRow + 4).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            xlWorkSheet.Range("a4", chartRangeInput & maxRow + 4).Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Orange)
            xlWorkSheet.Range("a4", chartRangeInput & maxRow + 4).Borders.Weight = 2D
            xlWorkSheet.Cells.EntireColumn.AutoFit()
            xlApp.ActiveWindow.DisplayGridlines = False
            xlApp.ActiveWindow.DisplayFormulas = False
            xlApp.ActiveWindow.DisplayHeadings = False

            xlWorkBook.Close(True, misValue, misValue)
            xlApp.Quit()
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
        Catch ex As Exception
            Strings.Instance.LogErr(ex.Message)
            MessageBox.Show("Please check if your computer got excel!")
        End Try
    End Function


    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

End Class
