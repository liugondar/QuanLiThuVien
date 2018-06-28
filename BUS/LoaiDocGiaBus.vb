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

    Function GetTheNextId(ByRef maLoaiDocGia As String) As Result
        maLoaiDocGia = String.Empty
        Dim result = _readerTypeDAO.GetTheLastId(maLoaiDocGia)
        maLoaiDocGia = If(String.IsNullOrWhiteSpace(maLoaiDocGia), 1, maLoaiDocGia + 1)
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

    Function InsertOne(loaiDocGia As LoaiDocGia) As Result
        If Not loaiDocGia.Validate() Then Return New Result(False, "Thông tin nhập vào không hợp lệ!", "")
        Return _readerTypeDAO.InsertOne(loaiDocGia)
    End Function
End Class
