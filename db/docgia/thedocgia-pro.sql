-- Create a new stored procedure called 'USP_DemSoLuongSachMuonByTheDocGiaID' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'USP_DemSoLuongSachMuonByTheDocGiaID'
)
DROP PROCEDURE dbo.USP_DemSoLuongSachMuonByTheDocGiaID
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.USP_DemSoLuongSachMuonByTheDocGiaID
    @MaTheDocGia NVARCHAR(50)
AS
    select count(ctpm.MaChiTietPhieuMuonSach) SachDangMuon
    from PhieuMuonSach pms, TheDocGia dg, ChiTietPhieuMuonSach ctpm
    where dg.MaTheDocGia= pms.MaTheDocGia
    and pms.MaPhieuMuonSach = ctpm.MaPhieuMuonSach
    and dg.MaTheDocGia=  @MaTheDocGia
GO
-- example to execute the stored procedure we just created
EXECUTE dbo.USP_DemSoLuongSachMuonByTheDocGiaID 19000000 
GO


