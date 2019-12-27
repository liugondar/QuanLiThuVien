Imports System.Windows.Forms
Imports DAO
Imports DTO
Imports Utility

Public Class SachBus
    Private _sachDAO As SachDAO
    Private _dauSachDAO As DauSachDAO
    Private _quiDinh As QuiDinh
    Private _danhSachTacGia As List(Of TacGia)
    Private _danhSachTheLoaiSach As List(Of TheLoaiSach)
    Private _ketQuaLayQuiDinh As Result
    Public Sub New()
        _sachDAO = New SachDAO()
        _danhSachTacGia = New List(Of TacGia)
        _dauSachDAO = New DauSachDAO()
        _danhSachTheLoaiSach = New List(Of TheLoaiSach)

    End Sub

    Public Function InsertOne(cuonsach As Sach)
        Dim getNextIDResult = GetNextId(cuonsach.MaSach)
        Dim validateResult = Validate(cuonsach)
        If validateResult.FlagResult = False Then Return validateResult
        Return _sachDAO.InsertOne(cuonsach)
    End Function

    Public Function SelectById(txtSachId As String, ByRef sach As Sach) As Result
        Return _sachDAO.SelectById(txtSachId, sach)
    End Function

    Friend Function SetStatusSachToUnavailableByID(maSach As String) As Object
        Return _sachDAO.SetStatusSachToUnavailableByID(maSach)
    End Function

    Private Function GetNextId(ByRef maCuonSach) As Result
        Dim result = _sachDAO.GetTheLastID(maCuonSach)
        Strings.Instance.LogMess("ma " & maCuonSach)

        maCuonSach = If(String.IsNullOrWhiteSpace(maCuonSach), 1, maCuonSach + 1)

        Return result
    End Function

    Private Function Validate(dausach As Object) As Result
        Return New Result()
    End Function


    Public Function getQuanlity(maDauSach As String) As Integer
        Return _sachDAO.getQuanlity(maDauSach)
    End Function

    Public Function SelectByType(maCS As String, ByRef tenSach As String, ByRef theLoai As String, ByRef tacGia As String, ByRef soluongSachCon As Integer, ByRef listIdCuonSach As List(Of Integer)) As Result
        Return _sachDAO.SelectByType(maCS, tenSach, theLoai, tacGia, soluongSachCon, listIdCuonSach)
    End Function

    Public Function DeleteById(txtSachId As String, dauSachId As String) As Result
        Dim rs = _sachDAO.DeleteById(txtSachId)

        If rs.FlagResult Then
            Dim count = getQuanlity(dauSachId)
            count = If(count < 0, 0, count)
            _dauSachDAO.UpdateQuanlityBook(dauSachId, count - 1)
        End If
        Return rs
    End Function

    Public Function getAvailableQuanlity(maDauSach As String, ByRef slCon As Integer) As Result
        Return _sachDAO.getAvailableSachBaseOnDauSachId(maDauSach, slCon)
    End Function

    Public Function SelectAllCuonSachByMaSach(ByRef listSachDaMuon As List(Of Sach), maSach As String) As Result
        Return _sachDAO.SelectAllCuonSachByMaSach(listSachDaMuon, maSach)
    End Function

    Public Sub selectSachByType(maSach As String, ByRef tSach As String, ByRef tgia As String, ByRef maDauSach As String)
        _sachDAO.selectSachByType(maSach, tSach, tgia, maDauSach)
    End Sub

    Friend Sub SetStatusSachToAvailableByID(maSach As String)
        _sachDAO.SetStatusSachToAvailableByID(maSach)
    End Sub
End Class


