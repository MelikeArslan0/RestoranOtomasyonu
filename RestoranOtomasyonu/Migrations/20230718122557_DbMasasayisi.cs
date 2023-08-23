using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestoranOtomasyonu.Migrations
{
    /// <inheritdoc />
    public partial class DbMasasayisi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<int>(
                name: "masasayisiID",
                table: "masa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "masasayisi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AD = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    AlanID = table.Column<int>(type: "int", nullable: false),
                    AlanNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_masasayisi", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_masa_masasayisiID",
                table: "masa",
                column: "masasayisiID");

            migrationBuilder.AddForeignKey(
                name: "FK_masa_masasayisi_masasayisiID",
                table: "masa",
                column: "masasayisiID",
                principalTable: "masasayisi",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_masa_masasayisi_masasayisiID",
                table: "masa");

            migrationBuilder.DropTable(
                name: "masasayisi");

            migrationBuilder.DropIndex(
                name: "IX_masa_masasayisiID",
                table: "masa");

            migrationBuilder.DropColumn(
                name: "masasayisiID",
                table: "masa");

         
        }
    }
}
