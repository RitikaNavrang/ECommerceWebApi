using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OrderDetails
    {
        public ICollection<Order> Orders { get; set; }
    }
}
