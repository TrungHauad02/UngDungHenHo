use NHANTINHENHO
go

create view [dbo].[v_BaoCao] 
as 
select * 
from BAOCAO

go

CREATE VIEW V_SOTHICH AS
SELECT
	SOTHICH.ID_SoThich,
	SOTHICH.TenSoThich,
	SOTHICH_NGUOIDUNG.ID_NguoiDung,
	NGUOIDUNG.HoTen,
	NGUOIDUNG.GioiTinh,
	NGUOIDUNG.DiaChi,
	NGUOIDUNG.NgaySinh,
	NGUOIDUNG.MoTaCaNhan,
	NGUOIDUNG.Email,
	NGUOIDUNG.SDT,
	NGUOIDUNG.AnhDaiDien
FROM
	SOTHICH JOIN SOTHICH_NGUOIDUNG ON SOTHICH.ID_SoThich = SOTHICH_NGUOIDUNG.ID_SoThich
	JOIN NGUOIDUNG ON NGUOIDUNG.ID_NguoiDung = SOTHICH_NGUOIDUNG.ID_NguoiDung
GO

create view [dbo].[v_SoThich]
as 
select * 
from SOTHICH
GO

create view [dbo].[v_SoThich]
as 
select * 
from SOTHICH