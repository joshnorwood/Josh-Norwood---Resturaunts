using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturants.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNotesEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NotesID",
                table: "Meals",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NotesID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NotesID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meals_NotesID",
                table: "Meals",
                column: "NotesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Notes_NotesID",
                table: "Meals",
                column: "NotesID",
                principalTable: "Notes",
                principalColumn: "NotesID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Notes_NotesID",
                table: "Meals");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Meals_NotesID",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "NotesID",
                table: "Meals");
        }
    }
}
