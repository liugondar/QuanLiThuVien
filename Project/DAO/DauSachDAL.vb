Imports DTO
Imports Utility

Public Class DauSachDAO

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
    Public Function InsertOne(dausach As DauSachDTO) As Result
        Dim query = String.Empty
        query &= "EXECUTE USP_NhapSach "
        query &= "@MaDauSach= N'" & dausach.MaDauSach & "',"
        query &= "@TenSach = N'" & dausach.TenSach & "',"
        query &= "@MaTheLoaiSach =" & dausach.MaTheLoaiSach & " ,"
        query &= "@MaTacGia =" & dausach.MaTacGia & " ,"
        query &= "@TenNhaXuatBan =N'" & dausach.TenNhaXuatBan & "',"
        query &= "@NgayXuatBan='" & dausach.NgayXuatBan.ToString(formatDate) & "' ,"
        query &= "@NgayNhap='" & dausach.NgayNhap.ToString(formatDate) & "' ,"
        query &= "@TriGia =" & dausach.TriGia & " "

        Dim resultDauSach = _dataProvider.ExecuteNonquery(query)

        Return resultDauSach
    End Function
#End Region

#Region "-   Update and delete  -"
    Public Function SetStatusSachToUnavailableByID(maDauSach As String) As Result
        Dim query = String.Format("
update DauSach
set TinhTrang=1
where maDauSach={0}", maDauSach)
        Return _dataProvider.ExecuteNonquery(query)
    End Function

    Public Function SetStatusSachToAvailableByID(maDauSach As String) As Result
        Dim query = String.Format("
update DauSach
set TinhTrang=0
where maSach={0}", maDauSach)
        Return _dataProvider.ExecuteNonquery(query)
    End Function

    Public Function Update(dausach As DauSachDTO) As Result
        Dim query = String.Format("update DauSach
set TenSach=N'{0}', MaTheLoaiSach={1},
MaTacGia={2},TenNhaXuatBan=N'{3}',
NgayXuatBan='{4}',TriGia={5}
WHERE MaDauSach={6} and DeleteFlag='N'",
dausach.TenSach, dausach.MaTheLoaiSach,
dausach.MaTacGia, dausach.TenNhaXuatBan,
dausach.NgayXuatBan.ToString(DateHelper.Instance.GetFormatType()), dausach.TriGia,
dausach.MaDauSach)
        Return _dataProvider.ExecuteNonquery(query)
    End Function

    Public Function DeleteById(id As String) As Result
        Dim query = String.Format("update DauSach
set DeleteFlag='Y'
where MaDauSach={0}", id)
        Return _dataProvider.ExecuteNonquery(query)
    End Function
#End Region

#Region "-   Retrieve data    -"
    Public Function SelectAll(ByRef listDauSach As List(Of DauSachDTO)) As Result
        Dim query = String.Empty
        query &= "Select * from DauSach where DeleteFlag='N'"
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        If result.FlagResult = True Then
            For Each row In dataTable.Rows
                Dim dausach = New DauSachDTO(row)
                listDauSach.Add(dausach)
            Next
        End If
        Return result
    End Function

    Public Function SelectAllBySpecificConditions(listDauSach As List(Of DauSachDTO), sachYeuCau As DauSachDTO,
                                                  ngayXuatBanMin As Date, ngayXuatBanMax As Date,
                                                  ngayNhapMin As Date, ngayNhapMax As Date,
                                                  triGiaMin As Double, triGiaMax As Double) As Result
        Dim query = String.Empty

        Dim dieuKienMaDauSach = If(sachYeuCau.MaDauSach = -1, " 1=1 ", " MaSach=" & sachYeuCau.MaDauSach)
        Dim dieuKienTenNhaXuatBan = If(sachYeuCau.TenNhaXuatBan = "-1", " 1=1 ", "TenNhaXuatBan='" & sachYeuCau.TenNhaXuatBan & "'")
        Dim dieuKienMaTacGia = If(sachYeuCau.MaTacGia = -1, " 1=1 ", "MaTacGia=" & sachYeuCau.MaTacGia)
        Dim dieuKienMaTheLoaiSach = If(sachYeuCau.MaTheLoaiSach = -1, " 1=1 ", "MaTheLoaiSach=" & sachYeuCau.MaTheLoaiSach)

        Dim formatDate = DateHelper.Instance.GetFormatType()
        Dim ngayxbMinConverted = ngayXuatBanMin.ToString(formatDate)
        Dim ngayxbMaxConverted = ngayXuatBanMax.ToString(formatDate)
        Dim ngayNhapMinConverted = ngayNhapMin.ToString(formatDate)
        Dim ngayNhapMaxConverted = ngayNhapMax.ToString(formatDate)

        query = String.Format("select * 
from DauSach
where {0} and {1} and {2} and {3}
and NgayNhap between '{4}' and '{5}'
and NgayXuatBan between '{6}' and '{7}'
and TriGia between {8} and {9}
and DeleteFlag='N'",
dieuKienMaDauSach, dieuKienMaTheLoaiSach, dieuKienMaTacGia, dieuKienTenNhaXuatBan,
ngayNhapMinConverted, ngayNhapMaxConverted,
ngayxbMinConverted, ngayxbMaxConverted,
triGiaMin, triGiaMax)

        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        If result.FlagResult = True Then
            For Each row In dataTable.Rows
                Dim sachTemp = New DauSachDTO(row)
                listDauSach.Add(sachTemp)
            Next
        End If
        Return result
    End Function

    Public Function SelectAllByMaDauSach(ByRef listDauSach As List(Of DauSachDTO), maDauSach As String) As Result
        Dim query = String.Empty
        query = String.Format("Select * from DauSach where MaSach={0} and DeleteFlag='N'", maDauSach)
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        If result.FlagResult = True Then
            For Each row In dataTable.Rows
                Dim dausach = New DauSachDTO(row)
                listDauSach.Add(dausach)
            Next
        End If
        Return result
    End Function

    Public Function SelectByType(maDauSach As String,
                                 ByRef tenSach As String, ByRef theLoai As String,
                                 ByRef tenTacGia As String, ByRef tinhTrangSach As Integer) As Result
        Dim query = String.Format("
select s.MaDauSach as MaDauSach,s.TenSach as tenSach,
tls.TenTheLoaiSach as TenTheLoaiSach,tg.TenTacGia as TenTacGia,TinhTrang 
from sach s,TheLoaiSach tls,TacGia tg
where s.MaTheLoaiSach=tls.MaTheLoaiSach and s.MaTacGia=tg.MaTacGia
and s.DeleteFlag='N' and tls.DeleteFlag='N' and tg.DeleteFlag='N'
and s.MaDauSach={0}", maDauSach)
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        If result.FlagResult = True Then
            For Each row In dataTable.Rows
                tenSach = row("TenSach").ToString()
                theLoai = row("TenTheLoaiSach").ToString()
                tenTacGia = row("TenTacGia").ToString()
                Integer.TryParse(row("TinhTrang").ToString(), tinhTrangSach)
            Next
        End If
        Return result
    End Function

    Public Function SelectDauSachById(dausach As DauSachDTO, maDauSach As String) As Result
        Dim query = String.Empty
        query &= "select [maDauSach], [tenSach], [maTacGia], [maTheLoaiSach]  "
        query &= "from dausach "
        query &= "where maDauSach= " & maDauSach & " "
        query &= " And DeleteFlag='N'" & " "

        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        If result.FlagResult = True Then
            For Each row In dataTable.Rows
                Dim doesRowContainsCorrectFields = row.Table.Columns.Contains("MaDauSach") And
                 row.Table.Columns.Contains("MaTheLoaiSach") And
                 row.Table.Columns.Contains("MaTacGia") And
                row.Table.Columns.Contains("TenSach")

                If doesRowContainsCorrectFields = False Then
                    Return New Result(False, "Lấy thông tin sách không thành công!", "")
                End If
                Integer.TryParse(row("MaSach").ToString(), dausach.MaDauSach)
                Integer.TryParse(row("MaTheLoaiSach").ToString(), dausach.MaTheLoaiSach)
                Integer.TryParse(row("MaTacGia").ToString(), dausach.MaTacGia)
                dausach.TenSach = row("TenSach").ToString()
            Next
        End If
        Return result
    End Function

    Public Function GetByID(ByRef dausach As DauSachDTO, maDauSach As Integer) As Result
        Dim query = String.Format("select * 
from dausach
where DeleteFlag='N' and 
maDauSach={0}", maDauSach)
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            dausach = New DauSachDTO(row)
        Next
        Return result
    End Function

    Public Function GetTheLastExistID(ByRef maDauSach As String) As Result
        Dim query As String = String.Empty
        query &= "select top 1 [MaDauSach] "
        query &= "from DauSach "
        query &= "where DeleteFlag='N'"
        query &= "ORDER BY [MaDauSach] DESC "
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            maDauSach = row("MaDauSach")
        Next
        Return result
    End Function

    Public Function GetTheLastID(ByRef maDauSach As String) As Result
        Dim query As String = String.Empty
        query &= "select top 1 [MaDauSach] "
        query &= "from DauSach "
        query &= "ORDER BY [MaDauSach] DESC "
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            maDauSach = row("MaDauSach")
        Next
        Return result
    End Function
      Dim formatDate = DateHelper.Instance.GetFormatType()
        Dim query As String = String.Empty
        query &= "EXECUTE USP_ThemTheDocGia "
        query &= "@MaTheDocGia=N'" & docGia.MaTheDocGia & "', "
        query &= "@TenDocGia=N'" & docGia.TenDocGia & "', "
        query &= "@Email=N'" & docGia.Email & "', "
        query &= "@DiaChi =N'" & docGia.DiaChi & "', "
        query &= "@MaLoaiDocGia=" & docGia.MaLoaiDocGia & ", "
        query &= "@NgaySinh='" & docGia.NgaySinh.ToString(formatDate) & "', "
        query &= "@NgayTao='" & docGia.NgayTao.ToString(formatDate) & "', "
        query &= "@NgayHetHan='" & docGia.NgayHetHan.ToString(formatDate) & "' "

        Dim result = _dataProvider.ExecuteNonquery(query)
        Return result
    End Function

    Public Function DeleteByReaderID(maThe As String) As Result
        Dim query As String = String.Empty
        query &= "EXECUTE USP_XoaTheDocGia "
        query &= "@MaTheDocGia=" & maThe
         query &= "@NgaySinh='" & docGia.NgaySinh.ToString(formatDate) & "', "
        query &= "@NgayTao='" & docGia.NgayTao.ToString(formatDate) & "', "
        query &= "@NgayHetHan='" & docGia.NgayHetHan.ToString(formatDate) & "' "
        Dim result = _dataProvider.ExecuteNonquery(query)
        Return result
    End Function

    Public Function UpdateByReaderId(DocGia As DocGia) As Result
        Dim query As String = String.Empty
        Dim formatDate = DateHelper.Instance.GetFormatType()
        query &= "EXECUTE USP_SuaTheDocGia "
        query &= "@MaTheDocGia=N'" & DocGia.MaTheDocGia & "', "
        query &= "@TenDocGia=N'" & DocGia.TenDocGia & "', "
        query &= "@Email=N'" & DocGia.Email & "', "
        query &= "@DiaChi =N'" & DocGia.DiaChi & "', "
        query &= "@MaLoaiDocGia=" & DocGia.MaLoaiDocGia & ", "
        query &= "@NgaySinh='" & DocGia.NgaySinh.ToString(formatDate) & "'"
        Dim result = _dataProvider.ExecuteNonquery(query)
        Return result
    End Function
    Public Function GetTheLastID(ByRef maDauSach As String) As Result
        Dim query As String = String.Empty
        query &= "select top 1 [MaDauSach] "
        query &= "from DauSach "
        query &= "ORDER BY [MaDauSach] DESC "
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            maDauSach = row("MaDauSach")
        Next
        Return result
    End Function
      Dim formatDate = DateHelper.Instance.GetFormatType()
        Dim query As String = String.Empty
        query &= "EXECUTE USP_ThemTheDocGia "
        query &= "@MaTheDocGia=N'" & docGia.MaTheDocGia & "', "
        query &= "@TenDocGia=N'" & docGia.TenDocGia & "', "
        query &= "@Email=N'" & docGia.Email & "', "
        query &= "@DiaChi =N'" & docGia.DiaChi & "', "
        query &= "@MaLoaiDocGia=" & docGia.MaLoaiDocGia & ", "
        query &= "@NgaySinh='" & docGia.NgaySinh.ToString(formatDate) & "', "
        query &= "@NgayTao='" & docGia.NgayTao.ToString(formatDate) & "', "
        query &= "@NgayHetHan='" & docGia.NgayHetHan.ToString(formatDate) & "' "

        Dim result = _dataProvider.ExecuteNonquery(query)
        Return result
    End Function

    Public Function DeleteByReaderID(maThe As String) As Result
        Dim query As String = String.Empty
        query &= "EXECUTE USP_XoaTheDocGia "
        query &= "@MaTheDocGia=" & maThe
         query &= "@NgaySinh='" & docGia.NgaySinh.ToString(formatDate) & "', "
        query &= "@NgayTao='" & docGia.NgayTao.ToString(formatDate) & "', "
        query &= "@NgayHetHan='" & docGia.NgayHetHan.ToString(formatDate) & "' "
        Dim result = _dataProvider.ExecuteNonquery(query)
        Return result
    End Function

    Public Function UpdateByReaderId(DocGia As DocGia) As Result
        Dim query As String = String.Empty
        Dim formatDate = DateHelper.Instance.GetFormatType()
        query &= "EXECUTE USP_SuaTheDocGia "
        query &= "@MaTheDocGia=N'" & DocGia.MaTheDocGia & "', "
        query &= "@TenDocGia=N'" & DocGia.TenDocGia & "', "
        query &= "@Email=N'" & DocGia.Email & "', "
        query &= "@DiaChi =N'" & DocGia.DiaChi & "', "
        query &= "@MaLoaiDocGia=" & DocGia.MaLoaiDocGia & ", "
        query &= "@NgaySinh='" & DocGia.NgaySinh.ToString(formatDate) & "'"
        Dim result = _dataProvider.ExecuteNonquery(query)
        Return result
    End Function

#End Region

#Region "-   Retrieve data    -"

    Public Function SelectAllByType(maLoai As String, ByRef listDocGia As List(Of DocGia)) As Result
        Dim dieuKienMaLoai = If(maLoai = -1, "1=1", "[MaLoaiDocGia]=" & maLoai)
        Dim query As String = String.Empty
        query = String.Format("select * from TheDocGia where {0} and DeleteFlag='N'", dieuKienMaLoai)
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            Dim docGia = New DocGia(row)
            listDocGia.Add(docGia)
        Next

        Return result
    End Function

    Public Function SelectAllDocGia(ByRef listDocGia As List(Of DocGia)) As Result
        Dim query = String.Empty
        query &= "Select * from TheDocGia where DeleteFlag='N'"
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        If result.FlagResult = True Then
            For Each row In dataTable.Rows
                Dim docgia = New DocGia(row)
                listDocGia.Add(docgia)
            Next
        End If
        Return result
    End Function
    Public Function SelectAllBy(maLoai As String, ByRef listDocGia As List(Of DocGia)) As Result
        Dim dieuKienMaLoai = If(maLoai = -1, "1=1", "[MaLoaiDocGia]=" & maLoai)
        Dim query As String = String.Empty
        query = String.Format("select * from TheDocGia where {0} and DeleteFlag='N'", dieuKienMaLoai)
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            Dim docGia = New DocGia(row)
            listDocGia.Add(docGia)
        Next

        Return result
    End Function

    Public Function SelectAlltenDocGia(ByRef listDocGia As List(Of DocGia)) As Result
        Dim query = String.Empty
        query &= "Select * from TheDocGia where DeleteFlag='N'"
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        If result.FlagResult = True Then
            For Each row In dataTable.Rows
                Dim docgia = New DocGia(row)
                listDocGia.Add(docgia)
            Next
        End If
        Return result
    End Function

    Public Function GetReaderNameByID(ByRef tenDocGia As String, maThe As String) As Result
        Dim query As String = String.Empty
        query = String.Format("select TenDocGia from TheDocGia where MaTheDocGia={0} and DeleteFlag='N'", maThe)

        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            tenDocGia = row("TenDocGia")
        Next
        Return result
    End Function

#End Region

End Class
