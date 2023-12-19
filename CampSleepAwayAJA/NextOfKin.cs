namespace CampSleepAwayAJA
{
	public class NextOfKin
	{
		public int NextOfKinID { get; set; }
		public required string FirstName { get; set; }
		public required string LastName { get; set; }
		public required Camper Camper { get; set; }
		public string Relation { get; set; }
        public ContactInfo ContactInfo { get; set; }
    }
}
