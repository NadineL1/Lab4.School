using Lab4.School.Data;
using Lab4.School.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.School
{
	internal class CountEmployees
	{
		static internal void CountNumberofEmployees()
		{
			using var db = new SchoolDbContext();


			// group staff based by rolename, project the result into an anonymous object
			// containing role name(group key) and groupcount(number of employees)
			var allStaff = db.Staff
				.GroupBy(s => s.Role.Rname)
				.Select(g => new 
				{
					RoleName = g.Key,
					Count =g.Count()
				})
				.ToList();
				
			//print out each role with its employee count 
			foreach (var nr in allStaff)
			{
				Console.WriteLine($"{nr.RoleName}: {nr.Count}");
			}
			Console.ReadKey();
		}
	}
}
