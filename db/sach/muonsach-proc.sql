use master
GO
use QuanLiThuVien
go

-- create producer insert phieumuonsach
create PROC USP_ThemPhieuMuonSach
    @MaPhieuMuonSach int,
    @MaTheDocGia int,
    @NgayMuon date,
    @HanTra date,
    @TongSoSachMuon int
as
BEGIN
    insert into dbo.PhieuMuonSach
        (MaPhieuMuonSach,MaTheDocGia,NgayMuon,HanTra,TongSoSachMuon)
    Values
        (@MaPhieuMuonSach, @MaTheDocGia, @NgayMuon, @HanTra, @TongSoSachMuon)
END
go

--create procduer insert chitietphieumuonsach
create PROC USP_ThemChiTietPhieuMuonSach
    @MaPhieuMuonSach INT,
    @MaSach Int
as
BEGIN
    insert into dbo.ChiTietPhieuMuonSach
        (MaPhieuMuonSach,MaSach)
    Values
        (@MaPhieuMuonSach, @MaSach)
    update PhieuMuonSach set TongSoSachMuon=  (  select pms.TongSoSachMuon from PhieuMuonSach pms where pms.MaPhieuMuonSach= @MaPhieuMuonSach) + 1 
END
go


-- get sach procs
-- create proc get info sach for rent
create PROC USP_GetInfoBookForRent
	@MaDauSach NVARCHAR(50)
as
begin
	select cs.TinhTrang, tg.TenTacGia, cs.MaSach, cs.MaDauSach, tls.TenTheLoaiSach, ds.TenSach
	from Sach cs,DauSach ds, TheLoaiSach tls, TacGia tg
	where cs.MaDauSach = ds.MaDauSach
	and cs.MaDauSach= @MaDauSach
	and tls.MaTheLoaiSach= ds.MaTheLoaiSach 
	and tg.MaTacGia = ds.MaTacGia
end
go


-- Create a new stored procedure called 'USP_CountCuonSachBaseOnDauSachId' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'USP_CountCuonSachBaseOnDauSachId'
)
DROP PROC dbo.USP_CountCuonSachBaseOnDauSachId
GO
-- Create the stored procedure in the specified schema
CREATE PROC dbo.USP_CountCuonSachBaseOnDauSachId
    @MaDauSach NVARCHAR(20)
AS
    SELECT COUNT(s.MaSach) as soLuong
    from Sach s, DauSach ds
    WHERE s.MaDauSach = ds.MaDauSach
    and s.MaDauSach = @MaDauSach
    and s.TinhTrang= 0
    and s.DeleteFlag =N'N'
    and ds.DeleteFlag=N'N'
GO
-- example to execute the stored procedure we just created
EXECUTE dbo.USP_CountCuonSachBaseOnDauSachId 1
GO

-- Create a new stored procedure called 'USP_getPhieuMuonSachNotPayByDocGiaId' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'USP_getPhieuMuonSachNotPayByDocGiaId'
)
DROP PROCEDURE dbo.USP_getPhieuMuonSachNotPayByDocGiaId
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.USP_getPhieuMuonSachNotPayByDocGiaId
    @maTheDocGia /*parameter name*/ NVARCHAR(20)
AS
    -- body of the stored procedure
    SELECT * FROM dbo.PhieuMuonSach
    WHERE maTheDocGia=@maTheDocGia AND TinhTrang=0 and DeleteFlag=N'N'	/* add search conditions here */
    GO
GO
-- example to execute the stored procedure we just created
EXECUTE dbo.USP_getPhieuMuonSachNotPayByDocGiaId 19000000 
GO

-- Select rows from a Table or View 'PhieuMuonSach' in schema 'dbo'

-- Create a new stored procedure called 'USP_SelectTacGiaAndTenSachByCuonSachId' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'USP_SelectTacGiaAndTenSachByCuonSachId'
)
DROP PROCEDURE dbo.USP_SelectTacGiaAndTenSachByCuonSachId
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.USP_SelectTacGiaAndTenSachByCuonSachId
    @maSach NVARCHAR(20)
AS
-- Select rows from a Table or View 'sach' in schema 'dbo'
SELECT ds.TenSach, tg.TenTacGia, ds.MaDauSach
    from Sach s, DauSach ds, TacGia tg
    WHERE s.MaDauSach = ds.MaDauSach
    and tg.MaTacGia = ds.MaTacGia
    and s.MaSach = @maSach
GO
-- example to execute the stored procedure we just created
EXECUTE dbo.USP_SelectTacGiaAndTenSachByCuonSachId 1
GO  



-- Create a new stored procedure called 'SelectRentSachByDocGiaId' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'SelectRentSachByDocGiaId'
)
DROP PROCEDURE dbo.SelectRentSachByDocGiaId
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.SelectRentSachByDocGiaId
    @docGiaId NVARCHAR(20)
AS
    select ds.MaDauSach, s.MaSach, ds.TenSach, ds.TenNhaXuatBan, ctpm.TinhTrang,pms.NgayMuon, ctpm.NgayTra, qd.SoNgayMuonToiDa,tg.TenTacGia, pms.MaPhieuMuonSach, ctpm.MaChiTietPhieuMuonSach
    from PhieuMuonSach pms, TheDocGia dg, ChiTietPhieuMuonSach ctpm, sach s, DauSach ds, QuiDinh qd, TacGia tg
    where
        pms.MaPhieuMuonSach = ctpm.MaPhieuMuonSach
        and pms.MaTheDocGia = dg.MaTheDocGia
        and dg.MaTheDocGia= @docGiaId
        and ctpm.MaSach= s.MaSach
        and s.MaDauSach= ds.MaDauSach
		and tg.MaTacGia =ds.MaTacGia
        and pms.TinhTrang=0
        and ctpm.TinhTrang=0
        and pms.DeleteFlag='N'

GO
