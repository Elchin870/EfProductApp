using EfProductApp.Entities;
using EfProductApp.Models;
using EfProductApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EfProductApp.Controllers
{
	public class ProductController : Controller
	{
		private IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IActionResult> Index(string key="")
		{
			var result=await _productService.GetAllByKeyAsync(key);
			return View(result);
		}

		public async Task<IActionResult> Delete(int id)
		{
			var product = new Product { Id = id };
			await _productService.DeleteAsync(product);
			TempData["Message"] = "Product deleted successfully";
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Add()
		{
			var vm = new ProductAddViewModel
			{
				Product = new Product()
			};
			return View(vm);
		}

		[HttpPost]
		public async Task<IActionResult> Add(Product product)
		{
			if (ModelState.IsValid)
			{
				await _productService.AddAsync(product);
				TempData["Message"] = "Product added successfully";
				return RedirectToAction("Index");
			}
			return View(product);
		}

		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			var product = await _productService.GetAllByKeyAsync();
			var selectedProduct = product.FirstOrDefault(p => p.Id == id);

			if (selectedProduct == null)
			{
				return NotFound();
			}

			var vm = new ProductAddViewModel
			{
				Product = selectedProduct
			};

			return View(vm);
		}

		[HttpPost]
		public async Task<IActionResult> Update(ProductAddViewModel vm)
		{
			if (ModelState.IsValid)
			{
				await _productService.UpdateAsync(vm.Product);
				TempData["Message"] = "Product updated successfully";
				return RedirectToAction("Index");
			}

			return View(vm);
		}


	}
}
