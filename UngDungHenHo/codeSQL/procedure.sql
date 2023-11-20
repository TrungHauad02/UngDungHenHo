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
    EXEC dbo.AddAccount @TaiKhoan, @MatKhau, @PhanQuyen;

    SET @ID_DangNhap = SCOPE_IDENTITY();

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



