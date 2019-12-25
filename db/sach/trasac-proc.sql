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
    select ds.MaDauSach, s.MaSach, ds.TenSach, ds.TenNhaXuatBan,ctpm.TinhTrang,pms.NgayMuon, ctpm.NgayTra, qd.SoNgayMuonToiDa,tg.TenTacGia, pms.MaPhieuMuonSach, ctpm.MaChiTietPhieuMuonSach
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



-- Create a new stored procedure called 'ReturnAllBookByPhieuMuonId' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'ReturnAllBookByPhieuMuonId'
)
DROP PROCEDURE dbo.ReturnAllBookByPhieuMuonId
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.ReturnAllBookByPhieuMuonId
    @MaPhieuMuonSach NVARCHAR(20),
    @ReturnDate DATETIME
AS
    update PhieuMuonSach
    set TinhTrang=1
    where MaPhieuMuonSach= @MaPhieuMuonSach

    update 
        ChiTietPhieuMuonSach
    set 
        TinhTrang=1,
        NgayTra = @ReturnDate    
    from 
        ChiTietPhieuMuonSach as ctpms
        INNER JOIN PhieuMuonSach as pms
        on ctpms.MaPhieuMuonSach= pms.MaPhieuMuonSach
    where pms.MaPhieuMuonSach=@MaPhieuMuonSach
GO
-- example to execute the stored procedure we just created
EXECUTE dbo.ReturnAllBookByPhieuMuonId 1 , '2019-12-01'
GO

-- Create a new stored procedure called 'ReturnBookByPhieuMuonIdAndBookId' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'ReturnBookByPhieuMuonIdAndBookId'
)
DROP PROCEDURE dbo.ReturnBookByPhieuMuonIdAndBookId
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.ReturnBookByPhieuMuonIdAndBookId
-- add more stored procedure parameters here
    @MaPhieuMuonSach NVARCHAR(20),
    @MaSach NVARCHAR(20),
    @ReturnDate DATE
AS
    update 
        ChiTietPhieuMuonSach
    set 
        TinhTrang=1,
        NgayTra = @ReturnDate    
    from 
        ChiTietPhieuMuonSach as ctpms
        INNER JOIN PhieuMuonSach as pms
            on ctpms.MaPhieuMuonSach= pms.MaPhieuMuonSach
        INNER JOIN Sach as s
            on ctpms.MaSach= s.MaSach
    where pms.MaPhieuMuonSach=@MaPhieuMuonSach 
    and s.MaSach= @MaSach
GO
-- example to execute the stored procedure we just created
EXECUTE dbo.ReturnBookByPhieuMuonIdAndBookId 3, 2, '2019-12-20' 
GO

select * from ChiTietPhieuMuonSach