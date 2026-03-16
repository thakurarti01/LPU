using AutoMapper;
using ProjectManagementSystem.Entities;
using ProjectManagementSystem.DTOs;

namespace ProjectManagementSystem.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Product, ProductSummaryDto>();
			CreateMap<Product, ProductDetailDto>();

			CreateMap<CreateProductDto, Product>();
			CreateMap<UpdateProductDto, Product>();

			CreateMap<Category, CategoryDto>();
			CreateMap<CreateCategoryDto, Category>();

			CreateMap<Order, OrderDto>();
			CreateMap<OrderItem, CreateOrderItemDto>();

			CreateMap<Inventory, InventoryDto>();
		}
	}
}