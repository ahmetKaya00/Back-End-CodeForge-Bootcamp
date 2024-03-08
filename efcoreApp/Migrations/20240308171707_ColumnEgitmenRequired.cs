using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace efcoreApp.Migrations
{
    /// <inheritdoc />
    public partial class ColumnEgitmenRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bootcamps_Egitmenler_EgitmenId",
                table: "Bootcamps");

            migrationBuilder.AlterColumn<int>(
                name: "EgitmenId",
                table: "Bootcamps",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bootcamps_Egitmenler_EgitmenId",
                table: "Bootcamps",
                column: "EgitmenId",
                principalTable: "Egitmenler",
                principalColumn: "OgretmenId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bootcamps_Egitmenler_EgitmenId",
                table: "Bootcamps");

            migrationBuilder.AlterColumn<int>(
                name: "EgitmenId",
                table: "Bootcamps",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Bootcamps_Egitmenler_EgitmenId",
                table: "Bootcamps",
                column: "EgitmenId",
                principalTable: "Egitmenler",
                principalColumn: "OgretmenId");
        }
    }
}
