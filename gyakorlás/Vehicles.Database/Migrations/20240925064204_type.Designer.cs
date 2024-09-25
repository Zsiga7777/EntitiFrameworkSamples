﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vehicles.Database;

#nullable disable

namespace Vehicles.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240925064204_type")]
    partial class type
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Vehicles.Database.Entities.ColorEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.HasKey("Id");

                    b.HasIndex("Name", "Code")
                        .IsUnique();

                    b.ToTable("Color");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Code = "ffffff",
                            Name = "White"
                        },
                        new
                        {
                            Id = 2L,
                            Code = "000000",
                            Name = "Black"
                        });
                });

            modelBuilder.Entity("Vehicles.Database.Entities.FieldOfUseEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("FieldOfUse");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Normal"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Taxi"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Freight transport"
                        });
                });

            modelBuilder.Entity("Vehicles.Database.Entities.ManufacturerEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Ceo")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<long>("FoundationYear")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.ModelEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ChassisType")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<string>("EngineType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<long>("ManufacturerId")
                        .HasColumnType("bigint");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("ModelName")
                        .IsUnique();

                    b.ToTable("Model");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.TypeEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Type");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Car"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Truck"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Bus"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Motorcycle"
                        });
                });

            modelBuilder.Entity("Vehicles.Database.Entities.VehicleEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ChassisNumber")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<long>("ColorId")
                        .HasColumnType("bigint");

                    b.Property<string>("EngineNumber")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<long>("FieldOfUseId")
                        .HasColumnType("bigint");

                    b.Property<string>("LicencePlate")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<long>("ModelId")
                        .HasColumnType("bigint");

                    b.Property<long>("NumberOfDoors")
                        .HasColumnType("bigint");

                    b.Property<long>("Power")
                        .HasColumnType("bigint");

                    b.Property<long>("TypeId")
                        .HasColumnType("bigint");

                    b.Property<long>("Weight")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("FieldOfUseId");

                    b.HasIndex("LicencePlate")
                        .IsUnique();

                    b.HasIndex("ModelId");

                    b.HasIndex("TypeId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.ModelEntity", b =>
                {
                    b.HasOne("Vehicles.Database.Entities.ManufacturerEntity", "Manufacturer")
                        .WithMany("Models")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.VehicleEntity", b =>
                {
                    b.HasOne("Vehicles.Database.Entities.ColorEntity", "Color")
                        .WithMany("Vehicles")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vehicles.Database.Entities.FieldOfUseEntity", "FieldOfUse")
                        .WithMany("Vehicles")
                        .HasForeignKey("FieldOfUseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vehicles.Database.Entities.ModelEntity", "Model")
                        .WithMany("Vehicles")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vehicles.Database.Entities.TypeEntity", "Type")
                        .WithMany("Vehicles")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("FieldOfUse");

                    b.Navigation("Model");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.ColorEntity", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.FieldOfUseEntity", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.ManufacturerEntity", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.ModelEntity", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Vehicles.Database.Entities.TypeEntity", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
