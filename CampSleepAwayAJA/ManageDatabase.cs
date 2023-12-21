using Microsoft.EntityFrameworkCore;
using Spectre.Console;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace CampSleepAwayAJA
{
    public class ManageDatabase
    {
        public static void AddCounselor()
        {
            using var context = new CSAContext();
            Console.WriteLine("Enter firstname:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter lastname:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter address:");
            string address = Console.ReadLine();
            Console.WriteLine("Enter phonenumber:");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter email:");
            string email = Console.ReadLine();
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
                .Title("Choose what to update")
                .AddChoices(new[] { "First Name", "Last Name", "Address", "Phone Number", "Email" })
                .UseConverter(s => s.ToUpperInvariant()));
            if (menu2.Contains("Name"))
            {
                Console.WriteLine("Enter new firstname");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter new lastname:");
                string lastName = Console.ReadLine();
                counselor.FirstName = firstName;
                counselor.LastName = lastName;
            }
            else if (menu2.Contains("Address"))
            {
                Console.WriteLine("Enter new address:");
                string address = Console.ReadLine();
                counselor.ContactInfo.Address = address;
            }
            else if (menu2.Contains("Phone Number"))
            {
                Console.WriteLine("Enter new phonenumber:");
                string phoneNumber = Console.ReadLine();
                counselor.ContactInfo.PhoneNumber = phoneNumber;
            }
            else if (menu2.Contains("Email"))
            {

                Console.WriteLine("Enter new email:");
                string email = Console.ReadLine();
                counselor.ContactInfo.EmailAddress = email;
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
            var counselor = context.Counselors.Where(c => c.FullName == menu).FirstOrDefault();
            context.Counselors.Remove(counselor);
            Console.WriteLine("Counselor removed.");
            Console.ReadKey();
            context.SaveChanges();
        }
        public static void AddCabin()
        {
            Console.Clear();
            while (true)
            {
                using var context = new CSAContext();
                Console.WriteLine("Enter Cabin Name");
                string cabinName = Console.ReadLine();
                var cabin = new Cabin
                {
                    CabinName = cabinName
                };
                context.Cabins.Add(cabin);

				Console.WriteLine("Cabin added.");
				Console.ReadKey();
				context.SaveChanges();
				break;
			}
		}

        public static void UpdateCabin()
        {
            bool? camperInCabin = null;
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
             .Title("Choose what to update")
             .AddChoices(new[] { "Cabin name", "Cabin leader", "Add camper to cabin", "Abort update" })
             .UseConverter(s => s.ToUpperInvariant()));
            //Gör egen metod
            if (menu2.Contains("Cabin name"))
            {
                Console.WriteLine("Enter new cabin name");
                string cabinName = Console.ReadLine();
                cabin.CabinName = cabinName;
            }
            //Gör egen metod av denna
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
                var counselor = context.Counselors.Where(c => c.FullName == menu3).FirstOrDefault();
                cabin.CounselorID = counselor.CounselorID;
            }
            else if (menu2.Contains("Add camper to cabin"))
            {
               camperInCabin = AddCamperToCabin(cabin);

            }
			else if (menu2.Contains("Abort update"))
			{
				ManageConsole.MainMenu();
			}
            if (camperInCabin == true || camperInCabin == null)
            {
               Console.WriteLine("Cabin updated.");
                Console.ReadKey();
                context.SaveChanges();
            }
        }
        public static bool AddCamperToCabin(Cabin? cabin)
        {
            using var context = new CSAContext();
            var cabins = context.Cabins.Select(c => c.CabinName).ToList();
            if (cabin.Campers?.Count() > 4)
            {
                Console.WriteLine("Maximum cabin capacity reached.");
            }
            var campers = context.Campers.Select(c => c.FullName).ToList();
            var choices = campers.Concat(new[] { "Abort" });
            if (campers.Count() == 0)
            {
                Console.WriteLine("No campers available.");
                Console.ReadKey();
                return false;
            }
            var menu2 = AnsiConsole.Prompt(new SelectionPrompt<string>()
               .Title("Choose camper to add to cabin")
               .AddChoices(choices)
               .UseConverter(s => s.ToUpperInvariant()));
            var camper = context.Campers.Where(c => c.FullName == menu2).FirstOrDefault();
            if (camper.CabinID == cabin.CabinID)
            {
                Console.WriteLine("The camper is already in this cabin.");              
                Console.ReadKey();
                return false;
            }
			else if (menu2.Contains("Abort"))
			{
				ManageConsole.MainMenu();
			}
			
            cabin.Campers?.Add(camper);
            camper.CabinID = cabin.CabinID;
            Console.WriteLine("Camper added to cabin.");
            Console.ReadKey();
            context.SaveChanges();
            return true;
        }
        public static void RemoveCabin()
        {
            using var context = new CSAContext();
            var cabins = context.Cabins.Select(c => c.CabinName).ToList();
            var choices = cabins.Concat(new[] { "Abort" });
            if (cabins.Count() == 0)
            {
                Console.WriteLine("No cabins available.");
                Console.ReadKey();
                return;
            }
            var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose cabin to remove:")
                .AddChoices(choices)
                .UseConverter(s => s.ToUpperInvariant()));
			if (menu.Contains("Abort"))
			{
				ManageConsole.MainMenu();
			}
            var cabin = context.Cabins.Where(c => c.CabinName == menu).FirstOrDefault();
            context.Cabins.Remove(cabin);
            Console.WriteLine("Cabin removed.");
            Console.ReadKey();
            context.SaveChanges();
        }
        public static void AddCamper()
        {
            using var context = new CSAContext();
            Console.WriteLine("Enter first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter start date: ");
            string startDate = Console.ReadLine();
            Console.WriteLine("Enter end date: ");
            string endDate = Console.ReadLine();
            Console.WriteLine("Next of kin first name: ");
            string nextOfKinFirstName = Console.ReadLine();
            Console.WriteLine("Next of kin last name: ");
            string nextOfKinLastName = Console.ReadLine();
            Console.WriteLine("Next of kin relation: ");
            string nextOfKinRelation = Console.ReadLine();
            Console.WriteLine("Next of kin address: ");
            string nextOfKinAddress = Console.ReadLine();
            Console.WriteLine("Next of kin phone number: ");
            string nextOfKinPhoneNumber = Console.ReadLine();
            Console.WriteLine("Next of kin email: ");
            string nextOfKinEmail = Console.ReadLine();

			var camper = new Camper
			{
				FirstName = firstName,
				LastName = lastName,
				StartDate = DateTime.Parse(startDate),
				EndDate = DateTime.Parse(endDate),
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
			var camper = context.Campers.Where(c => c.FirstName + " " + c.LastName == menu).FirstOrDefault();
			var menu2 = AnsiConsole.Prompt(new SelectionPrompt<string>()
			.Title("Choose what to update")
			.AddChoices(new[] { "Name", "Start Date", "End Date", "Next of kin", "Abort" })
			.UseConverter(s => s.ToUpperInvariant()));
			if (menu2.Contains("Name"))
			{
				if (camper != null)
				{
					Console.WriteLine("Change camper name");
					Console.WriteLine("Enter new first name: ");
					string firstName = Console.ReadLine();
					Console.WriteLine("Enter new last name: ");
					string lastName = Console.ReadLine();
					camper.FirstName = firstName;
					camper.LastName = lastName;

				}
			}
			else if (menu2.Contains("Start Date"))
			{
				Console.WriteLine("Change start date");
				Console.WriteLine("Enter new start date: ");
				string startDate = Console.ReadLine();
				camper.StartDate = DateTime.Parse(startDate);
			}
			else if (menu2.Contains("End Date"))
			{
				Console.WriteLine("Change end date");
				Console.WriteLine("Enter new end date: ");
				string endDate = Console.ReadLine();
				camper.EndDate = DateTime.Parse(endDate);
			}
			else if (menu2.Contains("Next of kin"))
			{
				var nextOfKins = context.NextOfKins.Select(c => c.FullName).ToList();
                var choices2 = nextOfKins.Concat(new[] { "Back" });
                var menu3 = AnsiConsole.Prompt(new SelectionPrompt<string>()
	         	.Title("Choose next of kin to update")
				.AddChoices(choices2)
				.UseConverter(s => s.ToUpperInvariant()));
				if (menu3.Contains("Back"))
				{
					return;
				}
				var nextOfKin = context.NextOfKins.Where(c => c.FirstName + " " + c.LastName == menu3).FirstOrDefault();
				var menu4 = AnsiConsole.Prompt(new SelectionPrompt<string>()
				.Title("Choose what to update")
				.AddChoices(new[] { "First Name", "Last Name", "Relation", "Address", "Phone Number", "Email", "Abort update" })
				.UseConverter(s => s.ToUpperInvariant()));
				if (menu4.Contains("Name"))
				{
					Console.WriteLine("Change next of kin name");
					Console.WriteLine("Enter new first name: ");
					string firstName = Console.ReadLine();
					Console.WriteLine("Enter new last name: ");
					string lastName = Console.ReadLine();
					nextOfKin.FirstName = firstName;
					nextOfKin.LastName = lastName;
				}
				else if (menu4.Contains("Relation"))
				{
					Console.WriteLine("Change relation");
					Console.WriteLine("Enter new relation: ");
					string relation = Console.ReadLine();
					nextOfKin.Relation = relation;
				}
				else if (menu4.Contains("Address"))
				{
					Console.WriteLine("Change address");
					Console.WriteLine("Enter new address: ");
					string address = Console.ReadLine();
					nextOfKin.ContactInfo.Address = address;
				}
				else if (menu4.Contains("Phone Number"))
				{
					Console.WriteLine("Change phone number");
					Console.WriteLine("Enter new phone number: ");
					string phoneNumber = Console.ReadLine();
					nextOfKin.ContactInfo.PhoneNumber = phoneNumber;
				}
				else if (menu4.Contains("Email"))
				{
					Console.WriteLine("Change email");
					Console.WriteLine("Enter new email: ");
					string email = Console.ReadLine();
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
			context.Campers.Remove(camper);
			Console.WriteLine("Camper removed.");
			Console.ReadKey();
			context.SaveChanges();
		}
		public static List<List<string>> ViewCounselors()
		{
			List<List<string>> output = new();
			using var context = new CSAContext();
			var counselor = context.Counselors.Include(e => e.ContactInfo)
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
		public static void ViewCabins()
		{
			/*using var context = new CSAContext();
			 * 			var cabin = context.Cabins.Where(c => c.CabinName == "Cabin 2").FirstOrDefault();
			 * 						Console.WriteLine(cabin.CabinName);*/
		}
		public static void ViewCampers()
		{
			/*using var context = new CSAContext();
			 * 			var camper = context.Campers.Where(c => c.FirstName == "John").FirstOrDefault();
			 * 						Console.WriteLine(camper.FirstName);*/
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
				throw new Exception("Missmatched lenghts of list 'cabin' and 'counsler'");
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
		public static void Settings()
		{
			var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
				.Title("")
				.AddChoices(new[] {"Add seed data", "Back"})
				.UseConverter(s => s.ToUpperInvariant()));
			if (menu.Contains("Add seed data"))
			{
                string filePath = "C:\\Users\\axels\\OneDrive\\Documents\\GitHub\\CampSleepAwayAja\\CampSleepAwayAJA\\seedData.csv";
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


