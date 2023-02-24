using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTO;

public class UserProductOrderViewDto
{
    public int OrderId { get; set; }

    public string ProductName { get; set; }

    public int Price { get; set; }

    public string ProductDescription { get; set; }


}
