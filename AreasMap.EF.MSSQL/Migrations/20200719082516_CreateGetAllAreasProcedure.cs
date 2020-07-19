using Microsoft.EntityFrameworkCore.Migrations;

namespace AreasMap.EF.MSSQL.Migrations
{
    public partial class CreateGetAllAreasProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE procedure [spGetAllAreas]
                    as begin
                    SELECT Id, DataId,[Name],[ShapeId],[TypeId],0 [Radius],0 [Longitude],0 [Latitude], [CoordinatesAsJson],0 [North],0 [South],0 [East],0 [West]
                    FROM [vwPolygonAreas]
                    union
                    SELECT Id, DataId, [Name],[ShapeId],[TypeId],[Radius], [Longitude], [Latitude], '' [CoordinatesAsJson],0 [North],0 [South],0 [East],0 [West]
                    FROM [vwCircleAreas]
                    union
                    SELECT  Id,DataId, [Name],[ShapeId],[TypeId],0 [Radius],0 [Longitude],0 [Latitude], '' [CoordinatesAsJson], [North], [South],[East],[West]
                    FROM [vwRectangleAreas]
                    end
                    ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop procedure spGetAllAreas");
        }
    }
}