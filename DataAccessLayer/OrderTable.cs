using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OrderTable : Audit
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int TotalPrice { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
