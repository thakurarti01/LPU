using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using System.Linq;

namespace StudentManagementSystem.Controllers
{
	public class CourseController : Controller
	{
		private readonly AppDbContext _context;

		public CourseController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var courses = _context.Courses.Include(c => c.Department).ToList();
			return View(courses);
		}

		public IActionResult Create()
		{
			ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
			return View();
		}

		[HttpPost]
		public IActionResult Create(Course course)
		{
			_context.Courses.Add(course);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Edit(int id)
		{
			var course = _context.Courses.Find(id);
			ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
			return View(course);
		}

		[HttpPost]
		public IActionResult Edit(Course course)
		{
			_context.Courses.Update(course);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
			var course = _context.Courses.Find(id);
			_context.Courses.Remove(course);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}