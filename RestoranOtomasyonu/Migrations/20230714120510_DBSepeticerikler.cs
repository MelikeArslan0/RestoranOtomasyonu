using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestoranOtomasyonu.Migrations
{
    /// <inheritdoc />
    public partial class DBSepeticerikler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sepeticerikler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SepetID = table.Column<int>(type: "int", nullable: false),
                    IcerikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sepeticerikler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sepeticerikler_icerik_IcerikID",
                        column: x => x.IcerikID,
                        principalTable: "icerik",
                        principalColumn: "IcerikID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sepeticerikler_sepet_SepetID",
                        column: x => x.SepetID,
                        principalTable: "sepet",
                        principalColumn: "SepetID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_sepeticerikler_IcerikID",
                table: "sepeticerikler",
                column: "IcerikID");

            migrationBuilder.CreateIndex(
                name: "IX_sepeticerikler_SepetID",
                table: "sepeticerikler",
                column: "SepetID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sepeticerikler");
        }
    }
}
