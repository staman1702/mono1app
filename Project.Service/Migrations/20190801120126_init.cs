using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Service.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleMakes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
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
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 35, nullable: false),
                    Abrv = table.Column<string>(maxLength: 15, nullable: false),
                    VehicleMakeId = table.Column<Guid>(nullable: false)
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
                values: new object[] { new Guid("2ca5ebe0-9b49-11e9-b475-0800200c9a66"), "VW", "VolksWagen" });

            migrationBuilder.InsertData(
                table: "VehicleMakes",
                columns: new[] { "Id", "Abrv", "Name" },
                values: new object[] { new Guid("0d6ac610-9b49-11e9-b475-0800200c9a66"), "BMW", "Bmw" });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "Abrv", "Name", "VehicleMakeId" },
                values: new object[] { new Guid("b4a12a60-9b4c-4b55-b2e0-fe6f7d133890"), "G3", "Golf 3", new Guid("2ca5ebe0-9b49-11e9-b475-0800200c9a66") });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "Abrv", "Name", "VehicleMakeId" },
                values: new object[] { new Guid("99b4ddbc-1038-40e0-9b42-42b6e9d85148"), "X3", "x3", new Guid("0d6ac610-9b49-11e9-b475-0800200c9a66") });

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
