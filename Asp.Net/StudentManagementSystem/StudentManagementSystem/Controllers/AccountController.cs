using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using System.Linq;

namespace StudentManagementSystem.Controllers
{
	public class AccountController : Controller
	{
		private readonly AppDbContext _context;

		public AccountController(AppDbContext context)
		{
			_context = context;
		}

		// Register Page
		public IActionResult Register()
		{
			return View();
		}

		// Register POST
		[HttpPost]
		public IActionResult Register(User user)
		{
			if (ModelState.IsValid)
			{
				_context.Users.Add(user);
				_context.SaveChanges();
				return RedirectToAction("Login");
			}

			return View(user);
		}

		// Login Page
		public IActionResult Login()
		{
			return View();
		}

		// Login POST
		[HttpPost]
		public IActionResult Login(string email, string password)
		{
			var user = _context.Users
				.FirstOrDefault(u => u.Email == email && u.Password == password);

			if (user == null)
			{
				ViewBag.Message = "Invalid Email or Password";
				return View();
			}

			if (user.Role == "Teacher")
				return RedirectToAction("TeacherDashboard", "Dashboard");

			return RedirectToAction("StudentDashboard", "Dashboard");
		}

		public IActionResult Logout()
		{
			return RedirectToAction("Login");
		}
	}
}