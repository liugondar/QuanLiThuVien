-- Create a new database called 'QLHS'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
WHILE EXISTS(select NULL
from sys.databases
where name='QuanLiThuVien')
BEGIN
    DECLARE @SQL varchar(max)
    SELECT @SQL = COALESCE(@SQL,'') + 'Kill ' + Convert(varchar, SPId) + ';'
    FROM MASTER..SysProcesses
    WHERE DBId = DB_ID(N'QLHS') AND SPId <> @@SPId
    EXEC(@SQL)
    DROP DATABASE [QuanLiThuVien]
END
GO
CREATE DATABASE QuanLiThuVien
GO

USE QuanLiThuVien
Go
-- Create a new table called 'LoaiDocGia' in schema 'SchemaName'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.LoaiDocGia', 'U') IS NOT NULL
DROP TABLE dbo.LoaiDocGia
GO
-- Create the table in the specified schema
CREATE TABLE dbo.LoaiDocGia
(
    LoaiDocGiaId INT IDENTITY PRIMARY KEY,
    -- primary key column
    TenLoaiDocGia NVARCHAR(10)
);
GO

-- Create a new table called 'DocGia' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.DocGia', 'U') IS NOT NULL
DROP TABLE dbo.TheDocGia
GO
-- Create the table in the specified schema
CREATE TABLE dbo.TheDocGia
(
    TheDocGiaId INT IDENTITY ,
    -- primary key column
    TenDocGia NVARCHAR( 50 ) not null,
    TenNguoiTao NVARCHAR(50) DEFAULT N'User',
    Email NVARCHAR(50) not null,
    DiaChi NVARCHAR(50),
    LoaiDocGiaId INT not null,
    NgaySinh date not null DEFAULT GETDATE(),
    NgayTao date not null DEFAULT GETDATE(),
    NgayHetHan date not null
        CONSTRAINT PK_Reader PRIMARY KEY (DocGiaId,TenDocGia),
    CONSTRAINT FK_Reader_ReaderType FOREIGN KEY(LoaiDocGiaId) REFERENCES LoaiDocGia(LoaiDocGiaId)
);
GO

-- Create a new table called 'qui dinh' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.QuiDinh', 'U') IS NOT NULL
DROP TABLE dbo.QuiDinh
GO
-- Create the table in the specified schema
CREATE TABLE dbo.QuiDinh
(
    TuoiToiDa int not null,
    TuoiToiThieu int not null,
    ThoiHanToiDaTheDocGia int not null--month
);
GO

--create producer insert Reader
CREATE PROC USP_ThemTheDocGia
    @TenDocGia NVARCHAR(50),
    @TenNguoiTao NVARCHAR(50),
    @Email NVARCHAR(50),
    @DiaChi NVARCHAR(50),
    @LoaiDocGiaId INT ,
    @NgaySinh date ,
    @NgayTao date,
    @NgayHetHan date
AS
BEGIN
    insert into dbo.DocGia
        (TenDocGia,TenNguoiTao,Email,DiaChi,LoaiDocGiaId,
        NgaySinh,NgayTao,NgayHetHan)
    VALUES
        (@TenDocGia, @TenNguoiTao, @Email, @DiaChi, @LoaiDocGiaId,
            @NgaySinh, @NgayTao, @NgayHetHan)
END
go

INSERT INTO dbo.QuiDinh
    (TuoiToiDa,TuoiToiThieu,ThoiHanToiDaTheDocGia)
VALUES(55, 18, 6)

INSERT into LoaiDocGia
    (TenLoaiDocGia)
VALUES('X')
INSERT into LoaiDocGia
    (TenLoaiDocGia)
VALUES('Y')