//using BusinessLayer.Interface;
//using DataAccessLayer;
using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Db;
using DataAccessLayer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerceWebApi.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRole _db;

        public RoleController(IRole db)
        {
            _db = db;
        }

        [HttpPost("add-role")]
        [Authorize (Roles ="Admin")]
        public async Task<IActionResult> AddRole(RoleRespDto obj)
        {
            string Uid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userId = Convert.ToInt32(Uid);

             var res = await _db.AddRoleAsync(obj,userId);
            return Ok(res);

        }



        [HttpGet("get-role-by-Id")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetRole(int id)
        {

            var res = await _db.GetRoleAsync(id);
            return Ok(res);

        }



        [HttpGet("get-all-roles")]
        [Authorize (Roles ="Admin")]
        public async Task<IActionResult> GetallRole()
        {

            var res = await _db.GetAllRoleAsync();
            return Ok(res);

        }

    }
}
