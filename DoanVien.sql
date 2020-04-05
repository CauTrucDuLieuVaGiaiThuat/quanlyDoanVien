
CREATE DATABASE QuanLyDoanVien

use QuanLyDoanVien
go

create table Khoa
(
	ID nvarchar(10) primary key,
	Name nvarchar(10) not null default N'Trống',
)
go

create table Lop
(
	ID nvarchar(10) primary key,
	idKhoa nvarchar(10) not null default N'Trống',
	Foreign key (idKhoa) references dbo.Khoa(ID),
)
go


create table DoanVien
(
	ID nvarchar(100) primary key,
	HoTen nvarchar(100),
	idKhoa nvarchar(10) not null default N'Null',
	Foreign key (idKhoa) references dbo.Khoa(ID),
	idLop nvarchar(10) not null default N'Null',
	Foreign key (idLop) references dbo.Lop(ID),
	NgaySinh date,
	GioiTinh nvarchar(100),
	QueQuan ntext,
	DanToc nvarchar(100),
	TonGiao nvarchar(100),
	NgayVaoDoan date,
	NoiVaoDoan nvarchar(1000),
	ChoOHienNay ntext,
	SDT nvarchar(100),
	Email nvarchar(100),
	laDangVien int not null default 0,
	DuBi date,
	ChinhThuc date,
	ChucVu nvarchar(1000),
	TomTat ntext,
	KiLuat ntext,
	KhenThuong ntext,
	LinkAnh nvarchar(1000),
)
go


create proc USP_AddStudent
@ID nvarchar(100),
@HoTen nvarchar(100),
@idKhoa nvarchar(10),
@idLop nvarchar(10),
@NgaySinh date,
@GioiTinh nvarchar(100),
@QueQuan ntext,
@DanToc nvarchar(100),
@TonGiao nvarchar(100),
@NgayVaoDoan date,
@NoiVaoDoan nvarchar(1000),
@ChoOHienNay ntext,
@SDT nvarchar(100),
@Email nvarchar(100),
@laDangVien int,
@DuBi date,
@ChinhThuc date,
@ChucVu nvarchar(1000),
@TomTat ntext,
@KiLuat ntext,
@KhenThuong ntext,
@LinkAnh nvarchar(1000)
as
begin
	Insert into dbo.DoanVien
	(
	ID,
	HoTen,
	idKhoa,
	idLop,
	NgaySinh,
	GioiTinh,
	QueQuan,
	DanToc,
	TonGiao,
	NgayVaoDoan,
	NoiVaoDoan,
	ChoOHienNay,
	SDT,
	Email,
	laDangVien,
	DuBi,
	ChinhThuc,
	ChucVu,
	TomTat,
	KiLuat,
	KhenThuong,
	LinkAnh
	)
	values 
	(
	@ID,
	@HoTen,
	@idKhoa,
	@idLop,
	@NgaySinh,
	@GioiTinh,
	@QueQuan,
	@DanToc,
	@TonGiao,
	@NgayVaoDoan,
	@NoiVaoDoan,
	@ChoOHienNay,
	@SDT,
	@Email,
	@laDangVien,
	@DuBi,
	@ChinhThuc,
	@ChucVu,
	@TomTat,
	@KiLuat,
	@KhenThuong,
	@LinkAnh
	)
end
go

create proc USP_AddLop
@id nvarchar(10),
@idKhoa nvarchar(10)
as
begin
	insert into dbo.Lop
	(ID, idKhoa)
	values
	(@id, @idKhoa)
end
go

create proc USP_AddKhoa
@id nvarchar(10),
@name nvarchar(10)
as
begin
	insert into dbo.Khoa
	(ID, Name)
	values
	(@id, @name)
end
go

alter proc USP_LoadStudentList
as
begin
	select
		ID as [MSSV],
		HoTen as [Họ và Tên],
		idKhoa as [Khóa],
		idLop as [Lớp],
		NgaySinh as [Ngày sinh],
		GioiTinh as [Giới tính],
		QueQuan as [Quê quán],
		DanToc as [Dân tộc],
		TonGiao as [Tôn giáo],
		NgayVaoDoan as [Ngày vào Đoàn],
		NoiVaoDoan as [Nơi vào Đoàn],
		ChoOHienNay as [Chỗ ở hiện nay],
		SDT as [Số điện thoại],
		Email,
		laDangVien as [Là Đảng viên],
		DuBi as [Ngày vào Đảng dự bị],
		ChinhThuc as [Ngày vào Đảng chính thức],
		ChucVu as [Chức vụ],
		TomTat as [Tóm tắt],
		KiLuat as [Kỉ luật],
		KhenThuong as [Khen thưởng],
		LinkAnh as [Ảnh]
	from dbo.DoanVien
end
go

exec USP_LoadStudentList
go

create proc USP_UpdateStudent
@ID nvarchar(100),
@HoTen nvarchar(100),
@idKhoa nvarchar(10),
@idLop nvarchar(10),
@NgaySinh date,
@GioiTinh nvarchar(100),
@QueQuan ntext,
@DanToc nvarchar(100),
@TonGiao nvarchar(100),
@NgayVaoDoan date,
@NoiVaoDoan nvarchar(1000),
@ChoOHienNay ntext,
@SDT nvarchar(100),
@Email nvarchar(100),
@laDangVien int,
@DuBi date,
@ChinhThuc date,
@ChucVu nvarchar(1000),
@TomTat ntext,
@KiLuat ntext,
@KhenThuong ntext,
@LinkAnh nvarchar(1000)
as
begin
	update dbo.DoanVien 
	set
	HoTen = @HoTen,
	idKhoa = @idKhoa,
	idLop = @idLop,
	NgaySinh = @NgaySinh,
	GioiTinh = @GioiTinh,
	QueQuan = @QueQuan,
	DanToc = @DanToc,
	TonGiao = @DanToc,
	NgayVaoDoan = @NgayVaoDoan,
	NoiVaoDoan = @NoiVaoDoan,
	ChoOHienNay = @ChoOHienNay,
	SDT = @SDT,
	Email = @Email,
	laDangVien = @laDangVien,
	DuBi = @DuBi,
	ChinhThuc = @ChinhThuc,
	ChucVu = @ChucVu,
	TomTat = @TomTat,
	KiLuat = @KiLuat,
	KhenThuong = @KhenThuong,
	LinkAnh = @LinkAnh
	WHERE ID = @ID
end
go

select * from DoanVien
go

create proc USP_DeleteStudent
@id nvarchar(1000)
as
begin
	delete from dbo.DoanVien
	where ID = @id
end

exec USP_DeleteStudent N'004'


----------- Khúc này là bạn Tường làm
CREATE TABLE SuKien
(
	id INT IDENTITY PRIMARY KEY,
	tenSuKien NVARCHAR(100),
	noiDungChiTiet NTEXT,
	thoiGianBatDau DATETIME,
	thoiGianKetThuc DATETIME,
	soLuongSinhVien NVARCHAR(100),
	diaDiemToChuc NVARCHAR(100),
	hoTroMuonDo ntext,
	idLienHe INT NOT NULL

	FOREIGN KEY (idLienHe) REFERENCES dbo.LienHe(id)
)

CREATE TABLE LienHe
(
	id INT IDENTITY PRIMARY KEY,
	tenThanhVien NVARCHAR(100),
	soDienThoai NVARCHAR(100)
)

INSERT INTO dbo.LienHe
			(tenThanhVien, soDienThoai)
	VALUES	(N'Lê Nhật Tường', N'0354941876')
INSERT INTO dbo.LienHe
			(tenThanhVien, soDienThoai)
	VALUES	(N'Đặng Thị Ngọc Hân', N'0782928397')

INSERT INTO dbo.SuKien
		(tenSuKien, noiDungChiTiet, thoiGianBatDau, thoiGianKetThuc, soLuongSinhVien, diaDiemToChuc, hoTroMuonDo, idLienHe)
VALUES	(N'Sinh Hoạt CLB', N'Hoạt náo, khai xuân', '2020-04-03 17:00:00', '2020-04-03 20:00:00', N'Tất cả thành viên VSC', N'E1-503', N'No', 1)

INSERT INTO dbo.SuKien
		(tenSuKien, noiDungChiTiet, thoiGianBatDau, thoiGianKetThuc, soLuongSinhVien, diaDiemToChuc, hoTroMuonDo, idLienHe)
VALUES	(N'Họp BCH', N'Họp định kỳ', '2020-04-04 17:00:00', '2020-04-04 20:00:00', N'Tất cả thành viên BCH', N'E1-403', N'Máy quét', 2)

INSERT INTO dbo.SuKien
		(tenSuKien, noiDungChiTiet, thoiGianBatDau, thoiGianKetThuc, soLuongSinhVien, diaDiemToChuc, hoTroMuonDo, idLienHe)
VALUES	(N'Hội thi "Phong cách cán bộ Đoàn - UTE" năm 2020', N'Cho các thí sinh thi đó bạn', '2020-04-04 17:00:00', '2020-04-04 20:00:00', N'Tất cả thành viên BCH', N'Thi Onl', N'Máy quét', 1)

CREATE TABLE TaiKhoan
(
	tenTaiKhoan NVARCHAR(100) PRIMARY KEY,
	tenHienThi NVARCHAR(100)  NOT NULL DEFAULT N'Đoàn viên',
	matKhau NVARCHAR(1000) NOT NULL DEFAULT 0,
	loaiTaiKhoan INT NOT NULL DEFAULT 0 -- 1: Thành viên BCH, 0: đoàn viên
)
GO


INSERT INTO dbo.TaiKhoan
			(tenTaiKhoan, tenHienThi, matKhau, loaiTaiKhoan)
	VALUES	(N'TuongLe', N'Lê Nhật Tường', N'123456', 1)


CREATE PROC USP_GetSuKienByDate
@ngayBatDau DATETIME, @ngayKetThuc DATETIME
AS
BEGIN
	SELECT * 
	FROM dbo.SuKien
	WHERE CONVERT(DATE, thoiGianBatDau) >= CONVERT(DATE, @ngayBatDau) AND CONVERT(DATE, thoiGianBatDau) <= CONVERT(DATE, @ngayKetThuc)
	--WHERE thoiGianBatDau >= @ngayBatDau AND thoiGianBatDau <= @ngayKetThuc
	ORDER BY thoiGianBatDau
END
GO

CREATE PROC USP_GetSuKienByOneDate
@ngayCanXet DATETIME
AS
BEGIN
	SELECT *
	FROM dbo.SuKien
	WHERE CONVERT(DATE, thoiGianBatDau) = CONVERT(DATE, @ngayCanXet)
	--WHERE thoiGianBatDau >= @ngayBatDau AND thoiGianBatDau <= @ngayKetThuc
END
GO

CREATE PROC USP_InsertSuKien
@tenSuKien NVARCHAR(100), @noiDungChiTiet NTEXT,  @thoiGianBatDau DATETIME,	@thoiGianKetThuc DATETIME,	@soLuongSinhVien NVARCHAR(100),
@diaDiemToChuc NVARCHAR(100), @hoTroMuonDo ntext, @idLienHe INT
AS
BEGIN
	INSERT INTO dbo.SuKien
			(tenSuKien, noiDungChiTiet, thoiGianBatDau, thoiGianKetThuc, soLuongSinhVien, diaDiemToChuc, hoTroMuonDo, idLienHe)
	VALUES	(@tenSuKien, @noiDungChiTiet, @thoiGianBatDau, @thoiGianKetThuc, @soLuongSinhVien, @diaDiemToChuc, @hoTroMuonDo, @idLienHe)
END
GO

CREATE PROC USP_DeleteSuKienByID
@idSuKien INT
AS
BEGIN
	DELETE dbo.SuKien WHERE id = @idSuKien
END
GO

CREATE PROC USP_UpDateSuKienByID
@id INT, @tenSuKien NVARCHAR(100), @noiDungChiTiet NTEXT,  @thoiGianBatDau DATETIME,	@thoiGianKetThuc DATETIME,	@soLuongSinhVien NVARCHAR(100),
@diaDiemToChuc NVARCHAR(100), @hoTroMuonDo ntext, @idLienHe INT
AS
BEGIN
	UPDATE dbo.SuKien SET
			tenSuKien = @tenSuKien , noiDungChiTiet = @noiDungChiTiet, thoiGianBatDau = @thoiGianBatDau, 
			thoiGianKetThuc = @thoiGianKetThuc, soLuongSinhVien = @soLuongSinhVien, diaDiemToChuc = @diaDiemToChuc, 
			hoTroMuonDo = @hoTroMuonDo, idLienHe = @idLienHe WHERE id = @id
END
GO

CREATE PROC USP_DangNhap
@tenTaiKhoan NVARCHAR (100), @matKhau NVARCHAR(1000)
AS
BEGIN
		SELECT * FROM dbo.TaiKhoan WHERE tenTaiKhoan = @tenTaiKhoan AND matKhau = @matKhau
END
GO

CREATE PROC USP_InsertLienHe
@tenLienhe NVARCHAR(100), @soDienThoai NVARCHAR(100)
AS
BEGIN
	INSERT INTO dbo.LienHe
			(tenThanhVien, soDienThoai)
	VALUES	(@tenLienhe, @soDienThoai)
END
GO

CREATE PROC USP_UpDateLienHeByID
@id INT, @tenThanhVien NVARCHAR(100), @soDienThoai NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.LienHe SET tenThanhVien = @tenThanhVien , soDienThoai = @soDienThoai WHERE id = @id
END
GO

DELETE dbo.LienHe WHERE id = 3

EXEC USP_InsertSuKien N'aaaa' , N'aaaa', '2020-03-02 17:00:00' , '2020-03-02 17:00:00' , N'aaaa' , N'aaaa' , N'aaaa' , 1

SELECT * FROM dbo.SuKien, dbo.LienHe WHERE SuKien.idLienHe = LienHe.id AND SuKien.id = 1

SELECT * FROM dbo.SuKien WHERE thoiGianBatDau = '2020-03-02 17:00:00'