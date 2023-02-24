using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer;

public class Product :  Audit
{
    [Key]
    public int Id { get; set; }
    public string ProductName { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }

   public int CategoryId { get; set; }

    public int UserId { get; set; }

    public string ImgUrl { get; set; }



    public ICollection<OrderDetails>  OrderDetails { get; set;}

    #region Navigation

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }

    [ForeignKey(nameof(CategoryId))]
    
   public Category Category { get; set; }

    #endregion Navigation

}
