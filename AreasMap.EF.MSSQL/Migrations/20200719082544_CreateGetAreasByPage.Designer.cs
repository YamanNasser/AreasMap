﻿// <auto-generated />
using System;
using AreasMap.EF.MSSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AreasMap.EF.MSSQL.Migrations
{
    [DbContext(typeof(MsSqDbContext))]
    [Migration("20200719082544_CreateGetAreasByPage")]
    partial class CreateGetAreasByPage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.6.20312.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AreasMap.Domain.Entities.Area", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ShapeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("AreasMap.Domain.Entities.Shape", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AreaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DataAsJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaId")
                        .IsUnique();

                    b.HasIndex("TypeId");

                    b.ToTable("Shape");
                });

            modelBuilder.Entity("AreasMap.Domain.Entities.ShapeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ShapeType");
                });

            modelBuilder.Entity("AreasMap.Domain.Entities.Shapes.Circle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CoordinateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Radius")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Circle");
                });

            modelBuilder.Entity("AreasMap.Domain.Entities.Shapes.CircleCoordinate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CircleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CircleId")
                        .IsUnique();

                    b.ToTable("CircleCoordinate");
                });

            modelBuilder.Entity("AreasMap.Domain.Entities.Shapes.Polygon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CoordinateId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Polygon");
                });

            modelBuilder.Entity("AreasMap.Domain.Entities.Shapes.PolygonCoordinate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CoordinatesAsJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PolygonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PolygonId")
                        .IsUnique();

                    b.ToTable("PolygonCoordinate");
                });

            modelBuilder.Entity("AreasMap.Domain.Entities.Shapes.Rectangle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BoundsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BoundsId")
                        .IsUnique();

                    b.ToTable("Rectangle");
                });

            modelBuilder.Entity("AreasMap.Domain.Entities.Shapes.RectangleBounds", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("East")
                        .HasColumnType("float");

                    b.Property<double>("North")
                        .HasColumnType("float");

                    b.Property<Guid>("RectangleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("South")
                        .HasColumnType("float");

                    b.Property<double>("West")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("RectangleBounds");
                });

            modelBuilder.Entity("AreasMap.Domain.Entities.Shape", b =>
                {
                    b.HasOne("AreasMap.Domain.Entities.Area", "Area")
                        .WithOne("Shape")
                        .HasForeignKey("AreasMap.Domain.Entities.Shape", "AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AreasMap.Domain.Entities.ShapeType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AreasMap.Domain.Entities.Shapes.CircleCoordinate", b =>
                {
                    b.HasOne("AreasMap.Domain.Entities.Shapes.Circle", "Circle")
                        .WithOne("Coordinate")
                        .HasForeignKey("AreasMap.Domain.Entities.Shapes.CircleCoordinate", "CircleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AreasMap.Domain.Entities.Shapes.PolygonCoordinate", b =>
                {
                    b.HasOne("AreasMap.Domain.Entities.Shapes.Polygon", "Polygon")
                        .WithOne("Coordinate")
                        .HasForeignKey("AreasMap.Domain.Entities.Shapes.PolygonCoordinate", "PolygonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AreasMap.Domain.Entities.Shapes.Rectangle", b =>
                {
                    b.HasOne("AreasMap.Domain.Entities.Shapes.RectangleBounds", "Bounds")
                        .WithOne("Rectangle")
                        .HasForeignKey("AreasMap.Domain.Entities.Shapes.Rectangle", "BoundsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
