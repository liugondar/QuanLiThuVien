Imports DTO
Imports Utility

Public Class LoaiDocGiaDAO
    Private _dataProvider As DataProvider

    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub

    Function SelectAll(ByRef listLoaiDocGia As List(Of LoaiDocGia)) As Result
        Dim data = New DataTable()
        Dim query = String.Empty
        query &= "Select * from LoaiDocGia "
        query &= " Where DeleteFlag='N'" & " "
        Dim result = _dataProvider.ExcuteQuery(query, data)

        For Each row In data.Rows
            Dim readertypeTemp = New LoaiDocGia()
            readertypeTemp.MaLoaiDocGia = Integer.Parse(row("MaLoaiDocGia"))
            readertypeTemp.TenLoaiDocGia = (row("TenLoaiDocGia")).ToString()
            listLoaiDocGia.Add(readertypeTemp)
        Next
        Return New Result()
    End Function

    Function GetTheLastId(ByRef maLoaiDocGia As String) As Result
        Dim data = New DataTable()
        Dim query = String.Format("select top 1 [maLoaiDocGia]
from LoaiDocGia
order by MaLoaiDocGia desc")
        Dim result = _dataProvider.ExcuteQuery(query, data)

        For Each row In data.Rows
            maLoaiDocGia = row("maLoaiDocGia").ToString()
        Next
        Return New Result()
    End Function

    Function UpdateById(loaiDocgia As LoaiDocGia, loaiDocGiaId As String) As Result
        Dim query = String.Format("
update LoaiDocGia
set TenLoaiDocGia='{0}'
where MaLoaiDocGia={1} and DeleteFlag='N'", loaiDocgia.TenLoaiDocGia, loaiDocGiaId)
        Return _dataProvider.ExcuteNonquery(query)
    End Function

    Function DeleteById(loaiDocGiaId As String) As Result
        Dim query = String.Format("
update LoaiDocGia
set DeleteFlag='Y'
where MaLoaiDocGia={0}", loaiDocGiaId)
        Return _dataProvider.ExcuteNonquery(query)
    End Function

    Function InsertOne(loaiDocGia As LoaiDocGia) As Result
        Dim query = String.Format("
INSERT into dbo.LoaiDocGia(TenLoaiDocGia)
VALUES('{0}')", loaiDocGia.TenLoaiDocGia)
        Return _dataProvider.ExcuteNonquery(query)
    End Function
End Class
