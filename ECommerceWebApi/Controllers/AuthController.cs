using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
//using WebApiJWT.Data;
using System.Net;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer;
using DataAccessLayer.Db;
using BusinessLayer.Interface;
using Microsoft.Identity.Client;

namespace WebApiJWT.Controllers
{
    [Route("/[Controller]")]
    [ApiController]
    public class AuthController : Controller
    {

        private readonly IAuth _db;

        public AuthController(IAuth db)
        {
            _db = db;

        }

        [HttpGet("create-token")]
        public  IActionResult AddToken(int id) 
        {
             
               var token=  _db.CreateToken(id);
                return Ok(token);
        }


       
    }
}
