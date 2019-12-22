Imports DTO
Imports Utility
Imports System.Configuration
Imports System.Data.SqlClient

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
    Public Function InsertOne(sach As Sach) As Result
        Dim query = String.Empty
        query &= "EXECUTE USP_NhapSach "
        query &= "@MaSach= N'" & sach.MaSach & "',"
        query &= "@TenSach = N'" & sach.TenSach & "',"
        query &= "@MaTheLoaiSach =" & sach.MaTheLoaiSach & " ,"
        query &= "@MaTacGia =" & sach.MaTacGia & " ,"
        query &= "@TenNhaXuatBan =N'" & sach.TenNhaXuatBan & "',"
        query &= "@NgayXuatBan='" & sach.NgayXuatBan.ToString(formatDate) & "' ,"
        query &= "@NgayNhap='" & sach.NgayNhap.ToString(formatDate) & "' ,"
        query &= "@TriGia =" & sach.TriGia & " "

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
        Dim query = String.Format("update Sach
set TenSach=N'{0}', MaTheLoaiSach={1},
MaTacGia={2},TenNhaXuatBan=N'{3}',
NgayXuatBan='{4}',TriGia={5}
WHERE MaSach={6} and DeleteFlag='N'",
sach.TenSach, sach.MaTheLoaiSach,
sach.MaTacGia, sach.TenNhaXuatBan,
sach.NgayXuatBan.ToString(DateHelper.Instance.GetFormatType()), sach.TriGia,
sach.MaSach)
        Return _dataProvider.ExecuteNonquery(query)
    End Function

    Public Function DeleteById(id As String) As Result
        Dim query = String.Format("update Sach
set DeleteFlag='Y'
where MaSach={0}", id)
        Return _dataProvider.ExecuteNonquery(query)
    End Function
#End Region

#Region "-   Retrieve data    -"
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

    Public Function SelectAllBySpecificConditions(listSach As List(Of Sach), sachYeuCau As Sach,
                                                  ngayXuatBanMin As Date, ngayXuatBanMax As Date,
                                                  ngayNhapMin As Date, ngayNhapMax As Date,
                                                  triGiaMin As Double, triGiaMax As Double) As Result
        Dim query = String.Empty

        Dim dieuKienMaSach = If(sachYeuCau.MaSach = -1, " 1=1 ", " MaSach=" & sachYeuCau.MaSach)
        Dim dieuKienTenNhaXuatBan = If(sachYeuCau.TenNhaXuatBan = "-1", " 1=1 ", "TenNhaXuatBan='" & sachYeuCau.TenNhaXuatBan & "'")
        Dim dieuKienMaTacGia = If(sachYeuCau.MaTacGia = -1, " 1=1 ", "MaTacGia=" & sachYeuCau.MaTacGia)
        Dim dieuKienMaTheLoaiSach = If(sachYeuCau.MaTheLoaiSach = -1, " 1=1 ", "MaTheLoaiSach=" & sachYeuCau.MaTheLoaiSach)

        Dim formatDate = DateHelper.Instance.GetFormatType()
        Dim ngayxbMinConverted = ngayXuatBanMin.ToString(formatDate)
        Dim ngayxbMaxConverted = ngayXuatBanMax.ToString(formatDate)
        Dim ngayNhapMinConverted = ngayNhapMin.ToString(formatDate)
        Dim ngayNhapMaxConverted = ngayNhapMax.ToString(formatDate)

        query = String.Format("select * 
from Sach
where {0} and {1} and {2} and {3}
and NgayNhap between '{4}' and '{5}'
and NgayXuatBan between '{6}' and '{7}'
and TriGia between {8} and {9}
and DeleteFlag='N'",
dieuKienMaSach, dieuKienMaTheLoaiSach, dieuKienMaTacGia, dieuKienTenNhaXuatBan,
ngayNhapMinConverted, ngayNhapMaxConverted,
ngayxbMinConverted, ngayxbMaxConverted,
triGiaMin, triGiaMax)

        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        If result.FlagResult = True Then
            For Each row In dataTable.Rows
                Dim sachTemp = New Sach(row)
                listSach.Add(sachTemp)
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

    Public Function SelectAllByMaCuonSach(ByRef listSach As List(Of Sach), maCuonSach As String) As Result
        Dim querycs = String.Empty
        querycs = String.Format("Select * from Sach, CuonSach where Sach.MaSach=CuonSach.DauSach and MaCuonSach={0} and DeleteFlag='N'", maCuonSach)
        Dim dataTablecs = New DataTable()
        Dim resultcs = _dataProvider.ExecuteQuery(querycs, dataTablecs)
        If resultcs.FlagResult = True Then
            For Each rowcs In dataTablecs.Rows
                Dim sach = New Sach(rowcs)
                listSach.Add(sach)
            Next
        End If
        Return resultcs
    End Function

    Public Function SelectByType(maSach As String,
                                 ByRef tenSach As String, ByRef theLoai As String,
                                 ByRef tenTacGia As String, ByRef tinhTrangSach As Integer) As Result
        Dim query = String.Format("
select s.MaSach as MaSach,s.TenSach as tenSach,
tls.TenTheLoaiSach as TenTheLoaiSach,tg.TenTacGia as TenTacGia,TinhTrang 
from sach s,TheLoaiSach tls,TacGia tg
where s.MaTheLoaiSach=tls.MaTheLoaiSach and s.MaTacGia=tg.MaTacGia
and s.DeleteFlag='N' and tls.DeleteFlag='N' and tg.DeleteFlag='N'
and s.MaSach={0}", maSach)
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

    Public Function SelectByTypePls(maSach As String,
                                 ByRef tenSach As String, ByRef theLoai As String,
                                 ByRef tenTacGia As String, ByRef tinhTrangSach As Integer) As Result
        Dim query = String.Format("
select s.MaSach as MaSach,s.TenSach as tenSach,
tls.TenTheLoaiSach as TenTheLoaiSach,tg.TenTacGia as TenTacGia,TinhTrang 
from sach s,TheLoaiSach tls,TacGia tg
where s.MaTheLoaiSach=tls.MaTheLoaiSach and s.MaTacGia=tg.MaTacGia
and s.DeleteFlag='N' and tls.DeleteFlag='N' and tg.DeleteFlag='N'
and s.MaSach={0}", maSach)
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

    Public Function SelectSachById(sach As Sach, maSach As String) As Result
        Dim query = String.Empty
        query &= "select [maSach], [tenSach], [maTacGia], [maTheLoaiSach]  "
        query &= "from sach "
        query &= "where maSach= " & maSach & " "
        query &= " And DeleteFlag='N'" & " "

        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        If result.FlagResult = True Then
            For Each row In dataTable.Rows
                Dim doesRowContainsCorrectFields = row.Table.Columns.Contains("MaSach") And
                 row.Table.Columns.Contains("MaTheLoaiSach") And
                 row.Table.Columns.Contains("MaTacGia") And
                row.Table.Columns.Contains("TenSach")

                If doesRowContainsCorrectFields = False Then
                    Return New Result(False, "Lấy thông tin sách không thành công!", "")
                End If
                Integer.TryParse(row("MaSach").ToString(), sach.MaSach)
                Integer.TryParse(row("MaTheLoaiSach").ToString(), sach.MaTheLoaiSach)
                Integer.TryParse(row("MaTacGia").ToString(), sach.MaTacGia)
                sach.TenSach = row("TenSach").ToString()
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
