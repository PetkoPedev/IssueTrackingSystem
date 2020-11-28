using Microsoft.EntityFrameworkCore.Migrations;

namespace IssueTrackingSystem.Data.Migrations
{
    public partial class AddCategoryTicketConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryTickets",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    TicketId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTickets", x => new { x.CategoryId, x.TicketId });
                    table.ForeignKey(
                        name: "FK_CategoryTickets_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryTickets_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTickets_TicketId",
                table: "CategoryTickets",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryTickets");
        }
    }
}
