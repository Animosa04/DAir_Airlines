using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AircraftModels",
                columns: table => new
                {
                    Model = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassengerCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftModels", x => x.Model);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeNumber);
                });

            migrationBuilder.CreateTable(
                name: "FlightStates",
                columns: table => new
                {
                    StateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightStates", x => x.StateID);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageID);
                });

            migrationBuilder.CreateTable(
                name: "Aircrafts",
                columns: table => new
                {
                    RegistrationNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AircraftModel = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YearOfManufacture = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircrafts", x => x.RegistrationNumber);
                    table.ForeignKey(
                        name: "FK_Aircrafts_AircraftModels_AircraftModel",
                        column: x => x.AircraftModel,
                        principalTable: "AircraftModels",
                        principalColumn: "Model",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CabinCrewMembers",
                columns: table => new
                {
                    CabinCrewMemberNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CrewMemberEmployeeNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinCrewMembers", x => x.CabinCrewMemberNumber);
                    table.ForeignKey(
                        name: "FK_CabinCrewMembers_Employees_CrewMemberEmployeeNumber",
                        column: x => x.CrewMemberEmployeeNumber,
                        principalTable: "Employees",
                        principalColumn: "EmployeeNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyTrips",
                columns: table => new
                {
                    TripID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BaseAirport = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyTrips", x => x.TripID);
                    table.ForeignKey(
                        name: "FK_DailyTrips_Employees_EmployeeNumber",
                        column: x => x.EmployeeNumber,
                        principalTable: "Employees",
                        principalColumn: "EmployeeNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pilots",
                columns: table => new
                {
                    PilotLicenseNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PilotEmployeeNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilots", x => x.PilotLicenseNumber);
                    table.ForeignKey(
                        name: "FK_Pilots_Employees_PilotEmployeeNumber",
                        column: x => x.PilotEmployeeNumber,
                        principalTable: "Employees",
                        principalColumn: "EmployeeNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CabinCrewLanguages",
                columns: table => new
                {
                    CabinCrewMemberNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LanguageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinCrewLanguages", x => new { x.CabinCrewMemberNumber, x.LanguageID });
                    table.ForeignKey(
                        name: "FK_CabinCrewLanguages_CabinCrewMembers_CabinCrewMemberNumber",
                        column: x => x.CabinCrewMemberNumber,
                        principalTable: "CabinCrewMembers",
                        principalColumn: "CabinCrewMemberNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CabinCrewLanguages_Languages_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Languages",
                        principalColumn: "LanguageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartureAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledDepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduledArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AircraftRegistrationNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CaptainLicenseNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstOfficerLicenseNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrentStateID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightCode);
                    table.ForeignKey(
                        name: "FK_Flights_Aircrafts_AircraftRegistrationNumber",
                        column: x => x.AircraftRegistrationNumber,
                        principalTable: "Aircrafts",
                        principalColumn: "RegistrationNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_FlightStates_CurrentStateID",
                        column: x => x.CurrentStateID,
                        principalTable: "FlightStates",
                        principalColumn: "StateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Pilots_CaptainLicenseNumber",
                        column: x => x.CaptainLicenseNumber,
                        principalTable: "Pilots",
                        principalColumn: "PilotLicenseNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Pilots_FirstOfficerLicenseNumber",
                        column: x => x.FirstOfficerLicenseNumber,
                        principalTable: "Pilots",
                        principalColumn: "PilotLicenseNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PilotCertifications",
                columns: table => new
                {
                    PilotLicenseNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AircraftModel = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PilotCertifications", x => new { x.PilotLicenseNumber, x.AircraftModel });
                    table.ForeignKey(
                        name: "FK_PilotCertifications_AircraftModels_AircraftModel",
                        column: x => x.AircraftModel,
                        principalTable: "AircraftModels",
                        principalColumn: "Model",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PilotCertifications_Pilots_PilotLicenseNumber",
                        column: x => x.PilotLicenseNumber,
                        principalTable: "Pilots",
                        principalColumn: "PilotLicenseNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PilotRatings",
                columns: table => new
                {
                    RatingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingPilotLicenseNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RatedEmployeeNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PilotRatings", x => x.RatingID);
                    table.ForeignKey(
                        name: "FK_PilotRatings_Employees_RatedEmployeeNumber",
                        column: x => x.RatedEmployeeNumber,
                        principalTable: "Employees",
                        principalColumn: "EmployeeNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PilotRatings_Pilots_RatingPilotLicenseNumber",
                        column: x => x.RatingPilotLicenseNumber,
                        principalTable: "Pilots",
                        principalColumn: "PilotLicenseNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAssignments",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripID = table.Column<int>(type: "int", nullable: false),
                    FlightCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAssignments", x => x.AssignmentID);
                    table.ForeignKey(
                        name: "FK_EmployeeAssignments_DailyTrips_TripID",
                        column: x => x.TripID,
                        principalTable: "DailyTrips",
                        principalColumn: "TripID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeAssignments_Flights_FlightCode",
                        column: x => x.FlightCode,
                        principalTable: "Flights",
                        principalColumn: "FlightCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aircrafts_AircraftModel",
                table: "Aircrafts",
                column: "AircraftModel");

            migrationBuilder.CreateIndex(
                name: "IX_CabinCrewLanguages_LanguageID",
                table: "CabinCrewLanguages",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_CabinCrewMembers_CrewMemberEmployeeNumber",
                table: "CabinCrewMembers",
                column: "CrewMemberEmployeeNumber");

            migrationBuilder.CreateIndex(
                name: "IX_DailyTrips_EmployeeNumber",
                table: "DailyTrips",
                column: "EmployeeNumber");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAssignments_FlightCode",
                table: "EmployeeAssignments",
                column: "FlightCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAssignments_TripID",
                table: "EmployeeAssignments",
                column: "TripID");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AircraftRegistrationNumber",
                table: "Flights",
                column: "AircraftRegistrationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_CaptainLicenseNumber",
                table: "Flights",
                column: "CaptainLicenseNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_CurrentStateID",
                table: "Flights",
                column: "CurrentStateID");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_FirstOfficerLicenseNumber",
                table: "Flights",
                column: "FirstOfficerLicenseNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PilotCertifications_AircraftModel",
                table: "PilotCertifications",
                column: "AircraftModel");

            migrationBuilder.CreateIndex(
                name: "IX_PilotRatings_RatedEmployeeNumber",
                table: "PilotRatings",
                column: "RatedEmployeeNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PilotRatings_RatingPilotLicenseNumber",
                table: "PilotRatings",
                column: "RatingPilotLicenseNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Pilots_PilotEmployeeNumber",
                table: "Pilots",
                column: "PilotEmployeeNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CabinCrewLanguages");

            migrationBuilder.DropTable(
                name: "EmployeeAssignments");

            migrationBuilder.DropTable(
                name: "PilotCertifications");

            migrationBuilder.DropTable(
                name: "PilotRatings");

            migrationBuilder.DropTable(
                name: "CabinCrewMembers");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "DailyTrips");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Aircrafts");

            migrationBuilder.DropTable(
                name: "FlightStates");

            migrationBuilder.DropTable(
                name: "Pilots");

            migrationBuilder.DropTable(
                name: "AircraftModels");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
