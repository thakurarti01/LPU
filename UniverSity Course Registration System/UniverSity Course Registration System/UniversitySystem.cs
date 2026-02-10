using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Course_Registration_System
{
    // =========================
    // University System Class
    // =========================
    public class UniversitySystem
    {
        public Dictionary<string, Course> AvailableCourses { get; private set; }
        public Dictionary<string, Student> Students { get; private set; }

        public UniversitySystem()
        {
            AvailableCourses = new Dictionary<string, Course>();
            Students = new Dictionary<string, Student>();
        }

        public void AddCourse(string code, string name, int credits, int maxCapacity = 50, List<string> prerequisites = null)
        {
            // TODO:
            // 1. Throw ArgumentException if course code exists
            if (AvailableCourses.ContainsKey(code))
            {
                throw new ArgumentException("course already exits");
            }
            Course obj = new Course(code, name, credits, maxCapacity, prerequisites);
            AvailableCourses.Add(code, obj);
            // 2. Create Course object
            // 3. Add to AvailableCourses
            // throw new NotImplementedException();
        }

        public void AddStudent(string id, string name, string major, int maxCredits = 18, List<string> completedCourses = null)
        {
            // TODO:
            // 1. Throw ArgumentException if student ID exists
            if (Students.ContainsKey(id))
            {
                throw new ArgumentException("student already exits");
            }
            Student studObj = new Student(id, name, major, maxCredits, completedCourses);
            Students.Add(id, studObj);
            // 2. Create Student object
            // 3. Add to Students dictionary
            // throw new NotImplementedException();
        }

        public bool RegisterStudentForCourse(string studentId, string courseCode)
        {
            // TODO:
            // 1. Validate student and course existence
            if(!Students.ContainsKey(studentId) || !AvailableCourses.ContainsKey(courseCode))
            {
                return false;
            }
            Student studObj = Students[studentId];
            Course obj = AvailableCourses[courseCode];

            return studObj.AddCourse(obj);
            
            // 2. Call student.AddCourse(course)
            // 3. Display meaningful messages
            // throw new NotImplementedException();
        }

        public bool DropStudentFromCourse(string studentId, string courseCode)
        {
            // TODO:
            // 1. Validate student existence
            if (!Students.ContainsKey(studentId))
            {
                return false;
            }
            Students[studentId].DropCourse(courseCode);
            return true;
            // 2. Call student.DropCourse(courseCode)
            // throw new NotImplementedException();
        }

        public void DisplayAllCourses()
        {
            // TODO:
            // Display course code, name, credits, enrollment info
            foreach(var course in AvailableCourses.Values)
            {
                Console.WriteLine($"{course.CourseCode}, {course.CourseName}, {course.Credits}, {course.GetEnrollmentInfo()}");
            }
            // throw new NotImplementedException();
        }

        public void DisplayStudentSchedule(string studentId)
        {
            // TODO:
            // Validate student existence
            if (!Students.ContainsKey(studentId))
            {
                return;
            }
            Students[studentId].DisplaySchedule();
            // Call student.DisplaySchedule()
            // throw new NotImplementedException();
        }

        public void DisplaySystemSummary()
        {
            // TODO:
            // Display total students, total courses, average enrollment
            int totalStudents = Students.Count;
            int totalCourses = AvailableCourses.Count;

            double avgEnrollment = totalCourses == 0 ? 0 : AvailableCourses.Values.Average(c => int.Parse(c.GetEnrollmentInfo().Split('/')[0]));

            Console.WriteLine($"Students: {totalStudents}, Courses: {totalCourses}, Avg Enrollment: {avgEnrollment}");
            // throw new NotImplementedException();
        }
    }
}
