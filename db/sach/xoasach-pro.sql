use master
go
use QuanLiThuVien
go

-- Create a new stored procedure called 'GetAllInfoBookByCuonSachId' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'GetAllInfoBookByCuonSachId'
)
DROP PROCEDURE dbo.GetAllInfoBookByCuonSachId
GO

CREATE PROCEDURE dbo.GetAllInfoBookByCuonSachId
    @MaCuonSach NVARCHAR(20)
AS
    select *
    from dbo.Sach s, DauSach ds
    where s.MaDauSach= ds.MaDauSach
    and s.MaSach= @MaCuonSach
    and ds.DeleteFlag = N'N'
GO


-- Create a new stored procedure called 'USP_XoaDauSach' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'USP_XoaDauSach'
)
DROP PROCEDURE dbo.USP_XoaDauSach
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.USP_XoaDauSach
    @MaDauSach NVARCHAR(50)
AS
    update DauSach
    set DeleteFlag=N'Y'
    where MaDauSach=@MaDauSach

    update Sach
    set DeleteFlag=N'Y'
    from Sach as s
        INNER JOIN DauSach as ds
        on s.MaDauSach = ds.MaDauSach
        and ds.MaDauSach= @MaDauSach
GO