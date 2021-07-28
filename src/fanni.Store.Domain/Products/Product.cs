using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace fanni.Store.Products
{
   public class Product:AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public int Pirce { get; set; }
        public ProductType ProductType { get; set; }


    }
}
