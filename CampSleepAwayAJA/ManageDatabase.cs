namespace CampSleepAwayAJA
{
	public class ManageDatabase
	{
		public static void AddCabin()
		{
			using var context = new CSAContext();
			var cabin = new Cabin
			{
				CabinName = "Cabin 1"
			};
			context.Cabins.Add(cabin);
			context.SaveChanges();
		}
		public static void RemoveCabin()
		{
			using var context = new CSAContext();
			var cabin = context.Cabins.Where(c => c.CabinName == "Cabin 1").FirstOrDefault();
			context.Cabins.Remove(cabin);
			context.SaveChanges();
		}

		public static void AddCamper()
		{
			using var context = new CSAContext();

			var camper = new Camper
			{
				FirstName = "John",
				LastName = "Doe",
				StartDate = new DateTime(2021, 6, 1),
				EndDate = new DateTime(2021, 6, 30),
				CabinID = 1,

			};
		}
		public static void RemoveCamper()
		{
			using var context = new CSAContext();
			var camper = context.Campers.Where(c => c.FirstName == "John").FirstOrDefault();
			context.Campers.Remove(camper);
			context.SaveChanges();
		}

		public static void AddCounselor()
		{
			using var context = new CSAContext();

			var counselor = new Counselor
			{
				FirstName = "Jane",
				LastName = "Doe",
				StartDate = new DateTime(2021, 6, 1),
				EndDate = new DateTime(2021, 6, 30),
				CabinID = 1,
				//ContactInfoID = 1
			};
		}
		public static void RemoveCounselor()
		{
			using var context = new CSAContext();
			var counselor = context.Counselors.Where(c => c.FirstName == "Jane").FirstOrDefault();
			context.Counselors.Remove(counselor);
			context.SaveChanges();
		}

		public static void AddNextOfKin()
		{
			var context = new CSAContext();

			var nextOfKin = new NextOfKin
			{
				CamperID = 1,
				FirstName = "John",
				LastName = "Doe",
				Relation = "Father",
				
			};
		}
		public static void RemoveNextOfKin()
		{
			using var context = new CSAContext();
			var nextOfKin = context.NextOfKins.Where(c => c.FirstName == "John").FirstOrDefault();
			context.NextOfKins.Remove(nextOfKin);
			context.SaveChanges();
		}

	}
}
