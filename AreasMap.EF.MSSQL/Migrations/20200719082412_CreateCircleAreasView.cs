using Microsoft.EntityFrameworkCore.Migrations;

namespace AreasMap.EF.MSSQL.Migrations
{
    public partial class CreateCircleAreasView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" CREATE VIEW  [vwCircleAreas]
                            AS
                            SELECT         Shape.TypeId,  Area.Name,  Circle.Radius,  CircleCoordinate.Longitude,  CircleCoordinate.Latitude,  Area.ShapeId,  Area.Id,  Circle.CoordinateId AS DataId
                            FROM             CircleCoordinate INNER JOIN
                          Circle ON  CircleCoordinate.CircleId =  Circle.Id INNER JOIN
                          Area INNER JOIN
                          Shape ON  Area.Id =  Shape.AreaId ON  Circle.Id =  Shape.Id
                        WHERE        (Area.Deleted = 0) OR
                         (Area.Deleted IS NULL)
                        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop VIEW  [vwCircleAreas]");
        }
    }
}