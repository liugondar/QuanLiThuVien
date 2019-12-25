use master
GO
use QuanLiThuVien
go
--create producer insert dau sach sach
create PROC USP_NhapSach
    @MaDauSach NVARCHAR(20),
    @TenSach NVARCHAR(50),
    @MaTheLoaiSach int,
    @MaTacGia int,
    @TenNhaXuatBan NVARCHAR(50),
    @NgayXuatBan date,
    @TriGia INT,
    @SoLuong int
AS
BEGIN
    insert into dbo.DauSach
        (MaDauSach,TenSach,MaTheLoaiSach,MaTacGia,TenNhaXuatBan,NgayXuatBan,TriGia, SoLuong)
    VALUES(@MaDauSach, @TenSach, @MaTheLoaiSach, @MaTacGia, @TenNhaXuatBan, @NgayXuatBan,  @TriGia, @SoLuong)
END
GO

-- sach
--create producer insert sach
create PROC USP_NhapCuonSach
    @MaSach NVARCHAR(50),
    @MaDauSach NVARCHAR(20),
    @NgayNhap  date,
    @TinhTrang INT
AS
BEGIN
    insert into dbo.Sach
        (MaSach, MaDauSach, TinhTrang, NgayNhap )
    VALUES(@MaSach, @MaDauSach, @TinhTrang, @NgayNhap)
END
GO

-- Create a new stored procedure called 'UpdateCuonSachQuanlity' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'UpdateCuonSachQuanlity'
)
DROP PROCEDURE dbo.UpdateCuonSachQuanlity
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.UpdateCuonSachQuanlity
    @MaDauSach NVARCHAR(50),
    @SoLuong INT
AS
    update DauSach
    SET SoLuong= @SoLuong
    where MaDauSach= @MaDauSach
GO
-- example to execute the stored procedure we just created
EXECUTE dbo.UpdateCuonSachQuanlity 1, 6
GO

<<<<<<< HEAD
Select * from sach where MaSach=N'3'and DeleteFlag= N'N' 
=======
Select * from sach where MaSach=N'3'and DeleteFlag= N'N' 
>>>>>>> loc
