using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace fanni.Store.Orders
{
  public  class CustomerLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}