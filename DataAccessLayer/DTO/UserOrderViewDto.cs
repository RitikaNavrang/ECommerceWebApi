using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTO;

public class UserOrderViewDto
{
    public int UserId { get; set; }
    public string UserName { get; set; }

    public int TotalPrice { get; set; }


    public ICollection<UserProductOrderViewDto> Userpro { get; set; }

}
