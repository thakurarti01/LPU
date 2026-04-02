using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs;

namespace Application.Interfaces
{
	public interface IMenuService
	{
		Task<IEnumerable<MenuItemDto>> GetAllAsync();
		Task<MenuItemDto> GetByIdAsync(int id);
		Task AddAsync(CreateMenuItemDto dto);
		Task UpdateAsync(int id, UpdateMenuItemDto dto);
		Task DeleteAsync(int id);
	}
}
