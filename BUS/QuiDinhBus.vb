Imports DAO
Imports DTO
Imports Utility

Public Class QuiDinhBus
    Private _quiDinhDAO As QuiDinhDAO

    Public Sub New()
        _quiDinhDAO = New QuiDinhDAO()
    End Sub

    Public Function SelectAll(ByRef listQuiDinh As List(Of QuiDinh)) As Result
        Dim result = _quiDinhDAO.SelectAll(listQuiDinh)
        If listQuiDinh.Count < 1 Then
            Return New Result(False, "Danh sách các qui định hiện đang trống", "")
        End If
        Return result
    End Function
End Class
