using Microsoft.EntityFrameworkCore;
using Spectre.Console;
using System.Data;
using System.Reflection;

namespace CampSleepAwayAJA
{
	public class ManageDatabase
	{
		public static void AddCounselor()
		{
			using var context = new CSAContext();
			string firstName = ValidateString("Enter first name: ");
			string lastName = ValidateString("Enter last name: ");
			string address = ValidateString("Enter address: ");
			string phoneNumber = ValidateString("Enter phone number: ");
			string email = ValidateString("Enter email: ");
			var counselor = new Counselor
			{
				FirstName = firstName,
				LastName = lastName,
				ContactInfo = new ContactInfo
				{
					Address = address,
					PhoneNumber = phoneNumber,
					EmailAddress = email,
					Role = "Counselor"
				}
			};
			context.Counselors.Add(counselor);
			Console.WriteLine("Counselor added.");
			Console.ReadKey();
			context.SaveChanges();
		}
		public static void UpdateCounselor()
		{
			using var context = new CSAContext();
			var counselors = context.Counselors.Select(c => c.FullName).ToList();
			var choices = counselors.Concat(new[] { "Back" });
			var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
				.Title("Choose counselor to update")
				.AddChoices(choices)
				.UseConverter(s => s.ToUpperInvariant()));
			var counselor = context.Counselors.Include(c => c.ContactInfo).Where(c => c.FirstName + " " + c.LastName == menu).FirstOrDefault();
			if (counselors.Count() == 0)
			{
				Console.WriteLine("No counselors available.");
			}
			else if (menu.Contains("Back"))
			{
				return;
			}
			var menu2 = AnsiConsole.Prompt(new SelectionPrompt<string>()
				.Title("What would you like to update?")
				.AddChoices(new[] { "Name", "Address", "Phone Number", "Email", "Abort" })
				.UseConverter(s => s.ToUpperInvariant()));
			if (menu2.Contains("Name"))
			{
				string firstName = ValidateString("Enter new first name: ");
				string lastName = ValidateString("Enter new last name: ");
				counselor.FirstName = firstName;
				counselor.LastName = lastName;
			}
			else if (menu2.Contains("Address"))
			{
				string address = ValidateString("Enter new address: ");
				counselor.ContactInfo.Address = address;
			}
			else if (menu2.Contains("Phone Number"))
			{
				string phoneNumber = ValidateString("Enter new phone number: ");
				counselor.ContactInfo.PhoneNumber = phoneNumber;
			}
			else if (menu2.Contains("Email"))
			{
				string email = ValidateString("Enter new email: ");
				counselor.ContactInfo.EmailAddress = email;

			}
			else if (menu2.Contains("Abort"))
			{
				ManageConsole.MainMenu();
			}

			Console.WriteLine("Counselor updated.");
			Console.ReadKey();
			context.SaveChanges();
		}
		public static void RemoveCounselor()
		{
			using var context = new CSAContext();
			var counselors = context.Counselors.Select(c => c.FullName).ToList();
			var choices = counselors.Concat(new[] { "Back" });
			var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
				.Title("Choose counselor to remove")
				.AddChoices(choices)
				.UseConverter(s => s.ToUpperInvariant()));
			var counselor = context.Counselors.Where(c => c.FirstName + " " + c.LastName == menu).FirstOrDefault();
			if (counselors.Count() == 0)
			{
				Console.WriteLine("No counselors available.");
				Console.ReadKey();
				return;
			}
			var menu2 = AnsiConsole.Prompt(new SelectionPrompt<string>()
				.Title("Are you sure you want to remove this counselor?")
				.AddChoices(new[] { "Yes", "No" })
				.UseConverter(s => s.ToUpperInvariant()));
			if (menu2.Contains("No"))
			{
				return;
			}
			else if (menu2.Contains("Yes"))
			{
				var cabins = context.Cabins.Where(c => c.CounselorID == counselor.CounselorID);
				foreach (var cabin in cabins)
				{
					cabin.CounselorID = null;
				}
				context.Counselors.Remove(counselor);
				Console.WriteLine("Counselor removed.");
				Console.ReadKey();

			}
			context.SaveChanges();
		}
		public static void AddCabin()
		{
			Console.Clear();
			while (true)
			{
				using var context = new CSAContext();
				Console.WriteLine("Enter cabin name");
				string cabinName = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(cabinName))
				{
					Console.WriteLine("Name can not be empty.");
				}
				else
				{
					var cabin = new Cabin
					{
						CabinName = cabinName,
						CabinCapacity = 4
					};
					context.Cabins.Add(cabin);

					Console.WriteLine("Cabin added.");
					Console.ReadKey();
					context.SaveChanges();
					break;
				}
			}
		}
		public static void UpdateCabin()
		{
			using var context = new CSAContext();
			var cabins = context.Cabins.Select(c => c.CabinName).ToList();
			var choices = cabins.Concat(new[] { "Back" });
			if (cabins.Count() == 0)
			{
				Console.WriteLine("No cabins available.");
				Console.ReadKey();
				return;
			}
			var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
				.Title("Choose cabin to update")
				.AddChoices(choices)
				.UseConverter(s => s.ToUpperInvariant()));
			var cabin = context.Cabins.Where(c => c.CabinName == menu).FirstOrDefault();
			var menu2 = AnsiConsole.Prompt(new SelectionPrompt<string>()
			 .Title("What would you like to update? ")
			 .AddChoices(new[] { "Cabin name", "Cabin leader", "Abort update" })
			 .UseConverter(s => s.ToUpperInvariant()));

			if (menu2.Contains("Cabin name"))
			{
				string cabinName = ValidateString("Enter new cabin name: ");
				cabin.CabinName = cabinName;
			}

			else if (menu2.Contains("Cabin leader"))
			{
				var counselors = context.Counselors.Select(c => c.FullName).ToList();
				if (counselors.Count() == 0)
				{
					Console.WriteLine("No counselors available.");
					Console.ReadKey();
					return;
				}
				var menu3 = AnsiConsole.Prompt(new SelectionPrompt<string>()
				 .Title("Choose cabin leader")
				 .AddChoices(counselors)
				 .UseConverter(s => s.ToUpperInvariant()));
				var counselor = context.Counselors.Where(c => c.FirstName + " " + c.LastName == menu3).FirstOrDefault();
				cabin.CounselorID = counselor.CounselorID;
			}
			else if (menu2.Contains("Abort update"))
			{
				ManageConsole.MainMenu();
			}
			Console.WriteLine("Cabin updated.");
			Console.ReadKey();
			context.SaveChanges();
		}
		public static void AddCamperToCabin()
		{
			using var context = new CSAContext();

			var cabins = context.Cabins.Select(c => new { c.CabinID, c.CabinName }).ToDictionary(c => c.CabinID, c => c.CabinName);
			List<string> choices = new();
			

			foreach (var c in cabins)
			{
				choices.Add($"{c.Key.ToString()}: {c.Value.ToString()}");

			}
			choices.Concat(new[] { "Abort" });

			var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
				.Title("Choose cabin to add campers to")
				.AddChoices(choices)
				.UseConverter(s => s.ToUpperInvariant()));
			int choice = int.Parse(menu.Split(':').First());
			var cabin = context.Cabins.Include(c => c.Campers).FirstOrDefault(c => c.CabinID == choice);
			if (menu.Contains("Abort"))
			{
				return;
			}
			if (cabin.Campers?.Count() >= cabin.CabinCapacity)
			{
				Console.WriteLine("Maximum cabin capacity reached.");
				Console.ReadKey();
				return;
			}
			else if (cabin.Counselor == null)
			{
                Console.WriteLine("Cabin has no counselor.");
                Console.ReadKey();
                return;
            }
			var campers = context.Campers.Select(c => c.FullName).ToList();

			var choices2 = campers.Concat(new[] { "Abort" });
			if (campers.Count() == 0)
			{
				Console.WriteLine("No campers available.");
				Console.ReadKey();
				return;
			}
			var menu2 = AnsiConsole.Prompt(new MultiSelectionPrompt<string>()
				.Title("Choose camper(s) to add to cabin:")
				.PageSize(10)
				.MoreChoicesText("[grey](Move up and down to reveal more campers)[/]")
				.AddChoices(choices2));

			int insertcount = cabin.CabinCapacity - cabin.Campers.Count();
			if (insertcount > menu2.Count()) insertcount = menu2.Count();

			for (int i = 0; i < insertcount; i++)
			{
				var camper = context.Campers.FirstOrDefault(c => c.FirstName + " " + c.LastName == menu2[i]);
				if (camper.CabinID == cabin.CabinID)
				{
					Console.WriteLine($"{camper.FullName} is already in to {cabin.CabinName}.");
					Console.ReadKey();
				}
				else
				{
					cabin.Campers?.Add(camper);
					camper.CabinID = cabin.CabinID;
					Console.WriteLine($"{camper.FullName} added to {cabin.CabinName}.");
				}
			}
			for (int i = insertcount; i < menu2.Count(); i++)
			{
				Console.WriteLine($"{menu2[i]} was not added to {cabin.CabinName}.");
			}
			Console.ReadKey();

			if (menu2.Contains("Abort"))
			{
				ManageConsole.MainMenu();
			}
			context.SaveChanges();
		}
		public static void RemoveCabin()
		{
			using var context = new CSAContext();
			//var cabins = context.Cabins.Select(c => c.CabinName).ToList();
			// var choices = cabins.Concat(new[] { "Abort" });

			var cabins = context.Cabins.Select(c => new { c.CabinID, c.CabinName }).ToDictionary(c => c.CabinID, c => c.CabinName);
			List<string> choices = new();

			foreach (var c in cabins)
			{
				choices.Add($"{c.Key.ToString()}: {c.Value.ToString()}");

			}
			if (cabins.Count() == 0)
			{
				Console.WriteLine("No cabins available.");
				Console.ReadKey();
				return;
			}
			choices.Concat(new[] { "Abort" });

			var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
				.Title("Choose cabin to add campers to")
				.AddChoices(choices)
				.UseConverter(s => s.ToUpperInvariant()));
			int choice = int.Parse(menu.Split(':').First());
			var cabin = context.Cabins.Include(c => c.Campers).FirstOrDefault(c => c.CabinID == choice);

			//var cabin = context.Cabins.Where(c => c.CabinName == menu).Include(c => c.Campers).FirstOrDefault();
			if (cabin.Campers.Count() != 0)
			{
				var choice2 = AnsiConsole.Prompt(new SelectionPrompt<string>()
				.Title($"{cabin.CabinName} is not empty! \nWould you like to evict it's inhabitants? ")
				.AddChoices(new List<string> { "Yes", "No" })
				.UseConverter(s => s.ToUpperInvariant()));
				if (choice2 == "Yes")
				{
					var campers = cabin.Campers;
					foreach (var c in campers)
					{
						c.CabinID = null;
						context.Update(c);


					}
					context.Cabins.Remove(cabin);
					Console.WriteLine($"{cabin.CabinName} was removed.");
				}
				else
				{
					Console.WriteLine($"{cabin.CabinName} was not removed.");
				}
			}
			else
			{
				context.Cabins.Remove(cabin);
				Console.WriteLine($"{cabin.CabinName} was removed.");

			}
			Console.ReadKey();
			context.SaveChanges();
		}
		public static void AddCamper()
		{
			while (true)
			{
				using var context = new CSAContext();
				string firstName = ValidateString("Enter first name: ");
				string lastName = ValidateString("Enter last name: ");
				DateTime startDate = ValidateDate("Enter start date: ");
				DateTime endDate = ValidateDate("Enter end date: ");
				string nextOfKinFirstName = ValidateString("Next of kin first name: ");
				string nextOfKinLastName = ValidateString("Next of kin last name: ");
				string nextOfKinRelation = ValidateString("Next of kin relation: ");
				string nextOfKinAddress = ValidateString("Next of kin address: ");
				string nextOfKinPhoneNumber = ValidateString("Next of kin phone number: ");
				string nextOfKinEmail = ValidateString("Next of kin email: ");

				var camper = new Camper
				{
					FirstName = firstName,
					LastName = lastName,
					StartDate = startDate,
					EndDate = endDate,
					NextOfKin = new List<NextOfKin>()
				{
					new NextOfKin
					{
						FirstName = nextOfKinFirstName,
						LastName = nextOfKinLastName,
						Relation = nextOfKinRelation,
						ContactInfo = new ContactInfo
						{
							Address = nextOfKinAddress,
							PhoneNumber = nextOfKinPhoneNumber,
							EmailAddress = nextOfKinEmail,
							Role = "NextOfKin"
						}
				}   }
				};
				context.Campers.Add(camper);
				Console.WriteLine("Camper added.");
				Console.ReadKey();
				context.SaveChanges();
				break;
			}
		}
		public static void UpdateCamper()
		{
			using var context = new CSAContext();
			var campers = context.Campers.Select(c => c.FullName).ToList();
			var choices = campers.Concat(new[] { "Back" });
			var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
			.Title("Choose camper to update")
			.AddChoices(choices)
			.UseConverter(s => s.ToUpperInvariant()));
			if (menu.Contains("Back"))
			{
				return;
			}
			var camper = context.Campers.Include(c => c.NextOfKin).Where(c => c.FirstName + " " + c.LastName == menu).FirstOrDefault();
			var menu2 = AnsiConsole.Prompt(new SelectionPrompt<string>()
			.Title("Choose what to update")
			.AddChoices(new[] { "Name", "Start Date", "End Date", "Next of kin", "Abort" })
			.UseConverter(s => s.ToUpperInvariant()));
			if (menu2.Contains("Name"))
			{
				if (camper != null)
				{
					Console.WriteLine("Change camper name");
					string firstName = ValidateString("Enter new first name: ");
					string lastName = ValidateString("Enter new last name: ");
					camper.FirstName = firstName;
					camper.LastName = lastName;

				}
			}
			else if (menu2.Contains("Start Date"))
			{
				Console.WriteLine("Change start date");
				DateTime startDate = ValidateDate("Enter new start date: ");
				camper.StartDate = startDate;
			}
			else if (menu2.Contains("End Date"))
			{
				Console.WriteLine("Change end date");
				DateTime endDate = ValidateDate("Enter new end date: ");
				camper.EndDate = endDate
;
			}
			else if (menu2.Contains("Next of kin"))
			{
				var nextOfKins = camper.NextOfKin.Select(n => n.FullName).ToList();
				var choices2 = nextOfKins.Concat(new[] { "Back" });
				var menu3 = AnsiConsole.Prompt(new SelectionPrompt<string>()
				 .Title("Choose next of kin to update")
				.AddChoices(choices2)
				.UseConverter(s => s.ToUpperInvariant()));
				if (menu3.Contains("Back"))
				{
					return;
				}
				var nextOfKin = camper.NextOfKin.FirstOrDefault(n => n.FirstName + " " + n.LastName == menu3);
				var menu4 = AnsiConsole.Prompt(new SelectionPrompt<string>()
				.Title("Choose what to update")
				.AddChoices(new[] { "First Name", "Last Name", "Relation", "Address", "Phone Number", "Email", "Abort update" })
				.UseConverter(s => s.ToUpperInvariant()));
				if (menu4.Contains("Name"))
				{
					Console.WriteLine("Change next of kin name");
					string firstName = ValidateString("Enter new first name: ");
					string lastName = ValidateString("Enter new last name: ");
					nextOfKin.FirstName = firstName;
					nextOfKin.LastName = lastName;
				}
				else if (menu4.Contains("Relation"))
				{
					Console.WriteLine("Change relation");
					string relation = ValidateString("Enter new relation: ");
					nextOfKin.Relation = relation;
				}
				else if (menu4.Contains("Address"))
				{
					Console.WriteLine("Change address");
					string address = ValidateString("Enter new address: ");
					nextOfKin.ContactInfo.Address = address;
				}
				else if (menu4.Contains("Phone number"))
				{
					Console.WriteLine("Change phone number");
					string phoneNumber = ValidateString("Enter new phone number: ");
					nextOfKin.ContactInfo.PhoneNumber = phoneNumber;
				}
				else if (menu4.Contains("Email"))
				{
					Console.WriteLine("Change email");
					string email = ValidateString("Enter new email: ");
					nextOfKin.ContactInfo.EmailAddress = email;
				}
				else if (menu4.Contains("Abort update"))
				{
					ManageConsole.MainMenu();
				}
			}
			else if (menu2.Contains("Abort"))
			{
				ManageConsole.MainMenu();
			}
			Console.WriteLine("Camper updated.");
			Console.ReadKey();
			context.SaveChanges();
		}
		public static void RemoveCamper()
		{
			using var context = new CSAContext();
			var campers = context.Campers.OrderBy(c => c.LastName).Select(c => c.FirstName + " " + c.LastName).ToList();
			var choices = campers.Concat(new[] { "Abort" });
			var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
			.Title("Choose camper to remove")
			.AddChoices(choices)
			.UseConverter(s => s.ToUpperInvariant()));
			if (menu.Contains("Abort"))
			{
				return;
			}
			var camper = context.Campers.Where(c => c.FirstName + " " + c.LastName == menu).FirstOrDefault();
			if (camper != null)
			{
				context.Campers.Remove(camper);
				Console.WriteLine("Camper was removed.");
				Console.ReadKey();
				context.SaveChanges();
			}
			else
			{
				Console.WriteLine("Camper not found.");
			}
		}
		public static List<List<string>> ViewCounselors()
		{
			List<List<string>> output = new();
			using var context = new CSAContext();
			var counselor = context.Counselors.Include(c => c.ContactInfo)
				.Select(c => new
				{
					c.FirstName,
					c.LastName,
					c.ContactInfo.Address,
					c.ContactInfo.PhoneNumber,
					c.ContactInfo.EmailAddress,
				}).ToList();
			foreach (var c in counselor)
			{
				List<string> list = new();
				foreach (PropertyInfo k in c.GetType().GetProperties())
				{
					list.Add(k.GetValue(c, null).ToString());
				}
				output.Add(list);
			}
			Console.WriteLine();
			return output;
		}
		public static List<List<string>> ViewCabins()
		{
			List<List<string>> output = new();
			using var context = new CSAContext();
			var cabinData = context.Cabins.Include(e => e.Counselor)
				.Select(c => new
				{
					c.CabinName,
					c.Counselor.FullName,
					c.Campers
				}).ToList();

			foreach (var c in cabinData)
			{
				List<string> list = new();
				list.Add(c.CabinName);
				list.Add(c.FullName);
				foreach (var k in c.Campers)
				{
					list.Add(k.FullName);
				}
				output.Add(list);
			}
			Console.WriteLine();
			return output;
		}
		public static List<List<string>> ViewCampers()
		{
			List<List<string>> output = new();
			using var context = new CSAContext();
			var counselor = context.Campers.Include(c => c.Cabin)
				.Select(c => new
				{
					c.FullName,
					c.Cabin.CabinName,
					c.StartDate,
					c.EndDate,
				}).ToList();
			foreach (var c in counselor)
			{
				List<string> list =
				[
					c.FullName,
					c.CabinName != null ? c.CabinName : "Not in a cabin",
					DateOnly.FromDateTime(c.StartDate).ToString(),
					DateOnly.FromDateTime(c.EndDate).ToString(),
				];
				output.Add(list);
			}
			Console.WriteLine();
			return output;
		}

		public static void ReadCSV(string filePath)
		{
			/* Format for csv:
             * FirstName,Lastname,startdate(yyyy/mm/dd),endDate(yyyy/mm/dd);camper
             * FirstName,Lastname;nextofkin
             * FirstName,Lastname,startdate(yyyy/mm/dd),endDate(yyyy/mm/dd);counsler
             * cabinName;cabin
             *
             * Notes: 
             * There must be an equal amount of cabins and counslers.
             * Campers and next of kin will be coupled in the order they apear in the csv file
             */
			var campers = new List<string[]>();
			var nextOfKins = new List<string[]>();
			var counselors = new List<string[]>();
			var cabins = new List<string[]>();

			using var reader = new StreamReader(filePath);

			// Read the header line
			//var headerLine = reader.ReadLine();

			//Read csv file and sort values to each category
			while (!reader.EndOfStream)
			{
				var line = reader.ReadLine();
				if (line == null)
				{
					break;
				}

				// Split the line by comma
				var values = line.Split(',');
				var table = values[^1].Split(';').Last().ToLower(); //Gets last element
				values[^1] = values[^1].Split(';').First(); //Removes last element from array

				if (table == "camper")
				{
					campers.Add(values);
				}
				else if (table == "counselor")
				{
					counselors.Add(values);
				}
				else if (table == "cabin")
				{
					cabins.Add(values);
				}
				else if (table == "nextofkin")
				{
					nextOfKins.Add(values);
				}
			}
			//Add to db Order: Counsler -> Cabin -> Camper -> Next of kin
			if (cabins.Count != counselors.Count)
			{
				throw new Exception("Mismatched lengths of list 'cabin' and 'counselor'");
			}
			using var context = new CSAContext();
			//Add cabins and counslers
			for (int i = 0; i < cabins.Count; i++)
			{
				var cabin = new Cabin
				{
					CabinName = cabins[i][0],
					StartDate = DateTime.Parse(cabins[i][1]),
					EndDate = DateTime.Parse(cabins[i][2]),
					CabinCapacity = int.Parse(cabins[i][3]),
					Counselor = new Counselor
					{
						FirstName = counselors[i][0],
						LastName = counselors[i][1],

						ContactInfo = new ContactInfo
						{
							Address = counselors[i][2],
							PhoneNumber = counselors[i][3],
							EmailAddress = counselors[i][4],
							Role = "Counselor"
						}
					}

				};
				context.Cabins.Add(cabin);
			}
			for (int i = 0; i < campers.Count; i++)
			{
				if (nextOfKins.Count > i)
				{
					var NextOfKin = new NextOfKin
					{
						FirstName = nextOfKins[i][0],
						LastName = nextOfKins[i][1],
						Relation = nextOfKins[i][2],
						Camper = new Camper
						{
							FirstName = campers[i][0],
							LastName = campers[i][1],
							StartDate = DateTime.Parse(campers[i][2]),
							EndDate = DateTime.Parse(campers[i][3])
						},
						ContactInfo = new ContactInfo
						{
							Address = nextOfKins[i][3],
							PhoneNumber = nextOfKins[i][4],
							EmailAddress = nextOfKins[i][5],
							Role = "NextOfKin"
						}
					};
					context.NextOfKins.Add(NextOfKin);
				}
				else //If camper has no next of kin
				{
					var camper = new Camper
					{
						FirstName = campers[i][0],
						LastName = campers[i][1],
						StartDate = DateTime.Parse(campers[i][2]),
						EndDate = DateTime.Parse(campers[i][3])
					};
					context.Campers.Add(camper);
				}
			}
			context.SaveChanges();
		}
		public static string ValidateString(string output)
		{
			string input = "";
			while (true)
			{
				Console.WriteLine(output);
				try
				{
					input = Console.ReadLine();
					if (string.IsNullOrWhiteSpace(input))
					{
						Console.WriteLine("Input can not be empty.");
						Console.ReadKey();
						continue;
					}
					else
					{
						return input;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					Console.ReadKey();

				}
			}

		}
		public static DateTime ValidateDate(string output)
		{
			string input = "";
			while (true)
			{

				Console.WriteLine(output);
				input = Console.ReadLine();
				try
				{
					return DateTime.Parse(input);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					Console.ReadKey();

				}
			}

		}
		public static void Settings()
		{
			var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
				.Title("")
				.AddChoices(new[] { "ADD SEED DATA", "BACK" })
				.UseConverter(s => s.ToUpperInvariant()));
			if (menu.Contains("ADD SEED DATA"))
			{
				string filePath = "seedData.csv";
				ReadCSV(filePath);
				Console.WriteLine("Database seeded.");
				Console.ReadKey();
			}
			else
			{
				return;
			}

		}
	}
}


