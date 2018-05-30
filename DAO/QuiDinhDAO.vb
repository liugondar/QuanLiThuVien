Imports DTO
Imports Utility


Public Class QuiDinhDAO
    Private _dataProvider As DataProvider
    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub
    Public Function SelectAll(ByRef listQuiDinh As List(Of QuiDinh)) As Result
        Dim query = String.Empty
        query &= "Select * from QuiDinh"
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            Dim quiDinh = New QuiDinh(row)
            listQuiDinh.Add(quiDinh)
        Next

        Return Result
    End Function
End Class
