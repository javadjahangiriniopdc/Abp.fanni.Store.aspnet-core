using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace fanni.Store.Orders
{
    public class OrderDto:AuditedEntityDto<int>
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; } 
        public int Count { get; set; }
        public int Pirce { get; set; }
        public int PriceAll { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
