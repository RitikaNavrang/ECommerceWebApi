using AutoMapper;
using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Db;
using DataAccessLayer.DTO;
using DataAccessLayer.NewFolder;
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
        private readonly EcDbContext _db;
        private readonly IMapper _mapper;
        public UserImp(EcDbContext db,IMapper mapper) 
        {
            _db = db;
            _mapper = mapper;
        }

        

        public async Task AddCustomerAsync(UserDto obj, int role1)
        {
            try
            {
                if (obj == null)
                {
                    return;
                }
                
                var map = _mapper.Map<User>(obj);
                map.RoleId = role1;
                map.CreatedBy = obj.Id;
                map.CreatedAt = DateTime.Now;

                _db.Users.Add(map);
                await _db.SaveChangesAsync();
              
            }
            catch (Exception ex) { throw; }
        }

        public async Task<User> GetUserAsync(int id)
        {
            try
            {
                var us = await _db.Users.Where(a => a.UserId== id).FirstOrDefaultAsync();  
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
                var obj = _db.Roles.Include(x => x.Users).Select(x => new RoleDto()
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


        public async Task<List<UserRoleDto>> GetAllSuppliersAsync()
        {
            try
            {

                var obj= await _db.Users.Where(a => a.RoleId == 2).Select(x => new UserRoleDto()
                {
                    UserId = x.UserId,
                    UserName= x.UserName,
                }).ToListAsync();

                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
