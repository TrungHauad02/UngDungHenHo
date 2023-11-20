USE [NHANTINHENHO]
GO


----- Function Login
CREATE FUNCTION [dbo].[ValidateLogin]
    (@TaiKhoan VARCHAR(255), @MatKhau VARCHAR(255))
RETURNS INT
AS
BEGIN
    DECLARE @ID_DangNhap INT
    DECLARE @ID_NguoiDung INT

    SELECT @ID_DangNhap = ID_DangNhap
    FROM THONGTINDANGNHAP
    WHERE TaiKhoan = @TaiKhoan AND MatKhau = @MatKhau;

    IF @ID_DangNhap IS NULL
    BEGIN
        RETURN -1;
    END

    SELECT @ID_NguoiDung = ID_NguoiDung
    FROM NGUOIDUNG
    WHERE ID_DangNhap = @ID_DangNhap;

    IF @ID_NguoiDung IS NOT NULL
    BEGIN
        RETURN @ID_NguoiDung;
    END
    RETURN -1;
END
GO



CREATE FUNCTION [dbo].[func_LayDanhSachBaiVietNguoiDung]
(
    @IdNguoiDung INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM BaiViet
    WHERE ID_NguoiDung = @IdNguoiDung
);
go
create function func_Laydanhsachsothichcuanguoidung
(
	@IdNguoiDung int
)
	returns table
as
return(

	
	select SOTHICH.TenSoThich
	from SOTHICH
	inner join 
	(select ID_SoThich
	from SOTHICH_NGUOIDUNG
	where SOTHICH_NGUOIDUNG.ID_NguoiDung = @IdNguoiDung) as danhsach
	on danhsach.ID_SoThich = SOTHICH.ID_SoThich

);
go






