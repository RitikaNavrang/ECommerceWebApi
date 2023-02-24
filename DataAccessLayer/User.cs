using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class User : Audit
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public int RoleId { get; set; }
        public ICollection<Product> ProCollect { get; set; }

        #region Navigation

        [ForeignKey (nameof(RoleId))]
        public Role Roles { get; set; }

        #endregion Navigation

    }
}
