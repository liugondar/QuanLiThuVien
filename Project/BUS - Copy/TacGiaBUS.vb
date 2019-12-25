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

#Region "-    Insert,delete,update   -"

    Function UpdateById(tacGia As TacGia, id As String) As Result
        If String.IsNullOrWhiteSpace(id) Then Return New Result(False, "Mã thể loại không hợp lệ!", "")
        Return _tacGiaDAO.UpdateById(tacGia, id)
    End Function

    Function DeleteById(id As String) As Result
        If String.IsNullOrWhiteSpace(id) Then Return New Result(False, "Mã thể loại không hợp lệ!", "")
        Return _tacGiaDAO.DeleteById(id)
    End Function

    Function InsertOne(tacGia As TacGia) As Result
        If Not tacGia.ValidateTenTacGia() Then Return New Result(False, "Thông tin input không hợp lệ!", "")
        Return _tacGiaDAO.InsertOne(tacGia)
    End Function
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

    Public Function GetTheNextID(ByRef id As String) As Result
        id = String.Empty
        Dim result = _tacGiaDAO.GetTheLastId(id)
        id = If(String.IsNullOrWhiteSpace(id), 1, id + 1)
        Return result
    End Function
#End Region
End Class
