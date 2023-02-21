//using DataAccessLayer;

using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLayer.Interface;

public interface IRole
{
    public  Task AddRoleAsync(Role obj);
   // public Task GetRoleAsync(int id);


    //Task AddRoleAsync(global::DataAccessLayer.Role obj);
}
