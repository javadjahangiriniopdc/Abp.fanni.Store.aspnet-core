using fanni.Store.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace fanni.Store
{
    [DependsOn(
        typeof(StoreEntityFrameworkCoreTestModule)
        )]
    public class StoreDomainTestModule : AbpModule
    {

    }
}