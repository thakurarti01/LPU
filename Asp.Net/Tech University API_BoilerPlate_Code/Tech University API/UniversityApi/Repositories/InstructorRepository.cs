using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.Interfaces;
using UniversityApi.Models;

namespace UniversityApi.Repositories
{
    public class InstructorRepository : IInstructor
    {
        // Implement your code here
        private readonly UniversityContext _context;
        public InstructorRepository(UniversityContext context)
        {
            _context = context;
        }

        public bool AddInstructor(Instructor instructor)
        {
            var existInstructor = _context.Instructors.Any(i => i.InstructorId == instructor.InstructorId);
            if(existInstructor != null)
            { 
                return false;
            }
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
            return true;
        }

		public IEnumerable<Instructor> GetInstructorsWithCourseCountAbove(int count)
		{
			return _context.Instructors
				.Where(i => i.InstructorCourses.Count() > count)
				.ToList();
		}

		public IEnumerable<Instructor> GetInstructorsWithMostEnrollments()
        {
            var instructorWithCounts = _context.Instructors.Select(i => new
            {
                Instructor = i,
                EnrollmentCount = i.InstructorCourses.SelectMany(ic => ic.Course.Enrollments).Count()
            }).ToList();

            var maxCount = instructorWithCounts.Max(i => i.EnrollmentCount);
            return instructorWithCounts.Where(i => i.EnrollmentCount == maxCount).Select(i => i.Instructor);
        }
	}
}
