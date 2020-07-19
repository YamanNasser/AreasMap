using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AreasMap.EF.MSSQL
{
    /*
    * https://codingblast.com/entityframework-core-idesigntimedbcontextfactory/
    * Problem:
    * Your DbContext in a separate project – class library project. You are trying to add new migration and update database.
    *
    * Solution:
    * So you need to implement this interface, and you are not sure how to do it.
    * You can add a class that implements IDesignTimeDbContextFactory inside of your Web project.
    */

    public class MsSqDbContextFactory : IDesignTimeDbContextFactory<MsSqDbContext>
    {
        public MsSqDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile("appsettings.local.json", true)
                .Build();

            var builder = new DbContextOptionsBuilder<MsSqDbContext>();
            builder.UseSqlServer(
                config.GetConnectionString("MsSqDbContext"));
            return new MsSqDbContext(builder.Options);
        }
    }
}