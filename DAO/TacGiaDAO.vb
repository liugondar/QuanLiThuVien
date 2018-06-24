﻿Imports DTO
Imports Utility

Public Class TacGiaDAO

#Region "-   Fields   -"
    Private _dataProvider As DataProvider
#End Region

#Region "-   Constructor   -"
    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub

#End Region

#Region "-   Retrieve data    -"

    Public Function SelectAll(ByRef listTacGia As List(Of TacGia)) As Result
        Dim query = String.Empty
        query &= "Select * from dbo.TacGia"
        query &= " Where DeleteFlag='N'" & " "

        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row As DataRow In dataTable.Rows
            Dim tacGia = New TacGia(row)
            listTacGia.Add(tacGia)
        Next
        Return result
    End Function

    Public Function SelectTacGiaByMaTacGia(ByRef tacGia As TacGia, maTacGia As String) As Result
        Dim query = String.Empty
        query &= "Select * from dbo.TacGia where MaTacGia=" & maTacGia
        query &= " and DeleteFlag='N'" & " "
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row As DataRow In dataTable.Rows
            tacGia = New TacGia(row)
        Next
        Return result
    End Function

    Public Function GetTenTacGiaByMaTacGia(ByRef tenTacGia As String, maTacGia As String) As Object
        Dim query = String.Empty
        query &= "Select * from dbo.TacGia where MaTacGia=" & maTacGia
        query &= " and DeleteFlag='N'" & " "
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row As DataRow In dataTable.Rows
            tenTacGia = row("TenTacGia").ToString()
        Next
        Return result
    End Function

#End Region

End Class
