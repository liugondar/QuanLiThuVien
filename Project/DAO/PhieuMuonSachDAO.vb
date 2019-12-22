Imports DTO
Imports Utility
Imports System.Configuration
Imports System.Data.SqlClient

Public Class PhieuMuonSachDAO
#Region "-   Fields    -"
    'Private connectionString As String

    'Public Sub New(ConnectionString As String)
    '    Me.connectionString = ConnectionString
    'End Sub
    Private _dataProvider As DataProvider

#End Region

#Region "-   Constructor  -"

    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub

#End Region

#Region "-   Insert   -"

    Public Function InsertOne(phieuMuonSach As PhieuMuonSach) As Result
        Dim query = String.Empty
        Dim formatDate = DateHelper.Instance.GetFormatType()
        query &= "EXECUTE USP_ThemPhieuMuonSach "
        query &= "@MaPhieuMuonSach=" & phieuMuonSach.MaPhieuMuonSach & ", "
        query &= "@MaTheDocGia=" & phieuMuonSach.MaTheDocGia & ", "
        query &= "@NgayMuon='" & phieuMuonSach.NgayMuon.ToString(formatDate) & "' , "
        query &= "@HanTra='" & phieuMuonSach.HanTra.ToString(formatDate) & "', "
        query &= "@TongSoSachMuon=" & phieuMuonSach.TongSoSachMuon
        Return _dataProvider.ExecuteNonquery(query)
    End Function

#End Region

#Region "-   Update    -"
    Public Function UpdateCheckOutPhieuMuonByPhieuMuonSach(PhieuMuonSach As PhieuMuonSach) As Result
        Dim formatDate = DateHelper.Instance.GetFormatType()
        Dim query = String.Format("
update PhieuMuonSach    
set TinhTrang=1, NgayTra='{0}'
where MaPhieuMuonSach={1}
 ", PhieuMuonSach.NgayTra.ToString(formatDate), PhieuMuonSach.MaPhieuMuonSach)
        Return _dataProvider.ExecuteNonquery(query)
    End Function
#End Region

#Region "-   Retrieve data    -"

    Public Function GetTheLastPhieuMuonSachID(ByRef maPhieuDocSach As String) As Result
        maPhieuDocSach = 0
        Dim query = String.Empty
        query = String.Format("select top 1 [MaPhieuMuonSach] from PhieuMuonSach where DeleteFlag='N' order by [MaPhieuMuonSach] desc")

        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        If result.FlagResult = False Then Return New Result(False, "Không thể lấy mã phiếu mượn sách gần nhất!", "")
        Dim phieuMuonSach = New PhieuMuonSach()
        phieuMuonSach.MaPhieuMuonSach = 0
        For Each row In dataTable.Rows
            maPhieuDocSach = row("MaPhieuMuonSach").ToString()
        Next

        Return result
    End Function

    Public Function SelectAllByMaTheDocGia(ByRef listPhieuMuonSach As List(Of PhieuMuonSach), maTheDocGia As String) As Result
        Dim query = String.Empty
        query &= "select * "
        query &= "from PhieuMuonSach "
        query &= "Where MaTheDocGia=" & maTheDocGia
        query &= " And DeleteFlag='N'" & " "


        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        If result.FlagResult = False Then Return New Result(False, "Không thể lấy danh sach phiếu mượn sách đã có!", "")
        For Each row In dataTable.Rows
            Dim phieuMuonSach = New PhieuMuonSach()
            phieuMuonSach.MaPhieuMuonSach = 0
            phieuMuonSach = New PhieuMuonSach(row)
            listPhieuMuonSach.Add(phieuMuonSach)
        Next
        Return result
    End Function

    Public Function SelectAllByMaCuonSach(ByRef listSach As List(Of Sach), maCuonSach As String) As Result
        Dim query = String.Empty
        query &= "select * "
        query &= "from CuonSach, Sach "
        query &= "Where CuonSach.DauSach = Sach.MaSach "
        query &= " And MaCuonSach=" & maCuonSach
        query &= " And DeleteFlag='N'" & " "
        Dim dataTablecs = New DataTable()
        Dim resultcs = _dataProvider.ExecuteQuery(query, dataTablecs)
        If resultcs.FlagResult = True Then
            For Each rowcs In dataTablecs.Rows
                Dim sach = New Sach(rowcs)
                listSach.Add(sach)
            Next
        End If
        Return resultcs
    End Function

    Public Function SelectAllPhieuMuonSachChuaTraByReaderId(ByRef listPhieuMuonSach As List(Of PhieuMuonSach), maTheDocGia As String) As Result
        Dim query = String.Empty
        query = String.Format("Select * from PhieuMuonSach
WHERE [MaTheDocGia]={0} AND [TinhTrang]=0
and DeleteFlag='N'", maTheDocGia)

        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        If result.FlagResult = False Then Return New Result(False, "Không thể lấy danh sach phiếu mượn sách đã có!", "")
        For Each row In dataTable.Rows
            Dim phieuMuonSach = New PhieuMuonSach()
            phieuMuonSach.MaPhieuMuonSach = 0
            phieuMuonSach = New PhieuMuonSach(row)
            listPhieuMuonSach.Add(phieuMuonSach)
        Next
        Return result
    End Function

    Public Function SelectIdTheLastOne(ByRef maPhieuMuonSach As String) As Result
        Dim query As String = String.Empty
        query &= "select top 1 [MaPhieuMuonSach] "
        query &= "from PhieuMuonSach "
        query &= " Where DeleteFlag='N'" & " "
        query &= "ORDER BY [MaPhieuMuonSach] DESC "

        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            maPhieuMuonSach = row("MaPhieuMuonSach")
        Next
        Return result
    End Function

    Public Function GetPhieuMuonSachById(ByRef phieuMuonSach As PhieuMuonSach, maPhieuMuonSach As String) As Result
        Dim query = String.Format("
select * from PhieuMuonSach
where MaPhieuMuonSach={0} And DeleteFlag='N'", maPhieuMuonSach)
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            phieuMuonSach = New PhieuMuonSach(row)
        Next
        Return result
    End Function

    Public Function SelectAllPhieuMuonSachByDate(ByRef listPhieuMuonSach As List(Of PhieuMuonSach), thoiGian As DateTime) As Result
        'Get all phieu muon sach in time input
        Dim query = String.Format("
select * from PhieuMuonSach
where DeleteFlag='N' and TinhTrang='1'
And YEAR(NgayTra)='{0}' and month(NgayMuon)='{1}'
", thoiGian.ToString("yyyy"), thoiGian.ToString("MM"))
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            Dim PhieuMuonSach = New PhieuMuonSach(row)
            listPhieuMuonSach.Add(PhieuMuonSach)
        Next
        Return result
    End Function


    'Public Function getAll_SachDangMuon_ByMaDocGia(madocgia As String, ByRef listMaSach As List(Of String), ByRef listTenSach As List(Of String), ByRef listNgayMuon As List(Of Date)) As Result

    '    Dim query As String = String.Empty
    '    query &= "SELECT DISTINCT cs.[MaCuonSach], s.[TenSach], pm.[NgayMuon] "
    '    query &= "FROM [CuonSach] cs, [ChiTietPhieuMuonSach] ctpm, [PhieuMuonSach] pm, [TheDocGia] dg, [Sach] s "
    '    query &= "WHERE cs.[MaCuonSach] = ctpm.[MaCuonSach] and ctpm.[MaPhieuMuonSach] = pm.[MaPhieuMuonSach] and cs.[DauSach] = s.[MaSach] and pm.[MaTheDocGia] = @madocgia "


    '    Using conn As New SqlConnection(connectionString)
    '        Using comm As New SqlCommand()
    '            With comm
    '                .Connection = conn
    '                .CommandType = CommandType.Text
    '                .CommandText = query
    '                .Parameters.AddWithValue("@madocgia", madocgia)
    '            End With
    '            Try
    '                conn.Open()
    '                Dim reader As SqlDataReader
    '                reader = comm.ExecuteReader()
    '                If reader.HasRows = True Then
    '                    listMaSach.Clear()
    '                    listTenSach.Clear()
    '                    listNgayMuon.Clear()
    '                    While reader.Read()
    '                        listMaSach.Add(reader("macuonsach"))
    '                        listTenSach.Add(reader("tendausach"))
    '                        listNgayMuon.Add(reader("ngaymuon"))
    '                    End While
    '                End If

    '            Catch ex As Exception
    '                conn.Close()
    '                System.Console.WriteLine(ex.StackTrace)
    '                Return New Result(False)
    '            End Try
    '        End Using
    '    End Using
    '    Return New Result(True) ' thanh cong
    'End Function
#End Region
End Class
