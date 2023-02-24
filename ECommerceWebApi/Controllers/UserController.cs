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
        private readonly IUser _db;

        public UserController(IUser db)
        {
            _db= db;
        }

        [HttpPost("add-supplier")]
        [Authorize (Roles ="Admin")]
        public async Task<IActionResult> AddSupplier(UserDto obj)
        {
            try
            {
                int role = 2;
                 await _db.AddCustomerAsync(obj,role);
                return Ok(obj);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("add-customer")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> AddCustomer(UserDto obj)
        {
            try
            {
                int role = 3;
                await _db.AddCustomerAsync(obj, role);
                return Ok(obj);
            }
            catch (Exception ex) {
                return BadRequest();
            }
        }

        [HttpGet("get-user-by-id")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetUser(int id)
        {
            var res = await _db.GetUserAsync(id);
            return Ok(res);
        }

        [HttpGet("get-all-users")]
        [Authorize (Roles ="Admin")]

        public async Task<IActionResult> GetAllUsers()
        {
            var res = await _db.GetAllUsersAsync();
            return Ok(res);
        }


        [HttpGet("get-all-suppliers")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetAllSuppliers()
        {
            var supp = await _db.GetAllSuppliersAsync();
            return Ok(supp);
        }
    }
}
