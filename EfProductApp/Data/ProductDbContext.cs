using EfProductApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfProductApp.Data
{
	public class ProductDbContext : DbContext
	{
		public ProductDbContext(DbContextOptions<ProductDbContext> options)
		   : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
