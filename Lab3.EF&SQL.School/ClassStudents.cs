using Lab4.School.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.School
{
	internal class ClassStudents
	{
		static internal void ShowClassStudents()
		{
			using var db = new SchoolDbContext();
			Console.WriteLine("Classes:");
			var classes = db.Classes.ToList();
			foreach (var c in classes)
			{
				Console.WriteLine($"ID: {c.Id}||Classname: {c.ClassName}");
			}

			Console.Write("Write the id of the class list you want to access: ");

			if (!int.TryParse(Console.ReadLine(), out int Id))
			{
				Console.WriteLine("Invalid choice.");
				return;
			}

			var selectedClass = db.Classes
				.Include(c => c.Students)
				.FirstOrDefault(c => c.Id == Id);


			if (selectedClass == null)
			{
				Console.WriteLine("Invalid. start again.");
				return;
			}
			Console.WriteLine($"Students in {selectedClass.ClassName}");
			foreach (var s in selectedClass.Students)
			{
				Console.WriteLine($"ID: {s.Id}||Firstname: {s.Fname}||Lastname: {s.Lname}");
			}

			Console.WriteLine("Press any key to return to main menu.");
			Console.ReadKey();


		}
	
	

	}
}
