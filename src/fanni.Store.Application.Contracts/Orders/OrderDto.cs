﻿using System;
using System.Collections.Generic;
using System.Text;

namespace fanni.Store.Orders
{
    public class OrderDto
    {
        public int CustomerId { get; set; }
        public int CustomerName { get; set; }
        public int ProductId { get; set; }
        public int ProductName { get; set; }
        public string Description { get; set; } 
        public int Count { get; set; }
        public int Pirce { get; set; }
        public int PriceAll { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
