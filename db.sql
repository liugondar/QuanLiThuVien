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
    MaLoaiDocGia INT IDENTITY PRIMARY KEY,
    -- primary key column
    DeleteFlag NVARCHAR(1) not null default 'N',
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
    MaTheDocGia INT Primary Key NOT NULL,
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
IF OBJECT_ID('dbo.Sach', 'U') IS NOT NULL
DROP TABLE dbo.Sach
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Sach
(
    MaSach INT IDENTITY PRIMARY KEY,
    -- primary key column
    MaTheLoaiSach Int not null,
    MaTacGia Int not null,
    TenNhaXuatBan NVARCHAR(50) not null default N'TenNXB',
    TenSach NVARCHAR(50) not null default N'TenSach',
    NgayXuatBan date not null DEFAULT getdate(),
    NgayNhap date not null DEFAULT getdate(),
    TriGia INT not null DEFAULT 0,
    TinhTrang INT not null DEFAULT 0,-- 0 la con, 1 la het 
    DeleteFlag NVARCHAR(1) not null default 'N',
    CONSTRAINT FK_Sach_TacGia FOREIGN KEY(MaTacGia) REFERENCES TacGia(MaTacGia),
    CONSTRAINT FK_Sach_TheLoaiSach FOREIGN KEY(MaTheLoaiSach) REFERENCES TheLoaiSach(MaTheLoaiSach),
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
    MaTheDocGia[INT] NOT NULL,
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
    MaSach int not null,
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


--create producer insert Reader
CREATE PROC USP_ThemTheDocGia
    @MaTheDocGia INT,
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
END
go

--create producer insert sach
create PROC USP_NhapSach
    @TenSach NVARCHAR(50),
    @MaTheLoaiSach int,
    @MaTacGia int,
    @TenNhaXuatBan NVARCHAR(50),
    @NgayXuatBan date,
    @NgayNhap date,
    @TriGia INT
AS
BEGIN
    insert into dbo.Sach
        (TenSach,MaTheLoaiSach,MaTacGia,TenNhaXuatBan,NgayXuatBan,NgayNhap,TriGia)
    VALUES(@TenSach, @MaTheLoaiSach, @MaTacGia, @TenNhaXuatBan, @NgayXuatBan, @NgayNhap, @TriGia)
END
GO

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
    @thoiGian date
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

-- Init qui dinh
INSERT INTO dbo.QuiDinh
    (TuoiToiDa,TuoiToiThieu,ThoiHanToiDaTheDocGia,ThoiHanNhanSach
    ,SoNgayMuonToiDa,SoSachMuonToiDa)
VALUES(55, 18, 6, 8, 4, 5)

INSERT into LoaiDocGia
    (TenLoaiDocGia)
VALUES('X')
INSERT into LoaiDocGia
    (TenLoaiDocGia)
VALUES('Y')

--Init the loai 
INSERT INTO dbo.TheLoaiSach
    (TenTheLoaiSach)
VALUES('A')
INSERT INTO dbo.TheLoaiSach
    (TenTheLoaiSach)
VALUES('B')
INSERT INTO dbo.TheLoaiSach
    (TenTheLoaiSach)
VALUES('C')

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

select *
from ChiTietBaoCaoSachTraTre