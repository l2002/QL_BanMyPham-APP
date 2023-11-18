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
	TenKM nvarchar(50)
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
create table LoHang
(
	MaLo char(20) primary key,
	MaSP char(20),
	MaNCC char(20),
	NgayNhap date,
	SoLuong int,
	constraint FK_LoHang_SanPham foreign key(MaSP) references SanPham,
	constraint FK_LoHang_NhaCC foreign key(MaNCC) references NhaCC,
)
create table DonHang
(
	MaDH char(20) primary key,
	MaKH char(20),
	MaNV char(20),
	NgayDat date,
	NgayGiao date,
	TinhTrang nvarchar(20),
	TongTien money,
	constraint FK_DonHang_NhanVien foreign key(MaNV) references NhanVien,
	constraint FK_Donhang_KhachHang foreign key(MaKH) references KhachHang,
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

select * from DonHang

update DonHang set NgayGiao= '2023-02-02' where MaDH = 'DH01'