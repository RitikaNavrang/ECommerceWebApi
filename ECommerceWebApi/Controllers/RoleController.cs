//using BusinessLayer.Interface;
//using DataAccessLayer;
using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Db;
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

        [HttpPost("Add-Role")]
        public async Task<IActionResult> AddRole(Role obj)
        {

            await _con.AddRoleAsync(obj);
            return Ok(obj);



        }
    }
}
