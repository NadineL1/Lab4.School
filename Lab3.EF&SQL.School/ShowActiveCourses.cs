using Lab4.School.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.School
{
	internal class ShowActiveCourses
	{
		internal static void ShowCourse()
		{
			using var db = new SchoolDbContext();
			Console.WriteLine("Active courses:");
			var subject = db.Subjects.ToList();

			if (subject.Any())
			{
				foreach (var s in subject)
				{
					Console.WriteLine($"ID: {s.Id}|| Course: {s.SubjectName}");
				}
			}
			else
			{
				Console.WriteLine("There are no active courses right now.");
			}

			Console.WriteLine("Press any key to return to main menu.");
			Console.ReadKey();
		}
	}
}
