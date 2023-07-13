﻿// <auto-generated />
using System;
using CertificateManagementApi.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CertificateManagementApi.Migrations
{
    [DbContext(typeof(CertificateContextClass))]
    [Migration("20230617024440_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CertificateManagementApi.Model.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("CertificateManagementApi.Model.Certificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<string>("Signature")
                        .HasColumnType("longtext");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("CertificateManagementApi.Model.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CAC")
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("LocalGovernment")
                        .HasColumnType("longtext");

                    b.Property<string>("Logo")
                        .HasColumnType("longtext");

                    b.Property<string>("OrganizationDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("OrganizationName")
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<bool>("isApproved")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("CertificateManagementApi.Model.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CertificateManagementApi.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CertificateManagementApi.Model.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("CertificateManagementApi.Model.Admin", b =>
                {
                    b.HasOne("CertificateManagementApi.Model.User", "User")
                        .WithOne("Admin")
                        .HasForeignKey("CertificateManagementApi.Model.Admin", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CertificateManagementApi.Model.Certificate", b =>
                {
                    b.HasOne("CertificateManagementApi.Model.Organization", "Organization")
                        .WithMany("Certificates")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("CertificateManagementApi.Model.Organization", b =>
                {
                    b.HasOne("CertificateManagementApi.Model.User", "User")
                        .WithOne("Organization")
                        .HasForeignKey("CertificateManagementApi.Model.Organization", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CertificateManagementApi.Model.UserRole", b =>
                {
                    b.HasOne("CertificateManagementApi.Model.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CertificateManagementApi.Model.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CertificateManagementApi.Model.Organization", b =>
                {
                    b.Navigation("Certificates");
                });

            modelBuilder.Entity("CertificateManagementApi.Model.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("CertificateManagementApi.Model.User", b =>
                {
                    b.Navigation("Admin");

                    b.Navigation("Organization");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}