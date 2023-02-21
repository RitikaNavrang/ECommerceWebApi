using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.NewFolder;

public class AddOrderDto
{
    [Key]
    public int OrderId { get; set; } = 0;


    public int[] ProductId { get; set; }

    public int ShippingId { get; set; }

}
