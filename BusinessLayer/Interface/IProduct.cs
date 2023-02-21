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
    public Task<Product> AddProductAsync(ProductDto obj);
    public Task<string> RemoveProductAsync(int id);
    public Task<IList<Product>> GetAllProductAsync();

    public Task<Product> UpdateProductAsync(ProductDto obj,int id);


}
