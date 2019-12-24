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
ALTER DATABASE [QLTV] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLTV] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLTV] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLTV] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLTV] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLTV] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLTV] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLTV] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLTV] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLTV] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLTV] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLTV] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLTV] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLTV] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLTV] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLTV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLTV] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLTV] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLTV] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLTV] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLTV] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLTV] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLTV] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLTV] SET  MULTI_USER 
GO
ALTER DATABASE [QLTV] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLTV] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLTV] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLTV] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QLTV] SET DELAYED_DURABILITY = DISABLED 
GO
USE [QLTV]
GO
/****** Object:  Table [dbo].[tblChiTietPhieuMuon]    Script Date: 6/22/2019 10:04:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblChiTietPhieuMuon]
(
    [maphieumuon] [varchar](50) NOT NULL,
    [macuonsach] [varchar](50) NOT NULL,
    CONSTRAINT [PK_tblChiTietPhieuMuon] PRIMARY KEY CLUSTERED 
(
	[maphieumuon] ASC,
	[macuonsach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblChiTietPhieuNhap]    Script Date: 6/22/2019 10:04:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblChiTietPhieuNhap]
(
    [maphieunhap] [varchar](50) NOT NULL,
    [madausach] [varchar](50) NOT NULL,
    [soluong] [int] NOT NULL,
    [ghichu] [nvarchar](max) NULL,
    [thanhtien] [int] NOT NULL,
    CONSTRAINT [PK_tblChiTietPhieuNhap] PRIMARY KEY CLUSTERED 
(
	[maphieunhap] ASC,
	[madausach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblChiTietPhieuTra]    Script Date: 6/22/2019 10:04:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblChiTietPhieuTra]
(
    [maphieutra] [varchar](50) NOT NULL,
    [macuonsach] [varchar](50) NOT NULL,
    CONSTRAINT [PK_tblChiTietPhieuTra] PRIMARY KEY CLUSTERED 
(
	[maphieutra] ASC,
	[macuonsach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblChiTietPhieuXuat]    Script Date: 6/22/2019 10:04:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblChiTietPhieuXuat]
(
    [maphieuxuat] [varchar](50) NOT NULL,
    [macuonsach] [varchar](50) NOT NULL,
    [thanhtien] [int] NOT NULL,
    [ghichu] [nvarchar](max) NULL,
    CONSTRAINT [PK_tblChiTietPhieuXuat] PRIMARY KEY CLUSTERED 
(
	[maphieuxuat] ASC,
	[macuonsach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblCuonSach]    Script Date: 6/22/2019 10:04:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCuonSach]
(
    [macuonsach] [varchar](50) NOT NULL,
    [tinhtrang] [varchar](50) NOT NULL,
    [dausach] [varchar](50) NOT NULL,
    [soke] [int] NOT NULL,
    CONSTRAINT [PK_tblCuonSach] PRIMARY KEY CLUSTERED 
(
	[macuonsach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblDangNhap]    Script Date: 6/22/2019 10:04:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblDangNhap]
(
    [madangnhap] [varchar](50) NOT NULL,
    [nguoidung] [varchar](50) NOT NULL,
    [tendangnhap] [nvarchar](max) NOT NULL,
    [matkhau] [nvarchar](max) NOT NULL,
    [dangnhaplandau] [bit] NOT NULL,
    CONSTRAINT [PK_tblDangNhap] PRIMARY KEY CLUSTERED 
(
	[madangnhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblDauSach]    Script Date: 6/22/2019 10:04:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblDauSach]
(
    [madausach] [varchar](50) NOT NULL,
    [tendausach] [nvarchar](max) NOT NULL,
    [tomtat] [nchar](10) NULL,
    [nhaxuatban] [varchar](50) NOT NULL,
    [namxuatban] [int] NOT NULL,
    [trigia] [int] NOT NULL,
    CONSTRAINT [PK_tblDauSach] PRIMARY KEY CLUSTERED 
(
	[madausach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblDauSach_NgonNgu]    Script Date: 6/22/2019 10:04:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblDauSach_NgonNgu]
(
    [madausach] [varchar](50) NOT NULL,
    [mangonngu] [varchar](50) NOT NULL,
    CONSTRAINT [PK_tblDauSach_NgonNgu] PRIMARY KEY CLUSTERED 
(
	[madausach] ASC,
	[mangonngu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblDauSach_TacGia]    Script Date: 6/22/2019 10:04:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblDauSach_TacGia]
(
    [madausach] [varchar](50) NOT NULL,
    [matacgia] [varchar](50) NOT NULL,
    CONSTRAINT [PK_tblDauSach_TacGia] PRIMARY KEY CLUSTERED 
(
	[madausach] ASC,
	[matacgia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblDauSach_TheLoai]    Script Date: 6/22/2019 10:04:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblDauSach_TheLoai]
(
    [madausach] [varchar](50) NOT NULL,
    [matheloai] [varchar](50) NOT NULL,
    CONSTRAINT [PK_tblDauSach_TheLoai] PRIMARY KEY CLUSTERED 
(
	[madausach] ASC,
	[matheloai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblNgonNgu]    Script Date: 6/22/2019 10:04:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblNgonNgu]
(
    [mangonngu] [varchar](50) NOT NULL,
    [tenngonngu] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_tblNgonNgu] PRIMARY KEY CLUSTERED 
(
	[mangonngu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblNguoiDung]    Script Date: 6/22/2019 10:04:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblNguoiDung]
(
    [manguoidung] [varchar](50) NOT NULL,
    [hoten] [nvarchar](max) NOT NULL,
    [CMND] [nvarchar](max) NOT NULL,
    [gioitinh] [bit] NOT NULL,
    [ngaysinh] [datetime] NOT NULL,
    [diachi] [nvarchar](max) NULL,
    [email] [nvarchar](max) NULL,
    [sodienthoai] [nvarchar](max) NULL,
    [vaitro] [varchar](50) NOT NULL,
    [ngaytao] [datetime] NOT NULL,
    CONSTRAINT [PK_tblNguoiDung] PRIMARY KEY CLUSTERED 
(
	[manguoidung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblNhaCungCap]    Script Date: 6/22/2019 10:04:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblNhaCungCap]
(
    [manhacungcap] [varchar](50) NOT NULL,
    [tennhacungcap] [nvarchar](max) NOT NULL,
    [diachi] [nvarchar](max) NOT NULL,
    [sodienthoai] [nvarchar](max) NOT NULL,
    [sofax] [nvarchar](max) NULL,
    CONSTRAINT [PK_tblNhaCungCap] PRIMARY KEY CLUSTERED 
(
	[manhacungcap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblNhaThanhLy]    Script Date: 6/22/2019 10:04:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblNhaThanhLy]
(
    [manhathanhly] [varchar](50) NOT NULL,
    [tennhathanhly] [nvarchar](max) NOT NULL,
    [diachi] [nvarchar](max) NOT NULL,
    [sodienthoai] [nvarchar](max) NOT NULL,
    [sofax] [nvarchar](max) NULL,
    CONSTRAINT [PK_tblNhaThanhLy] PRIMARY KEY CLUSTERED 
(
	[manhathanhly] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblNhaXuatBan]    Script Date: 6/22/2019 10:04:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblNhaXuatBan]
(
    [manhaxuatban] [varchar](50) NOT NULL,
    [tennhaxuatban] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_tblNhaXuatBan] PRIMARY KEY CLUSTERED 
(
	[manhaxuatban] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblPhieuMuon]    Script Date: 6/22/2019 10:04:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblPhieuMuon]
(
    [maphieumuon] [varchar](50) NOT NULL,
    [docgia] [varchar](50) NOT NULL,
    [thuthu] [varchar](50) NOT NULL,
    [ngaymuon] [datetime] NOT NULL,
    CONSTRAINT [PK_tblPhieuMuon] PRIMARY KEY CLUSTERED 
(
	[maphieumuon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblPhieuNhap]    Script Date: 6/22/2019 10:04:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblPhieuNhap]
(
    [maphieunhap] [varchar](50) NOT NULL,
    [ngaynhap] [datetime] NOT NULL,
    [nhacungcap] [varchar](50) NOT NULL,
    [tongtien] [int] NOT NULL,
    [nguoinhap] [varchar](50) NOT NULL,
    CONSTRAINT [PK_tblPhieuNhap] PRIMARY KEY CLUSTERED 
(
	[maphieunhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblPhieuTra]    Script Date: 6/22/2019 10:04:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblPhieuTra]
(
    [maphieutra] [varchar](50) NOT NULL,
    [docgia] [varchar](50) NOT NULL,
    [thuthu] [varchar](50) NOT NULL,
    [ngaytra] [datetime] NOT NULL,
    CONSTRAINT [PK_tblPhieuTra] PRIMARY KEY CLUSTERED 
(
	[maphieutra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblPhieuXuat]    Script Date: 6/22/2019 10:04:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblPhieuXuat]
(
    [maphieuxuat] [varchar](50) NOT NULL,
    [ngayxuat] [datetime] NOT NULL,
    [nhathanhly] [varchar](50) NOT NULL,
    [tongtien] [int] NOT NULL,
    [nguoixuat] [varchar](50) NOT NULL,
    CONSTRAINT [PK_tblPhieuXuat] PRIMARY KEY CLUSTERED 
(
	[maphieuxuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblTacGia]    Script Date: 6/22/2019 10:04:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTacGia]
(
    [matacgia] [varchar](50) NOT NULL,
    [tentacgia] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_tblTacGia] PRIMARY KEY CLUSTERED 
(
	[matacgia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblTheLoai]    Script Date: 6/22/2019 10:04:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTheLoai]
(
    [matheloai] [varchar](50) NOT NULL,
    [tentheloai] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_tblTheLoai] PRIMARY KEY CLUSTERED 
(
	[matheloai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblTinhTrang]    Script Date: 6/22/2019 10:04:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTinhTrang]
(
    [matinhtrang] [varchar](50) NOT NULL,
    [tentinhtrang] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_tblTinhTrang] PRIMARY KEY CLUSTERED 
(
	[matinhtrang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblVaiTro]    Script Date: 6/22/2019 10:04:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblVaiTro]
(
    [mavaitro] [varchar](50) NOT NULL,
    [tenvaitro] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_tblVaiTro] PRIMARY KEY CLUSTERED 
(
	[mavaitro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[tblChiTietPhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK_tblChiTietPhieuMuon_tblCuonSach] FOREIGN KEY([macuonsach])
REFERENCES [dbo].[tblCuonSach] ([macuonsach])
GO
ALTER TABLE [dbo].[tblChiTietPhieuMuon] CHECK CONSTRAINT [FK_tblChiTietPhieuMuon_tblCuonSach]
GO
ALTER TABLE [dbo].[tblChiTietPhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK_tblChiTietPhieuMuon_tblPhieuMuon] FOREIGN KEY([maphieumuon])
REFERENCES [dbo].[tblPhieuMuon] ([maphieumuon])
GO
ALTER TABLE [dbo].[tblChiTietPhieuMuon] CHECK CONSTRAINT [FK_tblChiTietPhieuMuon_tblPhieuMuon]
GO
ALTER TABLE [dbo].[tblChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_tblChiTietPhieuNhap_tblDauSach] FOREIGN KEY([madausach])
REFERENCES [dbo].[tblDauSach] ([madausach])
GO
ALTER TABLE [dbo].[tblChiTietPhieuNhap] CHECK CONSTRAINT [FK_tblChiTietPhieuNhap_tblDauSach]
GO
ALTER TABLE [dbo].[tblChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_tblChiTietPhieuNhap_tblPhieuNhap] FOREIGN KEY([maphieunhap])
REFERENCES [dbo].[tblPhieuNhap] ([maphieunhap])
GO
ALTER TABLE [dbo].[tblChiTietPhieuNhap] CHECK CONSTRAINT [FK_tblChiTietPhieuNhap_tblPhieuNhap]
GO
ALTER TABLE [dbo].[tblChiTietPhieuTra]  WITH CHECK ADD  CONSTRAINT [FK_tblChiTietPhieuTra_tblCuonSach] FOREIGN KEY([macuonsach])
REFERENCES [dbo].[tblCuonSach] ([macuonsach])
GO
ALTER TABLE [dbo].[tblChiTietPhieuTra] CHECK CONSTRAINT [FK_tblChiTietPhieuTra_tblCuonSach]
GO
ALTER TABLE [dbo].[tblChiTietPhieuTra]  WITH CHECK ADD  CONSTRAINT [FK_tblChiTietPhieuTra_tblPhieuTra] FOREIGN KEY([maphieutra])
REFERENCES [dbo].[tblPhieuTra] ([maphieutra])
GO
ALTER TABLE [dbo].[tblChiTietPhieuTra] CHECK CONSTRAINT [FK_tblChiTietPhieuTra_tblPhieuTra]
GO
ALTER TABLE [dbo].[tblChiTietPhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK_tblChiTietPhieuXuat_tblCuonSach] FOREIGN KEY([macuonsach])
REFERENCES [dbo].[tblCuonSach] ([macuonsach])
GO
ALTER TABLE [dbo].[tblChiTietPhieuXuat] CHECK CONSTRAINT [FK_tblChiTietPhieuXuat_tblCuonSach]
GO
ALTER TABLE [dbo].[tblChiTietPhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK_tblChiTietPhieuXuat_tblPhieuXuat] FOREIGN KEY([maphieuxuat])
REFERENCES [dbo].[tblPhieuXuat] ([maphieuxuat])
GO
ALTER TABLE [dbo].[tblChiTietPhieuXuat] CHECK CONSTRAINT [FK_tblChiTietPhieuXuat_tblPhieuXuat]
GO
ALTER TABLE [dbo].[tblCuonSach]  WITH CHECK ADD  CONSTRAINT [FK_tblCuonSach_tblDauSach] FOREIGN KEY([dausach])
REFERENCES [dbo].[tblDauSach] ([madausach])
GO
ALTER TABLE [dbo].[tblCuonSach] CHECK CONSTRAINT [FK_tblCuonSach_tblDauSach]
GO
ALTER TABLE [dbo].[tblCuonSach]  WITH CHECK ADD  CONSTRAINT [FK_tblCuonSach_tblTinhTrang] FOREIGN KEY([tinhtrang])
REFERENCES [dbo].[tblTinhTrang] ([matinhtrang])
GO
ALTER TABLE [dbo].[tblCuonSach] CHECK CONSTRAINT [FK_tblCuonSach_tblTinhTrang]
GO
ALTER TABLE [dbo].[tblDangNhap]  WITH CHECK ADD  CONSTRAINT [FK_tblDangNhap_tblNguoiDung] FOREIGN KEY([nguoidung])
REFERENCES [dbo].[tblNguoiDung] ([manguoidung])
GO
ALTER TABLE [dbo].[tblDangNhap] CHECK CONSTRAINT [FK_tblDangNhap_tblNguoiDung]
GO
ALTER TABLE [dbo].[tblDauSach]  WITH CHECK ADD  CONSTRAINT [FK_tblDauSach_tblNhaXuatBan] FOREIGN KEY([nhaxuatban])
REFERENCES [dbo].[tblNhaXuatBan] ([manhaxuatban])
GO
ALTER TABLE [dbo].[tblDauSach] CHECK CONSTRAINT [FK_tblDauSach_tblNhaXuatBan]
GO
ALTER TABLE [dbo].[tblDauSach_NgonNgu]  WITH CHECK ADD  CONSTRAINT [FK_tblDauSach_NgonNgu_tblDauSach] FOREIGN KEY([madausach])
REFERENCES [dbo].[tblDauSach] ([madausach])
GO
ALTER TABLE [dbo].[tblDauSach_NgonNgu] CHECK CONSTRAINT [FK_tblDauSach_NgonNgu_tblDauSach]
GO
ALTER TABLE [dbo].[tblDauSach_NgonNgu]  WITH CHECK ADD  CONSTRAINT [FK_tblDauSach_NgonNgu_tblNgonNgu] FOREIGN KEY([mangonngu])
REFERENCES [dbo].[tblNgonNgu] ([mangonngu])
GO
ALTER TABLE [dbo].[tblDauSach_NgonNgu] CHECK CONSTRAINT [FK_tblDauSach_NgonNgu_tblNgonNgu]
GO
ALTER TABLE [dbo].[tblDauSach_TacGia]  WITH CHECK ADD  CONSTRAINT [FK_tblDauSach_TacGia_tblDauSach] FOREIGN KEY([madausach])
REFERENCES [dbo].[tblDauSach] ([madausach])
GO
ALTER TABLE [dbo].[tblDauSach_TacGia] CHECK CONSTRAINT [FK_tblDauSach_TacGia_tblDauSach]
GO
ALTER TABLE [dbo].[tblDauSach_TacGia]  WITH CHECK ADD  CONSTRAINT [FK_tblDauSach_TacGia_tblTacGia] FOREIGN KEY([matacgia])
REFERENCES [dbo].[tblTacGia] ([matacgia])
GO
ALTER TABLE [dbo].[tblDauSach_TacGia] CHECK CONSTRAINT [FK_tblDauSach_TacGia_tblTacGia]
GO
ALTER TABLE [dbo].[tblDauSach_TheLoai]  WITH CHECK ADD  CONSTRAINT [FK_tblDauSach_TheLoai_tblDauSach] FOREIGN KEY([madausach])
REFERENCES [dbo].[tblDauSach] ([madausach])
GO
ALTER TABLE [dbo].[tblDauSach_TheLoai] CHECK CONSTRAINT [FK_tblDauSach_TheLoai_tblDauSach]
GO
ALTER TABLE [dbo].[tblDauSach_TheLoai]  WITH CHECK ADD  CONSTRAINT [FK_tblDauSach_TheLoai_tblTheLoai] FOREIGN KEY([matheloai])
REFERENCES [dbo].[tblTheLoai] ([matheloai])
GO
ALTER TABLE [dbo].[tblDauSach_TheLoai] CHECK CONSTRAINT [FK_tblDauSach_TheLoai_tblTheLoai]
GO
ALTER TABLE [dbo].[tblNguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_tblNguoiDung_tblVaiTro] FOREIGN KEY([vaitro])
REFERENCES [dbo].[tblVaiTro] ([mavaitro])
GO
ALTER TABLE [dbo].[tblNguoiDung] CHECK CONSTRAINT [FK_tblNguoiDung_tblVaiTro]
GO
ALTER TABLE [dbo].[tblPhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK_tblPhieuMuon_tblNguoiDung] FOREIGN KEY([docgia])
REFERENCES [dbo].[tblNguoiDung] ([manguoidung])
GO
ALTER TABLE [dbo].[tblPhieuMuon] CHECK CONSTRAINT [FK_tblPhieuMuon_tblNguoiDung]
GO
ALTER TABLE [dbo].[tblPhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK_tblPhieuMuon_tblNguoiDung1] FOREIGN KEY([thuthu])
REFERENCES [dbo].[tblNguoiDung] ([manguoidung])
GO
ALTER TABLE [dbo].[tblPhieuMuon] CHECK CONSTRAINT [FK_tblPhieuMuon_tblNguoiDung1]
GO
ALTER TABLE [dbo].[tblPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_tblPhieuNhap_tblNguoiDung] FOREIGN KEY([nguoinhap])
REFERENCES [dbo].[tblNguoiDung] ([manguoidung])
GO
ALTER TABLE [dbo].[tblPhieuNhap] CHECK CONSTRAINT [FK_tblPhieuNhap_tblNguoiDung]
GO
ALTER TABLE [dbo].[tblPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_tblPhieuNhap_tblNhaCungCap] FOREIGN KEY([nhacungcap])
REFERENCES [dbo].[tblNhaCungCap] ([manhacungcap])
GO
ALTER TABLE [dbo].[tblPhieuNhap] CHECK CONSTRAINT [FK_tblPhieuNhap_tblNhaCungCap]
GO
ALTER TABLE [dbo].[tblPhieuTra]  WITH CHECK ADD  CONSTRAINT [FK_tblPhieuTra_tblNguoiDung] FOREIGN KEY([docgia])
REFERENCES [dbo].[tblNguoiDung] ([manguoidung])
GO
ALTER TABLE [dbo].[tblPhieuTra] CHECK CONSTRAINT [FK_tblPhieuTra_tblNguoiDung]
GO
ALTER TABLE [dbo].[tblPhieuTra]  WITH CHECK ADD  CONSTRAINT [FK_tblPhieuTra_tblNguoiDung1] FOREIGN KEY([thuthu])
REFERENCES [dbo].[tblNguoiDung] ([manguoidung])
GO
ALTER TABLE [dbo].[tblPhieuTra] CHECK CONSTRAINT [FK_tblPhieuTra_tblNguoiDung1]
GO
ALTER TABLE [dbo].[tblPhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK_tblPhieuXuat_tblNguoiDung] FOREIGN KEY([nguoixuat])
REFERENCES [dbo].[tblNguoiDung] ([manguoidung])
GO
ALTER TABLE [dbo].[tblPhieuXuat] CHECK CONSTRAINT [FK_tblPhieuXuat_tblNguoiDung]
GO
ALTER TABLE [dbo].[tblPhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK_tblPhieuXuat_tblNhaThanhLy] FOREIGN KEY([nhathanhly])
REFERENCES [dbo].[tblNhaThanhLy] ([manhathanhly])
GO
ALTER TABLE [dbo].[tblPhieuXuat] CHECK CONSTRAINT [FK_tblPhieuXuat_tblNhaThanhLy]
GO
USE [master]
GO
ALTER DATABASE [QLTV] SET  READ_WRITE 
GO
NSERT
INTO dbo.QuiDinh
(TuoiToiDa,TuoiToiThieu,ThoiHanToiDaTheDocGia,ThoiHanNhanSach
    ,SoNgayMuonToiDa,SoSachMuonToiDa)
VALUES
(55, 18, 6, 8, 4, 5)

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