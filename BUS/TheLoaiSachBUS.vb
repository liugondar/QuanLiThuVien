Imports DAO
Imports DTO
Imports Utility

Public Class TheLoaiSachBUS
    Private _theLoaiSachDAO As TheLoaiSachDAO

    Public Sub New()
        _theLoaiSachDAO = New TheLoaiSachDAO()
    End Sub
    Public Function SelectAll(ByRef listTheLoaiSach As List(Of TheLoaiSach)) As Result
        Dim result = _theLoaiSachDAO.SelectAll(listTheLoaiSach)
        If listTheLoaiSach.Count < 1 Then
            Return New Result(False, "Lấy danh sách thể loại sách không thành công!", "")
        End If
        Return result
    End Function
End Class
