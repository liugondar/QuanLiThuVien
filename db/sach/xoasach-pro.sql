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
-- example to execute the stored procedure we just created
EXECUTE dbo.GetAllInfoBookByCuonSachId 1
GO


select * from Sach
select * from DauSach

'