using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public int Roleid { get; set; }

        [ForeignKey (nameof(Roleid))]
        public Role RoleId { get; set; }

        public ICollection<Product> Products { get; set;}
    }
}
