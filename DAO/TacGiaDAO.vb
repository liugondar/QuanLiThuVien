Imports DTO
Imports Utility

Public Class TacGiaDAO
    Private _dataProvider As DataProvider

    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub
    Public Function SelectAll(ByRef listTacGia As List(Of TacGia)) As Result
        Dim query = String.Empty
        query &= "Select * from dbo.TacGia"
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row As DataRow In dataTable.Rows
            Dim tacGia = New TacGia(row)
            listTacGia.Add(tacGia)
        Next
        Return result
    End Function
End Class
