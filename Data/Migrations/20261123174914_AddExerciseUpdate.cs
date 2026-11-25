using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KryptonApi_EFCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddExerciseUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TrackingType",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Reps",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TrackingType",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Reps");
        }
    }
}
