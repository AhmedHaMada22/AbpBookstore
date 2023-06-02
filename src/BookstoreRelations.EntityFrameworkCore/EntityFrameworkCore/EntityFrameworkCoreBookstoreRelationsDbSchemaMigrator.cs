using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookstoreRelations.Data;
using Volo.Abp.DependencyInjection;

namespace BookstoreRelations.EntityFrameworkCore;

public class EntityFrameworkCoreBookstoreRelationsDbSchemaMigrator
    : IBookstoreRelationsDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreBookstoreRelationsDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the BookstoreRelationsDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<BookstoreRelationsDbContext>()
            .Database
            .MigrateAsync();
    }
}
