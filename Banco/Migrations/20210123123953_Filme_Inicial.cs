using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Banco.Migrations
{
    public partial class Filme_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "film",
                columns: table => new
                {
                    film_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(255)", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    release_year = table.Column<string>(type: "varchar(4)", nullable: true),
                    language_id = table.Column<byte>(type: "tinyint", nullable: false),
                    original_language_id = table.Column<byte>(type: "tinyint", nullable: true),
                    length = table.Column<short>(type: "smallint", nullable: true),
                    rating = table.Column<string>(type: "varchar(10)", nullable: true),
                    cover_image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    last_update = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_film", x => x.film_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "film");
        }
    }
}
