using EfProductApp.Entities;
using EfProductApp.Repository;

namespace EfProductApp.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task AddAsync(Product product)
		{
			await _productRepository.AddAsync(product);
		}

		public async Task DeleteAsync(Product product)
		{
							
			await _productRepository.DeleteAsync(product);
		}

		public async Task<List<Product>> GetAllByKeyAsync(string key = "")
		{
			return await _productRepository.GettAllAsync(key);
		}

		public async Task UpdateAsync(Product product)
		{
			await _productRepository.UpdateAsync(product);
		}
	}
}
