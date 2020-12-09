﻿// <auto-generated />
using System;
using FenBaoApiTest.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FenBaoApiTest.Migrations
{
    [DbContext(typeof(AppDbcontext))]
    partial class AppDbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FenBaoApiTest.Models.Activity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ActivityEndTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ActivityScore")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("ActivityTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ActivtyAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ActivtyStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("ParticipantsNum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("activities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d0615df1-f3a5-4097-9c62-4f124a71596a"),
                            ActivityScore = 2.0m,
                            ActivityTime = new DateTime(2020, 12, 9, 10, 33, 2, 771, DateTimeKind.Local).AddTicks(6920),
                            ActivtyAddress = "博文楼",
                            ActivtyStatus = true,
                            Comment = "",
                            Name = "1",
                            ParticipantsNum = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
