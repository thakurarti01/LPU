using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuController : ControllerBase
	{
		private readonly IMenuService _menuService;

		public MenuController(IMenuService menuService)
		{
			_menuService = menuService;
		}
		// GET: api/<MenuController>
		[HttpGet]
		public async Task<ActionResult> GetAll()
		{
			var items = await _menuService.GetAllAsync();
			return Ok(items);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var item = await _menuService.GetByIdAsync(id);

			if (item == null)
			{
				return NotFound();
			}
			return Ok(item);
		}

		[HttpPost]
		public async Task<IActionResult>Create(CreateMenuItemDto dto)
		{
			await _menuService.AddAsync(dto);
			return Ok("Created Successfully");
		}

		[HttpPut("{id}")]
		public async Task<IActionResult>Update(int id, UpdateMenuItemDto dto)
		{
			await _menuService.UpdateAsync(id, dto);
			return Ok("Updated Successfully");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _menuService.DeleteAsync(id);
			return Ok("Deleted successfully");
		}

	}
}
