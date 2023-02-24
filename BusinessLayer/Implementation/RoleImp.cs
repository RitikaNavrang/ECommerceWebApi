using AutoMapper;
using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Db;
using DataAccessLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



//using DataAccessLayer;
namespace BusinessLayer.Implementation;

public class RoleImp : IRole
{
    private readonly EcDbContext _db;
    private readonly IMapper _mapper;
    public RoleImp(EcDbContext db,IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    

    public async Task<Role> AddRoleAsync(RoleRespDto obj,int userid)
    {
        try
        {

            var map = _mapper.Map<Role>(obj);

            map.CreatedAt = DateTime.Now;
            map.CreatedBy = userid;

            _db.Roles.AddAsync(map);
            await _db.SaveChangesAsync();
            return map;
        }
        catch (Exception) { throw; }
    }

    public async Task<List<Role>> GetAllRoleAsync()
    {

        try
        {
            var list = await _db.Roles.ToListAsync();
            return list;
        }
        catch(Exception) { throw; }
    }

    public async Task<Role> GetRoleAsync(int id)
    {

        try
        {
            var res = await _db.Roles.Where(x => x.RoleId == id).FirstOrDefaultAsync();
            return res;
        }
        catch (Exception) { throw; }
    }
}
