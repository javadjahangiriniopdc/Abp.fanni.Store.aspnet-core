using fanni.Store.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace fanni.Store.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class StoreController : AbpController
    {
        protected StoreController()
        {
            LocalizationResource = typeof(StoreResource);
        }
    }
}