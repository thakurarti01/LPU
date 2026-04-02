using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
//using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
	public interface IMenuRepository
	{
		Task<IEnumerable<MenuItem>> GetAllAsync();
		Task<MenuItem> GetByIdAsync(int id);
		Task AddAsync(MenuItem menuItem);
		Task UpdateAsync(MenuItem menuItem);
		Task DeleteAsync(int id);
	}
}

