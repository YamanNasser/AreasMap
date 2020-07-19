using AreasMap.Domain.Entities;
using AreasMap.Repository.Core.Interfaces;
using AreasMap.Repository.Core.Models;
using AreasMap.Repository.EntityFramework.Common;
using AreasMap.Repository.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;
using System.Threading.Tasks;
using Z.EntityFramework.Extensions;

namespace AreasMap.Repository.EntityFramework.AreasRepository
{
    public class AreaRepository : Repository<Area>, IAreaRepository
    {
        public AreaRepository(AreasMapCoreDbContext context)
            : base(context)
        {
            EntityFrameworkManager.ContextFactory = context =>
            {
                return Context;
            };
        }

        public async Task<List<MainAreaDto>> GetAllAreasAsync()
        {
            var areasList = new List<MainAreaDto>();

            using (var connection = new SqlConnection(Context.Database.GetConnectionString()))
            using (connection)
            {
                //for pagination case , you can use [spGetAreasByPage]. Ex: get 10 page: spGetAreasByPage 1,10

                SqlCommand command = new SqlCommand("spGetAllAreas", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        var type = int.Parse(reader["TypeId"].ToString());
                        var area = new MainAreaDto()
                        {
                            Name = reader["Name"].ToString(),
                            Id = Guid.Parse(reader["Id"].ToString())
                        };

                        area.Shape = new ShapeDto()
                        {
                            Type = type,
                            Id = Guid.Parse(reader["ShapeId"].ToString())
                        };

                        switch (type)
                        {
                            case ShapeType.Circle:
                                {
                                    AddCircle(reader, area);
                                }
                                break;

                            case ShapeType.Rectangle:
                                {
                                    AddRectangle(reader, area);
                                }
                                break;

                            case ShapeType.Polygon:
                                {
                                    AddPloygon(reader, area);
                                }
                                break;
                        }

                        areasList.Add(area);
                    }
                }

                reader.Close();
            }

            return areasList;
        }

        private static void AddPloygon(SqlDataReader reader, MainAreaDto area)
        {
            area.Shape.Data = new PolygonDto()
            {
                CoordinateId = Guid.Parse(reader["DataId"].ToString()),
                Coordinate = JsonSerializer
                .Deserialize<List<PolygonCoordinateDto>>(reader["CoordinatesAsJson"].ToString())
            };
        }

        private static void AddRectangle(SqlDataReader reader, MainAreaDto area)
        {
            area.Shape.Data = new RectangleDto()
            {
                BoundsId = Guid.Parse(reader["DataId"].ToString()),
                Bounds = new RectangleBoundsDto()
                {
                    East = double.Parse(reader["East"].ToString()),
                    North = double.Parse(reader["North"].ToString()),
                    South = double.Parse(reader["South"].ToString()),
                    West = double.Parse(reader["West"].ToString()),
                }
            };
        }

        private static void AddCircle(SqlDataReader reader, MainAreaDto area)
        {
            area.Shape.Data = new CircleDto()
            {
                CoordinateId = Guid.Parse(reader["DataId"].ToString()),
                Coordinate = new CoordinateDto()
                {
                    Latitude = double.Parse(reader["Latitude"].ToString()),
                    Longitude = double.Parse(reader["Longitude"].ToString())
                },
                Radius = double.Parse(reader["Radius"].ToString())
            };
        }

        /// <summary>
        /// https://entityframework-extensions.net/bulk-merge
        /// </summary>
        /// <param name="bulk"></param>
        /// <returns></returns>
        public async Task<bool> BulkMergeAsync(AreaMapBulk bulk)
        {
            var transaction = Context.Database.BeginTransaction();
            try
            {
                await Context.BulkMergeAsync(bulk.Area);
                await Context.BulkMergeAsync(bulk.Shape);
                await Context.BulkMergeAsync(bulk.Polygon,
                   operation => operation.IncludeGraph = true);
                await Context.BulkMergeAsync(bulk.Circle,
                   operation => operation.IncludeGraph = true);
                await Context.BulkMergeAsync(bulk.Rectangle,
                   operation => operation.IncludeGraph = true);

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw ex;
            }

            return true;//done
        }
    }
}