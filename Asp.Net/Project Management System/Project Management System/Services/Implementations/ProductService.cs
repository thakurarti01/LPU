using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Data;
using ProjectManagementSystem.DTOs;
using ProjectManagementSystem.Entities;
using ProjectManagementSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace ProjectManagementSystem.Services
{
	public class ProductService : IProductService
	{
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;

		public ProductService(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<PagedResultDto<ProductSummaryDto>> GetProductsAsync(ProductFilterDto filter, int pageNumber, int pageSize)
		{
			var query = _context.Products
				.Include(p => p.Category)
				.AsQueryable();

			if (filter != null)
			{
				if (!string.IsNullOrEmpty(filter.SearchTerm))
					query = query.Where(p => p.Name.Contains(filter.SearchTerm));

				if (filter.CategoryId.HasValue)
					query = query.Where(p => p.CategoryId == filter.CategoryId);

				if (filter.MinPrice.HasValue)
					query = query.Where(p => p.Price >= filter.MinPrice);

				if (filter.MaxPrice.HasValue)
					query = query.Where(p => p.Price <= filter.MaxPrice);
			}

			var totalCount = await query.CountAsync();

			var products = await query
				.Skip((pageNumber - 1) * pageSize)	
				.Take(pageSize)
				.ToListAsync();

			var items = _mapper.Map<List<ProductSummaryDto>>(products);

			return new PagedResultDto<ProductSummaryDto>
			{
				Items = items,
				TotalCount = totalCount,
				PageNumber = pageNumber,
				PageSize = pageSize
			};
		}

		public async Task<ProductDetailDto?> GetProductByIdAsync(int id)
		{
			var product = await _context.Products
				.Include(p => p.Category)
				.FirstOrDefaultAsync(p => p.Id == id);

			if (product == null)
				return null;

			return _mapper.Map<ProductDetailDto>(product);
		}

		public async Task<ProductDetailDto> CreateProductAsync(CreateProductDto dto)
		{
			var product = _mapper.Map<Product>(dto);

			_context.Products.Add(product);
			await _context.SaveChangesAsync();

			return _mapper.Map<ProductDetailDto>(product);
		}

		public async Task<bool> UpdateProductAsync(int id, UpdateProductDto dto)
		{
			var product = await _context.Products.FindAsync(id);

			if (product == null)
				return false;

			_mapper.Map(dto, product);

			await _context.SaveChangesAsync();

			return true;
		}

		public async Task<bool> DeleteProductAsync(int id)
		{
			var product = await _context.Products.FindAsync(id);

			if (product == null)
				return false;

			_context.Products.Remove(product);
			await _context.SaveChangesAsync();

			return true;
		}
	}
}
