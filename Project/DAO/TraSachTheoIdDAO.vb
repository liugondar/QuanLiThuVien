Imports DAO
Imports DTO
Imports Utility
Public Class TraSachTheoIdDAO
    Private Sub New()
    End Sub

    Public Shared ReadOnly Property Instance As TraSachTheoIdDAO
        Get
            Static INST As TraSachTheoIdDAO = New TraSachTheoIdDAO
            Return INST
        End Get
    End Property

    Function GetInfoBookLentByReaderId(readerId As String, ByRef maPhieuMuonSach As String, ByRef maSach As String, ByRef tenSach As String, ByRef ngayMuon As Date) As Result
        Dim qr = String.Format("
select pms.MaPhieuMuonSach, cs.MaSach, ds.TenSach, pms.NgayMuon
from PhieuMuonSach pms, ChiTietPhieuMuonSach ctpm, TheDocGia tdg, Sach cs, DauSach ds
where tdg.MaTheDocGia= pms.MaTheDocGia
and tdg.MaTheDocGia = N'{0}' 
and pms.MaPhieuMuonSach = ctpm.MaPhieuMuonSach
and ctpm.TinhTrang =0
and cs.MaDauSach = ds.MaDauSach
and ctpm.MaSach= cs.MaSach
", readerId)

        Dim tb = New DataTable()

        Dim rs = DataProvider.Instance.ExecuteQuery(qr, tb)


        For Each row In tb.Rows
            maPhieuMuonSach = row("MaPhieuMuonSach")
            tenSach = row("TenSach")
            maSach = row("MaSach")
            Date.TryParse(row("NgayMuon"), ngayMuon)
        Next
        Return New Result
    End Function

    Public Function GetInfoBookLentByReaderId(readerId As String, ByRef listBook As List(Of CustomBookInfoDisplay)) As Result
        Dim qr = String.Format("

select pms.MaPhieuMuonSach, cs.MaSach, ds.TenSach, pms.NgayMuon, ds.MaDauSach, pms.HanTra NgayHetHan, tg.TenTacGia
from PhieuMuonSach pms, ChiTietPhieuMuonSach ctpm, TheDocGia tdg, Sach cs, DauSach ds, TacGia tg
where tdg.MaTheDocGia= pms.MaTheDocGia
and tdg.MaTheDocGia = N'{0}' 
and pms.MaPhieuMuonSach = ctpm.MaPhieuMuonSach
and ctpm.TinhTrang =0
and cs.MaDauSach = ds.MaDauSach
and ctpm.MaSach= cs.MaSach
and tg.MaTacGia= ds.MaTacGia

", readerId)

        Dim tb = New DataTable()

        Dim rs = DataProvider.Instance.ExecuteQuery(qr, tb)

        For Each row In tb.Rows
            Dim temp = New CustomBookInfoDisplay()
            temp.MaPhieuMuonSach = row("MaPhieuMuonSach")
            temp.TenSach = row("TenSach")
            temp.MaCuonSach = row("MaSach")
            temp.TacGia = row("TenTacGia")
            Date.TryParse(row("NgayMuon"), temp.NgayMuon)
            Date.TryParse(row("NgayHetHan"), temp.NgayHetHan)
            listBook.Add(temp)
        Next
        Return New Result
    End Function
End Class