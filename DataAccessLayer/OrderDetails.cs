using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OrderDetails : Audit
    {


        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(OrderId))]

        public OrderTable OrderTable { get; set; }

        [ForeignKey(nameof(ProductId))]

       public Product? Product { get; set; }
    }
}
