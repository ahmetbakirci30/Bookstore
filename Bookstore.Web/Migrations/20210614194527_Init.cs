using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Web.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorName", "Description", "ImagePath", "Publisher", "Title" },
                values: new object[,]
                {
                    { 1, "Bilal ÖZTÜRK", "My Last Book In Programming Languages.", "team-image-2-646x680.jpg", "Time Magazine", "Dart Programming Tutorial For Beginners" },
                    { 2, "Mustafa Kaslı", "My Third Book In Programming Languages.", "about-1-570x350.jpg", "The Cut", "Paython Programming Tutorial For Beginners" },
                    { 3, "Ahmet Demir", "My Second Book In Programming Languages.", "team-image-1-646x680.jpg", "The Next Web", "C# Programming Tutorial For Beginners" },
                    { 4, "Leyla ÖZTÜRK", "My First Book In Programming Languages.", "team-image-3-646x680.jpg", "BBC TV", "Java Programming Tutorial For Beginners" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
