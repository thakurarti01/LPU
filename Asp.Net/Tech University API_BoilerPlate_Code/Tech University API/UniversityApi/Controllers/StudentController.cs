using Microsoft.AspNetCore.Mvc;
using UniversityApi.Interfaces;
using UniversityApi.Models;
using UniversityApi.Repositories;

namespace UniversityApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly IStudent studentRepository;

		public StudentController(IStudent studentRepository)
		{
			this.studentRepository = studentRepository;
		}

		// DELETE: api/Student/DeleteStudent/1
		[HttpDelete("DeleteStudent/{studentId}")]
		public IActionResult Delete(int studentId)
		{
			var res = studentRepository.DeleteStudent(studentId);

			if (!res)
			{
				return BadRequest("Student not found");
			}

			return Ok("Student Deleted Successfully");
		}

		// GET: api/Student/ByCourseTitle/Math
		[HttpGet("ByCourseTitle/{courseTitle}")]
		public IActionResult Get(string courseTitle)
		{
			var result = studentRepository.GetStudentsByCourseTitle(courseTitle);

			if (result != null && result.Any())
			{
				return Ok(result);
			}

			return NotFound("No students found for this course");
		}
	}
}