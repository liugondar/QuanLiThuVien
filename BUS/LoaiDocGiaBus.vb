Imports DAO
Imports DTO
Imports Utility

Public Class LoaiDocGiaBus
    Private _readerTypeDAO As LoaiDocGiaDAO

    Public Sub New()
        _readerTypeDAO = New LoaiDocGiaDAO()
    End Sub

    Public Function SelectAll(ByRef listLoaiDocGia As List(Of LoaiDocGia)) As Result
        Dim result = _readerTypeDAO.SelectAll(listLoaiDocGia)
        Return result
    End Function

    Function UpdateById(loaiDocgia As LoaiDocGia, loaiDocGiaId As String) As Result
        If String.IsNullOrWhiteSpace(loaiDocGiaId) Then Return New Result(False, "Mã loại độc giả trống!", "")
        Return _readerTypeDAO.UpdateById(loaiDocgia, loaiDocGiaId)
    End Function

    Function DeleteById(loaiDocGiaId As String) As Result
        If String.IsNullOrWhiteSpace(loaiDocGiaId) Then Return New Result(False, "Mã loại độc giả trống!", "")
        Return _readerTypeDAO.DeleteById(loaiDocGiaId)
    End Function
End Class
