create TRIGGER KiemTraGhepDoi
ON THICHNGUOIDUNG
AFTER INSERT
AS
BEGIN
    DECLARE @ID_NguoiThich INT, @ID_NguoiDuocThich INT;

    SELECT @ID_NguoiThich = ID_NguoiThich, @ID_NguoiDuocThich = ID_NguoiDuocThich FROM inserted;

    IF EXISTS (SELECT 1 FROM THICHNGUOIDUNG WHERE ID_NguoiThich = @ID_NguoiDuocThich AND ID_NguoiDuocThich = @ID_NguoiThich)
    BEGIN
		PRINT 'Ghép đôi thành công!';
        INSERT INTO GHEPDOI (ID_NguoiDung1, ID_NguoiDung2)
        VALUES (@ID_NguoiThich, @ID_NguoiDuocThich);
     
    END
END;
GO




