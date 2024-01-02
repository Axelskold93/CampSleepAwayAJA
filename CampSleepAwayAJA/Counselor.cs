using System.ComponentModel.DataAnnotations.Schema;

namespace CampSleepAwayAJA
{
	public class Counselor : Person
	{
		[Column(Order = 1)]
		public int CounselorID { get; set; }
        [ForeignKey("ContactInfoId")]
		public ContactInfo ContactInfo { get; set; }
		public Cabin cabin { get; set; }
	}
}