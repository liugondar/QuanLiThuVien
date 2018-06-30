Imports DTO
Imports Utility

Public Class TheLoaiSachDAO

#Region "-  Fields and constructor   -"
    Private _dataProvider As DataProvider

    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub

#End Region

#Region "-    Insert,delete,update   -"

    Function UpdateById(theLoaiSach As TheLoaiSach, theLoaiSachID As String) As Result
        Dim query = String.Format("
update TheLoaiSach
set TenTheLoaiSach='{0}'
where maTheLoaiSach={1} and DeleteFlag='N'", theLoaiSach.TenTheLoaiSach, theLoaiSachID)
        Return _dataProvider.ExcuteNonquery(query)
    End Function

    Function DeleteById(theLoaiSachId As String) As Result
        Dim query = String.Format("
update TheLoaiSach
set DeleteFlag='Y'
where maTheLoaiSach={0}", theLoaiSachId)
        Return _dataProvider.ExcuteNonquery(query)
    End Function

    Function InsertOne(theLoaiSach As TheLoaiSach) As Result
        Dim query = String.Format("
INSERT into dbo.TheLoaiSach(TenTheLoaiSach)
VALUES('{0}')", theLoaiSach.TenTheLoaiSach)
        Return _dataProvider.ExcuteNonquery(query)
    End Function
#End Region

#Region "-   Retrieve data    -"
    Public Function SelectAll(ByRef listTheLoaiSach As List(Of TheLoaiSach)) As Result
        Dim query = String.Empty
        query &= "Select * from dbo.TheLoaiSach"
        query &= " Where DeleteFlag='N'" & " "
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row As DataRow In dataTable.Rows
            Dim theLoaiSach = New TheLoaiSach(row)
            listTheLoaiSach.Add(theLoaiSach)
        Next
        Return result
    End Function

    Public Function SelectTheLoaiSachByID(ByRef theLoaiSach As TheLoaiSach, maTheLoaiSach As String) As Result
        Dim query = String.Empty
        query &= "Select * from dbo.TheLoaiSach where MaTheLoaiSach=" & maTheLoaiSach
        query &= " and DeleteFlag='N'" & " "
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row As DataRow In dataTable.Rows
            theLoaiSach = New TheLoaiSach(row)
        Next
        Return result
    End Function

    Public Function GetTenTheLoaiSachByID(ByRef tentheLoaiSach As String, maTheLoaiSach As String) As Object
        Dim query = String.Format("select [TenTheLoaiSach]
from TheLoaiSach 
where MaTheLoaiSach={0} and DeleteFlag='N'", maTheLoaiSach)
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row As DataRow In dataTable.Rows
            tentheLoaiSach = row("TenTheLoaiSach").ToString()
        Next
        Return result
    End Function

    Function GetTheLastId(ByRef maTheLoaiSAch As String) As Result
        Dim data = New DataTable()
        Dim query = String.Format("select top 1 [maTheLoaiSach]
from theloaisach
order by maTheLoaiSach desc")
        Dim result = _dataProvider.ExcuteQuery(query, data)

        For Each row In data.Rows
            maTheLoaiSAch = row("maTheLoaiSach").ToString()
        Next
        Return New Result()
    End Function
#End Region

End Class
