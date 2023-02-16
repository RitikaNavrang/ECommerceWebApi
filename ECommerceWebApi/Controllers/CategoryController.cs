using BusinessLayer.Interface;
using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category obj)
        {
            try
            {
                await _cate.AddCategoryAsync(obj);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
