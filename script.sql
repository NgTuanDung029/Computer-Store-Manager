create database script

create table KhachHang(
	maKH nvarchar(50) primary key not null,
	tenKH nvarchar(50),
	diaChiKH nvarchar(50),
	sdtKH int
);

create table MatHang(
	maMH nvarchar(50) primary key not null,
	tenMH nvarchar(50),
	soLuong int,
	giaMH nvarchar(10),
	maLoaiMH nvarchar(50),
	foreign key (maLoaiMH) references LoaiMatHang 
);

create table LoaiMatHang(
	maLoaiMH nvarchar(50) primary key not null,
	tenLoaiMH nvarchar(50)
);

create table HoaDon(
	maHD nvarchar(50) primary key not null,
	ngayBan date,
	giaBan nvarchar(50),
	soLuongBan int,
	maMH nvarchar(50),
	maKH nvarchar(50),
	foreign key (maMH) references MatHang,
	foreign key (maKH) references KhachHang
);

