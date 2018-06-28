Imports DAO
Imports DTO
Imports Utility

Public Class TheLoaiSachBUS
#Region "-   Fields   -"
    Private _theLoaiSachDAO As TheLoaiSachDAO
#End Region

#Region "-   Constructor   -"
    Public Sub New()
        _theLoaiSachDAO = New TheLoaiSachDAO()
    End Sub

#End Region

#Region "-    Insert,delete,update   -"

    Function UpdateById(theLoaiSach As TheLoaiSach, theLoaiSachID As String) As Result
        If String.IsNullOrWhiteSpace(theLoaiSachID) Then Return New Result(False, "Mã thể loại không hợp lệ!", "")
        Return _theLoaiSachDAO.UpdateById(theLoaiSach, theLoaiSachID)
    End Function

    Function DeleteById(theLoaiSachId As String) As Result
        If String.IsNullOrWhiteSpace(theLoaiSachId) Then Return New Result(False, "Mã thể loại không hợp lệ!", "")
        Return _theLoaiSachDAO.DeleteById(theLoaiSachId)
    End Function

    Function InsertOne(theLoaiSach As TheLoaiSach) As Result
        If Not theLoaiSach.Validate() Then Return New Result(False, "Thông tin input không hợp lệ!", "")
        Return _theLoaiSachDAO.InsertOne(theLoaiSach)
    End Function
#End Region

#Region "-   Retrieve data  -"

    Public Function SelectAll(ByRef listTheLoaiSach As List(Of TheLoaiSach)) As Result
        Dim result = _theLoaiSachDAO.SelectAll(listTheLoaiSach)
        If listTheLoaiSach.Count < 1 Then
            Return New Result(False, "Lấy danh sách thể loại sách không thành công!", "")
        End If
        Return result
    End Function

    Public Function SelectTheLoaiSachByID(ByRef theLoaiSach As TheLoaiSach, maTheLoaiSach As String) As Result
        Dim result = _theLoaiSachDAO.SelectTheLoaiSachByID(theLoaiSach, maTheLoaiSach)
        Return result
    End Function

    Public Function GetTenTheLoaiSachByID(ByRef tentheLoaiSach As String, maTheLoaiSach As String) As Result
        Dim result = _theLoaiSachDAO.GetTenTheLoaiSachByID(tentheLoaiSach, maTheLoaiSach)
        Return result
    End Function

    Public Function GetTheNextID(ByRef id As String) As Result
        id = String.Empty
        Dim result = _theLoaiSachDAO.GetTheLastId(id)
        id = If(String.IsNullOrWhiteSpace(id), 1, id + 1)
        Return result
    End Function
#End Region

End Class
