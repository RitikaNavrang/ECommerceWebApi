using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.NewFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using System.Security.Claims;

namespace ECommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _db;

        public CategoryController(ICategory db)
        {
            _db = db;
        }



        [HttpPost("add-category"),Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddCategory(CategoryDto obj)
        {
            try
            {
                string Uid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                int userId = Convert.ToInt32(Uid);

                var res = await _db.AddCategoryAsync(obj,userId);
                return Ok(res);
            }
            catch (Exception ex) 
            {
                throw;
            }
        }


        [HttpDelete("delete-category")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory(int id)
        {

            await _db.DeleteCategoryAsync(id);
            return Ok();
        }



        [HttpGet("getall-category")]
        [Authorize (Roles ="Admin,Supplier,Customer")]
        public async Task<IActionResult> GetAllCategory()
        {
           
               var get =  await _db.GetAllCategoryAsync();
                return Ok(get);
            
        }

        [HttpPut("update-category")]
        [Authorize (Roles ="Admin")]
        public async Task<IActionResult> UpdateCate(CategoryDto obj,int id,int userid)
        {
            string Uid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userId = Convert.ToInt32(Uid);

            var res = await _db.UpdateCategoryAsync(obj,id,userid);
            return Ok(res);
        }
    }
}
