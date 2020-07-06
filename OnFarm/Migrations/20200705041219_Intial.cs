using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnFarm.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Founded = table.Column<DateTime>(nullable: false),
                    MainGenre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 400, nullable: true),
                    BandId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "Id", "Founded", "MainGenre", "Name" },
                values: new object[,]
                {
                    { new Guid("b5aa38bc-be50-11ea-b3de-0242ac130004"), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heavy Metal", "Metallica" },
                    { new Guid("b5aa3b96-be50-11ea-b3de-0242ac130004"), new DateTime(1985, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "Guns N Roses" },
                    { new Guid("b5aa3ccc-be50-11ea-b3de-0242ac130004"), new DateTime(1965, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Disco", "ABBA" },
                    { new Guid("b5aa3ec0-be50-11ea-b3de-0242ac130004"), new DateTime(1991, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alternative", "Oasis" },
                    { new Guid("b5aa3fb0-be50-11ea-b3de-0242ac130004"), new DateTime(1981, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pop", "A-ha" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "BandId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("8ad268e2-be52-11ea-b3de-0242ac130004"), new Guid("b5aa38bc-be50-11ea-b3de-0242ac130004"), "One of the best heavy metal albums ever", "Master Of Puppets" },
                    { new Guid("cee0e2c4-be53-11ea-b3de-0242ac130004"), new Guid("b5aa3b96-be50-11ea-b3de-0242ac130004"), "Amazing Rock album with raw sound", "Appetite for Destruction" },
                    { new Guid("cee0e576-be53-11ea-b3de-0242ac130004"), new Guid("b5aa3ccc-be50-11ea-b3de-0242ac130004"), "Very groovy album", "Waterloo" },
                    { new Guid("cee0e698-be53-11ea-b3de-0242ac130004"), new Guid("b5aa3ec0-be50-11ea-b3de-0242ac130004"), "Arguably one of the best albums by Oasis", "Be Here Now" },
                    { new Guid("cee0e77e-be53-11ea-b3de-0242ac130004"), new Guid("b5aa3fb0-be50-11ea-b3de-0242ac130004"), "Awesome Debut album by A-Ha", "Hunting Hight and Low " }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_BandId",
                table: "Albums",
                column: "BandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Bands");
        }
    }
}
