using System.Data;
using System.Net;
using System.Net.WebSockets;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

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
            var counselors = context.Counselors.Select(c => c.FirstName).ToList();
            var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose counselor to update")
                .AddChoices(counselors)
                .UseConverter(s => s.ToUpperInvariant()));
            var counselor = context.Counselors.Where(c => c.FirstName == menu).FirstOrDefault();
            if (counselors.Count() == 0)
            {
                Console.WriteLine("No counselors available.");
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
            var counselors = context.Counselors.Select(c => c.FirstName).ToList();
            var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose counselor to remove")
                .AddChoices(counselors)
                .UseConverter(s => s.ToUpperInvariant()));
            var counselor = context.Counselors.Where(c => c.FirstName == menu).FirstOrDefault();
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

            using var context = new CSAContext();
            var cabins = context.Cabins.Select(c => c.CabinName).ToList();
            var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose cabin to update")
                .AddChoices(cabins)
                .UseConverter(s => s.ToUpperInvariant()));
            var cabin = context.Cabins.Where(c => c.CabinName == menu).FirstOrDefault();
            var menu2 = AnsiConsole.Prompt(new SelectionPrompt<string>()
             .Title("Choose what to update")
             .AddChoices(new[] { "Cabin name", "Cabin leader", "Add camper to cabin" })
             .UseConverter(s => s.ToUpperInvariant()));
            if (menu2.Contains("Cabin name"))
            {
                Console.WriteLine("Enter new cabin name");
                string cabinName = Console.ReadLine();
                cabin.CabinName = cabinName;
            }
            else if (menu2.Contains("Cabin leader"))
            {
                var counselors = context.Counselors.Select(c => c.FirstName).ToList();
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
                var counselor = context.Counselors.Where(c => c.FirstName == menu3).FirstOrDefault();
                cabin.CounselorID = counselor.CounselorID;
            }
            else if (menu2.Contains("Add camper to cabin"))
            {
                AddCamperToCabin();
            }
            Console.WriteLine("Cabin updated.");
            Console.ReadKey();
            context.SaveChanges();
        }
        public static void AddCamperToCabin()
        {
            using var context = new CSAContext();
            var cabins = context.Cabins.Select(c => c.CabinName).ToList();
            if (cabins.Count() == 0)
            {
                Console.WriteLine("No cabins available.");
                Console.ReadKey();
                return;
            }
            var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
               .Title("Choose cabin to add camper to")
               .AddChoices(cabins)
               .UseConverter(s => s.ToUpperInvariant())); 
            var cabin = context.Cabins.Where(c => c.CabinName == menu).FirstOrDefault();
            var campers = context.Campers.Select(c => c.FirstName).ToList();
            if (campers.Count() == 0)
            {
                Console.WriteLine("No campers available.");
                Console.ReadKey();
                return;
            }
            var menu2 = AnsiConsole.Prompt(new SelectionPrompt<string>()
               .Title("Choose camper to add to cabin")
               .AddChoices(campers)
               .UseConverter(s => s.ToUpperInvariant()));
            var camper = context.Campers.Where(c => c.FirstName == menu2).FirstOrDefault();
            cabin.Campers.Add(camper);
            Console.WriteLine("Camper added to cabin.");
            Console.ReadKey();
            context.SaveChanges();

        }
        public static void RemoveCabin()
        {
            using var context = new CSAContext();
            var cabins = context.Cabins.Select(c => c.CabinName).ToList();
            if (cabins.Count() == 0)
            {
                Console.WriteLine("No cabins available.");
                Console.ReadKey();
                return;
            }
            var menu = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose cabin to remove:")
                .AddChoices(cabins)
                .UseConverter(s => s.ToUpperInvariant()));
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
                            EmailAddress = nextOfKinEmail
                 
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
            /*using var context = new CSAContext();
             *             *            var camper = context.Campers.Where(c => c.FirstName == "John").FirstOrDefault();
             *                         *                       camper.FirstName = "Johnny";
             *                                     *                                  context.SaveChanges();


			**context.SaveChanges();
		};
		context.NextOfKins.Add(nextOfKin);
            context.SaveChanges();*/
        }
        public static void RemoveCamper()
        {
            /*using var context = new CSAContext();
			var camper = context.Campers.Where(c => c.FirstName == "John").FirstOrDefault();
			context.Campers.Remove(camper);
			context.SaveChanges();*/
        }
        public static List<List<string>> ViewCounselors()
        {
            List<List<string>> output = new();
            using var context = new CSAContext();
            var counselor = context.Counselors.Include(e => e.ContactInfo)
                .Select(c => new {
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

    }
}


