using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Service.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleMakes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Abrv = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMakes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 35, nullable: false),
                    Abrv = table.Column<string>(maxLength: 15, nullable: false),
                    VehicleMakeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleModels_VehicleMakes_VehicleMakeId",
                        column: x => x.VehicleMakeId,
                        principalTable: "VehicleMakes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VehicleMakes",
                columns: new[] { "Id", "Abrv", "Name" },
                values: new object[] { 1, "VW", "VolksWagen" });

            migrationBuilder.InsertData(
                table: "VehicleMakes",
                columns: new[] { "Id", "Abrv", "Name" },
                values: new object[] { 2, "BMW", "Bmw" });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "Abrv", "Name", "VehicleMakeId" },
                values: new object[] { 1, "G3", "Golf 3", 1 });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "Abrv", "Name", "VehicleMakeId" },
                values: new object[] { 2, "X3", "x3", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_VehicleMakeId",
                table: "VehicleModels",
                column: "VehicleMakeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleModels");

            migrationBuilder.DropTable(
                name: "VehicleMakes");
        }
    }
}
