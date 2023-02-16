using BusinessLayer.Interface;
using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ECommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _pro;

        public ProductController(IProduct pro)
        {
            _pro= pro;
        }


        [HttpPost("Add-Product")]
        public async Task<IActionResult> AddProduct(Product obj)
        {
            try
            {
                
                await _pro.AddProductAsync(obj);
                return Ok(obj);
            }
            catch (Exception ex) { 
            return BadRequest(ex.Message);
            }
        }

    }
}
