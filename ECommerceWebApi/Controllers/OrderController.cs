using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Db;
using DataAccessLayer.DTO;
using DataAccessLayer.NewFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ECommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _db;

        public OrderController(IOrder db)
        {
            _db = db;
        }

        [HttpPost("add-db"), Authorize(Roles = "Admin,Customer")]
        public async Task<IActionResult> AddOrder(AddOrderDto obj, int userid)
        {
            var res = await _db.orderAsync(obj, userid);
            return Ok(res);


        }

        [HttpGet("db-view"),Authorize(Roles ="Admin,Supplier")]
        public async Task<IActionResult> OrderView(int id)
        {
            var view = await _db.OrderViewAsync(id);
            return Ok(view);
        }

        //[HttpGet("order-view"), Authorize(Roles = "Admin,Supplier")]
        //public async Task<IActionResult> GetAllOrdersView()
        //{
        //    var view = await _order.GetAllOrdersViewAsync();
        //    return Ok(view);
        //}

    }
}
