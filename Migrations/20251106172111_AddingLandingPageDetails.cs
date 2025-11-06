using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Portfolio.Migrations
{
    /// <inheritdoc />
    public partial class AddingLandingPageDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_secondarySkills",
                table: "secondarySkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_refreshTokens",
                table: "refreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_profileDetails",
                table: "profileDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_primarySkills",
                table: "primarySkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_experiances",
                table: "experiances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contactMes",
                table: "contactMes");

            migrationBuilder.RenameTable(
                name: "secondarySkills",
                newName: "SecondarySkills");

            migrationBuilder.RenameTable(
                name: "refreshTokens",
                newName: "RefreshTokens");

            migrationBuilder.RenameTable(
                name: "profileDetails",
                newName: "ProfileDetails");

            migrationBuilder.RenameTable(
                name: "primarySkills",
                newName: "PrimarySkills");

            migrationBuilder.RenameTable(
                name: "experiances",
                newName: "Experiances");

            migrationBuilder.RenameTable(
                name: "contactMes",
                newName: "ContactMes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SecondarySkills",
                table: "SecondarySkills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileDetails",
                table: "ProfileDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrimarySkills",
                table: "PrimarySkills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Experiances",
                table: "Experiances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactMes",
                table: "ContactMes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "LandingPageDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HelloMessage = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PassionMessage = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    ShortDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandingPageDetails", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LandingPageDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SecondarySkills",
                table: "SecondarySkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileDetails",
                table: "ProfileDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrimarySkills",
                table: "PrimarySkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Experiances",
                table: "Experiances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactMes",
                table: "ContactMes");

            migrationBuilder.RenameTable(
                name: "SecondarySkills",
                newName: "secondarySkills");

            migrationBuilder.RenameTable(
                name: "RefreshTokens",
                newName: "refreshTokens");

            migrationBuilder.RenameTable(
                name: "ProfileDetails",
                newName: "profileDetails");

            migrationBuilder.RenameTable(
                name: "PrimarySkills",
                newName: "primarySkills");

            migrationBuilder.RenameTable(
                name: "Experiances",
                newName: "experiances");

            migrationBuilder.RenameTable(
                name: "ContactMes",
                newName: "contactMes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_secondarySkills",
                table: "secondarySkills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_refreshTokens",
                table: "refreshTokens",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_profileDetails",
                table: "profileDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_primarySkills",
                table: "primarySkills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_experiances",
                table: "experiances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contactMes",
                table: "contactMes",
                column: "Id");
        }
    }
}
