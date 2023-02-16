using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class Order
    {
        [Key]
        public int Id { get; set; }

        public string ShippingDetails { get; set; }

        public int TotalPrice { get; set; }
    }
}
