Imports DTO
Imports Utility

Public Class SachDAO

#Region "-   Fields   -"
    Private _dataProvider As DataProvider
    Private formatDate As String
#End Region

#Region "-   Constructors   -"
    Public Sub New()
        _dataProvider = New DataProvider()
        formatDate = DateHelper.Instance.GetFormatType()
    End Sub

    Public Function InsertOne(cuonsach As Sach) As Result
        Dim query = String.Empty
        query &= "EXECUTE USP_NhapCuonSach "
        query &= "@MaSach = N'" & cuonsach.MaSach & "',"
        query &= "@MaDauSach= N'" & cuonsach.MaDauSach & "',"
        query &= "@TinhTrang = 0"


        Dim result = _dataProvider.ExecuteNonquery(query)

        Return result
    End Function

    Public Function GetTheLastID(maCuonSach As Object) As Result
        Dim query As String = String.Empty
        query &= "select top 1 [MaSach] "
        query &= "from DauSach "
        query &= "ORDER BY [MaSach] DESC "
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            maCuonSach = row("MaSach")
        Next
        Return result
    End Function
#End Region
End Class