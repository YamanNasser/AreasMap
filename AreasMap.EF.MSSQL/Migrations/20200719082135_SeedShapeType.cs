using AreasMap.Domain.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AreasMap.EF.MSSQL.Migrations
{
    public partial class SeedShapeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "ShapeType",
            columns: new[] { "Id", "Name" },
            values: new object[] { ShapeType.Polygon, "Polygon" });

            migrationBuilder.InsertData(
          table: "ShapeType",
          columns: new[] { "Id", "Name" },
          values: new object[] { ShapeType.Circle, "Circle" });

            migrationBuilder.InsertData(
          table: "ShapeType",
          columns: new[] { "Id", "Name" },
          values: new object[] { ShapeType.Rectangle, "Rectangle" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}