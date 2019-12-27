-- Create a new stored procedure called 'USP_CountSlMuon' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'USP_CountSlMuon'
)
DROP PROCEDURE dbo.USP_CountSlMuon
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.USP_CountSlMuon
    @Thang as Date
AS
    SELECT COUNT(ctpms.MaChiTietPhieuMuonSach) SoLuotMuon
    from PhieuMuonSach pms, ChiTietPhieuMuonSach ctpms
    where ctpms.TinhTrang=1
	and ctpms.MaPhieuMuonSach = pms.MaPhieuMuonSach 
    and MONTH(ctpms.NgayTra) = MONTH(@Thang)
    and Year(ctpms.NgayTra) = Year(@Thang)
GO
-- example to execute the stored procedure we just created
EXECUTE dbo.USP_CountSlMuon '2019-12-01'
GO


EXECUTE dbo.USP_CountSlMuon '2019-12-02'
