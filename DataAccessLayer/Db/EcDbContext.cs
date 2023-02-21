using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.Db;

public class EcDbContext : DbContext
{
	public EcDbContext(DbContextOptions<EcDbContext> options): base(options)
	{

	}

	public DbSet<User> Users { get; set; }

	public DbSet<Role> Roles { get; set; }
    public DbSet<Product> products { get; set; }
    public DbSet<Category> categories { get; set; }

    public DbSet<OrderTable> orders { get; set; }

	public DbSet<OrderDetails> OrderDetails { get; set; }

}