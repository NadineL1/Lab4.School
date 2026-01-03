using Lab4.School.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace Lab4.School
{
	internal class ShowALLStudentInfo
	{
		internal static void Show()
		{
			using var db = new SchoolDbContext();

			//make a list with all students and their respective class, grades, and gradesubject
			var students = db.Students
				.Include(s => s.Class)
				.Include(s => s.Grades)
					.ThenInclude(g=> g.Subject)
				.ToList();

			foreach ( var student in students )
			{
				Console.WriteLine($"Student: {student.Fname} {student.Lname} Class: {student.Class.ClassName}.");

				// if the student has grades, print them out
				if (student.Grades.Any())
				{
					Console.WriteLine("Grades:");
					foreach( var grade in student.Grades)
					{
						Console.WriteLine($"{grade.Subject.SubjectName}: {grade.GradeValue}");

					}
				}
				else
				{
					Console.WriteLine("Student has no grades yet.");
				}
				Console.WriteLine("------");
			}

			Console.ReadKey();
		}
	}
}
