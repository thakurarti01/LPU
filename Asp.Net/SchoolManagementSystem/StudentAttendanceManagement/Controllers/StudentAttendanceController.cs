using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAttendanceManagement.Models;

namespace StudentAttendanceManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentAttendanceController : ControllerBase
	{
		private static List<StudentAttendanceDetailsModel> attendanceList = new List<StudentAttendanceDetailsModel>
		{
			new StudentAttendanceDetailsModel {StudentId = 1, StudentName = "Alok", AttendancePercentage = 83.60},
			new StudentAttendanceDetailsModel {StudentId = 2, StudentName = "Riya", AttendancePercentage = 93.60},

		};

		//GET : api/StudentAttendance
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(attendanceList);
		}

		//GET : api/StudentAttendance/{id}
		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var student = attendanceList.FirstOrDefault(s => s.StudentId == id);
			if(student == null)
			{
				return NotFound();
			}
			return Ok(student);
		}

		// POST : api/StudentAttendance
		[HttpPost]
		public IActionResult Create([FromBody] StudentAttendanceDetailsModel model)
		{
			if(model == null)
			{
				return BadRequest("model is null");
			}
			//attendanceList.Add(model);
			return Ok(model);
		}

		//PUT : api/StudentAttendance/{id}
		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] StudentAttendanceDetailsModel model)
		{
			var student = attendanceList.FirstOrDefault(student => student.StudentId == id);
			if(id == null)
			{
				return NotFound();
			}
			student.StudentName = model.StudentName;
			student.AttendancePercentage = model.AttendancePercentage;

			return Ok(student);
		}

		//DELETE : api/StudentAttendance/{id}
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var student = attendanceList.FirstOrDefault(s => s.StudentId == id);
			if(student == null)
			{
				return NotFound();
			}
			attendanceList.Remove(student);
			return Ok();
		}
	}
}
