
use Master
go
use QuanLiThuVien
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