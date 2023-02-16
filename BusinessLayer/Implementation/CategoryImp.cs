using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Db;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation;

public class CategoryImp : ICategory
{
    private readonly EcDbContext _context;

    public CategoryImp(EcDbContext context)
    {
        _context = context;
    }


    public async Task AddCategoryAsync(Category obj)
    {
        try
        {
            _context.categories.Add(obj);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex) {
            throw;
        
        }
    }
}
