using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystem.Controllers
{
	public class DashboardController : Controller
	{
		// Teacher Dashboard
		public IActionResult TeacherDashboard()
		{
			return View();
		}

		// Student Dashboard
		public IActionResult StudentDashboard()
		{
			return View();
		}
	}
}