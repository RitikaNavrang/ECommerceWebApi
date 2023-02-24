using DataAccessLayer;
using DataAccessLayer.DTO;
using DataAccessLayer.NewFolder;
using Microsoft.AspNetCore.Mvc;
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
    public Task<List<UserOrderViewDto>> OrderViewAsync(int id);
    //public Task<List<OrderTable>> GetAllOrdersViewAsync();
    
}
