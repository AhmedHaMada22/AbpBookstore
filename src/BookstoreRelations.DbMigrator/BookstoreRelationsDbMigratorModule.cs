using BookstoreRelations.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace BookstoreRelations.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BookstoreRelationsEntityFrameworkCoreModule),
    typeof(BookstoreRelationsApplicationContractsModule)
    )]
public class BookstoreRelationsDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
