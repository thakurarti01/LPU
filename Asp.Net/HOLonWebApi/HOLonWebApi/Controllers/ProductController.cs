using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Data;
using ProductApi.Models;

namespace ProductApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly ProductRepository repo = new ProductRepository();
		[HttpGet]
		public ActionResult<IEnumerable<Product>> GetProducts()
		{
			return Ok(repo.GetAll());
		}

		[HttpGet("{id}")]
		public ActionResult<Product> GetProduct(int id)
		{
			var product = repo.GetById(id);
			if(product == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(product);
			}
		}

		[HttpPost]
		public IActionResult AddProduct (Product product)
		{
			repo.Add(product);
			return Ok(product);
		}

		[HttpPut("{id}")]
		public IActionResult updateProduct(int id, Product product)
		{
			repo.Update(product);
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteProduct(int id)
		{
			repo.Delete(id);
			return Ok();
		}
	}
}
