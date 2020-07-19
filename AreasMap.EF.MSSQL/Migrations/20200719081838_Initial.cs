using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AreasMap.EF.MSSQL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShapeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Circle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Radius = table.Column<double>(type: "float", nullable: false),
                    CoordinateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Polygon",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoordinateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polygon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RectangleBounds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    North = table.Column<double>(type: "float", nullable: false),
                    South = table.Column<double>(type: "float", nullable: false),
                    East = table.Column<double>(type: "float", nullable: false),
                    West = table.Column<double>(type: "float", nullable: false),
                    RectangleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RectangleBounds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShapeType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShapeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CircleCoordinate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    CircleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CircleCoordinate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CircleCoordinate_Circle_CircleId",
                        column: x => x.CircleId,
                        principalTable: "Circle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolygonCoordinate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoordinatesAsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolygonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolygonCoordinate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolygonCoordinate_Polygon_PolygonId",
                        column: x => x.PolygonId,
                        principalTable: "Polygon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rectangle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoundsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rectangle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rectangle_RectangleBounds_BoundsId",
                        column: x => x.BoundsId,
                        principalTable: "RectangleBounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shape",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAsJson = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shape", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shape_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shape_ShapeType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ShapeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CircleCoordinate_CircleId",
                table: "CircleCoordinate",
                column: "CircleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PolygonCoordinate_PolygonId",
                table: "PolygonCoordinate",
                column: "PolygonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rectangle_BoundsId",
                table: "Rectangle",
                column: "BoundsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shape_AreaId",
                table: "Shape",
                column: "AreaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shape_TypeId",
                table: "Shape",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CircleCoordinate");

            migrationBuilder.DropTable(
                name: "PolygonCoordinate");

            migrationBuilder.DropTable(
                name: "Rectangle");

            migrationBuilder.DropTable(
                name: "Shape");

            migrationBuilder.DropTable(
                name: "Circle");

            migrationBuilder.DropTable(
                name: "Polygon");

            migrationBuilder.DropTable(
                name: "RectangleBounds");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "ShapeType");
        }
    }
}