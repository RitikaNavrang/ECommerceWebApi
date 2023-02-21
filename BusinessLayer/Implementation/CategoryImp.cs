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
    private readonly EcDbContext _context;

    public CategoryImp(EcDbContext context)
    {
        _context = context;
    }


    public async Task<CategoryDto> AddCategoryAsync(CategoryDto obj)
    {
        try
        {

            Category res = new Category
            {
                Name = obj.CategoryName
            };
            _context.categories.AddAsync(res);
            await _context.SaveChangesAsync();
            return obj;
        }
        catch (Exception ex) 
        {
            throw; 
        }
    }


    public async Task<Category> DeleteCategoryAsync(int id)
    {
       

            var del = _context.categories.FirstOrDefault(x => x.Id == id);
             _context.categories.Remove(del);
            _context.SaveChanges();
            return del;
       

    }

   
    public async Task<IList<Category>> GetAllCategoryAsync()
    {
        
        var getall = _context.categories.Include(a => a.collectproducts).ToList();
            return getall;
        
    }

    public async Task<Category> UpdateCategoryAsync(CategoryDto obj,int CategoryId)
    {
        try
        {
            Category res = new Category
            {
                Id = CategoryId,
               Name = obj.CategoryName,
            };
            _context.categories.Update(res);
            await _context.SaveChangesAsync();
            return res;

        }
        catch (Exception ex)
        {
            throw;
        }

    }

    
}
