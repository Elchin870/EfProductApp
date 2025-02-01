using EfProductApp.Data;
using EfProductApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfProductApp.Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly ProductDbContext _context;

		public ProductRepository(ProductDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(Product product)
		{
			await _context.Products.AddAsync(product);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(Product product)
		{
			_context.Products.Remove(product);
			await _context.SaveChangesAsync();
		}

		public async Task<List<Product>> GettAllAsync(string key)
		{
			var keyCode=key.Trim().ToLower();
			return keyCode != "" ? await _context.Products.Where(s => s.Name.ToLower().Contains(keyCode)).ToListAsync() : await _context.Products.ToListAsync();
		}

		public async Task UpdateAsync(Product product)
		{
			_context.Products.Update(product);
			await _context.SaveChangesAsync();
		}
	}
}
