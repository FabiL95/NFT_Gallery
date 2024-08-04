using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFT_Gallery.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NFTs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NFTs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebsiteURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarketplaceURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NFTProjects",
                columns: table => new
                {
                    NFTId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NFTProjects", x => new { x.NFTId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_NFTProjects_NFTs_NFTId",
                        column: x => x.NFTId,
                        principalTable: "NFTs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NFTProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "NFTs",
                columns: new[] { "Id", "ImageURL", "Name", "Price" },
                values: new object[] { 1, "SAC1.png", "Stoned Ape #", 2.0 });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "MarketplaceURL", "Name", "WebsiteURL" },
                values: new object[] { 1, "Blablabla", "https://www.tensor.trade/trade/stoned_ape_crew", "Stoned Ape Crew", "https://www.stonedapecrew.com/" });

            migrationBuilder.InsertData(
                table: "NFTProjects",
                columns: new[] { "NFTId", "ProjectId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_NFTProjects_ProjectId",
                table: "NFTProjects",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NFTProjects");

            migrationBuilder.DropTable(
                name: "NFTs");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
