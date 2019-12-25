use master
go

use QuanLiThuVien
go


select * from PhieuMuonSach
SELECT * from ChiTietPhieuMuonSach

-- Create a new stored procedure called 'GetThongMuonTre' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'GetThongMuonTre'
)
DROP PROCEDURE dbo.GetThongMuonTre
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.GetThongMuonTre
    @Month as DATE
AS
    select 
    dg.TenDocGia, dg.MaTheDocGia, pms.NgayMuon, ctpm.NgayTra, ds.TenSach,
    pms.MaPhieuMuonSach, ctpm.MaSach, DATEDIFF(DAY,pms.NgayMuon,ctpm.NgayTra) NgayTraTre, ds.MaDauSach
    from ChiTietPhieuMuonSach ctpm , PhieuMuonSach pms, QuiDinh qd, TheDocGia dg, DauSach ds, sach s
    where pms.MaPhieuMuonSach= ctpm.MaPhieuMuonSach
    and dg.MaTheDocGia= pms.MaTheDocGia
    and s.MaDauSach= ds.MaDauSach
    and s.MaSach= ctpm.MaSach
    and MONTH(@Month) = MONTH(pms.HanTra)
    and (
        DATEDIFF(DAY,CAST( pms.NgayMuon as date),CAST( NgayTra as date)) >qd.SoNgayMuonToiDa
    )

GO
-- example to execute the stored procedure we just created
EXECUTE dbo.GetThongMuonTre '2019-12-01'
GO

 EXECUTE dbo.GetThongMuonTre '2019-12-25'