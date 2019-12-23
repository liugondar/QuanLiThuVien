Imports DAO
Imports DTO
Imports Utility

Public Class SachBus
    Private _sachDAO As SachDAO
    Private _quiDinh As QuiDinh
    Private _danhSachTacGia As List(Of TacGia)
    Private _danhSachTheLoaiSach As List(Of TheLoaiSach)
    Private _ketQuaLayQuiDinh As Result
    Public Sub New()
        _sachDAO = New SachDAO()
        _danhSachTacGia = New List(Of TacGia)
        _danhSachTheLoaiSach = New List(Of TheLoaiSach)

    End Sub

    Public Function InsertOne(cuonsach As Sach)
        Dim getNextIDResult = GetNextId(cuonsach.MaSach)
        Dim validateResult = Validate(cuonsach)
        If validateResult.FlagResult = False Then Return validateResult
        Return _sachDAO.InsertOne(cuonsach)
    End Function

    Private Function GetNextId(ByRef maCuonSach) As Result
        Dim result = _sachDAO.GetTheLastID(maCuonSach)
        maCuonSach = If(String.IsNullOrWhiteSpace(maCuonSach), 1, maCuonSach + 1)
        Return result
    End Function

    Private Function Validate(dausach As Object) As Result
        Return New Result()
    End Function
End Class
