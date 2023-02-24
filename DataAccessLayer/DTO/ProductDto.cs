using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.NewFolder;

public class ProductDto
{
    

    public IFormFile fileupload { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public int UserId { get; set; }


   // [ForeignKey("UserId")]
   
    //public User User { get; set; }  

    public int Price { get; set; }

    public int CategoryId { get; set; }
}
