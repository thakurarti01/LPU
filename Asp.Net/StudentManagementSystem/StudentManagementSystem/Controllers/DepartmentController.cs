using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using System.Linq;

namespace StudentManagementSystem.Controllers
{
	public class DepartmentController : Controller
	{
		private readonly AppDbContext _context;

		public DepartmentController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var departments = _context.Departments.ToList();
			return View(departments);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Department dept)
		{
			_context.Departments.Add(dept);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Edit(int id)
		{
			var dept = _context.Departments.Find(id);
			return View(dept);
		}

		[HttpPost]
		public IActionResult Edit(Department dept)
		{
			_context.Departments.Update(dept);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
			var dept = _context.Departments.Find(id);
			_context.Departments.Remove(dept);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}