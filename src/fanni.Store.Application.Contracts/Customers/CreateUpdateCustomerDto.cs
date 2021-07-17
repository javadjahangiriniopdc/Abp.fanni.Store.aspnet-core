using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace fanni.Store.Customers
{
    public class CreateUpdateCustomerDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        public string Family { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }=DateTime.Now;
    }
}
