using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.NewFolder;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProductAsync(ProductDto obj)
        {
            try
            {
            var res =  _pro.AddProductAsync(obj);
            return Ok(res);

            }
            catch (Exception exe)
            {

                return BadRequest(exe.InnerException);
            }
        }
       

        [HttpDelete("delete-product")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
              await _pro.RemoveProductAsync(id);
                return Ok();
           
        }

        [HttpGet("getall-product")]
        public async Task<IActionResult> GetAllProduct()
        {
            
               var getall =  await _pro.GetAllProductAsync();
                return Ok(getall);
            
           
        }

        [HttpPut("update-product")]
        public async Task<IActionResult> UpdateProduct(ProductDto obj,int CategoryId)
        {
            var res = await _pro.UpdateProductAsync(obj,CategoryId);
            return Ok(res); 
        }
    }
}
