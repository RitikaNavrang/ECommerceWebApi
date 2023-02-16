using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user= user;
        }

        [HttpPost("Add-Supplier")]
        public async Task<IActionResult> AddSupplier(UserDto obj)
        {
            try
            {
                int role = 4;
                 await _user.AddCustomerAsync(obj,role);
                return Ok(obj);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("Add-Customer")]
        public async Task<IActionResult> AddCustomer(UserDto obj)
        {
            try
            {
                int role = 3;
                await _user.AddCustomerAsync(obj, role);
                return Ok(obj);
            }
            catch (Exception ex) {
                return BadRequest();
            }
        }
    }
}
