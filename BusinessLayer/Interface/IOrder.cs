using DataAccessLayer;
using DataAccessLayer.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface;

public interface IOrder
{
    //public Task order(AddOrderDto obj);
    public Task<OrderTable> orderAsync(AddOrderDto obj, int userid);

}
