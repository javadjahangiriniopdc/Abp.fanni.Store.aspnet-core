using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace fanni.Store.Customers
{
    public class Customer :AuditedAggregateRoot<int>
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public DateTime Birthday { get; set; }
    }
}
