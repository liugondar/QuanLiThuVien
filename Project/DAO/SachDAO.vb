Imports DTO
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

    Public Function InsertOne(cuonsach As Sach) As Result
        Dim query = String.Empty
        query &= "EXECUTE USP_NhapCuonSach "
        query &= "@MaSach = N'" & cuonsach.MaSach & "',"
        query &= "@MaDauSach= N'" & cuonsach.MaDauSach & "',"
        query &= "@TinhTrang = 0"

        System.Diagnostics.Debug.WriteLine(query)
        Dim result = _dataProvider.ExecuteNonquery(query)

        Return result
    End Function

    Public Function GetTheLastID(ByRef maCuonSach As Integer) As Result
        Dim query As String = String.Empty
        query &= "select top 1 [MaSach] "
        query &= "from Sach "
        query &= "ORDER BY [MaSach] DESC "
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            maCuonSach = Integer.Parse(row("MaSach"))
        Next
        System.Diagnostics.Debug.WriteLine(maCuonSach)

        Return result
    End Function

    Public Function getQuanlity(maDauSach As String) As Integer
        Dim query = "Select * from [QuanLiThuVien].[dbo].[Sach] where MaDauSach=N'" & maDauSach & "'"
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        Return dataTable.Rows.Count
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
#End Region
End Class