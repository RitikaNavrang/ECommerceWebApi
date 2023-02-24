using DataAccessLayer;
using DataAccessLayer.NewFolder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface;

public interface IProduct
{
    public Task<Product> AddProductAsync(ProductDto obj,int userid , string URL);
    public Task<string> RemoveProductAsync(int id);
    public Task<IList<Product>> GetAllProductAsync();

    public Task<string> GetImageById (int id);

    public Task<Product> UpdateProductAsync(ProductDto obj,int userid);


}
