using ProjectManagementSystem.DTOs;

namespace ProjectManagementSystem.Services.Interfaces
{
	public interface IProductService
	{
		Task<PagedResultDto<ProductSummaryDto>> GetProductsAsync(ProductFilterDto filter, int pageNumber, int pageSize);

		Task<ProductDetailDto?> GetProductByIdAsync(int id);

		Task<ProductDetailDto> CreateProductAsync(CreateProductDto dto);

		Task<bool> UpdateProductAsync(int id, UpdateProductDto dto);

		Task<bool> DeleteProductAsync(int id);
	}
}