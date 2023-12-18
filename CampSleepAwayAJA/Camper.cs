namespace CampSleepAwayAJA
{
	public class Camper
	{
		public int CamperID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public ICollection<NextOfKin>? NextOfKin { get; set; }

		public Cabin Cabin { get; set; }
		public int? CabinID { get; set; }
	}
}
