using Lab4.School.Data;

namespace Lab4.School
{
	internal class AddEmployee
	{
		public static void AddNewEmployee()
		{
			Console.WriteLine("Add Employee");
			using var db = new SchoolDbContext();
			var employeerole = db.StaffRoles.ToList();
			employeerole.ForEach(sr => Console.WriteLine(sr.Id + " " + sr.Rname));

			if (employeerole.Count < 1)
			{
				Console.WriteLine("EmployeeRoles do not exist yet, please update database to continue.");
			}

			Console.WriteLine("Chose the role-id for the hired employee: ");
			if (!int.TryParse(Console.ReadLine(), out int selectedRoleId))
			{
				Console.WriteLine("Invalid id.");
				Console.ReadKey();
				return;
			}

			var selectedRole = db.StaffRoles.FirstOrDefault(sr => sr.Id == selectedRoleId);
			if (selectedRole == null)
			{
				Console.WriteLine("No role with this id exists!");
				Console.ReadKey();
				return;
			}

			// get employee information from user
			Console.WriteLine("First name: ");
			string fName = Console.ReadLine();
			while (string.IsNullOrEmpty(fName))
			{
				Console.WriteLine("Please insert the first name of the employee. This field cannot be empty.");
				fName = Console.ReadLine();
			}
			Console.WriteLine("Last name: ");
			string lName = Console.ReadLine();
			while (string.IsNullOrEmpty(lName))
			{
				Console.WriteLine("Please insert the first name of the employee. This field cannot be empty.");
				lName = Console.ReadLine();
			}

			// create employee with user input
			var newEmployee = new Models.Staff()
			{
				Fname = fName,
				Lname = lName,
				RoleId = selectedRoleId
			};
			db.Staff.Add(newEmployee);
			db.SaveChanges();

			Console.WriteLine($"Staff member {fName} {lName} added to staff list in role {selectedRole.Rname}.");
			Console.ReadKey();

		}
	}
}
