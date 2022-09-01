﻿// <auto-generated />
using System;
using Exsm3945_Assignment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Exsm3945_Assignment.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_general_ci")
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("Exsm3945_Assignment.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("ID");

                    b.Property<int>("AccountTypeId")
                        .HasColumnType("int(11)")
                        .HasColumnName("Account_Type_ID");

                    b.Property<decimal>("Balance")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int(11)")
                        .HasColumnName("Client_ID");

                    b.Property<DateOnly?>("InterestAppliedDate")
                        .HasColumnType("date")
                        .HasColumnName("Interest_Applied_Date");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "AccountTypeId" }, "Account_Type_ID");

                    b.HasIndex(new[] { "ClientId" }, "Client_ID");

                    b.ToTable("account");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountTypeId = 1,
                            Balance = 0m,
                            ClientId = 1,
                            InterestAppliedDate = new DateOnly(1998, 1, 9)
                        },
                        new
                        {
                            Id = 2,
                            AccountTypeId = 2,
                            Balance = 0m,
                            ClientId = 1,
                            InterestAppliedDate = new DateOnly(1979, 5, 25)
                        },
                        new
                        {
                            Id = 3,
                            AccountTypeId = 3,
                            Balance = 0m,
                            ClientId = 2,
                            InterestAppliedDate = new DateOnly(2004, 4, 28)
                        },
                        new
                        {
                            Id = 4,
                            AccountTypeId = 2,
                            Balance = 0m,
                            ClientId = 3,
                            InterestAppliedDate = new DateOnly(2010, 8, 3)
                        },
                        new
                        {
                            Id = 5,
                            AccountTypeId = 1,
                            Balance = 0m,
                            ClientId = 3,
                            InterestAppliedDate = new DateOnly(2001, 5, 16)
                        },
                        new
                        {
                            Id = 6,
                            AccountTypeId = 2,
                            Balance = 0m,
                            ClientId = 4,
                            InterestAppliedDate = new DateOnly(2008, 2, 14)
                        },
                        new
                        {
                            Id = 7,
                            AccountTypeId = 3,
                            Balance = 0m,
                            ClientId = 2,
                            InterestAppliedDate = new DateOnly(2019, 10, 5)
                        });
                });

            modelBuilder.Entity("Exsm3945_Assignment.Models.AccountType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("ID");

                    b.Property<decimal>("InterestRate")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("Interest_Rate");

                    b.Property<string>("Name")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.ToTable("account_type");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InterestRate = 0.35m,
                            Name = "Chequing"
                        },
                        new
                        {
                            Id = 2,
                            InterestRate = 0.86m,
                            Name = "Savings"
                        },
                        new
                        {
                            Id = 3,
                            InterestRate = 1.50m,
                            Name = "Retirement"
                        });
                });

            modelBuilder.Entity("Exsm3945_Assignment.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("ID");

                    b.Property<string>("Address")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Address");

                    b.Property<DateOnly>("Dob")
                        .HasColumnType("date")
                        .HasColumnName("DOB");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("First_Name");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Last_Name");

                    b.HasKey("Id");

                    b.ToTable("client");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "151 Military Ave",
                            Dob = new DateOnly(1958, 3, 5),
                            FirstName = "Johnny",
                            LastName = "English"
                        },
                        new
                        {
                            Id = 2,
                            Address = "915 Halifax Rd.",
                            Dob = new DateOnly(1960, 5, 22),
                            FirstName = "Kirk ",
                            LastName = "Grimes"
                        },
                        new
                        {
                            Id = 3,
                            Address = "919 Old Theatre Court",
                            Dob = new DateOnly(1963, 6, 4),
                            FirstName = "Izzie ",
                            LastName = "Cash"
                        },
                        new
                        {
                            Id = 4,
                            Address = "7363 South Gulf St",
                            Dob = new DateOnly(1964, 10, 30),
                            FirstName = "Lachlan ",
                            LastName = "Kent"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Exsm3945_Assignment.Models.Account", b =>
                {
                    b.HasOne("Exsm3945_Assignment.Models.AccountType", "AccountType")
                        .WithMany("Accounts")
                        .HasForeignKey("AccountTypeId")
                        .IsRequired()
                        .HasConstraintName("account_ibfk_2");

                    b.HasOne("Exsm3945_Assignment.Models.Client", "Client")
                        .WithMany("Accounts")
                        .HasForeignKey("ClientId")
                        .IsRequired()
                        .HasConstraintName("account_ibfk_1");

                    b.Navigation("AccountType");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Exsm3945_Assignment.Models.AccountType", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("Exsm3945_Assignment.Models.Client", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
