using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegisterToDoctor.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangePatientModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OmsNumder",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OmsNumber",
                table: "Patients",
                type: "nchar(16)",
                fixedLength: true,
                maxLength: 16,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OmsNumber",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "OmsNumder",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
