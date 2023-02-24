using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTO;

public class OrderView
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }


    public int Price { get; set; }

    public int OrderId { get; set; }

    public int ShippingId { get; set; }

}    
