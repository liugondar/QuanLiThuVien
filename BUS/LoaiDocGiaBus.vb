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
End Class
