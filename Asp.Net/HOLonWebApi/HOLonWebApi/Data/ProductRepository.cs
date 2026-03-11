using ProductApi.Models;
using System.Linq;

namespace ProductApi.Data
{
	public class ProductRepository
	{
		private static List<Product> products = new List<Product>()
		{
			new Product{Id = 101, Name="Laptop", Price = 50000, Quantity = 5},
			new Product{Id = 102, Name="Mouse", Price = 500, Quantity = 15},
		};

		public List<Product> GetAll()
		{
			return products;
		}

		public Product GetById(int id)
		{
			return products.FirstOrDefault(p => p.Id == id);
		}

		public void Add(Product product)
		{
			product.Id = products.Max(p => p.Id) + 1;
			products.Add(product);
		}

		public void Update(Product product)
		{
			var data = products.FirstOrDefault(p => p.Id == product.Id);

			data.Name = product.Name;
			data.Price = product.Price;
			data.Quantity = product.Quantity;
		}

		public void Delete(int id)
		{
			var item = products.FirstOrDefault(p => p.Id == id);
			products.Remove(item);
		}
	}
}
