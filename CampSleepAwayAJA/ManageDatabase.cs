﻿using System.Data;
using System.Net;
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
            /*using var context = new CSAContext();
             *            var counselor = context.Counselors.Where(c => c.FirstName == "Jane").FirstOrDefault();
             *                       counselor.FirstName = "Janet";
             *                                  context.SaveChanges();*/
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
             .AddChoices(new[] { "Cabin Name", "Cabin Leader" })
             .UseConverter(s => s.ToUpperInvariant()));
            if (menu2.Contains("Cabin Name"))
            {
                Console.WriteLine("Enter new cabin name");
                string cabinName = Console.ReadLine();
                cabin.CabinName = cabinName;
            }
            else if (menu2.Contains("Cabin Leader"))
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
            Console.WriteLine("Cabin updated.");
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
                NextOfKin = new List<NextOfKin>
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
                    }
                }
            };
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
        public static void ViewCounselors()
        {
            /*using var context = new CSAContext();
             *             *            var counselor = context.Counselors.Where(c => c.FirstName == "Janet").FirstOrDefault();
             *                         *                       Console.WriteLine(counselor.FirstName);*/
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


