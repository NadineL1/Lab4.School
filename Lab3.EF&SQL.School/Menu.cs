using Lab4.School.Models;
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
				Console.WriteLine("[3] Enroll new student.");
				Console.WriteLine("[4] View list of employees.");
				Console.WriteLine("[5] Add newly hired employee.");
				Console.WriteLine("[6] Exit menu.");

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
						AddStudent.AddNewStudent();
						break;
					case "4":
						ListEmployee.ListOfEmployees();
						break;
					case "5":
						AddEmployee.AddNewEmployee();
						break;
					case "6":
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
