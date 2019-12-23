﻿Imports DTO
Imports Utility

Public Class SachDAO

#Region "-   Fields   -"
    Private _dataProvider As DataProvider
    Private formatDate As String
#End Region

#Region "-   Constructors   -"
    Public Sub New()
        _dataProvider = New DataProvider()
        formatDate = DateHelper.Instance.GetFormatType()
    End Sub
#End Region

#Region "-   insert   -"
    Public Function InsertOne(cuonsach As Sach) As Result
        Dim query = String.Empty
        query &= "EXECUTE USP_NhapCuonSach "
        query &= "@MaSach = N'" & cuonsach.MaSach & "',"
        query &= "@MaDauSach= N'" & cuonsach.MaDauSach & "',"
        query &= "@TinhTrang = 0"

        Dim result = _dataProvider.ExecuteNonquery(query)
        Return result
    End Function
#End Region

#Region "-   Update and delete  -"
    Public Function SetStatusSachToUnavailableByID(maSach As String) As Result
        Dim query = String.Format("
update Sach
set TinhTrang=1
where maSach={0}", maSach)
        Return _dataProvider.ExecuteNonquery(query)
    End Function

    Public Function SetStatusSachToAvailableByID(maSach As String) As Result
        Dim query = String.Format("
update Sach
set TinhTrang=0
where maSach={0}", maSach)
        Return _dataProvider.ExecuteNonquery(query)
    End Function

    Public Function Update(sach As Sach) As Result

    End Function

    Public Function DeleteById(id As String) As Result
        Dim query = String.Format("update Sach
set DeleteFlag='Y'
where MaSach={0}", id)
        Return _dataProvider.ExecuteNonquery(query)
    End Function
#End Region

#Region "-   Retrieve data    -"
    Public Function getQuanlity(maDauSach As String) As Integer
        Dim query = "Select * from [QuanLiThuVien].[dbo].[Sach] where MaDauSach=N'" & maDauSach & "'"
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        Return dataTable.Rows.Count
    End Function

    Public Function getAvailableSachBaseOnDauSachId(dauSachId As String, ByRef soluong As Integer) As Result
        Dim query = "EXECUTE dbo.USP_CountCuonSachBaseOnDauSachId " + dauSachId
        Dim dtb = New DataTable()
        Dim rs = _dataProvider.ExecuteQuery(query, dtb)
        For Each row In dtb.Rows
            soluong = Integer.Parse(row("soLuong"))
        Next
        Return rs
    End Function

    Public Sub selectSachByType(maSach As String, ByRef tSach As String, ByRef tgia As String, ByRef maDs As String)
        Dim query = "EXECUTE dbo.USP_SelectTacGiaAndTenSachByCuonSachId " + maSach
        Dim dtb = New DataTable()
        Dim rs = _dataProvider.ExecuteQuery(query, dtb)
        For Each row In dtb.Rows
            tSach = (row("TenSach"))
            tgia = (row("TenTacGia"))
            maDs = row("MaDauSach")
        Next
    End Sub

    Public Function SelectAll(ByRef listSach As List(Of Sach)) As Result
        Dim query = String.Empty
        query &= "Select * from Sach where DeleteFlag='N'"
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        If result.FlagResult = True Then
            For Each row In dataTable.Rows
                Dim sach = New Sach(row)
                listSach.Add(sach)
            Next
        End If
        Return result
    End Function

    Public Function SelectByType(maSach As String, ByRef tenSach As String, ByRef theLoai As String, ByRef tenTacGia As String, ByRef soluongSachCon As Integer, ByRef listIdCuonSach As List(Of Integer)) As Result
        Dim query = String.Format("exec USP_GetInfoBookForRent @MaDauSach=N'{0}'", maSach)
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        If (dataTable.Rows.Count <= 0) Then
            tenSach = String.Empty
            theLoai = String.Empty
            tenTacGia = String.Empty
            result.FlagResult = False

            Return result
        Else
            For Each row In dataTable.Rows
                If (Integer.Parse(row("TinhTrang")) = 0) Then
                    Dim id = Integer.Parse(row("MaSach").ToString())
                    tenSach = row("TenSach").ToString()
                    theLoai = row("TenTheLoaiSach").ToString()
                    tenTacGia = row("TenTacGia").ToString()
                    soluongSachCon += 1
                    listIdCuonSach.Add(id)
                End If
            Next

        End If

        Return result
    End Function

    Public Function SelectAllByMaSach(ByRef listSach As List(Of Sach), maSach As String) As Result
        Dim query = String.Empty
        query = String.Format("Select * from Sach where MaSach={0} and DeleteFlag='N'", maSach)
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        If result.FlagResult = True Then
            For Each row In dataTable.Rows
                Dim sach = New Sach(row)
                listSach.Add(sach)
            Next
        End If
        Return result
    End Function


    Public Function GetByID(ByRef sach As Sach, maSach As Integer) As Result
        Dim query = String.Format("select * 
from sach
where DeleteFlag='N' and 
maSach={0}", maSach)
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            sach = New Sach(row)
        Next
        Return result
    End Function

    Public Function GetTheLastExistID(ByRef maSach As String) As Result
        Dim query As String = String.Empty
        query &= "select top 1 [MaSach] "
        query &= "from Sach "
        query &= "where DeleteFlag='N'"
        query &= "ORDER BY [MaSach] DESC "
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            maSach = row("MaSach")
        Next
        Return result
    End Function

    Public Function GetTheLastID(ByRef maSach As String) As Result
        Dim query As String = String.Empty
        query &= "select top 1 [MaSach] "
        query &= "from Sach "
        query &= "ORDER BY [MaSach] DESC "
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            maSach = row("MaSach")
        Next
        Return result
    End Function
#End Region

End Class
