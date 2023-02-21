//using BusinessLayer.Interface;
//using DataAccessLayer;
using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Db;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApi.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRole _con;

        public RoleController(IRole con)
        {
            _con = con;
        }

        [HttpPost("add-role")]
        public async Task<IActionResult> AddRole(Role obj)
        {

            await _con.AddRoleAsync(obj);
            return Ok(obj);

        }

        //[HttpGet("Get-Role-ById")]
        //public async Task<IActionResult> GetRole(int id)
        //{
           
        //    await _con.GetRoleAsync(id);
        //    return Ok();

        //}
    }
}
