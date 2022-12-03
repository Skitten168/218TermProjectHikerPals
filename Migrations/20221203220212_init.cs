using Microsoft.EntityFrameworkCore.Migrations;

namespace HikerPals.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pack",
                columns: table => new
                {
                    PackId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackName = table.Column<string>(nullable: true),
                    PackVolume = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pack", x => x.PackId);
                });

            migrationBuilder.CreateTable(
                name: "Trails",
                columns: table => new
                {
                    TrailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TName = table.Column<string>(maxLength: 50, nullable: false),
                    Distance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trails", x => x.TrailId);
                });

            migrationBuilder.CreateTable(
                name: "Hikers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrailName = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    AverageDailyMiles = table.Column<int>(nullable: false),
                    YearsExperience = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    TrailId = table.Column<int>(nullable: false),
                    PackId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hikers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hikers_pack_PackId",
                        column: x => x.PackId,
                        principalTable: "pack",
                        principalColumn: "PackId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hikers_Trails_TrailId",
                        column: x => x.TrailId,
                        principalTable: "Trails",
                        principalColumn: "TrailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "TrailId", "Distance", "TName" },
                values: new object[,]
                {
                    { 1, 2190.0, "Appalacian Trail" },
                    { 2, 2650.0, "Pacific Crest Trail" },
                    { 3, 789.0, "Arizona Trail" },
                    { 4, 3100.0, "Continental Divide Trail" }
                });

            migrationBuilder.InsertData(
                table: "pack",
                columns: new[] { "PackId", "PackName", "PackVolume" },
                values: new object[,]
                {
                    { 1, "Osprey Atmos", 65 },
                    { 2, "Gregory Paragon", 58 },
                    { 3, "REI Traverse", 65 }
                });

            migrationBuilder.InsertData(
                table: "Hikers",
                columns: new[] { "Id", "Age", "AverageDailyMiles", "PackId", "TrailId", "TrailName", "YearsExperience", "email" },
                values: new object[,]
                {
                    { 1, 45, 15, 1, 1, "Low Branch", 15, "littleJimmy@aol.com" },
                    { 2, 65, 7, 1, 2, "Ten Steps", 30, "ten@aol.com" },
                    { 3, 33, 4, 2, 3, "Coach", 2, "coach@aol.com" },
                    { 4, 35, 4, 3, 4, "The Captain", 2, "Cap@aol.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hikers_PackId",
                table: "Hikers",
                column: "PackId");

            migrationBuilder.CreateIndex(
                name: "IX_Hikers_TrailId",
                table: "Hikers",
                column: "TrailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hikers");

            migrationBuilder.DropTable(
                name: "pack");

            migrationBuilder.DropTable(
                name: "Trails");
        }
    }
}
