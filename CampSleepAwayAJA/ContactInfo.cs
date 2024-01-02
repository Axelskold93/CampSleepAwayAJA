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
	}
}