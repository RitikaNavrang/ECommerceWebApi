using BusinessLayer.Interface;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using DataAccessLayer;
using DataAccessLayer.NewFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using System.Net;
using BusinessLayer.Implementation;
//using CloudinaryDotNet;
//using CloudinaryDotNet.Actions;


namespace ECommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _db;
        public static IWebHostEnvironment _webHostEnvironment;
        //private Cloudinary _cloudinary;
        public ProductController(IProduct db , IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            //_cloudinary = cloudinary;
        }


        #region Add-Product

        [HttpPost("add-product")]
        [Authorize(Roles = "Admin,Supplier")]
        public async Task<IActionResult> AddProductAsync([FromForm] ProductDto obj)
        {
            try
            {

                #region filestream

                //var filepath = "";

                //string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                //if (!Directory.Exists(path))
                //{
                //    Directory.CreateDirectory(path);
                //}
                //using (FileStream filestream = System.IO.File.Create(path + obj.fileupload.FileName))
                //{
                //    obj.fileupload.CopyTo(filestream);
                //    filestream.Flush();
                //    //return ($"Uploaded Done {path + fileupload.FileName}");
                //    filepath = path + obj.fileupload.FileName;
                //}

                #endregion filestream

                #region Cloudinary

                var file = obj.fileupload;

                var uploadResult = new ImageUploadResult();

                var cloudinary = new Cloudinary(new Account("dxcxcq1j4", "252825332172232", "AXKoil3qKF0286Kar2xuFaSaN0M"));

                var stream = file.OpenReadStream();
               
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        PublicId = obj.fileupload.FileName,
                    };

                     uploadResult = cloudinary.Upload(uploadParams);
                

                var filepath = uploadResult.SecureUrl.ToString();

                #endregion Cloudinary




                string Uid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                int userId = Convert.ToInt32(Uid);

                var res = await _db.AddProductAsync(obj,userId);
            return Ok(res);

            }
            catch (Exception exe)
            {

                return BadRequest(exe.InnerException);
            }
        }

        #endregion Add-Product



        #region get-product-image

        [Route("get-product-image")]
        [HttpGet]
        public async Task<IActionResult> Get(string fileName)
        {
            var imgBytes = await _db.Get(fileName);
            return File(imgBytes, "image/webp");
        }
        #endregion get-product-image




        #region delete-product

        [HttpDelete("delete-product")]
        [Authorize(Roles ="Admin,Supplier")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
              await _db.RemoveProductAsync(id);
                return Ok();
           
        }
        #endregion delete-product




        #region getall-product

        [HttpGet("getall-product")]
        [Authorize(Roles ="Admin,Supplier,Customer")]
        public async Task<IActionResult> GetAllProduct()
        {

            var getall = await _db.GetAllProductAsync();
             return Ok(getall);
          
        }

        #endregion getall-product



        #region update-product

        [HttpPut("update-product")]
        [Authorize(Roles ="Admin,Supplier")]
        public async Task<IActionResult> UpdateProduct(ProductDto obj)
        {
            string Uid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userId = Convert.ToInt32(Uid);

            var res = await _db.UpdateProductAsync(obj,userId);
            return Ok(res); 
        }

        #endregion update-product



        #region download


        [Route("download")]
        [HttpGet]
        public async Task<IActionResult> Download(string fileName)
        {
            var imagBytes = await _db.Get(fileName);
            return new FileContentResult(imagBytes, "application/octet-stream")
            {
                FileDownloadName = Guid.NewGuid().ToString() + ".webp",
            };
        }

        #endregion download




    }
}
