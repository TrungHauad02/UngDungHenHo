use NHANTINHENHO
GO

CREATE PROCEDURE dbo.SignIn
    @HoTen NVARCHAR(50),
    @GioiTinh INT,
    @NgaySinh DATE,
    @SDT CHAR(10),
    @Email VARCHAR(50),
	@ID_DangNhap INT
AS
BEGIN
    INSERT INTO NGUOIDUNG (HoTen, GioiTinh, NgaySinh, SDT, Email, ID_DangNhap)
    VALUES (@HoTen, @GioiTinh, @NgaySinh, @SDT, @Email, @ID_DangNhap);
END;
GO

CREATE PROCEDURE dbo.AddAccount
	@TaiKhoan VARCHAR(255),
    @MatKhau VARCHAR(255),
    @PhanQuyen VARCHAR(10)
AS
BEGIN
	INSERT INTO THONGTINDANGNHAP (TaiKhoan, MatKhau, PhanQuyen)
    VALUES (@TaiKhoan, @MatKhau, @PhanQuyen);
END;
GO

CREATE PROCEDURE dbo.TrySignIn
    @HoTen NVARCHAR(50),
    @GioiTinh INT,
    @NgaySinh DATE,
    @SDT CHAR(10),
    @Email VARCHAR(50),
    @TaiKhoan VARCHAR(255),
    @MatKhau VARCHAR(255),
    @PhanQuyen VARCHAR(10),
    @ID_DangNhap INT OUTPUT
AS
BEGIN
    DECLARE @AccountID INT;

    -- Thêm tài khoản
    EXEC dbo.AddAccount @TaiKhoan, @MatKhau, @PhanQuyen;

    -- Lấy ID_DangNhap từ bảng Account với TaiKhoan = @TaiKhoan
    SELECT @AccountID = ID_DangNhap
    FROM dbo.Account
    WHERE TaiKhoan = @TaiKhoan;

    -- Gán giá trị cho biến OUTPUT
    SET @ID_DangNhap = @AccountID;

    -- Thực hiện đăng nhập
    EXEC dbo.SignIn @HoTen, @GioiTinh, @NgaySinh, @SDT, @Email, @ID_DangNhap;
END;
GO

create PROCEDURE [dbo].[ThemThichNguoiDung]
    @IdNguoithich INT,
    @IdNguoiDuocthich INT
AS
BEGIN
    INSERT INTO THICHNGUOIDUNG (ID_NguoiThich, ID_NguoiDuocThich)
    VALUES (@IdNguoithich, @IdNguoiDuocthich);
END;
go
create PROCEDURE Proc_TaoBaoCaoNguoiDung
    @ID_NguoiDungBaoCao INT,
    @ID_NguoiDungBiBaoCao INT,
	@ThoiGianBaoCao date,
	@NoiDungBaoCao nvarchar(200)
AS
BEGIN
    INSERT INTO BAOCAO(ID_NguoiDungBaoCao,ID_NguoiDungBiBaoCao,ThoiGianBaoCao,NoiDungBaoCao)
    VALUES (@ID_NguoiDungBaoCao, @ID_NguoiDungBiBaoCao,	@ThoiGianBaoCao ,@NoiDungBaoCao);
END;
go

CREATE PROC [dbo].[CapNhatBaoCao]
    @ID_BaoCao INT,
    @ID_QuanTri INT,
    @ThoiGianPhanHoi DATETIME,
    @NoiDungPhanHoi NVARCHAR(255)
AS
BEGIN
    UPDATE BAOCAO
    SET
        ID_QuanTri = @ID_QuanTri,
        ThoiGianPhanHoi = @ThoiGianPhanHoi,
        NoiDungPhanHoi = @NoiDungPhanHoi
    WHERE
        ID_BaoCao = @ID_BaoCao;
END;
go

CREATE PROCEDURE [dbo].[ChanNguoiDung]
AS
BEGIN
    UPDATE NGUOIDUNG
    SET TrangThai = 0
    WHERE ID_NguoiDung IN (
        SELECT ID_NguoiDungBiBaoCao
        FROM BAOCAO
        GROUP BY ID_NguoiDungBiBaoCao
        HAVING COUNT(ID_BaoCao) >= 5
    );
END;
GO
CREATE PROCEDURE UpdateNguoiDung
    @ID_NguoiDung INT,
    @HoTen NVARCHAR(MAX),
    @NgaySinh DATE,
    @AnhDaiDien VARBINARY(MAX),
    @MoTaCaNhan NVARCHAR(MAX)
AS
BEGIN
    UPDATE [NHANTINHENHO].[dbo].[NGUOIDUNG]
    SET 
        [HoTen] = @HoTen,
        [NgaySinh] = @NgaySinh,
        [AnhDaiDien] = @AnhDaiDien,
        [MoTaCaNhan] = @MoTaCaNhan
    WHERE 
        [ID_NguoiDung] = @ID_NguoiDung;
END;
go

CREATE FUNCTION dbo.GetRelatedIDs (@id_select INT)
RETURNS TABLE
AS
RETURN
(
    SELECT  RelatedID
    FROM
    (
        SELECT ID_NguoiDung1 AS RelatedID
        FROM GHEPDOI
        WHERE @id_select = ID_NguoiDung2
        
        UNION ALL
        
        SELECT ID_NguoiDung2 AS RelatedID
        FROM GHEPDOI
        WHERE @id_select = ID_NguoiDung1
    ) AS Subquery
);

go


CREATE PROC layThongTinNguoiChat @MaND INT
as
	select ID_NguoiDung,HoTen,AnhDaiDien
	from GetRelatedIDs(@MaND) rl, NGUOIDUNG ND
	where rl.RelatedID = ND.ID_NguoiDung
GO

CREATE PROC [dbo].[proc_ThemSoThich]
    @TenSoThich NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO SOTHICH (TenSoThich)
    VALUES (@TenSoThich);

    SELECT SCOPE_IDENTITY() AS ID_SoThich;
END;
GO

CREATE PROC [dbo].[proc_ThemSoThich]
    @TenSoThich NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO SOTHICH (TenSoThich)
    VALUES (@TenSoThich);

    SELECT SCOPE_IDENTITY() AS ID_SoThich;
END;
GO

CREATE PROC [dbo].[proc_CapNhatSoThich]
    @ID_SoThich INT,
    @TenSoThich nvarchar(30)
AS
BEGIN
    UPDATE SOTHICH
    SET
        TenSoThich = @TenSoThich
    WHERE
        ID_SoThich = @ID_SoThich;
END;
go
