Imports DAO
Imports DTO
Imports Utility

Public Class TacGiaBUS
    Private _tacGiaDAO As TacGiaDAO

    Public Sub New()
        _tacGiaDAO = New TacGiaDAO()
    End Sub
    Public Function SelectAll(ByRef listTacGia As List(Of TacGia)) As Result
        Dim result = _tacGiaDAO.SelectAll(listTacGia)
        If listTacGia.Count < 1 Then
            Return New Result(False, "Lấy danh sách tác giả không thành công!", "")
        End If
        Return result
    End Function

    Public Function SelectTacGiaByMaTacGia(ByRef tacGia As TacGia, maTacGia As String) As Result
        Dim result = _tacGiaDAO.SelectTacGiaByMaTacGia(tacGia, maTacGia)
        Return result
    End Function
    Public Function SelectTenTacGiaByMaTacGia(ByRef tenTacGia As String, maTacGia As String) As Result
        Dim result = _tacGiaDAO.SelectTenTacGiaByMaTacGia(tenTacGia, maTacGia)
        Return result
    End Function
End Class
