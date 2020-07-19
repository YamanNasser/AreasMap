using Microsoft.EntityFrameworkCore.Migrations;

namespace AreasMap.EF.MSSQL.Migrations
{
    public partial class CreateRectangleAreasView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW [vwRectangleAreas] AS
                    SELECT         Shape.TypeId,  Area.Name,  RectangleBounds.North,  RectangleBounds.South,  RectangleBounds.East,  RectangleBounds.West,  Area.ShapeId,  Area.Id,  Rectangle.BoundsId AS DataId
                    FROM             RectangleBounds INNER JOIN
                          Rectangle ON  RectangleBounds.Id =  Rectangle.BoundsId INNER JOIN
                          Area INNER JOIN
                          Shape ON  Area.Id =  Shape.AreaId ON  Rectangle.Id =  Shape.Id
                         WHERE        (Area.Deleted = 0) OR
                         (Area.Deleted IS NULL)
                        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop VIEW  [vwRectangleAreas]");
        }
    }
}