using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Db;
using Microsoft.AspNetCore.Mvc;



//using DataAccessLayer;
namespace BusinessLayer.Implementation;

public class RoleImp : IRole
{
    private readonly EcDbContext _context;

    public RoleImp(EcDbContext context)
    {
        _context = context;
    }

    

    public async Task AddRoleAsync(Role obj)
    {
        try {
            //throw new Exception();
             _context.Roles.AddAsync(obj);
           await _context.SaveChangesAsync();
        }
        catch (Exception ex){ throw; }
    }

   
}
