using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace fanni.Store.Products
{
    public class CreateUpdateProductDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        public int Pirce { get; set; }

        [Required] 
        public ProductType ProductType { get; set; } = ProductType.Undefined;
    }
}
