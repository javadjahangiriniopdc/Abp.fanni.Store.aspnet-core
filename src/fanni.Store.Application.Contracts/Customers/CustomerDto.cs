using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace fanni.Store.Customers
{
    public class CustomerDto : AuditedEntityDto<int>
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public DateTime Birthday { get; set; }
    }
}