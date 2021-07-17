using System;
using System.Collections.Generic;
using System.Text;
using fanni.Store.Localization;
using Volo.Abp.Application.Services;

namespace fanni.Store
{
    /* Inherit your application services from this class.
     */
    public abstract class StoreAppService : ApplicationService
    {
        protected StoreAppService()
        {
            LocalizationResource = typeof(StoreResource);
        }
    }
}
