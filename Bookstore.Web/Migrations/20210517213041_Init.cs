using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Web.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "AddedDate", "FullName" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 18, 0, 30, 40, 930, DateTimeKind.Local).AddTicks(2964), "Bilal ÖZTÜRK" },
                    { 2, new DateTime(2021, 5, 18, 0, 30, 40, 930, DateTimeKind.Local).AddTicks(3439), "Ali ÖZTÜRK" },
                    { 3, new DateTime(2021, 5, 18, 0, 30, 40, 930, DateTimeKind.Local).AddTicks(3441), "Evliya ÇELEBİ" },
                    { 4, new DateTime(2021, 5, 18, 0, 30, 40, 930, DateTimeKind.Local).AddTicks(3444), "Mustafa BAKIRCI" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AddedDate", "AuthorId", "Description", "ImagePath", "Title" },
                values: new object[,]
                {
                    { 4, new DateTime(2021, 5, 18, 0, 30, 40, 931, DateTimeKind.Local).AddTicks(8830), 1, "My First Book In Programming Languages.", "team-image-3-646x680.jpg", "Java Programming Tutorial For Beginners" },
                    { 3, new DateTime(2021, 5, 18, 0, 30, 40, 931, DateTimeKind.Local).AddTicks(8828), 2, "My Second Book In Programming Languages.", "team-image-1-646x680.jpg", "C# Programming Tutorial For Beginners" },
                    { 2, new DateTime(2021, 5, 18, 0, 30, 40, 931, DateTimeKind.Local).AddTicks(8824), 3, "My Third Book In Programming Languages.", "about-1-570x350.jpg", "Paython Programming Tutorial For Beginners" },
                    { 1, new DateTime(2021, 5, 18, 0, 30, 40, 931, DateTimeKind.Local).AddTicks(7158), 4, "My Last Book In Programming Languages.", "team-image-2-646x680.jpg", "Dart Programming Tutorial For Beginners" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
