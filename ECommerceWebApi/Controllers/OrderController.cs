using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Db;
using DataAccessLayer.NewFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _order;

        public OrderController(IOrder order)
        {
            _order = order;
        }

        [HttpPost("add-order")]
        public async Task<IActionResult> AddOrder(AddOrderDto obj, int userid)
        {
            var res = await _order.orderAsync(obj, userid);
            return Ok(res);
        }

    }
}
