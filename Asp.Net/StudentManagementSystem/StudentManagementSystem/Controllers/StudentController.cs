using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using System.Linq;

namespace StudentManagementSystem.Controllers
{
	public class StudentController : Controller
	{
		private readonly AppDbContext _context;

		public StudentController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index(string search)
		{
			var students = _context.Students
		.Include(s => s.Department)
		.Include(s => s.Course)
		.Where(s => search == null || s.StudentName.Contains(search))
		.ToList();

			return View(students);

		}

		public IActionResult Create()
		{
			ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
			ViewBag.Courses = new SelectList(_context.Courses, "CourseId", "CourseName");

			return View();
		}

		[HttpPost]
		public IActionResult Create(Student student)
		{
			_context.Students.Add(student);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Edit(int id)
		{
			var student = _context.Students.Find(id);

			ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
			ViewBag.Courses = new SelectList(_context.Courses, "CourseId", "CourseName");

			return View(student);
		}

		[HttpPost]
		public IActionResult Edit(Student student)
		{
			_context.Students.Update(student);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
			var student = _context.Students.Find(id);
			_context.Students.Remove(student);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}