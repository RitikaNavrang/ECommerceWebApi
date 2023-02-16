//using DataAccessLayer;

using DataAccessLayer;

namespace BusinessLayer.Interface;

public interface IRole
{
    public  Task AddRoleAsync(Role obj);


    //Task AddRoleAsync(global::DataAccessLayer.Role obj);
}
