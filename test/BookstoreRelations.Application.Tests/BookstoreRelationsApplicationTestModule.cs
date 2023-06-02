using Volo.Abp.Modularity;

namespace BookstoreRelations;

[DependsOn(
    typeof(BookstoreRelationsApplicationModule),
    typeof(BookstoreRelationsDomainTestModule)
    )]
public class BookstoreRelationsApplicationTestModule : AbpModule
{

}
