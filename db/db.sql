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
    WHERE DBId = DB_ID(N'[QuanLiThuVien]') AND SPId <> @@SPId
    EXEC(@SQL)
    DROP DATABASE [QuanLiThuVien]
END
GO
CREATE DATABASE QuanLiThuVien
GO

USE QuanLiThuVien
Go


-- Create a new table called 'Account' in schema 'SchemaName'
-- Drop the table if it already exists
-- Create the table in the specified schema
CREATE TABLE Account
(
    AccountId INT IDENTITY ,
    -- primary key column
    UserName NVARCHAR(100) not null,
    -- specify more columns here
    DisplayName NVARCHAR(100) NOT NULL default N'Nhan vien',
    Password NVARCHAR(1000) not NULL DEFAULT 0,
    salt NVARCHAR(1000) ,
    Type int NOT null DEFAULT 0,
    -- 0 is nhan vien, 1 is admin
    CONSTRAINT PK_Acount PRIMARY key(AccountId,UserName)
);
GO
-- Create a new table called 'LoaiDocGia' in schema 'SchemaName'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.LoaiDocGia', 'U') IS NOT NULL
DROP TABLE dbo.LoaiDocGia
GO
-- Create the table in the specified schema
CREATE TABLE dbo.LoaiDocGia
(
    MaLoaiDocGia INT IDENTITY PRIMARY KEY,
    -- primary key column
    DeleteFlag NVARCHAR(1) not null default 'N',
    TenLoaiDocGia NVARCHAR(10)
);
GO

-- Create a new table called 'DocGia' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.TheDocGia', 'U') IS NOT NULL
DROP TABLE dbo.TheDocGia
GO
-- Create the table in the specified schema
CREATE TABLE dbo.TheDocGia
(
    MaTheDocGia NVARCHAR(20) Primary Key NOT NULL,
    -- primary key column
    TenDocGia NVARCHAR( 50 ) not null,
    Email NVARCHAR(50) not null,
    DiaChi NVARCHAR(50),
    MaLoaiDocGia INT not null,
    NgaySinh date not null DEFAULT GETDATE(),
    NgayTao date not null DEFAULT GETDATE(),
    NgayHetHan date not null,
    DeleteFlag NVARCHAR(1) not null default 'N',
    CONSTRAINT FK_Reader_ReaderType FOREIGN KEY(MaLoaiDocGia) REFERENCES LoaiDocGia(MaLoaiDocGia)
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
    ThoiHanToiDaTheDocGia int not null,--month
    ThoiHanNhanSach int not null,
    --year
    SoNgayMuonToiDa int not null,
    SoSachMuonToiDa int not null
);
GO

-- Create a new table called 'TacGia' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.TacGia', 'U') IS NOT NULL
DROP TABLE dbo.TacGia
GO
-- Create the table in the specified schema
CREATE TABLE dbo.TacGia
(
    MaTacGia INT IDENTITY PRIMARY KEY,
    -- primary key column
    TenTacGia NVARCHAR(50) not null default N'TenTacGia',
    DeleteFlag NVARCHAR(1) not null default 'N',
);
GO

-- Create a new table called 'TheLoai' in schema 'SchemaName'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.TheLoaiSach', 'U') IS NOT NULL
DROP TABLE dbo.TheLoaiSach
GO
-- Create the table in the specified schema
CREATE TABLE dbo.TheLoaiSach
(
    MaTheLoaiSach INT IDENTITY PRIMARY KEY,
    -- primary key column
    TenTheLoaiSach NVARCHAR(50) not null DEFAULT N'TenLoaiSach',
    DeleteFlag NVARCHAR(1) not null default 'N',
);
GO

-- Create a new tabcalled 'Sach' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.DauSach', 'U') IS NOT NULL
DROP TABLE dbo.DauSach
GO
-- Create the table in the specified schema
CREATE TABLE dbo.DauSach
(
	MaDauSach varchar(50) NOT NULL PRIMARY KEY,
	MaTheLoaiSach Int not null,
    MaTacGia Int not null,
    TenNhaXuatBan NVARCHAR(50) not null default N'TenNXB',
    TenSach NVARCHAR(50) not null default N'TenSach',
    NgayXuatBan date not null DEFAULT getdate(),
    NgayNhap date not null DEFAULT getdate(),
    TriGia INT not null DEFAULT 0,
    DeleteFlag NVARCHAR(1) not null default 'N',
    CONSTRAINT FK_DauSach_TacGia FOREIGN KEY(MaTacGia) REFERENCES TacGia(MaTacGia),
    CONSTRAINT FK_DauSach_TheLoaiSach FOREIGN KEY(MaTheLoaiSach) REFERENCES TheLoaiSach(MaTheLoaiSach),
);
GO

IF OBJECT_ID('dbo.Sach', 'U') IS NOT NULL
DROP TABLE dbo.Sach
GO
-- Create the table in the specified schema

CREATE TABLE dbo.Sach
(
    MaSach NVARCHAR(20) NOT NUll PRIMARY KEY,
    -- primary key column
	MaDauSach varchar(50) NOT NULL,
	 TinhTrang INT not null DEFAULT 0,-- 0 la con, 1 la het 
         DeleteFlag NVARCHAR(1) not null default 'N',

	 CONSTRAINT FK_Sach_DauSach FOREIGN KEY(MaDauSach) REFERENCES DauSach(MaDauSach),

);
GO
-- Create a new table called 'PhieuMuonSach' in schema 'SchemaName'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.PhieuMuonSach', 'U') IS NOT NULL
DROP TABLE dbo.PhieuMuonSach
GO
-- Create the table in the specified schema
CREATE TABLE dbo.PhieuMuonSach
(
    MaPhieuMuonSach INT NOT NULL PRIMARY KEY,
    -- primary key column
    MaTheDocGia NVARCHAR(20) NOT NULL,
    NgayMuon[date] NOT NULL default GETDATE(),
    NgayTra[date] ,
    HanTra[date] NOT NULL DEFAULT getdate(),
    TongSoSachMuon int NOT NULL DEFAULT 1,
    TinhTrang int not null DEFAULT 0,-- 0 is not check out, 1 is check out 
    DeleteFlag NVARCHAR(1) not null default 'N',
    CONSTRAINT FK_PhieuMuonSach_TheDocGia FOREIGN KEY(MaTheDocGia)
    REFERENCES TheDocGia(MaTheDocGia)
);
GO

-- Create a new table called 'ChiTietPhieuMuonSach' in schema 'SchemaName'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.ChiTietPhieuMuonSach', 'U') IS NOT NULL
DROP TABLE dbo.ChiTietPhieuMuonSach
GO
-- Create the table in the specified schema
CREATE TABLE dbo.ChiTietPhieuMuonSach
(
    MaChiTietPhieuMuonSach INT IDENTITY NOT NULL PRIMARY KEY,
    -- primary key column
    MaPhieuMuonSach INT NOT NULL,
    MaSach NVARCHAR(20) not null,
    TinhTrang int not null DEFAULT 0,-- 0 is not check out, 1 is check out 
    DeleteFlag NVARCHAR(1) not null default 'N',
    CONSTRAINT FK_ChiTietPhieuMuonSach_PhieuMuonSach FOREIGN KEY(MaPhieuMuonSach)
    REFERENCES PhieuMuonSach(MaPhieuMuonSach),
    CONSTRAINT FK_ChiTietPhieuMuonSach_MaSach FOREIGN KEY(MaSach)
    REFERENCES Sach(MaSach),

);
GO

-- Create a new table called 'BaoCaoTinhHinhMuonSachTheoTheLoai' in schema 'SchemaName'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.BaoCaoTinhHinhMuonSachTheoTheLoai', 'U') IS NOT NULL
DROP TABLE dbo.BaoCaoTinhHinhMuonSachTheoTheLoai
GO
-- Create the table in the specified schema
CREATE TABLE dbo.BaoCaoTinhHinhMuonSachTheoTheLoai
(
    MaBaoCaoTinhHinhMuonSachTheoTheLoai INT IDENTITY NOT NULL PRIMARY KEY,
    -- primary key column
    ThoiGian date not null default getdate(),
    DeleteFlag NVARCHAR(1) not null default 'N',
    TongSoLuotMuon int not null default 0
);
GO

-- Create a new table called 'ChiTietBaoCaoTinhHinhMuonSach' in schema 'SchemaName'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.ChiTietBaoCaoTinhHinhMuonSachTheotheLoai', 'U') IS NOT NULL
DROP TABLE dbo.ChiTietBaoCaoTinhHinhMuonSachTheotheLoai
GO
-- Create the table in the specified schema
CREATE TABLE dbo.ChiTietBaoCaoTinhHinhMuonSachTheotheLoai
(
    MaChiTietBaoCaoTinhHinhMuonSachTheoTheLoai INT IDENTITY NOT NULL PRIMARY KEY,
    -- primary key column
    MaBaoCaoTinhHinhMuonSachTheoTheLoai int not null,
    MaTheLoaiSach int not null ,
    SoLuongMuon int not null DEFAULT 0,
    TiLe FLOAT not null default 0,
    DeleteFlag NVARCHAR(1) not null default 'N',
    CONSTRAINT FK_ChiTietBaoCaoTinhHinhMuonSach_BaoCaoTinhHinhMuonSach FOREIGN KEY(MaBaoCaoTinhHinhMuonSachTheoTheLoai)
    REFERENCES BaoCaoTinhHinhMuonSachTheoTheLoai(MaBaoCaoTinhHinhMuonSachTheoTheLoai),
    CONSTRAINT FK_ChiTietBaoCaoTinhHinhMuonSach_TheLoaiSAch FOREIGN KEY(MaTheLoaiSach)
    REFERENCES TheLoaiSach(MaTheLoaiSach),
);
GO

-- Create a new table called 'BaoCaoSachTraTre' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.BaoCaoSachTraTre', 'U') IS NOT NULL
DROP TABLE dbo.BaoCaoSachTraTre
GO
-- Create the table in the specified schema
CREATE TABLE dbo.BaoCaoSachTraTre
(
    MaBaoCaoSachTraTre INT IDENTITY NOT NULL PRIMARY KEY,
    -- primary key column
    ThoiGian date not null DEFAULT getdate(),
    DeleteFlag NVARCHAR(1) not null default 'N',
);
GO

-- Create a new table called 'ChiTietBaoCaoSachTraTre' in schema 'SchemaName'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.ChiTietBaoCaoSachTraTre', 'U') IS NOT NULL
DROP TABLE dbo.ChiTietBaoCaoSachTraTre
GO
-- Create the table in the specified schema
CREATE TABLE dbo.ChiTietBaoCaoSachTraTre
(
    MaChiTietBaoCaoSachTraTre INT NOT NULL IDENTITY PRIMARY KEY,
    -- primary key column
    MaBaoCaoSachTraTre int not null,
    MaChiTietPhieuMuonSach int not null,
    SoNgayTre int not null,
    DeleteFlag NVARCHAR(1) not null default 'N',
    CONSTRAINT FK_ChiTietBaoCaoSachTre_BaoCaoSachTren FOREIGN KEY(MaBaoCaoSachTraTre)
    REFERENCES BaoCaoSachTraTre(MaBaoCaoSachTraTre),
    CONSTRAINT FK_ChiTietBaoCaoSachTre_ChiTietPhieuMuonSach FOREIGN KEY(MaChiTietPhieuMuonSach)
    REFERENCES ChiTietPhieuMuonSach(MaChiTietPhieuMuonSach)
);
GO

Create PROC USP_CreateAccount
    @userName NVARCHAR(100),
    @DisplayName NVARCHAR(100),
    @Password NVARCHAR(1000) ,
    @salt NVARCHAR(1000) ,
    @Type int
AS
BEGIN
    INSERT into Account
        (UserName,DisplayName,[Password],salt,[Type])
    VALUES(@userName, @DisplayName, @Password, @salt, @Type)
END
go

create PROC USP_UpdateAccount
    @AccountId int,
    @newAccountDisplayName NVARCHAR(100),
    @password NVARCHAR(100) ,
    @salt NVARCHAR(100)
as
begin
    update Account SET DisplayName=@newAccountDisplayName, Password=@password , salt=@salt where AccountId=@AccountId
end
go


create PROC USP_getAccountByUserName
    @UserName NVARCHAR(100)
AS
BEGIN
    SELECT *
    from Account
    where UserName=@UserName
end
go

create PROC USP_LOGIN
    @userName NVARCHAR(100),
    @password NVARCHAR(100)
AS
BEGIN
    select *
    from Account
    where UserName=@userName and [Password]=@password
END
GO

--create producer insert Reader
CREATE PROC USP_ThemTheDocGia
    @MaTheDocGia NVARCHAR(20),
    @TenDocGia NVARCHAR(50),
    @Email NVARCHAR(50),
    @DiaChi NVARCHAR(50),
    @MaLoaiDocGia INT ,
    @NgaySinh date ,
    @NgayTao date,
    @NgayHetHan date
AS
BEGIN
    insert into dbo.TheDocGia
        (MaTheDocGia,TenDocGia,Email,DiaChi,MaLoaiDocGia,
        NgaySinh,NgayTao,NgayHetHan)
    VALUES
        (@MaTheDocGia, @TenDocGia, @Email, @DiaChi, @MaLoaiDocGia,
            @NgaySinh, @NgayTao, @NgayHetHan)
END
go

-- create producer delete reader card
CREATE PROC USP_XoaTheDocGia
    @MaTheDocGia INT
AS
BEGIN
    Update TheDocGia
   Set DeleteFlag='Y'
   Where MaTheDocGia=@MaTheDocGia
END
go

CREATE PROC USP_SuaTheDocGia
    @MaTheDocGia INT,
    @TenDocGia NVARCHAR(50),
    @Email NVARCHAR(50),
    @DiaChi NVARCHAR(50),
    @MaLoaiDocGia INT ,
    @NgaySinh date
AS
BEGIN
    Update TheDocGia
   Set TenDocGia=@TenDocGia,Email=@Email,DiaChi=@DiaChi,MaLoaiDocGia=@MaLoaiDocGia,NgaySinh=@NgaySinh
   Where MaTheDocGia=@MaTheDocGia
END
go

--create producer insert sach
create PROC USP_NhapSach
    @MaDauSach NVARCHAR(20),
    @TenSach NVARCHAR(50),
    @MaTheLoaiSach int,
    @MaTacGia int,
    @TenNhaXuatBan NVARCHAR(50),
    @NgayXuatBan date,
    @NgayNhap date,
    @TriGia INT
AS
BEGIN
    insert into dbo.DauSach
        (MaDauSach,TenSach,MaTheLoaiSach,MaTacGia,TenNhaXuatBan,NgayXuatBan,NgayNhap,TriGia)
    VALUES(@MaDauSach, @TenSach, @MaTheLoaiSach, @MaTacGia, @TenNhaXuatBan, @NgayXuatBan, @NgayNhap, @TriGia)
END
GO

-- sach
--create producer insert sach
create PROC USP_NhapCuonSach
    @MaSach NVARCHAR(50),
    @MaDauSach NVARCHAR(20),
    @TinhTrang INT
AS
BEGIN
    insert into dbo.Sach
        (MaSach, MaDauSach, TinhTrang)
    VALUES(@MaSach, @MaDauSach, @TinhTrang)
END
GO
USE QuanLiThuVien
Go


--create procducer insert baocaotinhhinhmuonsachtheotheloai
create PROC USP_NhapBaoCaoTinhHinhMuonSachTheoTheLoai
    @ThoiGian date
as
BEGIN
    insert into dbo.BaoCaoTinhHinhMuonSachTheoTheLoai
        (ThoiGian)
    VALUES(@ThoiGian)
END
go

create proc USP_UpdateSoLuongSachMuonTheoTheLoai
    @MaBaoCaoTinhHinhMuonSachTheoTheLoai int,
    @TongSoLuotMuon int
as
BEGIN
    update dbo.BaoCaoTinhHinhMuonSachTheoTheLoai
    Set TongSoLuotMuon=@TongSoLuotMuon
    where MaBaoCaoTinhHinhMuonSachTheoTheLoai=@MaBaoCaoTinhHinhMuonSachTheoTheLoai
        and DeleteFlag='N'
END
go

go
create proc USP_UpdateTiLeChiTietBaoCaoTheoTheLoai
    @MaChiTietBaoCaoTinhHinhMuonSachTheoTheLoai int,
    @TiLe FLOAT
as
BEGIN
    update dbo.ChiTietBaoCaoTinhHinhMuonSachTheotheLoai
    Set TiLe=@TiLe
    where MaChiTietBaoCaoTinhHinhMuonSachTheoTheLoai=@MaChiTietBaoCaoTinhHinhMuonSachTheoTheLoai
        and DeleteFlag='N'
END
go
--create procducer insert baocaotinhhinhmuonsachtheotheloai
create PROC USP_NhapChiTietBaoCaoTinhHinhMuonSachTheoTheLoai
    @MaBaoCaoTinhHinhMuonSachTheoTheLoai int,
    @MaTheLoaiSach int,
    @SoLuongMuon int
as
BEGIN
    insert into dbo.ChiTietBaoCaoTinhHinhMuonSachTheoTheLoai
        (MaBaoCaoTinhHinhMuonSachTheoTheLoai,MaTheLoaiSach,SoLuongMuon)
    VALUES(@MaBaoCaoTinhHinhMuonSachTheoTheLoai, @MaTheLoaiSach, @SoLuongMuon )
END
go
-- create proceduer insert baocaotrasachtre
CREATE PROC USP_NhapBaoCaoTraSachTre
    @thoiGian datetime
AS
BEGIN
    insert into dbo.BaoCaoSachTraTre
        (ThoiGian)
    VALUES(@thoiGian)
END
go

--create proceduce insert chitietbaocaosachtratre
create proc USP_NhapChiTietBaoCaoSachTraTre
    @MaBaoCaoSachTraTre INTEGER,
    @MaChiTietPhieuMuonSach INTEGER,
    @SoNgayTre INTEGER
AS
BEGIN
    INSERT into dbo.ChiTietBaoCaoSachTraTre
        (MaBaoCaoSachTraTre,MaChiTietPhieuMuonSach,SoNgayTre)
    VALUES(@MaBaoCaoSachTraTre, @MaChiTietPhieuMuonSach, @SoNgayTre)
END
go
