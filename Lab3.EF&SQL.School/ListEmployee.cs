using Lab4.School.Data;
using Lab4.School.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.School
{
	internal class ListEmployee
	{
		static internal void ListOfEmployees()
		{
			Console.WriteLine("List of Employees");
			Console.WriteLine("What employees do you want to see?");
			Console.WriteLine("[1] All employees.");
			Console.WriteLine("[2] Show only employees in specific role.");

			var choice = Console.ReadLine();

			using var db = new SchoolDbContext();

			switch (choice)
			{
				case "1":
					var allStaff = db.Staff
						.Include(s => s.Role)
						.ToList();
					foreach (var s in allStaff)
					{
						Console.WriteLine($"ID: {s.Id}||Firstname: {s.Fname}||Lastname: {s.Lname}||{s.Role.Rname} ");
					}
					break;
				case "2":
					Console.WriteLine("Write the id of the list you want to acess: ");
					var roles = db.StaffRoles.ToList();

					foreach (var role in roles)
					{
						Console.WriteLine($"[{role.Id}] {role.Rname}");
					}

					if(!int.TryParse(Console.ReadLine(), out int chosenId))
					{						
						Console.WriteLine("Invalid choice."); 
						return;
					}

					var selectedRole = db.StaffRoles
						.Include(r => r.Staff)
						.FirstOrDefault(r => r.Id == chosenId);

					if (selectedRole == null)
					{
						Console.WriteLine("Invalid, try again.");
						return;
					}

					foreach (var s in selectedRole.Staff)
					{
						Console.WriteLine($"ID: {s.Id}||Firstname:{s.Fname}||Lastname: {s.Lname}||Role: {selectedRole.Rname} ");
					}
					break;
				default:
					Console.WriteLine("Invalid choice.");
					break;
			}


			Console.WriteLine("Press any key to return to main menu.");
			Console.ReadKey();
		}
	}
}
