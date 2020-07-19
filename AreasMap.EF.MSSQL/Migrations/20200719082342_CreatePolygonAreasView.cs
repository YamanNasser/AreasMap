using Microsoft.EntityFrameworkCore.Migrations;

namespace AreasMap.EF.MSSQL.Migrations
{
    public partial class CreatePolygonAreasView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW  [vwPolygonAreas] AS
                        SELECT         PolygonCoordinate.CoordinatesAsJson,  Area.ShapeId,  Area.Name,  Shape.TypeId,  Area.Id,  Polygon.CoordinateId AS DataId
                        FROM             PolygonCoordinate INNER JOIN
                          Polygon INNER JOIN
                          Shape ON  Polygon.Id =  Shape.Id INNER JOIN
                          Area ON  Shape.AreaId =  Area.Id ON  PolygonCoordinate.PolygonId =  Polygon.Id   WHERE        (Area.Deleted = 0) OR
                         (Area.Deleted IS NULL) ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop VIEW  [vwPolygonAreas]");
        }
    }
}