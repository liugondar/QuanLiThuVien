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

update 
TheDocGia
set DeleteFlag=N'n'

 select * 
from DauSach ds, Sach s
where ds.MaDauSach=1 and  1=1  and  1=1  and  1=1 
and NgayXuatBan between '1753-01-01' and '2019-12-26'
and TriGia between 0 and 100000000000
and ds.DeleteFlag='N' and s.DeleteFlag=N'N'

query: select * 
from DauSach
where (TenSach REGEXP_LIKE '.*2.*')  and  1=1  and  1=1  and  1=1 
and NgayXuatBan between '1753-01-01' and '2019-12-26'
and TriGia between 0 and 100000000000
and DeleteFlag='N'

select * from DauSach
SELECT * from TacGia

SELECT *
FROM DauSach , TacGia
WHERE TenSach LIKE  '%Hi%'
and (
    TenTacGia LIKE '%Den%'
    or TenTacGia Like '%lee%'
)


select * 
from DauSach
where  TenSach like 'hihihi'  and MaTheLoaiSach=1 and MaTacGia=4 and TenNhaXuatBan='32132'
and NgayXuatBan between '1753-01-01' and '2019-12-26'
and TriGia between 0 and 100000000000
and DeleteFlag='N'
