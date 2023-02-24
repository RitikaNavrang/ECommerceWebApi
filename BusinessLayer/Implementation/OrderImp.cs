using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Db;
using DataAccessLayer.DTO;
using DataAccessLayer.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Implementation;

public class OrderImp : IOrder
{
    private readonly EcDbContext _db;

    public OrderImp(EcDbContext db)
    {
        _db = db;
    }


    public async Task<OrderTable> orderAsync(AddOrderDto obj, int userid)
    {

        try
        {
            var totalPrice = await _db.products.Where(x => obj.ProductId.Contains(x.Id)).SumAsync(x => x.Price);

            List<OrderDetails> orderDetails = new List<OrderDetails>();
            foreach (int i in obj.ProductId)
            {
                OrderDetails orderdetail = new OrderDetails();
                orderdetail.ProductId = i;
               
                orderDetails.Add(orderdetail);
                
            };

            OrderTable table = new OrderTable()
            {
                
                TotalPrice = totalPrice,
                UserId = userid,
                OrderDetails = orderDetails,
                CreatedAt = DateTime.Now,
                //ModifiedAt = DateTime.Now,
                CreatedBy = userid,
               // ModifiedBy = obj.OrderId,
            };
            await _db.OrderTable.AddAsync(table);
            await _db.SaveChangesAsync();

            return (table);
        }
        catch (Exception)
        {
            throw;
        }
    }

    

    public async Task<List<UserOrderViewDto>> OrderViewAsync(int id)
    {
        try
        {
            var username = _db.Users.Where(x => x.UserId == id).Select(x => x.UserName).FirstOrDefault();

            var user = _db.OrderTable.Where(x => x.Id == id).Include(x => x.OrderDetails)
                .ThenInclude(x => x.Product).Select(x => new UserOrderViewDto()
                {

                    UserName = username,
                    TotalPrice = x.TotalPrice,
                    UserId = id,
                    Userpro = x.OrderDetails.Select(x => new UserProductOrderViewDto()
                    {

                        OrderId = x.Id,
                        ProductName = x.Product.ProductName,
                        Price = x.Product.Price,
                        ProductDescription = x.Product.Description,

                }).ToList(),
                }) .ToList();
            return user;
        }
        catch (Exception)
        {
            throw;
        }
    }

    //public async Task<List<OrderTable>> GetAllOrdersViewAsync()
    //{
    //    try
    //    {
    //        var res = await _db.OrderTable.ToListAsync();
    //        return res;
    //    }
    //    catch(Exception)
    //    {
    //        throw;
    //    }
    //}

}
