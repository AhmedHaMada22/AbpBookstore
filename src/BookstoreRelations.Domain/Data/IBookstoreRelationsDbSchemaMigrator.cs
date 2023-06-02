using System.Threading.Tasks;

namespace BookstoreRelations.Data;

public interface IBookstoreRelationsDbSchemaMigrator
{
    Task MigrateAsync();
}
