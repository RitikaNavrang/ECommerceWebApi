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

        private readonly IAuth _auth;

        public AuthController(IAuth auth)
        {
            _auth = auth;

        }

        [HttpGet("create-token")]
        public  IActionResult AddToken(int id) 
        {
            try
            { 
               var token=  _auth.CreateToken(id);
                return Ok(token);
            }
            catch(Exception ex) { throw; }
        }

    }
}
