Create database QL_MyPham_DA
GO
Use QL_MyPham_DA
GO

create table LoaiHang
(
	MaLoai char(20) primary key,
	TenLoai nvarchar(50)
)
create table ThuongHieu
(
	MaTH char(20) primary key,
	TenTH nvarchar(50)
)
create table KhuyenMai
(
	MaKM char(20) primary key,
	TenKM int
)
create table NhaCC
(
	MaNCC char(20) primary key,
	TenNCC nvarchar(50)
)
create table NhanVien
(
	MaNV char(20) primary key,
	TenNV nvarchar(50),
	GioiTinh nvarchar(10),
	DiaChi nvarchar(50),
	DienThoai varchar(11),
	NgaySing Date
)
create table KhachHang
(
	MaKH char(20) primary key,
	TenKH nvarchar(50),
	DiaChi nvarchar(50),
	DienThoai varchar(11),
	NgaySing Date
)
create table SanPham
(
	MaSP char(20) primary key,
	TenSP nvarchar(50),
	MaLoai char(20),
	MaKM char(20) null,
	MaTH char(20),
	HSD Date,
	HinhAnh varchar(100),
	GiaBan money,
	constraint FK_SanPham_LoaiHang foreign key(MaLoai) references LoaiHang,
	constraint FK_SanPham_KhuyenMai foreign key(MaKM) references KhuyenMai,
	constraint FK_SanPham_ThuongHieu foreign key(MaTH) references ThuongHieu
)
alter table SanPham
Add MoTa nvarchar(200)

create table LoHang
(
	MaLo char(20),
	MaSP char(20),
	MaNCC char(20),
	NgayNhap date,
	SoLuong int,
	constraint PK_LoHang primary key(MaLo,MaSP),
	constraint FK_LoHang_SanPham foreign key(MaSP) references SanPham,
	constraint FK_LoHang_NhaCC foreign key(MaNCC) references NhaCC,
)
create table DonHang
(
	MaDH char(20) primary key,
	MaKH char(20),
	MaNV char(20),
	NgayDat date,
	TongTien money,
	constraint FK_DonHang_NhanVien foreign key(MaNV) references NhanVien,
	constraint FK_Donhang_KhachHang foreign key(MaKH) references KhachHang,
)

create table DatHang
(
	MaDH char(20) primary key,
	MaNguoidung int NULL,
	NgayDat date,
	NgayGiao date,
	TrangThai nvarchar(20),
	TongTien money,
)
ALTER TABLE [dbo].DatHang  WITH CHECK ADD  CONSTRAINT [FK_DatHang_Khachhang] FOREIGN KEY([MaNguoidung])
REFERENCES [dbo].[Nguoidung] ([MaNguoiDung])
GO
create table NguoiDung
(
	[MaNguoiDung] [int] IDENTITY(1,1) NOT NULL primary key,
	[Hoten] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Dienthoai] [nchar](10) NULL,
	[Matkhau] [varchar](50) NULL,
	[IDQuyen] [int] NULL,
	[Diachi] [nvarchar](100) NULL,
)
create table CTDonHang
(
	MaDH char(20),
	MaSP char(20),
	SoLuongMua int,
	DonGia money,
	ThanhTien money,
	constraint PK_CTDonHang primary key(MaDH,MaSP),
	constraint FK_CTDonHang_SanPham foreign key(MaSP) references SanPham,
)

-----------------Login--------------------
CREATE TABLE TAIKHOAN (
  sMaTK char(10) NOT NULL ,
  sTaiKhoan NVARCHAR(50) NOT NULL,
  sMatKhau NVARCHAR(50) NOT NULL,
  Email VARCHAR(50),
  iMaQuyen INT,
  MaNV NVARCHAR(10),
  CONSTRAINT PK_TAIKHOAN PRIMARY KEY(sMaTK),
);

CREATE TABLE QUYEN (
  iMaQuyen INT IDENTITY(1,1) NOT NULL,
  sTenQuyen NVARCHAR(50) NOT NULL,
  CONSTRAINT PK_QUYEN PRIMARY KEY (iMaQuyen)
);
ALTER TABLE TAIKHOAN
ADD CONSTRAINT FK_TAIKHOAN_QUYEN FOREIGN KEY(iMaQuyen) REFERENCES Quyen(iMaQuyen)

ALTER TABLE TAIKHOAN
ADD CONSTRAINT FK_TAIKHOAN_NhanVien FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)

select * from CTDonHang

create function LOAD_CTHD_FUNC (@mahdban char(30))
returns table
as
return(SELECT MaDH,a.MaSP, b.TenSP, a.SoLuongMua, b.GiaBan,a.ThanhTien,c.TenKM,b.HSD FROM CTDonHang AS a, SanPham AS b, KhuyenMai as c WHERE a.MaDH = @mahdban AND a.MaSP=b.MaSP AND b.MaKM=c.MaKM)
go

drop function LOAD_CTHD_FUNC

CREATE TRIGGER UPDATE_AFTERThemSP_TRIGGER ON CTDonHang AFTER INSERT 
AS	
	BEGIN
		UPDATE LoHang
		SET SOLUONG=SOLUONG-(SELECT SOLUONGMUA FROM inserted WHERE MaSP=LoHang.MaSP)
		FROM LoHang
		JOIN inserted ON LoHang.MaSP=inserted.MaSP
	END

CREATE TRIGGER UPDATE_TONGTIEN ON CTDonHang AFTER INSERT 
AS
	BEGIN
		DECLARE @TONG decimal(10,2)
		SELECT @TONG = (SELECT TongTien FROM DonHang WHERE MaDH=(SELECT MaDH FROM inserted))
		DECLARE @TONGMOI decimal(10,2)
		SELECT @TONGMOI=@TONG+(SELECT ThanhTien FROM inserted)
		UPDATE DonHang
		SET TONGTIEN= @TONGMOI WHERE MaDH=(SELECT MaDH FROM inserted)
	END

--Cập nhật lại số lượng cho các mặt hàng khi xóa số lượng hàng mua trong CTHD
CREATE TRIGGER UPDATE_AFTERXoaSP_TRIGGER ON CTDonHang AFTER DELETE 
AS
	BEGIN
		UPDATE LoHang
		SET SOLUONG=SOLUONG+(SELECT SOLUONGMUA FROM deleted WHERE MaSP=LoHang.MaSP)
		FROM LoHang
		JOIN deleted ON LoHang.MaSP=deleted.MaSP
	END

drop trigger UPDATE_AFTERXoaSP_TRIGGER
select LoHang.SoLuong from SanPham,LoHang where SanPham.MaSP=LoHang.MaSP

create proc Delete_CTHDBAN_Func @mahdban char(30),@mahangxoa char(30)
as
begin
	DELETE CTDonHang WHERE MaDH=@mahdban AND MaSP = @mahangxoa
end

select * from LOAD_CTHD_FUNC ('DH01')
select * from SanPham
SELECT GiaBan FROM SanPham WHERE MaSP = N'SP0119112023        '
select KhuyenMai.TenKM from SanPham,KhuyenMai where MaSP='SP0119112023' and SanPham.MaKM=KhuyenMai.MaKM

update DonHang set NgayGiao= '2023-02-02' where MaDH = 'DH01'
SELECT TenKH FROM KhachHang WHERE MaKH =N'KH01'
SELECT MaDH,a.MaSP, b.TenSP, a.SoLuongMua, b.GiaBan, b.MaKM,a.ThanhTien,c.TenKM,b.HSD FROM CTDonHang AS a, SanPham AS b, KhuyenMai as c WHERE a.MaDH = 'HD01' AND a.MaSP=b.MaSP AND b.MaKM=c.MaKM

SELECT TONGTIEN FROM DonHang WHERE MaDH =N'HDB11222023_133423'

select * from DonHang
select * from CTDonHang

exec Delete_CTHDBAN_Func 'HDB11242023_144523', N'SP03'

delete from DonHang
delete from CTDonHang

select * from NhanVien
select * from TAIKHOAN
select NhanVien.TenNV,NhanVien.MaNV from TAIKHOAN,NhanVien where TAIKHOAN.MaNV=NhanVien.MaNV and TAIKHOAN.sTaiKhoan='Vang'

select * from CTDonHang
select * from DatHang
select * from QUYEN
select * from TAIKHOAN

delete CTDonHang from CTDonHang,SanPham where SanPham.MaSP=CTDonHang.MaSP and MaDH= 'HDB11302023_102210    '
delete FROM DonHang WHERE MaDH = 'HDB11302023_102210  '

insert into TaiKhoan(sMaTK,sTaiKhoan,sMatKhau,Email,iMaQuyen,MaNV) values('3',N'Thien','123','thien@gmail.com','1','NV03')


SELECT SUM(SoLuongMua) AS SoSanPhamDaBan
FROM CTDonHang
INNER JOIN SanPham ON CTDonHang.MaSP = SanPham.MaSP

SELECT TenSP, SUM(SoLuongMua) AS SoLuongBanRa
FROM CTDonHang,SanPham
where SanPham.MaSP=CTDonHang.MaSP
GROUP BY TenSP
ORDER BY SoLuongBanRa DESC


SELECT TOP 10 KhachHang.TenKH as Ten, SUM(TongTien) as TongTien
FROM DonHang,KhachHang
where KhachHang.MaKH=DonHang.MaKH
GROUP BY KhachHang.TenKH
ORDER BY TongTien DESC 



