using Microsoft.EntityFrameworkCore.Migrations;

namespace AreasMap.EF.MSSQL.Migrations
{
    public partial class CreateGetAreasByPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create procedure [spGetAreasByPage] @PageNumber AS INT,@RowsOfPage                       AS INT
                                as begin

                                select * from(
                                SELECT  Id, DataId,[Name],[ShapeId],[TypeId],0 [Radius],0 [Longitude],0 [Latitude], [CoordinatesAsJson],0 [North],0 [South],0 [East],0 [West]
                                FROM [vwPolygonAreas]
                                union
                                SELECT  Id, DataId, [Name],[ShapeId],[TypeId],[Radius], [Longitude], [Latitude], '' [CoordinatesAsJson],0 [North],0 [South],0 [East],0 [West]
                                FROM [vwCircleAreas]
                                union
                                SELECT  Id,DataId, [Name],[ShapeId],[TypeId],0 [Radius],0 [Longitude],0 [Latitude], '' [CoordinatesAsJson], [North], [South],[East],[West]
                                FROM [vwRectangleAreas]
                                ) areas
                                order by id
                                OFFSET (@PageNumber-1)*@RowsOfPage ROWS
                                FETCH NEXT @RowsOfPage ROWS ONLY
                                end
                    ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop procedure spGetAreasByPage");
        }
    }
}