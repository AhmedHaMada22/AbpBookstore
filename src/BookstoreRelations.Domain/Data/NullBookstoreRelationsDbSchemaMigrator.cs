using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace BookstoreRelations.Data;

/* This is used if database provider does't define
 * IBookstoreRelationsDbSchemaMigrator implementation.
 */
public class NullBookstoreRelationsDbSchemaMigrator : IBookstoreRelationsDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
