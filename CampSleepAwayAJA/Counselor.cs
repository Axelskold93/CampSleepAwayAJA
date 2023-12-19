namespace CampSleepAwayAJA
{
	public class Counselor
	{
		public int CounselorID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

		public ContactInfo ContactInfo { get; set; }

	}
}
