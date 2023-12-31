﻿// <auto-generated />
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(DAirDatabaseContext))]
    [Migration("20231101200125_Migration1")]
    partial class Migration1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Database.DTOs.AircraftDto", b =>
                {
                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AircraftModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("YearOfManufacture")
                        .HasColumnType("int");

                    b.HasKey("RegistrationNumber");

                    b.HasIndex("AircraftModel");

                    b.ToTable("Aircrafts");
                });

            modelBuilder.Entity("Database.DTOs.AircraftModelDto", b =>
                {
                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassengerCapacity")
                        .HasColumnType("int");

                    b.HasKey("Model");

                    b.ToTable("AircraftModels");
                });

            modelBuilder.Entity("Database.DTOs.CabinCrewLanguagesDto", b =>
                {
                    b.Property<string>("CabinCrewMemberNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("LanguageID")
                        .HasColumnType("int");

                    b.HasKey("CabinCrewMemberNumber", "LanguageID");

                    b.HasIndex("LanguageID");

                    b.ToTable("CabinCrewLanguages");
                });

            modelBuilder.Entity("Database.DTOs.CabinCrewMemberDto", b =>
                {
                    b.Property<string>("CabinCrewMemberNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CrewMemberEmployeeNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CabinCrewMemberNumber");

                    b.HasIndex("CrewMemberEmployeeNumber");

                    b.ToTable("CabinCrewMembers");
                });

            modelBuilder.Entity("Database.DTOs.DailyTripDto", b =>
                {
                    b.Property<int>("TripID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TripID"));

                    b.Property<string>("BaseAirport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TripID");

                    b.HasIndex("EmployeeNumber");

                    b.ToTable("DailyTrips");
                });

            modelBuilder.Entity("Database.DTOs.EmployeeAssignmentDto", b =>
                {
                    b.Property<int>("AssignmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentID"));

                    b.Property<string>("FlightCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TripID")
                        .HasColumnType("int");

                    b.HasKey("AssignmentID");

                    b.HasIndex("FlightCode");

                    b.HasIndex("TripID");

                    b.ToTable("EmployeeAssignments");
                });

            modelBuilder.Entity("Database.DTOs.EmployeeDto", b =>
                {
                    b.Property<string>("EmployeeNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeNumber");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Database.DTOs.FlightDto", b =>
                {
                    b.Property<string>("FlightCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AircraftRegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CaptainLicenseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CurrentStateID")
                        .HasColumnType("int");

                    b.Property<string>("DepartureAirport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationAirport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstOfficerLicenseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ScheduledArrivalTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScheduledDepartureTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlightCode");

                    b.HasIndex("AircraftRegistrationNumber");

                    b.HasIndex("CaptainLicenseNumber");

                    b.HasIndex("CurrentStateID");

                    b.HasIndex("FirstOfficerLicenseNumber");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Database.DTOs.FlightStateDto", b =>
                {
                    b.Property<int>("StateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StateID"));

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StateID");

                    b.ToTable("FlightStates");
                });

            modelBuilder.Entity("Database.DTOs.LanguageDto", b =>
                {
                    b.Property<int>("LanguageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LanguageID"));

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageID");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Database.DTOs.PilotCertificationsDto", b =>
                {
                    b.Property<string>("PilotLicenseNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AircraftModel")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PilotLicenseNumber", "AircraftModel");

                    b.HasIndex("AircraftModel");

                    b.ToTable("PilotCertifications");
                });

            modelBuilder.Entity("Database.DTOs.PilotDto", b =>
                {
                    b.Property<string>("PilotLicenseNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PilotEmployeeNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PilotLicenseNumber");

                    b.HasIndex("PilotEmployeeNumber");

                    b.ToTable("Pilots");
                });

            modelBuilder.Entity("Database.DTOs.PilotRatingsDto", b =>
                {
                    b.Property<int>("RatingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RatingID"));

                    b.Property<string>("RatedEmployeeNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("RatingPilotLicenseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RatingID");

                    b.HasIndex("RatedEmployeeNumber");

                    b.HasIndex("RatingPilotLicenseNumber");

                    b.ToTable("PilotRatings");
                });

            modelBuilder.Entity("Database.DTOs.AircraftDto", b =>
                {
                    b.HasOne("Database.DTOs.AircraftModelDto", null)
                        .WithMany()
                        .HasForeignKey("AircraftModel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.DTOs.CabinCrewLanguagesDto", b =>
                {
                    b.HasOne("Database.DTOs.CabinCrewMemberDto", null)
                        .WithMany()
                        .HasForeignKey("CabinCrewMemberNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.DTOs.LanguageDto", null)
                        .WithMany()
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.DTOs.CabinCrewMemberDto", b =>
                {
                    b.HasOne("Database.DTOs.EmployeeDto", null)
                        .WithMany()
                        .HasForeignKey("CrewMemberEmployeeNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.DTOs.DailyTripDto", b =>
                {
                    b.HasOne("Database.DTOs.EmployeeDto", null)
                        .WithMany()
                        .HasForeignKey("EmployeeNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.DTOs.EmployeeAssignmentDto", b =>
                {
                    b.HasOne("Database.DTOs.FlightDto", null)
                        .WithMany()
                        .HasForeignKey("FlightCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.DTOs.DailyTripDto", null)
                        .WithMany()
                        .HasForeignKey("TripID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.DTOs.FlightDto", b =>
                {
                    b.HasOne("Database.DTOs.AircraftDto", null)
                        .WithMany()
                        .HasForeignKey("AircraftRegistrationNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.DTOs.PilotDto", null)
                        .WithMany()
                        .HasForeignKey("CaptainLicenseNumber")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Database.DTOs.FlightStateDto", null)
                        .WithMany()
                        .HasForeignKey("CurrentStateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.DTOs.PilotDto", null)
                        .WithMany()
                        .HasForeignKey("FirstOfficerLicenseNumber")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.DTOs.PilotCertificationsDto", b =>
                {
                    b.HasOne("Database.DTOs.AircraftModelDto", null)
                        .WithMany()
                        .HasForeignKey("AircraftModel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.DTOs.PilotDto", null)
                        .WithMany()
                        .HasForeignKey("PilotLicenseNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.DTOs.PilotDto", b =>
                {
                    b.HasOne("Database.DTOs.EmployeeDto", null)
                        .WithMany()
                        .HasForeignKey("PilotEmployeeNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.DTOs.PilotRatingsDto", b =>
                {
                    b.HasOne("Database.DTOs.EmployeeDto", null)
                        .WithMany()
                        .HasForeignKey("RatedEmployeeNumber")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Database.DTOs.PilotDto", null)
                        .WithMany()
                        .HasForeignKey("RatingPilotLicenseNumber")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
