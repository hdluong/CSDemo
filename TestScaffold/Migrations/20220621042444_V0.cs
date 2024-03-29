﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestScaffold.Migrations
{
    public partial class V0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cungcap",
                columns: table => new
                {
                    CungcapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tendaydu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TenLienhe = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Diachi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Thanhpho = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaBuudien = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Quocgia = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Dienthoai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cungcap", x => x.CungcapID);
                });

            migrationBuilder.CreateTable(
                name: "Danhmuc",
                columns: table => new
                {
                    DanhmucID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDanhMuc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Danhmuc", x => x.DanhmucID);
                });

            migrationBuilder.CreateTable(
                name: "Donhang",
                columns: table => new
                {
                    DonhangID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhachhangID = table.Column<int>(type: "int", nullable: true),
                    NhanvienID = table.Column<int>(type: "int", nullable: true),
                    Ngaydathang = table.Column<DateTime>(type: "date", nullable: true),
                    ShipperID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donhang", x => x.DonhangID);
                });

            migrationBuilder.CreateTable(
                name: "DonhangChitiet",
                columns: table => new
                {
                    DonhangChitietID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonhangID = table.Column<int>(type: "int", nullable: true),
                    SanphamID = table.Column<int>(type: "int", nullable: true),
                    Soluong = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonhangChitiet", x => x.DonhangChitietID);
                });

            migrationBuilder.CreateTable(
                name: "Khachhang",
                columns: table => new
                {
                    KhachhangID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TenLienLac = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Diachi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Thanhpho = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaBuudien = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    QuocGia = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khachhang", x => x.KhachhangID);
                });

            migrationBuilder.CreateTable(
                name: "Nhanvien",
                columns: table => new
                {
                    NhanviennID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ho = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: true),
                    Anh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ghichu = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Nhanvien__92550447826C7F23", x => x.NhanviennID);
                });

            migrationBuilder.CreateTable(
                name: "Sanpham",
                columns: table => new
                {
                    SanphamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSanpham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CungcapID = table.Column<int>(type: "int", nullable: true),
                    DanhmucID = table.Column<int>(type: "int", nullable: true),
                    Donvi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Gia = table.Column<decimal>(type: "decimal(13,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanpham", x => x.SanphamID);
                });

            migrationBuilder.CreateTable(
                name: "Shippers",
                columns: table => new
                {
                    ShipperID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hoten = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Sodienthoai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippers", x => x.ShipperID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cungcap");

            migrationBuilder.DropTable(
                name: "Danhmuc");

            migrationBuilder.DropTable(
                name: "Donhang");

            migrationBuilder.DropTable(
                name: "DonhangChitiet");

            migrationBuilder.DropTable(
                name: "Khachhang");

            migrationBuilder.DropTable(
                name: "Nhanvien");

            migrationBuilder.DropTable(
                name: "Sanpham");

            migrationBuilder.DropTable(
                name: "Shippers");
        }
    }
}
