Imports DTO
Imports Utility

Public Class LoaiDocGiaDAO
    Private _dataProvider As DataProvider

    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub
    Function SelectAll() As List(Of LoaiDocGia)
        Dim data = New DataTable()
        Dim query = String.Empty
        query &= "Select * from LoaiDocGia"
        data = _dataProvider.ExcuteQuery(query)

        Dim listReaderType = New List(Of LoaiDocGia)
        For Each row In data.Rows
            Dim readertypeTemp = New LoaiDocGia()
            readertypeTemp.LoaiDocGiaId = Integer.Parse(row.ItemArray(0))
            readertypeTemp.TenLoaiDocGia = (row.ItemArray(1)).ToString()
            listReaderType.Add(readertypeTemp)
        Next
        Return listReaderType
    End Function
End Class
