using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace fanni.Store.Orders
{
    public class CreateUpdateOrderDto
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        [Required]
        [StringLength(128)]
        public string Description { get; set; }

        [Required] 
        public int Count { get; set; } = 1;


        [Required] 
        public int Pirce { get; set; } = 0;


        [Required] 
        public int PriceAll { get; set; } = 0;

        [Required]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }=DateTime.Now;
    }
}
