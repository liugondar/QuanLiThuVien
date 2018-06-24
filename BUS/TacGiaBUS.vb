Imports DAO
Imports DTO
Imports Utility

Public Class TacGiaBUS
#Region "-   Fields   -"

    Private _tacGiaDAO As TacGiaDAO
#End Region

#Region "-   Constructor  -"

    Public Sub New()
        _tacGiaDAO = New TacGiaDAO()
    End Sub

#End Region
#Region "-   Retrieve data  -"

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
    Public Function GetTenTacGiaByMaTacGia(ByRef tenTacGia As String, maTacGia As String) As Result
        Dim result = _tacGiaDAO.GetTenTacGiaByMaTacGia(tenTacGia, maTacGia)
        Return result
    End Function

#End Region
End Class
