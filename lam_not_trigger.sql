CREATE TRIGGER trg_BanVe_KiemTraSoLuongVe
ON ThongTinVe
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra số lượng vé còn lại trước khi bán vé
    DECLARE @SoLuongVeConLai INT;

    SELECT @SoLuongVeConLai = SoLuongVe - COUNT(i.MaVe)
    FROM ChuyenBay cb
    LEFT JOIN ThongTinVe i ON cb.MaChuyenBay = i.MaChuyenBay
	inner join MayBay mb on mb.MaMayBay = cb.MaMayBay
    GROUP BY cb.MaChuyenBay, mb.SoLuongGhe1, mb.SoLuongGhe2;

    -- Thực hiện bán vé nếu có đủ số lượng vé còn lại
    IF @SoLuongVeConLai >= 0
    BEGIN
        INSERT INTO ThongTinVe (MaVe, MaChuyenBay, LoaiVe, GiaVe)
        SELECT i.MaVe, i.MaChuyenBay, i.LoaiVe, i.GiaVe
        FROM inserted i;

        -- Cập nhật lại số lượng vé còn lại trong ChuyenBay
        UPDATE cb
        SET SoLuongVe = cb.SoLuongVe - COUNT(i.MaVe)
        FROM ChuyenBay cb
        JOIN inserted i ON cb.MaChuyenBay = i.MaChuyenBay;
    END
    ELSE
    BEGIN
        RAISEERROR ('Số lượng vé không đủ', 16, 1);
    END;
END;

SELECT
    cb.MaChuyenBay,
    cb.NgayDi,
    COUNT(ttv.MaVe) AS SoVeBanRa
FROM
    ChuyenBay cb
INNER JOIN
    ThongTinVe ttv ON cb.MaChuyenBay = ttv.MaChuyenBay
GROUP BY
    cb.MaChuyenBay, cb.NgayDi
ORDER BY
    cb.NgayDi, cb.MaChuyenBay;
select * from ChuyenBay
select * from DuongDi
select * from HoaDon
select * from KhachHang
select * from MayBay
select * from NhanVien
select * from ThongTinVe

CREATE TRIGGER trg_HuyBanVe_UpdateTongTienVaSoLuongVe
ON ThongTinVe
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật tổng tiền trong HoaDon sau khi có thông tin hủy bán vé
    UPDATE HoaDon
    SET TongTien = TongTien - d.GiaVe
    FROM HoaDon h
    JOIN deleted d ON h.MaVe = d.MaVe;

    -- Cập nhật số lượng vé còn lại trong ChuyenBay sau khi hủy bán vé
    UPDATE cb
    SET SoLuongVe = cb.SoLuongVe + COUNT(d.MaVe)
    FROM ChuyenBay cb
    JOIN deleted d ON cb.MaChuyenBay = d.MaChuyenBay;
END;

CREATE TRIGGER trg_KiemTraNgayDen
ON ChuyenBay
INSTEAD OF UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT *
        FROM inserted i
        WHERE i.NgayDen < i.NgayDi
    )
    BEGIN
        print N'Ngày đến phải sau ngày đi';
		rollback tran
    END
    ELSE
    BEGIN
        -- Nếu không có lỗi, thực hiện cập nhật dữ liệu
        UPDATE cb
        SET cb.NgayDen = i.NgayDen
        FROM ChuyenBay cb
        JOIN inserted i ON cb.MaChuyenBay = i.MaChuyenBay;
    END;
END;

CREATE TRIGGER trg_KiemTraNgayBan
ON HoaDon
INSTEAD OF UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM inserted i
        WHERE i.NgayBan > GETDATE()
    )
    BEGIN
        print N'Ngày bán phải là ngày hiện tại hoặc quá khứ';
		rollback tran
    END
    ELSE
    BEGIN
        -- Nếu không có lỗi, thực hiện cập nhật dữ liệu
        UPDATE hd
        SET hd.NgayBan = i.NgayBan
        FROM HoaDon hd
        JOIN inserted i ON hd.MaHoaDon = i.MaHoaDon;
    END;
END;

INSERT dbo.HoaDon(MaHoaDon, NgayBan, MaNV, MaKH, MaVe, TongTien) 
VALUES  ( N'HD01', '2023-10-27', 'NV01', 'KH01' , 'MV01', 1000000),


CREATE PROCEDURE QuanLiHoaDon
AS
BEGIN
    DECLARE @MaHoaDon NCHAR(5), @NgayBan DATE, @MaNV NCHAR(5), @MaKH NCHAR(5), @MaVe NCHAR(5), @TongTien INT;

    -- Con trỏ: Lặp qua danh sách hóa đơn
    DECLARE CursorHoaDon CURSOR FOR
    SELECT MaHoaDon, NgayBan, MaNV, MaKH, MaVe, TongTien
    FROM HoaDon;

    OPEN CursorHoaDon;
    FETCH NEXT FROM CursorHoaDon INTO @MaHoaDon, @NgayBan, @MaNV, @MaKH, @MaVe, @TongTien;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Thực hiện xử lý với thông tin từ bảng HoaDon
        PRINT 'Thông tin hóa đơn: ' + @MaHoaDon + ', ' + CAST(@NgayBan AS NVARCHAR(MAX)) + ', ' + @MaNV + ', ' + @MaKH + ', ' + @MaVe + ', ' + CAST(@TongTien AS NVARCHAR(MAX));

        -- Lấy dòng tiếp theo từ con trỏ HoaDon
        FETCH NEXT FROM CursorHoaDon INTO @MaHoaDon, @NgayBan, @MaNV, @MaKH, @MaVe, @TongTien;
    END;

    -- Đóng con trỏ HoaDon
    CLOSE CursorHoaDon;
    DEALLOCATE CursorHoaDon;
END;

exec QuanLiHoaDon

CREATE PROCEDURE QuanLiVeMayBay
AS
BEGIN
    DECLARE @MaVe NCHAR(5), @MaChuyenBay NCHAR(5), @LoaiVe NCHAR(5), @GiaVe FLOAT;

    -- Con trỏ: Lặp qua danh sách vé máy bay
    DECLARE CursorVeMayBay CURSOR FOR
    SELECT MaVe, MaChuyenBay, LoaiVe, GiaVe
    FROM ThongTinVe;

    OPEN CursorVeMayBay;
    FETCH NEXT FROM CursorVeMayBay INTO @MaVe, @MaChuyenBay, @LoaiVe, @GiaVe;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Thực hiện xử lý với thông tin từ bảng VeMayBay
        PRINT 'Thông tin vé máy bay: ' + @MaVe + ', ' + @MaChuyenBay + ', ' + @LoaiVe + ', ' + CAST(@GiaVe AS nchar(10));

        -- Lấy dòng tiếp theo từ con trỏ VeMayBay
        FETCH NEXT FROM CursorVeMayBay INTO @MaVe, @MaChuyenBay, @LoaiVe, @GiaVe;
    END;

    -- Đóng con trỏ VeMayBay
    CLOSE CursorVeMayBay;
    DEALLOCATE CursorVeMayBay;
END;

exec QuanLiVeMayBay