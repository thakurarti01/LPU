using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAdmissionManagement.Models;

namespace StudentAdmissionManagement.Controllers
{
	[Route("api/[controller]")]
	//[Route("api/student")]
	[ApiController]
	public class StudentAdmissionController : ControllerBase
	{
		[HttpGet]
		public IEnumerable<StudentAdmissionDetailsModel> Get()
		{
			var obj1 = new StudentAdmissionDetailsModel { StudentId = 1, StudentName = "Alok", StudentClass = "X", DateOfJoining = DateTime.Now };
			var obj2 = new StudentAdmissionDetailsModel { StudentId = 2, StudentName = "Riya", StudentClass = "IX", DateOfJoining = DateTime.Now };
			return new List<StudentAdmissionDetailsModel> { obj1, obj2 };
		}

		//[HttpGet("test")]
		//public IActionResult Test()
		//{
		//	return Ok("Test working");
		//}
	}
}
