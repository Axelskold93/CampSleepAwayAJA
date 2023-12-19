namespace CampSleepAwayAJA
{
	public class ManageDatabase
	{
		public static void AddCabin()
		{
			/*using var context = new CSAContext();
			var cabin = new Cabin
			{
				CabinName = "Cabin 1"
			};
			context.Cabins.Add(cabin);
			context.SaveChanges();*/
		}

		public static void UpdateCabin()
		{
			/*using var context = new CSAContext();
			 * 			var cabin = context.Cabins.Where(c => c.CabinName == "Cabin 1").FirstOrDefault();
			 * 						cabin.CabinName = "Cabin 2";
			 * 									context.SaveChanges();*/
		}

		public static void ViewCabins()
		{
			/*using var context = new CSAContext();
			 * 			var cabin = context.Cabins.Where(c => c.CabinName == "Cabin 2").FirstOrDefault();
			 * 						Console.WriteLine(cabin.CabinName);*/
		}
		public static void RemoveCabin()
		{
			/*using var context = new CSAContext();
			var cabin = context.Cabins.Where(c => c.CabinName == "Cabin 1").FirstOrDefault();
			context.Cabins.Remove(cabin);
			context.SaveChanges();*/
		}

		public static void AddCamper()
		{
			/*using var context = new CSAContext();

			var camper = new Camper
			{
				FirstName = "John",
				LastName = "Doe",
				StartDate = new DateTime(2021, 6, 1),
				EndDate = new DateTime(2021, 6, 30),
				CabinID = 1

			};
			context.Campers.Add(camper);
			context.SaveChanges();*/
		}
		public static void RemoveCamper()
		{
			/*using var context = new CSAContext();
			var camper = context.Campers.Where(c => c.FirstName == "John").FirstOrDefault();
			context.Campers.Remove(camper);
			context.SaveChanges();*/
		}

		public static void ViewCampers()
		{
			/*using var context = new CSAContext();
			 * 			var camper = context.Campers.Where(c => c.FirstName == "John").FirstOrDefault();
			 * 						Console.WriteLine(camper.FirstName);*/
		}

		public static void AddCounselor()
		{
			/*using var context = new CSAContext();

			var counselor = new Counselor
			{
				FirstName = "Jane",
				LastName = "Doe",
				StartDate = new DateTime(2021, 6, 1),
				EndDate = new DateTime(2021, 6, 30),
				
				//ContactInfoID = 1
			};
			context.Counselors.Add(counselor);
			context.SaveChanges();*/
		}
		public static void RemoveCounselor()
		{
			/*using var context = new CSAContext();
			var counselor = context.Counselors.Where(c => c.FirstName == "Jane").FirstOrDefault();
			context.Counselors.Remove(counselor);
			context.SaveChanges();*/
		}

		public static void AddNextOfKin()
		{
			/*using var context = new CSAContext();

			var nextOfKin = new NextOfKin
			{
				CamperID = 1,
				FirstName = "John",
				LastName = "Doe",
				Relation = "Father",

			};
			context.NextOfKins.Add(nextOfKin);
			context.SaveChanges();*/
		}
		public static void RemoveNextOfKin()
		{
			/*using var context = new CSAContext();
			var nextOfKin = context.NextOfKins.Where(c => c.FirstName == "John").FirstOrDefault();
			context.NextOfKins.Remove(nextOfKin);
			context.SaveChanges();*/
		}
		public static void UpdateCounselor()
		{
			/*using var context = new CSAContext();
             *            var counselor = context.Counselors.Where(c => c.FirstName == "Jane").FirstOrDefault();
             *                       counselor.FirstName = "Janet";
             *                                  context.SaveChanges();*/
		}
		public static void ViewCounselors()
		{
			/*using var context = new CSAContext();
             *             *            var counselor = context.Counselors.Where(c => c.FirstName == "Janet").FirstOrDefault();
             *                         *                       Console.WriteLine(counselor.FirstName);*/
		}
		public static void UpdateCamper()
		{
			/*using var context = new CSAContext();
             *             *            var camper = context.Campers.Where(c => c.FirstName == "John").FirstOrDefault();
             *                         *                       camper.FirstName = "Johnny";
             *                                     *                                  context.SaveChanges();*/
		}

	}
}
//             *                                     *                                  context.SaveChanges();
//            };
//            context.NextOfKins.Add(nextOfKin);
//            context.SaveChanges();*/
//        }
//        static void ReadCSV(string filePath)
//        {
//            var campers = new List<string[]>();
//            var nextOfKins = new List<string[]>();
//            var counselor = new List<string[]>();
//            var cabins = new List<string[]>();

//            using var reader = new StreamReader(filePath);

//            // Read the header line
//            var headerLine = reader.ReadLine();

//            //Read csv file and sort values to each category
//            while (!reader.EndOfStream)
//            {
//                var line = reader.ReadLine();
//                if (line == null)
//                {
//                    break;
//                }

//                // Split the line by comma
//                var values = line.Split(',');
//                var table = values[values.Length - 1].Split(';').Last().ToLower();

//                if (table == "camper")
//                {
//                    campers.Add(values);
//                }
//                else if (table == "counselor")
//                {
//                    counselor.Add(values);
//                }
//                else if (table == "cabin")
//                {
//                    cabins.Add(values);
//                }
//                else if (table == "nextofkin")
//                {
//                    nextOfKins.Add(values);
//                }
//            }
//            //Add to db Order: Counsler -> Cabin -> Camper -> Next of kin
//            //Problem add realtions 
//            using var context = new CSAContext();
//            foreach (var c in counselor)
//            {
//                if (c != null)
//                {
//                    var counsler = new Counselor
//                    {
//                        FirstName = c[0],
//                        LastName = c[1],
//                        StartDate = DateTime.Parse(c[2]),
//                        EndDate = DateTime.Parse(c[3])
//                    };
//                    context.Counselors.Add(counsler);
//                }
//            }
//            context.SaveChanges();
//            foreach (var c in cabins)
//            {
//                if (c != null)
//                {
//                    var cabin = new Cabin
//                    {
//                        CabinName = c[0]

//                    };
//                    context.Cabins.Add(cabin);
//                }
//            }
//            foreach (var c in campers)
//            {
//                if (c != null)
//                {
//                    var camper = new Camper
//                    {
//                        FirstName = c[0],
//                        LastName = c[1],
//                        StartDate = DateTime.Parse(c[2]),
//                        EndDate = DateTime.Parse(c[3])
//                    };
//                    context.Campers.Add(camper);
//                }
//            }
//            foreach (var c in nextOfKins)
//            {
//                if (c != null)
//                {
//                    var nextOfKin = new NextOfKin
//                    {
//                        FirstName = c[0],
//                        LastName = c[1],
//                        CamperID = 1
//                    };
//                    context.NextOfKins.Add(nextOfKin);
//                }
//            }

//        }

//    }
//}
