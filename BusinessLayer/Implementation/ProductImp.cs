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
    public class ProductImp : IProduct
    {
        private readonly EcDbContext _con;

        public ProductImp(EcDbContext con)
        {
            _con = con;
        }

       public async Task AddProductAsync(Product obj)
        {
            try
            {
                await _con.products.AddAsync(obj);
                await _con.SaveChangesAsync();
            }
            catch (Exception ex){ throw; }
        }

        
    }
}
