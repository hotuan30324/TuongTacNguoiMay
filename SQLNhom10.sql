create DATABASE BTLHQT
USE BTLHQT;
GO
CREATE TABLE MayBay(
	MaMayBay NCHAR(5) NOT NULL PRIMARY KEY,
	TenMayBay NCHAR(30) NOT NULL , 
	HangSanXuat NCHAR(30) ,
	SoLuongGhe1 INT ,
	SoLuongGhe2 INT ,
)

CREATE TABLE KhachHang (
	MaKH NCHAR(5) NOT NULL PRIMARY KEY,
	TenKH NCHAR(30),
	SDT nchar(30),
	NgaySinh date,
	GioiTinh NCHAR(3),
	DiaChi NCHAR(40),
	CMNDHoChieu NCHAR(20),
	QuocTich NCHAR(20)

)
CREATE TABLE NhanVien (
	MaNV NCHAR(5) NOT NULL PRIMARY KEY,
	TenNhanVien NCHAR(30),
	GioiTinh NCHAR(3),
	DiaChi NCHAR(30),
	NgaySinh date,
	SoDT NCHAR(10),
	ChucVu NCHAR(10),
	TaiKhoan NCHAR(50),
	MatKhau NCHAR(50)
)
CREATE TABLE DuongDi(

	MaDD NCHAR(5) NOT NULL PRIMARY KEY,
	DiemDen NCHAR(30),
	DiemDi NCHAR(30),
	Manv NCHAR(5) NOT NULL ,
	FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
)
CREATE TABLE ChuyenBay(
	MaChuyenBay NCHAR(5) NOT NULL PRIMARY KEY ,
	MaMayBay NCHAR(5) NOT NULL ,
	MaDD NCHAR(5) NOT NULL,
	Manv NCHAR(5) NOT NULL ,
	NgayDi DATE ,
	NgayDen DATE ,
	GioDi NCHAR(10),
	GhiChu NCHAR(50),
	FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
	FOREIGN KEY (MaDD) REFERENCES DuongDi(MaDD),
	FOREIGN KEY (MaMayBay) REFERENCES MayBay(MaMayBay)
)
CREATE TABLE ThongTinVe (
	MaVe NCHAR(5) NOT NULL PRIMARY KEY,
	MaChuyenBay  NCHAR(5) NOT NULL,
	Loaive NCHAR(5),
	GiaVe FLOAT,
	FOREIGN KEY (MaChuyenBay) REFERENCES chuyenBay(MaChuyenBay)
)

CREATE TABLE HoaDon (
	MaHoaDon NCHAR(5) NOT NULL primary key ,
	NgayBan date,
	MaNV NCHAR(5) NOT NULL,
	MaKH NCHAR(5) NOT NULL ,
	MaVe nchar(5) not null,
	TongTien int,
	foreign key (mave) references thongtinve(mave),
	FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
	FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
)

SELECT * FROM MayBay
SELECT * FROM ChuyenBay
SELECT * FROM DuongDi
SELECT * FROM HoaDon
SELECT * FROM KhachHang
SELECT * FROM NhanVien
SELECT * FROM ThongTinVe

DROP TABLE ChuyenBay;
DROP TABLE DuongDi;
DROP TABLE HoaDon;
DROP TABLE KhachHang;
DROP TABLE MayBay;
DROP TABLE NhanVien;
DROP TABLE ThongTinVe;

														--- PHẦN 1 TRIGGER 

-- trigger kiểm tra tuổi nhân viên cho phép từ 18 đến 60  - bảng Nhân Viên 
DROP TRIGGER checktuoi
CREATE TRIGGER checktuoi
on nhanvien 
AFTER INSERT 
AS 
IF (( SELECT DATEDIFF(yy,ngaysinh,GETDATE())   FROM Inserted    ) BETWEEN 18 AND 60)
	PRINT N'Tuổi Hợp Lệ '
ELSE 
	BEGIN 
		PRINT N'Xem lại tuổi '
		ROLLBACK TRAN
	END

-- trigger kiểm tra số điện thoại Bảng nhân viên 
DROP TRIGGER dbo.checksdt
CREATE TRIGGER checksdt 
ON NhanVien 
AFTER INSERT 
as
 
IF ((SELECT LEN(SoDT) FROM inserted) != 10 )
	BEGIN 
	PRINT N'Kiểm Tra Lại Số Điện Thoai'
	ROLLBACK TRAN 
	 END 
ELSE 
	PRINT N'số điện thoại hợp lệ  '

INSERT dbo.NhanVien
        ( MaNV ,
          TenNhanVien ,
          DiaChi ,
          NgaySinh ,
          SoDT ,
          ChucVu ,
          TaiKhoan ,
          MatKhau ,
          GioiTinh
        )
VALUES  ( N'NV100' , -- MaNV - nchar(5)
          N'Vũ Minh Quân' , -- TenNhanVien - nchar(30)
          N'Hải Dương' , -- DiaChi - nchar(30)
          '2003-02-18' , -- NgaySinh - date
          N'0334448073' , -- SoDT - nchar(10)
          N'Nhân Viên' , -- ChucVu - nchar(10)
          N'quan' , -- TaiKhoan - nchar(50)
          N'' , -- MatKhau - nchar(50)
          N'Nam'  -- GioiTinh - nchar(3)
        ) 

-- trigger Kiểm Tra Tuổi Khách Hàng 
DROP TRIGGER ChecktuoiKH
	CREATE TRIGGER ChecktuoiKH
	ON KhachHang 
	AFTER INSERT 
	AS  
	IF (( SELECT DATEDIFF(yy,ngaysinh,GETDATE())   FROM Inserted    ) >100 OR (SELECT DATEDIFF(yy,ngaysinh,GETDATE())   FROM Inserted ) < 1 )
		BEGIN 
			PRINT N'Xem lai tuổi khách hàng!'
			ROLLBACK TRAN 
		END 
	ELSE 
		PRINT N'Tuổi Đúng !'
	 
INSERT dbo.KhachHang
	        ( MaKH ,
	          TenKH ,
	          SDT ,
	          NgaySinh ,
	          DiaChi ,
	          CMNDHoChieu ,
	          QuocTich ,
	          GioiTinh
	        )
	VALUES  ( N'KH108' , -- MaKH - nchar(5)
	          N'Vũ Minh Quân' , -- TenKH - nchar(30)
	          N'0334792743' , -- SDT - nchar(30)
	          '2003-02-18' , -- NgaySinh - date
	          N'Hải Dương ' , -- DiaChi - nchar(40)
	          N'113730521' , -- CMNDHoChieu - nchar(20)
	          N'Việt Nam ' , -- QuocTich - nchar(20)
	          N'Nam'  -- GioiTinh - nchar(3)
	        )
			SELECT * FROM NhanVien;
			SELECT * FROM KhachHang;
-- Trigger kiểm tra Số ĐIện thoại khách hàng 
DROP TRIGGER checksdtKH
	CREATE TRIGGER checksdtKH
	ON KhachHang 
	AFTER INSERT 
	as
	IF ((SELECT LEN(SDT) FROM inserted) != 10 )
	BEGIN 
	PRINT N'Kiểm Tra Lại Số Điện Thoai'
	ROLLBACK TRAN 
		END 
	ELSE 
	PRINT N'Số Điện Thoại Đúng ! '
		
	
--triger Kiểm tra ngày đi nhỏ hơn ngày đến cua Chuyến Bay

	DROP  TRIGGER KiemTraNDND
	CREATE TRIGGER KiemTraNDND
	ON Chuyenbay
	FOR  INSERT 
	AS  
	IF ((SELECT ngaydi  FROM inserted ) >  (SELECT ngayden  FROM inserted ) )
	BEGIN 
		PRINT N'ngày đi ngày đến không hợp lệ  '
		ROLLBACK TRAN 
	END 
	ELSE 
	PRINT N'Ngày đi đến  hợp lệ '
	
	   
	--Test
	INSERT dbo.ChuyenBay
	        ( MaChuyenBay ,
	          MaMayBay ,
	          MaDD ,
	          Manv ,
	          NgayDi ,
	          NgayDen ,
	          GioDi ,
	          GhiChu
	        )
	VALUES  ( N'CB101' , -- MaChuyenBay - nchar(5)
	          N'VNE1' , -- MaMayBay - nchar(5)
	          N'DD02' , -- MaDD - nchar(5)
	          N'NV100' , -- Manv - nchar(5)
	          '2023-11-27' , -- NgayDi - date
	          '2023-11-28' , -- NgayDen - date
	          N'14:05' , -- GioDi - nchar(10)
	          N''  -- GhiChu - nchar(50)
	        )
			SELECT * FROM ChuyenBay;
			--Add dữ liệu DuongDi
			INSERT dbo.DuongDi
			(
				MaDD, 
				DiemDen,
				DiemDi,
				Manv
			)
			VALUES  ( N'HAN' , -- MaDD - nchar(5)
	          N'Tân Sơn Nhất' , -- DiemDen - nchar(30)
	          N'Nội Bài' , -- DiemDi - nchar(3)
			  N'NV100' -- Mã nhân viên
	        )
			SELECT * FROM DuongDi;
			--Add dữ liệu MayBay:
			INSERT dbo.MayBay
	        ( 
	          MaMayBay ,
	          TenMayBay ,
	          HangSanXuat,
			  SoLuongGhe1,
			  SoLuongGhe2
	        )
	VALUES  ( N'VNE1' , -- MaMayBay - nchar(5)
	          N'Boeing 767' , -- TenMayBay - nchar(30)
	          N'Boeing Commercial' , -- HangSanXuat - nchar(3)
			  120, 
			  50
	        )
			SELECT * FROM MayBay;



	-- kiểm tra xem nếu hết vé loại thì không cho tạo vé nữa 
	DROP TRIGGER KiemTraGhe1
	CREATE TRIGGER KiemTraGhe1 
	ON ThongTinVe 
	AFTER INSERT 
	AS 
	
	IF((SELECT loaive FROM inserted ) = 'eco')
	BEGIN 
			
	IF(			(SELECT count(*) FROM ThongTinVe  WHERE Loaive ='eco' AND MaCHuyenBay = (SELECT MaCHuyenBay FROM inserted )) > 
			(SELECT maybay.SoLuongGhe1 FROM dbo.ChuyenBay,dbo.MayBAy
			WHERE (SELECT MaCHuyenBay FROM inserted) = dbo.ChuyenBay.MaChuyenBay 
			AND dbo.ChuyenBay.MaMayBay= maybay.MaMayBay 
			 )	)
			BEGIN 
			PRINT N'Quá số ghế Economy'
			ROLLBACK TRAN 
			END 
	ELSE 
	PRINT N'Thành Công '
			END
	-- test
	INSERT dbo.ThongTinVe
	        ( MaVe, MaCHuyenBay, Loaive, GiaVe )
	VALUES  ( N'MV201', -- MaVe - nchar(5)
	          N'CB200', -- MaCHuyenBay - nchar(5)
	          N'bu', -- Loaive - nchar(5)
	          111  -- GiaVe - float
	          )

			  
		
		
	--- 2 kiếm tra xem nếu hết vé loại 2 thì không cho thêm nữa 
	DROP TRIGGER KiemTraGhe2
	CREATE TRIGGER KiemTraGhe2
	ON ThongTinVe 
	AFTER INSERT 
	AS 
	
	IF((SELECT loaive FROM inserted ) = 'bu')
	BEGIN 
			
	IF(			(SELECT count(*) FROM ThongTinVe  WHERE Loaive ='bu' AND MaCHuyenBay = (SELECT MaCHuyenBay FROM inserted )) > 
			(SELECT maybay.SoLuongGhe2 FROM dbo.ChuyenBay,dbo.MayBAy
			WHERE (SELECT MaCHuyenBay FROM inserted) = dbo.ChuyenBay.MaChuyenBay 
			AND dbo.ChuyenBay.MaMayBay= maybay.MaMayBay 
			 )	)
			BEGIN 
			PRINT N'Quá số ghế Business'
			ROLLBACK TRAN 
			END 
	ELSE 
	PRINT N'Thành Công '
			END
-- Trigger để giảm số lượng ghế khi huỷ chuyến bay
CREATE TRIGGER DecreaseGhe
ON ChuyenBay
AFTER DELETE
AS
BEGIN
    UPDATE MayBay
    SET SoLuongGhe1 = MayBay.SoLuongGhe1 - d.SoLuongGhe1,
        SoLuongGhe2 = MayBay.SoLuongGhe2 - d.SoLuongGhe2
    FROM MayBay
    INNER JOIN deleted d ON MayBay.MaMayBay = d.MaMayBay;
END;

CREATE TRIGGER CheckNgayDiNgayDen
ON ChuyenBay
AFTER INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE NgayDi <= GETDATE() OR NgayDen <= NgayDi
    )
    BEGIN
       print('Ngày đi và ngày đến không hợp lệ.');
        ROLLBACK;
    END
END

															--- 2 PHẦN PHÂN QUYỀN 

	create role QUANLY -- thêm nhóm quyền role tên ADMIN 
	create role MEMBER -- thêm nhóm quyền role tên MEMBER 

-- thêm các quyền cho quản lí và member 
	GRANT SELECT,INSERT,UPDATE,DELETE ON NhanVien  TO QUANLY
	GRANT SELECT,INSERT,UPDATE,DELETE ON KhachHang  TO QUANLY
	GRANT SELECT,INSERT,UPDATE,DELETE ON ThongTinVe  TO QUANLY
	GRANT SELECT,INSERT,UPDATE,DELETE ON HoaDon  TO QUANLY
	GRANT SELECT,INSERT,UPDATE,DELETE ON MayBay  TO QUANLY
	GRANT SELECT,INSERT,UPDATE,DELETE ON ChuyenBay  TO QUANLY
	GRANT SELECT,INSERT,UPDATE,DELETE ON dbo.DuongDi  TO QUANLY
	GRANT EXECUTE ON dbo.addQuyen  TO QUANLY
	GRANT EXECUTE ON dbo.sp_timkiem  TO QUANLY
	GRANT EXECUTE ON dbo.sp_xoaquyen TO QUANLY
	GRANT EXECUTE ON dbo. sp_timkiemVe TO QUANLY

	GRANT SELECT ON dbo.NhanVien TO MEMBER
	GRANT SELECT ON KhachHang TO MEMBER
	GRANT SELECT ON MayBAy TO MEMBER
	GRANT SELECT ON ChuyenBay TO MEMBER
	GRANT SELECT ON HoaDon TO MEMBER
	GRANT SELECT ON DuongDI TO MEMBER
	GRANT SELECT ON dbo.ThongTinVe TO MEMBER

	-- -- tạo thủ tục để phân quyền 
	CREATE PROC addQuyen
	@tk varchar(50)  ,@mk varchar(50)  ,@chucvu nchar(50)
	as
	begin
		CREATE LOGIN [@tk] WITH PASSWORD = @mk;
		CREATE USER [@tk] FOR LOGIN [@tk];
		IF @chucvu = 'QUANLY'
			ALTER ROLE QUANLY ADD MEMBER [@tk]; 
		ELSE 
			ALTER ROLE MEMBER ADD MEMBER [@tk];
	end
-- thu lại quyền 
	CREATE PROC xoaquyen @tk NCHAR(50)
	AS
	BEGIN 
		DROP USER [@tk];
        DROP LOGIN [@tk];
	END


															--3 PHẦN THỦ TỤC 
-- tạo proc tìm kiếm 
CREATE PROC sp_timkiem @key nchar(30)
 AS BEGIN 

 select MaNV, TenNhanVien, ChucVu,SoDT,DiaChi,NgaySinh from NhanVien 
	where TenNhanVien like  N'%'+@key+'%' OR MaNV = @key 
	END 
----  tạo proc tìm kiếm theo vé 
	CREATE PROC sp_timkiemVe @mave NCHAR(5)
	AS BEGIN
    
	SELECT MaVe, LoaiVe, GiaVe, DiemDi, DiemDen from ThongTinVe as ttv INNER JOIN dbo.ChuyenBay AS cb ON ttv.MaCHuyenBay = cb.MaChuyenBay 
	INNER JOIN dbo.DuongDi AS dd ON dd.MaDD = cb.MaDD WHERE MaVe=  @maVe
	END

--Thủ tục để thêm một khách hàng mới:
CREATE PROCEDURE AddKhachHang
    @MaKH NCHAR(5),
    @TenKH NCHAR(30),
    @SDT NCHAR(30),
    @NgaySinh DATE,
    @GioiTinh NCHAR(3),
    @DiaChi NCHAR(40),
    @CMNDHoChieu NCHAR(20),
    @QuocTich NCHAR(20)
AS
BEGIN
    INSERT INTO KhachHang (MaKH, TenKH, SDT, NgaySinh, GioiTinh, DiaChi, CMNDHoChieu, QuocTich)
    VALUES (@MaKH, @TenKH, @SDT, @NgaySinh, @GioiTinh, @DiaChi, @CMNDHoChieu, @QuocTich);
END;

-- Chạy thủ tục với tham số
EXEC AddKhachHang @MaKH = 'KH10', @TenKH = N'Dương Văn Hiến', @SDT = '0366741258', @NgaySinh = '2003-07-22', @GioiTinh = 'Nam', @DiaChi = N'Bắc Ninh', @CMNDHoChieu = '1234567890', @QuocTich = N'Việt Nam';


--Thủ tục để lấy danh sách chuyến bay theo ngày:
CREATE PROCEDURE GetChuyenBayByDateRange
    @NgayBatDau DATE,
    @NgayKetThuc DATE
AS
BEGIN
    SELECT
        cb.MaChuyenBay,
        cb.NgayDi,
        cb.NgayDen,
        cb.GioDi,
        dd.DiemDi,
        dd.DiemDen
    FROM
        ChuyenBay cb
    INNER JOIN
        DuongDi dd ON cb.MaDD = dd.MaDD
    WHERE
        cb.NgayDi BETWEEN @NgayBatDau AND @NgayKetThuc;
END;

-- Chạy thủ tục với tham số
EXEC GetChuyenBayByDateRange @NgayBatDau = '2023-01-01', @NgayKetThuc = '2024-01-19';

															--4 PHẦN HÀM 
-- Viêt hàm để in ra số lượng ghế trống loai 1 
CREATE FUNCTION GheTrongLoai1 (@MaChuyenBay  nchar(30))
RETURNS int 
AS BEGIN
DECLARE @SoLuongLoai1 INT
DECLARE @soluongGhe INT 
DECLARE @slGheDaBan INT 
SELECT @SoLuongLoai1 = SoLuongGhe1 FROM MayBay  WHERE MaMayBay= (SELECT MaMayBay FROM ChuyenBay WHERE MaChuyenBay = @MaChuyenBay  )
SELECT @slGheDaBan = COUNT(*) FROM dbo.HoaDon,dbo.ThongTinVe
WHERE dbo.ThongTinVe.MaVe= HoaDon.MaVe AND Loaive = 'eco' AND dbo.ThongTinVe.MaCHuyenBay = @MaChuyenBay 

SET @soluongGhe = @SoLuongLoai1 - @slGheDaBan

RETURN @soluongGhe
END

PRINT CAST(dbo.GheTrongLoai2('CB02') AS NCHAR(5))

-- ghế loại 2
CREATE FUNCTION GheTrongLoai2 (@MaChuyenBay  nchar(30))
RETURNS int  
AS BEGIN
DECLARE @SoLuongLoai2 INT
DECLARE @soluongGhe INT 
DECLARE @slGheDaBan INT 
SELECT @SoLuongLoai2 = SoLuongGhe2 FROM MayBay  WHERE MaMayBay= (SELECT MaMayBay FROM ChuyenBay WHERE MaChuyenBay = @MaChuyenBay  )
SELECT @slGheDaBan = COUNT(*) FROM dbo.HoaDon,dbo.ThongTinVe
WHERE dbo.ThongTinVe.MaVe= HoaDon.MaVe AND Loaive = 'bu' AND dbo.ThongTinVe.MaCHuyenBay = @MaChuyenBay 

SET @soluongGhe = @SoLuongLoai2 - @slGheDaBan

RETURN @soluongGhe
END

-- Hàm tính doanh thu từ tất cả các hoá đơn
CREATE FUNCTION GetTongDoanhThu()
RETURNS INT
AS
BEGIN
    DECLARE @TongDoanhThu INT;

    SELECT @TongDoanhThu = SUM(TongTien)
    FROM HoaDon;

    RETURN @TongDoanhThu;
END;
select dbo.GetTongDoanhThu()

-- Hàm in ra thông tin vé của một khách hàng dựa trên mã khách hàng
CREATE FUNCTION GetVeByMaKH(@MaKH NCHAR(5))
RETURNS TABLE
AS
RETURN (
    SELECT ThongTinVe.MaVe, ThongTinVe.Loaive, ThongTinVe.GiaVe,
           ChuyenBay.MaChuyenBay, ChuyenBay.NgayDi
    FROM ThongTinVe
    JOIN ChuyenBay ON ThongTinVe.MaChuyenBay = ChuyenBay.MaChuyenBay
    WHERE ThongTinVe.MaVe = (select Mave from HoaDon where MaKH = @MaKH)
);
select * from dbo.GetVeByMaKH('KH02')


															--5 PHẦN VIEW
--1 view hóa đơn 
CREATE VIEW viewhoadon

AS

SELECT HD.MaHoaDon ,KH.MaKH , Kh.TenKH ,KH.SDT ,HD.NgayBan , HD.MaNV , DD.DiemDi  , DD.DiemDen, CB.NgayDi , CB.NgayDen  ,TTV.Loaive,TTV.GiaVe
FROM HoaDon HD,KhachHang KH,dbo.ChuyenBay CB,dbo.DuongDi DD,ThongTinVe TTV,dbo.NhanVien NV

WHERE 
HD.MaKH= KH.MaKH AND HD.MaVe = TTV.MaVe AND TTV.MaCHuyenBay= CB.MaChuyenBay AND Cb.MAdd= DD.MaDD AND NV.MaNV = HD.MaNV

--2 view In ra Các Chuyến Bay đã thêm 
CREATE VIEW viewchuyenbay AS 
select cb.MaChuyenBay, cb.NgayDi , cb.NgayDen , cb.GioDi ,
mb.SoLuongGhe1 , mb.SoLuongGhe2 , dd.DiemDi , dd.DiemDen ,cb.GhiChu 
from ChuyenBay AS cb INNER JOIN dbo.MayBay AS mb ON cb.MaMayBay = mb.MaMayBay INNER JOIN dbo.DuongDi AS dd ON cb.MaDD = dd.MaDD

--3 view in ra các đường đi 
CREATE VIEW viewduongdi AS 
select MaDD, DiemDi, DiemDen, Manv, (rtrim(DiemDi)+'-'+rtrim(DiemDen)) AS LoTrinh from DuongDi

---4 view in ra thông tin vé 
CREATE VIEW VIEWthongtinve as
select MaVe, LoaiVe, GiaVe, DiemDi, DiemDen from ThongTinVe as ttv INNER JOIN 
dbo.ChuyenBay AS cb ON ttv.MaCHuyenBay = cb.MaChuyenBay INNER JOIN dbo.DuongDi AS dd ON dd.MaDD = cb.MaDD

--5 View hiển thị thông tin chi tiết về chuyến bay
CREATE VIEW ViewChuyenBay AS
SELECT
    cb.MaChuyenBay,
    cb.MaMayBay,
    mb.TenMayBay,
    cb.MaDD,
    dd.DiemDi,
    dd.DiemDen,
    cb.MaNV,
    nv.TenNhanVien,
    cb.NgayDi,
    cb.NgayDen,
    cb.GioDi,
    cb.GhiChu
FROM
    ChuyenBay cb
JOIN
    MayBay mb ON cb.MaMayBay = mb.MaMayBay
JOIN
    DuongDi dd ON cb.MaDD = dd.MaDD
JOIN
    NhanVien nv ON cb.MaNV = nv.MaNV;

select * from viewchuyenbay

--6 View hiển thị thông tin tổng doanh thu từng khách hàng
CREATE VIEW ViewTongDoanhThuKhachHang AS
SELECT
    hd.MaKH,
    kh.TenKH,
    kh.SDT,
    SUM(hd.TongTien) AS TongDoanhThu
FROM
    HoaDon hd
JOIN
    KhachHang kh ON hd.MaKH = kh.MaKH
GROUP BY
    hd.MaKH, kh.TenKH, kh.SDT;

select * from ViewTongDoanhThuKhachHang
