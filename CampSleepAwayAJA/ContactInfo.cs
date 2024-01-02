using System.ComponentModel.DataAnnotations;

namespace CampSleepAwayAJA
{
	public class ContactInfo
	{
		public int ContactInfoID { get; set; }
		[Required]
		public string Address { get; set; }
		[Required]
		public string PhoneNumber { get; set; }
		[Required]
		public string EmailAddress { get; set; }
		[Required]
		public string Role { get; set; }

		public Counselor? Counselor { get; set; }
		public int? CounslerId { get; set; }
		public NextOfKin? nextOfKin { get; set; }
		public int? NextOfKin { get; set; }
	}
}