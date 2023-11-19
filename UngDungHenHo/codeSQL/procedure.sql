use NHANTINHENHO
GO
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

--------L?y n?i dung tin nh?n--------
create proc prc_laynoidungtinnhan @id_gui int, @id_nhan int  
as   
 select * from TINNHAN where ID_NguoiGui = @id_gui and ID_NguoiNhan = @id_nhan