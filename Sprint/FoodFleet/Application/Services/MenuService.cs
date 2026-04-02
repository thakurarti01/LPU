using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
	public class MenuService : IMenuService
	{
		private readonly IMenuRepository _menuRepository;

		public MenuService(IMenuRepository menuRepository)
		{
			_menuRepository = menuRepository;
		}

		public async Task<IEnumerable<MenuItemDto>> GetAllAsync()
		{
			var items = await _menuRepository.GetAllAsync();

			return items.Select(x => new MenuItemDto
			{
				Id = x.MenuItemId,
				Name = x.Name,
				Description = x.Description,
				Price = x.Price,
				RestaurantId = x.RestaurantId
			});
		}

		public async Task<MenuItemDto> GetByIdAsync(int id)
		{
			var item = await _menuRepository.GetByIdAsync(id);

			if (item == null) return null;

			return new MenuItemDto
			{
				Id = item.MenuItemId,
				Name = item.Name,
				Description = item.Description,
				Price = item.Price,
				RestaurantId = item.RestaurantId
			};
		}

		public async Task AddAsync(CreateMenuItemDto dto)
		{
			var menuItem = new MenuItem
			{
				Name = dto.Name,
				Description = dto.Description,
				Price = dto.Price,
				RestaurantId = dto.RestaurantId
			};

			await _menuRepository.AddAsync(menuItem);
		}

		public async Task UpdateAsync(int id, UpdateMenuItemDto dto)
		{
			var item = await _menuRepository.GetByIdAsync(id);

			if (item == null) return;

			item.Name = dto.Name;
			item.Description = dto.Description;
			item.Price = dto.Price;

			await _menuRepository.UpdateAsync(item);
		}

		public async Task DeleteAsync(int id)
		{
			await _menuRepository.DeleteAsync(id);
		}

	}
}
