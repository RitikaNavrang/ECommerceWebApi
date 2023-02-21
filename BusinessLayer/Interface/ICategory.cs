using DataAccessLayer;
using DataAccessLayer.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ICategory
    {
        public Task<CategoryDto> AddCategoryAsync(CategoryDto obj);
        public Task<IList<Category>> GetAllCategoryAsync();
        public Task<Category> DeleteCategoryAsync(int id);
        public Task<Category> UpdateCategoryAsync(CategoryDto obj,int id);


    }
}
