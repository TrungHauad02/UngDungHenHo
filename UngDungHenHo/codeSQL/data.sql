USE [NHANTINHENHO]
GO

INSERT INTO THONGTINDANGNHAP (TaiKhoan, MatKhau, PhanQuyen) VALUES
('user1', 'password1', 'user'),
('trunghau' ,'trunghau', 'admin'),
('phamtuan', 'phamtuan', 'user');
go
INSERT INTO NGUOIDUNG (HoTen, GioiTinh, NgaySinh, DiaChi, SDT, AnhDaiDien, Email, MoTaCaNhan, ID_DangNhap) VALUES
('tui la con gai', 1, '1990-01-01', 'Address 1', '1234567890', (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\Users\ad\Documents\datatinnhanhenho\hinhanh1.jpg', SINGLE_BLOB) as ImageData), 'user@email.com', 'huong ngoai.', 1),
('pham huu tuan', 0, '1995-05-05', 'Address 2', '9876543210', NULL, 'pht@email.com', 'it noi ', 3),
('Nguyen Trung Hau', 1, '1985-08-15', 'Admin Address', '5555555555', NULL, 'trunghau@email.com', 'admin la tao', 2);
go
INSERT INTO QUANTRIVIEN (HoTen, ID_DangNhap) VALUES
('Nguyen Trung Hau', 2);
go

INSERT INTO BAIVIET (NoiDung, HinhAnh, ThoiGianDang, SLThich, ID_NguoiDung) VALUES
('1 ngay dep troi', (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\Users\ad\Documents\datatinnhanhenho\hinhanh1.jpg', SINGLE_BLOB) as ImageData), '2023-11-15 12:00:00', 10, 1),
('ngay buon', NULL, '2023-11-15 12:30:00', 5, 1),
('hinh anh', NULL, '2023-11-15 13:00:00', 8, 2);
go
INSERT INTO TINNHAN (NoiDung, HinhAnh, ThoiGianGui, TrangThai, ID_NguoiGui, ID_NguoiNhan) VALUES
('nay m di hoc ko', (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\Users\ad\Documents\datatinnhanhenho\hinhanh1.jpg', SINGLE_BLOB) as ImageData), '2023-11-15 14:00:00', 1, 1, 2),
('t dup.', NULL, '2023-11-15 14:30:00', 1, 2, 1),
('chao admin.', NULL, '2023-11-15 15:00:00', 1, 1, 3);
go
INSERT INTO GHEPDOI (ID_NguoiDung1, ID_NguoiDung2, ThoiGianGhepDoi, BieuTuongDoi) VALUES
(1, 2, '2023-11-15 16:00:00', (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\Users\ad\Documents\datatinnhanhenho\hinhanh1.jpg', SINGLE_BLOB) as ImageData)),
(2, 3, '2023-11-15 17:00:00', NULL);
go
INSERT INTO KETBAN (ID_NguoiDung1, ID_NguoiDung2, ThoiGianKetBan) VALUES
(1, 3, '2023-11-15 18:00:00');
go
INSERT INTO THICHBAIVIET (ID_BaiViet, ID_NguoiDung) VALUES
(1, 2),
(3, 1);
go
INSERT INTO BAOCAO (ID_NguoiDung, ID_BaiViet, ID_QuanTri, ThoiGianBaoCao, NoiDungBaoCao, ThoiGianPhanHoi, NoiDungPhanHoi) VALUES
(2, 1, 1, '2023-11-15 19:00:00', 'spam tin nhan', '2023-11-15 19:30:00', 'cam on ban'),
(3, 3, 1, '2023-11-15 20:00:00', 'ghet','2023-11-15 19:30:00', 'cam on ban');
go
INSERT INTO SOTHICH (TenSoThich) VALUES
('Reading'),
('Sports'),
('Music');
go
INSERT INTO SOTHICH_NGUOIDUNG (ID_NguoiDung, ID_SoThich) VALUES
(1, 1),
(1, 2),
(2, 2),
(3, 3);
go




