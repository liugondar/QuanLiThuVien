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

    Public Function SelectByType(maSach As String, ByRef tenSach As String, ByRef theLoai As String, ByRef tenTacGia As String, ByRef tinhTrangSach As Integer) As Result
        Dim query = String.Format("
   select cs.TinhTrang, tg.TenTacGia, ds.TenSach, tls.TenTheLoaiSach
from Sach cs,DauSach ds, TheLoaiSach tls, TacGia tg
where cs.MaDauSach = ds.MaDauSach
and cs.MaDauSach= '{0}'
and tls.MaTheLoaiSach= ds.MaTheLoaiSach 
and tg.MaTacGia = ds.MaTacGia", maSach)
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        Dim row = dataTable.Rows(0)
        If (dataTable.Rows.Count <= 0) Then
            tenSach = String.Empty
            theLoai = String.Empty
            tenTacGia = String.Empty
            result.FlagResult = False

            Return result
        End If

        tenSach = row("TenSach").ToString()
        theLoai = row("TenTheLoaiSach").ToString()
        tenTacGia = row("TenTacGia").ToString()
        Integer.TryParse(row("TinhTrang").ToString(), tinhTrangSach)

        Return result
    End Function

      Public Function SelectAll(ByRef listTacGia As List(Of TacGia)) As Result
        Dim query = String.Empty
        query &= "Select * from dbo.TacGia"
        query &= " Where DeleteFlag='N'" & " "

        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row As DataRow In dataTable.Rows
            Dim tacGia = New TacGia(row)
            listTacGia.Add(tacGia)
        Next
        Return result
    End Function

    Public Function SelectTacGiaByMaTacGia(ByRef tacGia As TacGia, maTacGia As String) As Result
        Dim query = String.Empty
        query &= "Select * from dbo.TacGia where MaTacGia=" & maTacGia
        query &= " and DeleteFlag='N'" & " "
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row As DataRow In dataTable.Rows
            tacGia = New TacGia(row)
        Next
        Return result
    End Function

    Public Function GetTenTacGiaByMaTacGia(ByRef tenTacGia As String, maTacGia As String) As Object
        Dim query = String.Empty
        query &= "Select * from dbo.TacGia where MaTacGia=" & maTacGia
        query &= " and DeleteFlag='N'" & " "
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row As DataRow In dataTable.Rows
            tenTacGia = row("TenTacGia").ToString()
        Next
        Return result
    End Function

    Function GetTheLastId(ByRef maTacGia As String) As Result
        Dim data = New DataTable()
        Dim query = String.Format("select top 1 [MaTacGia]
from TacGia
order by MaTacGia desc")
        Dim result = _dataProvider.ExecuteQuery(query, data)

        For Each row In data.Rows
            maTacGia = row("MaTacGia").ToString()
        Next
        Return New Result()
    End Function
#End Region

#Region "-    Insert,delete,update   -"
    Function UpdateById(tacGia As TacGia, tacGiaId As String) As Result
        Dim query = String.Format("
update TacGia
set TenTacGia='{0}'
where MaTacGia={1} and DeleteFlag='N'", tacGia.TenTacGia, tacGiaId)
        Return _dataProvider.ExecuteNonquery(query)
    End Function

    Function DeleteById(tacGiaId As String) As Result
        Dim query = String.Format("
update TacGia
set DeleteFlag='Y'
where MaTacGia={0}", tacGiaId)
        Return _dataProvider.ExecuteNonquery(query)
    End Function

    Function InsertOne(tacGia As TacGia) As Result
        Dim query = String.Format("
INSERT into dbo.TacGia(TenTacGia)
VALUES('{0}')", tacGia.TenTacGia)
        Return _dataProvider.ExecuteNonquery(query)
    End Function
#End Region
End Class