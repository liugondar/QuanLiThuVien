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
#End Region
End Class
