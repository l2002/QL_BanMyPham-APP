USE [master]
GO
/****** Object:  Database [QL_MyPham_DA]    Script Date: 12/5/2023 2:35:31 PM ******/
CREATE DATABASE [QL_MyPham_DA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QL_MyPham_DA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\QL_MyPham_DA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QL_MyPham_DA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\QL_MyPham_DA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QL_MyPham_DA] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QL_MyPham_DA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QL_MyPham_DA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QL_MyPham_DA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QL_MyPham_DA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QL_MyPham_DA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QL_MyPham_DA] SET ARITHABORT OFF 
GO
ALTER DATABASE [QL_MyPham_DA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QL_MyPham_DA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QL_MyPham_DA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QL_MyPham_DA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QL_MyPham_DA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QL_MyPham_DA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QL_MyPham_DA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QL_MyPham_DA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QL_MyPham_DA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QL_MyPham_DA] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QL_MyPham_DA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QL_MyPham_DA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QL_MyPham_DA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QL_MyPham_DA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QL_MyPham_DA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QL_MyPham_DA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QL_MyPham_DA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QL_MyPham_DA] SET RECOVERY FULL 
GO
ALTER DATABASE [QL_MyPham_DA] SET  MULTI_USER 
GO
ALTER DATABASE [QL_MyPham_DA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QL_MyPham_DA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QL_MyPham_DA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QL_MyPham_DA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QL_MyPham_DA] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QL_MyPham_DA] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QL_MyPham_DA', N'ON'
GO
ALTER DATABASE [QL_MyPham_DA] SET QUERY_STORE = OFF
GO
USE [QL_MyPham_DA]
GO
/****** Object:  Table [dbo].[KhuyenMai]    Script Date: 12/5/2023 2:35:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhuyenMai](
	[MaKM] [char](20) NOT NULL,
	[TenKM] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 12/5/2023 2:35:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSP] [char](20) NOT NULL,
	[TenSP] [nvarchar](50) NULL,
	[MaLoai] [char](20) NULL,
	[MaKM] [char](20) NULL,
	[MaTH] [char](20) NULL,
	[HSD] [date] NULL,
	[HinhAnh] [varchar](100) NULL,
	[GiaBan] [money] NULL,
	[MoTa] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTDonHang]    Script Date: 12/5/2023 2:35:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTDonHang](
	[MaDH] [char](20) NOT NULL,
	[MaSP] [char](20) NOT NULL,
	[SoLuongMua] [int] NULL,
	[DonGia] [money] NULL,
	[ThanhTien] [money] NULL,
 CONSTRAINT [PK_CTDonHang] PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[LOAD_CTHD_FUNC]    Script Date: 12/5/2023 2:35:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[LOAD_CTHD_FUNC] (@mahdban char(30))
returns table
as
return(SELECT MaDH,a.MaSP, b.TenSP, a.SOLUONGMUA,b.HSD, b.GiaBan, c.TenKM,a.THANHTIEN FROM CTDonHang AS a, SanPham AS b, KhuyenMai as c WHERE a.MaDH = @mahdban AND a.MaSP=b.MaSP and b.MaKM=c.MaKM)
GO

/****** Object:  Table [dbo].[ChitietdonhangOnl]    Script Date: 12/5/2023 2:35:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChitietdonhangOnl](
	[Madon] [int] NOT NULL,
	[MaSP] [char](20) NOT NULL,
	[Soluong] [int] NULL,
	[Dongia] [decimal](18, 0) NULL,
	[Thanhtien] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Chitietdonhang] PRIMARY KEY CLUSTERED 
(
	[Madon] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 12/5/2023 2:35:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[MaDH] [char](20) NOT NULL,
	[MaKH] [char](20) NULL,
	[MaNV] [char](20) NULL,
	[NgayDat] [date] NULL,
	[TongTien] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonhangOnl]    Script Date: 12/5/2023 2:35:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonhangOnl](
	[Madon] [int] IDENTITY(1,1) NOT NULL,
	[Ngaydat] [datetime] NULL,
	[Ngaygiao] [datetime] NULL,
	[Tinhtrang] [nvarchar](20) NULL,
	[MaNguoiDung] [int] NULL,
	[TongTien] [money] NULL,
 CONSTRAINT [PK_Donhang] PRIMARY KEY CLUSTERED 
(
	[Madon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 12/5/2023 2:35:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [char](20) NOT NULL,
	[TenKH] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[DienThoai] [varchar](11) NULL,
	[NgaySing] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiHang]    Script Date: 12/5/2023 2:35:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiHang](
	[MaLoai] [char](20) NOT NULL,
	[TenLoai] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoHang]    Script Date: 12/5/2023 2:35:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoHang](
	[MaLo] [char](20) NOT NULL,
	[MaSP] [char](20) NOT NULL,
	[MaNCC] [char](20) NULL,
	[NgayNhap] [date] NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_LoHang] PRIMARY KEY CLUSTERED 
(
	[MaLo] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 12/5/2023 2:35:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[MaNguoiDung] [int] IDENTITY(1,1) NOT NULL,
	[Hoten] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Dienthoai] [nchar](10) NULL,
	[Matkhau] [varchar](50) NULL,
	[IDQuyen] [int] NULL,
	[Diachi] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCC]    Script Date: 12/5/2023 2:35:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCC](
	[MaNCC] [char](20) NOT NULL,
	[TenNCC] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 12/5/2023 2:35:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [char](20) NOT NULL,
	[TenNV] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[DienThoai] [varchar](11) NULL,
	[NgaySing] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QUYEN]    Script Date: 12/5/2023 2:35:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUYEN](
	[iMaQuyen] [int] IDENTITY(1,1) NOT NULL,
	[sTenQuyen] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_QUYEN] PRIMARY KEY CLUSTERED 
(
	[iMaQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 12/5/2023 2:35:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[sMaTK] [char](10) NOT NULL,
	[sTaiKhoan] [nvarchar](50) NOT NULL,
	[sMatKhau] [nvarchar](50) NOT NULL,
	[Email] [varchar](50) NULL,
	[iMaQuyen] [int] NULL,
	[MaNV] [char](20) NULL,
 CONSTRAINT [PK_TAIKHOAN] PRIMARY KEY CLUSTERED 
(
	[sMaTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThuongHieu]    Script Date: 12/5/2023 2:35:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuongHieu](
	[MaTH] [char](20) NOT NULL,
	[TenTH] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChitietdonhangOnl]  WITH CHECK ADD  CONSTRAINT [FK_ChitietdonhangOnl_DonhangOnl] FOREIGN KEY([Madon])
REFERENCES [dbo].[DonhangOnl] ([Madon])
GO
ALTER TABLE [dbo].[ChitietdonhangOnl] CHECK CONSTRAINT [FK_ChitietdonhangOnl_DonhangOnl]
GO
ALTER TABLE [dbo].[ChitietdonhangOnl]  WITH CHECK ADD  CONSTRAINT [FK_ChitietdonhangOnl_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[ChitietdonhangOnl] CHECK CONSTRAINT [FK_ChitietdonhangOnl_SanPham]
GO
ALTER TABLE [dbo].[CTDonHang]  WITH CHECK ADD  CONSTRAINT [FK_CTDonHang_DonHang] FOREIGN KEY([MaDH])
REFERENCES [dbo].[DonHang] ([MaDH])
GO
ALTER TABLE [dbo].[CTDonHang] CHECK CONSTRAINT [FK_CTDonHang_DonHang]
GO
ALTER TABLE [dbo].[CTDonHang]  WITH CHECK ADD  CONSTRAINT [FK_CTDonHang_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[CTDonHang] CHECK CONSTRAINT [FK_CTDonHang_SanPham]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_Donhang_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_Donhang_KhachHang]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_NhanVien]
GO
ALTER TABLE [dbo].[DonhangOnl]  WITH CHECK ADD  CONSTRAINT [FK_DonhangOnl_NguoiDung] FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[DonhangOnl] CHECK CONSTRAINT [FK_DonhangOnl_NguoiDung]
GO
ALTER TABLE [dbo].[LoHang]  WITH CHECK ADD  CONSTRAINT [FK_LoHang_NhaCC] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCC] ([MaNCC])
GO
ALTER TABLE [dbo].[LoHang] CHECK CONSTRAINT [FK_LoHang_NhaCC]
GO
ALTER TABLE [dbo].[LoHang]  WITH CHECK ADD  CONSTRAINT [FK_LoHang_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[LoHang] CHECK CONSTRAINT [FK_LoHang_SanPham]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_KhuyenMai] FOREIGN KEY([MaKM])
REFERENCES [dbo].[KhuyenMai] ([MaKM])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_KhuyenMai]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiHang] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LoaiHang] ([MaLoai])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiHang]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_ThuongHieu] FOREIGN KEY([MaTH])
REFERENCES [dbo].[ThuongHieu] ([MaTH])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_ThuongHieu]
GO
ALTER TABLE [dbo].[TAIKHOAN]  WITH CHECK ADD  CONSTRAINT [FK_TAIKHOAN_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[TAIKHOAN] CHECK CONSTRAINT [FK_TAIKHOAN_NhanVien]
GO
ALTER TABLE [dbo].[TAIKHOAN]  WITH CHECK ADD  CONSTRAINT [FK_TAIKHOAN_QUYEN] FOREIGN KEY([iMaQuyen])
REFERENCES [dbo].[QUYEN] ([iMaQuyen])
GO
ALTER TABLE [dbo].[TAIKHOAN] CHECK CONSTRAINT [FK_TAIKHOAN_QUYEN]
GO
/****** Object:  StoredProcedure [dbo].[Delete_CTHDBAN_Func]    Script Date: 12/5/2023 2:35:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[Delete_CTHDBAN_Func] @mahdban char(30),@mahangxoa char(30)
as
begin
	DELETE CTDonHang WHERE MaDH=@mahdban AND MaSP = @mahangxoa
end
GO
USE [master]
GO
ALTER DATABASE [QL_MyPham_DA] SET  READ_WRITE 
GO


------------------------------CONSTRAINT
ALTER TABLE KhuyenMai
ADD CONSTRAINT df_KhuyenMai
DEFAULT 0 FOR TenKM; 
------------------------------TRIGGER

CREATE TRIGGER UPDATE_AFTERThemSP_TRIGGER ON CTDonHang AFTER INSERT 
AS	
	BEGIN
		UPDATE LoHang
		SET SOLUONG=SOLUONG-(SELECT SOLUONGMUA FROM inserted WHERE MaSP=LoHang.MaSP)
		FROM LoHang
		JOIN inserted ON LoHang.MaSP=inserted.MaSP
	END

select * from ChitietdonhangOnl
select Soluong from LoHang,SanPham where SanPham.MaSP=LoHang.MaSP

CREATE TRIGGER UPDATE_AFTERThemSPOnl_TRIGGER ON ChitietdonhangOnl AFTER INSERT
AS
BEGIN
    UPDATE LoHang
    SET LoHang.SoLuong=LoHang.SoLuong-(SELECT Soluong FROM inserted WHERE MaSP=LoHang.MaSP)
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

