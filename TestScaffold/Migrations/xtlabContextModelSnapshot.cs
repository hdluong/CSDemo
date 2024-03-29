﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestScaffold.Models;

namespace TestScaffold.Migrations
{
    [DbContext(typeof(xtlabContext))]
    partial class xtlabContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestScaffold.Models.Cungcap", b =>
                {
                    b.Property<int>("CungcapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CungcapID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Diachi")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Dienthoai")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FullName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("MaBuudien")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Quocgia")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TenLienhe")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Thanhpho")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("CungcapId");

                    b.ToTable("Cungcap");
                });

            modelBuilder.Entity("TestScaffold.Models.Danhmuc", b =>
                {
                    b.Property<int>("DanhmucId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DanhmucID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MoTa")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TenDanhMuc")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("DanhmucId");

                    b.ToTable("Danhmuc");
                });

            modelBuilder.Entity("TestScaffold.Models.Donhang", b =>
                {
                    b.Property<int>("DonhangId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DonhangID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("KhachhangId")
                        .HasColumnType("int")
                        .HasColumnName("KhachhangID");

                    b.Property<DateTime?>("Ngaydathang")
                        .HasColumnType("date");

                    b.Property<int?>("NhanvienId")
                        .HasColumnType("int")
                        .HasColumnName("NhanvienID");

                    b.Property<int?>("ShipperId")
                        .HasColumnType("int")
                        .HasColumnName("ShipperID");

                    b.HasKey("DonhangId");

                    b.ToTable("Donhang");
                });

            modelBuilder.Entity("TestScaffold.Models.DonhangChitiet", b =>
                {
                    b.Property<int>("DonhangChitietId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DonhangChitietID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DonhangId")
                        .HasColumnType("int")
                        .HasColumnName("DonhangID");

                    b.Property<int?>("SanphamId")
                        .HasColumnType("int")
                        .HasColumnName("SanphamID");

                    b.Property<int?>("Soluong")
                        .HasColumnType("int");

                    b.HasKey("DonhangChitietId");

                    b.ToTable("DonhangChitiet");
                });

            modelBuilder.Entity("TestScaffold.Models.Khachhang", b =>
                {
                    b.Property<int>("KhachhangId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KhachhangID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Diachi")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("HoTen")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("MaBuudien")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("QuocGia")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TenLienLac")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Thanhpho")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("KhachhangId");

                    b.ToTable("Khachhang");
                });

            modelBuilder.Entity("TestScaffold.Models.Nhanvien", b =>
                {
                    b.Property<int>("NhanviennId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("NhanviennID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Anh")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Ghichu")
                        .HasColumnType("text");

                    b.Property<string>("Ho")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("date");

                    b.Property<string>("Ten")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("NhanviennId")
                        .HasName("PK__Nhanvien__92550447826C7F23");

                    b.ToTable("Nhanvien");
                });

            modelBuilder.Entity("TestScaffold.Models.Sanpham", b =>
                {
                    b.Property<int>("SanphamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SanphamID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CungcapId")
                        .HasColumnType("int")
                        .HasColumnName("CungcapID");

                    b.Property<int?>("DanhmucId")
                        .HasColumnType("int")
                        .HasColumnName("DanhmucID");

                    b.Property<string>("Donvi")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal?>("Gia")
                        .HasColumnType("decimal(13,2)");

                    b.Property<string>("TenSanpham")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("SanphamId");

                    b.ToTable("Sanpham");
                });

            modelBuilder.Entity("TestScaffold.Models.Shipper", b =>
                {
                    b.Property<int>("ShipperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ShipperID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Hoten")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Sodienthoai")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ShipperId");

                    b.ToTable("Shippers");
                });
#pragma warning restore 612, 618
        }
    }
}
