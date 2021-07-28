using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace fanni.Store.Orders
{
  public  class ProductLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}