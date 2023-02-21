using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Db;
using DataAccessLayer.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation
{
    public class ProductImp : IProduct
    {
        private readonly EcDbContext _con;

        public ProductImp(EcDbContext con)
        {
            _con = con;
        }

       public async Task<Product> AddProductAsync(ProductDto obj)
        {
            try
            {
                Product res = new Product
                {
                    Id= obj.Id,
                    Name = obj.Name,
                    Description= obj.Description,
                    UserId= obj.UserId,
                    Price=obj.Price,
                    CategoryId= obj.CategoryId,
                };
                await _con.products.AddAsync(res);
                     _con.SaveChanges();
                return res;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> RemoveProductAsync(int id)
        {
                var del= _con.products.FirstOrDefault(x => x.Id == id);
                 _con.products.Remove(del);
                await _con.SaveChangesAsync();
            return ("successful");
           
        }


        public async Task <IList<Product>> GetAllProductAsync()
        {
           
               var prolist = await _con.products.ToListAsync();
                return prolist;
            
        }

        public async Task<Product> UpdateProductAsync(ProductDto obj,int id)
        {
            try
            {
                Product get = new Product
                {
                    Id= obj.Id,
                    Name= obj.Name,
                    Price= obj.Price,
                    CategoryId = obj.CategoryId,
                };
                 _con.products.Update(get);
                _con.SaveChangesAsync();
                return get;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        
    }
}
