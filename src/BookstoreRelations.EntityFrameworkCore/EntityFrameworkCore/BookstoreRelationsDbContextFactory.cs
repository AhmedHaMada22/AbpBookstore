using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BookstoreRelations.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class BookstoreRelationsDbContextFactory : IDesignTimeDbContextFactory<BookstoreRelationsDbContext>
{
    public BookstoreRelationsDbContext CreateDbContext(string[] args)
    {
        BookstoreRelationsEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<BookstoreRelationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new BookstoreRelationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../BookstoreRelations.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
