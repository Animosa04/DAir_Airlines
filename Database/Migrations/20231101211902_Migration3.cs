using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PilotRatings_Employees_RatedEmployeeNumber",
                table: "PilotRatings");

            migrationBuilder.RenameColumn(
                name: "RatedEmployeeNumber",
                table: "PilotRatings",
                newName: "RatedCabinCrewMemberNumber");

            migrationBuilder.RenameIndex(
                name: "IX_PilotRatings_RatedEmployeeNumber",
                table: "PilotRatings",
                newName: "IX_PilotRatings_RatedCabinCrewMemberNumber");

            migrationBuilder.CreateTable(
                name: "PilotConflicts",
                columns: table => new
                {
                    ConflictID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PilotLicenseNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConflicsWithPilot = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PilotConflicts", x => x.ConflictID);
                    table.ForeignKey(
                        name: "FK_PilotConflicts_Pilots_ConflicsWithPilot",
                        column: x => x.ConflicsWithPilot,
                        principalTable: "Pilots",
                        principalColumn: "PilotLicenseNumber");
                    table.ForeignKey(
                        name: "FK_PilotConflicts_Pilots_PilotLicenseNumber",
                        column: x => x.PilotLicenseNumber,
                        principalTable: "Pilots",
                        principalColumn: "PilotLicenseNumber");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PilotConflicts_ConflicsWithPilot",
                table: "PilotConflicts",
                column: "ConflicsWithPilot");

            migrationBuilder.CreateIndex(
                name: "IX_PilotConflicts_PilotLicenseNumber",
                table: "PilotConflicts",
                column: "PilotLicenseNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_PilotRatings_CabinCrewMembers_RatedCabinCrewMemberNumber",
                table: "PilotRatings",
                column: "RatedCabinCrewMemberNumber",
                principalTable: "CabinCrewMembers",
                principalColumn: "CabinCrewMemberNumber",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PilotRatings_CabinCrewMembers_RatedCabinCrewMemberNumber",
                table: "PilotRatings");

            migrationBuilder.DropTable(
                name: "PilotConflicts");

            migrationBuilder.RenameColumn(
                name: "RatedCabinCrewMemberNumber",
                table: "PilotRatings",
                newName: "RatedEmployeeNumber");

            migrationBuilder.RenameIndex(
                name: "IX_PilotRatings_RatedCabinCrewMemberNumber",
                table: "PilotRatings",
                newName: "IX_PilotRatings_RatedEmployeeNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_PilotRatings_Employees_RatedEmployeeNumber",
                table: "PilotRatings",
                column: "RatedEmployeeNumber",
                principalTable: "Employees",
                principalColumn: "EmployeeNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
