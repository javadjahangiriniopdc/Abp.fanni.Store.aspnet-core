using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace fanni.Store.Orders
{
  public  class Order : AuditedAggregateRoot<int>
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public int Pirce { get; set; }
        public int PriceAll { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
