using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CabinCrewLanguages",
                table: "CabinCrewLanguages");

            migrationBuilder.AddColumn<int>(
                name: "CabinCrewLanguageID",
                table: "CabinCrewLanguages",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CabinCrewLanguages",
                table: "CabinCrewLanguages",
                column: "CabinCrewLanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_CabinCrewLanguages_CabinCrewMemberNumber",
                table: "CabinCrewLanguages",
                column: "CabinCrewMemberNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CabinCrewLanguages",
                table: "CabinCrewLanguages");

            migrationBuilder.DropIndex(
                name: "IX_CabinCrewLanguages_CabinCrewMemberNumber",
                table: "CabinCrewLanguages");

            migrationBuilder.DropColumn(
                name: "CabinCrewLanguageID",
                table: "CabinCrewLanguages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CabinCrewLanguages",
                table: "CabinCrewLanguages",
                columns: new[] { "CabinCrewMemberNumber", "LanguageID" });
        }
    }
}
