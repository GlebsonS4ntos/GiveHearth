using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiveHearth.Migrations
{
    /// <inheritdoc />
    public partial class add_email_to_registration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "registrations",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "registrations");
        }
    }
}
