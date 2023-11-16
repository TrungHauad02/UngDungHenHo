
CREATE TRIGGER TRG_UpdateSLThich
ON THICHBAIVIET
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật SLThich khi có bản ghi được thêm hoặc cập nhật trong THICHBAIVIET
    UPDATE BAIVIET
    SET SLThich = (
        SELECT COUNT(ID_BaiViet)
        FROM THICHBAIVIET
        WHERE THICHBAIVIET.ID_BaiViet = BAIVIET.ID_BaiViet
    )
    FROM BAIVIET
    INNER JOIN INSERTED ON BAIVIET.ID_BaiViet = INSERTED.ID_BaiViet

    -- Cập nhật SLThich khi có bản ghi bị xóa trong THICHBAIVIET
    UPDATE BAIVIET
    SET SLThich = SLThich - 1
    FROM BAIVIET
    INNER JOIN DELETED ON BAIVIET.ID_BaiViet = DELETED.ID_BaiViet

    -- Cập nhật SLThich khi có bản ghi được thêm vào THICHBAIVIET
    UPDATE BAIVIET
    SET SLThich = SLThich + 1
    FROM BAIVIET
    INNER JOIN INSERTED ON BAIVIET.ID_BaiViet = INSERTED.ID_BaiViet
END
GO