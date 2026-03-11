using System.Linq;
namespace FirstWebApiDemo.Models.Repos
{
	public class StudentRepo : IRepos<Student>
	{
		public static List<Student> studList = null;
		public StudentRepo()
		{
			if(studList == null)
			{
				studList = new List<Student>()
				{
					new Student(){RollNo=101, Name="Alok", City="Jalandhar",PhoneNo=456123987},
					new Student(){RollNo=102, Name="Riya", City="Ludhiana",PhoneNo=55662244},
					new Student(){RollNo=102, Name="Jatin", City="Amritsar",PhoneNo=123654789},
				};
			}
		}

		public bool Add(Student item)
		{
			bool flag = false;
			if (item != null)
			{
				studList.Add(item);
				flag = true;
			}
			return flag;
		}

		public Student Get(int id)
		{
			//if want to search on basis of primary key, use firstordefault otherwise use where in linq
			Student stud = studList.Find(s => s.RollNo == id);
			if (stud != null)
			{
				return stud;
			}
			else
			{
				throw new Exception("Student record not available");
			}
		}

		public ICollection<Student> GetAll()
		{
			return studList;
		}

		public bool Update(int id, Student currStudent)
		{
			bool flag = false;
			Student existStudent = studList.Find(s => s.RollNo == id);
			if(existStudent!=null && currStudent != null)
			{
				existStudent.Name = currStudent.Name;
				existStudent.City = currStudent.City;
				existStudent.PhoneNo = currStudent.PhoneNo;
				flag = true;
			}
			return flag;
		}

		public bool Delete(int id)
		{
			bool flag = false;
			Student existStudent = studList.Find(s => s.RollNo == id);
			if (existStudent != null)
			{
				studList.Remove(existStudent);
				flag = true;
			}
			return flag;
		}

	}
}
