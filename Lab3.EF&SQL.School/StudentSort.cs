using Lab4.School.Data;
using Lab4.School.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.School
{
	internal class StudentSort
	{
		static internal void SortStudents()
		{
			Console.WriteLine("Sort the list of students by....");
			Console.WriteLine("[1] By last name, A-Ö. ");
			Console.WriteLine("[2] By last name, Ö -A.");
			Console.WriteLine("[3] By first name, A-Ö.");
			Console.WriteLine("[4] By first name, Ö-A.");
			Console.WriteLine("Choice: ");
			var choice = Console.ReadLine();

			using var db = new SchoolDbContext();
			List<Student> students;

			switch (choice)
			{
				case "1":
					students = db.Students.OrderBy(s => s.Lname).ToList();
					break;
				case "2":
					students = db.Students.OrderByDescending(s => s.Lname).ToList();
					break;
				case "3":
					students = db.Students.OrderBy(s=>s.Fname).ToList();
					break;
				case "4":
					students = db.Students.OrderByDescending(s => s.Fname).ToList();
					break;
				default:
					Console.WriteLine("Invalid input. Default list will be presented");
					students = db.Students.ToList();
					break;
			}

			Console.WriteLine("List of students");
			foreach (var s in students)
			{
				Console.WriteLine($"ID: {s.Id}||Firstname: {s.Fname}||Lastname: {s.Lname} ");
			}

			Console.ReadKey();
		}
	}
}
