Imports DAO
Imports DTO
Imports Utility

Public Class QuiDinhBus
    Private _quiDinhDAO As QuiDinhDAO

    Public Sub New()
        _quiDinhDAO = New QuiDinhDAO()
    End Sub

    Public Function SelectAll(ByRef quiDinh As QuiDinh) As Result
        Dim result = _quiDinhDAO.SelectAll(quiDinh)
        Return result
    End Function
End Class
