using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Project.Migrations
{
    public partial class NewPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PageItem",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Functionsid = table.Column<int>(type: "int", nullable: true),
                    pr = table.Column<int>(type: "int", nullable: false),
                    WebPage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_PageItem_Functions_Functionsid",
                        column: x => x.Functionsid,
                        principalTable: "Functions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PageItem_Functionsid",
                table: "PageItem",
                column: "Functionsid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PageItem");
        }
    }
}
