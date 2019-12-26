USE master
GO

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
    TriGia INT not null DEFAULT 0,
    SoLuong Int not null default 0,
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
    NgayNhap date not null DEFAULT getdate(),
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
    NgayTra[date] ,
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

-- Init qui dinh
INSERT INTO dbo.QuiDinh
    (TuoiToiDa,TuoiToiThieu,ThoiHanToiDaTheDocGia,ThoiHanNhanSach
    ,SoNgayMuonToiDa,SoSachMuonToiDa)
VALUES(55, 18, 6, 8, 4, 5)

INSERT into LoaiDocGia
    (TenLoaiDocGia)
VALUES('Thường')
INSERT into LoaiDocGia
    (TenLoaiDocGia)
VALUES('VIP')

--Init the loai 
INSERT INTO dbo.TheLoaiSach
    (TenTheLoaiSach)
VALUES('Phiêu lưu')
INSERT INTO dbo.TheLoaiSach
    (TenTheLoaiSach)
VALUES('Khoa học')
INSERT INTO dbo.TheLoaiSach
    (TenTheLoaiSach)
VALUES('Trinh thám')
INSERT INTO dbo.TheLoaiSach
    (TenTheLoaiSach)
VALUES('Ngôn tình')

--Init tac gia
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Lou Jimenez')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Dollie Dennis')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Lottie Lee')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Chase Nash')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Julia Tucker')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Pauline Silva')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Victor Jennings')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Bruce Manning')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Jerome Hart')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Frederick Logan')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Owen Walters')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Mario Torres')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Maud Ray')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Hattie Ramirez')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Francis Cobb')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'John Flores')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Shane Gray')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'John Ross')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Emilie Rios')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Barry Saunders')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Alex Hayes')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Helen Goodman')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Sarah Bradley')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Steve Higgins')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Jackson McKinney')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Tyler Crawford')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Rosa Ballard')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Harriet Rose')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Allie Graves')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Isabella Greene')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Nancy Patterson')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Myra Bennett')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Charlotte Roberson')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Hattie Rowe')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Adam Duncan')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Daisy Stevenson')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Ann Harvey')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Adelaide Hoffman')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Olive Briggs')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Logan McCoy')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Jeremy Lane')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Belle Stephens')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Cody Shaw')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Elijah Harris')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Amy Cole')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Chester Obrien')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Timothy Ingram')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Franklin Elliott')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES('Craig Barnes')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Mabelle Higgins')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Carl Morgan')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Phoebe Shelton')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Travis Erickson')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Jeffery McCoy')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Duane Fisher')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Cynthia Walsh')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Rose Fitzgerald')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Scott Berry')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Willie Porter')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Carl Dawson')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Leo Soto')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Daniel Chapman')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Jeff Williams')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Clifford Drake')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Willie Vargas')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Mabelle Burgess')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Lilly Carter')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Harry Watts')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Albert Dawson')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Celia Welch')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Alex Garrett')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Mamie Stone')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Sue Yates')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Manuel Sullivan')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Christina Moran')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Cecilia Butler')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Mattie Welch')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Margaret Clarke')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Linnie Reed')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Sylvia Armstrong')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Effie Becker')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Bettie Peters')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Matthew Pierce')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Kate Roberson')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Leonard Fox')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Marie Graham')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Helen Weaver')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Alvin Sullivan')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Lilly Lee')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Ralph Pierce')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Ruth Wong')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Etta Yates')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Tom Owen')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Howard Moody')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Maud Reeves')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Luella Reese')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Mike Cole')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Terry Copeland')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Lelia Fletcher')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Bruce Clark')
INSERT INTO dbo.TacGia
    (TenTacGia)
VALUES(N'Matie Jefferson')
go


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
        or ctpm.NgayTra is null and  ctpm.NgayTra is null and DATEDIFF(DAY,pms.HanTra, GETDATE()) >0
    )
GO
-- example to execute the stored procedure we just created
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