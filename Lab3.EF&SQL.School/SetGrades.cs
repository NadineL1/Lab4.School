using Lab4.School.Data;
using Lab4.School.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.School
{
	internal class SetGrades
	{
		static internal void GradeStudent()
		{
			using var db = new SchoolDbContext();
			// begin a database transaction to ensure all operations are completed successfully
			// before comitting changes to the database
			using var transaction = db.Database.BeginTransaction();

			try
			{
				// Show students for user to chose from, and error handling on user input
				var students = db.Students.ToList();
				foreach (var student in students)
				{
					Console.WriteLine($"StudentID: [{student.Id}] Student name: {student.Fname} {student.Lname}");
				}

				bool validStudentInput = false;
				int studentId = 0;
				while(!validStudentInput)
				{
					Console.WriteLine("Chose student ID: ");

					if (!int.TryParse(Console.ReadLine(), out studentId))
					{
						Console.WriteLine("Invalid studentID.");
						continue;
					}
					
					if(!students.Any(s=>s.Id == studentId))
					{
						Console.WriteLine("Invalid studentID. Only chose from the list. ");
						continue;
					}
					validStudentInput = true;
				}

				// Show subjects for user to chose from, and error handling on user input
				var subjects = db.Subjects.ToList();
				foreach (var sub in subjects)
				{
					Console.WriteLine($"Subject ID[{sub.Id}] Subject Name: {sub.SubjectName}");
				}

				bool validSubjectInput = false;
				int subjectId = 0;

				while(!validSubjectInput)
				{
					Console.WriteLine("Chose subjectID");
					if (!int.TryParse(Console.ReadLine(), out subjectId))
					{
						Console.WriteLine("Invalid subjectID. ");
						continue;
					}

					if (!subjects.Any(s => s.Id == subjectId))
					{
						Console.WriteLine("Invalid subjectID. Only chose from the list. ");
						continue;
					}
					validSubjectInput = true;
				}
			

				// set grades matching the logic from database + error handling on user input
				Console.WriteLine($"Chose grade from the listed numbers: 10(A), 8(B), 6(C), 4(D), 2(E), 0(F) ");

				var validGrades = new List<int> { 10, 8, 6, 4, 2, 0 };

				int gradeValue;
				
				while(true)
				{
					if(!int.TryParse(Console.ReadLine(), out gradeValue))
					{
						Console.WriteLine("Invalid input. Only numbers are acceptable.");
						continue;
					}

					if(!validGrades.Contains(gradeValue))
					{
						Console.WriteLine("Invalid grade. Try again.");
						continue;
					}
					break;
				}

				// create the new grade with the date automatically set for today
				var grade = new Grade
				{
					StudentId = studentId,
					SubjectId = subjectId,
					GradeValue = gradeValue,
					GradeDate = DateOnly.FromDateTime(DateTime.Now)
				};

				// add grade to database
				db.Grades.Add(grade);	
				db.SaveChanges();

				// commit transaction
				transaction.Commit();
				Console.WriteLine("Grade successfully saved!");

			}
			// if transaction on grade saving was unsuccessful 
			catch (Exception ex)
			{
				transaction.Rollback();
				Console.WriteLine("Grade setting was unsuccesful.");
				Console.WriteLine(ex.Message);
			}
			Console.ReadKey();	
		}
	}
}
