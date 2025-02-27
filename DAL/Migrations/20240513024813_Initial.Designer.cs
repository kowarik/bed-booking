﻿// <auto-generated />
using System;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(BookingDbContext))]
    [Migration("20240513024813_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Entities.Apartment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(5000)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Rooms")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Apartments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("58bd7b2c-23d5-4806-ac0f-77eda2877805"),
                            Address = "Test Address 1",
                            CreationDate = new DateTime(2024, 5, 13, 2, 48, 10, 19, DateTimeKind.Utc).AddTicks(7137),
                            Description = "Test Description 1",
                            Price = 100m,
                            Rooms = 2,
                            Title = "Test Apartment 1",
                            UserId = new Guid("e130e306-7fe2-464d-829a-c9125b0bc3c6")
                        },
                        new
                        {
                            Id = new Guid("1221afce-35e8-4081-a8c8-51f100296772"),
                            Address = "Test Address 2",
                            CreationDate = new DateTime(2024, 5, 13, 2, 48, 10, 19, DateTimeKind.Utc).AddTicks(7167),
                            Description = "Test Description 2",
                            Price = 100m,
                            Rooms = 2,
                            Title = "Test Apartment 2",
                            UserId = new Guid("e130e306-7fe2-464d-829a-c9125b0bc3c6")
                        },
                        new
                        {
                            Id = new Guid("5432c7a3-a2d9-45a9-b86d-c0f7eca89af4"),
                            Address = "Test Address 3",
                            CreationDate = new DateTime(2024, 5, 13, 2, 48, 10, 19, DateTimeKind.Utc).AddTicks(7174),
                            Description = "Test Description 3",
                            Price = 100m,
                            Rooms = 2,
                            Title = "Test Apartment 3",
                            UserId = new Guid("e130e306-7fe2-464d-829a-c9125b0bc3c6")
                        });
                });

            modelBuilder.Entity("DAL.Entities.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfNights")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ff9a2e90-2299-4c0e-a9f9-4a67c434f4cf"),
                            ApartmentId = new Guid("58bd7b2c-23d5-4806-ac0f-77eda2877805"),
                            BookingDate = new DateTime(2024, 5, 13, 2, 48, 10, 19, DateTimeKind.Utc).AddTicks(7183),
                            CheckIn = new DateTime(2024, 5, 14, 2, 48, 10, 19, DateTimeKind.Utc).AddTicks(7184),
                            NumberOfNights = 1,
                            UserId = new Guid("e130e306-7fe2-464d-829a-c9125b0bc3c6")
                        },
                        new
                        {
                            Id = new Guid("c6628855-6406-4fc6-a182-a6a227e6fa27"),
                            ApartmentId = new Guid("58bd7b2c-23d5-4806-ac0f-77eda2877805"),
                            BookingDate = new DateTime(2024, 5, 13, 2, 48, 10, 19, DateTimeKind.Utc).AddTicks(7211),
                            CheckIn = new DateTime(2024, 5, 23, 2, 48, 10, 19, DateTimeKind.Utc).AddTicks(7212),
                            NumberOfNights = 2,
                            UserId = new Guid("e130e306-7fe2-464d-829a-c9125b0bc3c6")
                        },
                        new
                        {
                            Id = new Guid("48209baf-ec8d-47fa-9aad-3fd48422cc54"),
                            ApartmentId = new Guid("58bd7b2c-23d5-4806-ac0f-77eda2877805"),
                            BookingDate = new DateTime(2024, 5, 13, 2, 48, 10, 19, DateTimeKind.Utc).AddTicks(7218),
                            CheckIn = new DateTime(2024, 8, 21, 2, 48, 10, 19, DateTimeKind.Utc).AddTicks(7219),
                            NumberOfNights = 3,
                            UserId = new Guid("e130e306-7fe2-464d-829a-c9125b0bc3c6")
                        });
                });

            modelBuilder.Entity("DAL.Entities.Identity.BookingUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("e130e306-7fe2-464d-829a-c9125b0bc3c6"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6560df5f-b40f-47ee-bb77-c77ac55cef55",
                            Email = "user@user.com",
                            EmailConfirmed = false,
                            FirstName = "Test",
                            LastName = "User",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@USER.COM",
                            NormalizedUserName = "USER@USER.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEIaoVLqeTyebVTx3x0tUyHe25TcOuYZ00MYGNN6ojpILgDXq3giqy5KtNT+D3khLgA==",
                            PhoneNumber = "+380777777777",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "192624b3-574f-48e1-b32a-34dd98e194a6",
                            TwoFactorEnabled = false,
                            UserName = "user@user.com"
                        },
                        new
                        {
                            Id = new Guid("abd8733a-d739-4f82-b9f5-0384a0201e0d"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7edf1cfe-fdee-4753-bb51-3bdf71adafcd",
                            Email = "admin@admin.com",
                            EmailConfirmed = false,
                            FirstName = "Test",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEDRzZFMWkOV5XQxypko+aw/6qSwU+QHr1tqQQJrAwh4wX34ov8ZZ/C+DpOLMcSTThw==",
                            PhoneNumber = "+380000000000",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d71e0b05-9ecd-4214-b7b7-0c0fce9ea9c0",
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("7b1d9098-bb08-452a-9a4e-f3230ec2063d"),
                            Name = "user",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = new Guid("d2142d7b-0b22-44fb-8558-91aa31344b5a"),
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("e130e306-7fe2-464d-829a-c9125b0bc3c6"),
                            RoleId = new Guid("7b1d9098-bb08-452a-9a4e-f3230ec2063d")
                        },
                        new
                        {
                            UserId = new Guid("abd8733a-d739-4f82-b9f5-0384a0201e0d"),
                            RoleId = new Guid("d2142d7b-0b22-44fb-8558-91aa31344b5a")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Apartment", b =>
                {
                    b.HasOne("DAL.Entities.Identity.BookingUser", "User")
                        .WithMany("Apartments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.Booking", b =>
                {
                    b.HasOne("DAL.Entities.Apartment", "Apartment")
                        .WithMany("Bookings")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Identity.BookingUser", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Apartment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("DAL.Entities.Identity.BookingUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("DAL.Entities.Identity.BookingUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Identity.BookingUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("DAL.Entities.Identity.BookingUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entities.Apartment", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("DAL.Entities.Identity.BookingUser", b =>
                {
                    b.Navigation("Apartments");

                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
