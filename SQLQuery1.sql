create database StoreManagement
go

use StoreManagement
go

--drop database Test2
--go

create table SanPham 
(
    AnhSanPham image,
    MaSanPham varchar(10) not null,
    TenSanPham nvarchar(50) not null,
    MaLoai varchar(10),
    SoLuong int not null,
    GiaTien float not null,
    
    constraint PK_SanPham primary key (MaSanPham)
)
go

create table PhanLoai
(
    MaLoai varchar(10) not null,
    TenLoai nvarchar(25) not null
    
    constraint PK_NhaCungCap primary key (MaLoai)
)
go

create table KhachHang
(
    MaKH varchar(10) not null,
    TenKH nvarchar(25),
    Sdt varchar(11),
    GhiChu nvarchar(50)

    constraint PK_KhachHang primary key (MaKH)
)
go

create table HoaDon
(
    MaHoaDon varchar(10) not null,
    NgayBan date not null,
    ThanhTien float not null,
    MaKH varchar(10) not null,
    Ghichu nvarchar(50)

    constraint PK_HoaDon primary key (MaHoaDon)
)
go

create table ChiTietHoaDon
(
    MaHoaDon varchar(10) not null,
    MaSanPham varchar(10) not null,
    SoLuong int not null,
    DonGia float not null,
    GiamGia int not null,
    ThanhTien float not null,

    constraint PK_ChiTietHoaDon primary key (MaHoaDon,MaSanPham)
)
go

alter table SanPham 
add constraint FK_PhanLoai_SanPham foreign key (MaLoai) references PhanLoai(MaLoai)
go

alter table HoaDon
add constraint FK_KhachHang_HoaDon foreign key (MaKH) references KhachHang(MaKH)
go

alter table ChiTietHoaDon
add constraint FK_HoaDon_CTHD foreign key (MaHoaDon) references HoaDon(MaHoaDon)
go

alter table ChiTietHoaDon
add constraint FK_SanPham_CTHD foreign key (MaSanPham) references SanPham(MaSanPham)
go

