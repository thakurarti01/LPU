using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityApi.Interfaces;
using UniversityApi.Models;
using UniversityApi.Repositories;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

	public class InstructorController : ControllerBase
	{
		private readonly IInstructor instructorRepository;

		public InstructorController(IInstructor instructorRepository)
		{
			this.instructorRepository = instructorRepository;
		}

		[HttpPost("AddInstructor")]
		public IActionResult AddInstructor([FromBody] Instructor instructor)
		{
			var res = instructorRepository.AddInstructor(instructor);

			if (!res)
			{
				return BadRequest();
			}
			return Ok("Instructor Added Successfully");
		}

		[HttpGet("WithCourseCountAbove/{count}")]
		public IActionResult WithCourseCountAbove(int count)
		{
			var result = instructorRepository.GetInstructorsWithCourseCountAbove(count);

			if (result != null && result.Any())
			{
				return Ok(result);
			}
			return NotFound();
		}

		[HttpGet("WithMostEnrollments")]
		public IActionResult WithMostEnrollments()
		{
			var result = instructorRepository.GetInstructorsWithMostEnrollments();

			if (result != null)
			{
				return Ok(result);
			}
			return NotFound();
		}
	}


}
