using EfProductApp.Entities;

namespace EfProductApp.Repository
{
	public interface IProductRepository
	{
		Task<List<Product>> GettAllAsync(string key);
		Task AddAsync(Product product);
		Task UpdateAsync(Product product);
		Task DeleteAsync(Product product);
	}
}
