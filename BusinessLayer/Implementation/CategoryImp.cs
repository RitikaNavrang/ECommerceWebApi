using AutoMapper;
using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Db;
using DataAccessLayer.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace BusinessLayer.Implementation;

public class CategoryImp : ICategory
{
    private readonly EcDbContext _db;
    private readonly IMapper _mapper;

    public CategoryImp(EcDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }


    public async Task<Category> AddCategoryAsync(CategoryDto obj,int userid)
    {
        try
        {

            var map = _mapper.Map<Category>(obj);
            map.CreatedAt= DateTime.Now;
            map.CreatedBy= userid;

            _db.categories.AddAsync(map);
            await _db.SaveChangesAsync();
            return map;
        }
        catch (Exception ex) 
        {
            throw; 
        }
    }


    public async Task<Category> DeleteCategoryAsync(int id)
    {
       

            var del = _db.categories.FirstOrDefault(x => x.Id == id);
             _db.categories.Remove(del);
            _db.SaveChanges();
            return del;
       

    }

   
    public async Task<IList<Category>> GetAllCategoryAsync()
    {
        
        var getall = _db.categories.Include(a => a.collectproducts).ToList();
            return getall;
        
    }

    public async Task<Category> UpdateCategoryAsync(CategoryDto obj,int CategoryId,int userid)
    {
        try
        {

            
            var res = _mapper.Map<Category>(obj);

            res.ModifiedAt = DateTime.Now;
            res.ModifiedBy = userid;

            _db.categories.Update(res);
            await _db.SaveChangesAsync();
            return res;

        }
        catch (Exception ex)
        {
            throw;
        }

    }

    
}
