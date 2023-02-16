using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Db;
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

        //public async Task AddSupplierAsync(User obj,int role)
        //{
        //    try
        //    {
        //        _context.Users.Add(obj);
        //         await _context.SaveChangesAsync();
        //    }
        //    catch(Exception ex) {throw; }
        //}

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
                    Roleid = role1,
                };
                _context.Users.Add(us);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { throw; }
        }


    }
}
