﻿Imports DTO
Imports Utility

Public Class ChiTietPhieuMuonSachDAO
#Region "-   Fields   -"
    Private _dataProvider As DataProvider
#End Region

#Region "-   Constructor    -"

    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub

#End Region

#Region "-   Insert    -"

    Public Function InsertOne(chiTietPhieuMuonSach As ChiTietPhieuMuonSach) As Result
        Dim query = String.Empty
        query = String.Format("EXECUTE USP_ThemChiTietPhieuMuonSach @MaPhieuMuonSach={0} ,@MaSach={1}",
            chiTietPhieuMuonSach.MaPhieuMuonSach, chiTietPhieuMuonSach.MaSach)
        Return _dataProvider.ExecuteNonquery(query)
    End Function

#End Region

#Region "-   Delete   -"
    Public Function DeleteById(maChiPhieuMuonSach As String) As Result
        Dim query = String.Format("
delete from ChiTietPhieuMuonSach
where MaChiTietPhieuMuonSach={0}", maChiPhieuMuonSach)
        Return _dataProvider.ExecuteNonquery(query)
    End Function
#End Region

#Region "-   Retrieve data    -"

    Public Function selectAllByMaphieumuonsach(listChitietphieumuonsach As List(Of ChiTietPhieuMuonSach), maPhieuMuonSach As String) As Result
        Dim query = String.Empty
        query = String.Format("select * from chiTietPhieuMuonSach where MaPhieuMuonSach={0} and DeleteFlag='N'",
                                maPhieuMuonSach)
        Dim DataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, DataTable)
        For Each row In DataTable.Rows
            Dim chiTietPhieuMuonSach = New ChiTietPhieuMuonSach(row)
            listChitietphieumuonsach.Add(chiTietPhieuMuonSach)
        Next
        Return result
    End Function

    Public Function GetTheLastID(ByRef maChiTietPhieuMuonSach As String) As Result
        Dim query = String.Format("select top 1 [MaChiTietPhieuMuonSach]
from ChiTietPhieuMuonSach
ORDER by [MaChiTietPhieuMuonSach] desc")
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            maChiTietPhieuMuonSach = row("MaChiTietPhieuMuonSach")
        Next
        Return result
    End Function

    Public Function SelectAllBorrowsByReaderId(readerId As String, ByRef listCTPM As List(Of ChiTietPhieuMuonSach)) As Result
        Dim qr = String.Format("
select *
from PhieuMuonSach pms, ChiTietPhieuMuonSach ctpm, TheDocGia tdg
where tdg.MaTheDocGia= pms.MaTheDocGia
and tdg.MaTheDocGia = N'{0}'
and pms.MaPhieuMuonSach = ctpm.MaPhieuMuonSach
and ctpm.TinhTrang =0", readerId)

        Dim tb = New DataTable()
        Dim rs = _dataProvider.ExecuteQuery(qr, tb)
        For Each r In tb.Rows
            Dim temp = New ChiTietPhieuMuonSach(r)
            listCTPM.Add(temp)
        Next

        Return rs
    End Function

    Public Function ReturnBookByPhieuMuonSachIdAndBookId(phieuMuonId As String, sachId As String, ngayTra As Date) As Result
        Dim formatDate = DateHelper.Instance.GetFormatType()
        Dim qr = String.Format("EXECUTE dbo.ReturnBookByPhieuMuonIdAndBookId {0}, {1}, '{2}' ",
                               phieuMuonId, sachId, ngayTra.ToString(formatDate))
        Return _dataProvider.ExecuteNonquery(qr)
    End Function

    Public Function GetByID(ByRef chiTietPhieuMuonSach As ChiTietPhieuMuonSach, id As String) As Result
        Dim query = String.Format("Select *
    from ChiTietPhieuMuonSach
    where MaChiTietPhieuMuonSach={0}", id)
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            chiTietPhieuMuonSach = New ChiTietPhieuMuonSach(row)
        Next
        Return result
    End Function

#End Region

End Class
