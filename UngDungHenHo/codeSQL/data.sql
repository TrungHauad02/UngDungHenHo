USE [NHANTINHENHO]
GO

INSERT INTO THONGTINDANGNHAP (TaiKhoan, MatKhau, PhanQuyen) VALUES
('user1', 'password1', 'user'),
('trunghau' ,'trunghau', 'admin'),
('phamtuan', 'phamtuan', 'user');
GO

INSERT INTO NGUOIDUNG (HoTen, GioiTinh, NgaySinh, DiaChi, SDT, AnhDaiDien, Email, MoTaCaNhan, ID_DangNhap) VALUES
('tui la con gai', 1, '1990-01-01', 'Address 1', '1234567890', (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\Users\Dell\Desktop\Major_3_1\CNPM\UngDungHenHo\UngDungHenHo\codeSQL\hinhanh1.jpg', SINGLE_BLOB) as ImageData), 'user@email.com', 'huong ngoai.', 1),
('pham huu tuan', 0, '1995-05-05', 'Address 2', '9876543210', NULL, 'pht@email.com', 'it noi ', 3),
('Nguyen Trung Hau', 1, '1985-08-15', 'Admin Address', '5555555555', NULL, 'trunghau@email.com', 'admin la tao', 2);
GO

INSERT INTO QUANTRIVIEN (HoTen, ID_DangNhap) VALUES
('Nguyen Trung Hau', 2);
GO

INSERT INTO BAIVIET (NoiDung, HinhAnh, ThoiGianDang, ID_NguoiDung) VALUES
('1 ngay dep troi', (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\Users\Dell\Desktop\Major_3_1\CNPM\UngDungHenHo\UngDungHenHo\codeSQL\hinhanh1.jpg', SINGLE_BLOB) as ImageData), '2023-11-15 12:00:00', 1),
('ngay buon', NULL, '2023-11-15 12:30:00', 1),
('hinh anh', NULL, '2023-11-15 13:00:00', 2);
GO

INSERT INTO TINNHAN (NoiDung, HinhAnh, ThoiGianGui, TrangThai, ID_NguoiGui, ID_NguoiNhan) VALUES
('nay m di hoc ko', (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\Users\Dell\Desktop\Major_3_1\CNPM\UngDungHenHo\UngDungHenHo\codeSQL\hinhanh1.jpg', SINGLE_BLOB) as ImageData), '2023-11-15 12:00:00', 1, 1, 2),
('ko, m di hoc di', NULL, '2023-11-15 12:01:00', 1, 2, 1),
('ok', NULL, '2023-11-15 12:02:00', 1, 1, 2);
GO

INSERT INTO GHEPDOI (ID_NguoiDung1, ID_NguoiDung2) VALUES
(1, 2);
GO

INSERT INTO THICHNGUOIDUNG (ID_NguoiThich, ID_NguoiDuocThich) VALUES
(1, 2),
(2, 1);
GO

INSERT INTO BAOCAO (ID_NguoiDungBaoCao, ID_NguoiDungBiBaoCao, ThoiGianBaoCao, NoiDungBaoCao) VALUES
(1, 2, '2023-11-15 12:30:00', 'spam tin nhan');
GO

INSERT INTO SOTHICH (TenSoThich) VALUES
(N'Đọc sách'),
(N'xem phim'),
(N'Nghe nhạc');
GO

INSERT INTO SOTHICH_NGUOIDUNG (ID_NguoiDung, ID_SoThich) VALUES
(1, 1),
(1, 2),
(2, 3);
GO
