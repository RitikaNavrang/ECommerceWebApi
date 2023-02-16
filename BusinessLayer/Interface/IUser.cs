using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface;

public interface IUser
{
    public  Task AddCustomerAsync(UserDto obj,int role);
   // public Task AddSupplierAsync(UserDto obj,int role);

}
