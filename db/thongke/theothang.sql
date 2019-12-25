-- Create a new stored procedure called 'USP_GetSoLuongSachMuonByMaTheLoaiSachAndThoiGian' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'USP_GetSoLuongSachMuonByMaTheLoaiSachAndThoiGian'
)
DROP PROCEDURE dbo.USP_GetSoLuongSachMuonByMaTheLoaiSachAndThoiGian
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.USP_GetSoLuongSachMuonByMaTheLoaiSachAndThoiGian
-- add more stored procedure parameters here
AS
    -- body of the stored procedure
GO
-- example to execute the stored procedure we just created
EXECUTE dbo.USP_GetSoLuongSachMuonByMaTheLoaiSachAndThoiGian 3
GO

select COUNT(DISTINCT(ctpms.MaChiTietPhieuMuonSach)) as SoLuotMuon
from PhieuMuonSach pms,ChiTietPhieuMuonSach ctpms, dausach ds, sach s
where ctpms.DeleteFlag='N' and s.DeleteFlag='N' and pms.DeleteFlag='N'
and pms.MaPhieuMuonSach=ctpms.MaPhieuMuonSach and ctpms.MaSach=s.MaSach
and ds.MaTheLoaiSach=1 and Year(pms.NgayMuon)='2019' and MONTH(pms.NgayMuon)='12'
and ds.MaDauSach = s.MaDauSach

select COUNT(DISTINCT(ctpms.MaChiTietPhieuMuonSach)) as SoLuotMuon
from PhieuMuonSach pms,ChiTietPhieuMuonSach ctpms, sach s, DauSach ds
where ctpms.DeleteFlag='N' and s.DeleteFlag='N' and pms.DeleteFlag='N' and ds.DeleteFlag='N'
and ds.MaDauSach= s.MaDauSach
and pms.MaPhieuMuonSach=ctpms.MaPhieuMuonSach and ctpms.MaSach=s.MaSach
and ds.MaTheLoaiSach={0} and Year(pms.NgayMuon)='{1}' and MONTH(pms.NgayMuon)='{2}'