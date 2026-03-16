namespace ProjectManagementSystem.DTOs
{
	public class ProductDetailDto
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public decimal? DiscountedPrice { get; set; }

		public decimal Savings => Price - (DiscountedPrice ?? Price);

		public int DiscountPercentage =>
			DiscountedPrice.HasValue
			? (int)((Price - DiscountedPrice.Value) / Price * 100)
			: 0;

		public bool IsActive { get; set; }
		public bool IsFeatured { get; set; }

		public double AverageRating { get; set; }
		public int ReviewCount { get; set; }

		public string ImageUrl { get; set; } = string.Empty;
	}


	public class ProductSummaryDto
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public decimal? DiscountedPrice { get; set; }
		public string CategoryName { get; set; } = string.Empty;
		public bool IsInStock { get; set; }
	}


	public class CreateProductDto
	{
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public decimal? DiscountedPrice { get; set; }
		public int CategoryId { get; set; }
		public string SKU { get; set; } = string.Empty;
	}


	public class UpdateProductDto
	{
		public string? Name { get; set; }
		public decimal? Price { get; set; }
		public decimal? DiscountedPrice { get; set; }
		public int? CategoryId { get; set; }
		public bool? IsActive { get; set; }
		public bool? IsFeatured { get; set; }
	}


	public class ProductFilterDto
	{
		public string? SearchTerm { get; set; }
		public int? CategoryId { get; set; }
		public decimal? MinPrice { get; set; }
		public decimal? MaxPrice { get; set; }
		public bool? InStock { get; set; }
		public bool? IsFeatured { get; set; }
		public int? MinRating { get; set; }
	}


	public class PagedResultDto<T>
	{
		public List<T> Items { get; set; } = new();
		public int TotalCount { get; set; }
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
	}
}