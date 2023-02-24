using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.NewFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace ECommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _db;
        public static IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProduct db , IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("add-product")]
        [Authorize(Roles = "Admin,Supplier")]
        public async Task<IActionResult> AddProductAsync([FromForm] ProductDto obj)
        {
            try
            {
                var filepath = "";

                string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (FileStream filestream = System.IO.File.Create(path + obj.fileupload.FileName))
                {
                    obj.fileupload.CopyTo(filestream);
                    filestream.Flush();
                    //return ($"Uploaded Done {path + fileupload.FileName}");
                    filepath = path + obj.fileupload.FileName;
                }

                string Uid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                int userId = Convert.ToInt32(Uid);

                var res = await _db.AddProductAsync(obj,userId ,filepath);
            return Ok(res);

            }
            catch (Exception exe)
            {

                return BadRequest(exe.InnerException);
            }
        }



        [HttpGet("view-products-Image-id")]
        public async Task<IActionResult> GetImage(int id)
        {
            var filename = await _db.GetImageById(id);

            var filepath = filename;
            if (!System.IO.File.Exists(filepath))
            {
            }
            byte[] b = System.IO.File.ReadAllBytes(filepath);
            return File(b, "image/png");
            
        }


        [HttpDelete("delete-product")]
        [Authorize(Roles ="Admin,Supplier")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
              await _db.RemoveProductAsync(id);
                return Ok();
           
        }

        [HttpGet("getall-product")]
        [Authorize(Roles ="Admin,Supplier,Customer")]
        public async Task<IActionResult> GetAllProduct()
        {
            
               var getall =  await _db.GetAllProductAsync();
                return Ok(getall);
            
           
        }

        [HttpPut("update-product")]
        [Authorize(Roles ="Admin,Supplier")]
        public async Task<IActionResult> UpdateProduct(ProductDto obj)
        {
            string Uid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userId = Convert.ToInt32(Uid);

            var res = await _db.UpdateProductAsync(obj,userId);
            return Ok(res); 
        }
    }
}
