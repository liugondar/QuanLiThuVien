Imports DAO
Imports DTO

Public Class LoaiDocGiaBus
    Private _readerTypeDAO As LoaiDocGiaDAO

    Public Sub New()
        _readerTypeDAO = New LoaiDocGiaDAO()
    End Sub

    Public Function SelectAll() As List(Of LoaiDocGia)

        Dim data = New List(Of LoaiDocGia)
        data = _readerTypeDAO.SelectAll()
        Return data
    End Function
End Class
