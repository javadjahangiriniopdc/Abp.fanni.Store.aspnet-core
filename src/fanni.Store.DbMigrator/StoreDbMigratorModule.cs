using fanni.Store.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace fanni.Store.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(StoreEntityFrameworkCoreDbMigrationsModule),
        typeof(StoreApplicationContractsModule)
        )]
    public class StoreDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
