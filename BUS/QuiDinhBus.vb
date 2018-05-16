Imports DAO

Public Class QuiDinhBus
    Private _quiDinhDAO As QuiDinhDAO

    Public Sub New()
        _quiDinhDAO = New QuiDinhDAO()
    End Sub

    Public Function SelectAll() As DataTable

        Dim data = New DataTable()
        data = _quiDinhDAO.SelectAll()
        Return data
    End Function
End Class
