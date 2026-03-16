using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.DTOs;
using ProjectManagementSystem.Services.Interfaces;

namespace ProjectManagementSystem.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		// GET: Product
		public async Task<IActionResult> Index(string? searchTerm, int pageNumber = 1)
		{
			var filter = new ProductFilterDto
			{
				SearchTerm = searchTerm
			};

			var result = await _productService.GetProductsAsync(filter, pageNumber, 10);

			return View(result);
		}

		// GET: Product/Details/5
		public async Task<IActionResult> Details(int id)
		{
			var product = await _productService.GetProductByIdAsync(id);

			if (product == null)
				return NotFound();

			return View(product);
		}

		// GET: Product/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Product/Create
		[HttpPost]
		public async Task<IActionResult> Create(CreateProductDto dto)
		{
			if (!ModelState.IsValid)
				return View(dto);

			await _productService.CreateProductAsync(dto);

			return RedirectToAction(nameof(Index));
		}

		// GET: Product/Edit/5
		public async Task<IActionResult> Edit(int id)
		{
			var product = await _productService.GetProductByIdAsync(id);

			if (product == null)
				return NotFound();

			return View(product);
		}

		// POST: Product/Edit
		[HttpPost]
		public async Task<IActionResult> Edit(int id, UpdateProductDto dto)
		{
			var success = await _productService.UpdateProductAsync(id, dto);

			if (!success)
				return NotFound();

			return RedirectToAction(nameof(Index));
		}

		// GET: Product/Delete/5
		public async Task<IActionResult> Delete(int id)
		{
			var product = await _productService.GetProductByIdAsync(id);

			if (product == null)
				return NotFound();

			return View(product);
		}

		// POST: Product/Delete
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await _productService.DeleteProductAsync(id);

			return RedirectToAction(nameof(Index));
		}
	}
}