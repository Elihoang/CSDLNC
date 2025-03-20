﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using demo_csdlnc.Models;

#nullable disable

namespace demo_csdlnc.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("demo_csdlnc.Models.Account", b =>
                {
                    b.Property<int>("MaAccount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaAccount"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaAccount");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("demo_csdlnc.Models.DangKy", b =>
                {
                    b.Property<int>("MaDangKy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDangKy"));

                    b.Property<int?>("MaNguoiXetDuyet")
                        .HasColumnType("int");

                    b.Property<int>("MaSV")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayDangKy")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaDangKy");

                    b.HasIndex("MaNguoiXetDuyet");

                    b.HasIndex("MaSV");

                    b.ToTable("DangKys");
                });

            modelBuilder.Entity("demo_csdlnc.Models.KetQua", b =>
                {
                    b.Property<int>("MaKetQua")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKetQua"));

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaNguoiXetDuyet")
                        .HasColumnType("int");

                    b.Property<int>("MaSV")
                        .HasColumnType("int");

                    b.Property<string>("NamHoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("XepLoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaKetQua");

                    b.HasIndex("MaNguoiXetDuyet");

                    b.HasIndex("MaSV");

                    b.ToTable("KetQuas");
                });

            modelBuilder.Entity("demo_csdlnc.Models.Khoa", b =>
                {
                    b.Property<int>("MaKhoa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKhoa"));

                    b.Property<string>("TenKhoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaKhoa");

                    b.ToTable("Khoas");
                });

            modelBuilder.Entity("demo_csdlnc.Models.Lop", b =>
                {
                    b.Property<int>("MaLop")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaLop"));

                    b.Property<int>("MaKhoa")
                        .HasColumnType("int");

                    b.Property<string>("TenLop")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaLop");

                    b.HasIndex("MaKhoa");

                    b.ToTable("Lops");
                });

            modelBuilder.Entity("demo_csdlnc.Models.NguoiXetDuyet", b =>
                {
                    b.Property<int>("MaNguoiXetDuyet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaNguoiXetDuyet"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaAccount")
                        .HasColumnType("int");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaNguoiXetDuyet");

                    b.HasIndex("MaAccount");

                    b.ToTable("NguoiXetDuyets");
                });

            modelBuilder.Entity("demo_csdlnc.Models.SinhVien", b =>
                {
                    b.Property<int>("MaSV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaSV"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("GioiTinh")
                        .HasColumnType("bit");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaLop")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaSV");

                    b.HasIndex("MaLop");

                    b.ToTable("SinhViens");
                });

            modelBuilder.Entity("demo_csdlnc.Models.ThamGiaHoatDong", b =>
                {
                    b.Property<int>("MaThamGia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaThamGia"));

                    b.Property<int>("DiemSo")
                        .HasColumnType("int");

                    b.Property<int>("MaSV")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayThamGia")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenHoatDong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaThamGia");

                    b.HasIndex("MaSV");

                    b.ToTable("ThamGiaHoatDongs");
                });

            modelBuilder.Entity("demo_csdlnc.Models.TieuChi", b =>
                {
                    b.Property<int>("MaTieuChi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTieuChi"));

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenTieuChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaTieuChi");

                    b.ToTable("TieuChis");
                });

            modelBuilder.Entity("demo_csdlnc.Models.TieuChiSinhVien", b =>
                {
                    b.Property<int>("MaDanhGia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDanhGia"));

                    b.Property<int>("Diem")
                        .HasColumnType("int");

                    b.Property<int>("MaSV")
                        .HasColumnType("int");

                    b.Property<int>("MaTieuChi")
                        .HasColumnType("int");

                    b.Property<string>("NhanXet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaDanhGia");

                    b.HasIndex("MaSV");

                    b.HasIndex("MaTieuChi");

                    b.ToTable("TieuChiSinhViens");
                });

            modelBuilder.Entity("demo_csdlnc.Models.DangKy", b =>
                {
                    b.HasOne("demo_csdlnc.Models.NguoiXetDuyet", "NguoiXetDuyet")
                        .WithMany()
                        .HasForeignKey("MaNguoiXetDuyet");

                    b.HasOne("demo_csdlnc.Models.SinhVien", "SinhVien")
                        .WithMany()
                        .HasForeignKey("MaSV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiXetDuyet");

                    b.Navigation("SinhVien");
                });

            modelBuilder.Entity("demo_csdlnc.Models.KetQua", b =>
                {
                    b.HasOne("demo_csdlnc.Models.NguoiXetDuyet", "NguoiXetDuyet")
                        .WithMany()
                        .HasForeignKey("MaNguoiXetDuyet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("demo_csdlnc.Models.SinhVien", "SinhVien")
                        .WithMany()
                        .HasForeignKey("MaSV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiXetDuyet");

                    b.Navigation("SinhVien");
                });

            modelBuilder.Entity("demo_csdlnc.Models.Lop", b =>
                {
                    b.HasOne("demo_csdlnc.Models.Khoa", "Khoa")
                        .WithMany("Lops")
                        .HasForeignKey("MaKhoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Khoa");
                });

            modelBuilder.Entity("demo_csdlnc.Models.NguoiXetDuyet", b =>
                {
                    b.HasOne("demo_csdlnc.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("MaAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("demo_csdlnc.Models.SinhVien", b =>
                {
                    b.HasOne("demo_csdlnc.Models.Lop", "Lop")
                        .WithMany("SinhViens")
                        .HasForeignKey("MaLop")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lop");
                });

            modelBuilder.Entity("demo_csdlnc.Models.ThamGiaHoatDong", b =>
                {
                    b.HasOne("demo_csdlnc.Models.SinhVien", "SinhVien")
                        .WithMany()
                        .HasForeignKey("MaSV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SinhVien");
                });

            modelBuilder.Entity("demo_csdlnc.Models.TieuChiSinhVien", b =>
                {
                    b.HasOne("demo_csdlnc.Models.SinhVien", "SinhVien")
                        .WithMany()
                        .HasForeignKey("MaSV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("demo_csdlnc.Models.TieuChi", "TieuChi")
                        .WithMany()
                        .HasForeignKey("MaTieuChi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SinhVien");

                    b.Navigation("TieuChi");
                });

            modelBuilder.Entity("demo_csdlnc.Models.Khoa", b =>
                {
                    b.Navigation("Lops");
                });

            modelBuilder.Entity("demo_csdlnc.Models.Lop", b =>
                {
                    b.Navigation("SinhViens");
                });
#pragma warning restore 612, 618
        }
    }
}
