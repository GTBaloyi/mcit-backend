﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.DataAccess.Repositories;

namespace backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200621152609_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("backend.DataAccess.Database.Entities.EmailTemplateEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("code")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("email_type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("email_templates");
                });

            modelBuilder.Entity("backend.DataAccess.Database.Entities.EnquiryEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("company")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("company_registration_number")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("enquiry_date")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("expected_completion")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("focus_area_fk")
                        .HasColumnType("int");

                    b.Property<int>("product_expectation_fk")
                        .HasColumnType("int");

                    b.Property<double>("project_budget")
                        .HasColumnType("double");

                    b.Property<string>("quarter")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("service_tech_fk")
                        .HasColumnType("int");

                    b.Property<int>("socio_economic_impact_fk")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("enquiry");
                });

            modelBuilder.Entity("backend.DataAccess.Database.Entities.InvoiceEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Vat")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("bill_to_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("date_due")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("invoice_date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<string>("reference")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("subtotal")
                        .HasColumnType("double");

                    b.Property<string>("terms")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("total")
                        .HasColumnType("double");

                    b.Property<double>("total_due")
                        .HasColumnType("double");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.Property<string>("usersusername")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("vat_number")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.HasIndex("usersusername");

                    b.ToTable("invoice");
                });

            modelBuilder.Entity("backend.DataAccess.Entities.AccessLevelEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("level")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("access_levels");
                });

            modelBuilder.Entity("backend.DataAccess.Entities.CompanyEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("company_profile")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("isCompanyPresent")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("quarter")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("registration_number")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("backend.DataAccess.Entities.CompanyRepresentativeEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("avatar_path")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("company_fk")
                        .HasColumnType("int");

                    b.Property<DateTime>("date_captured")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("gender")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("phone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("surname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("company_representative");
                });

            modelBuilder.Entity("backend.DataAccess.Entities.UserStatusEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("user_status");
                });

            modelBuilder.Entity("backend.DataAccess.Entities.UsersEntity", b =>
                {
                    b.Property<string>("username")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("access_fk")
                        .HasColumnType("int");

                    b.Property<int>("company_rep_fk")
                        .HasColumnType("int");

                    b.Property<DateTime>("last_login")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("location")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("otp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("retry")
                        .HasColumnType("int");

                    b.Property<int>("user_status_fk")
                        .HasColumnType("int");

                    b.HasKey("username");

                    b.ToTable("users");
                });

            modelBuilder.Entity("backend.DataAccess.Database.Entities.InvoiceEntity", b =>
                {
                    b.HasOne("backend.DataAccess.Entities.UsersEntity", "users")
                        .WithMany()
                        .HasForeignKey("usersusername");
                });
#pragma warning restore 612, 618
        }
    }
}