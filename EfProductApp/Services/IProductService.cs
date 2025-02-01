using EfProductApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfProductApp.Services
{
	public interface IProductService
	{
		Task<List<Product>> GetAllByKeyAsync(string key = "");
		Task AddAsync(Product product);
		Task UpdateAsync(Product product);
		Task DeleteAsync(Product product);
		
	}
}
