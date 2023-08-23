using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestoranOtomasyonu.Migrations
{
    /// <inheritdoc />
    public partial class DBaaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MasaNumarası",
                table: "masa",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasaNumarası",
                table: "masa");
        }
    }
}
