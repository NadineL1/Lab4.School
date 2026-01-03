using Lab3.EF_SQL.School;
using Lab4.School.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Lab4.School
{
	internal class Menu
	{
		public static void SchoolMenu()
		{
			bool isRunning = true;
			while (isRunning)
			{
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Chax Academy school platform.");

				Console.WriteLine("[1] View list of all students.");
				Console.WriteLine("[2] Get a list of students in a specific class.");
				Console.WriteLine("[3] Show all student information.");
				Console.WriteLine("[4] Enroll new student.");
				Console.WriteLine("[5] Grade student.");
				Console.WriteLine("[6] Show all classes");
				Console.WriteLine("[7] View list of employees.");
				Console.WriteLine("[8] Add newly hired employee.");
				Console.WriteLine("[9] Show amount of personnel in each role.");
				Console.WriteLine("[10] Exit menu.");

				string? choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						StudentSort.SortStudents();
						break;
					case "2":
						ClassStudents.ShowClassStudents();
						break;
					case "3":
						//show student all information
						ShowALLStudentInfo.Show();
						break;
					case "4":
						AddStudent.AddNewStudent();
						break;
					case "5":
						//grade student - UserAssertion transactions ifall något går fel?
						SetGrades.GradeStudent();
						break;
					case "6":

						//show all active classes 
						ShowActiveCourses.ShowCourse();
						break;
					case "7":
						ListEmployee.ListOfEmployees();
						break;
					case "8":
						AddEmployee.AddNewEmployee();
						break;
					case "9":

						// show ammount of personel in each role
						CountEmployees.CountNumberofEmployees();
						break;
					case "10":
						Console.WriteLine("Press any key to exit menu.");
						Console.ReadKey();
						isRunning = false;
						break;
					default:
						Console.WriteLine("Invalid choice. Please restart and only answer with the number associated with your requested action.");
						break;
				
				}

			}
		}
		 
	}
}
