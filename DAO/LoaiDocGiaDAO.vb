Imports DTO
Imports Utility

Public Class LoaiDocGiaDAO
    Private _dataProvider As DataProvider

    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub
    Function SelectAll(listLoaiDocGia As List(Of LoaiDocGia)) As Result
        Dim data = New DataTable()
        Dim query = String.Empty
        query &= "Select * from LoaiDocGia"
        Dim result = _dataProvider.ExcuteQuery(query, data)

        For Each row In data.Rows
            Dim readertypeTemp = New LoaiDocGia()
            readertypeTemp.MaLoaiDocGia = Integer.Parse(row("MaLoaiDocGia"))
            readertypeTemp.TenLoaiDocGia = (row("TenLoaiDocGia")).ToString()
            listLoaiDocGia.Add(readertypeTemp)
        Next
        Return New Result()
    End Function
End Class
