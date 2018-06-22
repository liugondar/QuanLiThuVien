Imports DTO
Imports Utility

Public Class TheLoaiSachDAO
    Private _dataProvider As DataProvider

    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub
    Public Function SelectAll(ByRef listTheLoaiSach As List(Of TheLoaiSach)) As Result
        Dim query = String.Empty
        query &= "Select * from dbo.TheLoaiSach"
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row As DataRow In dataTable.Rows
            Dim theLoaiSach = New TheLoaiSach(row)
            listTheLoaiSach.Add(theLoaiSach)
        Next
        Return result
    End Function

    Public Function SelectTheLoaiSachByMaTheLoaiSach(ByRef theLoaiSach As TheLoaiSach, maTheLoaiSach As String) As Result
        Dim query = String.Empty
        query &= "Select * from dbo.TheLoaiSach where MaTheLoaiSach=" & maTheLoaiSach
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row As DataRow In dataTable.Rows
            theLoaiSach = New TheLoaiSach(row)
        Next
        Return result
    End Function
End Class
