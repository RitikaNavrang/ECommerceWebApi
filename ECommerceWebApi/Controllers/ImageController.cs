using BusinessLayer.Interface;
using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IFileManagerLogic _fileManagerLogic;

        public ImageController(IFileManagerLogic fileManagerLogic)
        {
            _fileManagerLogic = fileManagerLogic;
        }



        [Route("upload")]
        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] FileModel model)
        {

            var res = await _fileManagerLogic.Upload(model);

            return Ok(res);
        }




        [Route("get")]
        [HttpGet]
        public async Task<IActionResult> Get(string fileName)
        {
            var imgBytes = await _fileManagerLogic.Get(fileName);
            return File(imgBytes, "image/webp");
        }




        [Route("download")]
        [HttpGet]
        public async Task<IActionResult> Download(string fileName)
        {
            var imagBytes = await _fileManagerLogic.Get(fileName);
            return new FileContentResult(imagBytes, "application/octet-stream")
            {
                FileDownloadName = Guid.NewGuid().ToString() + ".webp",
            };
        }


    }

}
