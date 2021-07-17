using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace fanni.Store
{
    [Dependency(ReplaceServices = true)]
    public class StoreBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Store";
    }
}
