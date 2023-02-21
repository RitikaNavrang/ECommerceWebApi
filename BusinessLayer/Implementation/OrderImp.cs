using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Db;
using DataAccessLayer.NewFolder;
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
                OrderDetails = orderDetails
            };
            await _db.orders.AddAsync(table);
            await _db.SaveChangesAsync();

            return (table);
        }
        catch (Exception)
        {
            throw;
        }
    }


}
