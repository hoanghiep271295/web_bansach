USE [Web_BanSach2]
GO
ALTER TABLE [dbo].[ThamGia] DROP CONSTRAINT [FK_ThamGia_TacGia]
GO
ALTER TABLE [dbo].[ThamGia] DROP CONSTRAINT [FK_ThamGia_Sach]
GO
ALTER TABLE [dbo].[Sach] DROP CONSTRAINT [FK_Sach_NhaXuatBan]
GO
ALTER TABLE [dbo].[Sach] DROP CONSTRAINT [FK_Sach_ChuDe1]
GO
ALTER TABLE [dbo].[DonHang] DROP CONSTRAINT [FK_DonHang_KhachHang]
GO
ALTER TABLE [dbo].[ChiTietDonHang] DROP CONSTRAINT [FK_ChiTietDonHang_Sach]
GO
ALTER TABLE [dbo].[ChiTietDonHang] DROP CONSTRAINT [FK_ChiTietDonHang_DonHang]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/17/17 21:14:01 ******/
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[ThamGia]    Script Date: 12/17/17 21:14:01 ******/
DROP TABLE [dbo].[ThamGia]
GO
/****** Object:  Table [dbo].[TacGia]    Script Date: 12/17/17 21:14:01 ******/
DROP TABLE [dbo].[TacGia]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 12/17/17 21:14:01 ******/
DROP TABLE [dbo].[Sach]
GO
/****** Object:  Table [dbo].[NhaXuatBan]    Script Date: 12/17/17 21:14:01 ******/
DROP TABLE [dbo].[NhaXuatBan]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 12/17/17 21:14:01 ******/
DROP TABLE [dbo].[KhachHang]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 12/17/17 21:14:01 ******/
DROP TABLE [dbo].[DonHang]
GO
/****** Object:  Table [dbo].[ChuDe]    Script Date: 12/17/17 21:14:01 ******/
DROP TABLE [dbo].[ChuDe]
GO
/****** Object:  Table [dbo].[ChiTietDonHang]    Script Date: 12/17/17 21:14:01 ******/
DROP TABLE [dbo].[ChiTietDonHang]
GO
/****** Object:  Table [dbo].[ChiTietDonHang]    Script Date: 12/17/17 21:14:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[MaDonHang] [int] NOT NULL,
	[MaSach] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [decimal](18, 0) NULL,
 CONSTRAINT [PK_ChiTietDonHang] PRIMARY KEY CLUSTERED 
(
	[MaDonHang] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChuDe]    Script Date: 12/17/17 21:14:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuDe](
	[MaChuDe] [int] IDENTITY(1,1) NOT NULL,
	[TenChuDe] [nvarchar](50) NULL,
 CONSTRAINT [PK_ChuDe] PRIMARY KEY CLUSTERED 
(
	[MaChuDe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 12/17/17 21:14:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[MaDonHang] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [int] NULL,
	[DaThanhToan] [bit] NULL,
	[NgayDatHang] [date] NULL,
	[NgayGiaoHang] [date] NULL,
	[TinhTrangGiaoHang] [bit] NULL,
 CONSTRAINT [PK_DonHang] PRIMARY KEY CLUSTERED 
(
	[MaDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 12/17/17 21:14:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhacHang] [int] IDENTITY(1,1) NOT NULL,
	[TaiKhoan] [varchar](50) NULL,
	[TenKhachHang] [nvarchar](50) NULL,
	[MatKhau] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [bit] NULL,
	[DienThoai] [varchar](50) NULL,
	[socialID] [varchar](255) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKhacHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhaXuatBan]    Script Date: 12/17/17 21:14:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhaXuatBan](
	[MaNXB] [int] IDENTITY(1,1) NOT NULL,
	[TenNXB] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[DienThoai] [varchar](50) NULL,
 CONSTRAINT [PK_NhaXuatBan] PRIMARY KEY CLUSTERED 
(
	[MaNXB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 12/17/17 21:14:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sach](
	[MaSach] [int] IDENTITY(1,1) NOT NULL,
	[TenSach] [nvarchar](50) NULL,
	[GiaBan] [decimal](18, 0) NULL,
	[MoTa] [ntext] NULL,
	[AnhBia] [varchar](100) NULL,
	[NgayCapNhat] [date] NULL,
	[SoLuongTon] [int] NULL,
	[MaNXB] [int] NULL,
	[MaChuDe] [int] NULL,
	[Moi] [bit] NULL,
 CONSTRAINT [PK_Sach] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TacGia]    Script Date: 12/17/17 21:14:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TacGia](
	[MaTacGia] [int] IDENTITY(1,1) NOT NULL,
	[TenTacGia] [nvarchar](50) NULL,
	[DienThoai] [varchar](50) NULL,
	[TieuSu] [ntext] NULL,
	[DiaChi] [nvarchar](50) NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK_TacGia] PRIMARY KEY CLUSTERED 
(
	[MaTacGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ThamGia]    Script Date: 12/17/17 21:14:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThamGia](
	[MaTacGia] [int] NOT NULL,
	[MaSach] [int] NOT NULL,
	[VaiTro] [nvarchar](50) NULL,
	[ViTri] [nvarchar](50) NULL,
 CONSTRAINT [PK_ThamGia] PRIMARY KEY CLUSTERED 
(
	[MaTacGia] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 12/17/17 21:14:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[ChuDe] ON 

INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe]) VALUES (1, N'Công nghệ thông tin')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe]) VALUES (2, N'Ngoại ngữ')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe]) VALUES (3, N'Phật Giáo')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe]) VALUES (4, N'Văn học nước ngoài')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe]) VALUES (5, N'Kinh tế')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe]) VALUES (6, N'Luật')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe]) VALUES (7, N'Khoa học kỹ thuật')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe]) VALUES (8, N'Danh nhân')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe]) VALUES (9, N'Tâm lý giáo dục')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe]) VALUES (10, N'Tiểu thuyết')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe]) VALUES (11, N'Sách giáo khoa')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe]) VALUES (12, N'Sách tham khảo')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe]) VALUES (13, N'Lịch sử địa lý')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe]) VALUES (14, N'Du lịch')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe]) VALUES (15, N'Nghệ thuật')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe]) VALUES (16, N'Tuổi teen')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe]) VALUES (17, N'Truyện tranh')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe]) VALUES (18, N'Từ điển')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe]) VALUES (19, N'Trinh thám')
SET IDENTITY_INSERT [dbo].[ChuDe] OFF
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKhacHang], [TaiKhoan], [TenKhachHang], [MatKhau], [Email], [DiaChi], [NgaySinh], [GioiTinh], [DienThoai], [socialID]) VALUES (1, N'000', N'Ducth12b', N'ocmiccho', N'nguyenxuanducth12b@gmail.com', N'Thái Lọ', CAST(0x4D910500 AS Date), 0, N'012232323212', NULL)
INSERT [dbo].[KhachHang] ([MaKhacHang], [TaiKhoan], [TenKhachHang], [MatKhau], [Email], [DiaChi], [NgaySinh], [GioiTinh], [DienThoai], [socialID]) VALUES (2, N'001', N'hoàng', N'123', N'hoang121@gmail.com', N'Hà Nội', CAST(0x0B1A0B00 AS Date), 0, N'0121212121', NULL)
INSERT [dbo].[KhachHang] ([MaKhacHang], [TaiKhoan], [TenKhachHang], [MatKhau], [Email], [DiaChi], [NgaySinh], [GioiTinh], [DienThoai], [socialID]) VALUES (3, N'002', N'YenHKT', N'yenhoangkimkt', N'yenhoangkimcc@gmail.com', N'Hà Nội', CAST(0xE51C0B00 AS Date), 0, N'012454543434', NULL)
INSERT [dbo].[KhachHang] ([MaKhacHang], [TaiKhoan], [TenKhachHang], [MatKhau], [Email], [DiaChi], [NgaySinh], [GioiTinh], [DienThoai], [socialID]) VALUES (4, N'003', N'YenHK', N'yenhoangkim', N'yenhoangkim@gmail.com', N'Hà Nội', CAST(0x51170B00 AS Date), 0, N'01212121', NULL)
INSERT [dbo].[KhachHang] ([MaKhacHang], [TaiKhoan], [TenKhachHang], [MatKhau], [Email], [DiaChi], [NgaySinh], [GioiTinh], [DienThoai], [socialID]) VALUES (5, N'004', N'abc', N'1234', N'abc@gmail.com', N'Bắc Lạng', CAST(0xE51C0B00 AS Date), 0, N'012121', NULL)
INSERT [dbo].[KhachHang] ([MaKhacHang], [TaiKhoan], [TenKhachHang], [MatKhau], [Email], [DiaChi], [NgaySinh], [GioiTinh], [DienThoai], [socialID]) VALUES (6, N'005', N'Trần Đại Quang', N'daiquan', N'quandai@gmail.com', N'Hà Nam', CAST(0x20160B00 AS Date), 1, N'01212121212', NULL)
INSERT [dbo].[KhachHang] ([MaKhacHang], [TaiKhoan], [TenKhachHang], [MatKhau], [Email], [DiaChi], [NgaySinh], [GioiTinh], [DienThoai], [socialID]) VALUES (7, N'006', N'hà Vân Xinh', N'123', N'vanha@gail.cpm', N'Bắc Ninh', CAST(0x30170B00 AS Date), 0, N'09121212', NULL)
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
SET IDENTITY_INSERT [dbo].[NhaXuatBan] ON 

INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai]) VALUES (1, N'Kim Đồng', N'Hà Nội', N'19001001')
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai]) VALUES (2, N'Nhà xuất bản trẻ', N'Cầu Giấy', N'19001002')
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai]) VALUES (3, N'Nhà xuất bản thống kê', N'Láng', N'19001003')
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai]) VALUES (4, N'Đại học quốc gia', N'Cầu Giấy', N'19001004')
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai]) VALUES (5, N'Văn hóa', N'Mỹ Đình', N'19001005')
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai]) VALUES (6, N'Thanh niên', N'Đống Đa', N'19001006')
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai]) VALUES (7, N'Nhà xuất bản tổng hợp', N'Long Biên', N'19001007')
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai]) VALUES (8, N'Nhà xuất bản Phương Đông', N'Thanh Xuân', N'19001008')
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai]) VALUES (9, N'Nhà xuất bản phụ nữ', N'Hà Đông', N'19001009')
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai]) VALUES (10, N'Nhà xuất bản thời đại', N'Ba Đình', N'19001010')
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [DiaChi], [DienThoai]) VALUES (11, N'Nhà xuất bản thống nhất', N'Mỹ Đình', N'19001011')
SET IDENTITY_INSERT [dbo].[NhaXuatBan] OFF
SET IDENTITY_INSERT [dbo].[Sach] ON 

INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (1, N'One Piece tập 1', CAST(20000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/cbqeRoX.jpg', CAST(0x5E3B0B00 AS Date), 200, 1, 9, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (2, N'One Piece tập 2', CAST(20000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/65qP83C.jpg', CAST(0x623B0B00 AS Date), 200, 2, 17, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (3, N'One Piece tập 3', CAST(20000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/hLKmGW3.jpg', CAST(0x623B0B00 AS Date), 200, 2, 17, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (4, N'One Piece tập 4', CAST(20000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/SdasXqT.jpg', CAST(0x623B0B00 AS Date), 200, 2, 17, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (5, N'One Piece tập 5', CAST(20000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/kJ4Pyd3.jpg', CAST(0x623B0B00 AS Date), 200, 2, 17, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (6, N'One Piece tập 6', CAST(20000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/NnCcWNX.jpg', CAST(0x623B0B00 AS Date), 200, 2, 17, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (7, N'One Piece tập 7', CAST(20000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/v8z3VSL.jpg', CAST(0x623B0B00 AS Date), 200, 2, 17, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (8, N'One Piece tập 8', CAST(20000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/nrZ5iZO.jpg', CAST(0x623B0B00 AS Date), 200, 2, 17, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (9, N'One Piece tập 9', CAST(20000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/nrZ5iZO.jpg', CAST(0x623B0B00 AS Date), 200, 2, 17, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (10, N'Naruto tập 1', CAST(20000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/3yu8k0E.jpg', CAST(0x623B0B00 AS Date), 100, 11, 17, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (11, N'Naruto tập 2', CAST(20000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/pdrARbR.jpg', CAST(0x623B0B00 AS Date), 100, 11, 17, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (12, N'Naruto tập 3', CAST(20000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/TaW5fmQ.jpg', CAST(0x623B0B00 AS Date), 100, 11, 17, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (13, N'Naruto tập 4', CAST(20000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/wZSHR3n.jpg', CAST(0x623B0B00 AS Date), 100, 11, 17, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (14, N'Naruto tập 5', CAST(20000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/RwUXF16.jpg', CAST(0x623B0B00 AS Date), 100, 11, 17, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (15, N'Naruto tập 6', CAST(20000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/f0eQ8o4.jpg', CAST(0x623B0B00 AS Date), 100, 11, 17, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (16, N'Naruto tập 7', CAST(20000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/wdQ70No.jpg', CAST(0x623B0B00 AS Date), 100, 11, 17, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (17, N'Naruto tập 8', CAST(20000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/pfstdx0.jpg', CAST(0x623B0B00 AS Date), 100, 11, 17, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (18, N'Naruto tập 9', CAST(20000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/2LrNV1i.jpg', CAST(0x623B0B00 AS Date), 100, 11, 17, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (19, N'Đắc nhân tâm', CAST(70000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/8tn0RXN.jpg', CAST(0x623B0B00 AS Date), 50, 1, 9, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (20, N'Hạt giống tâm hồn', CAST(100000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/PDKAGd2.jpg', CAST(0x623B0B00 AS Date), 50, 3, 9, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (21, N'Sherlock Holmes tập 2', CAST(80000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/AwQLS3h.jpg', CAST(0x623B0B00 AS Date), 30, 5, 9, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (22, N'Nghìn lẻ một đêm', CAST(200000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/l82gtcc.jpg', CAST(0x623B0B00 AS Date), 30, 6, 9, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (23, N'Lập trình android', CAST(70000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/mf2PYmo.jpg', CAST(0x623B0B00 AS Date), 30, 7, 1, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (24, N'Tự Học C# Và SQL SERVER 2008', CAST(50000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/u4l0vaj.jpg', CAST(0x623B0B00 AS Date), 30, 8, 1, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (25, N'Nghệ Thuật Phật Giáo', CAST(120000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/jrWUCA6.jpg', CAST(0x5E3B0B00 AS Date), 20, 9, 3, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (26, N'Chiến Sĩ', CAST(100000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/2oFUFE6.jpg', CAST(0x5E3B0B00 AS Date), 20, 6, 10, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (27, N'Trại hoa đỏ', CAST(100000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/GXhZX5U.jpg', CAST(0x5E3B0B00 AS Date), 20, 10, 10, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (28, N'Mưu sát tuổi thanh xuân tập 1', CAST(110000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/5PGz7FP.jpg', CAST(0x5E3B0B00 AS Date), 1, 8, 10, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (29, N'Mưu sát tuổi thanh xuân tập 2', CAST(110000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/kVBNaCa.jpg', CAST(0x5E3B0B00 AS Date), 20, 10, 10, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (30, N'Ngày cuối cùng của một tử  tù', CAST(50000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/ODiIp9d.jpg', CAST(0x5E3B0B00 AS Date), 10, 4, 1, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (31, N'Giấc mơ mỹ', CAST(200000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/znaps0s.jpg', CAST(0x623B0B00 AS Date), 20, 4, 1, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (32, N'Học toeic', CAST(80000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/d91fGAr.jpg', CAST(0x5E3B0B00 AS Date), 10, 4, 1, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (33, N'Ngày xưa có một con bò', CAST(100000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/Emma9Hl.jpg', CAST(0x5E3B0B00 AS Date), 20, 4, 1, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (34, N'Bên nhau trọn đời', CAST(70000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/Q0Kmybe.jpg', CAST(0x5E3B0B00 AS Date), 50, 8, 10, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (35, N'Hoá ra anh vẫn ở đây ', CAST(60000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/Q8GEc5D.jpg', CAST(0x5E3B0B00 AS Date), 30, 10, 10, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (36, N'Thiên thu tố quang đồng', CAST(80000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/J5Gc6Rs.jpg', CAST(0x5E3B0B00 AS Date), 50, 10, 10, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (37, N'Thiên thần và ác quỷ', CAST(200000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/27wTErm.jpg', CAST(0x683B0B00 AS Date), 30, 7, 10, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (38, N'Pháo đài số', CAST(150000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/iGJvHWI.jpg', CAST(0x683B0B00 AS Date), 20, 5, 10, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (39, N'Nhà giả kim', CAST(130000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/J2pGTmV.jpg', CAST(0x683B0B00 AS Date), 30, 5, 10, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (40, N'Cây đàn Mandolin của Đại úy Corelli', CAST(160000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/1laHnOq.jpg', CAST(0x683B0B00 AS Date), 25, 6, 10, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (41, N'50 Sắc Thái - Xám', CAST(120000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/baINhpV.jpg', CAST(0x683B0B00 AS Date), 30, 2, 10, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (42, N'Harry Potter và tên tù nhân ngục Azkaban', CAST(180000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/zHiT7zJ.jpg', CAST(0x683B0B00 AS Date), 50, 10, 10, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (43, N'Mật Mã Champa', CAST(130000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/3VGbSJ4.jpg', CAST(0x683B0B00 AS Date), 20, 11, 19, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (44, N'Cánh Cửa Thứ 4', CAST(120000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/1zkRJvI.jpg', CAST(0x683B0B00 AS Date), 30, 1, 19, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (45, N'Thập Giác Quán', CAST(110000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/6LlGUrb.jpg', CAST(0x683B0B00 AS Date), 25, 9, 19, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (46, N'Sổ Tay Từ Vựng Tiếng Anh Trình Độ A (Sách Bỏ Túi)', CAST(50000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/6uoZSE7.jpg', CAST(0x683B0B00 AS Date), 110, 8, 2, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (47, N'Sổ Tay Từ Vựng Tiếng Anh Trình Độ B (Sách Bỏ Túi)', CAST(50000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/1xMnDob.jpg', CAST(0x683B0B00 AS Date), 120, 1, 2, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (48, N'Tiếng Hàn Cấp Tốc', CAST(10000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/SxZCNmv.jpg', CAST(0x683B0B00 AS Date), 40, 9, 2, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (49, N'Tủ Sách Bách Khoa Phật Giáo - Thiền Tông Phật Pháo', CAST(250000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/kfi7B3L.jpg', CAST(0x683B0B00 AS Date), 100, 10, 3, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (50, N'Tủ Sách Phật Giáo - Răng Của Con Lạc Đà', CAST(120000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/nfetSeH.jpg', CAST(0x683B0B00 AS Date), 45, 10, 3, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (51, N'Tùng Thư Truyện Kiều', CAST(50000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/A835I0E.jpg', CAST(0x683B0B00 AS Date), 45, 10, 4, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (52, N'Don Quixote', CAST(50000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/0oxCtvx.jpg', CAST(0x683B0B00 AS Date), 40, 1, 4, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (53, N'Đồi gió hú', CAST(120000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/Q42WvjO.jpg', CAST(0x683B0B00 AS Date), 24, 9, 4, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (54, N'Chúa tể những chiếc nhẫn tập 1', CAST(50000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/0oxCtvx.jpg', CAST(0x683B0B00 AS Date), 70, 8, 4, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (55, N'Chúa tể những chiếc nhẫn tập 2', CAST(50000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/YEZGdNF.jpg', CAST(0x683B0B00 AS Date), 70, 8, 4, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (56, N'Mưu sát tuổi thanh xuân tập 3', CAST(50000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/H2G14cB.jpg', CAST(0x683B0B00 AS Date), 70, 1, 4, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (57, N'We Are Market Basket', CAST(100000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/uUhKOec.jpg', CAST(0x683B0B00 AS Date), 60, 4, 5, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (58, N'Everybody Matters', CAST(50000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/j3eJywo.jpg', CAST(0x683B0B00 AS Date), 40, 9, 5, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (59, N'The Compass and The Nail', CAST(100000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/0VAXSZg.jpg', CAST(0x683B0B00 AS Date), 60, 9, 5, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (60, N'America’s Bank', CAST(120000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/wPVjOwU.jpg', CAST(0x683B0B00 AS Date), 70, 4, 5, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (61, N'Luật Ngân Sách Nhà Nước', CAST(30000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/hErfUT8.jpg', CAST(0x683B0B00 AS Date), 20, 1, 6, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (62, N'Chính Sách Thuế Hướng Dẫn Thi Hành Các Luật Thuế', CAST(50000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/p5x0SUQ.jpg', CAST(0x683B0B00 AS Date), 40, 4, 6, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (63, N'Hướng Dẫn Thi Hành Luật Sửa Đổi Bổ Sung 2015', CAST(100000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/CBAWKTL.jpg', CAST(0x683B0B00 AS Date), 30, 8, 6, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (64, N'Chính Sách Thuế 2013 - Các Luật Thuế Mới', CAST(50000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/dcxGNth.jpg', CAST(0x683B0B00 AS Date), 23, 2, 6, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (65, N'Giáo trình đồ gá', CAST(50000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/eTK4jHd.jpg', CAST(0x683B0B00 AS Date), 15, 7, 7, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (66, N'Giáo trình trắc địa Biển', CAST(200000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/87CBZbn.jpg', CAST(0x683B0B00 AS Date), 10, 11, 7, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (67, N'Sàn sườn bê tông cốt thép toàn khối', CAST(70000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/AD5KTjE.jpg', CAST(0x683B0B00 AS Date), 42, 10, 7, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (68, N'Bộ Sách Giáo Khoa Lớp 11', CAST(120000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/IdUh3OJ.jpg', CAST(0x683B0B00 AS Date), 160, 1, 11, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (69, N'Bộ Sách Giáo Khoa Và Bài Tập Lớp 1', CAST(100000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/2ZippWh.jpg', CAST(0x683B0B00 AS Date), 150, 9, 11, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (70, N'Bộ Sách Giáo Khoa Và Bài Tập Lớp 2', CAST(100000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/6pF68HB.jpg', CAST(0x683B0B00 AS Date), 200, 3, 11, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (71, N'Bộ Sách Giáo Khoa Lớp 4', CAST(100000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/p2myRDU.jpg', CAST(0x683B0B00 AS Date), 150, 3, 11, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (72, N'Bộ Sách Giáo Khoa Lớp 5', CAST(100000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/YvFPn0U.jpg', CAST(0x683B0B00 AS Date), 150, 4, 1, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (73, N'Hướng dẫn làm văn miêu tả', CAST(30000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/Oo5RQk4.jpg', CAST(0x683B0B00 AS Date), 20, 3, 12, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (74, N'Lịch Sử Của Sách', CAST(50000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/GpgetSi.jpg', CAST(0x683B0B00 AS Date), 14, 3, 13, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (75, N'Lịch Sử Nước Ta', CAST(1000000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/VInKjQW.jpg', CAST(0x683B0B00 AS Date), 50000, 1, 13, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (76, N'Tủ Sách Hỏi Đáp Về Đạo Cơ Đốc', CAST(20000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/UjFwUUy.jpg', CAST(0x623B0B00 AS Date), 14, 3, 13, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (77, N'scan0021_1.jpg', CAST(70000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/eG1EtAf.jpg', CAST(0x623B0B00 AS Date), 14, 3, 13, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (78, N'Địa lý du lịch Việt Nam', CAST(500000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/Ou0w8sJ.jpg', CAST(0x623B0B00 AS Date), 14, 3, 13, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (79, N'dia_ly_du_lich_viet_nam.jpg', CAST(70000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/F7O8G6H.jpg', CAST(0x623B0B00 AS Date), 14, 3, 13, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (80, N'Sổ tay du lịch miền Bắc', CAST(20000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/pbUWHxh.jpg', CAST(0x683B0B00 AS Date), 40, 5, 14, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (81, N'Sổ tay du lịch miền Nam', CAST(30000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/xS59a4m.jpg', CAST(0x683B0B00 AS Date), 15, 4, 1, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (82, N'Sổ tay du lịch miền Trung', CAST(30000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/QSXzsqU.jpg', CAST(0x683B0B00 AS Date), 14, 5, 14, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (83, N'Sắc Màu Nghệ Thuật', CAST(50000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/ZhSaJAq.jpg', CAST(0x623B0B00 AS Date), 14, 3, 14, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (84, N'bia_sac_mau_nghe_thuat_2-01.jpg', CAST(70000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/eSuWYci.jpg', CAST(0x623B0B00 AS Date), 1, 3, 14, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (85, N'Đọc Sách Như Một Nghệ Thuật', CAST(50000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/DHcmK5b.jpg', CAST(0x623B0B00 AS Date), 14, 3, 14, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (86, N'small_18035.jpg', CAST(70000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/QgXolRZ.jpg', CAST(0x623B0B00 AS Date), 1, 3, 14, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (87, N'Mặt Trời Rực Rỡ Nhất Ngày Đông', CAST(30000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/6FQ9M3j.jpg', CAST(0x623B0B00 AS Date), 14, 3, 14, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (88, N'mat_troi_ruc_ro_3.jpg', CAST(70000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/jA0mWP4.jpg', CAST(0x623B0B00 AS Date), 1, 3, 14, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (89, N'Từ Điển Việt - Anh', CAST(30000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/6Omn6uK.jpg', CAST(0x623B0B00 AS Date), 14, 3, 14, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (90, N'img066_12.jpg', CAST(70000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/TaNkWof.jpg', CAST(0x623B0B00 AS Date), 1, 3, 18, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (91, N'24 Giờ Trong Đời Một Người Đàn Bà', CAST(100000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/9ZbKT00.jpg', CAST(0x683B0B00 AS Date), 32, 10, 18, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (92, N'Hành Tinh Khỉ', CAST(70000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/2rEpNre.jpg', CAST(0x683B0B00 AS Date), 32, 1, 18, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (93, N'Rực Cháy', CAST(70000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/VInKjQW.jpg', CAST(0x623B0B00 AS Date), 14, 3, 18, 0)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (94, N'Marvel', CAST(70000 AS Decimal(18, 0)), N'Tác phẩm kinh điển', N'https://i.imgur.com/Ou0w8sJ.jpg', CAST(0x623B0B00 AS Date), 14, 3, 18, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (95, N'Sức mạnh đồng tiền', CAST(20000 AS Decimal(18, 0)), N'Tác phẩm truyện tranh', N'https://i.imgur.com/ZhSaJAq.jpg', CAST(0x30170B00 AS Date), 12, 3, 1, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [GiaBan], [MoTa], [AnhBia], [NgayCapNhat], [SoLuongTon], [MaNXB], [MaChuDe], [Moi]) VALUES (96, N'Cuộc Chiến Ngôi Vua', CAST(100000 AS Decimal(18, 0)), N'Sách Cho Lứa Tuổi Trưởng Thành', N'https://i.imgur.com/jA0mWP4.jpg', CAST(0x89180B00 AS Date), 34, 3, 10, 0)
SET IDENTITY_INSERT [dbo].[Sach] OFF
SET IDENTITY_INSERT [dbo].[TacGia] ON 

INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DienThoai], [TieuSu], [DiaChi], [Email]) VALUES (1, N'Marc Levy Thor ', N'123456789', N'O. Henry sinh dưới tên William Sydney Porter ngày 11 tháng 9 năm 1862 tại Greensboro, Bắc Carolina, Hoa Kỳ. Tên lót của ông là Sidney, nhưng sau đó được đổi thành Sydney năm 1898. Cha ông là bác sĩ Algernon Sydney Porter (1825–1888), và mẹ là Mary Jane Virginia Swain Porter (1833–1865). Họ lấy nhau ngày 20 tháng 4 năm 1858. Mẹ ông qua đời vì bệnh lao khi ông mới được 3 tuổi. Sau đó, Porter và cha chuyển về sống với bà nội. Ngay từ khi còn bé, Porter đã tỏ ra rất ham đọc. Ông đọc mọi thứ mình có, từ các tác phẩm kinh đển cho tới tiểu thuyết rẻ tiền. và ông theo học tại trường tư do bà cô mình,Evelina Maria Porter,làm chủ cho đến năm 1876. Sau đó ông tiếp tục theo học ở trường trung học Lindsey Street dưới sự bảo trợ của cô mình tới năm 15 tuổi. Năm 1879, ông làm việc cho hiệu y dược của ông chú, và sau đó, năm 1881, khi 19 tuổi, ông lấy bằng dược sĩ.', N'Hà Nội', N'mar@gmail.com')
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DienThoai], [TieuSu], [DiaChi], [Email]) VALUES (2, N'Diệp Lạc Vô Tâm', N'123456789', N'O. Henry sinh dưới tên William Sydney Porter ngày 11 tháng 9 năm 1862 tại Greensboro, Bắc Carolina, Hoa Kỳ. Tên lót của ông là Sidney, nhưng sau đó được đổi thành Sydney năm 1898. Cha ông là bác sĩ Algernon Sydney Porter (1825–1888), và mẹ là Mary Jane Virginia Swain Porter (1833–1865). Họ lấy nhau ngày 20 tháng 4 năm 1858. Mẹ ông qua đời vì bệnh lao khi ông mới được 3 tuổi. Sau đó, Porter và cha chuyển về sống với bà nội. Ngay từ khi còn bé, Porter đã tỏ ra rất ham đọc. Ông đọc mọi thứ mình có, từ các tác phẩm kinh đển cho tới tiểu thuyết rẻ tiền. và ông theo học tại trường tư do bà cô mình,Evelina Maria Porter,làm chủ cho đến năm 1876. Sau đó ông tiếp tục theo học ở trường trung học Lindsey Street dưới sự bảo trợ của cô mình tới năm 15 tuổi. Năm 1879, ông làm việc cho hiệu y dược của ông chú, và sau đó, năm 1881, khi 19 tuổi, ông lấy bằng dược sĩ.', N'Hà Nội', N'lac@gmail.com')
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DienThoai], [TieuSu], [DiaChi], [Email]) VALUES (3, N'Antoine Galland ', N'123456785', N'O. Henry sinh dưới tên William Sydney Porter ngày 11 tháng 9 năm 1862 tại Greensboro, Bắc Carolina, Hoa Kỳ. Tên lót của ông là Sidney, nhưng sau đó được đổi thành Sydney năm 1898. Cha ông là bác sĩ Algernon Sydney Porter (1825–1888), và mẹ là Mary Jane Virginia Swain Porter (1833–1865). Họ lấy nhau ngày 20 tháng 4 năm 1858. Mẹ ông qua đời vì bệnh lao khi ông mới được 3 tuổi. Sau đó, Porter và cha chuyển về sống với bà nội. Ngay từ khi còn bé, Porter đã tỏ ra rất ham đọc. Ông đọc mọi thứ mình có, từ các tác phẩm kinh đển cho tới tiểu thuyết rẻ tiền. và ông theo học tại trường tư do bà cô mình,Evelina Maria Porter,làm chủ cho đến năm 1876. Sau đó ông tiếp tục theo học ở trường trung học Lindsey Street dưới sự bảo trợ của cô mình tới năm 15 tuổi. Năm 1879, ông làm việc cho hiệu y dược của ông chú, và sau đó, năm 1881, khi 19 tuổi, ông lấy bằng dược sĩ.', N'Hà Nội', N'galland@gmail.com')
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DienThoai], [TieuSu], [DiaChi], [Email]) VALUES (4, N'Arthur Conan Doyle', N'123456785', N'O. Henry sinh dưới tên William Sydney Porter ngày 11 tháng 9 năm 1862 tại Greensboro, Bắc Carolina, Hoa Kỳ. Tên lót của ông là Sidney, nhưng sau đó được đổi thành Sydney năm 1898. Cha ông là bác sĩ Algernon Sydney Porter (1825–1888), và mẹ là Mary Jane Virginia Swain Porter (1833–1865). Họ lấy nhau ngày 20 tháng 4 năm 1858. Mẹ ông qua đời vì bệnh lao khi ông mới được 3 tuổi. Sau đó, Porter và cha chuyển về sống với bà nội. Ngay từ khi còn bé, Porter đã tỏ ra rất ham đọc. Ông đọc mọi thứ mình có, từ các tác phẩm kinh đển cho tới tiểu thuyết rẻ tiền. và ông theo học tại trường tư do bà cô mình,Evelina Maria Porter,làm chủ cho đến năm 1876. Sau đó ông tiếp tục theo học ở trường trung học Lindsey Street dưới sự bảo trợ của cô mình tới năm 15 tuổi. Năm 1879, ông làm việc cho hiệu y dược của ông chú, và sau đó, năm 1881, khi 19 tuổi, ông lấy bằng dược sĩ.', N'Hà Nội', N'author@gmail.com')
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DienThoai], [TieuSu], [DiaChi], [Email]) VALUES (5, N'Dale Carnegie', N'123456785', N'O. Henry sinh dưới tên William Sydney Porter ngày 11 tháng 9 năm 1862 tại Greensboro, Bắc Carolina, Hoa Kỳ. Tên lót của ông là Sidney, nhưng sau đó được đổi thành Sydney năm 1898. Cha ông là bác sĩ Algernon Sydney Porter (1825–1888), và mẹ là Mary Jane Virginia Swain Porter (1833–1865). Họ lấy nhau ngày 20 tháng 4 năm 1858. Mẹ ông qua đời vì bệnh lao khi ông mới được 3 tuổi. Sau đó, Porter và cha chuyển về sống với bà nội. Ngay từ khi còn bé, Porter đã tỏ ra rất ham đọc. Ông đọc mọi thứ mình có, từ các tác phẩm kinh đển cho tới tiểu thuyết rẻ tiền. và ông theo học tại trường tư do bà cô mình,Evelina Maria Porter,làm chủ cho đến năm 1876. Sau đó ông tiếp tục theo học ở trường trung học Lindsey Street dưới sự bảo trợ của cô mình tới năm 15 tuổi. Năm 1879, ông làm việc cho hiệu y dược của ông chú, và sau đó, năm 1881, khi 19 tuổi, ông lấy bằng dược sĩ.', N'Hà Nội', N'author@gmail.com')
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DienThoai], [TieuSu], [DiaChi], [Email]) VALUES (6, N'Norman Vincent Peale', N'123456785', N'O. Henry sinh dưới tên William Sydney Porter ngày 11 tháng 9 năm 1862 tại Greensboro, Bắc Carolina, Hoa Kỳ. Tên lót của ông là Sidney, nhưng sau đó được đổi thành Sydney năm 1898. Cha ông là bác sĩ Algernon Sydney Porter (1825–1888), và mẹ là Mary Jane Virginia Swain Porter (1833–1865). Họ lấy nhau ngày 20 tháng 4 năm 1858. Mẹ ông qua đời vì bệnh lao khi ông mới được 3 tuổi. Sau đó, Porter và cha chuyển về sống với bà nội. Ngay từ khi còn bé, Porter đã tỏ ra rất ham đọc. Ông đọc mọi thứ mình có, từ các tác phẩm kinh đển cho tới tiểu thuyết rẻ tiền. và ông theo học tại trường tư do bà cô mình,Evelina Maria Porter,làm chủ cho đến năm 1876. Sau đó ông tiếp tục theo học ở trường trung học Lindsey Street dưới sự bảo trợ của cô mình tới năm 15 tuổi. Năm 1879, ông làm việc cho hiệu y dược của ông chú, và sau đó, năm 1881, khi 19 tuổi, ông lấy bằng dược sĩ.', N'Hà Nội', N'author@gmail.com')
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DienThoai], [TieuSu], [DiaChi], [Email]) VALUES (7, N'Eiichiro Oda', N'123456785', N'Thánh của các thánh', N'Hà Nội', N'author@gmail.com')
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DienThoai], [TieuSu], [DiaChi], [Email]) VALUES (8, N'Kishimoto Masashi', N'123456785', N'O. Henry sinh dưới tên William Sydney Porter ngày 11 tháng 9 năm 1862 tại Greensboro, Bắc Carolina, Hoa Kỳ. Tên lót của ông là Sidney, nhưng sau đó được đổi thành Sydney năm 1898. Cha ông là bác sĩ Algernon Sydney Porter (1825–1888), và mẹ là Mary Jane Virginia Swain Porter (1833–1865). Họ lấy nhau ngày 20 tháng 4 năm 1858. Mẹ ông qua đời vì bệnh lao khi ông mới được 3 tuổi. Sau đó, Porter và cha chuyển về sống với bà nội. Ngay từ khi còn bé, Porter đã tỏ ra rất ham đọc. Ông đọc mọi thứ mình có, từ các tác phẩm kinh đển cho tới tiểu thuyết rẻ tiền. và ông theo học tại trường tư do bà cô mình,Evelina Maria Porter,làm chủ cho đến năm 1876. Sau đó ông tiếp tục theo học ở trường trung học Lindsey Street dưới sự bảo trợ của cô mình tới năm 15 tuổi. Năm 1879, ông làm việc cho hiệu y dược của ông chú, và sau đó, năm 1881, khi 19 tuổi, ông lấy bằng dược sĩ.', N'Hà Nội', N'author@gmail.com')
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DienThoai], [TieuSu], [DiaChi], [Email]) VALUES (9, N'Cố Mạn', N'123456785', N'O. Henry sinh dưới tên William Sydney Porter ngày 11 tháng 9 năm 1862 tại Greensboro, Bắc Carolina, Hoa Kỳ. Tên lót của ông là Sidney, nhưng sau đó được đổi thành Sydney năm 1898. Cha ông là bác sĩ Algernon Sydney Porter (1825–1888), và mẹ là Mary Jane Virginia Swain Porter (1833–1865). Họ lấy nhau ngày 20 tháng 4 năm 1858. Mẹ ông qua đời vì bệnh lao khi ông mới được 3 tuổi. Sau đó, Porter và cha chuyển về sống với bà nội. Ngay từ khi còn bé, Porter đã tỏ ra rất ham đọc. Ông đọc mọi thứ mình có, từ các tác phẩm kinh đển cho tới tiểu thuyết rẻ tiền. và ông theo học tại trường tư do bà cô mình,Evelina Maria Porter,làm chủ cho đến năm 1876. Sau đó ông tiếp tục theo học ở trường trung học Lindsey Street dưới sự bảo trợ của cô mình tới năm 15 tuổi. Năm 1879, ông làm việc cho hiệu y dược của ông chú, và sau đó, năm 1881, khi 19 tuổi, ông lấy bằng dược sĩ.', N'Hà Nội', N'author@gmail.com')
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DienThoai], [TieuSu], [DiaChi], [Email]) VALUES (10, N'Nam Cao', N'123456785', N'O. Henry sinh dưới tên William Sydney Porter ngày 11 tháng 9 năm 1862 tại Greensboro, Bắc Carolina, Hoa Kỳ. Tên lót của ông là Sidney, nhưng sau đó được đổi thành Sydney năm 1898. Cha ông là bác sĩ Algernon Sydney Porter (1825–1888), và mẹ là Mary Jane Virginia Swain Porter (1833–1865). Họ lấy nhau ngày 20 tháng 4 năm 1858. Mẹ ông qua đời vì bệnh lao khi ông mới được 3 tuổi. Sau đó, Porter và cha chuyển về sống với bà nội. Ngay từ khi còn bé, Porter đã tỏ ra rất ham đọc. Ông đọc mọi thứ mình có, từ các tác phẩm kinh đển cho tới tiểu thuyết rẻ tiền. và ông theo học tại trường tư do bà cô mình,Evelina Maria Porter,làm chủ cho đến năm 1876. Sau đó ông tiếp tục theo học ở trường trung học Lindsey Street dưới sự bảo trợ của cô mình tới năm 15 tuổi. Năm 1879, ông làm việc cho hiệu y dược của ông chú, và sau đó, năm 1881, khi 19 tuổi, ông lấy bằng dược sĩ.', N'Hà Nội', N'author@gmail.com')
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DienThoai], [TieuSu], [DiaChi], [Email]) VALUES (11, N'Tân Di Ổ', N'123456785', N'O. Henry sinh dưới tên William Sydney Porter ngày 11 tháng 9 năm 1862 tại Greensboro, Bắc Carolina, Hoa Kỳ. Tên lót của ông là Sidney, nhưng sau đó được đổi thành Sydney năm 1898. Cha ông là bác sĩ Algernon Sydney Porter (1825–1888), và mẹ là Mary Jane Virginia Swain Porter (1833–1865). Họ lấy nhau ngày 20 tháng 4 năm 1858. Mẹ ông qua đời vì bệnh lao khi ông mới được 3 tuổi. Sau đó, Porter và cha chuyển về sống với bà nội. Ngay từ khi còn bé, Porter đã tỏ ra rất ham đọc. Ông đọc mọi thứ mình có, từ các tác phẩm kinh đển cho tới tiểu thuyết rẻ tiền. và ông theo học tại trường tư do bà cô mình,Evelina Maria Porter,làm chủ cho đến năm 1876. Sau đó ông tiếp tục theo học ở trường trung học Lindsey Street dưới sự bảo trợ của cô mình tới năm 15 tuổi. Năm 1879, ông làm việc cho hiệu y dược của ông chú, và sau đó, năm 1881, khi 19 tuổi, ông lấy bằng dược sĩ.', N'Hà Nội', N'author@gmail.com')
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DienThoai], [TieuSu], [DiaChi], [Email]) VALUES (12, N'Tuệ Nghi ', N'123456785', N'O. Henry sinh dưới tên William Sydney Porter ngày 11 tháng 9 năm 1862 tại Greensboro, Bắc Carolina, Hoa Kỳ. Tên lót của ông là Sidney, nhưng sau đó được đổi thành Sydney năm 1898. Cha ông là bác sĩ Algernon Sydney Porter (1825–1888), và mẹ là Mary Jane Virginia Swain Porter (1833–1865). Họ lấy nhau ngày 20 tháng 4 năm 1858. Mẹ ông qua đời vì bệnh lao khi ông mới được 3 tuổi. Sau đó, Porter và cha chuyển về sống với bà nội. Ngay từ khi còn bé, Porter đã tỏ ra rất ham đọc. Ông đọc mọi thứ mình có, từ các tác phẩm kinh đển cho tới tiểu thuyết rẻ tiền. và ông theo học tại trường tư do bà cô mình,Evelina Maria Porter,làm chủ cho đến năm 1876. Sau đó ông tiếp tục theo học ở trường trung học Lindsey Street dưới sự bảo trợ của cô mình tới năm 15 tuổi. Năm 1879, ông làm việc cho hiệu y dược của ông chú, và sau đó, năm 1881, khi 19 tuổi, ông lấy bằng dược sĩ.', N'Hà Nội', N'author@gmail.com')
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DienThoai], [TieuSu], [DiaChi], [Email]) VALUES (13, N' First News', N'123456785', N'O. Henry sinh dưới tên William Sydney Porter ngày 11 tháng 9 năm 1862 tại Greensboro, Bắc Carolina, Hoa Kỳ. Tên lót của ông là Sidney, nhưng sau đó được đổi thành Sydney năm 1898. Cha ông là bác sĩ Algernon Sydney Porter (1825–1888), và mẹ là Mary Jane Virginia Swain Porter (1833–1865). Họ lấy nhau ngày 20 tháng 4 năm 1858. Mẹ ông qua đời vì bệnh lao khi ông mới được 3 tuổi. Sau đó, Porter và cha chuyển về sống với bà nội. Ngay từ khi còn bé, Porter đã tỏ ra rất ham đọc. Ông đọc mọi thứ mình có, từ các tác phẩm kinh đển cho tới tiểu thuyết rẻ tiền. và ông theo học tại trường tư do bà cô mình,Evelina Maria Porter,làm chủ cho đến năm 1876. Sau đó ông tiếp tục theo học ở trường trung học Lindsey Street dưới sự bảo trợ của cô mình tới năm 15 tuổi. Năm 1879, ông làm việc cho hiệu y dược của ông chú, và sau đó, năm 1881, khi 19 tuổi, ông lấy bằng dược sĩ.', N'Hà Nội', N'author@gmail.com')
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DienThoai], [TieuSu], [DiaChi], [Email]) VALUES (14, N' Lê Minh Quốc ', N'123456785', N'O. Henry sinh dưới tên William Sydney Porter ngày 11 tháng 9 năm 1862 tại Greensboro, Bắc Carolina, Hoa Kỳ. Tên lót của ông là Sidney, nhưng sau đó được đổi thành Sydney năm 1898. Cha ông là bác sĩ Algernon Sydney Porter (1825–1888), và mẹ là Mary Jane Virginia Swain Porter (1833–1865). Họ lấy nhau ngày 20 tháng 4 năm 1858. Mẹ ông qua đời vì bệnh lao khi ông mới được 3 tuổi. Sau đó, Porter và cha chuyển về sống với bà nội. Ngay từ khi còn bé, Porter đã tỏ ra rất ham đọc. Ông đọc mọi thứ mình có, từ các tác phẩm kinh đển cho tới tiểu thuyết rẻ tiền. và ông theo học tại trường tư do bà cô mình,Evelina Maria Porter,làm chủ cho đến năm 1876. Sau đó ông tiếp tục theo học ở trường trung học Lindsey Street dưới sự bảo trợ của cô mình tới năm 15 tuổi. Năm 1879, ông làm việc cho hiệu y dược của ông chú, và sau đó, năm 1881, khi 19 tuổi, ông lấy bằng dược sĩ.', N'Hà Nội', N'author@gmail.com')
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DienThoai], [TieuSu], [DiaChi], [Email]) VALUES (15, N' Dr. Seuss ', N'123456785', N'O. Henry sinh dưới tên William Sydney Porter ngày 11 tháng 9 năm 1862 tại Greensboro, Bắc Carolina, Hoa Kỳ. Tên lót của ông là Sidney, nhưng sau đó được đổi thành Sydney năm 1898. Cha ông là bác sĩ Algernon Sydney Porter (1825–1888), và mẹ là Mary Jane Virginia Swain Porter (1833–1865). Họ lấy nhau ngày 20 tháng 4 năm 1858. Mẹ ông qua đời vì bệnh lao khi ông mới được 3 tuổi. Sau đó, Porter và cha chuyển về sống với bà nội. Ngay từ khi còn bé, Porter đã tỏ ra rất ham đọc. Ông đọc mọi thứ mình có, từ các tác phẩm kinh đển cho tới tiểu thuyết rẻ tiền. và ông theo học tại trường tư do bà cô mình,Evelina Maria Porter,làm chủ cho đến năm 1876. Sau đó ông tiếp tục theo học ở trường trung học Lindsey Street dưới sự bảo trợ của cô mình tới năm 15 tuổi. Năm 1879, ông làm việc cho hiệu y dược của ông chú, và sau đó, năm 1881, khi 19 tuổi, ông lấy bằng dược sĩ.', N'Hà Nội', N'author@gmail.com')
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DienThoai], [TieuSu], [DiaChi], [Email]) VALUES (16, N'Mr Bean', N'123456785', N'Là tác giả trẻ của Trung Quốc', N'Hà Nội', N'author@gmail.com')
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [DienThoai], [TieuSu], [DiaChi], [Email]) VALUES (18, N'Anh Thư', N'123456785', N'O. Henry sinh dưới tên William Sydney Porter ngày 11 tháng 9 năm 1862 tại Greensboro, Bắc Carolina, Hoa Kỳ. Tên lót của ông là Sidney, nhưng sau đó được đổi thành Sydney năm 1898. Cha ông là bác sĩ Algernon Sydney Porter (1825–1888), và mẹ là Mary Jane Virginia Swain Porter (1833–1865). Họ lấy nhau ngày 20 tháng 4 năm 1858. Mẹ ông qua đời vì bệnh lao khi ông mới được 3 tuổi. Sau đó, Porter và cha chuyển về sống với bà nội. Ngay từ khi còn bé, Porter đã tỏ ra rất ham đọc. Ông đọc mọi thứ mình có, từ các tác phẩm kinh đển cho tới tiểu thuyết rẻ tiền. và ông theo học tại trường tư do bà cô mình,Evelina Maria Porter,làm chủ cho đến năm 1876. Sau đó ông tiếp tục theo học ở trường trung học Lindsey Street dưới sự bảo trợ của cô mình tới năm 15 tuổi. Năm 1879, ông làm việc cho hiệu y dược của ông chú, và sau đó, năm 1881, khi 19 tuổi, ông lấy bằng dược sĩ.', N'Hà Nội', N'author@gmail.com')
SET IDENTITY_INSERT [dbo].[TacGia] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [UserName], [Password], [Email]) VALUES (1, N'hoang', N'123', N'hoang@gmail.com')
INSERT [dbo].[User] ([ID], [UserName], [Password], [Email]) VALUES (2, N'hiep', N'234', N'hiep@gmail.com')
INSERT [dbo].[User] ([ID], [UserName], [Password], [Email]) VALUES (3, N'ana', N'123', N'ana@gmail.com')
INSERT [dbo].[User] ([ID], [UserName], [Password], [Email]) VALUES (4, N'oscar ', N'345', N'oscar@gmail.com')
INSERT [dbo].[User] ([ID], [UserName], [Password], [Email]) VALUES (5, N'hoanglong', N'123', N'longlong@gmail.com')
INSERT [dbo].[User] ([ID], [UserName], [Password], [Email]) VALUES (6, N'hoanganh', N'123', N'hoanganh@gmail.com')
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_DonHang] FOREIGN KEY([MaDonHang])
REFERENCES [dbo].[DonHang] ([MaDonHang])
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_DonHang]
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_Sach]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKhacHang])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_KhachHang]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_ChuDe1] FOREIGN KEY([MaChuDe])
REFERENCES [dbo].[ChuDe] ([MaChuDe])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_ChuDe1]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_NhaXuatBan] FOREIGN KEY([MaNXB])
REFERENCES [dbo].[NhaXuatBan] ([MaNXB])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_NhaXuatBan]
GO
ALTER TABLE [dbo].[ThamGia]  WITH CHECK ADD  CONSTRAINT [FK_ThamGia_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[ThamGia] CHECK CONSTRAINT [FK_ThamGia_Sach]
GO
ALTER TABLE [dbo].[ThamGia]  WITH CHECK ADD  CONSTRAINT [FK_ThamGia_TacGia] FOREIGN KEY([MaTacGia])
REFERENCES [dbo].[TacGia] ([MaTacGia])
GO
ALTER TABLE [dbo].[ThamGia] CHECK CONSTRAINT [FK_ThamGia_TacGia]
GO
