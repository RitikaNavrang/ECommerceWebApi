//using DataAccessLayer;

using DataAccessLayer;
using DataAccessLayer.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLayer.Interface;

public interface IRole
{
    

    public Task<Role> AddRoleAsync(RoleRespDto obj,int userid);
    public Task<List<Role>> GetAllRoleAsync();
    public Task<Role> GetRoleAsync(int id);


    //Task AddRoleAsync(global::DataAccessLayer.Role obj);
}
