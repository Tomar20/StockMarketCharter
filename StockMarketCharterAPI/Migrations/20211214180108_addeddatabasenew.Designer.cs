// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockMarketCharter.AuthAPI.DBContext;

#nullable disable

namespace StockMarketCharter.AuthAPI.Migrations
{
    [DbContext(typeof(StockMarketCharterDBContext))]
    [Migration("20211214180108_addeddatabasenew")]
    partial class addeddatabasenew
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StockMarketCharter.AuthAPI.Entities.Company", b =>
                {
                    b.Property<string>("CompanyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BOD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Brief")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SectorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StockCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StockExchangesId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TurnOver")
                        .HasColumnType("int");

                    b.HasKey("CompanyId");

                    b.HasIndex("SectorId");

                    b.HasIndex("StockExchangesId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("StockMarketCharter.AuthAPI.Entities.Sector", b =>
                {
                    b.Property<string>("SectorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SectorBrief")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SectorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SectorId");

                    b.ToTable("Sector");
                });

            modelBuilder.Entity("StockMarketCharter.AuthAPI.Entities.StockExchange", b =>
                {
                    b.Property<string>("StockExchangeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StockExchangeAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StockExchangeBrief")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StockExchangeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StockExchangeId");

                    b.ToTable("Stock Exchange");
                });

            modelBuilder.Entity("StockMarketCharter.AuthAPI.Entities.StockPrice", b =>
                {
                    b.Property<string>("StockCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CurrentPrice")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("StockExchangeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("StockCode");

                    b.HasIndex("StockExchangeId");

                    b.ToTable("Stock Price");
                });

            modelBuilder.Entity("StockMarketCharter.AuthAPI.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("StockMarketCharter.AuthAPI.Entities.Company", b =>
                {
                    b.HasOne("StockMarketCharter.AuthAPI.Entities.Sector", "Sector")
                        .WithMany()
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockMarketCharter.AuthAPI.Entities.StockExchange", "StockExchange")
                        .WithMany()
                        .HasForeignKey("StockExchangesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sector");

                    b.Navigation("StockExchange");
                });

            modelBuilder.Entity("StockMarketCharter.AuthAPI.Entities.StockPrice", b =>
                {
                    b.HasOne("StockMarketCharter.AuthAPI.Entities.StockExchange", "StockExchange")
                        .WithMany()
                        .HasForeignKey("StockExchangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StockExchange");
                });
#pragma warning restore 612, 618
        }
    }
}
