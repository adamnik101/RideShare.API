﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RideShare.DataAccess;

namespace RideShare.DataAccess.Migrations
{
    [DbContext(typeof(RideshareContext))]
    partial class RideshareContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RideShare.Domain.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("FirstRegistration")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LicencePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("ModelId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("TypeId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.CarRestriction", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("RestrictionId")
                        .HasColumnType("int");

                    b.HasKey("CarId", "RestrictionId");

                    b.HasIndex("RestrictionId");

                    b.ToTable("CarRestrictions");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.LogEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UseCaseData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UseCaseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LogEntries");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.Restriction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Restrictions");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.Ride", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<int>("EndCityId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("StartCityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("DriverId");

                    b.HasIndex("EndCityId");

                    b.HasIndex("StartCityId");

                    b.ToTable("Ride");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.RideRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("FromUserId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("RideId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("ToUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromUserId");

                    b.HasIndex("RideId");

                    b.HasIndex("ToUserId");

                    b.ToTable("RideRequests");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsDefault")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.RoleUseCase", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UseCaseId")
                        .HasColumnType("int");

                    b.HasKey("RoleId", "UseCaseId");

                    b.ToTable("RoleUseCases");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.Car", b =>
                {
                    b.HasOne("RideShare.Domain.Entities.Color", "Color")
                        .WithMany("Cars")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RideShare.Domain.Entities.Model", "Model")
                        .WithMany("Cars")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RideShare.Domain.Entities.User", "Owner")
                        .WithMany("Cars")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RideShare.Domain.Entities.Type", "Type")
                        .WithMany("Cars")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Model");

                    b.Navigation("Owner");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.CarRestriction", b =>
                {
                    b.HasOne("RideShare.Domain.Entities.Car", "Car")
                        .WithMany("CarRestrictions")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RideShare.Domain.Entities.Restriction", "Restriction")
                        .WithMany()
                        .HasForeignKey("RestrictionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Restriction");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.Model", b =>
                {
                    b.HasOne("RideShare.Domain.Entities.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.Ride", b =>
                {
                    b.HasOne("RideShare.Domain.Entities.Car", "Car")
                        .WithMany("Rides")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RideShare.Domain.Entities.User", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RideShare.Domain.Entities.City", "EndCity")
                        .WithMany("EndRides")
                        .HasForeignKey("EndCityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RideShare.Domain.Entities.City", "StartCity")
                        .WithMany("StartRides")
                        .HasForeignKey("StartCityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Driver");

                    b.Navigation("EndCity");

                    b.Navigation("StartCity");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.RideRequest", b =>
                {
                    b.HasOne("RideShare.Domain.Entities.User", "FromUser")
                        .WithMany("SentRideRequests")
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RideShare.Domain.Entities.Ride", "Ride")
                        .WithMany("RideRequests")
                        .HasForeignKey("RideId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RideShare.Domain.Entities.User", "ToUser")
                        .WithMany("ReceivedRideRequests")
                        .HasForeignKey("ToUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FromUser");

                    b.Navigation("Ride");

                    b.Navigation("ToUser");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.RoleUseCase", b =>
                {
                    b.HasOne("RideShare.Domain.Entities.Role", "Role")
                        .WithMany("RoleUseCases")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.User", b =>
                {
                    b.HasOne("RideShare.Domain.Entities.Gender", "Gender")
                        .WithMany("Users")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RideShare.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Gender");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.Brand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.Car", b =>
                {
                    b.Navigation("CarRestrictions");

                    b.Navigation("Rides");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.City", b =>
                {
                    b.Navigation("EndRides");

                    b.Navigation("StartRides");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.Color", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.Gender", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.Model", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.Ride", b =>
                {
                    b.Navigation("RideRequests");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.Role", b =>
                {
                    b.Navigation("RoleUseCases");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.Type", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("RideShare.Domain.Entities.User", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("ReceivedRideRequests");

                    b.Navigation("SentRideRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
