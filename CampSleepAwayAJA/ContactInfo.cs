namespace CampSleepAwayAJA
{
	public class ContactInfo
	{
		public int ContactInfoID { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public string EmailAddress { get; set; }

		public string Role { get; set; }
		public NextOfKin? NextOfKin { get; set; }
		public int? NextOfKinID { get; set; }

		public Counselor? Counselor { get; set; }
		public int? CounselorID { get; set; }




	}
}
