CREATE DATABASE QLTHUVIEN_DOAN
GO
USE QLTHUVIEN_DOAN
GO

--Tạo bảng Bằng cấp
CREATE TABLE [BANGCAP](
	[MaBangCap] int Identity(1,1),
	[TenBangCap] [nvarchar](40) NULL,
	CONSTRAINT [PK_BANGCAP] PRIMARY KEY (MaBangCap)
)
GO
--Tạo bảng Nhân viên
CREATE TABLE [NHANVIEN](
	[MaNhanVien] int Identity(1,1),
	[HoTenNhanVien] [nvarchar](50) NULL,
	[NgaySinh] [datetime] NULL,
	[DiaChi] [nvarchar](50) NULL,
	[DienThoai] [nvarchar](15) NULL,
	[Email] [nvarchar](30) NULL,
	[MaBangCap] [int] NULL,
	[UserName] [varchar](50),
	[Password] [varchar](50),
	CONSTRAINT [PK_NHANVIEN] PRIMARY KEY (MaNhanVien)
)
GO
--Tạo bảng Độc giả
CREATE TABLE [DOCGIA](
	[MaDocGia] [varchar](50),
	[HoTenDocGia] [nvarchar](40) NULL,
	[NgaySinh] [datetime] NULL,
	[DiaChi] [nvarchar](50) NULL,
	[Email] [nvarchar](30) NULL,
	[NgayLapThe] [datetime] NULL,
	[NgayHetHan] [datetime] NULL,
	[SoDienThoai] [varchar](12) NULL,
	CONSTRAINT [PK_DOCGIA_1] PRIMARY KEY (MaDocGia)
)
GO

--Tạo bảng Sách
CREATE TABLE [SACH](
	[MaSach] [varchar](50),
	[TenSach] [nvarchar](40) NULL,
	[TacGia] [nvarchar](30) NULL,
	[NamXuatBan] [int] NULL,
	[NhaXuatBan] [nvarchar](40) NULL,
	[TriGia] [float] NULL,
	[NgayNhap] [datetime] NULL,
	CONSTRAINT [PK_SACH] PRIMARY KEY (MaSach)
)
GO
--Tạo bảng Phiếu mượn sách
CREATE TABLE [PHIEUMUONSACH](
	[MaPhieuMuon] int Identity(1,1),
	[NgayMuon] [datetime] NOT NULL,
	[NgayTra] [datetime] NOT NULL,
	[MaDocGia] [varchar](50) NULL,
	[TrangThai] [bit] NULL,
	CONSTRAINT [PK_PHIEUMUONSACH] PRIMARY KEY (MaPhieuMuon)
)
GO
--Tạo bảng Chi tiết phiếu mượn
CREATE TABLE [CHITIETPHIEUMUON](
	[MaSach] [varchar](50) NOT NULL,
	[MaPhieuMuon] [int] NOT NULL,
	CONSTRAINT [PK_CHITIETPHIEUMUON] PRIMARY KEY (MaSach,MaPhieuMuon)
)
GO
--Tạo khoá ngoại
GO
ALTER TABLE [NHANVIEN] WITH NOCHECK ADD CONSTRAINT [FK_NHANVIEN_BANGCAP]
FOREIGN KEY([MaBangCap])
REFERENCES [BANGCAP] ([MaBangCap])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [NHANVIEN] CHECK CONSTRAINT [FK_NHANVIEN_BANGCAP]
GO
ALTER TABLE [PHIEUMUONSACH] WITH CHECK ADD CONSTRAINT
[FK_PHIEUMUONSACH_DOCGIA] FOREIGN KEY([MaDocGia])
REFERENCES [DOCGIA] ([MaDocGia])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [PHIEUMUONSACH] CHECK CONSTRAINT [FK_PHIEUMUONSACH_DOCGIA]
GO
ALTER TABLE [CHITIETPHIEUMUON] WITH CHECK ADD CONSTRAINT
[FK_CHITIETPHIEUMUON_PHIEUMUONSACH] FOREIGN KEY([MaPhieuMuon])
REFERENCES [PHIEUMUONSACH] ([MaPhieuMuon])
GO
ALTER TABLE [CHITIETPHIEUMUON] CHECK CONSTRAINT
[FK_CHITIETPHIEUMUON_PHIEUMUONSACH]
GO
ALTER TABLE [CHITIETPHIEUMUON] WITH CHECK ADD CONSTRAINT
[FK_CHITIETPHIEUMUON_SACH] FOREIGN KEY([MaSach])
REFERENCES [SACH] ([MaSach])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [CHITIETPHIEUMUON] CHECK CONSTRAINT [FK_CHITIETPHIEUMUON_SACH]

---Nhap lieu
insert into BANGCAP values(N'TIẾN SĨ')
insert into BANGCAP values(N'THẠC SĨ')
insert into BANGCAP values(N'ĐẠI HỌC')
insert into BANGCAP values(N'CAO ĐẲNG')
insert into BANGCAP values(N'TRUNG CẤP')
GO
insert into NHANVIEN values(N'PHẠM MINH VŨ','01/24/1980',N'163/30 Thành Thái F.14 Q.10 TPHCM','0905646162','email1@gmail.com',1,'a','1')
insert into NHANVIEN values(N'NGUYỄN MINH THÀNH','04/05/1983',N'41/4 CALMETTE Q1 TPHCM','0908373612','email1@gmail.com',2,'a','1')
insert into NHANVIEN values(N'NGUYỄN HÀ MY','04/13/1985',N'178 NAM KỲ KHỞI NGHĨA Q4 TPHCM','0908783274','email1@gmail.com',3,'a','1')
GO
insert into DOCGIA values('1711061667',N'NGUYỄN HOÀNG MINH','02/23/1990',N'41/4 CALMETTE Q1 TPHCM',N'hoangminh@yahoo.com','12/30/2000','12/30/2012','0122433253')
insert into DOCGIA values('1711061668',N'TRẦN VĂN CHÂU','08/29/1992',N'TRẦN HƯNG ĐẠO Q1 TPHCM',N'vanchau@yahoo.com','11/22/2001','11/22/2013','0122433253')
insert into DOCGIA values('1711061669',N'NGUYỄN HOÀNG NAM','02/21/1980',N'4 TRẦN ĐÌNH HƯNG Q1 TPHCM',N'hoangmNAM@yahoo.com','12/22/2001','12/30/2012','0122433253')
insert into DOCGIA values('1711061670',N'TRẦN THANH PHÚC','08/19/1993',N'TRƯƠNG ĐỊNH Qtb TPHCM',N'thanhphuc@yahoo.com','08/09/2001','11/22/2013','0122433253')
GO
insert into SACH values('CMP1',N'NHAP MON CNPM',N'PHẠM ĐÀO MINH VŨ',2007,N'NXB THỐNG KÊ',70000,'12/18/2008')
insert into SACH values('CMP2',N'KỸ THUẬT LẬP TRÌNH',N'TRẦN MINH THÁI',2005,N'NXB GIÁO DỤC',50000,'02/12/2006')
insert into SACH values('CMP3',N'CÔNG NGHỆ WEB',N'PHẠM ĐÀO MINH VŨ',2009,N'NXB TRẺ',90000,'12/01/2009')
GO
insert into PHIEUMUONSACH values ('11/22/2015', '12/22/2015','1711061667', 0)
insert into PHIEUMUONSACH values ('2/22/2015', '2/27/2015','1711061668', 1)
insert into PHIEUMUONSACH values ('3/22/2015', '4/22/2015','1711061669', 0)
insert into PHIEUMUONSACH values ('11/22/2016', '12/22/2016','1711061667', 1)
GO
insert into CHITIETPHIEUMUON values ('CMP1', 1)
insert into CHITIETPHIEUMUON values ('CMP3', 2)
insert into CHITIETPHIEUMUON values ('CMP2', 3)
insert into CHITIETPHIEUMUON values ('CMP1', 4)
GO