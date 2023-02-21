using DataAccessLayer;
using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface;

public interface IUser
{
    public  Task AddCustomerAsync(UserDto obj,int role);
    public Task<User> GetUserAsync(int id);
    public Task<List<RoleDto>> GetAllUsersAsync();
   // public Task<List<UserDto>> GetAllSuppliersAsync();


    // public Task AddSupplierAsync(UserDto obj,int role);

}
