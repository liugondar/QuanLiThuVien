Imports Utility


Public Class QuiDinhDAO
    Private _dataProvider As DataProvider
    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub
    Public Function SelectAll() As DataTable
        Dim data = New DataTable()
        Dim query = String.Empty
        query &= "Select * from QuiDinh"
        data = _dataProvider.ExcuteQuery(query)
        Return data
    End Function
End Class
