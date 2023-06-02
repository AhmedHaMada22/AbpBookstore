using BookstoreRelations.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace BookstoreRelations;

[DependsOn(
    typeof(BookstoreRelationsEntityFrameworkCoreTestModule)
    )]
public class BookstoreRelationsDomainTestModule : AbpModule
{

}
