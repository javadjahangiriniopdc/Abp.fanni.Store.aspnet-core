using Volo.Abp.Modularity;

namespace fanni.Store
{
    [DependsOn(
        typeof(StoreApplicationModule),
        typeof(StoreDomainTestModule)
        )]
    public class StoreApplicationTestModule : AbpModule
    {

    }
}