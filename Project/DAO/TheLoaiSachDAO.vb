Imports DTO
Imports Utility
Public Class TacGiaDAO
#Region "-   Fields   -"
    Private _dataProvider As DataProvider
#End Region
#Region "-   Constructor   -"
    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub
#End Region
#Region "-   Retrieve data    -"
    Public Function SelectAll(ByRef listTacGia As List(Of TacGia)) As Result
        Dim query = String.Empty
        query &= "Select * from dbo.TacGia"
        query &= " Where DeleteFlag='N'" & " "
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row As DataRow In dataTable.Rows
            Dim tacGia = New TacGia(row)
            listTacGia.Add(tacGia)
        Next
        Return result
    End Function
    Public Function SelectTacGiaByTenTacGia(ByRef listTacGia As List(Of TacGia)) As Result
        Dim query = String.Empty
        query &= "Select * from dbo.TacGia"
        query &= " Where DeleteFlag='N'" & " "
Dim query = String.Format("select top 1 [MaTacGia]
from TacGia
order by MaTacGia desc")
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row As DataRow In dataTable.Rows
            Dim tacGia = New TacGia(row)
            listTacGia.Add(tacGia)
        Next
        Return result
    End Function
  Public Sub New()
        _dataProvider = New DataProvider()
    End Sub
    Public Function SelectTacGiaByMaTacGia(ByRef tacGia As TacGia, maTacGia As String) As Result
        Dim query = String.Empty
        query &= "Select * from dbo.TacGia where MaTacGia=" & maTacGia
        query &= " and DeleteFlag='N'" & " "
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row As DataRow In dataTable.Rows
            tacGia = New TacGia(row)
        Next
        Return result
    End Function
    Public Function GetTenTacGiaByMaTacGia(ByRef tenTacGia As String, maTacGia As String) As Object
        Dim query = String.Empty
        query &= "Select * from dbo.TacGia where MaTacGia=" & maTacGia
        query &= " and DeleteFlag='N'" & " "
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row As DataRow In dataTable.Rows
            tenTacGia = row("TenTacGia").ToString()
        Next
        Return result
    End Function
    Function GetTheLastId(ByRef maTacGia As String) As Result
        Dim data = New DataTable()
        Dim query = String.Format("select top 1 [MaTacGia]
from TacGia
order by MaTacGia desc")
        Dim result = _dataProvider.ExecuteQuery(query, data)
        For Each row In data.Rows
            maTacGia = row("MaTacGia").ToString()
        Next
        Return New Result()
    End Function
#End Region
#Region "-    Insert,delete,update   -"
    Function UpdateById(tacGia As TacGia, tacGiaId As String) As Result
        Dim query = String.Format("
update TacGia
set TenTacGia='{0}'
where MaTacGia={1} and DeleteFlag='N'", tacGia.TenTacGia, tacGiaId)
        Return _dataProvider.ExecuteNonquery(query)
    End Function
    Function DeleteById(tacGiaId As String) As Result
        Dim query = String.Format("
update TacGia
set DeleteFlag='Y'
where MaTacGia={0}", tacGiaId)
        Return _dataProvider.ExecuteNonquery(query)
    End Function
    Function InsertOne(tacGia As TacGia) As Result
        Dim query = String.Format("
INSERT into dbo.TacGia(TenTacGia)
VALUES('{0}')", tacGia.TenTacGia)
        Return _dataProvider.ExecuteNonquery(query)
    End Function
#End Region
End Class


