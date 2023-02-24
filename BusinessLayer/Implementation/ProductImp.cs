using AutoMapper;
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
        private readonly EcDbContext _db;
        private readonly IMapper _mapper;

        public ProductImp(EcDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

       public async Task<Product> AddProductAsync(ProductDto obj,int userid , string URL)
        {
            try
            {
                
                var map = _mapper.Map<Product>(obj);
                
                map.CreatedAt= DateTime.Now;
                map.CreatedBy= userid;
                map.UserId= userid;
                map.ImgUrl= URL;

                await _db.products.AddAsync(map);
                     _db.SaveChanges();
                return map;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> RemoveProductAsync(int id)
        {
                var del= _db.products.FirstOrDefault(x => x.Id == id);
                 _db.products.Remove(del);
                await _db.SaveChangesAsync();
            return ("successful");
           
        }


        public async Task <IList<Product>> GetAllProductAsync()
        {
           
               var prolist = await _db.products.ToListAsync();
                return prolist;
            
        }

        public async Task<Product> UpdateProductAsync(ProductDto obj,int userid)
        {
            try
            {
                //Product get = new Product
                //{
                //    Id = obj.Id,
                //    ProductName = obj.Name,
                //    Price = obj.Price,
                //    CategoryId = obj.CategoryId,
                //};

                var res = _mapper.Map<Product>(obj);
                
                //res.UserId= userid;
                res.ModifiedAt = DateTime.Now;
                res.ModifiedBy = userid;

                 _db.products.Update(res);
                await _db.SaveChangesAsync();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> GetImageById(int id)
        {
            try
            {
                var url = await  _db.products.Where(x=>x.Id == id).Select(x=>x.ImgUrl).FirstOrDefaultAsync();
                return url;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
