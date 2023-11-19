CREATE PROCEDURE dbo.SignIn
    @HoTen NVARCHAR(50),
    @GioiTinh INT,
    @NgaySinh DATE,
    @SDT CHAR(10),
    @Email VARCHAR(50),
    @TaiKhoan VARCHAR(255),
    @MatKhau VARCHAR(255),
    @PhanQuyen VARCHAR(10)
AS
BEGIN
    DECLARE @ID_DangNhap INT;

    INSERT INTO THONGTINDANGNHAP (TaiKhoan, MatKhau, PhanQuyen)
    VALUES (@TaiKhoan, @MatKhau, @PhanQuyen);

    SET @ID_DangNhap = SCOPE_IDENTITY();

    INSERT INTO NGUOIDUNG (HoTen, GioiTinh, NgaySinh, SDT, Email, ID_DangNhap)
    VALUES (@HoTen, @GioiTinh, @NgaySinh, @SDT, @Email, @ID_DangNhap);
END;
GO



CREATE PROCEDURE ThemThichNguoiDung
    @IdNguoithich INT,
    @IdNguoiDuocthich INT
AS
BEGIN
    INSERT INTO THICHNGUOIDUNG (ID_NguoiThich, iD_nguoiduocthich)
    VALUES (@IdNguoithich, @IdNguoiDuocthich);
END;