using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.Interfaces;
using UniversityApi.Models;
using System.Linq;

namespace UniversityApi.Repositories
{
	public class StudentRepository : IStudent
	{
		private readonly UniversityContext _context;

		public StudentRepository(UniversityContext context)
		{
			_context = context;
		}

		public bool DeleteStudent(int studentId)
		{
			var existStudent = _context.Students
				.FirstOrDefault(s => s.StudentId == studentId);

			if (existStudent == null)
			{
				return false;
			}

			_context.Students.Remove(existStudent);
			_context.SaveChanges();
			return true;
		}

		public IEnumerable<Student> GetStudentsByCourseTitle(string courseTitle)
		{
			return _context.Students
				.Where(s => s.Enrollments
					.Any(e => e.Course.Title == courseTitle))
				.ToList();
		}
	}
}