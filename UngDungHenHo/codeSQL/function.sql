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

CREATE FUNCTION dbo.GetNguoiDungInfoById
(
    @NguoiDungId INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT [HoTen], [NgaySinh], [AnhDaiDien], [MoTaCaNhan]
    FROM [NHANTINHENHO].[dbo].[NGUOIDUNG]
    WHERE [ID_NguoiDung] = @NguoiDungId
);
go
CREATE FUNCTION dbo.GetSoThichByNguoiDung
(
    @NguoiDungId INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT [s].[ID_SoThich], [s].[TenSoThich]
    FROM [NHANTINHENHO].[dbo].[SOTHICH] AS [s]
    JOIN [NHANTINHENHO].[dbo].[SOTHICH_NGUOIDUNG] AS [snd]
    ON [s].[ID_SoThich] = [snd].[ID_SoThich]
    WHERE [snd].[ID_NguoiDung] = @NguoiDungId
);
go
CREATE FUNCTION dbo.GetBaiVietByNguoiDungId
(
    @NguoiDungId INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT [NoiDung], [HinhAnh], [ThoiGianDang]
    FROM (
        SELECT [NoiDung], [HinhAnh], [ThoiGianDang],
               ROW_NUMBER() OVER (ORDER BY [ThoiGianDang] DESC) AS RowNum
        FROM [NHANTINHENHO].[dbo].[BAIVIET]
        WHERE [ID_NguoiDung] = @NguoiDungId
    ) AS Subquery
    WHERE RowNum BETWEEN 1 AND 1000
);
go
CREATE FUNCTION dbo.GetInfoByNguoiDung1
(
    @NguoiDung1 INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT [ng].[HoTen], [gd].[ID_NguoiDung2]
    FROM [NHANTINHENHO].[dbo].[GHEPDOI] AS [gd]
    INNER JOIN [NHANTINHENHO].[dbo].[NGUOIDUNG] AS [ng] ON [gd].[ID_NguoiDung2] = [ng].[ID_NguoiDung]
    WHERE [gd].[ID_NguoiDung1] = @NguoiDung1
);
go

CREATE FUNCTION dbo.GetNguoiDungById_DangNhap
(
    @ID_DangNhap INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT [ID_NguoiDung], [HoTen], [NgaySinh], [AnhDaiDien], [MoTaCaNhan]
    FROM [NHANTINHENHO].[dbo].[NGUOIDUNG]
    WHERE [ID_DangNhap] = @ID_DangNhap
);
go

create FUNCTION func_Laydanhsachnguoidungchuathich
(
    @IdNguoiDung INT
)
RETURNS TABLE
AS
RETURN
(
   SELECT ID_NguoiDung,Hoten,AnhDaiDien,MoTaCaNhan

FROM V_NguoiDung

WHERE ID_NguoiDung not in
(

    SELECT ID_NguoiDuocThich
    FROM THICHNGUOIDUNG
    WHERE @IdNguoiDung = ID_NguoiThich
)
and  ID_NguoiDung not in 
(
	SELECT ID_NguoiDungBiBaoCao
    FROM BAOCAO
    WHERE @IdNguoiDung = ID_NguoiDungBaoCao
)
and ID_NguoiDung <> @IdNguoiDung
);
GO


