using Lab4.School.Data;
using Lab4.School.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.School
{
	internal class AddStudent
	{
		static internal void AddNewStudent()
		{
			Console.WriteLine("Add student");

			using var db = new SchoolDbContext();

			// print out list of classes for user to chose from, to enroll student into
			var classes = db.Classes.ToList();
			classes.ForEach(c => Console.WriteLine(c.Id +" "+ c.ClassName));

			// IF we dont have any Class in database
			if (classes.Count < 1)
			{
				Console.WriteLine("No Class exists yet. Update database to be able to add students.");
			}

			Console.WriteLine("Chose class for student by Id: ");
			if (!int.TryParse(Console.ReadLine(), out int selectedClassId))
			{
				Console.WriteLine("Invalid Id.");
				Console.ReadKey();
				return;
			}
			var selectedClass = db.Classes.FirstOrDefault(c => c.Id == selectedClassId);
			if (selectedClass == null)
			{
				Console.WriteLine("No class with that id exists!");
				Console.ReadKey();
				return;
			}

			// get student information from user
			Console.Write("Firstname: ");
			string fName = Console.ReadLine();
			while (string.IsNullOrEmpty(fName))
			{
				Console.WriteLine("Try again. Write the students firstname: ");
				fName = Console.ReadLine();
			}

			Console.Write("Lastname: ");
			string lName = Console.ReadLine();
			while (string.IsNullOrEmpty(lName))
			{
				Console.WriteLine("Try again. Write the students lastname: ");
				lName = Console.ReadLine();
			}

			Console.Write("Personal number: ");
			string Personalnumber = Console.ReadLine();
			while (string.IsNullOrEmpty(Personalnumber))
			{
				Console.WriteLine("Try again. Write the students personal number: ");
				Personalnumber = Console.ReadLine();
			}

			DateOnly birthdate;
			// birthday from string input to DateOnly error handling
			while (true)
			{
				Console.WriteLine("Birthday (YYMMDD): ");
				string stringBirthdate = Console.ReadLine();

				if (string.IsNullOrEmpty(stringBirthdate))
				{
					Console.WriteLine("Please provide input. Birthdate YYMMDD: ");
					continue;
				}
				if (DateOnly.TryParseExact(stringBirthdate, "yyMMdd", out birthdate))
				{
					break;
				}
				Console.WriteLine("Invalid format, please use YYMMDD.");
			}

			Console.Write("Phonenumber: ");
			string  phNumber= Console.ReadLine();
			while (string.IsNullOrEmpty(phNumber))
			{
				Console.WriteLine("Try again. Write the students phonenumber ");
				phNumber = Console.ReadLine();
			}

			// create a new student using all of the userinput
			var newStudent = new Models.Student()
			{
				Fname = fName,
				Lname = lName,
				PersonalNumber = Personalnumber,
				Birthdate = birthdate,
				PhoneNumber = phNumber,
				ClassId = selectedClassId,
			};
			// add new student to database
			db.Students.Add(newStudent);
			db.SaveChanges();
			
			Console.WriteLine($"Student {fName} {lName} enrolled in class {selectedClass.ClassName}.");
			Console.ReadKey();
		}
	}
}
