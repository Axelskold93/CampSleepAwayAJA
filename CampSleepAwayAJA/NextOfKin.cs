namespace CampSleepAwayAJA
{
	public class NextOfKin
	{
		public int NextOfKinID { get; set; }
		public required string FirstName { get; set; }
		public required string LastName { get; set; }
		public Camper Camper { get; set; }
		public required int CamperID { get; set; }
		public string Relation { get; set; }
	}
}
