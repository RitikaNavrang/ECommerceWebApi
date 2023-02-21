using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Db;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("add-supplier")]
        public async Task<IActionResult> AddSupplier(UserDto obj)
        {
            try
            {
                int role = 2;
                 await _user.AddCustomerAsync(obj,role);
                return Ok(obj);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("add-customer")]
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

        [HttpGet("get-user-by-id")]
        public async Task<IActionResult> GetUser(int id)
        {
            var res = await _user.GetUserAsync(id);
            return Ok(res);
        }

        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var res = await _user.GetAllUsersAsync();
            return Ok(res);
        }


        //[HttpGet("get-all-suppliers")]
        //public async Task<IActionResult> GetAllSuppliers()
        //{
        //    var supp = await _user.GetAllSuppliersAsync();
        //    return Ok(supp);
        //}
    }
}
