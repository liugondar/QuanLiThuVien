Imports DTO
Imports Utility

Public Class SachDAO
    Private _dataProvider As DataProvider

    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub

    Public Function InsertOne(sach As Sach) As Result
        Dim query = String.Empty
        query &= "EXECUTE USP_NhapSach "
        query &= "@TenSach = N'" & sach.TenSach & "',"
        query &= "@MaTheLoaiSach =" & sach.MaTheLoaiSach & " ,"
        query &= "@MaTacGia =" & sach.MaTacGia & " ,"
        query &= "@TenNhaXuatBan =N'" & sach.TenNhaXuatBan & "',"
        query &= "@NgayXuatBan='" & sach.NgayXuatBan & "' ,"
        query &= "@NgayNhap='" & sach.NgayNhap & "' ,"
        query &= "@TriGia =" & sach.TriGia & " "

        Dim result = _dataProvider.ExcuteNonquery(query)
        Return result
    End Function

    Public Function SelectAll(ByRef listSach As List(Of Sach)) As Result
        Dim query = String.Empty
        query &= "Select * from Sach"
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        If result.FlagResult = True Then
            For Each row In dataTable.Rows
                Dim sach = New Sach(row)
                listSach.Add(sach)
            Next
        End If
        Return result
    End Function

    Public Function SelectAllByMaSach(ByRef listSach As List(Of Sach), maSach As String) As Result
        Dim query = String.Empty
        query &= "Select * from Sach where MaSach=" & maSach
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        If result.FlagResult = True Then
            For Each row In dataTable.Rows
                Dim sach = New Sach(row)
                listSach.Add(sach)
            Next
        End If
        Return result
    End Function

    Public Function SelectAllByMaTheLoaiSach(ByRef listSach As List(Of Sach), maTheLoaiSach As String) As Result
        Dim query = String.Empty
        query &= "Select * from Sach where MaTheLoaiSach=" & maTheLoaiSach
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        If result.FlagResult = True Then
            For Each row In dataTable.Rows
                Dim sach = New Sach(row)
                listSach.Add(sach)
            Next
        End If
        Return result
    End Function

    Public Function SelectAllByMaTacGia(ByRef listSach As List(Of Sach), maTacGia As String) As Result
        Dim query = String.Empty
        query &= "Select * from Sach where MaTacGia=" & maTacGia
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        If result.FlagResult = True Then
            For Each row In dataTable.Rows
                Dim sach = New Sach(row)
                listSach.Add(sach)
            Next
        End If
        Return result
    End Function

    Public Function SelectAllByTenNhaXuatBan(ByRef listSach As List(Of Sach), TenNhaXuatBan As String) As Result
        Dim query = String.Empty
        query &= "Select * from Sach where TenNhaXuatBan='" & TenNhaXuatBan & "'"
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        If result.FlagResult = True Then
            For Each row In dataTable.Rows
                Dim sach = New Sach(row)
                listSach.Add(sach)
            Next
        End If
        Return result
    End Function

    Public Function SelectAllByNgayXuatBan(ByRef listSach As List(Of Sach), ngayMin As DateTime, ngayMax As DateTime) As Result
        Dim ngayMinConverted = ngayMin.ToString("MMMM dd, yyyy")
        Dim ngayMaxConverted = ngayMax.ToString("MMMM dd, yyyy")
        Dim query = String.Empty
        query &= "select * from Sach "
        query &= "where NgayXuatBan between " & "' " & ngayMinConverted & "' "
        query &= "And '" & ngayMaxConverted & "' "
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        If result.FlagResult = True Then
            For Each row In dataTable.Rows
                Dim sach = New Sach(row)
                listSach.Add(sach)
            Next
        End If
        Return result
    End Function

    Public Function SelectAllByNgayNhap(ByRef listSach As List(Of Sach), ngayMin As DateTime, ngayMax As DateTime) As Result
        Dim ngayMinConverted = ngayMin.ToString("MMMM dd, yyyy")
        Dim ngayMaxConverted = ngayMax.ToString("MMMM dd, yyyy")
        Dim query = String.Empty
        query &= "select * from Sach "
        query &= "where NgayNhap between " & "' " & ngayMinConverted & "' "
        query &= "And '" & ngayMaxConverted & "' "
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        If result.FlagResult = True Then
            For Each row In dataTable.Rows
                Dim sach = New Sach(row)
                listSach.Add(sach)
            Next
        End If
        Return result
    End Function

    Public Function SelectAllByTriGia(ByRef listSach As List(Of Sach), triGiaMin As String, triGiaMax As String) As Result
        Dim query = String.Empty
        query &= "select * from Sach "
        query &= "where TriGia between " & " " & triGiaMin & " "
        query &= "And " & triGiaMax & " "
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        If result.FlagResult = True Then
            For Each row In dataTable.Rows
                Dim sach = New Sach(row)
                listSach.Add(sach)
            Next
        End If
        Return result
    End Function
End Class
