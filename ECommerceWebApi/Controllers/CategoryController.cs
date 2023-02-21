using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.NewFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace ECommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _cate;

        public CategoryController(ICategory cate)
        {
            _cate = cate;
        }



        [HttpPost("add-category")]
        public async Task<IActionResult> AddCategory(CategoryDto obj)
        {
            try
            {
                var res = await _cate.AddCategoryAsync(obj);
                return Ok(res);
            }
            catch (Exception ex) 
            {
                throw;
            }
        }


        [HttpDelete("delete-category")]
        public async Task<IActionResult> DeleteCategory(int id)
        {

            await _cate.DeleteCategoryAsync(id);
            return Ok();
        }



            [HttpGet("getall-category")]
        public async Task<IActionResult> GetAllCategory()
        {
           
               var get =  await _cate.GetAllCategoryAsync();
                return Ok(get);
            
        }

        [HttpPut("update-category")]
        public async Task<IActionResult> UpdateCate(CategoryDto obj,int id)
        {
            var res = await _cate.UpdateCategoryAsync(obj,id);
            return Ok(res);
        }
    }
}
