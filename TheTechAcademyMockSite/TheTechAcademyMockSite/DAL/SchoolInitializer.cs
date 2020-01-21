using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TheTechAcademyMockSite.Models;

namespace TheTechAcademyMockSite.DAL
{

	public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
	{
		protected override void Seed(SchoolContext context)
		{
			var students = new List<Student>
		{
		new Student{FirstMidName="Jack",LastName="Stanley",EnrollmentDate=DateTime.Parse("2005-09-01")},
		new Student{FirstMidName="Erik",LastName="Gross",EnrollmentDate=DateTime.Parse("2002-09-01")},
		new Student{FirstMidName="Patrick",LastName="McCrea",EnrollmentDate=DateTime.Parse("2003-09-01")},
		new Student{FirstMidName="Emily",LastName="Stanley",EnrollmentDate=DateTime.Parse("2002-09-01")},
		new Student{FirstMidName="Brett",LastName="Caudle",EnrollmentDate=DateTime.Parse("2002-09-01")},
		new Student{FirstMidName="Adam",LastName="Smith",EnrollmentDate=DateTime.Parse("2001-09-01")},
		new Student{FirstMidName="Briar",LastName="Wilette",EnrollmentDate=DateTime.Parse("2003-09-01")},
		new Student{FirstMidName="Jordan",LastName="Vanwyhe",EnrollmentDate=DateTime.Parse("2005-09-01")}
		};

			students.ForEach(s => context.Students.Add(s));
			context.SaveChanges();
			var courses = new List<Course>
		{
		new Course{CourseID=1050,Title="Overview of Software Development",Credits=3,},
		new Course{CourseID=4022,Title="HTML & CSS",Credits=3,},
		new Course{CourseID=4041,Title="JavaScript",Credits=3,},
		new Course{CourseID=1045,Title="Database & SQL",Credits=4,},
		new Course{CourseID=3141,Title="C# AND .NET FRAMEWORK",Credits=4,},
		new Course{CourseID=2021,Title="PYTHON",Credits=3,},
		new Course{CourseID=2042,Title="DATA SCIENCE",Credits=4,}
		};
			courses.ForEach(s => context.Courses.Add(s));
			context.SaveChanges();
			var enrollments = new List<Enrollment>
		{
		new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
		new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
		new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
		new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
		new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
		new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
		new Enrollment{StudentID=3,CourseID=1050},
		new Enrollment{StudentID=4,CourseID=1050,},
		new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
		new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
		new Enrollment{StudentID=6,CourseID=1045},
		new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
		};
			enrollments.ForEach(s => context.Enrollments.Add(s));
			context.SaveChanges();
		}
	}
}
