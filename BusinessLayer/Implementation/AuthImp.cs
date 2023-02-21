using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Db;
using DataAccessLayer.NewFolder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation;

public class AuthImp : IAuth
{
    private readonly EcDbContext _db;
    private readonly IConfiguration _configuration;

    public AuthImp(EcDbContext db, IConfiguration confi)
    {
        _db = db;
        _configuration = confi;
    }
    public string CreateToken(int id)
    {
        var role = _db.Users.Where(x=>x.UserId==id).Include(x=>x.Roles).FirstOrDefault();

        List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, role.UserName),
                new Claim(ClaimTypes.Role, role.Roles.RoleName),

            };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:Token").Value));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken
        (
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

         return jwt;

    }
}
