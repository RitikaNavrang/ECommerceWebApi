using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Db;
using DataAccessLayer.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation
{
    public class UserImp : IUser
    {
        private readonly EcDbContext _context;
        public UserImp(EcDbContext con) 
        {
            _context = con;
        }

        

        public async Task AddCustomerAsync(UserDto obj, int role1)
        {
            try
            {
                if (obj == null)
                {
                    return;
                }
                User us = new User()
                {
                    UserId = obj.Id,
                    UserName = obj.Name,
                    RoleId = role1,
                };
                _context.Users.Add(us);
                await _context.SaveChangesAsync();
              
            }
            catch (Exception ex) { throw; }
        }

        public async Task<User> GetUserAsync(int id)
        {
            try
            {
                var us = await _context.Users.Where(a => a.UserId== id).FirstOrDefaultAsync();  
                if (us == null)
                    throw new Exception("User not found!");

                return us;
            }
            catch (Exception){ throw; }
        }

        public async Task<List<RoleDto>> GetAllUsersAsync()
        {
            try
            {
                var obj = _context.Roles.Include(x => x.Users).Select(x => new RoleDto()
                     {
                         RoleId = x.RoleId,
                         RoleName = x.RoleName,
                         UserRoles = x.Users.Select(u => new UserRoleDto()
                         {
                             UserId = u.UserId,
                             UserName = u.UserName
                         }).ToList(),
                     })
                     .ToList();

                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public async Task<List<UserDto>> GetAllSuppliersAsync()
        //{
        //    try
        //    {
        //        var obj = _context.Users.Where(a => a.RoleId == 2)
        //        {
        //            Id = x.Id,
        //            Name = x.Name,
        //            //UserRoles = x.Users.Select(u => new UserRoleDto()
        //            //{
        //            //    UserId = u.UserId,
        //            //    UserName = u.UserName
        //            //}).ToList(),
        //        })
        //             .ToList();

        //        return obj;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}



    }
}
