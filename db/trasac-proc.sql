USE master
go
use QuanLiThuVien
go
-- Create a new stored procedure called 'USP_SelectRentInfo' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'USP_SelectRentInfo'
)
DROP PROCEDURE dbo.USP_SelectRentInfo
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.USP_SelectRentInfo
    @MaPhieuMuonSach NVARCHAR(20)
AS
    select ds.MaDauSach, s.MaSach, ds.TenSach, ds.TenNhaXuatBan,ctpm.TinhTrang,pms.NgayMuon, pms.NgayTra, qd.SoNgayMuonToiDa,tg.TenTacGia, pms.MaPhieuMuonSach, ctpm.MaChiTietPhieuMuonSach
    from PhieuMuonSach pms, TheDocGia dg, ChiTietPhieuMuonSach ctpm, sach s, DauSach ds, QuiDinh qd, TacGia tg
    where
        pms.MaPhieuMuonSach = ctpm.MaPhieuMuonSach
        and pms.MaTheDocGia = dg.MaTheDocGia
        and ctpm.MaSach= s.MaSach
        and s.MaDauSach= ds.MaDauSach
		and tg.MaTacGia =ds.MaTacGia
        and pms.DeleteFlag='N'
        and pms.MaPhieuMuonSach= @MaPhieuMuonSach
GO

-- example to execute the stored procedure we just created
EXECUTE dbo.USP_SelectRentInfo 2
GO

select * from PhieuMuonSach
select * from ChiTietPhieuMuonSach

select * from PhieuMuonSach