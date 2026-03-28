using UniversityApi.Data;
using UniversityApi.Interfaces;
using UniversityApi.Models;

namespace UniversityApi.Repositories
{
    public class CourseRepository : ICourse
    {
       // Implement your code here
        private readonly UniversityContext _context;
        public CourseRepository(UniversityContext context)
        {
            _context = context;
        }

        public bool UpdateCourse(Course course)
        {
            var existCourse = _context.Courses.FirstOrDefault(c => c.CourseId == course.CourseId);
            if(existCourse != null)
            {
                existCourse.Title = course.Title;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Course> GetCoursesWithEnrollmentsAboveGrade(int grade)
        {
            return _context.Courses.Where(c => c.Enrollments.Any(e => e.Grade > grade)).ToList();
        }

		public IEnumerable<Course>GetCoursesByInstructorName(string instructorName)
        {
			return _context.Courses
				.Where(c => c.InstructorCourses.Any(ic => ic.Instructor.Name == instructorName))
				.ToList();
		}

	}
}
