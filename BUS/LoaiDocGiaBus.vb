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
        If listLoaiDocGia.Count < 1 Then
            Return New Result(False, "Danh sách loại độc giả hiện đang trống", "")
        End If
        Return result
    End Function
End Class
