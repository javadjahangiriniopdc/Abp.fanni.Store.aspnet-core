using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace fanni.Store.Products
{
    public class ProductDto:AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public int Pirce { get; set; }
        public ProductType ProductType { get; set; }
    }
}
